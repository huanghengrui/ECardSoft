using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFAllowanceAdd : frmBaseDialog
    {
        private bool IsWorking = false;

        protected override void InitForm()
        {
            formCode = "SFAllowanceAdd";
            CreateCardGridView(cardGrid);
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            txtMoney.Enter += TextBoxCurrency_Enter;
            txtMoney.Leave += TextBoxCurrency_Leave;
            double d = 0;
            txtMoney.Text = d.ToString(SystemInfo.CurrencySymbol + "0.00");
            cbbWay.Items.Clear();
            DataTableReader dr = null;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "18" }));
                while (dr.Read())
                {
                    //if (dr["AllowanceWayID"].ToString() == "1") continue;
                    cbbWay.Items.Add(new TCommonType(dr["AllowanceWaySysID"].ToString(), dr["AllowanceWayID"].ToString(),
                      dr["AllowanceWayName"].ToString(), true));
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
            cbbWay.Text = SystemInfo.ini.ReadIni("Public", "SFAllowanceWay", "");
            if (cbbWay.SelectedIndex == -1 && cbbWay.Items.Count > 0) cbbWay.SelectedIndex = 0;
            dtpFlag.Value = DateTime.Now.Date;
        }

        public frmSFAllowanceAdd(string title, string CurrentTool)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            InitializeComponent();
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalCard(btnQuickSearch.Text, cardGrid);
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalCard(txtQuickSearch, e, cardGrid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = cardGrid.SelectedRows.Count - 1; i >= 0; i--)
            {
                cardGrid.Rows.Remove(cardGrid.SelectedRows[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cardGrid.DataSource = null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
          
            progBar.Visible = true;
            progBar.Value = 0;
            IsWorking = true;
            bool ret = SaveDB();
            IsWorking = false;
            if (ret)
            {
                SystemInfo.ini.WriteIni("Public", "SFAllowanceWay", cbbWay.Text);
                Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            progBar.Visible = false;
        }

        private bool SaveDB()
        {
            
            if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg001", ""))) return false;
            if (cardGrid.RowCount == 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                return false;
            }
            if (cbbWay.SelectedIndex == -1)
            {
                ShowErrorSelectCorrect(label3.Text);
                return false;
            }
            int way = Convert.ToInt32(((TCommonType)cbbWay.Items[cbbWay.SelectedIndex]).id);
            double AllowanceAmount = 0;
            double.TryParse(CurrencyToStringEx(txtMoney.Text), out AllowanceAmount);
            if (AllowanceAmount <= 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMoneyZero", ""));
                return false;
            }
            DateTime dFlag = dtpFlag.Value;
            DateTime dt = new DateTime();
            byte retCheck = 0;
            List<string> sql = new List<string>();
            sql.Clear();
            string EmpSysID = "";
            int AllowanceCount = 0;
            bool isAllContinue = false;
            bool isNotAllContinue = false;
            DataTableReader dr = null;
            DataTable dtGrid = (DataTable)cardGrid.DataSource;
            /*if (dtGrid.Rows.Count > 1)
            {
              retCheck = db.CheckAllowanceFlag("", dFlag, ref dt);
              if (retCheck == 1)
              {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Error101", ""), dt.ToShortDateString()));
                return false;
              }
              else if (retCheck == 2)
              {
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Error102", ""), dt.ToShortDateString()));
                return false;
              }
              else if (retCheck == 3)
              {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error103", ""));
                return false;
              }
            }*/
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
                EmpSysID = dtGrid.Rows[i]["EmpSysID"].ToString();
                //if (dtGrid.Rows.Count == 1)
                //{

                retCheck = db.CheckAllowanceFlag(EmpSysID, dFlag, ref dt);
                if (retCheck == 1)
                {
                    Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "Error101", ""), dt.ToShortDateString()));
                    return false;
                }
                else if (retCheck == 2)
                {
                    Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "Error102", ""), dt.ToShortDateString()));
                    return false;
                }
                else if (retCheck == 3)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error103", ""));
                    return false;
                }

                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "24", EmpSysID, dFlag.ToString("MM")}));
                if(dr.Read())
                {
                    AllowanceCount = AllowanceCount+Convert.ToInt32(dr[1].ToString());
                }
                dr.Close();
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "25", EmpSysID, dFlag.ToString("MM")}));
                if (dr.Read())
                {
                    AllowanceCount = AllowanceCount + Convert.ToInt32(dr[1].ToString());
                }
                if(SystemInfo.SubsidyRestrictionFlag!=0)
                {
                    if (!isAllContinue)
                    {
                        if (isNotAllContinue)
                        {
                            continue;
                        }
                        if (AllowanceCount > SystemInfo.SubsidyRestrictionFlag)
                        {
                            string msg = string.Format(Pub.GetResText(formCode, "Msg002", ""),
                                dtGrid.Rows[i]["EmpNo"].ToString() + " [" + dtGrid.Rows[i]["EmpName"].ToString() + "]");
                            frmPubContinue frm = new frmPubContinue(this.Text, msg);

                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                isAllContinue = frm.IsAllContinue;
                                isNotAllContinue = frm.IsNotAllContinue;
                                continue;
                            }
                            else
                            {
                                isAllContinue = frm.IsAllContinue;
                                isNotAllContinue = frm.IsNotAllContinue;
                            }
                        }
                    }
                }

                //}
                if (!GetSFAllowance(EmpSysID, dFlag, AllowanceAmount, way, ref sql)) return false;
                progBar.Value = (i + 1) * 100 / (cardGrid.RowCount + 1);
            }
            if (db.ExecSQL(sql) != 0) return false;
            db.WriteSYLog(this.Text, CurrentOprt, sql);
            progBar.Value = 100;
            return true;
        }

        private void frmSFAllowanceAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsWorking) e.Cancel = true;
        }
    }
}