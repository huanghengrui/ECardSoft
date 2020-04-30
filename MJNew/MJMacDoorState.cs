using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacDoorState : frmMJMacDoorBase
  {
    protected override void InitForm()
    {
      formCode = "MJMacDoorState";
      SetToolItemState("ItemEdit", false);
      SetToolItemState("ItemLine2", false);
      SetToolItemState("ItemLine3", false);
      SetToolItemState("ItemTAG2", true);
      SetToolItemState("ItemTAG3", true);
      IgnoreTAG2State = true;
      base.InitForm();
    }

    public frmMJMacDoorState()
    {
      InitializeComponent();
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      ExecMacDoorOprt(1);
    }

    protected override void ExecItemTAG2()
    {
      base.ExecItemTAG2();
      ExecMacDoorOprt(2);
    }

    protected override void ExecItemTAG3()
    {
      base.ExecItemTAG3();
      ExecMacDoorOprt(3);
    }

    protected override bool ExecMacDoorCommand(byte flag, TMJDoorInfo doorInfo, ref string MacMsg)
    {
      bool ret = base.ExecMacDoorCommand(flag, doorInfo, ref MacMsg);
      ret = DeviceObject.objMJNew.DoorOpen(doorInfo.DoorID, flag);
      return ret;
    }
  }
}