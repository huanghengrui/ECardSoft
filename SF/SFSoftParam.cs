using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSFSoftParam : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SFSoftParam";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadParamInfo();
    }

    private void LoadParamInfo()
    {
      SFSoftParamInfo paramInfo = new SFSoftParamInfo("");
      DataTableReader dr = null;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "8" }));
        if (dr.Read()) paramInfo = new SFSoftParamInfo(dr["Value"].ToString());
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      txtBeginTime1.Text = paramInfo.BeginTime[0];
      txtBeginTime2.Text = paramInfo.BeginTime[1];
      txtBeginTime3.Text = paramInfo.BeginTime[2];
      txtBeginTime4.Text = paramInfo.BeginTime[3];
      txtEndTime1.Text = paramInfo.EndTime[0];
      txtEndTime2.Text = paramInfo.EndTime[1];
      txtEndTime3.Text = paramInfo.EndTime[2];
      txtEndTime4.Text = paramInfo.EndTime[3];
    }

    public frmSFSoftParam(string title, string CurrentTool)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      MaskedTextBox txt;
      string infoStr = "";
      for (int i = 1; i <= 4; i++)
      {
        txt = (MaskedTextBox)this.Controls["txtBeginTime" + i.ToString()];
        infoStr = infoStr + txt.Text + "#";
        txt = (MaskedTextBox)this.Controls["txtEndTime" + i.ToString()];
        infoStr = infoStr + txt.Text + "@";
      }
      infoStr = infoStr.Substring(0, infoStr.Length - 1);
      DataTableReader dr = null;
      bool IsOk = false;
      string sql = "";
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "8" }));
        if (dr.Read())
          sql = Pub.GetSQL(DBCode.DB_000002, new string[] { "9", infoStr });
        else
          sql = Pub.GetSQL(DBCode.DB_000002, new string[] { "10", infoStr });
        db.ExecSQL(sql);
        IsOk = true;
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (IsOk)
      {
        db.WriteSYLog(this.Text, CurrentOprt, sql);
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}