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
          QHKS.TMJMacPasswordInfo passInfo = new QHKS.TMJMacPasswordInfo();
          passInfo.Pass = new string[8];
          for (int i = 0; i < doorPasswordList.Count; i++)
          {
            passInfo.Pass[i] = doorPasswordList[i];
          }
          ret = DeviceObject.objMJ.SetMacPasswordInfo(ref passInfo);
          break;
      }
      return ret;
    }
  }
}