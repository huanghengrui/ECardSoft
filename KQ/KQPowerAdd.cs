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
    public partial class frmKQPowerAdd : frmBaseDialog
    {
        private string otherCoin = "";
        protected override void InitForm()
        {
            formCode = "KQPowerAdd";
            CreateCardGridView(cardGrid);
            cardGrid.Columns[1].Visible = false;
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            toolTip.SetToolTip(txtQuickSearch, Pub.GetResText(formCode, "lblQuickSearchToolTip", ""));
            txtEmpName.Enabled = false;
            txtDepart.Enabled = false;
            LoadData();
            KeyPreview = true;
            btnSelectStartDate.Text = "...";
            btnSelectEndDate.Text = "...";
            HasAbnormal = true;
            otherCoin = Pub.GetSQL(DBCode.DB_002001, new string[] { "205" });
        }

        public frmKQPowerAdd(string title, string CurrentTool)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            InitializeComponent();
        }

        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp(otherCoin);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmpNo.Text = frm.EmpNo;
                txtEmpName.Text = frm.EmpName;
                txtEmpNo_Leave(null, null);
            }
        }

        private void LoadData()
        {
            cbbSun.Items.Clear();
            cbbMon.Items.Clear();
            cbbTue.Items.Clear();
            cbbWed.Items.Clear();
            cbbThu.Items.Clear();
            cbbFri.Items.Clear();
            cbbSat.Items.Clear();
            cbbSun.Items.Add("0");
            cbbMon.Items.Add("0");
            cbbTue.Items.Add("0");
            cbbWed.Items.Add("0");
            cbbThu.Items.Add("0");
            cbbFri.Items.Add("0");
            cbbSat.Items.Add("0");
            DataTableReader dr = null;
            TIDAndName idn;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "3000" }));
                while (dr.Read())
                {
                    idn = new TIDAndName(dr["PassTimeID"].ToString(), "[" + dr["PassTimeID"].ToString() + "]" +
                      dr["PassTimeName"].ToString());
                    cbbSun.Items.Add(idn);
                    cbbMon.Items.Add(idn);
                    cbbTue.Items.Add(idn);
                    cbbWed.Items.Add(idn);
                    cbbThu.Items.Add(idn);
                    cbbFri.Items.Add(idn);
                    cbbSat.Items.Add(idn);
                }
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "2000" }));
                int rowindex = 0;
                while (dr.Read())
                {
                    macGrid.Rows.Add();
                    macGrid[0, rowindex].Value = true;
                    macGrid[1, rowindex].Value = dr["MacSN"].ToString();
                    rowindex++;
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
            int index = 0;
            if (cbbFri.Items.Count > 0)
                index = 1;

            cbbSun.SelectedIndex = index;
            cbbMon.SelectedIndex = index;
            cbbTue.SelectedIndex = index;
            cbbWed.SelectedIndex = index;
            cbbThu.SelectedIndex = index;
            cbbFri.SelectedIndex = index;
            cbbSat.SelectedIndex = index;
        }

        private void txtEmpNo_Leave(object sender, EventArgs e)
        {
            txtEmpNo.Tag = "";
            txtEmpName.Text = "";
            txtDepart.Text = "";
            if (txtEmpNo.Text.Trim() != "")
            {
                string EmpSysID = "";
                string EmpName = "";
                string DepartID = "";
                string DepartName = "";
                int EnrollCount = 0;
                if (db.GetEmpInfo(txtEmpNo.Text.Trim(), ref EmpSysID, ref EmpName, ref DepartID, ref DepartName, ref EnrollCount))
                {
                    if (EnrollCount > 0)
                    {
                        txtEmpNo.Tag = EmpSysID;
                        txtEmpName.Text = EmpName;
                        txtDepart.Text = "[" + DepartID + "]" + DepartName;
                    }
                    else
                    {

                    }
                }
                else
                {
                    txtEmpNo.Text = "";
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorEmpNotExists", ""));
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cardGrid.DataSource = null;
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalEmp(btnQuickSearch.Text, otherCoin, cardGrid);
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalEmp(otherCoin, txtQuickSearch, e, cardGrid);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtEmpNo.Text.Trim() == "")
            {
                txtEmpNo.Focus();
                ShowErrorEnterCorrect(label2.Text);
                return;
            }
            if (cbbSun.SelectedIndex == -1)
            {
                cbbSun.Focus();
                ShowErrorSelectCorrect(label3.Text);
                return;
            }
            if (cbbMon.SelectedIndex == -1)
            {
                cbbMon.Focus();
                ShowErrorSelectCorrect(label5.Text);
                return;
            }
            if (cbbTue.SelectedIndex == -1)
            {
                cbbTue.Focus();
                ShowErrorSelectCorrect(label6.Text);
                return;
            }
            if (cbbWed.SelectedIndex == -1)
            {
                cbbWed.Focus();
                ShowErrorSelectCorrect(label7.Text);
                return;
            }
            string EmpSysID = txtEmpNo.Tag.ToString();
            string SunID = cbbSun.Text;
            string MonID = cbbMon.Text;
            string TueID = cbbTue.Text;
            string WedID = cbbWed.Text;
            string ThuID = cbbThu.Text;
            string FriID = cbbFri.Text;
            string SatID = cbbSat.Text;
            if (cbbSun.SelectedIndex > 0) SunID = ((TIDAndName)cbbSun.Items[cbbSun.SelectedIndex]).id;
            if (cbbMon.SelectedIndex > 0) MonID = ((TIDAndName)cbbMon.Items[cbbMon.SelectedIndex]).id;
            if (cbbTue.SelectedIndex > 0) TueID = ((TIDAndName)cbbTue.Items[cbbTue.SelectedIndex]).id;
            if (cbbWed.SelectedIndex > 0) WedID = ((TIDAndName)cbbWed.Items[cbbWed.SelectedIndex]).id;
            if (cbbThu.SelectedIndex > 0) ThuID = ((TIDAndName)cbbThu.Items[cbbThu.SelectedIndex]).id;
            if (cbbFri.SelectedIndex > 0) FriID = ((TIDAndName)cbbSun.Items[cbbFri.SelectedIndex]).id;
            if (cbbSat.SelectedIndex > 0) SatID = ((TIDAndName)cbbSun.Items[cbbSat.SelectedIndex]).id;
            string StartDate = "NULL";
            string EndDate = "NULL";
            DateTime dt;
            if (DateTime.TryParse(txtStartDate.Text, out dt)) StartDate = "'" + dt.ToString(SystemInfo.SQLDateFMT) + "'";
            if (DateTime.TryParse(txtEndDate.Text, out dt)) EndDate = "'" + dt.ToString(SystemInfo.SQLDateFMT) + "'";
            List<string> macList = new List<string>();
            for (int i = 0; i < macGrid.RowCount; i++)
            {
                if (Pub.ValueToBool(macGrid[0, i].EditedFormattedValue)) macList.Add(macGrid[1, i].Value.ToString());
            }
            if (macList.Count == 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectMacOprt", ""));
                return;
            }
            List<string> sql = new List<string>();
            DataTableReader dr = null;
            bool IsError = false;
            string MacSN;
            try
            {
                for (int i = 0; i < macList.Count; i++)
                {
                    MacSN = macList[i];
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "4003", MacSN, EmpSysID }));
                    if (dr.Read())
                        sql.Add(Pub.GetSQL(DBCode.DB_002001, new string[] { "4005", MacSN, EmpSysID, SunID, MonID, TueID,
              WedID, ThuID, FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate }));
                    else
                        sql.Add(Pub.GetSQL(DBCode.DB_002001, new string[] { "4004", MacSN, EmpSysID, SunID, MonID, TueID,
              WedID, ThuID, FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate }));
                    dr.Close();
                    if (cardGrid.DataSource != null)
                    {
                        DataTable dtGrid = (DataTable)cardGrid.DataSource;
                        string Emp_SysID;
                        for (int j = 0; j < dtGrid.Rows.Count; j++)
                        {
                            Emp_SysID = dtGrid.Rows[j]["EmpSysID"].ToString();
                            if (Emp_SysID == EmpSysID) continue;
                            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "4003", MacSN, Emp_SysID }));
                            if (dr.Read())
                                sql.Add(Pub.GetSQL(DBCode.DB_002001, new string[] { "4005", MacSN, Emp_SysID, SunID, MonID, TueID,
                  WedID, ThuID, FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate }));
                            else
                                sql.Add(Pub.GetSQL(DBCode.DB_002001, new string[] { "4004", MacSN, Emp_SysID, SunID, MonID, TueID,
                  WedID, ThuID, FriID, SatID, OprtInfo.OprtNo, StartDate, EndDate }));
                            dr.Close();
                        }
                    }
                }
            }
            catch (Exception E)
            {
                IsError = true;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsError) return;
            if (db.ExecSQL(sql) != 0) return;
            db.WriteSYLog(this.Text, CurrentOprt, sql);
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cardGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            lblMsg.Text = string.Format(Pub.GetResText(formCode, "MsgSelectNo", ""), cardGrid.Rows.Count);
        }

        private void btnSelectStartDate_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            DateTime.TryParse(txtStartDate.Text, out d);
            if (Pub.GetSelectDate(false, ref d)) txtStartDate.Text = d.ToShortDateString();
        }

        private void btnSelectEndDate_Click(object sender, EventArgs e)
        {
            DateTime d = new DateTime();
            DateTime.TryParse(txtEndDate.Text, out d);
            if (Pub.GetSelectDate(false, ref d)) txtEndDate.Text = d.ToShortDateString();
        }
    }
}