using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using grproLib;

namespace ECard78
{
    public partial class frmRSCardOpterTotal : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "RSCardOpterTotal";
            ReportFile = "RSCardOpterTotal";
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now.Date;
        }

        public frmRSCardOpterTotal()
        {
            InitializeComponent();
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_001004, new string[] { "2", dtpStart.Value.ToString(SystemInfo.SQLDateFMT),
        dtpEnd.Value.ToString(SystemInfo.SQLDateFMT), OprtInfo.DepartPower });
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
           
        }
    }
}