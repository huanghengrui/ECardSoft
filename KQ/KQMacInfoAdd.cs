using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQMacInfoAdd : frmBaseDialog
  {
    private int MacSN = 0;
    private byte IsBigMac = 0;
    private string MacConnType = "";
    private string MacIPAddress = "";
    private string MacPort = "";
    private string MacConnPWD = "";
    private string MacPhysicsAddress = "";
    private string MacDesc = "";

    protected override void InitForm()
    {
      formCode = "KQMacInfoAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      lblMacSN.ForeColor = Color.Red;
      lblCommPort.ForeColor = Color.Red;
      lblCommBaudRate.ForeColor = Color.Red;
      lblLANIP.ForeColor = Color.Red;
      lblLANPort.ForeColor = Color.Red;
      lblWANIP.ForeColor = Color.Red;
      lblWANPort.ForeColor = Color.Red;
      lblWANAddress.ForeColor = Color.Red;
      SetTextboxNumber(txtMacSN);
      SetTextboxNumber(txtLANPort);
      SetTextboxNumber(txtWANPort);
      Pub.InitCommList(cbbCommPort);
      LoadData();
      RadioButton_Click(null, null);
      if (SystemInfo.IsBigMacAdd) txtMacSN.MaxLength = 5;
    }

    public frmKQMacInfoAdd(string title, string CurrentTool, string GUID)
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
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "101" }));
          if (dr.Read())
          {
            int no = 0;
            int.TryParse(dr[0].ToString(), out no);
            if (SystemInfo.IsBigMacAdd)
            {
              if (no > SystemInfo.MaxSN603Ex) no = SystemInfo.MaxSN603Ex;
            }
            else
            {
              if (no > SystemInfo.MaxSN603) no = SystemInfo.MaxSN603;
            }
            txtMacSN.Text = no.ToString();
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "4", SysID }));
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
                break;
              case MacConnTypeString.GPRS:
                rbWAN.Checked = true;
                txtWANIP.Text = dr["MacIpAddress"].ToString();
                txtWANPort.Text = dr["MacPort"].ToString();
                txtWANAddress.Text = dr["MacPhysicsAddress"].ToString();
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
      pnlWAN.Enabled = rbWAN.Checked;
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
        txtLANPort.Text = SystemInfo.LAN603Port.ToString();
      }
      else
      {
        txtLANPort.Text = "";
      }
      if (rbWAN.Checked)
      {
        txtWANIP.Text = SystemInfo.GPRS603IP;
        txtWANPort.Text = SystemInfo.LAN603Port.ToString();
      }
      else
      {
        txtWANIP.Text = "";
        txtWANPort.Text = "";
        txtWANAddress.Text = "";
      }
    }

    private bool CheckValue()
    {
      int MaxSN = SystemInfo.IsBigMacAdd ? SystemInfo.MaxSN603Ex : SystemInfo.MaxSN603;
      IsBigMac = SystemInfo.IsBigMacAdd ? (byte)1 : (byte)0;
      if ((txtMacSN.Text == "") || !Pub.IsNumeric(txtMacSN.Text))
      {
        txtMacSN.Focus();
        Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorMacSN603", ""), 1, MaxSN));
        return false;
      }
      MacSN = Convert.ToInt32(txtMacSN.Text);
      if ((MacSN < 1) || (MacSN > MaxSN))
      {
        txtMacSN.Focus();
        Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorMacSN603", ""), 1, MaxSN));
        return false;
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
        if (MacPort == "")
        {
          ShowErrorSelectCorrect(lblCommPort.Text);
          return false;
        }
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
      else if (rbWAN.Checked)
      {
        MacConnType = MacConnTypeString.GPRS;
        MacIPAddress = txtWANIP.Text.Trim();
        MacPort = txtWANPort.Text.Trim();
        MacPhysicsAddress = txtWANAddress.Text.Trim().ToUpper();
        if (MacIPAddress == "")
        {
          txtWANIP.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMacIP", ""));
          return false;
        }
        if (!Pub.CheckTextMaxLength(lblWANIP.Text, MacIPAddress, txtWANIP.MaxLength))
        {
          txtWANIP.Focus();
          return false;
        }
        if (!Pub.IsNumeric(MacPort))
        {
          txtWANPort.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMacPort", ""));
          return false;
        }
        if (MacPhysicsAddress == "")
        {
          txtWANAddress.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMacAddress", ""));
          return false;
        }
        if (!Pub.CheckTextMaxLength(lblWANAddress.Text, MacIPAddress, txtWANAddress.MaxLength))
        {
          txtWANAddress.Focus();
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
      DateTime dt = new DateTime();
      if (!CheckValue()) return;
      QHKS.TConnInfo connInfo = Pub.ValueToConnInfo(IsBigMac, MacSN, 1, MacConnType, MacIPAddress, MacPort,
        MacConnPWD, MacPhysicsAddress);
      DeviceObject.objKS.Init(ref connInfo);
      this.Enabled = false;
      bool ret = DeviceObject.objKS.PubTimeGet(ref dt);
      string msg = DeviceObject.objKS.ErrMsg;
      if (ret) msg = msg + "\r\n\r\n" + dt;
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
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "5", MacSN.ToString() }));
          if (dr.Read())
          {
            txtMacSN.Focus();
            ShowErrorCannotRepeated(lblMacSN.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "1", MacSN.ToString(), SystemInfo.CardType.ToString(), 
              MacConnType, MacIPAddress, MacPort, MacConnPWD, MacDesc, MacPhysicsAddress, IsBigMac.ToString() });
            db.ExecSQL(sql);
            IsOk = true;
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "6", SysID, MacSN.ToString() }));
          if (dr.Read())
          {
            txtMacSN.Focus();
            ShowErrorCannotRepeated(lblMacSN.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_002001, new string[] { "2", MacSN.ToString(), SystemInfo.CardType.ToString(), 
              MacConnType, MacIPAddress, MacPort, MacConnPWD, MacDesc, MacPhysicsAddress, IsBigMac.ToString(), SysID });
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