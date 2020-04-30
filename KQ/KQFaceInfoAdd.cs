using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQFaceInfoAdd : frmBaseDialog
  {
    private int MacSN = 0;
    private string MacSN_GPRS = "";
    private string MacConnType = "";
    private string MacIPAddress = "";
    private string MacPort = "";
    private string MacConnPWD = "";
    private string MacPhysicsAddress = "";
    private string MacDesc = "";
    private bool IsGPRS = false;
    private const int AcPort = 5005;

    protected override void InitForm()
    {
      formCode = "KQFaceInfoAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      lblMacSN.ForeColor = Color.Red;
      lblCommPort.ForeColor = Color.Red;
      lblCommBaudRate.ForeColor = Color.Red;
      lblLANIP.ForeColor = Color.Red;
      lblLANPort.ForeColor = Color.Red;
      SetTextboxNumber(txtMacSN);
      SetTextboxNumber(txtLANPort);
      Pub.InitCommList(cbbCommPort);
      LoadData();
      RadioButton_Click(null, null);
      chkGPRS.Text = "GPRS";
    }

    public frmKQFaceInfoAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "2002" }));
          if (dr.Read())
          {
            int no = 0;
            int.TryParse(dr[0].ToString(), out no);
            if (no > SystemInfo.MaxSNFinger) no = SystemInfo.MaxSNFinger;
            txtMacSN.Text = no.ToString();
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "2003", SysID }));
          if (dr.Read())
          {
            txtMacSN.Text = dr["MacSN"].ToString();
            switch (dr["MacConnType"].ToString())
            {
              case MacConnTypeString.USB:
                rbUSB.Checked = true;
                break;
              case MacConnTypeString.Comm:
                rbComm.Checked = true;
                cbbCommPort.Text = dr["MacPort"].ToString();
                cbbCommBaudRate.Text = dr["MacConnPWD"].ToString();
                break;
              case MacConnTypeString.LAN:
                rbLAN.Checked = true;
                txtLANIP.Text = dr["MacIpAddress"].ToString();
                txtLANPort.Text = dr["MacPort"].ToString();
                chkGPRS.Checked = Pub.ValueToBool(dr["IsGPRS"]);
                break;
            }
            txtDesc.Text = dr["MacDesc"].ToString();
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
    }

    private void RadioButton_Click(object sender, EventArgs e)
    {
      pnlComm.Enabled = rbComm.Checked;
      pnlLAN.Enabled = rbLAN.Checked;
      if (sender == null) return;
      if (rbComm.Checked)
      {
        if ((cbbCommPort.SelectedIndex == -1) && (cbbCommPort.Items.Count > 0)) cbbCommPort.SelectedIndex = 0;
        if (cbbCommBaudRate.SelectedIndex == -1) cbbCommBaudRate.SelectedIndex = 2;
      }
      else
      {
        cbbCommPort.SelectedIndex = -1;
        cbbCommBaudRate.SelectedIndex = -1;
      }
      if (rbLAN.Checked)
      {
        txtLANPort.Text = AcPort.ToString();
      }
      else
      {
        txtLANPort.Text = "";
      }
    }

    private bool CheckValue()
    {
      if (txtMacSN.Text.Trim() == "")
      {
        txtMacSN.Focus();
        ShowErrorEnterCorrect(lblMacSN.Text);
        return false;
      }
      IsGPRS = false;
      if (rbLAN.Checked) IsGPRS = chkGPRS.Checked;
      if (IsGPRS)
      {
        MacSN_GPRS = txtMacSN.Text.Trim();
      }
      else
      {
        if (!Pub.IsNumeric(txtMacSN.Text))
        {
          txtMacSN.Focus();
          Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorMacSN603", ""), 1, SystemInfo.MaxSNFinger));
          return false;
        }
        MacSN = Convert.ToInt32(txtMacSN.Text);
        if ((MacSN < 1) || (MacSN > SystemInfo.MaxSNFinger))
        {
          txtMacSN.Focus();
          Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorMacSN603", ""), 1, SystemInfo.MaxSNFinger));
          return false;
        }
        MacSN_GPRS = MacSN.ToString();
      }
      MacConnType = MacConnTypeString.USB;
      MacIPAddress = "";
      MacPort = "";
      MacConnPWD = "";
      MacDesc = "";
      MacPhysicsAddress = "";
      if (rbComm.Checked)
      {
        MacConnType = MacConnTypeString.Comm;
        MacPort = cbbCommPort.Text;
        MacConnPWD = cbbCommBaudRate.Text;
      }
      else if (rbLAN.Checked)
      {
        MacConnType = MacConnTypeString.LAN;
        MacIPAddress = txtLANIP.Text.Trim();
        MacPort = txtLANPort.Text.Trim();
        if (MacIPAddress == "")
        {
          txtLANIP.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMacIP", ""));
          return false;
        }
        if (!Pub.CheckTextMaxLength(lblLANIP.Text, MacIPAddress, txtLANIP.MaxLength))
        {
          txtLANIP.Focus();
          return false;
        }
        if (!Pub.IsNumeric(MacPort))
        {
          txtLANPort.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMacPort", ""));
          return false;
        }
      }
      MacDesc = txtDesc.Text.Trim();
      if (!Pub.CheckTextMaxLength(label1.Text, MacDesc, txtDesc.MaxLength))
      {
        txtDesc.Focus();
        return false;
      }
      return true;
    }

    private void btnTestConnect_Click(object sender, EventArgs e)
    {
      if (!CheckValue()) return;
      TConnInfoFinger conn = Pub.ValueToConnInfoFinger(MacSN, MacSN_GPRS, MacConnType, 
        MacIPAddress, MacPort, MacConnPWD, IsGPRS);
      this.Enabled = false;
      bool ret = false;
      string msg = "";
      string dtS = "";
      DateTime dt = new DateTime();
      DeviceObject.objFK623.InitConn(conn);
      ret = DeviceObject.objFK623.GetDeviceTime(ref dt);
      if (ret) dtS = dt.ToString();
      msg = DeviceObject.objFK623.ErrMsg;
      if (ret) msg = msg + "\r\n\r\n" + dtS;
      if (ret)
        Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
      else
        Pub.ShowErrorMsg(msg);
      this.Enabled = true;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      DataTableReader dr = null;
      bool IsOk = false;
      string sql = "";
      if (!CheckValue()) return;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "2004", MacSN_GPRS }));
          if (dr.Read())
          {
            txtMacSN.Focus();
            ShowErrorCannotRepeated(lblMacSN.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "2005", MacSN_GPRS, "3", "", 
              MacConnType, MacIPAddress, MacPort, MacConnPWD, MacDesc, MacPhysicsAddress, 
              Convert.ToByte(IsGPRS).ToString() });
            db.ExecSQL(sql);
            IsOk = true;
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "2006", SysID, MacSN_GPRS }));
          if (dr.Read())
          {
            txtMacSN.Focus();
            ShowErrorCannotRepeated(lblMacSN.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "2007", MacSN_GPRS, "3", "", MacConnType, 
              MacIPAddress, MacPort, MacConnPWD, MacDesc, MacPhysicsAddress, 
              Convert.ToByte(IsGPRS).ToString(), SysID });
            db.ExecSQL(sql);
            IsOk = true;
          }
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (IsOk)
      {
        db.WriteSYLog(this.Text, CurrentOprt, sql);
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}