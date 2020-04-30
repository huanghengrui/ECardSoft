using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFMacProductsSelect : frmBaseDialog
    {
        protected string CategoryID = "";
        protected bool Init = false;
        protected override void InitForm()
        {
            formCode = "SFMacProductsSelect";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            InitCategoryTreeView(tvAddress);

            LoadData();
        }

        public frmSFMacProductsSelect(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTableReader dr = null;
            string prodStr = "";
            string sql = "";

            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", SysID }));
                if (dr.Read()) prodStr = dr["Products"].ToString();
                if (prodStr != "")
                {
                    string[] ss = prodStr.Split(' ');
                    CategoryID = ss[0];
                    string tmp = "";
                    for (int i = 1; i < ss.Length; i++)
                    {
                        if ((ss[i] != "") && (Pub.IsNumeric(ss[i]))) tmp = tmp + ss[i] + ",";
                    }
                    if (tmp != "") tmp = tmp.Substring(0, tmp.Length - 1);
                    sql = Pub.GetSQL(DBCode.DB_004004, new string[] { "112", tmp, CategoryID });

                    //tvAddress.SelectedNode = tvAddress.Nodes[0].Nodes[int.Parse(CategoryID) - 1];
                    TreeNode fNode = findNode(tvAddress.Nodes[0], CategoryID);
                    if (fNode != null)
                    {
                        Init = true;
                        tvAddress.SelectedNode = fNode;
                    }
                }
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

        private TreeNode findNode(TreeNode treeNode,string name)
        {
            TreeNode tnRet = null;
            try
            {
                foreach (TreeNode tn in treeNode.Nodes)
                {
                    if (int.Parse(tn.Tag.ToString()) == int.Parse(name))
                    {
                        tnRet = tn;
                        break;
                    }

                    tnRet = findNode(tn, name);
                    if (tnRet != null)
                        break;
                }
            }
            catch
            {

            }
            return tnRet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectProduct(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectProduct(false);
        }

        private void SelectProduct(bool state)
        {
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                dataGrid[0, i].Value = state;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string prodStr = "";
            bool flag = false;
            prodStr = CategoryID + " ";
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue))
                {
                    prodStr += dataGrid[1, i].Value.ToString() + " ";
                    flag = true;
                }
            }
            if (!flag)
                prodStr = "";
            prodStr = prodStr.Trim();
            string sql = Pub.GetSQL(DBCode.DB_004004, new string[] { "113", prodStr, SysID });
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

        private void tvAddress_AfterCheck(object sender, TreeViewEventArgs e)
        {

        }

        private void tvAddress_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Init)
            {
                Init = false;
                return;
            }
            string sql = "";
            bindingSource.DataSource = null;
            dataGrid.Rows.Clear();
            if (tvAddress.SelectedNode.Tag == null)
                return;
            CategoryID = tvAddress.SelectedNode.Tag.ToString();

            try
            {
                sql = Pub.GetSQL(DBCode.DB_004003, new string[] { "110", CategoryID });
                bindingSource.DataSource = db.GetDataTable(sql);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E, sql);
                return;
            }
        }

        private void tvAddress_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, e.Node.Bounds);
            if (e.State == TreeNodeStates.Selected)//做判断
            {
                e.Graphics.FillRectangle(Brushes.DodgerBlue, new Rectangle(e.Node.Bounds.Left, e.Node.Bounds.Top, e.Node.Bounds.Width, e.Node.Bounds.Height));//背景色为蓝色
                RectangleF drawRect = new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width + 10, e.Bounds.Height);
                e.Graphics.DrawString(e.Node.Text, tvAddress.Font, Brushes.White, drawRect);
                //字体为白色
            }
            else
            {
                e.DrawDefault = true;
            }
        }
    }
}