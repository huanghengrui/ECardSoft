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
    public partial class frmNewAccount : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "NewAccount";
            base.InitForm();
            RadioButton_Click(null, null);
            txtAccName.Text = "ECard" + DateTime.Now.ToString(SystemInfo.YMFormatDB);
            txtDBName.Text = txtAccName.Text;
            txtBak.Text = db.GetDatabasePath().ToString() + SystemInfo.DefaultDBBak;
            txtPath.Text = db.GetDatabasePath().ToString();
        }

        public frmNewAccount()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            txtDBName.Enabled = rbNew.Checked || rbBak.Checked || rbMDF.Checked;
            cbbDBName.Enabled = rbOld.Checked;
            Label3.Enabled = rbBak.Checked;
            txtBak.Enabled = Label3.Enabled;
            btnDBName.Enabled = Label3.Enabled;
            Label3.Visible = Label3.Enabled;
            txtBak.Visible = Label3.Enabled;
            btnDBName.Visible = Label3.Enabled;
            Label4.Visible = Label3.Enabled || rbNew.Checked;
            Label4.Enabled = Label4.Visible;
            txtPath.Enabled = Label4.Enabled;
            txtPath.Visible = Label4.Enabled;
            btnDBPath.Enabled = Label4.Enabled;
            btnDBPath.Visible = Label4.Enabled;
            txtDBName.Visible = txtDBName.Enabled;
            cbbDBName.Visible = cbbDBName.Enabled;
            lblMDF.Visible = rbMDF.Checked;
            txtMDF.Visible = rbMDF.Checked;
            btnMDF.Visible = rbMDF.Checked;
            btnMDF.Enabled = rbMDF.Checked;
            if (rbOld.Checked)
            {
                cbbDBName.Items.Clear();
                DataTableReader dr = null;
                try
                {
                    if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                    switch (SystemInfo.DBType)
                    {
                        case 1:
                        case 2:
                            string sql = "SELECT Name FROM sysdatabases ORDER BY name";
                            dr = db.GetDataReader(sql);
                            break;
                    }
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            cbbDBName.Items.Add(dr[0].ToString());
                        }
                        dr.Close();
                    }
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }
                if (cbbDBName.Items.Count > 0) cbbDBName.SelectedIndex = 0;
            }
        }

        private void btnDBName_Click(object sender, EventArgs e)
        {
            string BakFile = txtBak.Text;

            BakFile = Pub.SelectDBPath(false, BakFile);
            if (BakFile != "") txtBak.Text = BakFile;
        }

        private void btnDBPath_Click(object sender, EventArgs e)
        {
            string DBPath = txtPath.Text;

            DBPath = Pub.SelectDBPath(true, DBPath);
            if (DBPath != "") txtPath.Text = DBPath;
        }

        private void btnMDF_Click(object sender, EventArgs e)
        {
            string MdfFile = txtMDF.Text;

            MdfFile = Pub.SelectDBPath(false, MdfFile);
            if (MdfFile != "")
            {
                txtMDF.Text = MdfFile;
                FileInfo fi = new FileInfo(MdfFile);
                txtDBName.Text = fi.Name.Split('.')[0].Trim();
            }
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            string AccName = txtAccName.Text.Trim();
            string DBName = "";
            string FileName = txtBak.Text;
            string DBPath = txtPath.Text;
            string msg = string.Format(Pub.GetResText(formCode, "Msg001", ""), AccName);
            bool b;
            bool IsOk = false;
            DataTableReader dr = null;
            DBName = rbNew.Checked || rbBak.Checked || rbMDF.Checked ? txtDBName.Text.Trim() : cbbDBName.Text;
            if (AccName == "")
            {
                txtAccName.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorAccountNameEmpty", ""));
                return;
            }
            if (DBName == "")
            {
                if (rbNew.Checked) txtDBName.Focus(); else cbbDBName.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBNameEmpty", ""));
                return;
            }
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "105", AccName }));
                b = dr.Read();
                dr.Close();
                if (b)
                {
                    txtAccName.Focus();
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorAccountNameExists", ""));
                    return;
                }
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "106", DBName }));
                b = dr.Read();
                dr.Close();
                if (rbNew.Checked)
                {
                    if (b)
                    {
                        txtDBName.Focus();
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBNameExists", ""));
                        return;
                    }
                    if (DBPath == "")
                    {
                        btnDBPath.Focus();
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBPathEmpty", ""));
                        return;
                    }
                    Pub.ShowMessageForm(msg);
                    if (!db.CreateDatabase(DBPath, DBName))
                        db.DeleteDatabase(DBName, true);
                    else
                    {
                        IsOk = true;
                        DateTime dt = new DateTime();
                        Database dbEx = new Database(GetConnStr(DBName));
                        try
                        {
                            dbEx.Open();
                            IsOk = dbEx.UpdateDatabase(this.Text, new DateTime(2000, 1, 1));
                            dbEx.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "5002" }));
                            dbEx.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "5003" }));
                            if (IsOk) IsOk = dbEx.UpdateDatabasesLang();
                            if (IsOk) IsOk = dbEx.UpdateDatabase(this.Text, new DateTime(2000, 1, 1));
                            if (IsOk)
                            {
                                dr = dbEx.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "2" }));
                                if (dr.Read())
                                {
                                    dt = Convert.ToDateTime(dr["DbDate"]);
                                    dbEx.UpdateDatabase(this.Text, dt);
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
                            dbEx = null;
                        }
                        if (!IsOk) db.DeleteDatabase(DBName, true);
                    }
                }
                else if (rbBak.Checked)
                {
                    if (b)
                    {
                        txtDBName.Focus();
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBNameExists", ""));
                        return;
                    }
                    if (FileName == "")
                    {
                        btnDBName.Focus();
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBFileEmpty", ""));
                        return;
                    }
                    if (DBPath == "")
                    {
                        btnDBPath.Focus();
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBPathEmpty", ""));
                        return;
                    }
                    Pub.ShowMessageForm(msg);
                    if (db.AttachDB(DBPath, DBName) != "")
                    {
                        if (!db.CreateDatabase(DBPath, DBName))
                            db.DeleteDatabase(DBName, true);
                        else if (!db.RestoreDatabase(DBName, FileName))
                            db.DeleteDatabase(DBName, true);
                        else
                        {
                            IsOk = true;
                            string fn = FileName.Substring(FileName.LastIndexOf("\\") + 1).ToLower();
                            Database dbEx = new Database(GetConnStr(DBName));
                            try
                            {
                                dbEx.Open();
                                if (fn == SystemInfo.DefaultDBBak.ToLower())
                                {
                                    IsOk = dbEx.UpdateDatabasesLang();
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
                }
                else
                {
                    if (rbOld.Checked && !b)
                    {
                        cbbDBName.Focus();
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBNameNotExists", ""));
                        return;
                    }
                    if (rbMDF.Checked && ((SystemInfo.DBType == 1) || (SystemInfo.DBType == 2)))
                    {
                        string MDFFile = txtMDF.Text.Trim();
                        if (MDFFile == "")
                        {
                            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                            return;
                        }
                        string LDFFile = MDFFile.Replace(".mdf", ".ldf");
                        string SqlStr = "";
                        if (db.DBFileExists(LDFFile))
                            SqlStr = "EXEC sp_attach_db @dbname=N'" + DBName + "',@filename1=N'" + MDFFile + "',@filename2=N'" + LDFFile + "'";
                        else
                            SqlStr = "EXEC sp_attach_single_file_db @dbname='" + DBName + "',@physname='" + MDFFile + "'";
                        db.ExecSQL(SqlStr);
                    }
                    Pub.ShowMessageForm(msg);
                    IsOk = true;
                }
                if (IsOk)
                {
                    string sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "801", AccName, DBName, DBPath + DBName });
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
                if (dr != null) dr.Close();
                dr = null;
                Pub.FreeMessageForm();
            }
            if (IsOk)
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Msg002", ""), AccName), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}