using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFDishCategorys : frmBaseMDIChildReport
    {
        protected override void InitForm()
        {
            formCode = "SFDishCategorys";
            ReportFile = "SFDishCategorys";
            ReportStartIndex = 3;
            base.InitForm();
            ImportFieldList = new string[] { "ProductsID", "ProductsName", "ProductsPrice" };
            ExecItemRefresh();
        }

        public frmSFDishCategorys()
        {
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmSFDishCategorysAdd frm = new frmSFDishCategorysAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            string GUID = GetSysID();
            frmSFDishCategorysAdd frm = new frmSFDishCategorysAdd(this.Text, CurrentTool, GUID);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
          
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_004003, new string[] { "102" });
            base.ExecItemRefresh();
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string GUID = GetSysID();
            string ret = Pub.GetSQL(DBCode.DB_004003, new string[] { "105", GUID });
            sql.Add(ret);
        }

        protected override bool GetProduts(ref string CategoryID)
        {
            bool ret = false;
            DataTableReader dr = null;
            CategoryID = Report.FieldByName("CategoryID").AsString;
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "110", CategoryID }));
            if (dr.Read())
                ret = true;
            return ret;

        }

        protected override bool GetProdutsID(ref string CategoryID)
        {
            bool ret = false;
            CategoryID = Report.FieldByName("CategoryID").AsString;
            if (CategoryID == "1")
                ret = true;
            return ret;

        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = Pub.GetResText(formCode, "CategoryID", "") + "=" + Report.FieldByName("CategoryID").AsString + "," +
              Pub.GetResText(formCode, "CategoryName", "") + "=" + Report.FieldByName("CategoryName").AsString;
            return ret;
        }

        private string GetSysID()
        {
            return Report.FieldByName("GUID").AsString;
        }

        public override bool ProcessImportData(DataRow row, List<string> sys, List<string> src, string DepartUpSysID,
          ref string ErrorMsg, ref double Sum)
        {
            bool ret = base.ProcessImportData(row, sys, src, DepartUpSysID, ref ErrorMsg, ref Sum);
            int CategoryID = 0;
            string CategoryName = "";

            for (int i = 0; i < sys.Count; i++)
            {
                switch (sys[i])
                {
                    case "CategoryID":
                        CategoryID = 0;
                        int.TryParse(row[src[i]].ToString(), out CategoryID);
                        break;
                    case "CategoryName":
                        CategoryName = row[src[i]].ToString().Trim();
                        break;
                }
            }
            if ((CategoryID < 1) || (CategoryID > 9999))
            {
                ErrorMsg = Pub.GetResText(formCode, "Error001", "");
                return false;
            }
            if (CategoryName == "")
            {
                ErrorMsg = Pub.GetResText(formCode, "Error002", "");
                return false;
            }
            bool IsError = false;
            DataTableReader dr = null;
            string sql = "";
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "107", CategoryID.ToString() }));
                if (!dr.Read())
                {
                    dr.Close();
                    sql = Pub.GetSQL(DBCode.DB_004003, new string[] { "103", CategoryID.ToString(), CategoryName });
                    db.ExecSQL(sql);
                }
                else
                {
                    ErrorMsg = Pub.GetResText(formCode, "Error004", "");
                    return false;
                }
            }
            catch (Exception E)
            {
                IsError = true;
                Pub.ShowErrorMsg(E, sql);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsError) return false;
            db.WriteSYLog(this.Text, CurrentTool, sql);
          
            return ret;
        }
    }
}