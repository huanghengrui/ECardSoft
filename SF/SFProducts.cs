using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFProducts : frmBaseMDIChildReport
    {
        protected override void InitForm()
        {
            formCode = "SFProducts";
            ReportFile = "SFProducts";
            ReportStartIndex = 3;
            base.InitForm();
            ImportFieldList = new string[] { "CategoryID", "CategoryName", "ProductsID", "ProductsName", "ProductsPrice" };
            SetToolItemState("ItemTAG1", true);
            //SetToolItemState("ItemTAG2", true);
            ExecItemRefresh();
        }

        public frmSFProducts()
        {
            InitializeComponent();
        }

        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            frmSFProductsAdd frm = new frmSFProductsAdd(this.Text, CurrentTool, "");
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
           
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            string GUID = GetSysID();
            frmSFProductsAdd frm = new frmSFProductsAdd(this.Text, CurrentTool, GUID);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
          
        }

        protected override void ExecItemRefresh()
        {
            QuerySQL = Pub.GetSQL(DBCode.DB_004003, new string[] { "0" });
            base.ExecItemRefresh();
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            string GUID = GetSysID();
            frmSFPlate frm = new frmSFPlate(this.Text, CurrentTool, GUID, false);
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();

        }

        //protected override void ExecItemTAG2()
        //{
        //    base.ExecItemTAG2();
        //    //List<string> sysID = new List<string>();
        //    //Report.DetailGrid.Recordset.First();
        //    //while (!Report.DetailGrid.Recordset.Eof())
        //    //{
        //    //    if (Report.FieldByName("Checked").AsInteger == (int)grproLib.GRSystemImage.grsi3DChecked)
        //    //    {
        //    //        guid = Report.FieldByName("GUID").AsString;
        //    //        sysID.Add(guid);
        //    //    }
        //    //    Report.DetailGrid.Recordset.Next();
        //    //}
        //    string GUID = GetSysID();
        //    frmSFPlate frm = new frmSFPlate(this.Text, CurrentTool, GUID, false);
        //    if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();

        //}

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string GUID = GetSysID();
            string ret = Pub.GetSQL(DBCode.DB_004003, new string[] { "3", GUID });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = Pub.GetResText(formCode, "ProductsID", "") + "=" + Report.FieldByName("ProductsID").AsString + "," +
              Pub.GetResText(formCode, "ProductsName", "") + "=" + Report.FieldByName("ProductsName").AsString;
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
            int ProductsID = 0;
            string ProductsName = "";
            double ProductsPrice = 0;
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
                    case "ProductsID":
                        ProductsID = 0;
                        int.TryParse(row[src[i]].ToString(), out ProductsID);
                        break;
                    case "ProductsName":
                        ProductsName = row[src[i]].ToString().Trim();
                        break;
                    case "ProductsPrice":
                        ProductsPrice = 0;
                        double.TryParse(CurrencyToStringEx(row[src[i]].ToString()), out ProductsPrice);
                        break;
                }
            }
            if ((ProductsID < 1) || (ProductsID > 9999))
            {
                ErrorMsg = Pub.GetResText(formCode, "Error001", "");
                return false;
            }
            if (ProductsName == "")
            {
                ErrorMsg = Pub.GetResText(formCode, "Error002", "");
                return false;
            }
            if (ProductsPrice <= 0)
            {
                ErrorMsg = Pub.GetResText(formCode, "Error003", "");
                return false;
            }
            bool IsError = false;
            DataTableReader dr = null;
            string sql = "";
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "5", ProductsID.ToString(), CategoryID.ToString() }));
                if (!dr.Read())
                {
                    dr.Close();
                    sql = Pub.GetSQL(DBCode.DB_004003, new string[] { "1", ProductsID.ToString(), ProductsName,
            ProductsPrice.ToString(),CategoryID.ToString(),CategoryName });
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