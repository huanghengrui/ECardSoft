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
    //0－一卡通考勤机
    //1－指纹考勤机
    //2－一卡通考勤机、指纹考勤机
    //3－无考勤设备
    private byte devFlag = 2;

    private void SubAdd(string Name, byte IsLine)
    {
      FormsList.SubAdd(Name, SystemInfo.res.GetResText(formCode, "mnu" + Name, ""), IsLine);
    }

    public FuncObject GetFormsList()
    {
      FormsList.Name = "KQ";
      FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");
      if (devFlag == 0 || devFlag == 2)
      {
        SubAdd("KQMac", 2);
        SubAdd("KQMacInfo", 3);
        SubAdd("KQMacParam", 3);
        SubAdd("KQMacCard", 3);
        SubAdd("KQMessage", 3);
        SubAdd("KQMacData", 3);
        SubAdd("KQMacReal", 3);
      }
      if (devFlag == 1 || devFlag == 2)
      {
        SubAdd("KQFace", 2);
        SubAdd("KQFaceInfo", 3);
        SubAdd("KQFaceData", 3);
        SubAdd("KQFaceReal", 3);
      }
      if (devFlag == 3)
        SubAdd("KQTypeSetDayoff", 0);
      else
        SubAdd("KQTypeSetDayoff", 1);
      SubAdd("KQTypeSetTrip", 0);
      SubAdd("KQTypeSetOt", 0);
      SubAdd("KQRule", 2);
      SubAdd("KQWeekEnd", 3);
      SubAdd("KQHoliday", 3);
      SubAdd("KQShift", 4);
      SubAdd("KQShiftRule", 3);
      SubAdd("KQEmpWorkType", 4);
      SubAdd("KQDepWorkType", 3);
      SubAdd("KQEmpShift", 4);
      SubAdd("KQDepShift", 3);
      SubAdd("KQShiftAssert", 4);
      SubAdd("KQShiftPackage", 4);
      SubAdd("KQShiftCountH", 3);
      SubAdd("KQEmpDayOff", 1);
      SubAdd("KQEmpTrip", 0);
      SubAdd("KQEmpOtSure", 0);
      SubAdd("KQEmpSignCard", 0);
      SubAdd("KQDataAssay", 1);
      SubAdd("KQDataExceptions", 0);
      SubAdd("KQReport", 2);
      SubAdd("KQReportData", 3);
      SubAdd("KQReportDataFilter", 4);
      SubAdd("KQReportResultDay", 3);
      SubAdd("KQReportResultMonth", 3);
      SubAdd("KQReportResultTotal", 3);
      //SubAdd("KQReportCustom", 4);
      SubAdd("KQReportOrderDetail", 4);
      return FormsList;
    }

    public Form GetForm(string frmName)
    {
      Form ret = null;
      switch (frmName)
      {
        case "KQMacInfo":
          ret = new frmKQMacInfo();
          break;
        case "KQMacParam":
          ret = new frmKQMacParam();
          break;
        case "KQMacCard":
          ret = new frmKQMacCard();
          break;
        case "KQMessage":
          ret = new frmKQMessage();
          break;
        case "KQMacData":
          ret = new frmKQMacData();
          break;
        case "KQMacReal":
          ret = new frmKQMacReal();
          break;
        case "KQFaceInfo":
          ret = new frmKQFaceInfo();
          break;
        case "KQFaceData":
          ret = new frmKQFaceData();
          break;
        case "KQFaceReal":
          ret = new frmKQFaceReal();
          break;
        case "KQTypeSetOt":
          ret = new frmKQTypeSetOt();
          break;
        case "KQTypeSetDayoff":
          ret = new frmKQTypeSetDayoff();
          break;
        case "KQTypeSetTrip":
          ret = new frmKQTypeSetTrip();
          break;
        case "KQWeekEnd":
          ret = new frmKQWeekEnd();
          break;
        case "KQHoliday":
          ret = new frmKQHoliday();
          break;
        case "KQShift":
          ret = new frmKQShift();
          break;
        case "KQShiftRule":
          ret = new frmKQShiftRule();
          break;
        case "KQEmpWorkType":
          ret = new frmKQEmpWorkType();
          break;
        case "KQDepWorkType":
          ret = new frmKQDepWorkType();
          break;
        case "KQEmpShift":
          ret = new frmKQEmpShift();
          break;
        case "KQDepShift":
          ret = new frmKQDepShift();
          break;
        case "KQShiftAssert":
          ret = new frmKQShiftAssert();
          break;
        case "KQShiftPackage":
          ret = new frmKQShiftPackage();
          break;
        case "KQShiftCountH":
          ret = new frmKQShiftCountH();
          break;
        case "KQEmpDayOff":
          ret = new frmKQEmpDayOff();
          break;
        case "KQEmpTrip":
          ret = new frmKQEmpTrip();
          break;
        case "KQEmpOtSure":
          ret = new frmKQEmpOtSure();
          break;
        case "KQEmpSignCard":
          ret = new frmKQEmpSignCard();
          break;
        case "KQDataAssay":
          ShowKQDataAssay();
          break;
        case "KQDataExceptions":
          ret = new frmKQDataExceptions();
          break;
        case "KQReportData":
          ret = new frmKQReportData();
          break;
        case "KQReportDataFilter":
          ret = new frmKQReportDataFilter();
          break;
        case "KQReportResultDay":
          ret = new frmKQReportResultDay();
          break;
        case "KQReportResultMonth":
          ret = new frmKQReportResultMonth();
          break;
        case "KQReportResultTotal":
          ret = new frmKQReportResultTotal();
          break;
        case "KQReportCustom":
          ret = new frmKQReportCustom();
          break;
        case"KQReportOrderDetail":
          ret = new frmKQReportOrderDetail();
          break;
      }
      return ret;
    }

    public byte KQFlag()
    {
      return devFlag;
    }

    private void ShowKQDataAssay()
    {
      frmKQDataAssay frm = new frmKQDataAssay();
      frm.ShowDialog();
    }
  }
}