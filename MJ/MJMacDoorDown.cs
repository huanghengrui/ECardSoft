using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacDoorDown : frmMJMacDoorBase
  {
    private byte DownFlag = 0;
    private string Title = "";
    private string CurrentOprt = "";
    private QHKS.TMJTimeOpenDoorInfo timeOpenInfo = new QHKS.TMJTimeOpenDoorInfo();

    protected override void InitForm()
    {
      formCode = "MJMacDoorDown";
      SetToolItemState("ItemEdit", false);
      SetToolItemState("ItemLine2", false);
      SetToolItemState("ItemTAG3", true);
      HideStop = true;
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
    }

    public frmMJMacDoorDown(string title, string CurrentTool, byte flag)
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
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003009, new string[] { "0" }));
          timeOpenInfo = new QHKS.TMJTimeOpenDoorInfo();
          timeOpenInfo.BeginTime = new string[21];
          timeOpenInfo.EndTime = new string[21];
          int index = 0;
          while (dr.Read())
          {
            for (int i = 1; i <= 2; i++)
            {
              timeOpenInfo.BeginTime[index * 3 + i - 1] = dr["BeginTime" + i.ToString()].ToString();
              timeOpenInfo.EndTime[index * 3 + i - 1] = dr["EndTime" + i.ToString()].ToString();
            }
            index += 1;
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
      ExecMacDoorOprt(0);
    }

    protected override void ExecItemTAG3()
    {
      base.ExecItemTAG3();
      ExecMacDoorOprt(1);
    }

    protected override bool ExecMacDoorCommand(byte flag, TMJDoorInfo doorInfo, ref string MacMsg)
    {
      bool ret = base.ExecMacDoorCommand(flag, doorInfo, ref MacMsg);
      byte doorID = Convert.ToByte(doorInfo.DoorID);
      switch (flag)
      {
        case 0:
          if (DownFlag == 0)
            ret = DeviceObject.objMJ.SetMacTimeOpenDoorInfo(doorID, ref timeOpenInfo);
          break;
        case 1:
          if (DownFlag == 0)
            ret = DeviceObject.objMJ.ClearMacTimeOpenDoorInfo(doorID);
          break;
      }
      return ret;
    }
  }
}