using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmPubSelectAddress : frmBaseDialog
  {
    public string AddressSysID = "";
    public string AddressID = "";
    public string AddressName = "";

    protected override void InitForm()
    {
      formCode = "PubSelectAddress";
      base.InitForm();
      AddressSysID = "";
      AddressID = "";
      AddressName = "";
      InitAddressTreeView(tvAddress);
    }

    public frmPubSelectAddress()
    {
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (tvAddress.SelectedNode == null) 
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectAddress", ""));
        return;
      }
      if (tvAddress.SelectedNode.Level == 0)
      {
        AddressSysID = "";
        AddressID = "";
        AddressName = "";
      }
      else
      {
        AddressSysID = tvAddress.SelectedNode.Tag.ToString();
        if (!db.GetAddressIDAndName(AddressSysID, ref AddressID, ref AddressName)) return;
      }
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void tvDepart_DoubleClick(object sender, EventArgs e)
    {
      btnOk.PerformClick();
    }
  }
}