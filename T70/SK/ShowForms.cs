using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  class ShowForms
  {
    private const string formCode = "Main";
    private FuncObject FormsList = new FuncObject();

    private void SubAdd(string Name, byte IsLine)
    {
      FormsList.SubAdd(Name, SystemInfo.res.GetResText(formCode, "mnu" + Name, ""), IsLine);
    }

    public FuncObject GetFormsList()
    {
      FormsList.Name = "SK";
      FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");
      SubAdd("SKDeposit", 0);
      SubAdd("SKDepositMore", 0);
      SubAdd("SKRefundment", 0);
      SubAdd("SKMakeCard", 1);
      SubAdd("SKReport", 2);
      SubAdd("SKReportDetail", 3);
      SubAdd("SKReportTotal", 3);
      return FormsList;
    }

    public Form GetForm(string frmName)
    {
      Form ret = null;
      switch (frmName)
      {
        case "SKDeposit":
          ShowSKDeposit();
          break;
        case "SKDepositMore":
          ShowSKDepositMore();
          break;
        case "SKRefundment":
          ShowSKRefundment();
          break;
        case "SKMakeCard":
          ShowSKMakeCard();
          break;
        case "SKReportDetail":
          ret = new frmSKReportDetail();
          break;
        case "SKReportTotal":
          ret = new frmSKReportTotal();
          break;
      }
      return ret;
    }

    private void ShowSKDeposit()
    {
      frmSKDeposit frm = new frmSKDeposit();
      frm.ShowDialog();
    }

    private void ShowSKDepositMore()
    {
      frmSKDepositMore frm = new frmSKDepositMore();
      frm.ShowDialog();
    }

    private void ShowSKRefundment()
    {
      frmSKRefundment frm = new frmSKRefundment();
      frm.ShowDialog();
    }

    private void ShowSKMakeCard()
    {
      frmSKMakeCard frm = new frmSKMakeCard();
      frm.ShowDialog();
    }
  }
}