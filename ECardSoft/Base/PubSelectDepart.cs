using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmPubSelectDepart : frmBaseDialog
  {
    public string DepartSysID = "";
    public string DepartID = "";
    public string DepartName = "";

    protected override void InitForm()
    {
      formCode = "PubSelectDepart";
      base.InitForm();
      DepartSysID = "";
      DepartID = "";
      DepartName = "";
      InitDepartTreeView(tvDepart);
    }

    public frmPubSelectDepart()
    {
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (tvDepart.SelectedNode == null)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectDepart", ""));
        return;
      }
      DepartSysID = tvDepart.SelectedNode.Tag.ToString();
      if (!db.CheckDepartPowerByDeptSysID(DepartSysID)) return;
      if (!db.GetDepartIDAndName(DepartSysID, ref DepartID, ref DepartName)) return;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void tvDepart_DoubleClick(object sender, EventArgs e)
    {
      btnOk.PerformClick();
    }
  }
}