using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacUnReturnEdit : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "MJMacUnReturnEditNew";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadData();
    }

    public frmMJMacUnReturnEdit(string title, string CurrentTool, string GUID, string MacSN)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
      if (MacSN.Substring(1, 1) == "1")
      {
        panel2.Enabled = false;
        panel2.Visible = false;
        this.Height = panel2.Height + 140;
      }
      else
      {
        panel1.Enabled = false;
        panel1.Visible = false;
      }
    }

    private void LoadData()
    {
      string IsReturn = "";
      string MacReturns = "";
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "102", SysID }));
        if (dr.Read())
        {
          IsReturn = dr["IsReturn"].ToString();
          MacReturns = dr["MacReturns"].ToString();
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
      chkEnabled.Checked = IsReturn.ToUpper() == "Y";
      if (panel1.Enabled)
      {
        chk1.Checked = MacReturns == "11";
      }
      else
      {
        chk21.Checked = MacReturns == "21";
        chk22.Checked = MacReturns == "22";
        chk23.Checked = MacReturns == "23";
      }
      chkEnabled_CheckedChanged(null, null);
    }

    private void CheckBox_Click(object sender, EventArgs e)
    {
      if (sender == chk21 && chk21.Checked)
      {
        chk22.Checked = false;
        chk23.Checked = false;
      }
      else if (sender == chk22 && chk22.Checked)
      {
        chk21.Checked = false;
        chk23.Checked = false;
      }
      else if (sender == chk23 && chk23.Checked)
      {
        chk21.Checked = false;
        chk22.Checked = false;
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string IsReturn = "N";
      string MacReturns = "";
      if (chkEnabled.Checked)
      {
        IsReturn = "Y";
        if (panel1.Enabled)
        {
          MacReturns = "10";
          if (chk1.Checked) MacReturns = "11";
        }
        else
        {
          MacReturns = "20";
          if (chk21.Checked)
            MacReturns = "21";
          else if (chk22.Checked)
            MacReturns = "22";
          else if (chk23.Checked)
            MacReturns = "23";
        }
      }
      string sql = "";
      try
      {
        sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "106", IsReturn, MacReturns, SysID });
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

    private void chkEnabled_CheckedChanged(object sender, EventArgs e)
    {
      panel1.Enabled = panel1.Visible && chkEnabled.Checked;
      panel2.Enabled = panel2.Visible && chkEnabled.Checked;
    }
  }
}