using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmRSDimissionAdd : frmBaseDialog
    {
        private string title = "";
        private string oprt = "";
        private bool IsRS = false;

        protected override void InitForm()
        {
            formCode = "RSRSDimissionAdd";
            CreateCardGridView(cardGrid);
            base.InitForm();
            lblQuickSearchToolTip.ForeColor = Color.Blue;
            this.Text = title + "[" + oprt + "]";
            HasAbnormal = true;
            btnDelete.Text = Pub.GetResText(formCode, "ItemDelete", "");
            LoadData();

        }

        private void BtnStauta(bool falg)
        {
            txtEmpNo.Enabled = falg;
            btnSelectEmp.Enabled = falg;
            btnQuickSearch.Enabled = falg;
            btnClear.Enabled = falg;
            btnDelete.Enabled = falg;
            txtQuickSearch.Enabled = falg;
        }
        private void LoadData()
        {
            DataTableReader dr = null;
            try
            {
                if(IsRS)
                {
                    txtDimissionOprt.Text = OprtInfo.OprtNo;
                    dtpDimissionDate.Value = DateTime.Now;
                    if (SysID != "")
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "102", SysID }));
                        if (dr.Read())
                        {
                            txtEmpNo.Text = dr["EmpNo"].ToString();
                            txtEmpName.Text = dr["EmpName"].ToString();
                            txtDepart.Text = "[" + dr["DepartID"].ToString() + "]" + dr["DepartName"].ToString();
                            dr.Close();
                        }
                    }

                }
                else
                {
                    if (SysID == "")
                    {
                        txtDimissionOprt.Text = OprtInfo.OprtNo;
                        dtpDimissionDate.Value = DateTime.Now;
                    }
                    else
                    {
                        BtnStauta(false);
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "101", SysID }));
                        if (dr.Read())
                        {
                            txtEmpNo.Text = dr["EmpNo"].ToString();
                            txtEmpName.Text = dr["EmpName"].ToString();
                            txtDepart.Text = "[" + dr["DepartID"].ToString() + "]" + dr["DepartName"].ToString();
                            dtpDimissionDate.Value = Convert.ToDateTime(dr["DimissionDate"]);
                            txtDimissionOprt.Text = dr["DimissionOprt"].ToString();
                            txtDimissionReason.Text = dr["DimissionReason"].ToString();
                            dr.Close();
                        }
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
        }

        public frmRSDimissionAdd(string Title, string Oprt, string GUID,bool IsRS)
        {
            this.IsRS = IsRS;
            title = Title;
            oprt = Oprt;
            SysID = GUID;
            InitializeComponent();
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalCard(btnQuickSearch.Text, cardGrid, 0, true, true);
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalCard(txtQuickSearch, e, cardGrid);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cardGrid.DataSource = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cardGrid.RowCount == 0) return;
            if (cardGrid.SelectedRows.Count == 0) return;
            int idx = cardGrid.SelectedRows[0].Index;
            cardGrid.Rows.RemoveAt(cardGrid.SelectedRows[0].Index);
            if (idx < cardGrid.RowCount)
                cardGrid.Rows[idx].Selected = true;
            else if (cardGrid.RowCount > 0)
                cardGrid.Rows[idx - 1].Selected = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DataTableReader dr = null;
            string EmpNo = txtEmpNo.Text.Trim();
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "100", EmpNo }));
                if (dr.Read())
                {
                    string tmp = dr["CardStatusID"].ToString();
                    if (!tmp.Contains("10") && !tmp.Contains("60"))
                    {
                        Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorNotEmp", "")));
                        return;
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
            if (EmpNo == "" && cardGrid.Rows.Count == 0)
            {
                txtEmpNo.Focus();
                ShowErrorEnterCorrect(label2.Text);
                return;
            }
            string DimissionOprt = txtDimissionOprt.Text.Trim();
            if (DimissionOprt == "")
            {
                txtDimissionOprt.Focus();
                ShowErrorEnterCorrect(label4.Text);
                return;
            }
            string DimissionReason = txtDimissionReason.Text.Trim();
            //if (DimissionReason == "")
            //{
            //    txtDimissionReason.Focus();
            //    ShowErrorEnterCorrect(label8.Text);
            //    return;
            //}
            string DimissionDate = dtpDimissionDate.Value.ToString(SystemInfo.SQLDateTimeFMT);
            if (!Pub.CheckTextMaxLength(label8.Text, DimissionReason, txtDimissionReason.MaxLength)) return;
            List<string> sql = new List<string>();
            if (cardGrid.Rows.Count > 0)
            {
                DataTable dtGrid = (DataTable)cardGrid.DataSource;
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    string dtEmpNo = dtGrid.Rows[i]["EmpNo"].ToString();
                    try
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001002, new string[] { "100", dtEmpNo }));
                        if (dr.Read())
                        {
                            string tmp = dr["CardStatusID"].ToString();
                            if (!tmp.Contains("10") && !tmp.Contains("60"))
                            {
                                Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "ErrorNotEmp", "")));
                                return;
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
                    sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "23", dtEmpNo, DimissionOprt, DimissionReason, DimissionDate }));
                }
            }
            if (EmpNo != "")
                sql.Add(Pub.GetSQL(DBCode.DB_001003, new string[] { "23", EmpNo, DimissionOprt, DimissionReason, DimissionDate }));
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
                return;
            }
            if (db.ExecSQL(sql) != 0) return;
            db.WriteSYLog(title, oprt, sql);

            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            BtnStauta(false);
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnSelectDepart_Click(object sender, EventArgs e)
        {
            frmPubSelectDepart frm = new frmPubSelectDepart(false);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDepart.Text = frm.DepartName;
                txtDepart.Tag = frm.DepartSysID;
            }
         
        }

        private void btnSelectEmp_Click(object sender, EventArgs e)
        {
            frmPubSelectEmp frm = new frmPubSelectEmp(false);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEmpNo.Text = frm.EmpNo;
                txtEmpNo_Leave(null, null);
            }
         
        }

        private void txtEmpNo_Leave(object sender, EventArgs e)
        {
            txtEmpNo.Tag = "";
            txtEmpName.Text = "";
            txtDepart.Text = "";
            if (txtEmpNo.Text != "")
            {
                string EmpName = "";
                string DepartID = "";
                string DepartName = "";
                if (GetEmpInfoCard(txtEmpNo.Text, ref EmpName, ref DepartID, ref DepartName))
                {
                    txtEmpName.Text = EmpName;
                    txtDepart.Text = "[" + DepartID + "]" + DepartName;
                }
                else
                {
                    txtEmpNo.Text = "";
                    txtEmpName.Text = "";
                    txtDepart.Text = "";
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorEmpNotExists", ""));
                }
            }
        }
    }
}