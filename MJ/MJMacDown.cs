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
    private List<QHKS.TMJHolidayInfo> holiList = new List<QHKS.TMJHolidayInfo>();
    private List<QHKS.TMJMacTime> timeList = new List<QHKS.TMJMacTime>();
    private List<QHKS.TMJMacTimeGroup> groupList = new List<QHKS.TMJMacTimeGroup>();

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
      SetToolItemState("ItemTAG2", true);
      SetToolItemState("ItemLine3", true);
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
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
          holiList.Clear();
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003002, new string[] { "0" }));
          QHKS.TMJHolidayInfo holi;
          DateTime d = new DateTime();
          while (dr.Read())
          {
            holi = new QHKS.TMJHolidayInfo();
            byte.TryParse(dr["MJHoliID"].ToString(), out holi.ID);
            holi.Enabled = Convert.ToByte(Convert.ToBoolean(dr["MJHoliIsApply"].ToString()));
            if (DateTime.TryParse(dr["MJHoliBeginDate"].ToString(), out d)) holi.StartTime = d;
            if (DateTime.TryParse(dr["MJHoliEndDate"].ToString(), out d)) holi.EndTime = d;
            holiList.Add(holi);
          }
        }
        else
        {
          timeList.Clear();
          groupList.Clear();
          if (SystemInfo.AdvTimeGroup)
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "7" }));
          else
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "0" }));
          QHKS.TMJMacTime time;
          while (dr.Read())
          {
            time = new QHKS.TMJMacTime();
            time.IsNew = SystemInfo.AdvTimeGroup ? Convert.ToByte(1) : Convert.ToByte(0);
            byte.TryParse(dr["MacTimeNo"].ToString(), out time.ID);
            byte.TryParse(dr["MacTimeLimit"].ToString(), out time.Limit);
            byte.TryParse(dr["MacTimeWeekIndex"].ToString(), out time.Week);
            time.StartTime = new string[6];
            time.EndTime = new string[6];
            for (int i = 1; i <= 6; i++)
            {
              time.StartTime[i - 1] = dr["MacTimeBeginTime" + i.ToString()].ToString();
              time.EndTime[i - 1] = dr["MacTimeEndTime" + i.ToString()].ToString();
            }
            time.InType = new byte[2];
            byte.TryParse(dr["MacTimeInType1"].ToString(), out time.InType[0]);
            byte.TryParse(dr["MacTimeInType2"].ToString(), out time.InType[1]);
            timeList.Add(time);
          }
          if (SystemInfo.AdvTimeGroup)
          {
            QHKS.TMJMacTimeGroup group;
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "1000" }));
            while (dr.Read())
            {
              group = new QHKS.TMJMacTimeGroup();
              byte.TryParse(dr["MacTimeHeaderTimeNo"].ToString(), out group.ID);
              byte.TryParse(dr["MacTimeHeaderSunday"].ToString(), out group.SunID);
              byte.TryParse(dr["MacTimeHeaderMonday"].ToString(), out group.MonID);
              byte.TryParse(dr["MacTimeHeaderTuesday"].ToString(), out group.TueID);
              byte.TryParse(dr["MacTimeHeaderWednesday"].ToString(), out group.WedID);
              byte.TryParse(dr["MacTimeHeaderThursday"].ToString(), out group.ThuID);
              byte.TryParse(dr["MacTimeHeaderFriday"].ToString(), out group.FriID);
              byte.TryParse(dr["MacTimeHeaderSaturday"].ToString(), out group.SatID);
              groupList.Add(group);
            }
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
            QHKS.TMJHolidayInfo holi;
            for (int i = 0; i < holiList.Count; i++)
            {
              holi = holiList[i];
              ret = DeviceObject.objMJ.SetMacHolidayInfo(ref holi);
              if (!ret) break;
            }
          }
          else
          {
            if (SystemInfo.AdvTimeGroup)
            {
              QHKS.TMJMacTimeGroup group;
              for (int i = 0; i < groupList.Count; i++)
              {
                group = groupList[i];
                ret = DeviceObject.objMJ.SetMacTimeGroupInfo(ref group);
                if (!ret) break;
              }
            }
            else
              ret = true;
            if (ret)
            {
              QHKS.TMJMacTime time;
              for (int i = 0; i < timeList.Count; i++)
              {
                time = timeList[i];
                ret = DeviceObject.objMJ.SetMacTimeInfo(ref time);
                if (!ret) break;
              }
            }
          }
          break;
        case 1:
          if (DownFlag == 0)
            ret = DeviceObject.objMJ.ClearMacHoliday();
          else
            ret = DeviceObject.objMJ.ClearMacTime();
          break;
      }
      return ret;
    }
  }
}