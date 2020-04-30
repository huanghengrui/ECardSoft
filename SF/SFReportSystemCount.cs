using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFReportSystemCount : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "SFReportSystemCount";
            ReportFile = "SFReportSystemCount";
            IgnoreTagExt = true;
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now.Date;
            RadioButton_Click(null, null);
            cbbCheckDate.Items.Clear();
            DataTableReader dr = null;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004011, new string[] { "60" }));
                while (dr.Read())
                {
                    cbbCheckDate.Items.Add(((DateTime)dr["CheckOutDate"]).ToShortDateString());
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
            if (cbbCheckDate.Items.Count > 0) cbbCheckDate.SelectedIndex = 0;
        }

        public frmSFReportSystemCount()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            dtpStart.Enabled = rbDate.Checked;
            dtpEnd.Enabled = rbDate.Checked;
            cbbCheckDate.Enabled = rbCheckDate.Checked;
        }

        protected override void ExecItemRefresh()
        {
            int flag = 0;
            DateTime tmpDate = new DateTime();
            if (rbDate.Checked)
                flag = 0;
            else if (rbCheckDate.Checked)
            {
                if (cbbCheckDate.SelectedIndex < 0)
                {
                    ShowErrorSelectCorrect(rbCheckDate.Text);
                    return;
                }
                flag = 1;
                DateTime.TryParse(cbbCheckDate.Text, out tmpDate);
            }
            QuerySQL = Pub.GetSQL(DBCode.DB_004011, new string[] { "61", flag.ToString(),
        dtpStart.Value.ToString(SystemInfo.SQLDateFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateFMT),
        tmpDate.ToString(SystemInfo.SQLDateFMT) });
            db.ExecSQL(QuerySQL);
            QuerySQL = Pub.GetSQL(DBCode.DB_004011, new string[] { "62" });
            if (rbDate.Checked)
                SetReportDate(dispView, rbDate.Text + ": " + dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            else
                SetReportDate(dispView, rbCheckDate.Text + ": " + cbbCheckDate.Text);
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
        }
    }
}