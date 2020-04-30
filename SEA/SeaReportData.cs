using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ECard78
{
    public partial class frmSeaReportData : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "SeaReportData";
            ReportFile = "SeaReportData";
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now.Date;
        }

        public frmSeaReportData()
        {
            InitializeComponent();
        }

        protected override void ExecItemRefresh()
        {
            picPhoto.BackgroundImage = null;
            picData.BackgroundImage = null;
            string EmpTag = "0";
            string EmpNo = "";
            string DepartTag = "0";
            string DepartID = "";
            string DepartList = "";
            if ((txtEmp.Text.Trim() != "") && (txtEmp.Tag != null))
            {
                EmpNo = txtEmp.Tag.ToString();
                EmpTag = "1";
            }
            else if (txtEmp.Text.Trim() != "")
            {
                EmpNo = txtEmp.Text.Trim();
            }
            if ((txtDepart.Text.Trim() != "") && (txtDepart.Tag != null))
            {
                DepartID = txtDepart.Tag.ToString();
                DepartTag = "1";
            }
            else if (txtDepart.Text.Trim() != "")
            {
                DepartID = txtDepart.Text.Trim();
            }
            if (DepartTag == "1")
            {
                if (DepartID != "") DepartList = db.GetDepartChildID(DepartID);
                if (DepartList == "") DepartList = "''";
            }
            QuerySQL = Pub.GetSQL(DBCode.DB_006001, new string[] { "14", EmpTag, EmpNo, DepartTag, DepartID, DepartList,
        dtpStart.Value.ToString(SystemInfo.SQLDateFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateFMT), OprtInfo.DepartPower });
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
            
        }

        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmp.Text = frm.EmpName;
                txtEmp.Tag = frm.EmpNo;
            }
            
        }

        private void btnSelectDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDepart.Text = frm.DepartName;
                txtDepart.Tag = frm.DepartID;
            }
           
        }

        private void txtEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEmp.Tag = null;
        }

        private void txtDepart_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtDepart.Tag = null;
        }

        private void dispView_SelectionCellChange(object sender, AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEvent e)
        {
            picPhoto.BackgroundImage = null;
            picData.BackgroundImage = null;
            DataTableReader dr = null;
            string EmpSysID = "";
            try
            {
                if (db.GetEmpSysID(Report.FieldByName("EmpNo").AsString, ref EmpSysID))
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "104", EmpSysID }));
                    if (dr.Read())
                    {
                        if (dr["EmpPhotoImage"].ToString() != "")
                        {
                            byte[] buff = (byte[])(dr["EmpPhotoImage"]);
                            if (buff.Length > 0)
                            {
                                MemoryStream ms = new MemoryStream(buff);
                                picPhoto.BackgroundImage = Image.FromStream(ms);
                                ms.Close();
                            }
                        }
                    }
                    dr.Close();
                }
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_006001, new string[] { "15", Report.FieldByName("GUID").AsString }));
                if (dr.Read())
                {
                    if (dr["Photo"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["Photo"]);
                        if (buff.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(buff);
                            picData.BackgroundImage = Image.FromStream(ms);
                            ms.Close();
                        }
                    }
                }

            }
            catch
            {
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
        }
    }
}