using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmRSDepositDiscountAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "RSDepositDiscountAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      txtDiscStart.Enter += TextBoxCurrency_Enter;
      txtDiscStart.Leave += TextBoxCurrency_Leave;
     // txtDiscEnd.Enter += TextBoxCurrency_Enter;
      //txtDiscEnd.Leave += TextBoxCurrency_Leave;
      txtDiscDiscount.Enter += TextBoxCurrency_Enter;
      txtDiscDiscount.Leave += TextBoxCurrency_Leave;
      double d = 0;
      txtDiscStart.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      //txtDiscEnd.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      txtDiscDiscount.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
      GetCardTypeList();
      cbbCardType.Items.Clear();
      for (int i = 0; i < cardTypeList.Count; i++)
      {
        cbbCardType.Items.Add(cardTypeList[i]);
      }
      cbbCardType.SelectedIndex = 0;
      if (SysID != "") LoadData();
    }

    public frmRSDepositDiscountAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      cbbCardType.SelectedIndex = -1;
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001001, new string[] { "102", SysID }));
        if (dr.Read())
        {
          for (int i = 0; i < cbbCardType.Items.Count; i++)
          {
            if (((TCardType)cbbCardType.Items[i]).sysID == dr["CardTypeSysID"].ToString())
            {
              cbbCardType.SelectedIndex = i;
              break;
            }
          }
          txtDiscStart.Text = CurrencyToString(dr["DiscStart"].ToString());
         // txtDiscEnd.Text = CurrencyToString(dr["DiscEnd"].ToString());
          txtDiscDiscount.Text = CurrencyToString(dr["DiscDiscount"].ToString());
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
      DataTableReader dr = null;
      bool IsOk = false;
      if (cbbCardType.SelectedIndex == -1)
      {
        cbbCardType.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
        return;
      }
      string CardTypeSysID = ((TCardType)cbbCardType.SelectedItem).sysID;
      string DiscStart = CurrencyToStringEx(txtDiscStart.Text);
     // string DiscEnd = CurrencyToStringEx(txtDiscEnd.Text);
      string DiscDiscount = CurrencyToStringEx(txtDiscDiscount.Text);
      if (Convert.ToDecimal(DiscStart) <= 0/* && Convert.ToDecimal(DiscEnd) <= 0*/)
      {
        //txtDiscEnd.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error002", ""));
        return;
      }
      //if (Convert.ToDecimal(DiscStart) > Convert.ToDecimal(DiscEnd) && Convert.ToDecimal(DiscEnd) > 0)
      //{
      //  txtDiscEnd.Focus();
      //  Pub.MessageBoxShow(Pub.GetResText(formCode, "Error003", ""));
      //  return;
      //}
      if (Convert.ToDecimal(DiscDiscount) <= 0)
      {
        txtDiscDiscount.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error004", ""));
        return;
      }
      string sql = "";
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          sql = Pub.GetSQL(DBCode.DB_001001, new string[] { "103", CardTypeSysID, DiscStart.ToString(), 
            /*DiscEnd.ToString(),*/ DiscDiscount.ToString() });
        }
        else
        {
          sql = Pub.GetSQL(DBCode.DB_001001, new string[] { "104", CardTypeSysID, DiscStart.ToString(), 
           /* DiscEnd.ToString(),*/ DiscDiscount.ToString(), SysID });
        }
        db.ExecSQL(sql);
        IsOk = true;
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