using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFAllowanceDownSelect : frmBaseDialog
    {
        private string title = "";
        public int selCount = 0;
        public string selCard = "";

        protected override void InitForm()
        {
            formCode = "SFAllowanceDownSelect";
            AddColumn(cardGrid, 0, "CardSectorNo", false, true, 1, 80);
            AddColumn(cardGrid, 0, "EmpNo", false, true, 1, 80);
            AddColumn(cardGrid, 0, "EmpName", false, true, 1, 80);
            AddColumn(cardGrid, 0, "AllowanceFlag", false, true, 1, 80);
            AddColumn(cardGrid, 0, "AllowanceWayName", false, true, 1, 80);
            AddColumn(cardGrid, 0, "AllowanceAmountUp", false, true, 1, 100);
            AddColumn(cardGrid, 0, "AllowanceAmount", false, true, 1, 100);
            AddColumn(cardGrid, 0, "AllowanceAmountSum", false, true, 1, 100);
            base.InitForm();
            this.Text = title;
            RadioButton_Click(null, null);
        }

        public frmSFAllowanceDownSelect(string Title)
        {
            title = Title;
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = rbEmp.Checked;
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            frmPubSelectEmpList frm = new frmPubSelectEmpList(Title, "");
            frm.IsAllowanceDownSelect = true;
            if (frm.ShowDialog() != DialogResult.OK) return;
            dt = frm.dtData;
            DataTable dtGrid = QuickSearchNormalCardDataTable(cardGrid);
            string EmpNo = "";
            bool IsExists = false;
            DataRow dr = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                EmpNo = dr["EmpNo"].ToString();
                IsExists = false;
                for (int j = 0; j < dtGrid.Rows.Count; j++)
                {
                    if (dtGrid.Rows[j]["EmpNo"].ToString() == EmpNo)
                    {
                        IsExists = true;
                        break;
                    }
                }
                if (!IsExists)
                {
                    dtGrid.Rows.Add(new object[] { dr["CardSectorNo"], EmpNo, dr["EmpName"].ToString(), dr["AllowanceFlag"],
            dr["AllowanceWayName"], dr["AllowanceAmountUp"], dr["AllowanceAmount"], dr["AllowanceAmountSum"],
            dr["AllowanceWay"], dr["CardTypeID"] });
                }
            }
            cardGrid.DataSource = dtGrid;
            if (cardGrid.RowCount > 0)
            {
                cardGrid.Rows[cardGrid.RowCount - 1].Selected = true;
                cardGrid.CurrentCell = cardGrid.Rows[cardGrid.RowCount - 1].Cells[3];
            }
        }

        private DataTable QuickSearchNormalCardDataTable(DataGridView grid)
        {
            DataTable rtn = new DataTable();
            if (grid.DataSource == null)
            {
                rtn.Columns.Add("CardSectorNo", typeof(string));
                rtn.Columns.Add("EmpNo", typeof(string));
                rtn.Columns.Add("EmpName", typeof(string));
                rtn.Columns.Add("AllowanceFlag", typeof(DateTime));
                rtn.Columns.Add("AllowanceWayName", typeof(string));
                rtn.Columns.Add("AllowanceAmountUp", typeof(double));
                rtn.Columns.Add("AllowanceAmount", typeof(double));
                rtn.Columns.Add("AllowanceAmountSum", typeof(double));
                rtn.Columns.Add("AllowanceWay", typeof(byte));
                rtn.Columns.Add("CardTypeID", typeof(byte));
            }
            else
                rtn = (DataTable)grid.DataSource;
            return rtn;
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            DataTable dtGrid = QuickSearchNormalCardDataTable(cardGrid);
            DataTableReader dr = null;
            string EmpNo = "";
            bool IsExists = false;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "100", txtQuickSearch.Text.Trim(), OprtInfo.DepartPower }));
                while (dr.Read())
                {
                    EmpNo = dr["EmpNo"].ToString();
                    IsExists = false;
                    for (int j = 0; j < dtGrid.Rows.Count; j++)
                    {
                        if (dtGrid.Rows[j]["EmpNo"].ToString() == EmpNo)
                        {
                            IsExists = true;
                            break;
                        }
                    }
                    if (!IsExists)
                    {
                        dtGrid.Rows.Add(new object[] { dr["CardSectorNo"], EmpNo, dr["EmpName"].ToString(), dr["AllowanceFlag"],
              dr["AllowanceWayName"], dr["AllowanceAmountUp"], dr["AllowanceAmount"], dr["AllowanceAmountSum"],
              dr["AllowanceWay"], dr["CardTypeID"] });
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
            cardGrid.DataSource = dtGrid;
            if (cardGrid.RowCount > 0)
            {
                cardGrid.Rows[cardGrid.RowCount - 1].Selected = true;
                cardGrid.CurrentCell = cardGrid.Rows[cardGrid.RowCount - 1].Cells[3];
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            selCount = 0;
            selCard = "";
            if (rbEmp.Checked)
            {
                if (cardGrid.RowCount == 0)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                    return;
                }
                DataTable dtEmp = (DataTable)cardGrid.DataSource;
                QHKS.TFeeAllowance Allowance;
                for (int i = 0; i < dtEmp.Rows.Count; i++)
                {
                    Allowance = new QHKS.TFeeAllowance();
                    Allowance.CardID = dtEmp.Rows[i]["CardSectorNo"].ToString();
                    DateTime.TryParse(dtEmp.Rows[i]["AllowanceFlag"].ToString(), out Allowance.Flag);
                    Allowance.Money = 0;
                    double.TryParse(dtEmp.Rows[i]["AllowanceAmountSum"].ToString(), out Allowance.Money);
                    Allowance.Model = 0;
                    byte.TryParse(dtEmp.Rows[i]["AllowanceWay"].ToString(), out Allowance.Model);
                    if (Allowance.Model == 0 || Allowance.Model == 1 || Allowance.Model == 2)
                        Allowance.Model += 1;
                    else
                        continue;
                    Allowance.ChangeCardType = 0;
                    if (SystemInfo.AllowanceCardType) Allowance.ChangeCardType = 1;
                    Allowance.CardType = 0;
                    byte.TryParse(dtEmp.Rows[i]["CardTypeID"].ToString(), out Allowance.CardType);
                    selCard = selCard + Allowance.CardID + ",";
                    DeviceObject.objKS.FeeAllowanceInit(Allowance, selCount == 0);
                    selCount++;
                }
                if (selCard != "") selCard = selCard.Substring(0, selCard.Length - 1);
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}