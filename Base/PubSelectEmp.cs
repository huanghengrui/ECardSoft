using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmPubSelectEmp : frmBaseDialog
    {
        private TreeNode findNode = null;
        private string otherCoin = "";
        public string EmpSysID = "";
        public string EmpNo = "";
        public string EmpName = "";
        public string CardSectorNo = "";
        public string CardPhysicsNo10 = "";
        public string CardPhysicsNo8 = "";

        protected override void InitForm()
        {
            formCode = "PubSelectEmp";
            base.InitForm();
            EmpSysID = "";
            EmpNo = "";
            EmpName = "";
            CardSectorNo = "";
            CardPhysicsNo10 = "";
            CardPhysicsNo8 = "";
            InitDepartTreeView(tvEmp, true, true, otherCoin);
            lblQuickSearchToolTip.ForeColor = Color.Blue;
        }

        public frmPubSelectEmp()
        {
            InitializeComponent();
        }

        public frmPubSelectEmp(bool state)
        {
            InitializeComponent();
            tvEmp.CheckBoxes = state;
        }

        public frmPubSelectEmp(string OtherCoin)
        {
            otherCoin = OtherCoin;
            InitializeComponent();
            tvEmp.CheckBoxes = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EmpNo = "";
            EmpName = "";
            SelectEmp(tvEmp.Nodes[0]);
            if (EmpNo != "")
            {
                EmpNo = EmpNo + "EmpNo";
                EmpName = EmpName.Substring(0, EmpName.Length - 1);
            }
            else if(EmpNo == "" && tvEmp.SelectedNode == null)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                return;
            }
            else
            {
                if (tvEmp.SelectedNode == null)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                    return;
                }
                EmpSysID = tvEmp.SelectedNode.Tag.ToString();
                if (EmpSysID.Length != 37)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
                    return;
                }
                EmpSysID = EmpSysID.Substring(1);
                string DepartSysID = tvEmp.SelectedNode.Parent.Tag.ToString();
                if (!db.CheckDepartPowerByDeptSysID(DepartSysID)) return;
                if (!db.GetEmpInfoCard(EmpSysID, ref EmpNo, ref EmpName, ref CardSectorNo, ref CardPhysicsNo10, ref CardPhysicsNo8)) return;
                if (EmpName.Trim() == "") EmpName = EmpNo;
            }
           
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SelectEmp(TreeNode node)
        {
            string empSysID = node.Tag.ToString();
            string empNo = "";
            string empName = "";
            try
            {
                if (empSysID.Length == 37)
                {
                    empSysID = empSysID.Substring(1);
                    if (node.Checked)
                    {
                        if (!db.GetEmpInfoCard(empSysID, ref empNo, ref empName, ref CardSectorNo, ref CardPhysicsNo10, ref CardPhysicsNo8)) return;
                        if (empName.Trim() == "") empName = empNo;
                        EmpNo = EmpNo + empNo + ",";
                        EmpName = EmpName + empName + ",";
                    }
                }
             
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }

            for (int i = 0; i < node.Nodes.Count; i++)
            {
                SelectEmp(node.Nodes[i]);
            }
        }
        private void tvEmp_DoubleClick(object sender, EventArgs e)
        {
            btnOk.PerformClick();
        }

        private bool FindNode(string findText, TreeNode nod)
        {
            bool ret = false;
            for (int i = 0; i < nod.Nodes.Count; i++)
            {
                if (nod.Nodes[i].Tag.ToString().Length != 37)
                {
                    ret = FindNode(findText, nod.Nodes[i]);
                    if (ret) break;
                    continue;
                }
                if (nod.Nodes[i].Text.IndexOf(findText) != -1)
                {
                    if (findNode != null && findNode.Index >= nod.Nodes[i].Index) continue;
                    findNode = nod.Nodes[i];
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            string s = txtFind.Text;
            if (s == "") return;
            bool isFind = false;
            for (int i = 0; i < tvEmp.Nodes.Count; i++)
            {
                if (tvEmp.Nodes[i].Tag.ToString().Length != 37)
                {
                    isFind = FindNode(s, tvEmp.Nodes[i]);
                    if (isFind) break;
                    continue;
                }
                if (tvEmp.Nodes[i].Text.IndexOf(s) != -1)
                {
                    if (findNode != null && findNode.Index >= tvEmp.Nodes[i].Index) continue;
                    findNode = tvEmp.Nodes[i];
                    isFind = true;
                    break;
                }
            }
            if (!isFind) findNode = null;
            if (findNode != null) tvEmp.SelectedNode = findNode;
        }

        private void tvEmp_AfterCheck(object sender, TreeViewEventArgs e)
        {
            SelectTreeNode(e.Node);
        }
    }
}