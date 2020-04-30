using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmKQShift : frmBaseMDIChildGrid
    {
        protected override void InitForm()
        {
            formCode = "KQShift";
            dataGrid.Columns.Clear();
            AddColumn(0, "GUID", true, false, 0);
            AddColumn(0, "ShiftNo", false, 80);
            AddColumn(0, "ShiftName", false, 100);
            AddColumn(0, "InTime1Str", false, false, 1, 80);
            AddColumn(0, "OutTime1Str", false, false, 1, 80);
            AddColumn(0, "InTime2Str", false, false, 1, 80);
            AddColumn(0, "OutTime2Str", false, false, 1, 80);
            AddColumn(0, "InTime3Str", false, false, 1, 80);
            AddColumn(0, "OutTime3Str", false, false, 1, 80);
            AddColumn(0, "InTime4Str", false, false, 1, 80);
            AddColumn(0, "OutTime4Str", false, false, 1, 80);
            AddColumn(0, "InTime5Str", false, false, 1, 80);
            AddColumn(0, "OutTime5Str", false, false, 1, 80);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            IgnoreSelect = true;
            CheckForward = false;
            base.InitForm();
            ExecItemRefresh();
        }

        public frmKQShift()
        {
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmKQShiftAdd frm = new frmKQShiftAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
            
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            DataRowView drv = (DataRowView)bindingSource.Current;
            string GUID = drv.Row["GUID"].ToString();
            frmKQShiftAdd frm = new frmKQShiftAdd(this.Text, CurrentTool, GUID);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_002003, new string[] { "0" });
            base.ExecItemRefresh();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_002003, new string[] { "3", dataGrid[0, rowIndex].Value.ToString() });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString() + "," +
              dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
            return ret;
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            if (bindingSource.Count > 0)
            {
                DataRowView drv = (DataRowView)bindingSource.Current;
                string No = "";
                No = drv.Row["ShiftNo"].ToString().ToUpper();
                ItemEdit.Enabled = ItemEdit.Enabled && ((No != "REST") && (No != "NULL"));
                ItemDelete.Enabled = ItemDelete.Enabled && ((No != "REST") && (No != "NULL"));
                SetContextMenuState();
            }
        }

        protected override bool CheckDelete(int rowIndex)
        {
            bool ret = base.CheckDelete(rowIndex);
            string No = dataGrid[1, rowIndex].Value.ToString().ToUpper();
            if ((No == "REST") || (No == "NULL"))
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                return false;
            }
            DataTableReader dr = null;
            try
            {
                for (int i = 7; i <= 12; i++)
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002003, new string[] { i.ToString(), No }));
                    if (dr.Read())
                    {
                        ret = Convert.ToInt32(dr[0].ToString()) == 0;
                        if (!ret)
                        {
                            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error002", ""));
                            break;
                        }
                    }
                    dr.Close();
                }
            }
            catch (Exception E)
            {
                ret = false;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            return ret;
        }
    }
}