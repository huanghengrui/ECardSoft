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
      FormsList.Name = "MJ";
      FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");
      SubAdd("MJMacInfo", 0);
      SubAdd("MJHoliday", 0);
      SubAdd("MJMacTime", 0);
      SubAdd("MJMacPower", 0);
      SubAdd("MJMacData", 0);
      SubAdd("MJMacReal", 0);
      SubAdd("MJMap", 0);
      SubAdd("MJReport", 2);
      SubAdd("MJReportNormal", 3);
      SubAdd("MJReportAlarm", 3);
      //SubAdd("MJReportCustom", 4);
      SubAdd("MJAdvanced", 2);
      SubAdd("MJMacPassword", 3);
      SubAdd("MJMacOpenDoor", 3);
      SubAdd("MJMacDoorState", 3);
      SubAdd("MJMacDoorLock", 3);
      SubAdd("MJMacUnReturn", 3);
      SubAdd("MJMacMoreCard", 3);
      SubAdd("MJMacFirstOpenDoor", 3);
      SubAdd("MJMacInOutConfirm", 3);
      SubAdd("MJMacTimeOpenDoor", 3);
      SubAdd("MJMacBJPassword", 3);
      return FormsList;
    }

    public Form GetForm(string frmName)
    {
      Form ret = null;
      switch (frmName)
      {
        case "MJMacInfo":
          ret = new frmMJMacInfo();
          break;
        case "MJHoliday":
          ret = new frmMJHoliday();
          break;
        case "MJMacTime":
          ret = new frmMJMacTimeAdv();
          break;
        case "MJMacPower":
          ret = new frmMJMacPower();
          break;
        case "MJMacData":
          ret = new frmMJMacData();
          break;
        case "MJMacReal":
          ret = new frmMJMacReal();
          break;
        case "MJMap":
          ret = new frmMJMap();
          break;
        case "MJReportNormal":
          ret = new frmMJReportNormal();
          break;
        case "MJReportAlarm":
          ret = new frmMJReportAlarm();
          break;
        case "MJReportCustom":
          ret = new frmMJReportCustom();
          break;
        case "MJMacPassword":
          ret = new frmMJMacPassword();
          break;
        case "MJMacOpenDoor":
          ret = new frmMJMacOpenDoor();
          break;
        case "MJMacDoorState":
          ret = new frmMJMacDoorState();
          break;
        case "MJMacDoorLock":
          ret = new frmMJMacDoorLock();
          break;
        case "MJMacUnReturn":
          ret = new frmMJMacUnReturn();
          break;
        case "MJMacMoreCard":
          ret = new frmMJMacMoreCard();
          break;
        case "MJMacFirstOpenDoor":
          ret = new frmMJMacFirstOpenDoor();
          break;
        case "MJMacInOutConfirm":
          ret = new frmMJMacInOutConfirm();
          break;
        case "MJMacTimeOpenDoor":
          ret = new frmMJMacTimeOpenDoor();
          break;
        case "MJMacBJPassword":
          ret = new frmMJMacBJPassword();
          break;
      }
      return ret;
    }

    public bool MJIsNew()
    {
      return true;
    }
  }
}