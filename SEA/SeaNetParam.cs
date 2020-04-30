using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSeaNetParam : frmBaseDialog
    {

        protected override void InitForm()
        {
            formCode = "SeaNetParam";
            base.InitForm();
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "");
            SetTextboxNumber(txtWebPort);
            SetTextboxNumber(txtListenPort);
            DataTableReader dr = null;
            string sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "42" });
            try
            {
                dr = db.GetDataReader(sql);
                if (dr.Read())
                {
                    txtIPAddr.Text = dr["IPAddr"].ToString();
                    txtSubmask.Text = dr["Submask"].ToString();
                    txtGateway.Text = dr["Gateway"].ToString();
                    txtListenPort.Text = dr["ListenPort"].ToString();
                    txtWebPort.Text = dr["WebPort"].ToString();
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                dr = null;
            }
         
            if(txtIPAddr.Text=="")
                txtIPAddr.Text = "192.168.1.100";
            if(txtSubmask.Text=="")
                txtSubmask.Text = "255.255.255.0";
            if(txtGateway.Text=="")
                txtGateway.Text = "192.168.1.1";
            if(txtListenPort.Text=="")
                txtListenPort.Text = "5000";
            if(txtWebPort.Text=="")
                txtWebPort.Text = "80";
        }
        public frmSeaNetParam()
        {
            InitializeComponent();
        }

        public bool IsIpAddr(string ipStr)
        {
            bool ret = false;
            IPAddress IP;
            if (IPAddress.TryParse(ipStr, out IP))
            {
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!IsIpAddr(txtIPAddr.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect",""),label1.Text),MessageBoxIcon.Error);
                txtIPAddr.Focus();
                return;
            }
            if (!IsIpAddr(txtSubmask.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), label2.Text), MessageBoxIcon.Error);
                txtSubmask.Focus();
                return;
            }
            if (!IsIpAddr(txtGateway.Text))
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), label3.Text), MessageBoxIcon.Error);
                txtGateway.Focus();
                return;
            }
            if (txtListenPort.Text=="")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), label4.Text), MessageBoxIcon.Error);
                txtSubmask.Focus();
                return;
            }
            if (txtWebPort.Text=="")
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText("", "ErrorEnterCorrect", ""), label5.Text), MessageBoxIcon.Error);
                txtWebPort.Focus();
                return;
            }

            string IPAddr = txtIPAddr.Text;
            string Submask = txtSubmask.Text;
            string Gateway = txtGateway.Text;
            int ListenPort = Convert.ToInt32(txtListenPort.Text);
            int WebPort = Convert.ToInt32(txtWebPort.Text);

            NetParam netParam = new NetParam(IPAddr, Submask, Gateway, ListenPort, WebPort);
            jsonBody<NetParam> jsonBody = new jsonBody<NetParam>("SetNetParam", netParam);
            string jsonString = JsonConvert.SerializeObject(jsonBody);
            frmSeaOprt frm = new frmSeaOprt(this.Text, btnOk.Text, jsonString, 5,null);
            frm.ShowDialog();

            SaveParam();
        }

        private void btnGetNetParam_Click(object sender, EventArgs e)
        {
            string param = "";
            frmSeaOprt frm = new frmSeaOprt(this.Text, btnGetNetParam.Text, param, 6,null);

            if(frm.ShowDialog()==DialogResult.OK)
            {
                param = frm.BodyParameter;
                if(param!="")
                {
                    Pub.MessageBoxShow(btnGetNetParam.Text + Pub.GetResText("", "FK_RUN_SUCCESS", ""),MessageBoxIcon.Information);
                    jsonBody<NetParam> jsonDoorCondition = JsonConvert.DeserializeObject<jsonBody<NetParam>>(param);
                    txtIPAddr.Text = jsonDoorCondition.info.IPAddr;
                    txtSubmask.Text = jsonDoorCondition.info.Submask;
                    txtGateway.Text = jsonDoorCondition.info.Gateway;
                    txtListenPort.Text = jsonDoorCondition.info.ListenPort.ToString();
                    txtWebPort.Text = jsonDoorCondition.info.WebPort.ToString();

                    SaveParam();
                }
                else
                {
                    Pub.MessageBoxShow(btnGetNetParam.Text + Pub.GetResText("", "FK_RUNERR_NON_CARRYOUT", ""), MessageBoxIcon.Information);
                }
            }

           
        }
        private void SaveParam()
        {
            DataTableReader dr = null;
            string sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "42" });
            try
            {
                dr = db.GetDataReader(sql);
                if (dr.Read())
                {
                    string MacSN = dr["MacSN"].ToString();
                    sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "41", MacSN, txtIPAddr.Text, txtSubmask.Text, txtGateway.Text, txtListenPort.Text, txtWebPort.Text });
                }
                else
                {
                    sql = Pub.GetSQL(DBCode.DB_006001, new string[] { "40", "1", txtIPAddr.Text, txtSubmask.Text, txtGateway.Text, txtListenPort.Text, txtWebPort.Text });
                }

                db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                dr = null;
            }
        }
    }
}
