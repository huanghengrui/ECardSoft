using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFMacOrder : frmBaseDialog
    {
        protected override void InitForm()
        {
            formCode = "SFMacOrder";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            ComboBox cbb;
            CheckBox chk;
            for (int i = 0; i <= 3; i++)
            {
                cbb = (ComboBox)pnlTime.Controls[string.Format("cbbOrder{0}", i + 1)];
                cbb.Items.Clear();
                cbb.Items.Add(Pub.GetResText(formCode, "ThatDay", ""));
                cbb.Items.Add(Pub.GetResText(formCode, "NextDay", ""));
                chk = (CheckBox)pnlTime.Controls[string.Format("chkOrder{0}1", i + 1)];
                chk.Text = Pub.GetResText(formCode, "Breakfast", "");
                chk = (CheckBox)pnlTime.Controls[string.Format("chkOrder{0}2", i + 1)];
                chk.Text = Pub.GetResText(formCode, "Lunch", "");
                chk = (CheckBox)pnlTime.Controls[string.Format("chkOrder{0}3", i + 1)];
                chk.Text = Pub.GetResText(formCode, "Dinner", "");
                chk = (CheckBox)pnlTime.Controls[string.Format("chkOrder{0}4", i + 1)];
                chk.Text = Pub.GetResText(formCode, "Snack", "");
            }
            chkOrder51.Text = Pub.GetResText(formCode, "Breakfast", "");
            chkOrder52.Text = Pub.GetResText(formCode, "Lunch", "");
            chkOrder53.Text = Pub.GetResText(formCode, "Dinner", "");
            chkOrder54.Text = Pub.GetResText(formCode, "Snack", "");

            chkOrder61.Text = Pub.GetResText(formCode, "SunID", "");
            chkOrder62.Text = Pub.GetResText(formCode, "MonID", "");
            chkOrder63.Text = Pub.GetResText(formCode, "TueID", "");
            chkOrder64.Text = Pub.GetResText(formCode, "WedID", "");
            chkOrder65.Text = Pub.GetResText(formCode, "ThuID", "");
            chkOrder66.Text = Pub.GetResText(formCode, "FriID", "");
            chkOrder67.Text = Pub.GetResText(formCode, "SatID", "");
            SetTextboxNumber(txtOrder53);
            LoadData();
        }

        public frmSFMacOrder(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            string orderStr = "";
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", SysID }));
                if (dr.Read()) orderStr = dr["Ordering"].ToString();
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
            SFOrdering order = new SFOrdering(orderStr);
            rbTime.Checked = order.OrderType == 1;
            rbDay.Checked = order.OrderType == 2;
            ComboBox cbb;
            CheckBox chk;
            MaskedTextBox txt;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    chk = (CheckBox)pnlTime.Controls[string.Format("chkOrder{0}{1}", i + 1, j + 1)];
                    chk.Checked = order.OrderMemo.Substring(i * 4, 4).Substring(j, 1) == "1";
                }
                chk = (CheckBox)pnlDay.Controls[string.Format("chkOrder5{0}", i + 1)];
                chk.Checked = order.OrderMemo.Substring(i, 1) == "1";
                cbb = (ComboBox)pnlTime.Controls[string.Format("cbbOrder{0}", i + 1)];
                if (cbb.Items.Count > order.IsNextDay[i]) cbb.SelectedIndex = order.IsNextDay[i];
                txt = (MaskedTextBox)pnlTime.Controls[string.Format("txtOrder{0}1", i + 1)];
                txt.Text = order.BeginTime[i];
                txt = (MaskedTextBox)pnlTime.Controls[string.Format("txtOrder{0}2", i + 1)];
                txt.Text = order.EndTime[i];
            }
            for (int i = 0; i <= 6; i++)
            {
                chk = (CheckBox)pnlTime.Controls[string.Format("chkOrder6{0}", i + 1)];
                chk.Checked = order.Restday[i].ToString() == "1";
            }
            txtOrder51.Text = order.BeginTime[0];
            txtOrder52.Text = order.EndTime[0];
            txtOrder53.Text = order.Units.ToString();
            RadioButton_Click(null, null);
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            pnlTime.Enabled = rbTime.Checked;
            pnlTime.Visible = pnlTime.Enabled;
            pnlDay.Enabled = rbDay.Checked;
            pnlDay.Visible = pnlDay.Enabled;
        }

        private void OrderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshOrderControl(pnlTime);
        }

        private void OrderCheckBox_Click(object sender, EventArgs e)
        {
            RefreshOrderControl(pnlTime);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbTime.Checked)
            {
                if (!CheckOrderInfo(pnlTime)) return;
            }
            else
            {
                if ((txtOrder51.Text == "00:00") && (txtOrder52.Text == "00:00"))
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorOrderTime", ""));
                    return;
                }
                if (txtOrder52.Text.CompareTo(txtOrder51.Text) <= 0)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorOrderTime", ""));
                    return;
                }
                if (!chkOrder51.Checked && !chkOrder52.Checked && !chkOrder53.Checked && !chkOrder54.Checked)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorOrderMealEmpty", ""));
                    return;
                }
                if ((txtOrder53.Text == "") || !Pub.IsNumeric(txtOrder53.Text))
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error101", ""));
                    return;
                }
                if ((Convert.ToByte(txtOrder53.Text) < 1) || (Convert.ToByte(txtOrder53.Text) > 7))
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error101", ""));
                    return;
                }
            }
            string orderStr = "N@";
            orderStr += rbTime.Checked ? "1" : "2";
            orderStr += "@";
            CheckBox chk;
            ComboBox cbb;
            MaskedTextBox txt;
            if (rbTime.Checked)
            {
                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        chk = (CheckBox)pnlTime.Controls[string.Format("chkOrder{0}{1}", i + 1, j + 1)];
                        orderStr += Convert.ToByte(chk.Checked).ToString();
                    }
                }
                orderStr += "@0@";
                for (int i = 0; i <= 3; i++)
                {
                    cbb = (ComboBox)pnlTime.Controls[string.Format("cbbOrder{0}", i + 1)];
                    orderStr += cbb.SelectedIndex.ToString() + "@";
                }
                for (int i = 0; i <= 3; i++)
                {
                    txt = (MaskedTextBox)pnlTime.Controls[string.Format("txtOrder{0}1", i + 1)];
                    orderStr += txt.Text + "@";
                }
                for (int i = 0; i <= 3; i++)
                {
                    txt = (MaskedTextBox)pnlTime.Controls[string.Format("txtOrder{0}2", i + 1)];
                    orderStr += txt.Text + "@";
                }
            }
            else
            {
                for (int i = 0; i <= 3; i++)
                {
                    chk = (CheckBox)pnlDay.Controls[string.Format("chkOrder5{0}", i + 1)];
                    orderStr += Convert.ToByte(chk.Checked).ToString();
                }
                for (int i = 0; i < 12; i++)
                {
                    orderStr += "0";
                }
                orderStr += "@" + txtOrder53.Text + "@0@0@0@0@";
                orderStr += txtOrder51.Text + "@00:00@00:00@00:00@";
                orderStr += txtOrder52.Text + "@00:00@00:00@00:00@";
            }
            if (rbTime.Checked)
            {
                for (int i = 0; i <= 6; i++)
                {
                    chk = (CheckBox)pnlTime.Controls[string.Format("chkOrder6{0}", i + 1)];
                    orderStr += Convert.ToByte(chk.Checked).ToString() + "@";
                }
            }
            string sql = Pub.GetSQL(DBCode.DB_004004, new string[] { "117", orderStr, SysID });
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