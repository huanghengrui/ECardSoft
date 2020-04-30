using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmPubSelectIDName : frmBaseDialog
  {
    private string title = "";
    private string _QuerySQL = "";
    private string _FieldID = "";
    private string _FieldName = "";
    public string SelectID = "";
    public string SelectName = "";

    protected override void InitForm()
    {
      formCode = "PubSelectIDName";
      Column1.DataPropertyName = _FieldID;
      Column2.DataPropertyName = _FieldName;
      base.InitForm();
      this.Text = Pub.GetResText(formCode, "SelectCheck", "") + title;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        bindingSource.DataSource = db.GetDataTable(_QuerySQL);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
    }

    public frmPubSelectIDName(string Title, string QuerySQL, string FieldID, string FieldName)
    {
      title = Title;
      _QuerySQL = QuerySQL;
      _FieldID = FieldID;
      _FieldName = FieldName;
      SelectID = "";
      SelectName = "";
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      if (drv == null) return;
      SelectID = drv[_FieldID].ToString();
      SelectName = drv[_FieldName].ToString();
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void dataGrid_DoubleClick(object sender, EventArgs e)
    {
      btnOk.PerformClick();
    }
  }
}