using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacInfo : frmMJMacBase
  {
    private string DownMessage = "";

    protected override void InitForm()
    {
      formCode = "MJMacInfo";
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemTAG2", true);
      SetToolItemState("ItemTAG3", true);
      SetToolItemState("ItemTAG4", true);
      SetToolItemState("ItemTAG5", true);
      SetToolItemState("ItemLine3", true);
      SetToolItemState("ItemTAGExt", true);
      AddExtDropDownItem("ItemMessage", ItemMessage_Click);
      AddExtDropDownItem("ItemReStart", ItemReStart_Click);
      AddExtDropDownItem("ItemInit", ItemInit_Click);
      base.InitForm();
    }

    public frmMJMacInfo()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmMJMacInfoAdd frm = new frmMJMacInfoAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmMJMacInfoAdd frm = new frmMJMacInfoAdd(this.Text, CurrentTool, GetMacSysID());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      frmPubFindMac frm = new frmPubFindMac(this.Text, CurrentTool, 0);
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemTAG2()
    {
      base.ExecItemTAG2();
      ExecMacOprt(0);
    }

    protected override void ExecItemTAG3()
    {
      base.ExecItemTAG3();
      txtMag.Text = "";
      ExecMacOprt(1);
    }

    protected override void ExecItemTAG4()
    {
      base.ExecItemTAG4();
      ExecMacOprt(2, 1);
    }

    protected override void ExecItemTAG5()
    {
      if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg001", ""))) return;
      base.ExecItemTAG5();
      ExecMacOprt(3);
    }

    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(State);
      ItemTAG1.Enabled = State;
      txtMag.Enabled = State;
      SetContextMenuState();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_003001, new string[] { "3", dataGrid[1, rowIndex].Value.ToString() });
      sql.Add(ret);
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      ret = dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
      return ret;
    }

    protected override bool ExecMacCommand(byte flag, string MacSN, ref string MacMsg)
    {
      bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
      AccessV2API.TYPE_Setting setting = new AccessV2API.TYPE_Setting();
      switch (flag)
      {
        case 0:
          ret = SyncTime();
          break;
        case 1:
          ret = DeviceObject.objMJNew.ReadSetting(out setting);
          if (ret)
          {
            byte DoorType = Convert.ToByte(MacSN.Substring(1, 1));
            string DoorState = "";
            for (byte i = 1; i <= DoorType; i++)
            {
              DoorState += i.ToString() + ":" + Pub.GetResText(formCode, "MJDoorMagnet" + setting.DoorState[i - 1].ToString(), "") + ";";
            }
            AccessV2API.TYPE_DoorBasic DoorBasic = new AccessV2API.TYPE_DoorBasic();
            AccessV2API.TYPE_DoorExpert DoorExpert = new AccessV2API.TYPE_DoorExpert();
            string StateInfo = "";
            string IntervalInfo = "";
            string DelayInfo = "";
            for (byte i = 1; i <= DoorType; i++)
            {
              ret = DeviceObject.objMJNew.ReadDoorInfo(i, ref DoorBasic, ref DoorExpert);
              if (!ret) break;
              StateInfo += i.ToString() + ":" + Pub.GetResText(formCode, "MJDoorState" + DoorBasic.State.ToString(), "") + ";";
              IntervalInfo += i.ToString() + ":" + DoorBasic.Interval.ToString() + "s;";
              DelayInfo += i.ToString() + ":" + DoorBasic.LockedDelay.ToString() + "s;";
            }
            string msg = Pub.GetResText(formCode, "MacSN", "") + ": " + MacSN + "\r\n    " + Pub.GetResText(formCode, "MacInfoNew", "");
            msg = string.Format(msg, DeviceObject.objMJNew.MJDateTimeToString(setting.DateTime), setting.Version, setting.LogCount,
              setting.RegCount, setting.RightType, DoorState, setting.Restrict.ToString("X"), setting.AntiReturn.ToString("X"),
              StateInfo, IntervalInfo, DelayInfo);
            ShowMsg(msg + "\r\n");
          }
          break;
        case 2:
          ret = DeviceObject.objMJNew.ReadSetting(out setting);
          if (!ret) break;
          setting.RightType = 32;
          ret = DeviceObject.objMJNew.SetSetting(setting);
          for (int i = 0; i < upDoorInfo.Count; i++)
          {
            if (upDoorInfo[i].MacSN.ToString() == MacSN)
            {
              ret = DeviceObject.objMJNew.SetDoorBasicInfo(upDoorInfo[i].DoorID, upDoorInfo[i].DoorInfo);
              if (!ret) break;
            }
          }
          break;
        case 3:
          ret = DeviceObject.objMJNew.ClearRegister();
          break;
        case 4:
          ret = DeviceObject.objMJNew.WriteComment(DownMessage);
          break;
        case 5:
          ret = DeviceObject.objMJNew.RebootDevice();
          break;
        case 6:
          ret = DeviceObject.objMJNew.Init();
          break;
      }
      return ret;
    }

    private void ItemMessage_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
      CurrentTool = ((ToolStripItem)sender).Text;
      if (!Pub.InputBox(CurrentTool, Pub.GetResText(formCode, "Msg002", ""), ref DownMessage)) return;
      if (DownMessage.Length > 1024) DownMessage = DownMessage.Substring(0, 1024);
      ExecMacOprt(4);
    }

    private void ItemReStart_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
      CurrentTool = ((ToolStripItem)sender).Text;
      ExecMacOprt(5);
    }

    private void ItemInit_Click(object sender, EventArgs e)
    {
      if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "MsgInitQuery", ""))) return;
      if (!db.CheckOprtRole(formCode, "C", AllowCheckOprtRole)) return;
      CurrentTool = ((ToolStripItem)sender).Text;
      ExecMacOprt(6);
    }

    private void ShowMsg(string msg)
    {
      txtMag.Text = txtMag.Text + msg;
    }
  }
}