using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFMacDisc : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "SFMacDisc";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            GetCardTypeList();
            dataGrid.Rows.Clear();
            for (int i = 0; i < cardTypeList.Count; i++)
            {
                dataGrid.Rows.Add();
                dataGrid[0, i].Value = cardTypeList[i];
            }
            label1.ForeColor = Color.Blue;
            LoadData();
        }

        public frmSFMacDisc(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            string discStr = "";
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", SysID }));
                if (dr.Read()) discStr = dr["WithinDiscount"].ToString();
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
            SFWithinDiscount disc = new SFWithinDiscount(discStr);
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                string[] tmp = disc.CardTypeTime[i].Split(' ');
                for (int j = 0; j < 4; j++)
                {
                    dataGrid[j + 1, i].Value = tmp[j] == "*" ? "" : tmp[j];
                }
            }
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                dataGrid.Columns[i].ReadOnly = false;
            }
        }

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    string v = "";
                    if (dataGrid[e.ColumnIndex, e.RowIndex].Value != null) v = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    int i = 0;
                    int.TryParse(v, out i);
                    if ((i <= 0) || (i > 255))
                        dataGrid[e.ColumnIndex, e.RowIndex].Value = "";
                    else
                        dataGrid[e.ColumnIndex, e.RowIndex].Value = i;
                    break;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string discStr = "";
            string v = "";
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    v = "*";
                    if ((dataGrid[j + 1, i].Value != null) && Pub.IsNumeric(dataGrid[j + 1, i].Value.ToString()))
                    {
                        v = dataGrid[j + 1, i].Value.ToString();
                        if ((Convert.ToInt16(v) <= 0) || (Convert.ToInt16(v) > 255)) v = "*";
                    }
                    discStr += v + " ";
                }
                discStr += "@";
            }
            discStr = discStr.Substring(0, discStr.Length - 1);
            string sql = Pub.GetSQL(DBCode.DB_004004, new string[] { "110", discStr, SysID });
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
    }
}