using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFMacOpterSelect : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "SFMacOpterSelect";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            LoadData();
        }

        public frmSFMacOpterSelect(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            string opterStr = "";
            string sql = "";
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", SysID }));
                if (dr.Read()) opterStr = dr["Opter"].ToString();
                if (opterStr != "")
                {
                    string[] ss = opterStr.Split(' ');
                    string tmp = "";
                    for (int i = 0; i < ss.Length; i++)
                    {
                        if ((ss[i] != "") && (Pub.IsNumeric(ss[i]))) tmp = tmp + ss[i] + ",";
                    }
                    if (tmp != "") tmp = tmp.Substring(0, tmp.Length - 1);
                    sql = Pub.GetSQL(DBCode.DB_004004, new string[] { "114", tmp });
                }
                else
                    sql = Pub.GetSQL(DBCode.DB_000004, new string[] { "0" });
                bindingSource.DataSource = db.GetDataTable(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectOpter(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectOpter(false);
        }

        private void SelectOpter(bool state)
        {
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                dataGrid[0, i].Value = state;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string opterStr = "";
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue)) opterStr += dataGrid[1, i].Value.ToString() + " ";
            }
            opterStr = opterStr.Trim();
            string sql = Pub.GetSQL(DBCode.DB_004004, new string[] { "115", opterStr, SysID });
            try
            {
                db.ExecSQL(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
                return;
            }
            db.WriteSYLog(this.Text, CurrentOprt, sql);
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}