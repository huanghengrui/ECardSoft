using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSeaFaceSelectEmp : frmBaseDialog
  {
    private string title = "";
    private string oprt = "";
    public TDownSelectList[] selList = new TDownSelectList[0];
    public string selEmpSysID = "";

    protected override void InitForm()
    {
      formCode = "KQFaceSelectEmp";
      IsFinger = true;
      CreateCardGridView(cardGrid);
      selList = new TDownSelectList[0];
      base.InitForm();
      lblQuickSearchToolTip.ForeColor = Color.Blue;
      this.Text = oprt;
    }

    public frmSeaFaceSelectEmp(string Title, string Oprt)
    {
      title = Title;
      oprt = Oprt;
      InitializeComponent();
    }

    private void btnQuickSearch_Click(object sender, EventArgs e)
    {
      QuickSearchNormalCard(btnQuickSearch.Text, cardGrid, 0, IsFinger);
    }

    private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
    {
      QuickSearchNormalCard(txtQuickSearch, e, cardGrid, 0, IsFinger);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      cardGrid.DataSource = null;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (cardGrid.RowCount == 0)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
        return;
      }
      selList = new TDownSelectList[cardGrid.RowCount];
      DataTable dtEmp = (DataTable)cardGrid.DataSource;
      for (int i = 0; i < dtEmp.Rows.Count; i++)
      {
        selList[i] = new TDownSelectList();
        selList[i].EmpSysID = dtEmp.Rows[i]["EmpSysID"].ToString();
        selList[i].EnrollNumber = Convert.ToUInt32(dtEmp.Rows[i]["CardFingerNo"].ToString());
        selList[i].EnrollName = dtEmp.Rows[i]["EmpName"].ToString();
        selEmpSysID += "'" + selList[i].EmpSysID + "',";
      }
      if (selEmpSysID != "") selEmpSysID = selEmpSysID.Substring(0, selEmpSysID.Length - 1);
      this.Close();
      this.DialogResult = DialogResult.OK;
    }
  }
}