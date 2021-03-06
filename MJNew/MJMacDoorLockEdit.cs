using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacDoorLockEdit : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "MJMacDoorLockEditNew";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadData();
    }

    public frmMJMacDoorLockEdit(string title, string CurrentTool, string GUID, string MacSN)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
      if (MacSN.Substring(1, 1) == "2")
      {
        panel4.Enabled = false;
        panel4.Visible = false;
        this.Height = panel2.Height + 90;
      }
      else
      {
        panel2.Enabled = false;
        panel2.Visible = false;
      }
    }

    private void LoadData()
    {
      string MacLocks = "";
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "1008", SysID }));
        if (dr.Read()) MacLocks = dr["MacLocks"].ToString();
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
      if (panel2.Enabled)
      {
        chk2.Checked = MacLocks == "21";
      }
      else
      {
        chk41.Checked = MacLocks == "41";
        chk42.Checked = MacLocks == "42";
        chk43.Checked = MacLocks == "43";
        chk44.Checked = MacLocks == "44";
        chk45.Checked = MacLocks == "45";
        chk46.Checked = MacLocks == "46";
      }
    }

    private void CheckBox_Click(object sender, EventArgs e)
    {
      if (sender == chk41 && chk41.Checked)
      {
        chk42.Checked = false;
        chk43.Checked = false;
        chk44.Checked = false;
        chk45.Checked = false;
        chk46.Checked = false;
      }
      else if ((sender == chk42) && chk42.Checked)
      {
        chk41.Checked = false;
        chk43.Checked = false;
        chk44.Checked = false;
        chk45.Checked = false;
        chk46.Checked = false;
      }
      else if ((sender == chk43) && chk43.Checked)
      {
        chk41.Checked = false;
        chk42.Checked = false;
        chk44.Checked = false;
        chk45.Checked = false;
        chk46.Checked = false;
      }
      else if ((sender == chk44) && chk44.Checked)
      {
        chk41.Checked = false;
        chk42.Checked = false;
        chk43.Checked = false;
        chk45.Checked = false;
        chk46.Checked = false;
      }
      else if ((sender == chk45) && chk45.Checked)
      {
        chk41.Checked = false;
        chk42.Checked = false;
        chk43.Checked = false;
        chk44.Checked = false;
        chk46.Checked = false;
      }
      else if ((sender == chk46) && chk46.Checked)
      {
        chk41.Checked = false;
        chk42.Checked = false;
        chk43.Checked = false;
        chk44.Checked = false;
        chk45.Checked = false;
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string MacLocks = "";
      if (panel2.Enabled)
      {
        MacLocks = "20";
        if (chk2.Checked) MacLocks = "21";
      }
      else
      {
        MacLocks = "40";
        if (chk41.Checked)
          MacLocks = "41";
        else if (chk42.Checked)
          MacLocks = "42";
        else if (chk43.Checked)
          MacLocks = "43";
        else if (chk44.Checked)
          MacLocks = "44";
        else if (chk45.Checked)
          MacLocks = "45";
        else if (chk46.Checked)
          MacLocks = "46";
      }
      string sql = "";
      try
      {
        sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "105", MacLocks, SysID });
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
  }
}