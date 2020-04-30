using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmRSDepartAdd : frmBaseDialog
    {
        private bool IsAdd = false;
        private string ParentDepartGUID = "";
        private string ParentDepartInfo = "";

        protected override void InitForm()
        {
            formCode = "RSDepartAdd";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            txtParent.Text = ParentDepartInfo;
            LoadData();
            if (ParentDepartGUID == "")
            {
                txtID.ReadOnly = true;
                txtID.Enabled = false;
            }
            label1.ForeColor = Color.Red;
            label2.ForeColor = Color.Red;
            if (ParentDepartGUID == "")
            {
                label4.Visible = false;
                txtParent.Enabled = false;
                txtParent.Visible = false;
            }
            btnParentDepart.Enabled = !IsAdd && (ParentDepartGUID != "");
            btnParentDepart.Visible = btnParentDepart.Enabled;
        }

        public frmRSDepartAdd(string title, bool AddData, string CurrentTool, string GUID,
          string ParentDepartSysID, string ParentDepart)
        {
            Title = title;
            IsAdd = AddData;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            ParentDepartGUID = ParentDepartSysID;
            ParentDepartInfo = ParentDepart;
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
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "0", ParentDepartGUID }));
                    int MaxID = 1;
                    if (dr.Read()) MaxID = Convert.ToInt32(dr[0]);
                    dr.Close();
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "1", ParentDepartGUID }));
                    string ID = "";
                    if (dr.Read()) ID = dr["DepartID"].ToString();
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
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "1", SysID }));
                    if (dr.Read())
                    {
                        txtID.Text = dr["DepartID"].ToString();
                        txtName.Text = dr["DepartName"].ToString();
                        txtDesc.Text = dr["DepartMemo"].ToString();
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

        private void btnParentDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart(false);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string s = frm.DepartSysID;
                string s1 = frm.DepartID;
                string s2 = frm.DepartName;
                if (s == SysID)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                    return;
                }
                string s3 = db.GetDepartChildSysIDBySysID(SysID);
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
                ParentDepartGUID = s;
                ParentDepartInfo = "[" + s1 + "]" + s2;
                txtParent.Text = ParentDepartInfo;
            }
          
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text.Trim();
            string Name = txtName.Text.Trim();
            string Desc = txtDesc.Text.Trim();
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
            if (!Pub.CheckTextMaxLength(label3.Text, Desc, txtDesc.MaxLength))
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
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "2", ID }));
                    if (dr.Read())
                    {
                        txtID.Focus();
                        ShowErrorCannotRepeated(label1.Text);
                    }
                    else
                    {
                        sql = Pub.GetSQL(DBCode.DB_001002, new string[] { "6", ID, Name, ParentDepartGUID, Desc });
                        db.ExecSQL(sql);
                        IsOk = true;
                    }
                }
                else
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "5", SysID, ID }));
                    if (dr.Read())
                    {
                        txtID.Focus();
                        ShowErrorCannotRepeated(label1.Text);
                    }
                    else
                    {
                        sql = Pub.GetSQL(DBCode.DB_001002, new string[] { "7", ID, Name, ParentDepartGUID, Desc, SysID });
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