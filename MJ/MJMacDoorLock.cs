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
        if (MacSN.Substring(0, 2) == "02")
          MacLocks = "20";
        else
          MacLocks = "40";
      }
      switch (flag)
      {
        case 0:
          ret = DeviceObject.objMJ.SetMacLocksInfo(Convert.ToByte(MacLocks));
          break;
      }
      return ret;
    }
  }
}