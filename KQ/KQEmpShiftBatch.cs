using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmKQEmpShiftBatch : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "KQEmpShiftBatch";
            CreateCardGridView(cardGrid);
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now.Date;
            DataTableReader dr = null;
            TCommonType ctype;
            cbbRule.Items.Clear();
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002004, new string[] { "0", Pub.GetResText(formCode, "ShiftRuleFlag0", ""),
          Pub.GetResText(formCode, "ShiftRuleFlag1", ""), Pub.GetResText(formCode, "ShiftRuleFlag2", "") }));
                while (dr.Read())
                {
                    ctype = new TCommonType(dr["ShiftRuleSysID"].ToString(), "", dr["ShiftRuleName"].ToString(), true);
                    cbbRule.Items.Add(ctype);
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
            if (cbbRule.Items.Count > 0) cbbRule.SelectedIndex = 0;
        }

        public frmKQEmpShiftBatch(string title, string CurrentTool)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            InitializeComponent();
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalEmp(btnQuickSearch.Text, cardGrid);
            
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalEmp(txtQuickSearch, e, cardGrid);
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           
            if (dtpEnd.Value < dtpStart.Value)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                return;
            }
            if (cbbRule.SelectedIndex < 0)
            {
                ShowErrorSelectCorrect(label3.Text);
                return;
            }
            if (cardGrid.RowCount == 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                return;
            }
            string ShiftRuleSysID = ((TCommonType)cbbRule.Items[cbbRule.SelectedIndex]).sysID;
            List<string> sql = new List<string>();
            string EmpSysID = "";
            DataTable dt = null;
            bool IsError = false;
            int days = (int)Pub.DateDiff(DateInterval.Day, dtpStart.Value, dtpEnd.Value);
            int flag = 0;
            int CycDays = 0;
            int row = 0;
            try
            {
                dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_002004, new string[] { "4", ShiftRuleSysID }));
                flag = Convert.ToInt32(dt.Rows[0]["Flag"].ToString());
                CycDays = Convert.ToInt32(dt.Rows[0]["CycDays"].ToString());
                dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_002004, new string[] { "10", ShiftRuleSysID }));
                DataTable dtGrid = (DataTable)cardGrid.DataSource;
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    EmpSysID = dtGrid.Rows[i]["EmpSysID"].ToString();
                    sql.Add(Pub.GetSQL(DBCode.DB_002005, new string[] { "3", EmpSysID,
            dtpStart.Value.ToString(SystemInfo.SQLDateFMT), dtpEnd.Value.ToString(SystemInfo.SQLDateFMT) }));
                    switch (flag)
                    {
                        case 0:
                            row = 1;
                            for (int j = 0; j <= days; j++)
                            {
                                if (row > CycDays) row = 1;
                                sql.Add(Pub.GetSQL(DBCode.DB_002005, new string[] { "2", EmpSysID,
                  dtpStart.Value.AddDays(j).ToString(SystemInfo.SQLDateFMT), dt.Rows[row - 1]["ShiftNo"].ToString() }));
                                row += 1;
                            }
                            break;
                        case 1:
                            for (int j = 0; j <= days; j++)
                            {
                                row = (int)dtpStart.Value.AddDays(j).DayOfWeek;
                                sql.Add(Pub.GetSQL(DBCode.DB_002005, new string[] { "2", EmpSysID,
                  dtpStart.Value.AddDays(j).ToString(SystemInfo.SQLDateFMT), dt.Rows[row]["ShiftNo"].ToString() }));
                            }
                            break;
                        case 2:
                            for (int j = 0; j <= days; j++)
                            {
                                row = dtpStart.Value.AddDays(j).Day;
                                sql.Add(Pub.GetSQL(DBCode.DB_002005, new string[] { "2", EmpSysID,
                  dtpStart.Value.AddDays(j).ToString(SystemInfo.SQLDateFMT), dt.Rows[row - 1]["ShiftNo"].ToString() }));
                            }
                            break;
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
                if (dt != null)
                {
                    dt.Clear();
                    dt.Reset();
                }
            }
            if (IsError) return;
            if (db.ExecSQL(sql) != 0) return;
            db.WriteSYLog(this.Text, CurrentOprt, sql);
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cardGrid.DataSource = null;
        }
    }
}