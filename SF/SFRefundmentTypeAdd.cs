using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSFRefundmentTypeAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SFRefundmentTypeAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      Label1.ForeColor = Color.Red;
      Label2.ForeColor = Color.Red;
      label3.ForeColor = Color.Blue;
      LoadData();
      SetTextboxNumber(txtNo);
    }

    public frmSFRefundmentTypeAdd(string title, string CurrentTool, string GUID)
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
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004014, new string[] { "101" }));
          if (dr.Read())
          {
            int no = 0;
            int.TryParse(dr[0].ToString(), out no);
            if (no == 1) no = 200;
            if (no < 200) no += 200;
            if (no > 209) no = 209;
            txtNo.Text = no.ToString();
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004014, new string[] { "4", SysID }));
          if (dr.Read())
          {
            txtNo.Text = dr["RefundmentTypeID"].ToString();
            txtName.Text = dr["RefundmentTypeName"].ToString();
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
      int TypeID = 0;
      if (Pub.IsNumeric(txtNo.Text.Trim())) TypeID = Convert.ToInt32(txtNo.Text.Trim());
      string TypeName = txtName.Text.Trim();
      DataTableReader dr = null;
      bool IsOk = true;
      string sql = "";
      if (!Pub.CheckTextMaxLength(Label2.Text, TypeName, txtName.MaxLength)) return;
      if ((TypeID < 200) || (TypeID > 209))
      {
        txtNo.Focus();
        ShowErrorEnterCorrect(Label1.Text);
        return;
      }
      if (TypeName == "")
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
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004014, new string[] { "5", TypeID.ToString() }));
          if (dr.Read())
          {
            if (txtNo.Enabled) txtNo.Focus();
            ShowErrorCannotRepeated(Label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_004014, new string[] { "1", TypeID.ToString(), TypeName });
            db.ExecSQL(sql);
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004014, new string[] { "6", SysID, TypeID.ToString() }));
          if (dr.Read())
          {
            txtNo.Focus();
            ShowErrorCannotRepeated(Label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_004014, new string[] { "2", TypeID.ToString(), TypeName, SysID });
            db.ExecSQL(sql);
          }
        }
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