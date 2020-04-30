using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;

namespace ECard78
{
  public partial class frmMJMacPower : frmBaseMDIChildReport
  {
    private bool IsDowning = false;
    private bool IsFirstLoad = true;

    protected override void InitForm()
    {
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemEdit", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemTAG2", true);
      formCode = "MJMacPower";
      ReportFile = "MJMacPower";
      ReportStartIndex = 3;
      base.InitForm();
      QuerySQL = Pub.GetSQL(DBCode.DB_003004, new string[] { "1000", OprtInfo.DepartPower });
      FindSQL = Pub.GetSQL(DBCode.DB_003004, new string[] { "1001", OprtInfo.DepartPower });
      FindOrderBy = Pub.GetSQL(DBCode.DB_003004, new string[] { "1002" });
      FindKeyWord = formCode;
      if (SystemInfo.HasFaCard)
      {
        SetReportColumnVisible("CardSectorNo", true);
        SetReportColumnVisible("CardPhysicsNo10", false);
      }
      else
      {
        SetReportColumnVisible("CardSectorNo", false);
        SetReportColumnVisible("CardPhysicsNo10", true);
      }
      DataTableReader dr = null;
      TCommonType cType;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "1007" }));
        while (dr.Read())
        {
          cType = new TCommonType(dr["MacDoorName"].ToString(), dr["MacDoorID"].ToString(), dr["MacDoorName"].ToString(), true);
          clbDoor.Items.Add(cType);
          clbDoor.SetItemChecked(clbDoor.Items.Count - 1, true);
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
      chkDoor_CheckedChanged(null, null);
    }

    public frmMJMacPower()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmMJMacPowerAdd frm = new frmMJMacPowerAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemDelete()
    {
      IsDowning = true;
      RefreshForm(false);
      string msg = Pub.GetResText(formCode, "Msg003", "");
      lblMsg.Text = msg;
      progBar.Value = 0;
      Report.DetailGrid.Recordset.First();
      int Count = Report.DetailGrid.Recordset.RecordCount;
      int Index = 0;
      bool ret = false;
      byte DoorID = 0;
      UInt32 cardNo = 0;
      UInt32 OtherCardNo = 0;
      int suCount = 0;
      string EmpNo = "";
      string EmpName = "";
      string tmp = "";
      string err = Pub.GetResText(formCode, "Error001", "");
      string errMsg = "";
      List<string> sql = new List<string>();
      TConnInfoNewMJ connInfo = new TConnInfoNewMJ();
      Report.DetailGrid.Recordset.First();
      while (!Report.DetailGrid.Recordset.Eof())
      {
        if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsi3DChecked)
        {
          byte.TryParse(Report.FieldByName("MacDoorID").AsString, out DoorID);
          UInt32.TryParse(Report.FieldByName("CardPhysicsNo10").AsString, out cardNo);
          UInt32.TryParse(Report.FieldByName("OtherCardNo").AsString, out OtherCardNo);
          EmpNo = Report.FieldByName("EmpNo").AsString;
          if (EmpNo == null) EmpNo = "";
          EmpName = Report.FieldByName("EmpName").AsString;
          if (EmpName == null) EmpName = "";
          tmp = "[" + EmpNo + "]" + EmpName + " [" + Report.FieldByName("MacSN").AsString + ": " +
            Report.FieldByName("MacDoorName").AsString + "]";
          lblMsg.Text = msg + tmp;
          if (GetConnInfo(Report.FieldByName("MacSysID").AsString, ref connInfo))
          {
            DeviceObject.objMJNew.NewDevice(connInfo);
            ret = true;
            if (cardNo > 0) ret = DeviceObject.objMJNew.RemoveRegister(DoorID, cardNo);
            if (ret && OtherCardNo > 0) ret = DeviceObject.objMJNew.RemoveRegister(DoorID, OtherCardNo);
            sql.Clear();
            GetDelSql(0, ref sql);
            GetDelSqlExt(ref sql);
            if (!ret)
            {
              errMsg = string.Format(err, tmp, GetErrMsg(ret));
              if (Pub.MessageBoxQuestion(errMsg, MessageBoxButtons.YesNo) == DialogResult.No) break;
            }
            else
            {
              if (db.ExecSQL(sql) != 0) break;
              db.WriteSYLog(this.Text, CurrentTool, tmp + GetErrMsg(ret));
              suCount += 1;
            }
            if (!IsDowning) break;
          }
          else
            break;
        }
        Report.DetailGrid.Recordset.Next();
        Index += 1;
        if (!IsDowning) break;
        if (Index >= Count) break;
        progBar.Value = Index * 100 / Count;
        Application.DoEvents();
      }
      IsDowning = false;
      progBar.Value = 0;
      ExecItemRefresh();
      Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Msg004", ""), suCount), MessageBoxIcon.Information);
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      IsDowning = true;
      RefreshForm(true);
      string msg = Pub.GetResText(formCode, "Msg001", "");
      bool IsE = false;
      lblMsg.Text = msg;
      progBar.Value = 0;
      Report.DetailGrid.Recordset.First();
      int Count = Report.DetailGrid.Recordset.RecordCount;
      int Index = 0;
      AccessV2API.TYPE_Register Register;
      bool ret = false;
      byte DoorID = 0;
      UInt32 cardNo = 0;
      UInt32 OtherCardNo = 0;
      int suCount = 0;
      string EmpNo = "";
      string EmpName = "";
      string EmpPass = "";
      string tmp = "";
      string err = Pub.GetResText(formCode, "Error002", "");
      string errMsg = "";
      TConnInfoNewMJ connInfo = new TConnInfoNewMJ();
      int RecNo = Report.DetailGrid.Recordset.RecordNo;
      Report.DetailGrid.Recordset.First();
      while (!Report.DetailGrid.Recordset.Eof())
      {
        if (Report.FieldByName("Checked").AsInteger == (int)GRSystemImage.grsi3DChecked)
        {
          IsE = Report.FieldByName("IsEnable").AsString.ToUpper() == "Y";
          byte.TryParse(Report.FieldByName("MacDoorID").AsString, out DoorID);
          UInt32.TryParse(Report.FieldByName("CardPhysicsNo10").AsString, out cardNo);
          UInt32.TryParse(Report.FieldByName("OtherCardNo").AsString, out OtherCardNo);
          EmpNo = DeviceObject.objMJNew.GetLengthText(Report.FieldByName("EmpNo").AsString, 16);
          EmpName = DeviceObject.objMJNew.GetLengthText(Report.FieldByName("EmpName").AsString, 16);
          EmpPass = DeviceObject.objMJNew.GetLengthText(Report.FieldByName("CardPWD").AsString, 8);
          tmp = "[" + EmpNo + "]" + EmpName + " [" + Report.FieldByName("MacSN").AsString + ": " +
            Report.FieldByName("MacDoorName").AsString + "]";
          lblMsg.Text = msg + tmp;
          if (GetConnInfo(Report.FieldByName("MacSysID").AsString, ref connInfo))
          {
            DeviceObject.objMJNew.NewDevice(connInfo);
            if (IsE)
            {
              ret = true;
              if (cardNo > 0)
              {
                Register = new AccessV2API.TYPE_Register();
                Register.CardNo = cardNo;
                Register.Door = DoorID;
                Register.Password = EmpPass;
                UInt32.TryParse(Report.FieldByName("MacTimeNo").AsString, out Register.TimeGroup);
                DeviceObject.objMJNew.DateTimeToMJDateTime(Report.FieldByName("CardStartDate").AsDateTime, ref Register.DateBegin);
                DeviceObject.objMJNew.DateTimeToMJDateTime(Report.FieldByName("CardEndDate").AsDateTime, ref Register.DateEnd);
                Register.UserID = EmpNo;
                Register.UserName = EmpName;
                ret = DeviceObject.objMJNew.AddRegister(Register);
              }
              if (ret && OtherCardNo > 0)
              {
                Register = new AccessV2API.TYPE_Register();
                Register.CardNo = OtherCardNo;
                Register.Door = DoorID;
                Register.Password = EmpPass;
                UInt32.TryParse(Report.FieldByName("MacTimeNo").AsString, out Register.TimeGroup);
                DeviceObject.objMJNew.DateTimeToMJDateTime(Report.FieldByName("CardStartDate").AsDateTime, ref Register.DateBegin);
                DeviceObject.objMJNew.DateTimeToMJDateTime(Report.FieldByName("CardEndDate").AsDateTime, ref Register.DateEnd);
                Register.UserID = EmpNo;
                Register.UserName = EmpName;
                ret = DeviceObject.objMJNew.AddRegister(Register);
              }
            }
            else
            {
              ret = true;
              if (cardNo > 0) ret = DeviceObject.objMJNew.RemoveRegister(DoorID, cardNo);
              if (ret && OtherCardNo > 0) ret = DeviceObject.objMJNew.RemoveRegister(DoorID, OtherCardNo);
            }
            if (!ret)
            {
              errMsg = string.Format(err, tmp, GetErrMsg(ret));
              if (Pub.MessageBoxQuestion(errMsg, MessageBoxButtons.YesNo) == DialogResult.No) break;
            }
            else
            {
              db.WriteSYLog(this.Text, CurrentTool, tmp + GetErrMsg(ret));
              suCount += 1;
            }
            if (!IsDowning) break;
          }
          else
            break;
        }
        Report.DetailGrid.Recordset.Next();
        Index += 1;
        if (!IsDowning || (Index >= Count)) break;
        progBar.Value = Index * 100 / Count;
        Application.DoEvents();
      }
      IsDowning = false;
      RefreshForm(true);
      lblMsg.Text = string.Format(Pub.GetResText(formCode, "Msg002", ""), suCount);
      progBar.Value = 0;
      Report.DetailGrid.Recordset.MoveTo(RecNo);
    }

    protected override void ExecItemTAG2()
    {
      base.ExecItemTAG2();
      IsDowning = false;
      RefreshForm(true);
    }

    protected override void ExecItemRefresh()
    {
      string EmpTag = "0";
      string EmpNo = "";
      string DepartTag = "0";
      string DepartID = "";
      string DepartList = "";
      string Door = "";
      if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
      {
        EmpNo = txtEmp.Tag.ToString();
        EmpTag = "1";
      }
      else if (txtEmp.Text.Trim() != "")
      {
        EmpNo = txtEmp.Text.Trim();
      }
      if ((txtDepart.Text.Trim() != "") && (txtDepart.Tag != null))
      {
        DepartID = txtDepart.Tag.ToString();
        DepartTag = "1";
      }
      else if (txtDepart.Text.Trim() != "")
      {
        DepartID = txtDepart.Text.Trim();
      }
      if (DepartTag == "1")
      {
        if (DepartID != "") DepartList = db.GetDepartChildID(DepartID);
        if (DepartList == "") DepartList = "''";
      }
      if (chkDoor.Checked)
      {
        for (int i = 0; i < clbDoor.Items.Count; i++)
        {
          if (clbDoor.GetItemChecked(i)) Door = Door + "'" + ((TCommonType)clbDoor.Items[i]).sysID + "',";
        }
        if (Door != "") Door = Door.Substring(0, Door.Length - 1);
      }
      if (!IsFirstLoad)
      {
        QuerySQL = Pub.GetSQL(DBCode.DB_003004, new string[] { "1003", FindSQL, FindOrderBy, EmpTag, EmpNo, DepartTag, 
          DepartID, DepartList, Door });
      }
      IsFirstLoad = false;
      base.ExecItemRefresh();
    }

    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(!IsDowning);
      pnlDisp.Enabled = pnlDisp.Enabled && !IsDowning;
      ItemTAG1.Enabled = ItemTAG1.Enabled && !IsDowning;
      ItemTAG2.Enabled = IsDowning;
      SetContextMenuState();
    }

    private bool GetConnInfo(string MacSysID, ref TConnInfoNewMJ connInfo)
    {
      bool ret = false;
      connInfo = new TConnInfoNewMJ();
      DataTableReader dr = null;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "1003", MacSysID }));
        if (dr.Read())
        {
          connInfo = Pub.ValueToNewMJConnInfo(dr["MacSN"].ToString(), dr["MacConnType"].ToString(),
            dr["MacIpAddress"].ToString(), dr["MacPort"].ToString(), dr["MacConnPWD"].ToString());
          ret = true;
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
      return ret;
    }

    private string GetErrMsg(bool ret)
    {
      return ret ? Pub.GetResText("", "MsgSuccess", "") : Pub.GetResText("", "MsgFailure", "");
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_003004, new string[] { "4", Report.FieldByName("EmpSysID").AsString, 
        Report.FieldByName("MacSysID").AsString, Report.FieldByName("MacDoorSysID").AsString });
      sql.Add(ret);
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      ret = "[" + Report.FieldByName("EmpNo").AsString + "]" + Report.FieldByName("EmpName").AsString + " [" +
        Report.FieldByName("MacSN").AsString + ": " + Report.FieldByName("MacDoorName").AsString + "]";
      return ret;
    }

    private void frmMJMacPower_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsDowning) e.Cancel = true;
    }

    private void btnSelectEmp_Click(object sender, EventArgs e)
    {
      frmPubSelectEmp frm = new frmPubSelectEmp();
      if (frm.ShowDialog() == DialogResult.OK)
      {
        txtEmp.Text = frm.EmpName;
        txtEmp.Tag = frm.EmpNo;
      }
    }

    private void txtEmp_KeyPress(object sender, KeyPressEventArgs e)
    {
      txtEmp.Tag = null;
    }

    private void btnSelectDepart_Click(object sender, EventArgs e)
    {
      frmPubSelectDepart frm = new frmPubSelectDepart();
      if (frm.ShowDialog() == DialogResult.OK)
      {
        txtDepart.Text = frm.DepartName;
        txtDepart.Tag = frm.DepartID;
      }
    }

    private void txtDepart_KeyPress(object sender, KeyPressEventArgs e)
    {
      txtDepart.Tag = null;
    }

    private void chkDoor_CheckedChanged(object sender, EventArgs e)
    {
      clbDoor.Enabled = chkDoor.Checked;
    }
  }
}