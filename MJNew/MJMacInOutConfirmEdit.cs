using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacInOutConfirmEdit : frmBaseDialog
  {
    private const int MaxCard = 5;

    protected override void InitForm()
    {
      formCode = "MJMacInOutConfirmEdit";
      CreateCardGridView(cardGrid);
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadData();
    }

    public frmMJMacInOutConfirmEdit(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      string IsInoutCard = "";
      string MacInoutCard = "";
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "102", SysID }));
        if (dr.Read())
        {
          IsInoutCard = dr["IsInoutCard"].ToString();
          MacInoutCard = dr["MacInoutCard"].ToString();
        }
        dr.Close();
        TInOutCard card = new TInOutCard(MacInoutCard);
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
      chkEnabled.Checked = IsInoutCard.ToUpper() == "Y";
      chkEnabled_CheckedChanged(null, null);
    }

    private void chkEnabled_CheckedChanged(object sender, EventArgs e)
    {
      gbxEmpInfo.Enabled = chkEnabled.Checked;
    }

    private void btnQuickSearch_Click(object sender, EventArgs e)
    {
      QuickSearchNormalCard(btnQuickSearch.Text, cardGrid, MaxCard);
    }

    private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
    {
      QuickSearchNormalCard(txtQuickSearch, e, cardGrid, MaxCard);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string IsInoutCard = "N";
      string MacInoutCard = "";
      if (chkEnabled.Checked)
      {
        IsInoutCard = "Y";
        DataTable dtGrid = (DataTable)cardGrid.DataSource;
        for (int i = 0; i < dtGrid.Rows.Count; i++)
        {
          MacInoutCard += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
        }
      }
      string sql = "";
      try
      {
        sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "111", IsInoutCard, MacInoutCard, SysID });
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