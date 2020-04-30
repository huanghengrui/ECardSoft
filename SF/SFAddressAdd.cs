using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFAddressAdd : frmBaseDialog
    {
        private bool IsAdd = false;
        private string ParentAddressGUID = "";
        private string ParentAddressInfo = "";

        protected override void InitForm()
        {
            formCode = "SFAddressAdd";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            txtParent.Text = ParentAddressInfo;
            LoadData();
            label1.ForeColor = Color.Red;
            label2.ForeColor = Color.Red;
            if (IsAdd)
            {
                btnParentAddress.Enabled = false;
                btnParentAddress.Visible = false;
            }
        }

        public frmSFAddressAdd(string title, bool AddData, string CurrentTool, string GUID,
          string ParentAddressSysID, string ParentAddress)
        {
            Title = title;
            IsAdd = AddData;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            ParentAddressGUID = ParentAddressSysID;
            ParentAddressInfo = ParentAddress;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                if (IsAdd)
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004001, new string[] { "0", ParentAddressGUID }));
                    int MaxID = 1;
                    if (dr.Read()) MaxID = Convert.ToInt32(dr[0]);
                    dr.Close();
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004001, new string[] { "1", ParentAddressGUID }));
                    string ID = "";
                    if (dr.Read()) ID = dr["AddressNO"].ToString();
                    string tmp = "";
                    int size = 2;
                    if (ID.Length <= 3) size = 3;
                    size = size + ID.Length;
                    while (tmp.Length < size)
                    {
                        tmp += "0";
                    }
                    if (tmp.Length > txtID.MaxLength) tmp = tmp.Substring(0, txtID.MaxLength);
                    tmp = MaxID.ToString(tmp);
                    tmp = ID + tmp.Substring(ID.Length);
                    txtID.Text = tmp;
                }
                else
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004001, new string[] { "1", SysID }));
                    if (dr.Read())
                    {
                        txtID.Text = dr["AddressNO"].ToString();
                        txtName.Text = dr["AddressName"].ToString();
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

        private void btnParentAddress_Click(object sender, EventArgs e)
        {
            frmPubSelectAddress frm = new frmPubSelectAddress();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string s = frm.AddressSysID;
                string s1 = frm.AddressID;
                string s2 = frm.AddressName;
                if (s == SysID)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                    return;
                }
                string s3 = db.GetAddressChildSysIDBySysID(SysID);
                if (s3 != "")
                {
                    string[] tmp = s3.Split(',');
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (tmp[i] == "") continue;
                        s3 = tmp[i].Substring(1);
                        s3 = s3.Substring(0, s3.Length - 1);
                        if (s3 == s)
                        {
                            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                            return;
                        }
                    }
                }
                ParentAddressGUID = s;
                ParentAddressInfo = "[" + s1 + "]" + s2;
                txtParent.Text = ParentAddressInfo;
            }
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text.Trim();
            string Name = txtName.Text.Trim();
            if (txtID.Enabled)
            {
                if (ID == "")
                {
                    txtID.Focus();
                    ShowErrorEnterCorrect(label1.Text);
                    return;
                }
                if (!Pub.CheckTextMaxLength(label1.Text, ID, txtID.MaxLength))
                {
                    txtID.Focus();
                    return;
                }
            }
            if (Name == "")
            {
                txtName.Focus();
                ShowErrorEnterCorrect(label2.Text);
                return;
            }
            if (!Pub.CheckTextMaxLength(label2.Text, Name, txtName.MaxLength))
            {
                txtName.Focus();
                return;
            }
            DataTableReader dr = null;
            bool IsOk = false;
            string sql = "";
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                if (SysID == "")
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004001, new string[] { "2", ID }));
                    if (dr.Read())
                    {
                        txtID.Focus();
                        ShowErrorCannotRepeated(label1.Text);
                    }
                    else
                    {
                        sql = Pub.GetSQL(DBCode.DB_004001, new string[] { "6", ID, Name, ParentAddressGUID });
                        db.ExecSQL(sql);
                        IsOk = true;
                    }
                }
                else
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004001, new string[] { "5", SysID, ID }));
                    if (dr.Read())
                    {
                        txtID.Focus();
                        ShowErrorCannotRepeated(label1.Text);
                    }
                    else
                    {
                        sql = Pub.GetSQL(DBCode.DB_004001, new string[] { "7", ID, Name, ParentAddressGUID, SysID });
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
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}