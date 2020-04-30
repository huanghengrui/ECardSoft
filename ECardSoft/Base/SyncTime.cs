using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSyncTime : frmBaseForm
  {
    private int MacSN = 0;
    private string MacType = "";
    private string MacConnType = "";
    private string MacIPAddress = "";
    private string MacPort = "";
    private string MacConnPWD = "";
    private string MacPhysicsAddress = "";

    protected override void InitForm()
    {
      formCode = "SyncTime";
      base.InitForm();
      txtMacSN.Text = SystemInfo.MaxSN603Find.ToString();
      lblMacSN.ForeColor = Color.Red;
      lblMacType.ForeColor = Color.Red;
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
      cbbMacType.Items.Clear();
      TCommonType cType;
      string s = "";
      for (int i = 1; i <= 6; i++)
      {
        s = Pub.GetResText(formCode, i.ToString("Dev00"), "");
        if (s == "") continue;
        cType = new TCommonType(i.ToString(), i.ToString(), s);
        cbbMacType.Items.Add(cType);
      }
      cbbMacType.SelectedIndex = 0;
      RadioButton_Click(null, null);
      if (SystemInfo.IsBigMacAdd)
      {
        txtMacSN.MaxLength = 5;
        txtMacSN.Text = SystemInfo.MaxSN603FindEx.ToString();
      }
    }

    public frmSyncTime()
    {
      InitializeComponent();
    }

    private void RadioButton_Click(object sender, EventArgs e)
    {
      pnlComm.Enabled = rbComm.Checked;
      pnlLAN.Enabled = rbLAN.Checked;
      pnlWAN.Enabled = rbWAN.Checked;
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
      int MaxSN = SystemInfo.IsBigMacAdd ? SystemInfo.MaxSN603FindEx : SystemInfo.MaxSN603Find;
      if ((txtMacSN.Text == "") || !Pub.IsNumeric(txtMacSN.Text))
      {
        txtMacSN.Focus();
        Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorMacSN603", ""), 1, MaxSN));
        return false;
      }
      MacSN = Convert.ToInt32(txtMacSN.Text);
      if ((MacSN < 1) || (MacSN > MaxSN))
      {
        txtMacSN.Focus();
        Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "ErrorMacSN603", ""), 1, MaxSN));
        return false;
      }
      if (cbbMacType.SelectedIndex == -1)
      {
        cbbMacType.Focus();
        ShowErrorSelectCorrect(lblMacType.Text);
        return false;
      }
      MacType = ((TCommonType)cbbMacType.Items[cbbMacType.SelectedIndex]).id;
      MacConnType = MacConnTypeString.USB;
      MacIPAddress = "";
      MacPort = "";
      MacConnPWD = "";
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
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorMacIP", ""));
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
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorMacPort", ""));
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
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorMacIP", ""));
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
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorMacPort", ""));
          return false;
        }
        if (MacPhysicsAddress == "")
        {
          txtWANAddress.Focus();
          Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorMacAddress", ""));
          return false;
        }
        if (!Pub.CheckTextMaxLength(lblWANAddress.Text, MacIPAddress, txtWANAddress.MaxLength))
        {
          txtWANAddress.Focus();
          return false;
        }
      }
      return true;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      DateTime dt = new DateTime();
      if (!db.GetServerDate(ref dt)) return;
      if (!CheckValue()) return;
      byte byt = 0;
      byte.TryParse(MacType, out byt);
      if (byt >= 32) byt = Convert.ToByte(byt - 30);
      byte IsBigMac = SystemInfo.IsBigMacAdd ? (byte)1 : (byte)0;
      QHKS.TConnInfo connInfo = Pub.ValueToConnInfo(IsBigMac, MacSN, byt, MacConnType, MacIPAddress, MacPort,
        MacConnPWD, MacPhysicsAddress);
      DeviceObject.objKS.Init(ref connInfo);
      this.Enabled = false;
      bool ret = DeviceObject.objKS.PubTimeSet(dt);
      string msg = btnOk.Text + "\r\n\r\n" + DeviceObject.objKS.ErrMsg;
      if (ret)
        Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
      else
        Pub.MessageBoxShow(msg);
      this.Enabled = true;
    }
  }
}