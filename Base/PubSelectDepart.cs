using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmPubSelectDepart : frmBaseDialog
    {
        public string DepartSysID = "";
        public string DepartID = "";
        public string DepartName = "";

        protected override void InitForm()
        {
            formCode = "PubSelectDepart";
            base.InitForm();
            DepartSysID = "";
            DepartID = "";
            DepartName = "";
            InitDepartTreeView(tvDepart);
        }

        public frmPubSelectDepart()
        {
            InitializeComponent();
        }

        public frmPubSelectDepart(bool state)
        {
            InitializeComponent();
            tvDepart.CheckBoxes = state;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DepartID = "";
            DepartName = "";
            SelectDepart(tvDepart.Nodes[0]);
            if (DepartID != "")
            {
                DepartID = DepartID + "DepartID";
                DepartName = DepartName.Substring(0, DepartName.Length - 1);
            }
            else if (DepartID == ""&& tvDepart.SelectedNode == null)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectDepart", ""));
                return;
            }
            else
            {
                if (tvDepart.SelectedNode == null)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectDepart", ""));
                    return;
                }
               
                DepartSysID = tvDepart.SelectedNode.Tag.ToString();
                if (!db.CheckDepartPowerByDeptSysID(DepartSysID)) return;
                if (!db.GetDepartIDAndName(DepartSysID, ref DepartID, ref DepartName)) return;
            }
               
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tvDepart_DoubleClick(object sender, EventArgs e)
        {
            btnOk.PerformClick();
        }

        private void tvDepart_AfterCheck(object sender, TreeViewEventArgs e)
        {
            SelectTreeNode(e.Node);
        }

        private void SelectDepart(TreeNode node)
        {
            string departSysID = node.Tag.ToString();
            string departID = "";
            string departName = "";
            try
            {
                if (node.Checked)
                {
                    if (!db.GetDepartIDAndName(departSysID, ref departID, ref departName)) return;
                    DepartID = DepartID + departID + ",";
                    DepartName = DepartName + departName + ",";
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
           
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                SelectDepart(node.Nodes[i]);
            }
        }
    }
}