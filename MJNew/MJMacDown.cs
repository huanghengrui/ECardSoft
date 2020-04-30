using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacDown : frmMJMacBase
  {
    private byte DownFlag = 0;
    private string Title = "";
    private string CurrentOprt = "";
    private AccessV2API.TYPE_HolidayPack holiPack = new AccessV2API.TYPE_HolidayPack();
    private AccessV2API.TYPE_TimeSegmentPack timePack = new AccessV2API.TYPE_TimeSegmentPack();
    private AccessV2API.TYPE_TimeGroupPack groupPack = new AccessV2API.TYPE_TimeGroupPack();

    protected override void InitForm()
    {
      formCode = "MJMacDown";
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemAdd", false);
      SetToolItemState("ItemEdit", false);
      SetToolItemState("ItemDelete", false);
      SetToolItemState("ItemLine2", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemTAG2", false);
      SetToolItemState("ItemLine3", true);
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      holiPack.Holiday = new AccessV2API.TYPE_Holiday[10];
      timePack.Data = new AccessV2API.TYPE_TimeSegment[50];
      groupPack.Data = new AccessV2API.TYPE_TimeGroup[50];
    }

    public frmMJMacDown(string title, string CurrentTool, byte flag)
    {
      DownFlag = flag;
      Title = title;
      CurrentOprt = CurrentTool;
      InitializeComponent();
    }

    protected override void ExecItemTAG1()
    {
      bool IsError = false;
      DataTableReader dr = null;
      try
      {
        if (DownFlag == 0)
        {
          holiPack.Count = 0;
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003002, new string[] { "0" }));
          AccessV2API.TYPE_Holiday holi;
          DateTime d = new DateTime();
          while (dr.Read())
          {
            holi = new AccessV2API.TYPE_Holiday();
            UInt32.TryParse(dr["MJHoliID"].ToString(), out holi.Index);
            holi.Enable = Convert.ToUInt32(Convert.ToBoolean(dr["MJHoliIsApply"].ToString()));
            UInt32.TryParse(dr["MacTimeNo"].ToString(), out holi.SegmentNo);
            if (DateTime.TryParse(dr["MJHoliBeginDate"].ToString(), out d))
            {
              DeviceObject.objMJNew.DateTimeToMJDateTime(d, ref holi.TimeBegin);
            }
            if (DateTime.TryParse(dr["MJHoliEndDate"].ToString(), out d))
            {
              DeviceObject.objMJNew.DateTimeToMJDateTime(d, ref holi.TimeEnd);
            }
            holiPack.Holiday[holiPack.Count] = holi;
            holiPack.Count++;
          }
        }
        else
        {
          timePack.Count = 0;
          groupPack.Count = 0;
          AccessV2API.TYPE_TimeSegment time;
          string s;
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "7" }));
          while (dr.Read())
          {
            time = new AccessV2API.TYPE_TimeSegment();
            int.TryParse(dr["MacTimeNo"].ToString(), out time.Index);
            time.Times = new int[6];
            time.TimeBegin = new AccessV2API.SYSTEMTIME[6];
            time.TimeEnd = new AccessV2API.SYSTEMTIME[6];
            time.Mode = new int[6];
            for (int i = 1; i <= 6; i++)
            {
              int.TryParse(dr["MacTimeTimes" + i.ToString()].ToString(), out time.Times[i - 1]);
              s = dr["MacTimeBeginTime" + i.ToString()].ToString();
              if (s.Length == 5)
              {
                ushort.TryParse(s.Substring(0, 2), out time.TimeBegin[i - 1].wHour);
                ushort.TryParse(s.Substring(3, 2), out time.TimeBegin[i - 1].wMinute);
              }
              s = dr["MacTimeEndTime" + i.ToString()].ToString();
              if (s.Length == 5)
              {
                ushort.TryParse(s.Substring(0, 2), out time.TimeEnd[i - 1].wHour);
                ushort.TryParse(s.Substring(3, 2), out time.TimeEnd[i - 1].wMinute);
              }
              int.TryParse(dr["MacTimeMode" + i.ToString()].ToString(), out time.Mode[i - 1]);
            }
            timePack.Data[timePack.Count] = time;
            timePack.Count++;
          }
          timePack.Count = 50;
          AccessV2API.TYPE_TimeGroup group;
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "1000" }));
          while (dr.Read())
          {
            group = new AccessV2API.TYPE_TimeGroup();
            int.TryParse(dr["MacTimeHeaderTimeNo"].ToString(), out group.Index);
            group.WeekDay = new int[7];
            int.TryParse(dr["MacTimeHeaderSunday"].ToString(), out group.WeekDay[0]);
            int.TryParse(dr["MacTimeHeaderMonday"].ToString(), out group.WeekDay[1]);
            int.TryParse(dr["MacTimeHeaderTuesday"].ToString(), out group.WeekDay[2]);
            int.TryParse(dr["MacTimeHeaderWednesday"].ToString(), out group.WeekDay[3]);
            int.TryParse(dr["MacTimeHeaderThursday"].ToString(), out group.WeekDay[4]);
            int.TryParse(dr["MacTimeHeaderFriday"].ToString(), out group.WeekDay[5]);
            int.TryParse(dr["MacTimeHeaderSaturday"].ToString(), out group.WeekDay[6]);
            int.TryParse(dr["MacTimeHeaderHoliday"].ToString(), out group.Holiday);
            groupPack.Data[groupPack.Count] = group;
            groupPack.Count++;
          }
        }
      }
      catch (Exception E)
      {
        IsError = true;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (IsError) return;
      base.ExecItemTAG1();
      ExecMacOprt(0);
    }

    protected override void ExecItemTAG2()
    {
      base.ExecItemTAG2();
      ExecMacOprt(1);
    }

    protected override bool ExecMacCommand(byte flag, string MacSN, ref string MacMsg)
    {
      bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
      switch (flag)
      {
        case 0:
          if (DownFlag == 0)
          {
            ret = DeviceObject.objMJNew.TimeHolidayWrite(holiPack);
          }
          else
          {
            ret = DeviceObject.objMJNew.WriteTimeSegment(timePack);
            if (ret) ret = DeviceObject.objMJNew.WriteTimeGroup(groupPack);
          }
          break;
      }
      return ret;
    }
  }
}