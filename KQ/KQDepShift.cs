using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmKQDepShift : frmBaseMDIChildTree
    {
        private string DepartSysID = "";

        protected override void InitForm()
        {
            formCode = "KQDepShift";
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            SetToolItemState("ItemTAG3", true);
            SetToolItemState("ItemLine3", true);
            CheckForward = false;
            base.InitForm();
            SetToolImage("ItemTAG1", "FileSave");
            SetToolImage("ItemTAG2", "EditUndo");
            SetToolImage("ItemTAG3", "FileSaveAll");
            DataTableReader dr = null;
            TCommonType ctype = new TCommonType("", "", "", true);
            ComboBox cbb;
            for (int i = 1; i <= 31; i++)
            {
                cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
                cbb.Items.Clear();
                cbb.Items.Add(ctype);
            }
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002004, new string[] { "3" }));
                while (dr.Read())
                {
                    ctype = new TCommonType(dr["GUID"].ToString(), dr["ShiftNo"].ToString(), dr["ShiftName"].ToString(), true);
                    for (int i = 1; i <= 31; i++)
                    {
                        cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
                        cbb.Items.Add(ctype);
                    }
                }
                for (int i = 1; i <= 31; i++)
                {
                    cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
                    cbb.SelectedIndex = 0;
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
            dtpYM.Value = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
            dtpYM.CustomFormat = SystemInfo.YMFormat;
        }

        public frmKQDepShift()
        {
            InitializeComponent();
        }

        private void pnlRight_Resize(object sender, EventArgs e)
        {
            int w = pnlRight.Width - 80;
            int ww = w / 7;
            int l = 10;
            Label lab;
            for (int i = 1; i <= 7; i++)
            {
                lab = (Label)pnlRight.Controls["lblWeek" + i.ToString()];
                lab.Width = ww;
                lab.Left = l;
                lab.Top = 80;
                l += ww + 10;
            }
            DisplayDays();
            RefreshForm(true);
           
        }

        private void tvEmp_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (IsInit) return;
            DisplayDays();
            RefreshForm(true);
            
        }

        private void dtpYM_ValueChanged(object sender, EventArgs e)
        {
            if (IsInit) return;
            DisplayDays();
            RefreshForm(true);
           
        }

        private void DisplayDays()
        {
            Label lab;
            ComboBox cbb;
            for (int i = 1; i <= 31; i++)
            {
                lab = (Label)pnlRight.Controls["lblDay" + i.ToString("00")];
                lab.Visible = false;
                lab.Enabled = false;
                cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
                cbb.Visible = false;
                cbb.Enabled = false;
            }
            DateTime dt = new DateTime(dtpYM.Value.Year, dtpYM.Value.Month, 1);
            int days = dt.AddMonths(1).AddDays(-1).Day;
            int week = (int)dt.DayOfWeek;
            int l = 10;
            switch (week)
            {
                case 0:
                    l = lblWeek1.Left;
                    break;
                case 1:
                    l = lblWeek2.Left;
                    break;
                case 2:
                    l = lblWeek3.Left;
                    break;
                case 3:
                    l = lblWeek4.Left;
                    break;
                case 4:
                    l = lblWeek5.Left;
                    break;
                case 5:
                    l = lblWeek6.Left;
                    break;
                case 6:
                    l = lblWeek7.Left;
                    break;
            }
            int xl = l;
            int t = 100;
            int w = lblWeek1.Width;
            for (int i = 1; i <= days; i++)
            {
                lab = (Label)pnlRight.Controls["lblDay" + i.ToString("00")];
                lab.Text = i.ToString();
                toolTip.SetToolTip(lab, lab.Text);
                cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
                lab.Width = w;
                lab.Left = l;
                lab.Visible = true;
                lab.Enabled = true;
                lab.Top = t;
                cbb.Width = w;
                cbb.Left = l;
                cbb.Top = t + 20;
                cbb.Visible = true;
                cbb.Enabled = true;
                l += w + 10;
                if (l + w >= pnlRight.Width)
                {
                    l = 10;
                    t += 60;
                }
            }
            
        }

        protected override void ExecItemEdit()
        {
            if (!db.CheckDepartPowerByDeptSysID(DepartSysID)) return;
            base.ExecItemEdit();
            RefreshForm(false);
          
        }

        protected override void ExecItemDelete()
        {
            if (!db.CheckDepartPowerByDeptSysID(DepartSysID)) return;
            string sql = Pub.GetSQL(DBCode.DB_002006, new string[] { "1", DepartSysID, dtpYM.Value.Year.ToString(),
        dtpYM.Value.Month.ToString() });
            try
            {
                db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
                return;
            }
            db.WriteSYLog(this.Text, CurrentTool, sql);
            RefreshForm(true);
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgDeleteSucceed", ""), MessageBoxIcon.Information);
            
        }

        protected override void ExecItemTAG1()
        {
            if (!db.CheckDepartPowerByDeptSysID(DepartSysID)) return;
            base.ExecItemTAG1();
            List<string> sql = new List<string>();
            sql.Add(Pub.GetSQL(DBCode.DB_002006, new string[] { "1", DepartSysID, dtpYM.Value.Year.ToString(),
        dtpYM.Value.Month.ToString() }));
            DateTime dt = new DateTime(dtpYM.Value.Year, dtpYM.Value.Month, 1);
            int days = dt.AddMonths(1).AddDays(-1).Day;
            string ShiftNo = "";
            ComboBox cbb;
            for (int i = 1; i <= days; i++)
            {
                cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
                ShiftNo = ((TCommonType)cbb.Items[cbb.SelectedIndex]).id;
                if (ShiftNo != "")
                {
                    sql.Add(Pub.GetSQL(DBCode.DB_002006, new string[] { "2", DepartSysID,
            dt.AddDays(i - 1).ToString(SystemInfo.SQLDateFMT), ShiftNo }));
                }
            }
            if (db.ExecSQL(sql) != 0) return;
            RefreshForm(true);
            db.WriteSYLog(this.Text, CurrentTool, sql);
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            
        }

        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            RefreshForm(true);
        }

        protected override void ExecItemTAG3()
        {
            base.ExecItemTAG3();
            frmKQDepShiftBatch frm = new frmKQDepShiftBatch(this.Text, CurrentTool);
            if (frm.ShowDialog() == DialogResult.OK) RefreshForm(true);
            
        }

        protected override void ExecItemRefresh()
        {
            DateTime StartTime = DateTime.Now;
            QuerySQL = Pub.GetSQL(DBCode.DB_002006, new string[] { "0", DepartSysID, dtpYM.Value.Year.ToString(),
        dtpYM.Value.Month.ToString() });
            RefreshMsg(StrReading);
            DataTable dt = null;
            if (QuerySQL != "")
            {
                try
                {
                    if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                    dt = db.GetDataTable(QuerySQL);
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E, QuerySQL);
                }
            }
            ComboBox cbb;
            for (int i = 1; i <= 31; i++)
            {
                cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
                if (cbb.Items.Count > 0) cbb.SelectedIndex = 0;
            }
            if (dt != null)
            {
                DateTime d = new DateTime(dtpYM.Value.Year, dtpYM.Value.Month, 1);
                for (int i = 1; i <= 31; i++)
                {
                    cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[j]["DepShiftDate"].ToString() == d.AddDays(i - 1).ToString())
                        {
                            for (int k = 0; k < cbb.Items.Count; k++)
                            {
                                if (((TCommonType)cbb.Items[k]).id == dt.Rows[j]["ShiftNo"].ToString())
                                {
                                    cbb.SelectedIndex = k;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            dt.Clear();
            dt.Reset();
            RefreshMsg(StrReadEnd + Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
            
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            bool IsDepart = false;
            DepartSysID = "";
            if (tvEmp.SelectedNode != null)
            {
                DepartSysID = tvEmp.SelectedNode.Tag.ToString();
                IsDepart = true;
            }
            ItemEdit.Enabled = IsDepart && State;
            ItemDelete.Enabled = IsDepart && State;
            ItemTAG1.Enabled = IsDepart && !State;
            ItemTAG2.Enabled = ItemTAG1.Enabled;
            ItemTAG3.Enabled = (tvEmp.SelectedNode != null) && State;
            label1.Enabled = State;
            dtpYM.Enabled = State;
            tvEmp.Enabled = State;
            Label lab;
            ComboBox cbb;
            for (int i = 1; i <= 31; i++)
            {
                lab = (Label)pnlRight.Controls["lblDay" + i.ToString("00")];
                if (lab.Visible) lab.Enabled = ItemTAG1.Enabled;
                cbb = (ComboBox)pnlRight.Controls["cbbDay" + i.ToString("00")];
                if (cbb.Visible) cbb.Enabled = ItemTAG1.Enabled;
            }
            if (State && (db != null)) ExecItemRefresh();
        }

        private void frmKQDepShift_Shown(object sender, EventArgs e)
        {
            RefreshForm(true);
        }
    }
}