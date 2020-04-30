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
      FormsList.Name = "RS";
      FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");
      SubAdd("RSCardType", 0);
      SubAdd("RSDepositDiscount", 0);
      SubAdd("RSDepart", 0);
      SubAdd("RSEmp", 1);
      SubAdd("RSReport", 2);
      SubAdd("RSEmpChart", 3);
      SubAdd("RSCardOpterDetail", 4);
      SubAdd("RSCardOpterTotal", 3);
      SubAdd("RSDimission", 0);
      SubAdd("RSHistoryCard", 0);
      //SubAdd("RSReportCustom", 4);
      return FormsList;
    }

    public Form GetForm(string frmName)
    {
      Form ret = null;
      switch (frmName)
      {
        case "RSCardType":
          ret = new frmRSCardType();
          break;
        case"RSDepositDiscount":
          ret = new frmRSDepositDiscount();
          break;
        case "RSDepart":
          ret = new frmRSDepart();
          break;
        case "RSEmp":
          ret = new frmRSEmp();
          break;
        case "RSEmpDelete":
          ret = new frmRSEmpDelete();
          break;
        case "RSEmpChart":
          ret = new frmRSEmpChart();
          break;
        case "RSCardOpterDetail":
          ret = new frmRSCardOpterDetail();
          break;
        case "RSCardOpterTotal":
          ret = new frmRSCardOpterTotal();
          break;
        case "RSReportCustom":
          ret = new frmRSReport();
          break;
        case "RSDimission":
          ret = new frmRSDimission();
          break;
        case "RSHistoryCard":
          ret = new frmRSHistoryCard();
          break;
      }
      return ret;
    }

    public void RSCardOprter(byte flag)
    {
      frmRSEmp frm = new frmRSEmp();
      frm.InitRSEmp();
      switch (flag)
      {
        case 0://·¢¿¨
          frm.ShowCardFa(false);
          break;
        case 1://¹ÒÊ§µÇ¼Ç
          frm.ShowCardLoss(false, "");
          break;
        case 2://½â¹ÒµÇ¼Ç
          frm.ShowCardRelieve(false);
          break;
        case 3://»»¿¨
          frm.ShowCardChange(false);
          break;
        case 4://ÍË¿¨
          frm.ShowCardRetirement(false);
          break;
        case 5://¿¨Æ¬ÐÞ¸´
          frm.ShowCardRepair(false);
          break;
        case 6://²é¿¨
          frm.ShowCardView(false);
          break;
        case 7://¸Ä¿¨
          frm.ShowCardModify(false);
          break;
        case 8://ºÚÃûµ¥
          frm.ShowCardBlack(false);
          break;
      }
      frm.Dispose();
      frm = null;
    }
  }
}