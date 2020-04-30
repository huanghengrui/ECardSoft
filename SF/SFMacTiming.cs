using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFMacTiming : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "SFMacTiming";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            GetCardTypeList();
            dataGrid.Rows.Clear();
            tvGrid.Nodes.Clear();
            for (int i = 0; i < 4; i++)
            {
                tvGrid.Nodes.Add(dataGrid.Columns[i].HeaderText);
            }
            TreeNode node;
            string Charge = Pub.GetResText(formCode, "Charge", "");
            string Accounting = Pub.GetResText(formCode, "Accounting", "");
            for (int i = 0; i < cardTypeList.Count; i++)
            {
                dataGrid.Columns[i * 2 + 4].HeaderText = cardTypeList[i].name;
                dataGrid.Columns[i * 2 + 5].HeaderText = cardTypeList[i].name;
                dataGrid.Columns[i * 2 + 4].Width = 45;
                dataGrid.Columns[i * 2 + 5].Width = 45;
                node = tvGrid.Nodes.Add(dataGrid.Columns[i * 2 + 4].HeaderText);
                node.Nodes.Add(Charge);
                node.Nodes.Add(Accounting);
            }
            string[] ss = DeviceObject.objKS.FeeTimingDataType.Split('|');
            Column2.Items.Clear();
            Column2.Items.Add("");
            for (int i = 0; i < ss.Length; i++)
            {
                Column2.Items.Add(ss[i]);
            }
            cbbWay.Items.Clear();
            for (int i = 1; i <= 4; i++)
            {
                cbbWay.Items.Add(Pub.GetResText(formCode, "Way" + i.ToString(), ""));
            }
            SetTextboxNumber(txtUnits);
            SetTextboxNumber(txtMin);
            SetTextboxNumber(txtMax);
            toolTip.SetToolTip(picTip, Pub.GetResText(formCode, "GridHint", ""));
            LoadData();
        }

        public frmSFMacTiming(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            string timingStr = "";
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", SysID }));
                if (dr.Read()) timingStr = dr["Timing"].ToString();
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
            SFTiming timing = new SFTiming(timingStr);
            txtUnits.Text = timing.Units.ToString();
            cbbWay.SelectedIndex = timing.Way - 1;
            txtMin.Text = timing.MinuteMin.ToString();
            txtMax.Text = timing.MinuteMax.ToString();
            txtFree.Text = timing.MinuteFree.ToString();
            chkDecFree.Checked = timing.DecFree;
            for (int i = 0; i < 20; i++)
            {
                string[] ss = timing.Info[i].Split(' ');
                dataGrid.Rows.Add();
                dataGrid[0, i].Value = i + 1;
                for (int j = 1; j < dataGrid.ColumnCount; j++)
                {
                    dataGrid[j, i].Value = ss[j - 1] == "/" ? "" : ss[j - 1];
                }
            }
            for (int j = 1; j < dataGrid.ColumnCount; j++)
            {
                dataGrid.Columns[j].ReadOnly = false;
            }
        }

        private void dataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string v = "";
            switch (e.ColumnIndex)
            {
                case 0:
                    break;
                case 1:
                    if (dataGrid[e.ColumnIndex, e.RowIndex].Value != null)
                    {
                        if (dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString() != "")
                        {
                            dataGrid[2, e.RowIndex].Value = "00:00";
                            dataGrid[3, e.RowIndex].Value = "23:59";
                        }
                    }
                    break;
                case 2:
                case 3:
                    if (dataGrid[e.ColumnIndex, e.RowIndex].Value != null)
                    {
                        txtTime.Text = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                        v = Pub.ValidatTime(txtTime.Text.Trim());
                        dataGrid[e.ColumnIndex, e.RowIndex].Value = v;
                    }
                    break;
                case 4:
                case 6:
                case 8:
                case 10:
                case 12:
                case 14:
                case 16:
                case 18:
                    if (dataGrid[e.ColumnIndex, e.RowIndex].Value != null) v = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    if (Pub.IsNumeric(v) && (Convert.ToDecimal(v) > 0))
                    {
                        if (Convert.ToDecimal(v) * 100 > 0xffffffff)
                            dataGrid[e.ColumnIndex, e.RowIndex].Value = "";
                        else
                        {
                            dataGrid[e.ColumnIndex, e.RowIndex].Value = Convert.ToDecimal(v).ToString("0.00");
                            dataGrid[e.ColumnIndex + 1, e.RowIndex].Value = "";
                        }
                    }
                    else
                        dataGrid[e.ColumnIndex, e.RowIndex].Value = "";
                    break;
                default:
                    if (dataGrid[e.ColumnIndex, e.RowIndex].Value != null) v = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                    if (Pub.IsNumeric(v) && (Convert.ToDecimal(v) > 0))
                    {
                        if (Convert.ToDecimal(v) * 100 > 0xffffffff)
                            dataGrid[e.ColumnIndex, e.RowIndex].Value = "";
                        else
                        {
                            dataGrid[e.ColumnIndex, e.RowIndex].Value = Convert.ToDecimal(v).ToString("0.00");
                            dataGrid[e.ColumnIndex - 1, e.RowIndex].Value = "";
                        }
                    }
                    else
                        dataGrid[e.ColumnIndex, e.RowIndex].Value = "";
                    break;
            }
        }

        private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void GridMenu_Opening(object sender, CancelEventArgs e)
        {
            ItemPasteUpData.Enabled = dataGrid.CurrentRow.Index > 0;
        }

        private void ItemPasteUpData_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                dataGrid.CurrentRow.Cells[i].Value = dataGrid[i, dataGrid.CurrentRow.Index - 1].Value;
            }
        }

        private void ItemEmptyData_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                dataGrid.CurrentRow.Cells[i].Value = "";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if ((txtUnits.Text == "") || !Pub.IsNumeric(txtUnits.Text) ||
              (Convert.ToInt16(txtUnits.Text) < 1) || (Convert.ToInt16(txtUnits.Text) > 255))
            {
                txtUnits.Focus();
                ShowErrorEnterCorrect(label1.Text);
                return;
            }
            if ((txtMin.Text == "") || !Pub.IsNumeric(txtMin.Text)) txtMin.Text = "0";
            if ((Convert.ToInt16(txtMin.Text) < 0) || (Convert.ToInt16(txtMin.Text) > 255))
            {
                txtMin.Focus();
                ShowErrorEnterCorrect(label5.Text);
                return;
            }
            if ((txtMax.Text == "") || !Pub.IsNumeric(txtMax.Text)) txtMax.Text = "0";
            if ((Convert.ToInt16(txtMax.Text) < 0) || (Convert.ToInt16(txtMax.Text) > 255))
            {
                txtMax.Focus();
                ShowErrorEnterCorrect(label7.Text);
                return;
            }
            if ((txtFree.Text == "") || !Pub.IsNumeric(txtFree.Text)) txtFree.Text = "0";
            if ((Convert.ToInt16(txtFree.Text) < 0) || (Convert.ToInt16(txtFree.Text) > 255))
            {
                txtFree.Focus();
                ShowErrorEnterCorrect(label9.Text);
                return;
            }
            string timingStr = string.Format("{0}@{1}@{2}@{3}@{4}@{5}@", txtUnits.Text, cbbWay.SelectedIndex + 1,
              txtMin.Text, txtMax.Text, txtFree.Text, Convert.ToByte(chkDecFree.Checked).ToString());
            for (int i = 0; i < 20; i++)
            {
                for (int j = 1; j < dataGrid.ColumnCount; j++)
                {
                    if ((dataGrid[1, i].Value != null) && (dataGrid[1, i].Value.ToString() == ""))
                        timingStr += "/";
                    else
                        timingStr += dataGrid[j, i].Value.ToString() == "" ? "/" : dataGrid[j, i].Value.ToString();
                    timingStr += " ";
                }
                timingStr += "@";
            }
            timingStr = timingStr.Substring(0, timingStr.Length - 1);
            string sql = Pub.GetSQL(DBCode.DB_004004, new string[] { "116", timingStr, SysID });
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

        private void picTip_Click(object sender, EventArgs e)
        {
            string tmp = "";
            for (int i = 0; i <= 5; i++)
            {
                tmp = tmp + Pub.GetResText(formCode, "GridHint" + i.ToString(), "") + "\r\n\r\n";
            }
            Pub.MessageBoxShow(tmp, MessageBoxIcon.Information);
        }
    }
}