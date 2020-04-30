using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQPassTimeAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "KQPassTimeAdd";
      base.InitForm();
      this.Text = Title + " - " + CurrentOprt;
      label1.ForeColor = Color.Red;
      cbbID.Enabled = SysID == "";
      LoadData();
    }

    public frmKQPassTimeAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      cbbID.Items.Clear();
      for (int i = 1; i <= (int)FKMax.TIME_ZONE_COUNT; i++)
      {
        cbbID.Items.Add(i.ToString());
      }
      DataTableReader dr = null;
      int id = 0;
      try
      {
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "3002" }));
          if (dr.Read())
          {
            int.TryParse(dr[0].ToString(), out id);
            if (id >= 0 && id <= (int)FKMax.TIME_ZONE_COUNT)
              cbbID.SelectedIndex = cbbID.Items.IndexOf(id.ToString());
            else
              cbbID.SelectedIndex = 0;
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "3003", SysID }));
          if (dr.Read())
          {
            int.TryParse(dr[0].ToString(), out id);
            if (id >= 0 && id <= (int)FKMax.TIME_ZONE_COUNT)
              cbbID.SelectedIndex = cbbID.Items.IndexOf(id.ToString());
            else
              cbbID.SelectedIndex = 0;
            txtName.Text = dr["PassTimeName"].ToString();
            dtpS1.Text = dr["T1S"].ToString();
            dtpE1.Text = dr["T1E"].ToString();
            dtpS2.Text = dr["T2S"].ToString();
            dtpE2.Text = dr["T2E"].ToString();
            dtpS3.Text = dr["T3S"].ToString();
            dtpE3.Text = dr["T3E"].ToString();
            dtpS4.Text = dr["T4S"].ToString();
            dtpE4.Text = dr["T4E"].ToString();
            dtpS5.Text = dr["T5S"].ToString();
            dtpE5.Text = dr["T5E"].ToString();
            dtpS6.Text = dr["T6S"].ToString();
            dtpE6.Text = dr["T6E"].ToString();
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
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (cbbID.SelectedIndex == -1)
      {
        if (cbbID.Enabled) cbbID.Focus();
        ShowErrorSelectCorrect(label1.Text);
        return;
      }
      string ID = cbbID.Text;
      string Name = txtName.Text.Trim();
      if (!Pub.CheckTextMaxLength(label10.Text, Name, txtName.MaxLength))
      {
        txtName.Focus();
        return;
      }
      string T1S = dtpS1.Text;
      string T1E = dtpE1.Text;
      string T2S = dtpS2.Text;
      string T2E = dtpE2.Text;
      string T3S = dtpS3.Text;
      string T3E = dtpE3.Text;
      string T4S = dtpS4.Text;
      string T4E = dtpE4.Text;
      string T5S = dtpS5.Text;
      string T5E = dtpE5.Text;
      string T6S = dtpS6.Text;
      string T6E = dtpE6.Text;
      DataTableReader dr = null;
      bool IsOk = true;
      string sql = "";
      try
      {
        if (SysID != "") ID = SysID;
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "3003", ID }));
        if (dr.Read())
          sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "3005", ID, Name, T1S, T1E, T2S, T2E, T3S, T3E, 
              T4S, T4E, T5S, T5E, T6S, T6E, OprtInfo.OprtNo });
        else
          sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "3004", ID, Name, T1S, T1E, T2S, T2E, T3S, T3E, 
              T4S, T4E, T5S, T5E, T6S, T6E, OprtInfo.OprtNo });
        db.ExecSQL(sql);
      }
      catch (Exception E)
      {
        IsOk = false;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (!IsOk) return;
      db.WriteSYLog(this.Text, CurrentOprt, sql);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}