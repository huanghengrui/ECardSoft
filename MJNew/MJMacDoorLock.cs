using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacDoorLock : frmMJMacBase
  {
    protected override void InitForm()
    {
      formCode = "MJMacDoorLock";
      ExtField.Add("MacLocks");
      QueryFlag = 1;
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemAdd", false);
      SetToolItemState("ItemDelete", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemLine3", true);
      base.InitForm();
    }

    public frmMJMacDoorLock()
    {
      InitializeComponent();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmMJMacDoorLockEdit frm = new frmMJMacDoorLockEdit(this.Text, CurrentTool, GetMacSysID(), GetMacSN());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      ExecMacOprt(0);
    }

    protected override bool ExecMacCommand(byte flag, string MacSN, ref string MacMsg)
    {
      bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
      string MacLocks = GetExtField(MacSN);
      if ((MacLocks == "") || (!Pub.IsNumeric(MacLocks)))
      {
        if (MacSN.Substring(1, 1) == "2")
          MacLocks = "20";
        else
          MacLocks = "40";
      }
      switch (flag)
      {
        case 0:
          AccessV2API.TYPE_Setting setting = new AccessV2API.TYPE_Setting();
          ret = DeviceObject.objMJNew.ReadSetting(out setting);
          if (ret)
          {
            if (MacLocks == "21")
              setting.Restrict = 0x1200;
            else if (MacLocks == "41")
              setting.Restrict = 0x1200;
            else if (MacLocks == "42")
              setting.Restrict = 0x7000;
            else if (MacLocks == "43")
              setting.Restrict = 0x1248;
            else if (MacLocks == "44")
              setting.Restrict = 0x1600;
            else if (MacLocks == "45")
              setting.Restrict = 0x1E00;
            else if (MacLocks == "46")
              setting.Restrict = 0x3C00;
            ret = DeviceObject.objMJNew.SetSetting(setting);
          }
          break;
      }
      return ret;
    }
  }
}