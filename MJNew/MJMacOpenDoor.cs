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
    private UInt32 DoorDelay = 0;

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
      if (!Pub.InputBox(CurrentTool, Pub.GetResText(formCode, "Msg002", ""), 3, 60 * 60 * 24, ref ResultNumber)) return;
      DoorDelay = (UInt32)ResultNumber;
      base.ExecItemTAG2();
      ExecMacDoorOprt(1);
    }

    protected override bool ExecMacDoorCommand(byte flag, TMJDoorInfo doorInfo, ref string MacMsg)
    {
      bool ret = base.ExecMacDoorCommand(flag, doorInfo, ref MacMsg);
      switch (flag)
      {
        case 0:
          ret = DeviceObject.objMJNew.RemoteOpen(doorInfo.DoorID);
          break;
        case 1:
          ret = DeviceObject.objMJNew.AwhileOpen(doorInfo.DoorID, DoorDelay);
          break;
      }
      return ret;
    }
  }
}