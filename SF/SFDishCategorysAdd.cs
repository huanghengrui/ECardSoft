using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSFDishCategorysAdd : frmBaseDialog
  {
    private static string OldID = "";
    protected override void InitForm()
    {
      formCode = "SFDishCategorysAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      Label1.ForeColor = Color.Red;
      Label2.ForeColor = Color.Red;
      Label4.ForeColor = Color.Blue;
      Label5.ForeColor = Color.Blue;
      LoadData();
      SetTextboxNumber(txtNo);

    }

    public frmSFDishCategorysAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "109" }));
          if (dr.Read())
          {
            int no = 0;
            int.TryParse(dr[0].ToString(), out no);
            if (no > 9999) no = 9999;
            txtNo.Text = no.ToString();
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "106", SysID }));
          if (dr.Read())
          {
            OldID = dr["CategoryID"].ToString();
            txtNo.Text = dr["CategoryID"].ToString();
            txtName.Text = dr["CategoryName"].ToString();
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
      int ProdID = 0;
      if (Pub.IsNumeric(txtNo.Text.Trim())) ProdID = Convert.ToInt32(txtNo.Text.Trim());
      string ProdName = txtName.Text.Trim();
   
      DataTableReader dr = null;
      bool IsOk = false;
      string sql = "";

      if (!Pub.CheckTextMaxLength(Label2.Text, ProdName, txtName.MaxLength)) return;
      if ((ProdID < 1) || (ProdID > 9999))
      {
        txtNo.Focus();
        ShowErrorEnterCorrect(Label1.Text);
        return;
      }
      if (ProdName == "")
      {
        txtName.Focus();
        ShowErrorEnterCorrect(Label2.Text);
        return;
      }
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "107", ProdID.ToString() }));
          if (dr.Read())
          {
            txtNo.Focus();
            ShowErrorCannotRepeated(Label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_004003, new string[] { "103", ProdID.ToString(), ProdName });
            db.ExecSQL(sql);
            IsOk = true;
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "108", SysID, ProdID.ToString() }));
          if (dr.Read())
          {
            txtNo.Focus();
            ShowErrorCannotRepeated(Label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_004003, new string[] { "104", ProdID.ToString(), ProdName, SysID });
            db.ExecSQL(sql);

           dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "110", OldID }));
           if (dr.Read())
           { 
                sql = Pub.GetSQL(DBCode.DB_004003, new string[] { "120", ProdID.ToString(), ProdName,OldID});
                db.ExecSQL(sql);
           }
            IsOk = true;
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