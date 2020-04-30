using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacData : frmMJMacBase
  {
    private string MsgString = "";
    private MJReadData readData = null;

    protected override void InitForm()
    {
      formCode = "MJMacData";
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemAdd", false);
      SetToolItemState("ItemEdit", false);
      SetToolItemState("ItemDelete", false);
      SetToolItemState("ItemLine2", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemTAG2", false);
      SetToolItemState("ItemLine3", true);
      base.InitForm();
    }

    public frmMJMacData()
    {
      InitializeComponent();
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      IsExec = true;
      readData = null;
      ExecMacOprt(0);
      IsExec = false;
      RefreshForm(true);
    }

    protected override void ExecItemTAG2()
    {
      base.ExecItemTAG2();
      if (readData != null) readData.StopData();
    }

    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(State);
      ItemTAG1.Enabled = ItemTAG1.Enabled && !IsExec;
      //ItemTAG2.Enabled = IsExec && dataGrid.RowCount > 0;
      SetContextMenuState();
    }

    protected override bool ExecMacCommand(byte flag, string MacSN, ref string MacMsg)
    {
      bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
      if (readData == null) readData = new MJReadData(this.Text + "[" + CurrentTool + "]");
      int RecordCount = 0;
      int RecordIndex = 0;
      switch (flag)
      {
        case 0:
          MsgString = lblMsg.Text;
          progBar.Style = ProgressBarStyle.Blocks;
          progBar.Value = 0;
          ret = readData.ReadData(db, MacSN, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
          MacMsg = string.Format("{0}/{1}", RecordIndex, RecordCount);
          break;
      }
      readData = null;
      return ret;
    }

    public void ShowReadDataProcess(int RecordCount, int RecordIndex)
    {
      progBar.Value = RecordIndex * 100 / RecordCount;
      lblMsg.Text = MsgString + string.Format("{0}/{1}", RecordIndex, RecordCount);
      Application.DoEvents();
    }
  }
}