using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQHolidayAddA : frmBaseDialog
  {
    public DateTime StartDate = new DateTime();
    public DateTime EndDate = new DateTime();
    public string HoliName = "";
    public string HoliTime = "";
    public string OtType = "";

    protected override void InitForm()
    {
      formCode = "KQHolidayAddA";
      base.InitForm();
      this.Text = this.Text + "[" + CurrentOprt + "]";
      dtpStart.Value = DateTime.Now.Date;
      dtpEnd.Value = DateTime.Now.Date;
    }

    public frmKQHolidayAddA(string CurrentTool, List<TCommonType> HolidayTimeList, List<TCommonType> HoliDayOtTypeList)
    {
      CurrentOprt = CurrentTool;
      InitializeComponent();
      cbbTime.Items.Clear();
      cbbTime.Items.Add(new TCommonType("", "", "", true));
      for (int i = 0; i < HolidayTimeList.Count; i++)
      {
        cbbTime.Items.Add(HolidayTimeList[i]);
      }
      if (cbbTime.Items.Count > 0) cbbTime.SelectedIndex = 0;
      cbbType.Items.Clear();
      cbbType.Items.Add(new TCommonType("", "", "", true));
      for (int i = 0; i < HoliDayOtTypeList.Count; i++)
      {
        cbbType.Items.Add(HoliDayOtTypeList[i]);
      }
      cbbType.SelectedIndex = 0;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (dtpStart.Value > dtpEnd.Value)
      {
        dtpStart.Focus();
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorStartDateBegreater", ""));
        return;
      }
      HoliName = txtName.Text.Trim();
      if (!Pub.CheckTextMaxLength(label3.Text, HoliName, txtName.MaxLength)) return;
      if (cbbTime.SelectedIndex == -1)
      {
        cbbTime.Focus();
        ShowErrorSelectCorrect(label4.Text);
        return;
      }
      StartDate = dtpStart.Value.Date;
      EndDate = dtpEnd.Value.Date;
      HoliTime = cbbTime.Text;
      OtType = cbbType.Text;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}