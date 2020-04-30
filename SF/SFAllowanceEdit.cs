using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFAllowanceEdit : frmBaseDialog
    {
        private int AllowanceWay = 0;
        private double AllowanceAmountUp = 0;
        private double AllowanceAmount = 0;
        private double AllowanceAmountSum = 0;

        protected override void InitForm()
        {
            formCode = "SFAllowanceEdit";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            txtAmount.Enter += TextBoxCurrency_Enter;
            txtAmount.Leave += TextBoxCurrency_Leave;
            LoadData();
        }

        public frmSFAllowanceEdit(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "15", SysID }));
                if (dr.Read())
                {
                    txtEmpNo.Text = dr["EmpNo"].ToString();
                    txtEmpName.Text = dr["EmpName"].ToString();
                    txtDepartName.Text = dr["DepartName"].ToString();
                    txtCardSectorNo.Text = dr["CardSectorNo"].ToString();
                    txtWay.Text = dr["AllowanceWayName"].ToString();
                    int.TryParse(dr["AllowanceWay"].ToString(), out AllowanceWay);
                    double.TryParse(dr["AllowanceAmountUp"].ToString(), out AllowanceAmountUp);
                    txtUp.Text = AllowanceAmountUp.ToString(SystemInfo.CurrencySymbol + "0.00");
                    double.TryParse(dr["AllowanceAmount"].ToString(), out AllowanceAmount);
                    txtAmount.Text = AllowanceAmount.ToString(SystemInfo.CurrencySymbol + "0.00");
                    double.TryParse(dr["AllowanceAmountSum"].ToString(), out AllowanceAmountSum);
                    txtSum.Text = AllowanceAmountSum.ToString(SystemInfo.CurrencySymbol + "0.00");
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
        }

        private void frmSFAllowanceEdit_Shown(object sender, EventArgs e)
        {
            txtAmount.Focus();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(CurrencyToStringEx(txtAmount.Text), out AllowanceAmount);
            if (AllowanceWay == 2)
                AllowanceAmountSum = AllowanceAmountUp + AllowanceAmount;
            else
                AllowanceAmountSum = AllowanceAmount;
            txtSum.Text = AllowanceAmountSum.ToString(SystemInfo.CurrencySymbol + "0.00");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (AllowanceAmount <= 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorMoneyZero", ""));
                return;
            }
            string sql = Pub.GetSQL(DBCode.DB_004006, new string[] { "19", AllowanceAmount.ToString(),
        AllowanceAmountUp.ToString(), AllowanceAmountSum.ToString(), OprtInfo.OprtSysID, SysID });
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