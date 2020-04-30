using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmPubDataIn : frmBaseForm
    {
        private string Title = "";
        private bool IsShowDepart = false;
        private bool IsShowCount = false;
        private string[] ImpFieldList;
        private int state = 0;
        private string RecordCountString = "";
        private string RecordIndexString = "";
        private string RecordFactString = "";
        private DataTable dtIn = null;
        private bool IsInitImportField = true;
        private string TableName = "";
        private ProcessImportData prcImportData = null;
        private bool IsImporting = false;

        public delegate bool ProcessImportData(DataRow row, List<string> sys, List<string> src, string DepartUpSysID,
          ref string ErrorMsg, ref double Sum);

        protected override void InitForm()
        {
            formCode = "PubDataIn";
            base.InitForm();
            this.Text = this.Text + "[" + Title + "]";
            RecordCountString = label7.Text;
            RecordIndexString = label8.Text;
            RecordFactString = label9.Text;
            label6.ForeColor = Color.Blue;
            btnSelectDepart.Text = "...";
            RefreshForm();
            lblPic.Visible = IsShowDepart;
        }

        public frmPubDataIn(string title, bool ShowDepart, bool ShowCount, string[] ImportFieldList, ProcessImportData ImportData)
        {
            Title = title;
            IsShowDepart = ShowDepart;
            IsShowCount = ShowCount;
            ImpFieldList = ImportFieldList;
            prcImportData = ImportData;
            InitializeComponent();
        }

        private void frmPubDataIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dtIn != null) dtIn.Reset();
        }

        private void frmPubDataIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsImporting)
            {
                IsImporting = false;
                e.Cancel = true;
            }
        }

        private void btnFileName_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            cbbTable.Items.Clear();
            txtFileName.Text = dlgOpen.FileName;
            string ext = Pub.GetFileNameExt(dlgOpen.FileName).ToLower();
            string ConnStr = "Provider={0};Data Source=\"" + txtFileName.Text + "\";Extended properties='Excel {1};HDR=YES'";
            if (ext == "xlsx")
                ConnStr = string.Format(ConnStr, "Microsoft.Ace.OleDb.12.0", "12.0 Xml");
            else
                ConnStr = string.Format(ConnStr, "Microsoft.Jet.OLEDB.4.0", "8.0");
            try
            {
                db.Open(255, ConnStr);
                DataTable dt = db.GetDataTableList();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbbTable.Items.Add(dt.Rows[i]["TABLE_NAME"].ToString());
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (cbbTable.Items.Count > 0) cbbTable.SelectedIndex = 0;
            
        }

        private void cbbCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTableReader dr = null;
            double d = 0;
            try
            {
                dr = db.GetDataReader("SELECT SUM([" + cbbCount.Text + "]) AS SumEx FROM [" + TableName + "]");
                if (dr.Read())
                {
                    double.TryParse(dr[0].ToString(), out d);
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
            lblMoney.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            state = state - 1;
            if ((state == 0) && (dtIn != null)) dtIn.Reset();
            RefreshForm();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool IsErr = false;
            if (state == 0)
            {
                if (txtFileName.Text == "")
                {
                    txtFileName.Focus();
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                    return;
                }
                if (cbbTable.Text == "")
                {
                    cbbTable.Focus();
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error002", ""));
                    return;
                }
                TableName = cbbTable.Text;
                try
                {
                    dtIn = db.GetDataTable("SELECT * FROM [" + TableName + "]");
                }
                catch (Exception E)
                {
                    IsErr = true;
                    Pub.ShowErrorMsg(E);
                }
            }
            if (IsErr) return;
            state = state + 1;
            RefreshForm();
            string na = "";
            if (state == 1)
            {
                dataGrid.Columns.Clear();
                cbbCount.Items.Clear();
                for (int i = 0; i < dtIn.Columns.Count; i++)
                {
                    na = dtIn.Columns[i].ColumnName;
                    AddColumn(dataGrid, 0, na, false, false, 0, 0);
                    dataGrid.Columns[dataGrid.ColumnCount - 1].HeaderText = na;
                    cbbCount.Items.Add(na);
                }
                if (cbbCount.Items.Count > 0) cbbCount.SelectedIndex = cbbCount.Items.Count - 1;
                dataGrid.DataSource = dtIn;
                dataGrid.Refresh();
                lblCount.Text = RecordCountString + dtIn.Rows.Count.ToString();
                if (cbbCount.Items.Count > 0) cbbCount.SelectedIndex = cbbCount.Items.Count - 1;
            }
            else if (state == 2)
            {
                IsInitImportField = true;
                impGrid.Rows.Clear();
                if (ImpFieldList != null)
                {
                    for (int i = 0; i < ImpFieldList.Length; i++)
                    {
                        impGrid.Rows.Add();
                        impGrid[1, i].Value = Pub.GetResText(formCode, ImpFieldList[i], "");
                        impGrid[2, i].Value = ImpFieldList[i];
                    }
                }
                DataGridViewComboBoxColumn colCombo = (DataGridViewComboBoxColumn)impGrid.Columns[3];
                colCombo.Items.Clear();
                for (int i = 0; i < dtIn.Columns.Count; i++)
                {
                    na = dtIn.Columns[i].ColumnName;
                    colCombo.Items.Add(na);
                    if (i < impGrid.RowCount) impGrid[3, i].Value = na;
                }
                colCombo.ReadOnly = false;
                IsInitImportField = false;
            }
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           
            List<string> sysField = new List<string>();
            List<string> srcField = new List<string>();
            for (int i = 0; i < impGrid.RowCount; i++)
            {
                if ((impGrid[0, i].Value != null) && Pub.ValueToBool(impGrid[0, i].Value))
                {
                    sysField.Add(impGrid[2, i].Value.ToString());
                    srcField.Add(impGrid[3, i].Value.ToString());
                }
            }
            if (sysField.Count == 0)
            {
                impGrid.Focus();
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error003", ""));
                return;
            }
            IsImporting = true;
            DateTime StartTime = DateTime.Now;
            RefreshForm();
            string DepartUpSysID = "";
            if (txtDepart.Tag != null) DepartUpSysID = txtDepart.Tag.ToString();
            if (DepartUpSysID == "") DepartUpSysID = SystemInfo.CommanySysID;
            int RecordCount = dtIn.Rows.Count;
            int RecordFact = 0;
            double SumMoney = 0;
            string FileName = SystemInfo.AppPath + "FormDataIn\\" +
              DateTime.Now.Date.ToString(SystemInfo.DateFormatLog) + ".txt";
            string Msg = string.Format(Pub.GetResText(formCode, "Msg001", ""), Title);
            progBar.Value = 0;
            label7.Text = RecordCountString + RecordCount.ToString();
            label8.Text = RecordIndexString + "0";
            label9.Text = RecordFactString + RecordFact.ToString();
            if (IsShowCount) label9.Text = label9.Text + "(" + SumMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")";
            Pub.WriteTextFile(FileName, Msg);
            string ErrorMsg = "";
            string NoStr = Pub.GetResText(formCode, "Msg003", "");
            Application.DoEvents();
            /*if (dtIn.Rows.Count > 0)
            {
              try
              {
                string s = dtIn.Rows[0]["AllowanceFlag"].ToString();
                DateTime dFlag = new DateTime();
                if (DateTime.TryParse(s, out dFlag))
                {
                  DateTime dt = new DateTime();
                  byte retCheck = db.CheckAllowanceFlag("", dFlag, ref dt);
                  if (retCheck == 1)
                  {
                    Pub.MessageBoxShow(string.Format(Pub.GetResText("SFAllowanceAdd", "Error101", ""), dt.ToShortDateString()));
                    return;
                  }
                  else if (retCheck == 2)
                  {
                    Pub.MessageBoxShow(string.Format(Pub.GetResText("SFAllowanceAdd", "Error102", ""), dt.ToShortDateString()));
                    return;
                  }
                }
              }
              catch
              {
              }
            }*/
            for (int i = 0; i < dtIn.Rows.Count; i++)
            {
                if (!IsImporting) break;
                if (prcImportData(dtIn.Rows[i], sysField, srcField, DepartUpSysID, ref ErrorMsg, ref SumMoney)) RecordFact = RecordFact + 1;
                progBar.Value = (i + 1) * 100 / RecordCount;
                label7.Text = RecordCountString + RecordCount.ToString();
                label8.Text = RecordIndexString + (i + 1).ToString();
                label9.Text = RecordFactString + RecordFact.ToString();
                if (IsShowCount) label9.Text = label9.Text + "(" + SumMoney.ToString(SystemInfo.CurrencySymbol + "0.00") + ")";
                if (ErrorMsg != "")
                {
                    Msg = string.Format(NoStr, i + 1) + ErrorMsg;
                    Pub.WriteTextFile(FileName, Msg);
                }
                Application.DoEvents();
            }
            IsImporting = false;
            RefreshForm();
            Msg = string.Format(Pub.GetResText(formCode, "Msg002", ""), Title, label7.Text, label8.Text, label9.Text);
            string ss = Pub.GetDateDiffTimes(StartTime, DateTime.Now);
            Pub.WriteTextFile(FileName, Msg + "    " + ss);
            Pub.MessageBoxShow(Msg + "\r\n\r\n" + ss, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void impGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 3) && (impGrid.RowCount > 0) && !IsInitImportField)
            {
                impGrid[0, e.RowIndex].Value = true;
            }
        }

        private void RefreshForm()
        {
            tabControl1.TabPages.Clear();
            switch (state)
            {
                case 0:
                    tabControl1.TabPages.Add(tabPage1);
                    break;
                case 1:
                    tabControl1.TabPages.Add(tabPage2);
                    break;
                case 2:
                    tabControl1.TabPages.Add(tabPage3);
                    break;
            }
            lblCount.Enabled = state == 1;
            lblCount.Visible = lblCount.Enabled;
            cbbCount.Enabled = (state == 1) && IsShowCount;
            cbbCount.Visible = cbbCount.Enabled;
            lblMoney.Visible = cbbCount.Enabled;
            txtDepart.Enabled = (state == 2) && IsShowDepart;
            txtDepart.Visible = txtDepart.Enabled;
            btnSelectDepart.Enabled = txtDepart.Enabled;
            btnSelectDepart.Visible = txtDepart.Enabled;
            label10.Visible = txtDepart.Enabled;
            btnPrev.Enabled = state != 0;
            btnNext.Enabled = state != 2;
            btnOk.Enabled = state == 2;
            btnOk.Visible = btnOk.Enabled;
            impGrid.Enabled = (state == 2) && !IsImporting;
            label10.Enabled = label10.Enabled && !IsImporting;
            txtDepart.Enabled = txtDepart.Enabled && !IsImporting;
            btnSelectDepart.Enabled = btnSelectDepart.Enabled && !IsImporting;
            btnPrev.Enabled = btnPrev.Enabled && !IsImporting;
            btnOk.Enabled = btnOk.Enabled && !IsImporting;
            btnCancel.Enabled = btnCancel.Enabled && !IsImporting;
        }

        private void btnSelectDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart(false);
            if (frm.ShowDialog() == DialogResult.OK) txtDepart.Tag = frm.DepartSysID;
        }
    }
}