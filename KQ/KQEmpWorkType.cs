using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmKQEmpWorkType : frmBaseMDIChildGrid
    {
        protected override void InitForm()
        {
            formCode = "KQEmpWorkType";
            dataGrid.Columns.Clear();
            AddColumn(1, "SelectCheck", false, false, 1, 60);
            AddColumn(0, "EmpNo", false, 0);
            AddColumn(0, "EmpName", false, 0);
            AddColumn(0, "DepartID", false, 0);
            AddColumn(0, "DepartName", false, 0);
            AddColumn(0, "ShiftNo", false, 0);
            AddColumn(0, "EmpOtIsHaveBar", false, 0);
            AddColumn(0, "EmpIsPressed", false, 0);
            AddColumn(0, "EmpRestName", false, 0);
            AddColumn(0, "WeekEndName", false, 0);
            AddColumn(0, "HolidayName", false, 0);
            AddColumn(0, "EmpTimeWorkUnit", false, 0);
            AddColumn(0, "EmpRestDays", false, 0);
            AddColumn(0, "GUID", true, false, 0);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            CheckForward = false;
            base.InitForm();
            ExecItemRefresh();
        }

        public frmKQEmpWorkType()
        {
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmKQEmpWorkTypeAdd frm = new frmKQEmpWorkTypeAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            DataRowView drv = (DataRowView)bindingSource.Current;
            string GUID = drv.Row["GUID"].ToString();
            frmKQEmpWorkTypeAdd frm = new frmKQEmpWorkTypeAdd(this.Text, CurrentTool, GUID);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
            
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_002018, new string[] { "0", Pub.GetResText(formCode, "NormalRest", ""),
        Pub.GetResText(formCode, "TurnsoffRest", "") });
            base.ExecItemRefresh();
           
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_002018, new string[] { "3", dataGrid[13, rowIndex].Value.ToString() });
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