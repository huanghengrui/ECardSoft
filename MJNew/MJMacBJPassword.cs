using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacBJPassword : frmMJMacBase
  {
    private int StressPWDA = 0;
    private int StressPWDB = 0;
    private int OverTimeOpen = 0;
    private int OverTimeLoop = 0;

    protected override void InitForm()
    {
      formCode = "MJMacBJPassword";
      ExtField.Add("MacExtensionBoard");
      ExtField.Add("MacStressPWD");
      ExtField.Add("MacOverTimeOpen");
      HideExtField = true;
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemLine2", false);
      SetToolItemState("ItemAdd", false);
      SetToolItemState("ItemEdit", false);
      SetToolItemState("ItemDelete", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemTAG2", true);
      SetToolItemState("ItemTAG3", true);
      SetToolItemState("ItemTAG4", true);
      SetToolItemState("ItemLine3", true);
      base.InitForm();
    }

    public frmMJMacBJPassword()
    {
      InitializeComponent();
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      frmMJMacBJExt frm = new frmMJMacBJExt(this.Text, CurrentTool, GetMacSysID());
      if (frm.ShowDialog() == DialogResult.OK)
      {
        ExecItemRefresh();
        ChangeSelectState();
        ExecMacOprt(0);
      }
    }

    protected override void ExecItemTAG2()
    {
      base.ExecItemTAG2();
      ChangeSelectState();
      ExecMacOprt(1);
    }

    protected override void ExecItemTAG3()
    {
      StressPWDA = 0;
      StressPWDB = 0;
      if (!Pub.InputBox2(Pub.GetResText(formCode, "Msg100", ""), Pub.GetResText(formCode, "Msg101", ""),
        Pub.GetResText(formCode, "Msg102", ""), 999999, 999999, ref StressPWDA, ref StressPWDB)) return;
      base.ExecItemTAG3();
      ExecMacOprt(2);
    }

    protected override void ExecItemTAG4()
    {
      OverTimeOpen = 0;
      OverTimeLoop = 0;
      if (!Pub.InputBox2(Pub.GetResText(formCode, "Msg103", ""), Pub.GetResText(formCode, "Msg104", ""),
        Pub.GetResText(formCode, "Msg105", ""), 3, 5, 1000, 1000, ref OverTimeOpen, ref OverTimeLoop)) return;
      base.ExecItemTAG4();
      ExecMacOprt(3);
    }

    protected override bool ExecMacCommand(byte flag, string MacSN, ref string MacMsg)
    {
      bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
      AccessV2API.TYPE_Setting setting = new AccessV2API.TYPE_Setting();
      AccessV2API.TYPE_ExtendAlarm[] ExtendAlarm = new AccessV2API.TYPE_ExtendAlarm[4];
      string s = "";
      UInt32 iEna = 1, iDis = 0;
      TMacExtensionBoardNew extBoard = new TMacExtensionBoardNew(GetExtField(MacSN));
      switch (flag)
      {
        case 0:
          for (int i = 0; i < 4; i++)
          {
            ExtendAlarm[i].Alarm = extBoard.Port[i];
            ExtendAlarm[i].Door = extBoard.DoorID[i];
            ExtendAlarm[i].UnlockedTick = (UInt32)extBoard.TimeOut[i];
            ExtendAlarm[i].UnlockedLoop = (UInt32)extBoard.TimeLoop[i];
            s = extBoard.Events[i];
            if (s.Length != 7) s = "0000000";
            ExtendAlarm[i].NoAccess = s.Substring(0, 1) == "1" ? iEna : iDis;
            ExtendAlarm[i].Unlocked = s.Substring(1, 1) == "1" ? iEna : iDis;
            ExtendAlarm[i].BreakIn = s.Substring(2, 1) == "1" ? iEna : iDis;
            ExtendAlarm[i].Linkage = s.Substring(3, 1) == "1" ? iEna : iDis;
            ExtendAlarm[i].Fire = s.Substring(4, 1) == "1" ? iEna : iDis;
            ExtendAlarm[i].Stress = s.Substring(5, 1) == "1" ? iEna : iDis;
            ExtendAlarm[i].Curfew = s.Substring(6, 1) == "1" ? iEna : iDis;
            s = extBoard.Souce[i];
            if (s.Length != 2) s = "00";
            ExtendAlarm[i].BreakInMode = s.Substring(0, 1) == "1" ? iEna : iDis;
            ExtendAlarm[i].UnlockedMode = s.Substring(1, 1) == "1" ? iEna : iDis;
          }
          ret = DeviceObject.objMJNew.SetAlarmInfo(ExtendAlarm);
          break;
        case 1:
          ret = DeviceObject.objMJNew.ReadSetting(out setting);
          if (ret)
          {
            setting.StressCodeA = "000000";
            setting.StressCodeB = "000000";
            ret = DeviceObject.objMJNew.SetSetting(setting);
          }
          if (ret)
          {
            for (int i = 0; i < 4; i++)
            {
              ExtendAlarm[i].Door = (UInt32)(i + 1);
            }
            ret = DeviceObject.objMJNew.SetAlarmInfo(ExtendAlarm);
          }
          break;
        case 2:
          ret = DeviceObject.objMJNew.ReadSetting(out setting);
          if (ret)
          {
            setting.StressCodeA = StressPWDA.ToString("000000");
            setting.StressCodeB = StressPWDB.ToString("000000");
            ret = DeviceObject.objMJNew.SetSetting(setting);
          }
          break;
        case 3:
          for (int i = 0; i < 4; i++)
          {
            ExtendAlarm[i].Door = (UInt32)(i + 1);
            ExtendAlarm[i].UnlockedTick = (UInt32)OverTimeOpen;
            ExtendAlarm[i].UnlockedLoop = (UInt32)OverTimeLoop;
          }
          ret = DeviceObject.objMJNew.SetAlarmInfo(ExtendAlarm);
          break;
      }
      return ret;
    }
  }
}