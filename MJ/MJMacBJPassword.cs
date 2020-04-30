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
    private int StressPWD = 0;
    private byte OverTimeOpen = 0;

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
      StressPWD = 0;
      if (!Pub.InputBox(Pub.GetResText(formCode, "Msg003", ""), Pub.GetResText(formCode, "Msg004", ""), 999999, ref StressPWD)) return;
      base.ExecItemTAG3();
      ExecMacOprt(2);
    }

    protected override void ExecItemTAG4()
    {
      int num = 0;
      if (!Pub.InputBox(Pub.GetResText(formCode, "Msg001", ""), Pub.GetResText(formCode, "Msg002", ""), 255, ref num)) return;
      OverTimeOpen = Convert.ToByte(num);
      base.ExecItemTAG4();
      ExecMacOprt(3);
    }

    protected override bool ExecMacCommand(byte flag, string MacSN, ref string MacMsg)
    {
      bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
      QHKS.TMJExtensionBoard Board = new QHKS.TMJExtensionBoard();
      Board.AlarmPort = new byte[4];
      Board.DoorID = new byte[4];
      Board.Events = new byte[28];
      Board.Source = new byte[8];
      Board.Timeout = new short[4];
      TMacExtensionBoard extBoard = new TMacExtensionBoard(GetExtField(MacSN));
      switch (flag)
      {
        case 0:
          for (int i = 0; i < 4; i++)
          {
            Board.AlarmPort[i] = extBoard.Port[i];
            Board.DoorID[i] = extBoard.DoorID[i];
            for (int j = 0; j < 7; j++)
            {
              Board.Events[i * 7 + j] = Convert.ToByte(extBoard.Events[i].Substring(j, 1));
            }
            for (int j = 0; j < 2; j++)
            {
              Board.Source[i * 2 + j] = Convert.ToByte(extBoard.Souce[i].Substring(j, 1));
            }
            Board.Timeout[i] = extBoard.TimeOut[i];
          }
          ret = DeviceObject.objMJ.SetExtensionBoard(ref Board);
          break;
        case 1:
          ret = DeviceObject.objMJ.SetMacStressPWD(0);
          if (!ret) break;
          Board.AlarmPort = new byte[4];
          Board.DoorID = new byte[4];
          Board.Events = new byte[28];
          Board.Source = new byte[8];
          Board.Timeout = new short[4];
          for (int i = 0; i < 4; i++)
          {
            Board.AlarmPort[i] = extBoard.Port[i];
            Board.DoorID[i] = extBoard.DoorID[i];
            Board.Timeout[i] = extBoard.TimeOut[i];
          }
          ret = DeviceObject.objMJ.SetExtensionBoard(ref Board);
          break;
        case 2:
          ret = DeviceObject.objMJ.SetMacStressPWD(StressPWD);
          break;
        case 3:
          ret = DeviceObject.objMJ.SetMacOverTimeOpen(OverTimeOpen);
          break;
      }
      return ret;
    }
  }
}