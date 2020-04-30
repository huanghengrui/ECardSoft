using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacPassword : frmMJMacDoorBase
  {
    protected override void InitForm()
    {
      formCode = "MJMacPassword";
      ExtField.Add("MacDoorPassword");
      base.InitForm();
    }

    public frmMJMacPassword()
    {
      InitializeComponent();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmMJMacPasswordEdit frm = new frmMJMacPasswordEdit(this.Text, CurrentTool, GetMacDoorSysID());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      ExecMacDoorOprt(0, 1);
    }

    protected override bool ExecMacDoorCommand(byte flag, TMJDoorInfo doorInfo, ref string MacMsg)
    {
      bool ret = base.ExecMacDoorCommand(flag, doorInfo, ref MacMsg);
      switch (flag)
      {
        case 0:
          AccessV2API.TYPE_DoorBasic basic = new AccessV2API.TYPE_DoorBasic();
          AccessV2API.TYPE_DoorExpert expert = new AccessV2API.TYPE_DoorExpert();
          ret = DeviceObject.objMJNew.ReadDoorInfo(doorInfo.DoorID, ref basic, ref expert);
          if (ret)
          {
            if (doorInfo.DoorPass.Length >= 16)
            {
              basic.PasswordA = doorInfo.DoorPass.Substring(0, 8);
              basic.PasswordB = doorInfo.DoorPass.Substring(8, 8);
            }
            else
            {
              basic.PasswordA = "00000000";
              basic.PasswordB = "00000000";
            }
            ret = DeviceObject.objMJNew.SetDoorBasicInfo(doorInfo.DoorID, basic);
          }
          break;
      }
      return ret;
    }
  }
}