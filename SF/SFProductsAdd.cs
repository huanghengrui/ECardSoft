using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSFProductsAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SFProductsAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      Label1.ForeColor = Color.Red;
      Label2.ForeColor = Color.Red;
      Label4.ForeColor = Color.Blue;
      Label5.ForeColor = Color.Blue;
      LoadData();
      SetTextboxNumber(txtNo);
      txtPrice.Enter += TextBoxCurrency_Enter;
      txtPrice.Leave += TextBoxCurrency_Leave;
    }

    public frmSFProductsAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      DataTableReader drr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "101" }));
          if (dr.Read())
          {
            int no = 0;
            int.TryParse(dr[0].ToString(), out no);
            if (no > 9999) no = 9999;
            txtNo.Text = no.ToString();
          }
          drr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "102" }));
          if (drr.Read())
          {
              txtCategory.Text = drr["CategoryName"].ToString();
              txtCategory.Tag = drr["CategoryID"].ToString();
          }
                  
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "4", SysID }));
          if (dr.Read())
          {
            txtNo.Text = dr["ProductsID"].ToString();
            txtName.Text = dr["ProductsName"].ToString();
            double d = 0;
            double.TryParse(dr["ProductsPrice"].ToString(), out d);
            txtPrice.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
            txtCategory.Text = dr["CategoryName"].ToString();
            txtCategory.Tag = dr["CategoryID"].ToString();
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
         if (drr != null) drr.Close();
         drr = null;
     }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      int ProdID = 0;
      if (Pub.IsNumeric(txtNo.Text.Trim())) ProdID = Convert.ToInt32(txtNo.Text.Trim());
      string ProdName = txtName.Text.Trim();
      string Price = CurrencyToStringEx(txtPrice.Text);
      string CategoryName = txtCategory.Text;
      string CategoryID = txtCategory.Tag.ToString();
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
      if (CategoryName == "")
      {
        txtName.Focus();
        ShowErrorEnterCorrect(label6.Text);
        return;
      }
       if (ProdName == "")
      {
        txtName.Focus();
        ShowErrorEnterCorrect(Label2.Text);
        return;
      }
      if (Convert.ToDecimal(Price) <= 0)
      {
        txtPrice.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
        return;
      }
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "5", ProdID.ToString(),CategoryID }));
          if (dr.Read())
          {
            txtNo.Focus();
            ShowErrorCannotRepeated(Label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_004003, new string[] { "1", ProdID.ToString(), ProdName, Price,CategoryID,CategoryName });
            db.ExecSQL(sql);
            IsOk = true;
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "6", SysID, ProdID.ToString() ,CategoryID}));
          if (dr.Read())
          {
            txtNo.Focus();
            ShowErrorCannotRepeated(Label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_004003, new string[] { "2", ProdID.ToString(), ProdName, Price,CategoryID,CategoryName, SysID });
            db.ExecSQL(sql);
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmPubSelectCategory frm = new frmPubSelectCategory();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCategory.Tag = frm.CategoryID;
                txtCategory.Text = frm.CategoryName; 
            }
        }
    }
}