using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacMoreCardEdit : frmBaseDialog
  {
    private const int MaxCard = 20;

    protected override void InitForm()
    {
      formCode = "MJMacMoreCardEdit";
      CreateCardGridView(cardGrid);
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      SetTextboxNumber(txtCount);
      LoadData();
    }

    public frmMJMacMoreCardEdit(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      string IsMoreCard = "";
      string MacMoreCard = "";
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "102", SysID }));
        if (dr.Read())
        {
          IsMoreCard = dr["IsMoreCard"].ToString();
          MacMoreCard = dr["MacMoreCard"].ToString();
        }
        dr.Close();
        TMacMoreCard card = new TMacMoreCard(MacMoreCard);
        chkEnabledIn.Checked = card.EnabledIn == 1;
        chkEnabledOut.Checked = card.EnabledOut == 1;
        txtCount.Text = card.EmpCount.ToString();
        if (card.EmpList != "")
        {
          string sql = "";
          if (SystemInfo.HasFaCard)
            sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "108", card.EmpList });
          else
            sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "301", card.EmpList });
          dr = db.GetDataReader(sql);
          while (dr.Read())
          {
            QuickSearchNormalCardByEmpSysID(dr["EmpSysID"].ToString(), cardGrid, MaxCard);
          }
        }
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
      chkEnabled.Checked = IsMoreCard.ToUpper() == "Y";
      chkEnabled_CheckedChanged(null, null);
    }

    private void chkEnabled_CheckedChanged(object sender, EventArgs e)
    {
      panel1.Enabled = chkEnabled.Checked;
      gbxEmpInfo.Enabled = chkEnabled.Checked;
      label1.Enabled = chkEnabled.Checked;
      label2.Enabled = chkEnabled.Checked;
      txtCount.Enabled = chkEnabled.Checked;
    }

    private void btnQuickSearch_Click(object sender, EventArgs e)
    {
      QuickSearchNormalCard(btnQuickSearch.Text, cardGrid, MaxCard);
      txtCount.Text = cardGrid.RowCount.ToString();
    }

    private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
    {
      QuickSearchNormalCard(txtQuickSearch, e, cardGrid, MaxCard);
      txtCount.Text = cardGrid.RowCount.ToString();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string IsMoreCard = "N";
      string MacMoreCard = "";
      if (chkEnabled.Checked)
      {
        IsMoreCard = "Y";
        if (!Pub.IsNumeric(txtCount.Text.Trim()))
        {
          txtCount.Focus();
          ShowErrorEnterCorrect(label1.Text);
          return;
        }
        if ((Convert.ToInt32(txtCount.Text.Trim()) < 0) && (Convert.ToInt32(txtCount.Text.Trim()) > MaxCard))
        {
          txtCount.Focus();
          ShowErrorEnterCorrect(label1.Text);
          return;
        }
        DataTable dtGrid = (DataTable)cardGrid.DataSource;
        for (int i = 0; i < dtGrid.Rows.Count; i++)
        {
          MacMoreCard += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
        }
        MacMoreCard = string.Format("{0}@{1}@{2}@{3}", Convert.ToByte(chkEnabledIn.Checked), 
          Convert.ToByte(chkEnabledOut.Checked), txtCount.Text.Trim(), MacMoreCard);
      }
      string sql = "";
      try
      {
        sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "107", IsMoreCard, MacMoreCard, SysID });
        db.ExecSQL(sql);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
        return;
      }
      db.WriteSYLog(this.Text, CurrentOprt, sql);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      cardGrid.DataSource = null;
    }
  }
}