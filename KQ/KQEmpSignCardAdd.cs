using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQEmpSignCardAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "KQEmpSignCardAdd";
      CreateCardGridView(cardGrid);
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      toolTip.SetToolTip(txtQuickSearch, Pub.GetResText(formCode, "lblQuickSearchToolTip", ""));
      RefreshButton();
    }

    public frmKQEmpSignCardAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void btnSelectEmp_Click(object sender, EventArgs e)
    {
      frmPubSelectEmp frm = new frmPubSelectEmp(false);
      if (frm.ShowDialog() == DialogResult.OK)
      {
        txtEmpNo.Text = frm.EmpNo;
        txtEmpNo_Leave(null, null);
      }
    }

    private void txtEmpNo_Leave(object sender, EventArgs e)
    {
      txtEmpNo.Tag = "";
      txtEmpName.Text = "";
      txtDepart.Text = "";
      if (txtEmpNo.Text.Trim() != "")
      {
        string EmpSysID = "";
        string EmpName = "";
        string DepartID = "";
        string DepartName = "";
        if (db.GetEmpInfo(txtEmpNo.Text.Trim(), ref EmpSysID, ref EmpName, ref DepartID, ref DepartName))
        {
          txtEmpNo.Tag = EmpSysID;
          txtEmpName.Text = EmpName;
          txtDepart.Text = "[" + DepartID + "]" + DepartName;
        }
        else
        {
          txtEmpNo.Text = "";
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorEmpNotExists", ""));
        }
      }
    }

    private void btnQuickSearch_Click(object sender, EventArgs e)
    {
      QuickSearchNormalEmp(btnQuickSearch.Text, cardGrid);
    }

    private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
    {
      QuickSearchNormalEmp(txtQuickSearch, e, cardGrid);
    }

    private void GetSql(string EmpSysID, string Remark, ref List<string> sql)
    {
      DateTime KQDate = new DateTime();
      DateTime dt = new DateTime();
      int KQTime = 0;
      int days = 0;
      string tmp = "";
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        DateTime.TryParse(dataGrid[0, i].Value.ToString(), out KQDate);
        DateTime.TryParse(dataGrid[1, i].Value.ToString(), out dt);
        KQTime = dt.Hour * 60 * 60 + dt.Minute * 60;
        int.TryParse(dataGrid[2, i].Value.ToString(), out days);
        for (int j = 0; j < days; j++)
        {
          tmp = Pub.GetSQL(DBCode.DB_002011, new string[] { "4", EmpSysID,
            KQDate.AddDays(j).ToString(SystemInfo.SQLDateFMT), KQTime.ToString(), Remark, OprtInfo.OprtSysID });
          sql.Add(tmp);
        }
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!CheckEmp()) return;
      if (dataGrid.RowCount == 0)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
        return;
      }
      string EmpSysID = txtEmpNo.Tag.ToString();
      string Remark = txtRemark.Text.Trim();
      if (!Pub.CheckTextMaxLength(label8.Text, Remark, txtRemark.MaxLength)) return;
      List<string> sql = new List<string>();
      GetSql(EmpSysID, Remark, ref sql);
      if (cardGrid.DataSource != null)
      {
        DataTable dtGrid = (DataTable)cardGrid.DataSource;
        for (int i = 0; i < dtGrid.Rows.Count; i++)
        {
          if (dtGrid.Rows[i]["EmpSysID"].ToString() == EmpSysID) continue;
          GetSql(dtGrid.Rows[i]["EmpSysID"].ToString(), Remark, ref sql);
        }
      }
      if (db.ExecSQL(sql) != 0) return;
      db.WriteSYLog(this.Text, CurrentOprt, sql);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private bool CheckEmp()
    {
      txtEmpNo.Tag = "";
      if (txtEmpNo.Text.Trim() == "")
      {
        txtEmpNo.Focus();
        ShowErrorEnterCorrect(label2.Text);
        return false;
      }
      string EmpSysID = "";
      string EmpName = "";
      string DepartID = "";
      string DepartName = "";
      if (!db.GetEmpInfo(txtEmpNo.Text.Trim(), ref EmpSysID, ref EmpName, ref DepartID, ref DepartName))
      {
        txtEmpNo.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorEmpNotExists", ""));
        return false;
      }
      txtEmpNo.Tag = EmpSysID;
      return true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      frmKQEmpSignCardAddA frm = new frmKQEmpSignCardAddA(button1.Text);
      if (frm.ShowDialog() != DialogResult.OK) return;
      DateTime dtDate = frm.CardDate;
      DateTime dtTime = frm.CardTime;
      dataGrid.Rows.Add();
      dataGrid[0, dataGrid.RowCount - 1].Value = dtDate.ToShortDateString();
      dataGrid[1, dataGrid.RowCount - 1].Value = dtTime.ToString("HH:mm");
      dataGrid[2, dataGrid.RowCount - 1].Value = frm.CardDays;
      dataGrid.Rows[dataGrid.RowCount - 1].Selected = true;
      dataGrid.CurrentCell = dataGrid.Rows[dataGrid.RowCount - 1].Cells[0];
      RefreshButton();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      dataGrid.Rows.Remove(dataGrid.SelectedRows[0]);
      RefreshButton();
    }

    private void RefreshButton()
    {
      button1.Enabled = true;
      button2.Enabled = dataGrid.RowCount > 0;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      cardGrid.DataSource = null;
    }
  }
}