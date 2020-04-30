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
      FormsList.Name = "SF";
      FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");
      SubAdd("SFAddress", 0);
      SubAdd("SFPrintTitle", 0);
      SubAdd("SFMobileInfo", 0);
      SubAdd("SFMobileCheck", 0);
      SubAdd("SFProducts", 0);
      SubAdd("SFDepositType", 0);
      if (SystemInfo.DefMoreRefundmentType) SubAdd("SFRefundmentType", 0);
      SubAdd("SFMacInfo", 1);
      SubAdd("SFMacParam", 0);
      SubAdd("SFMacData", 0);
      SubAdd("SFMacReal", 0);
      if (SystemInfo.SFCardDRMode)
        SubAdd("SFDepositRef", 1);
      else
      {
        SubAdd("SFDeposit", 1);
        SubAdd("SFRefundment", 0);
      }
      SubAdd("SFSoft", 0);
      SubAdd("SFAllowance", 0);
      SubAdd("SFAllowanceClear", 0);
      SubAdd("SFCheckAccount", 1);
      SubAdd("SFQueryIncomeCount", 1);
      SubAdd("SFQueryBalance", 0);
      SubAdd("SFDishCategorys", 0);
      SubAdd("SFReport", 2);
      SubAdd("SFReportOrderDetail", 3);
      SubAdd("SFReportOrderTotal", 3);
      SubAdd("SFReportSFDetail", 4);
      SubAdd("SFReportSFTotal", 3);
      SubAdd("SFReportSFMobile", 4);
      //SubAdd("SFReportSFMobileProdDetail", 3);
      //SubAdd("SFReportSFMobileProdTotal", 3);
      SubAdd("SFReportProductDetail", 4);
      SubAdd("SFReportProductTotal", 3);
      SubAdd("SFReportDepositDetail", 4);
      SubAdd("SFReportDepositTotal", 3);
      SubAdd("SFReportRefundmentDetail", 4);
      SubAdd("SFReportRefundmentTotal", 3);
      SubAdd("SFReportMealCount", 4);
      SubAdd("SFReportConsumeCount", 3);
      SubAdd("SFReportComposite", 3);
      SubAdd("SFReportSystemCount", 3);
      //SubAdd("SFReportCustom", 4);
      //SubAdd("SFReportAirData", 4);
      return FormsList;
    }

    public Form GetForm(string frmName)
    {
      Form ret = null;
      switch (frmName)
      {
        case "SFAddress":
          ret = new frmSFAddress();
          break;
        case "SFPrintTitle":
          ShowSFPrintTitle();
          break;
        case "SFMobileInfo":
          ShowSFMobileInfo();
          break;
        case "SFMobileCheck":
          ShowSFMobileCheck();
          break;
        case "SFProducts":
          ret = new frmSFProducts();
          break;
        case "SFDepositType":
          ret = new frmSFDepositType();
          break;
        case "SFRefundmentType":
          ret = new frmSFRefundmentType();
          break;
        case "SFMacInfo":
          ret = new frmSFMacInfo();
          break;
        case "SFMacParam":
          ret = new frmSFMacParam();
          break;
        case "SFMacData":
          ret = new frmSFMacData(0,"");
          break;
        case "SFMacReal":
          ret = new frmSFMacReal();
          break;
        case "SFDeposit":
          ShowSFDeposit();
          break;
        case "SFRefundment":
          ShowSFRefundment();
          break;
        case "SFDepositRef":
          ret = new frmSFDepositRef();
          break;
        case "SFSoft":
          ShowSFSoft();
          break;
        case "SFAllowance":
          ret = new frmSFAllowance();
          break;
        case "SFAllowanceClear":
          ShowSFAllowanceClear();
          break;
        case "SFCheckAccount":
          ShowSFCheckAccount();
          break;
        case "SFQueryIncomeCount":
          ret = new frmSFQueryIncomeCount();
          break;
        case "SFQueryBalance":
          ret = new frmSFQueryBalance();
          break;
        //case "SFReportOrderDetail":
        //  ret = new frmSFReportOrderDetail();
        //  break;
        //case "SFReportOrderTotal":
        //  ret = new frmSFReportOrderTotal();
        //  break;
        case "SFReportSFDetail":
          ret = new frmSFReportSFDetail();
          break;
        case "SFReportSFTotal":
          ret = new frmSFReportSFTotal();
          break;
        case "SFReportSFMobile":
          ret = new frmSFReportSFMobile();
          break;
        case "SFReportSFMobileProdDetail":
          ret = new frmSFReportSFMobileProdDetail();
          break;
        case "SFReportSFMobileProdTotal":
          ret = new frmSFReportSFMobileProdTotal();
          break;
        case "SFReportProductDetail":
          ret = new frmSFReportProductDetail();
          break;
        case "SFReportProductTotal":
          ret = new frmSFReportProductTotal();
          break;
        case "SFReportDepositDetail":
          ret = new frmSFReportDepositDetail();
          break;
        case "SFReportDepositTotal":
          ret = new frmSFReportDepositTotal();
          break;
        case "SFReportRefundmentDetail":
          ret = new frmSFReportRefundmentDetail();
          break;
        case "SFReportRefundmentTotal":
          ret = new frmSFReportRefundmentTotal();
          break;
        case "SFReportMealCount":
          ret = new frmSFReportMealCount();
          break;
        case "SFReportConsumeCount":
          ret = new frmSFReportConsumeCount();
          break;
        case "SFReportComposite":
          ret = new frmSFReportComposite();
          break;
        case "SFReportSystemCount":
          ret = new frmSFReportSystemCount();
          break;
        case "SFReportCustom":
          ret = new frmSFReportCustom();
          break;
        case "SFReportLoss":
          ret = new frmSFReportLoss();
          break;
        case "SFReportAlarm":
          ret = new frmSFReportAlarm();
          break;
        case "SFReportError":
          ret = new frmSFReportError();
          break;
        case "SFReportReturn":
          ret = new frmSFReportReturn();
          break;
        case "SFReportSFMobileError":
          ret = new frmSFReportSFMobileError();
          break;
        case "SFReportDataOrder":
          ret = new frmSFReportDataOrder();
          break;
        case "SFReportAirData":
          ret = new frmSFReportAirData();
          break;
        case "SFDishCategorys":
          ret = new frmSFDishCategorys();
          break;
      }
      return ret;
    }

    private void ShowSFPrintTitle()
    {
      frmSFPrintTitle frm = new frmSFPrintTitle();
      frm.ShowDialog();
    }

    private void ShowSFMobileInfo()
    {
      frmSFMobileInfo frm = new frmSFMobileInfo();
      frm.ShowDialog();
    }

    private void ShowSFMobileCheck()
    {
      frmSFMobileCheck frm = new frmSFMobileCheck("","");
      frm.ShowDialog();
    }

    private void ShowSFDeposit()
    {
      frmSFDeposit frm = new frmSFDeposit();
      frm.ShowDialog();
    }

    private void ShowSFRefundment()
    {
      frmSFRefundment frm = new frmSFRefundment();
      frm.ShowDialog();
    }

    private void ShowSFAllowanceClear()
    {
      frmSFAllowanceClear frm = new frmSFAllowanceClear();
      frm.ShowDialog();
    }

    private void ShowSFSoft()
    {
      frmSFSoft frm = new frmSFSoft();
      frm.ShowDialog();
    }

    private void ShowSFCheckAccount()
    {
      frmSFCheckAccount frm = new frmSFCheckAccount();
      frm.ShowDialog();
    }
  }
}