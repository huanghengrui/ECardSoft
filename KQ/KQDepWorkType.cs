using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmKQDepWorkType : frmBaseMDIChildGrid
    {
        protected override void InitForm()
        {
            formCode = "KQDepWorkType";
            dataGrid.Columns.Clear();
            AddColumn(1, "SelectCheck", false, false, 1, 60);
            AddColumn(0, "DepartID", false, 0);
            AddColumn(0, "DepartName", false, 0);
            AddColumn(0, "ShiftNo", false, 0);
            AddColumn(0, "DepOtIsHaveBar", false, 0);
            AddColumn(0, "DepIsPressed", false, 0);
            AddColumn(0, "DepRestName", false, 0);
            AddColumn(0, "WeekEndName", false, 0);
            AddColumn(0, "HolidayName", false, 0);
            AddColumn(0, "DepTimeWorkUnit", false, 0);
            AddColumn(0, "DepRestDays", false, 0);
            AddColumn(0, "GUID", true, false, 0);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            CheckForward = false;
            base.InitForm();
            ExecItemRefresh();
        }

        public frmKQDepWorkType()
        {
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmKQDepWorkTypeAdd frm = new frmKQDepWorkTypeAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            DataRowView drv = (DataRowView)bindingSource.Current;
            string GUID = drv.Row["GUID"].ToString();
            frmKQDepWorkTypeAdd frm = new frmKQDepWorkTypeAdd(this.Text, CurrentTool, GUID);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
            
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_002019, new string[] { "0", Pub.GetResText(formCode, "NormalRest", ""),
        Pub.GetResText(formCode, "TurnsoffRest", "") });
            base.ExecItemRefresh();
           
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_002019, new string[] { "3", dataGrid[11, rowIndex].Value.ToString() });
            sql.Add(ret);
           
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = dataGrid.Columns[1].HeaderText + "=" + dataGrid[1, rowIndex].Value.ToString() + "," +
              dataGrid.Columns[2].HeaderText + "=" + dataGrid[2, rowIndex].Value.ToString();
            
            return ret;
        }
    }
}