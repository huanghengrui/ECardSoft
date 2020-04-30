using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQEmpShiftView : frmBaseDialog
  {
    private DateTime _StartDate = new DateTime();
    private DateTime _EndDate = new DateTime();

    protected override void InitForm()
    {
      formCode = "KQEmpShiftView";
      cardGrid.AutoGenerateColumns = false;
      base.InitForm();
      this.Text = Title + " - " + CurrentOprt;
      btnOk.Text = Pub.GetResText(formCode, "btnViewShiftInfo", "");
      toolTip.SetToolTip(btnOk, btnOk.Text);
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        cardGrid.DataSource = db.GetDataTable(Pub.GetSQL(DBCode.DB_002007, new string[] { "7", SysID, 
          _StartDate.ToString(SystemInfo.SQLDateFMT), _EndDate.ToString(SystemInfo.SQLDateFMT) }));
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      btnOk.Enabled = cardGrid.RowCount > 0;
    }

    public frmKQEmpShiftView(string title, string CurrentTool, string GUID, DateTime StartDate, DateTime EndDate)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      _StartDate = StartDate;
      _EndDate = EndDate;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string GUID = cardGrid[4, cardGrid.SelectedRows[0].Index].Value.ToString();
      int ShiftType = 0;
      int.TryParse(cardGrid[5, cardGrid.SelectedRows[0].Index].Value.ToString(), out ShiftType);
      switch (ShiftType)
      {
        case 0:
          frmKQShiftAdd frm = new frmKQShiftAdd(this.Text, btnOk.Text, GUID, true);
          frm.ShowDialog();
          break;
        case 1:
          frmKQShiftPackageAdd frmPack = new frmKQShiftPackageAdd(this.Text, btnOk.Text, GUID, true);
          frmPack.ShowDialog();
          break;
        case 2:
          frmKQShiftCountHAdd frmCount = new frmKQShiftCountHAdd(this.Text, btnOk.Text, GUID, true);
          frmCount.ShowDialog();
          break;
      }
    }

    private void cardGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex < 0) return;
      if (btnOk.Enabled) btnOk.PerformClick();
    }
  }
}