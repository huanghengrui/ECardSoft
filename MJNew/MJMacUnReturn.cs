using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacUnReturn : frmMJMacBase
  {
    protected override void InitForm()
    {
      formCode = "MJMacUnReturn";
      ExtField.Add("IsReturn");
      ExtField.Add("MacReturns");
      QueryFlag = 2;
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

    public frmMJMacUnReturn()
    {
      InitializeComponent();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmMJMacUnReturnEdit frm = new frmMJMacUnReturnEdit(this.Text, CurrentTool, GetMacSysID(), GetMacSN());
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
      string IsReturn = GetExtField(MacSN);
      string MacReturns = GetExtField(MacSN, 1);
      if (IsReturn.ToUpper() == "Y")
      {
        if ((MacReturns == "") || (!Pub.IsNumeric(MacReturns))) MacReturns = "0";
      }
      else
        MacReturns = "0";
      switch (flag)
      {
        case 0:
          AccessV2API.TYPE_Setting setting = new AccessV2API.TYPE_Setting();
          ret = DeviceObject.objMJNew.ReadSetting(out setting);
          if (ret)
          {
            if (MacReturns == "11")
              setting.Restrict = 0x1200;
            else if (MacReturns == "21")
              setting.Restrict = 0x1200;
            else if (MacReturns == "22")
              setting.Restrict = 0x1248;
            else if (MacReturns == "23")
              setting.Restrict = 0x5A00;
            ret = DeviceObject.objMJNew.SetSetting(setting);
          }
          break;
      }
      return ret;
    }
  }
}