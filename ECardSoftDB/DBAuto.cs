using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ECard78
{
    public partial class frmDBAuto : frmBaseDialog
    {
        public string AccName = "";
        public string DBName = "";

        protected override void InitForm()
        {
            DataTableReader dr = null;
            string time = "";
            string Path = "";
            formCode = "DBAuto";
            base.InitForm();
            this.txtAccName.Text = AccName;
            this.txtDBName.Text = DBName;
            txtPath.Text = db.GetDatabasePath().ToString();
            this.Label5.Visible = (SystemInfo.DBType == 1) || (SystemInfo.DBType == 2);
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "109" }), true);
                db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "110" }), true);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "105", AccName }));
                if (dr.Read())
                {
                    time = dr["PlanTime"].ToString();
                    if (time != "") dtpTime.Value = Convert.ToDateTime(time);
                    Path = dr["PlanPath"].ToString();
                    if (Path != "") txtPath.Text = Path;
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
                db.Close();
            }
        }

        public frmDBAuto()
        {
            InitializeComponent();
        }

        private void btnDBPath_Click(object sender, EventArgs e)
        {
            string DBPath = txtPath.Text;
            DBPath = Pub.SelectDBPath(true, DBPath);
            if (DBPath != "") txtPath.Text = DBPath;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            formCode = "DBAuto";
            string DBPath = txtPath.Text;
            bool IsOk = false;
            if (DBPath == "")
            {
                btnDBPath.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorDBPathEmpty", ""));
                return;
            }
            try
            {
                db.Close();
                db.Open(GetConnStrPlan());
                IsOk = db.MaintenancePlan(DBName, DBPath, dtpTime.Text, Pub.GetResText(formCode, "MsgMaintenancePlan", ""),
                  Pub.GetResText(formCode, "MsgMaintenanceBack", ""));
                db.Close();
                db.Open(SystemInfo.ConnStr);
                db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "111", DBPath, dtpTime.Text, DBName }));
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (IsOk)
            {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Msg001", ""), AccName), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}