using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmRSEmpCardBlackClear : frmBaseDialog
    {
        public string UserName = "";
        public bool IsAlways = true;
        public DateTime SelectDate = new DateTime();

        protected override void InitForm()
        {
            formCode = "RSEmpCardBlackClear";
            AddColumn(dataGrid, 1, "SelectCheck", false, false, 1, 60);
            AddColumn(dataGrid, 0, "EmpNo", false, true, 1, 80);
            AddColumn(dataGrid, 0, "EmpName", false, true, 1, 80);
            AddColumn(dataGrid, 0, "CardSectorNo", false, true, 1, 80);
            AddColumn(dataGrid, 0, "BlackDate", false, true, 1, 0);
            AddColumn(dataGrid, 0, "OprtNo", false, true, 1, 0);
            base.InitForm();
            dtpDate.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMonths(-6);
        }

        public frmRSEmpCardBlackClear()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGrid.DataSource = null;
            DateTime d = new DateTime();
            if (!db.GetServerDate(ref d)) return;
            d = d.AddMonths(-6);
            if (dtpDate.Value.Date > d.Date)
            {
                Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "Error001", ""), d.ToShortDateString()));
                return;
            }
            string sql = Pub.GetSQL(DBCode.DB_001003, new string[] { "502", dtpDate.Value.ToString(SystemInfo.SQLDateTimeFMT) });
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dataGrid.DataSource = db.GetDataTable(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
        }

        private void SelectData(bool State)
        {
            if (dataGrid.DataSource != null)
            {
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    dataGrid[0, i].Value = State;
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectData(true);
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            SelectData(false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<string> sql = new List<string>();
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                if (dataGrid[0, i].Value == null) continue;
                if (!Pub.ValueToBool(dataGrid[0, i].Value)) continue;
                sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "503", dataGrid[3, i].Value.ToString() }));
            }
            if (sql.Count == 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "MsgNoSelectDelete", ""));
                return;
            }
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg001", ""))) return;
            if (db.ExecSQL(sql) != 0) return;
            db.WriteSYLog(this.Text, "", sql);
            this.DialogResult = DialogResult.OK;
            this.Close();
         
        }

        private void cardGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }
    }
}