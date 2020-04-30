using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacOpenDoor : frmMJMacDoorBase
  {
    private byte DoorDelay = 0;

    protected override void InitForm()
    {
      formCode = "MJMacOpenDoor";
      SetToolItemState("ItemEdit", false);
      SetToolItemState("ItemLine2", false);
      SetToolItemState("ItemLine3", false);
      SetToolItemState("ItemTAG2", true);
      IgnoreTAG2State = true;
      base.InitForm();
    }

    public frmMJMacOpenDoor()
    {
      InitializeComponent();
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      ExecMacDoorOprt(0);
    }

    protected override void ExecItemTAG2()
    {
      int ResultNumber = 0;
      if (!Pub.InputBox(CurrentTool, Pub.GetResText(formCode, "Msg001", ""), 3, 240, ref ResultNumber)) return;
      DoorDelay = Convert.ToByte(ResultNumber);
      base.ExecItemTAG2();
      ExecMacDoorOprt(1);
    }

    protected override bool ExecMacDoorCommand(byte flag, TMJDoorInfo doorInfo, ref string MacMsg)
    {
      bool ret = base.ExecMacDoorCommand(flag, doorInfo, ref MacMsg);
      switch (flag)
      {
        case 0:
          ret = DeviceObject.objMJ.SetDoorOpenRemote(Convert.ToByte(doorInfo.DoorID));
          break;
        case 1:
          ret = DeviceObject.objMJ.SetDoorOpenTemp(Convert.ToByte(doorInfo.DoorID), DoorDelay);
          break;
      }
      return ret;
    }
  }
}