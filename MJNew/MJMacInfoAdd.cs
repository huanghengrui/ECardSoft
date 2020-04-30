using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacInfoAdd : frmBaseDialog
  {
    private string MacSN = "";
    private byte MacDoorType = 0;
    private string MacConnType = "";
    private string MacIPAddress = "";
    private string MacPort = "";
    private string MacConnPWD = "";
    private string MacDesc = "";

    protected override void InitForm()
    {
      formCode = "MJMacInfoAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      lblMacSN.ForeColor = Color.Red;
      lblCommPort.ForeColor = Color.Red;
      lblLANIP.ForeColor = Color.Red;
      lblLANPort.ForeColor = Color.Red;
      SetTextboxNumber(txtMacSN);
      SetTextboxNumber(txtLANPort);
      Pub.InitCommList(cbbCommPort);
      LoadData();
      RadioButton_Click(null, null);
    }

    public frmMJMacInfoAdd(string title, string CurrentTool, string GUID)
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
        if (SysID != "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "1005", SysID }));
          if (dr.Read())
          {
            txtMacSN.Text = dr["MacSN"].ToString();
            switch (dr["MacConnType"].ToString())
            {
              case MacConnTypeString.Comm:
                rbComm.Checked = true;
                cbbCommPort.Text = dr["MacPort"].ToString();
                break;
              case MacConnTypeString.LAN:
                rbLAN.Checked = true;
                txtLANIP.Text = dr["MacIpAddress"].ToString();
                txtLANPort.Text = dr["MacPort"].ToString();
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
      }
      else
      {
        cbbCommPort.SelectedIndex = -1;
      }
      if (rbLAN.Checked)
      {
        txtLANPort.Text = SystemInfo.LAN80XPort.ToString();
      }
      else
      {
        txtLANPort.Text = "";
      }
    }

    private bool CheckValue()
    {
      if (!Pub.CheckTextMaxLength(lblMacSN.Text, txtMacSN.Text, txtMacSN.MaxLength))
      {
        txtMacSN.Focus();
        return false;
      }
      if ((txtMacSN.Text == "") || !Pub.IsNumeric(txtMacSN.Text))
      {
        txtMacSN.Focus();
        ShowErrorEnterCorrect(lblMacSN.Text);
        return false;
      }
      MacSN = txtMacSN.Text.Trim();
      if (MacSN.Length != 7)
      {
        txtMacSN.Focus();
        ShowErrorEnterCorrect(lblMacSN.Text);
        return false;
      }
      MacDoorType = Convert.ToByte(MacSN.Substring(1, 1));
      if ((MacDoorType != 1) && (MacDoorType != 2) && (MacDoorType != 4))
      {
        txtMacSN.Focus();
        ShowErrorEnterCorrect(lblMacSN.Text);
        return false;
      }
      MacConnType = MacConnTypeString.USB;
      MacIPAddress = "";
      MacPort = "";
      MacConnPWD = "";
      MacDesc = "";
      if (rbComm.Checked)
      {
        MacConnType = MacConnTypeString.Comm;
        MacPort = cbbCommPort.Text;
        MacConnPWD = "19200";
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
      this.Enabled = false;
      DeviceObject.objMJNew.NewDevice(Convert.ToUInt32(MacSN), MacConnType, MacIPAddress, MacPort);
      bool ret = DeviceObject.objMJNew.IsOnline();
      string msg = ret ? Pub.GetResText("", "MsgSuccess", "") : Pub.GetResText("", "MsgFailure", "");
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
      string MacSysID = SysID;
      if (!CheckValue()) return;
      try
      {
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "1004", MacSN }));
          if (dr.Read())
          {
            txtMacSN.Focus();
            ShowErrorCannotRepeated(lblMacSN.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "1", MacSN, MacDoorType.ToString(), MacConnType, 
              MacIPAddress, MacPort, MacConnPWD, MacDesc, SystemInfo.CardProtocol.ToString() });
            db.ExecSQL(sql);
            dr.Close();
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "1004", MacSN }));
            if (dr.Read())
            {
              MacSysID = dr["MacSysID"].ToString();
              IsOk = true;
            }
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "1006", SysID, MacSN }));
          if (dr.Read())
          {
            txtMacSN.Focus();
            ShowErrorCannotRepeated(lblMacSN.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "2", MacSN, MacDoorType.ToString(), MacConnType, 
              MacIPAddress, MacPort, MacConnPWD, MacDesc, SystemInfo.CardProtocol.ToString(), SysID });
            db.ExecSQL(sql);
            IsOk = true;
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
      if (IsOk)
      {
        db.WriteSYLog(this.Text, CurrentOprt, sql);
        //Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
        frmMJMacInfoAddNext frm = new frmMJMacInfoAddNext(Title, CurrentOprt, MacSysID);
        frm.ShowDialog();
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}