using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace ECard78
{
  public partial class frmLogin : frmBaseDialog
  {
    private bool IsRePassword = false;
    private string RePassword = "";
    private bool PassIsChange = false;
    private string DBAppDate = "";
    private string DBAppVer = "";
    private DateTime appLastWriteTime = new DateTime();
    private string updateFileName = SystemInfo.AppPath + "ECardUD78.exe";

    private void CompareFileTime(string fileName)
    {
      if (File.Exists(fileName))
      {
        DateTime dtTime = Pub.GetFileTime(fileName);
        if (dtTime > appLastWriteTime) appLastWriteTime = dtTime;
      }
    }

    private bool ShowDBConnect()
    {
      bool ret = false;
      if (new frmDBConnect().ShowDialog() == DialogResult.OK)
      {
        SystemInfo.IsRestart = true;
        this.Close();
        ret = true;
      }
      return ret;
    }

    protected override void InitForm()
    {
      formCode = "Login";
      base.InitForm();
      appLastWriteTime = Pub.GetFileTime(Application.ExecutablePath);
      SystemInfo.ConnStr = GetConnStrSystem();
      if ((SystemInfo.DBType == 1) && (DBServerInfo.ServerName == "")) 
      {
        if (ShowDBConnect()) return;
      }
      LoadAccount();
      IsRePassword = (SystemInfo.ini.ReadIni("Public", "IsRePassword", "") == "1");
      RePassword = SystemInfo.ini.ReadIni("Public", "RePassword", "");
      chkPass.Checked = IsRePassword;
      if (SystemInfo.LangName == "CHS" || SystemInfo.LangName == "CHT")
      {
        lblTitle.Font = new Font(Font.Name, 20, FontStyle.Bold);
        lblVersion.Font = new Font(Font.Name, 10, FontStyle.Bold);
      }
      else
      {
        lblTitle.Font = new Font(Font.Name, 16, FontStyle.Bold);
        lblVersion.Font = new Font(Font.Name, 10, FontStyle.Bold);
      }
      label4.Font = lblTitle.Font;
      lblTitle.Text = SystemInfo.AppTitle;
      lblVersion.Text = SystemInfo.AppVersion;
      label4.Text = lblTitle.Text;
      float size = 20;
      while (label4.Width > lblTitle.Width)
      {
        label4.Font = new Font(Font.Name, size, FontStyle.Bold);
        size = size - (float)0.5;
      }
      lblTitle.Font = label4.Font;
      if (SystemInfo.DBType == 2) btnConnect.Visible = false;
      btnConnect.Enabled=btnConnect.Visible;
    }

    public frmLogin()
    {
      InitializeComponent();
    }

    private void cbbAccount_SelectedIndexChanged(object sender, EventArgs e)
    {
      LoadData();
    }

    private void txtPass_TextChanged(object sender, EventArgs e)
    {
      PassIsChange = true;
    }

    private void btnMoreTool_Click(object sender, EventArgs e)
    {
      ShowDBConnect();
    }
    
    private bool SameAppVer()
    {
      bool ret = true;

      if (DBAppVer != "" && DBAppVer.Substring(0, 3) != Application.ProductVersion.Substring(0, 3))
      {
        ret = false;
        if ((DBAppVer.Substring(0, 3) == "2.0" || DBAppVer.Substring(0, 3) == "2.1") && Application.ProductVersion.Substring(0, 3) == "70.") ret = true;
      }
      return ret;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      CheckDBUpdate();
      if (!SameAppVer())
      {
        string msg = Pub.GetResText(formCode, "MsgSameAppVer", "");
        if (DBAppVer.Substring(0, 3) == "2.0" || DBAppVer.Substring(0, 3) == "2.1" || DBAppVer.Substring(0, 3) == "70.")
          msg = string.Format(msg, "V70.X.X");
        else
          msg = string.Format(msg, "V78.X.X");
        Pub.ShowErrorMsg(msg);
        return;
      }
      bool CheckApp = SystemInfo.ini.ReadIni("Public", "CheckApp", true);
      if (CheckApp)
      {
        if (!db.CheckAppIsNewVer(true, DBAppVer))
        {
          Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "Msg003", ""), DBAppVer));
          return;
        }
      }
      AccountObject obj = (AccountObject)cbbOpter.Items[cbbOpter.SelectedIndex];
      string OprtNo = obj.Value;
      string OprtPWD = Pub.GetOprtEncrypt(txtPass.Text.Trim());
      Database dbEx = new Database(GetConnStr(SystemInfo.DatabaseName));
      DataTableReader dr = null;
      bool IsOk = false;
      string Pass = "";
      if (IsRePassword && chkPass.Checked && !PassIsChange) OprtPWD = RePassword;
      try
      {
        dbEx.Open();
        dr = dbEx.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "3", OprtNo }));
        if (dr.Read())
        {
          Pass = dr["OprtPWD"].ToString();
          if (OprtPWD == "") OprtPWD = Pub.GetOprtEncrypt("0");
          if (Pass == "") Pass = Pub.GetOprtEncrypt("0");
          if (Pass != OprtPWD)
          {
            txtPass.Focus();
            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error002", ""));
          }
          else
            IsOk = true;
          if ((IsOk) && (dr["OprtIsActive"].ToString() != "Y"))
          {
            cbbOpter.Focus();
            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error003", ""));
            IsOk = false;
          }
          if (IsOk)
          {
            DateTime dt1 = Convert.ToDateTime(dr["OprtStartDay"]);
            DateTime dt2 = Convert.ToDateTime(dr["OprtEndDay"]);
            DateTime svrDate = new DateTime();
            if (!db.GetServerDate(ref svrDate)) return;
            string msg = string.Format(Pub.GetResText(formCode, "Error000", ""), dt1, dt2, svrDate);
            if (dt1 > svrDate)
            {
              cbbOpter.Focus();
              Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error004", "") + msg);
              IsOk = false;
            }
            if (dt2 < svrDate)
            {
              cbbOpter.Focus();
              Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error005", "") + msg);
              IsOk = false;
            }
          }
          if (IsOk)
          {
            OprtInfo.OprtSysID = dr["OprtSysID"].ToString();
            OprtInfo.OprtNo = OprtNo;
            OprtInfo.OprtIsSys = (dr["RoleIsSys"].ToString() == "Y");
            OprtInfo.DepartPower = "";
            OprtInfo.DepartPowerSysID = "";
            if (!OprtInfo.OprtIsSys)
            {
              dr.Close();
              dr = dbEx.GetDataReader(Pub.GetSQL(DBCode.DB_000003, new string[] { "108", OprtInfo.OprtSysID }));
              while (dr.Read())
              {
                OprtInfo.DepartPower = OprtInfo.DepartPower + " OR DepartID='" + dr["DepartID"].ToString() + "'";
                OprtInfo.DepartPowerSysID = OprtInfo.DepartPowerSysID + " OR DepartSysID='" + 
                  dr["DepartSysID"].ToString() + "'";
              }
              if (OprtInfo.DepartPower == "")
              {
                OprtInfo.DepartPower = " AND (1=2)";
                OprtInfo.DepartPowerSysID = " AND (1=2)";
              }
              else
              {
                OprtInfo.DepartPower = " AND (DepartID IS NULL OR DepartID='' OR " + OprtInfo.DepartPower.Substring(4) + ")";
                OprtInfo.DepartPowerSysID = " AND (OR DepartSysID IS NULL OR DepartSysID='' OR " + OprtInfo.DepartPowerSysID.Substring(4) + ")";
              }
            }
            OprtInfo.OprtNoAndName = cbbOpter.Text;
            SystemInfo.ini.WriteIni("Public", "OprtNo", OprtInfo.OprtNo);
            if (chkPass.Checked)
            {
              SystemInfo.ini.WriteIni("Public", "IsRePassword", IsRePassword);
              SystemInfo.ini.WriteIni("Public", "RePassword", OprtPWD);
            }
            else
            {
              SystemInfo.ini.WriteIni("Public", "IsRePassword", "");
              SystemInfo.ini.WriteIni("Public", "RePassword", "");
            }
            SystemInfo.ini.WriteIni("Public", "DatabaseName", SystemInfo.AccDBName);
            dbEx.ExecSQL(Pub.GetSQL(DBCode.DB_000002, new string[] { "4", OprtNo }));
            dr.Close();
            dr = dbEx.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "101" }));
            if (dr.Read())
            {
              SystemInfo.CommanyName = dr["DepartName"].ToString();
              SystemInfo.CommanySysID = dr["DepartSysID"].ToString();
            }
            dbEx.ExecSQL(Pub.GetSQL(DBCode.DB_000002, new string[] { "6", SystemInfo.CardValidDays.ToString() }));
            dbEx.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "3001", 
              Pub.GetOprtEncrypt(DeviceObject.objCPIC.GetMacTAG()) }));
            if (SystemInfo.ini.ReadIni("Public", "NotCheckSF", false)) dbEx.CheckSFDataCount();
          }
        }
      }
      catch (Exception E)
      {
        IsOk = false;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
        dbEx.Close();
      }
      if (IsOk)
      {
        this.Close();
        this.DialogResult = DialogResult.OK;
        SystemInfo.ConnStr = GetConnStr(SystemInfo.DatabaseName);
        SystemInfo.ConnStrReport = GetConnStrReport(SystemInfo.DatabaseName);
      }
    }

    private bool GetForwardState(string DBName)
    {
      bool ret = false;
      Database dbEx = new Database(GetConnStr(DBName));
      DataTableReader dr = null;
      try
      {
        dbEx.Open();
        dr = dbEx.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { }));
        if (dr.Read()) ret = (dr[0].ToString() == "Y");
      }
      catch
      {
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
        dbEx.Close();
      }
      return ret;
    }

    private void LoadAccount()
    {
      string DatabaseName = SystemInfo.ini.ReadIni("Public", "DatabaseName", "");
      DataTableReader dr = null;
      string AccName;
      string DBName;
      bool IsForward;
      AccountObject obj;
      bool IsError = false;
      cbbAccount.Items.Clear();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        db.CreateAccountTable();
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "100" }));
        if (!dr.Read() && (SystemInfo.DBType == 2))
        {
          DBName = "ECard" + DateTime.Now.ToString(SystemInfo.YMFormatDB);
          string FileName = db.GetDatabasePath().ToString() + SystemInfo.DefaultDBBak;
          string DBPath = db.GetDatabasePath().ToString();
          if (!db.CreateDatabase(DBPath, DBName))
            db.DeleteDatabase(DBName, true);
          else if (!db.RestoreDatabase(DBName, FileName))
            db.DeleteDatabase(DBName, true);
          else
          {
            bool IsOk = true;
            string fn = FileName.Substring(FileName.LastIndexOf("\\") + 1).ToLower();
            Database dbEx = new Database(GetConnStr(DBName));
            try
            {
              dbEx.Open();
              if (IsOk && (fn == SystemInfo.DefaultDBBak.ToLower()))
              {

                IsOk = dbEx.UpdateDatabasesLang();
              }
              if (IsOk)
              {
                string sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "801", DBName, DBName, DBPath + DBName });
                db.ExecSQL(sql);
              }
            }
            catch (Exception E)
            {
              IsOk = false;
              Pub.ShowErrorMsg(E);
            }
            finally
            {
              dbEx.Close();
              dbEx = null;
            }
            if (!IsOk) db.DeleteDatabase(DBName, true);
          }
        }
        dr.Close();
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "100" }));
        while (dr.Read())
        {
          AccName = dr["AccName"].ToString();
          DBName = dr["DBName"].ToString();
          IsForward = ((dr["IsForward"].ToString() == "Y") || GetForwardState(DBName));
          obj = new AccountObject();
          obj.Text = AccName;
          if (IsForward) obj.Text = obj.Text + "[" + Pub.GetResText(formCode, "AccForwardY", "") + "]";
          obj.Name = AccName;
          obj.Value = DBName;
          obj.IsForward = IsForward;
          cbbAccount.Items.Add(obj);
          if ((AccName == DatabaseName) && !IsForward) cbbAccount.SelectedIndex = cbbAccount.Items.Count - 1;
        }
        if (((DatabaseName == "") || (cbbAccount.SelectedIndex == -1)) && (cbbAccount.Items.Count > 0))
        {
          for (int i = 0; i < cbbAccount.Items.Count; i++)
          {
            obj = (AccountObject)cbbAccount.Items[i];
            if (!obj.IsForward)
            {
              cbbAccount.SelectedIndex = i;
              break;
            }
          }
        }
        if ((cbbAccount.SelectedIndex == -1) && (cbbAccount.Items.Count > 0)) cbbAccount.SelectedIndex = 0;
      }
      catch (Exception E)
      {
        IsError = true;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (!IsError && (cbbAccount.Items.Count == 0))
      {
        if (!Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg001", "")))
        {
          try
          {
            System.Diagnostics.Process.Start(SystemInfo.AppPath + "ECardDB78.exe");
          }
          catch (Exception E)
          {
            Pub.ShowErrorMsg(E);
          }
          this.Close();
        }
      }
    }

    private void LoadData()
    {
      AccountObject obj;
      AccountObject objOprt;
      string DefNo = SystemInfo.ini.ReadIni("Public", "OprtNo", "");
      Database dbEx = null;
      DataTableReader dr = null;
      cbbOpter.Items.Clear();
      if (cbbAccount.SelectedIndex == -1) return;
      obj = (AccountObject)cbbAccount.Items[cbbAccount.SelectedIndex];
      SystemInfo.AccIsForward = obj.IsForward;
      SystemInfo.AccDBVersion = "";
      SystemInfo.DatabaseName = obj.Value;
      SystemInfo.AccDBName = obj.Name;
      dbEx = new Database(GetConnStr(SystemInfo.DatabaseName));
      try
      {
        dbEx.Open();
        dr = dbEx.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "1" }));
        while (dr.Read())
        {
          objOprt = new AccountObject();
          objOprt.Name = dr["OprtName"].ToString();
          objOprt.Value = dr["OprtNo"].ToString();
          objOprt.Text = objOprt.Value + "[" + objOprt.Name + "]";
          cbbOpter.Items.Add(objOprt);
          if ((DefNo != "") && (objOprt.Value == DefNo)) cbbOpter.SelectedIndex = cbbOpter.Items.Count - 1;
        }
        dr.Close();
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
        dbEx.Close();
      }
      if ((cbbOpter.SelectedIndex == -1) && (cbbOpter.Items.Count > 0)) cbbOpter.SelectedIndex = 0;
      btnOk.Enabled = (cbbOpter.SelectedIndex >= 0);
    }

    private void CheckDBUpdate()
    {
      Database dbEx = null;
      DataTableReader dr = null;
      bool ReqUpdate = false;
      DateTime dt = new DateTime();
      DateTime dtx = new DateTime();
      int ret = 0;
      dbEx = new Database(GetConnStr(SystemInfo.DatabaseName));
      try
      {
        dbEx.Open();
        dr = dbEx.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "2" }));
        if (dr.Read())
        {
          DBAppDate = dr["AppVer"].ToString();
          SystemInfo.AccDBVersion = dr["DbVersion"].ToString() + ".";
          dt = Convert.ToDateTime(dr["DbDate"]);
          dtx = new DateTime(2010, 12, 31);
          if (dt != dtx) ReqUpdate = true;
          dtx = new DateTime(2011, 3, 21);
          if (dt >= dtx) ReqUpdate = false;
          DateTime dtTmp = new DateTime();
          if (DateTime.TryParse(DBAppDate, out dtTmp))
          {
            dtTmp = new DateTime(dtTmp.Year, dtTmp.Month, dtTmp.Day, dtTmp.Hour, dtTmp.Minute, 0);
            DBAppDate = dtTmp.ToString(SystemInfo.SQLDateFMT) + " " + dtTmp.ToString("HH:mm");
          }
          if ((DBAppDate == "") || (appLastWriteTime > dtTmp))
          {
            DBAppDate = appLastWriteTime.ToString(SystemInfo.SQLDateFMT) + " " + appLastWriteTime.ToString("HH:mm");
            dbEx.ExecSQL(Pub.GetSQL(DBCode.DB_000002, new string[] { "7", DBAppDate }));
          }
          DBAppVer = dr["AppVerInfo"].ToString();
        }
        else
        {
          ReqUpdate = true;
          DBAppVer = "";
        }
        if (SameAppVer())
        {
          if (ReqUpdate)
          {
            switch (SystemInfo.DBType)
            {
              case 1:
              case 2:
                ret = dbEx.ExecSQL("ALTER TABLE RS_CardType ADD CardCheckOrder bit", true);
                if (ret != 0) dbEx.ExecSQL("UPDATE RS_CardType SET CardCheckOrder=1", true);
                dbEx.ExecSQL("UPDATE DbVersion SET DbDate='2010-12-31'", true);
                break;
            }
            dt = new DateTime(2010, 12, 31);
          }
          SystemInfo.AccDBVersion = SystemInfo.AccDBVersion + dt.ToString(SystemInfo.DateFormatDBVer);
          SystemInfo.AccDBDate = dt;
          dbEx.ReadSystemConfig();
          dbEx.UpdateDatabase(this.Text, dt);
          dr = dbEx.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "2" }));
          if (dr.Read())
          {
            SystemInfo.AccDBVersion = dr["DbVersion"].ToString() + ".";
            dt = Convert.ToDateTime(dr["DbDate"]);
            SystemInfo.AccDBVersion = SystemInfo.AccDBVersion + dt.ToString(SystemInfo.DateFormatDBVer);
            DBAppVer = dr["AppVerInfo"].ToString();
          }
          if ((DBAppVer == "") || (dbEx.CheckAppIsNewVer(DBAppVer)))
          {
            DBAppVer = Application.ProductVersion;
            dbEx.ExecSQL("UPDATE DbVersion SET AppVerInfo='" + DBAppVer + "'", true);
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
        dbEx.Close();
      }
    }
  }

  public class AccountObject
  {
    private string _text = "";
    private string _name = "";
    private string _value = "";
    private bool _IsForward = false;

    public string Text
    {
      get { return _text; }
      set { _text = value; }
    }

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public string Value
    {
      get { return _value; }
      set { _value = value; }
    }

    public bool IsForward
    {
      get { return _IsForward; }
      set { _IsForward = value; }
    }
  }
}