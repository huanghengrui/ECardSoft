using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ECard78
{
  public partial class frmSFMobileCheck : frmBaseDialog
  {
    private List<TMobileInfo> UserList = new List<TMobileInfo>();
    private DateTime dtStart = new DateTime();
    private DateTime dtEnd = new DateTime();

    protected override void InitForm()
    {
      formCode = "SFMobileCheck";
      retGrid.Columns.Clear();
      AddColumn(retGrid, 0, "RecordNo", false, true, 1, 60);
      AddColumn(retGrid, 0, "OrderNo", false, true, 1, 200);
      AddColumn(retGrid, 0, "OrderTime", false, true, 1, 130);
      AddColumn(retGrid, 0, "PayTime", false, true, 1, 130);
      AddColumn(retGrid, 1, "IsWX", false, true, 1, 70);
      AddColumn(retGrid, 0, "Amount", false, true, 1, 70);
      AddColumn(retGrid, 0, "OrderRemark", false, true, 1, 270);
      base.InitForm();
      for (int i = 0; i < retGrid.ColumnCount; i++)
      {
        retGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
      }
      this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
      dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
      dtpEnd.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
      dtpStart.CustomFormat = SystemInfo.DateTimeFormat;
      dtpEnd.CustomFormat = SystemInfo.DateTimeFormat;
      UserList.Clear();
      List<string> SysID = new List<string>();
      TMobileInfo info = new TMobileInfo("");
      UserList.Add(info);
      DataTableReader dr = null;
      string s01 = "";
      string s02 = "";
      string s11 = "";
      string s12 = "";
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "0" }));
        while (dr.Read())
        {
          SysID.Add(dr["MacSysID"].ToString());
        }
        for (int i = 0; i < SysID.Count; i++)
        {
          dr.Close();
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", SysID[i] }));
          if (dr.Read())
          {
            s01 = dr["MobileInfo"].ToString();
            if (s01 == "") continue;
            info = new TMobileInfo(s01);
            if (UserList.Count > 0)
            {
              s01 = UserList[UserList.Count - 1].KeyID + UserList[UserList.Count - 1].MercID + UserList[UserList.Count - 1].TrmNo +
                UserList[UserList.Count - 1].PWD;
              s02 = info.KeyID + info.MercID + info.TrmNo + info.PWD;
              s11 = UserList[UserList.Count - 1].XJLName + UserList[UserList.Count - 1].XJLPWD;
              s12 = info.XJLName + info.XJLPWD;
              if (UserList[UserList.Count - 1].MobTyp != info.MobTyp)
              {
                UserList.Add(info);
              }
              else if (UserList[UserList.Count - 1].MobTyp == 0 && s01 != s02)
              {
                UserList.Add(info);
              }
              else if (UserList[UserList.Count - 1].MobTyp == 1 && s11 != s12)
              {
                UserList.Add(info);
              }
            }
          }
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      clbUserInfo.Items.Clear();
      for (int i = 0; i < UserList.Count; i++)
      {
        info = UserList[i];
        if (info.MobTyp == 0)
        {
          s01 = info.MercID + "[" + info.TrmNo + "]";
        }
        else
        {
          s01 = info.XJLName + "[" + info.XJLPWD + "]";
        }
        clbUserInfo.Items.Add(s01);
        clbUserInfo.SetItemChecked(clbUserInfo.Items.Count - 1, true);
      }
    }

    public frmSFMobileCheck()
    {
      InitializeComponent();
    }

    private void btnCheck_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "M", true)) return;
      CurrentOprt = btnOk.Text;
      dtStart = dtpStart.Value;
      dtEnd = dtpEnd.Value;
      lbRet.Items.Clear();
      retGrid.DataSource = null;
      DataTable dtGrid = new DataTable();
      dtGrid.Columns.Add("RecordNo", typeof(int));
      dtGrid.Columns.Add("OrderNo", typeof(string));
      dtGrid.Columns.Add("OrderTime", typeof(string));
      dtGrid.Columns.Add("PayTime", typeof(string));
      dtGrid.Columns.Add("IsWX", typeof(bool));
      dtGrid.Columns.Add("Amount", typeof(double));
      dtGrid.Columns.Add("OrderRemark", typeof(string));
      string StartTime = dtStart.ToString("yyyyMMddHHmmss");
      string EndTime = dtEnd.ToString("yyyyMMddHHmmss");
      string ErrMsg = "";
      int PageCount = 0;
      int RecordNo = 1;
      QHAPI.TBillOrderInfo BillData = new QHAPI.TBillOrderInfo();
      BillData.Data = new QHAPI.TOrderInfo[20];
      TMobileInfo info;
      for (int i = 0; i < clbUserInfo.Items.Count; i++)
      {
        if (!clbUserInfo.GetItemChecked(i)) continue;
        info = UserList[i];
        DeviceObject.objCard.MobileInit(info.MobTyp, info.MercID, info.TrmNo, info.PWD, info.XJLName, info.XJLPWD);
        if (!DeviceObject.objCard.BillFirst(StartTime, EndTime, ref  ErrMsg, ref  PageCount, ref BillData))
        {
          if (ErrMsg == "") ErrMsg = Pub.GetResText(formCode, "CheckFail", "");
          lbRet.Items.Add("[" + DateTime.Now.ToString(SystemInfo.DateTimeFormat) + "] " + ErrMsg);
          continue;
        }
        if (PageCount == 0)
        {
          if (ErrMsg == "") ErrMsg = Pub.GetResText(formCode, "NoData", "");
          lbRet.Items.Add("[" + DateTime.Now.ToString() + "] " + ErrMsg);
          continue;
        }
        for (int k = 0; k < BillData.Count; k++)
        {
          if (BillData.Data[k].OrderNo.Length != 32 || BillData.Data[k].OrderTime.ToOADate() == 0) continue;
          dtGrid.Rows.Add(new object[] { RecordNo, BillData.Data[k].OrderNo, BillData.Data[k].OrderTime.ToString(SystemInfo.DateTimeFormat), 
            BillData.Data[k].PayTime.ToString(SystemInfo.DateTimeFormat), BillData.Data[k].IsWX == 1, BillData.Data[k].Amount,
            BillData.Data[k].OrderRemark});
          RecordNo++;
        }
        for (int j = 2; j <= PageCount; j++)
        {
          if (DeviceObject.objCard.BillNext(StartTime, EndTime, j, ref  ErrMsg, ref BillData))
          {
            for (int k = 0; k < BillData.Count; k++)
            {
              if (BillData.Data[k].OrderNo.Length != 32 || BillData.Data[k].OrderTime.ToOADate() == 0) continue;
              dtGrid.Rows.Add(new object[] { RecordNo, BillData.Data[k].OrderNo, BillData.Data[k].OrderTime.ToString(SystemInfo.DateTimeFormat), 
                BillData.Data[k].PayTime.ToString(SystemInfo.DateTimeFormat), BillData.Data[k].IsWX == 1, BillData.Data[k].Amount,
                BillData.Data[k].OrderRemark });
              RecordNo++;
            }
          }
          else
          {
            if (ErrMsg == "") ErrMsg = Pub.GetResText(formCode, "CheckFail", "");
            lbRet.Items.Add("[" + DateTime.Now.ToString(SystemInfo.DateTimeFormat) + "] " + ErrMsg);
          }
        }
      }
      try
      {
        retGrid.DataSource = dtGrid;
        if (retGrid.RowCount > 0)
        {
          retGrid.Rows[0].Selected = true;
          retGrid.CurrentCell = retGrid.Rows[0].Cells[0];
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "M", true)) return;
      CurrentOprt = btnOk.Text;

    }
  }
}