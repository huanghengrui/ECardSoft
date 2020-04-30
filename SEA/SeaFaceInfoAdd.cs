using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSeaFaceInfoAdd : frmBaseDialog
    {
        private string MacSN = "";
        private string MacIPAddress = "";
        private string MacPort = "";
        private string MacPWD = "";
        private string MacName = "";
        private string MacDesc = "";
        private const int AcPort = 5005;
        private int MacInOut = 0;
        private string MacInOutName = "";

        protected override void InitForm()
        {
            formCode = "SEAFaceInfoAdd";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            lblMacSN.ForeColor = Color.Red;
           
            lblLANIP.ForeColor = Color.Red;
            lblLANPort.ForeColor = Color.Red;
            lbMacName.ForeColor = Color.Red;
            lbMacPWD.ForeColor = Color.Red;
            SetTextboxNumber(txtMacSN);
            SetTextboxNumber(txtLANPort);
            LoadData();
        }

        public frmSeaFaceInfoAdd(string title, string CurrentTool, string GUID)
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
                cbbInOut.Items.AddRange(new object[] { Pub.GetResText(formCode,"LOG_IOMODE_IO",""),
                Pub.GetResText(formCode,"LOG_IOMODE_IN1",""),
                Pub.GetResText(formCode,"LOG_IOMODE_OUT1",""),
                });
                cbbInOut.SelectedIndex = 0;
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                if (SysID == "")
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_006001, new string[] { "2" }));
                    if (dr.Read())
                    {
                        int no = 0;
                        int.TryParse(dr[0].ToString(), out no);
                        if (no > SystemInfo.MaxSNFinger) no = SystemInfo.MaxSNFinger;
                        txtMacSN.Text = no.ToString();
                    }
                    txtLANIP.Text = "192.168.1.100";
                    txtLANPort.Text = "5005";
                    txtMacConnName.Text = "admin";
                   
                }
                else
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_006001, new string[] { "3", SysID }));
                    if (dr.Read())
                    {
                        txtMacSN.Text = dr["MacSN"].ToString();
                        txtLANIP.Text = dr["MacIpAddress"].ToString();
                        txtLANPort.Text = dr["MacPort"].ToString();
                        txtDesc.Text = dr["MacDesc"].ToString();
                        txtMacConnName.Text = dr["MacName"].ToString();
                        txtMacConnPWD.Text = dr["MacPWD"].ToString();
                        cbbInOut.SelectedIndex = Convert.ToInt32(dr["MacInOut"].ToString());
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

        private bool CheckValue()
        {
            if (txtMacSN.Text.Trim() == "")
            {
                txtMacSN.Focus();
                ShowErrorEnterCorrect(lblMacSN.Text);
                return false;
            }
            if(txtMacConnName.Text.Trim() == "")
            {
                txtMacConnName.Focus();
                ShowErrorEnterCorrect(lbMacName.Text);
                return false;
            }
            if (txtMacConnPWD.Text.Trim() == "")
            {
                txtMacConnPWD.Focus();
                ShowErrorEnterCorrect(lbMacPWD.Text);
                return false;
            }
            if (!Pub.IsNumeric(txtMacSN.Text))
            {
                txtMacSN.Focus();
                Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorMacSN603", ""), 1, SystemInfo.MaxSNFinger));
                return false;
            }
            
            MacSN = txtMacSN.Text.Trim();
            MacIPAddress = txtLANIP.Text.Trim();
            MacPort = txtLANPort.Text.Trim();
            MacName = txtMacConnName.Text.Trim();
            MacPWD = txtMacConnPWD.Text.Trim();
            MacInOut = cbbInOut.SelectedIndex;
            MacInOutName = cbbInOut.Text;
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
            TConnInfoSEA conn = Pub.ValueToConnInfoSEA(MacSN,MacIPAddress, MacPort,MacName, MacPWD);
            this.Enabled = false;
            bool ret = false;
            string msg = "";
            //string dtS = "";
            //DateTime dt = new DateTime();
            //DeviceObject.objFK623.InitConn(conn);
            //ret = DeviceObject.objFK623.GetDeviceTime(ref dt);
            //if (ret) dtS = dt.ToString();
            //msg = DeviceObject.objFK623.ErrMsg;
            //if (ret) msg = msg + "\r\n\r\n" + dtS;
            string syncTime = "";
            string url = "http://" + MacIPAddress + "/action/GetSysParam";
            ret = DeviceObject.objFK623.POST_GetResponse(url, MacName, MacPWD, ref syncTime);

            if (ret)
            {
                if (syncTime != "")
                {
                    jsonBody<GetSysParam> answer = JsonConvert.DeserializeObject<jsonBody<GetSysParam>>(syncTime);
                    txtMacSN.Text = answer.info.DeviceID.ToString();
                    msg = Pub.GetResText("", "MsgReadEndData", "");
                    Application.DoEvents();
                }
            }
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
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_006001, new string[] { "4", MacSN }));
                    if (dr.Read())
                    {
                        txtMacSN.Focus();
                        ShowErrorCannotRepeated(lblMacSN.Text);
                    }
                    else
                    {
                        sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "5", MacSN, MacIPAddress,
                            MacPort,MacName, MacPWD,MacInOut.ToString(),MacInOutName, MacDesc });
                        db.ExecSQL(sql);
                        IsOk = true;
                    }
                }
                else
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_006001, new string[] { "6", SysID, MacSN }));
                    if (dr.Read())
                    {
                        txtMacSN.Focus();
                        ShowErrorCannotRepeated(lblMacSN.Text);
                    }
                    else
                    {
                        sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "7", MacSN, MacIPAddress,
                            MacPort,MacName, MacPWD,MacInOut.ToString(),MacInOutName, MacDesc ,SysID });
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