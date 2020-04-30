using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ECard78
{
    public partial class frmSeaReportSnapShots : frmBaseMDIChildReportPrint
    {
        protected override void InitForm()
        {
            formCode = "SeaReportSnapShots";
            ReportFile = "SeaReportSnapShots";
           
            base.InitForm();
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now.Date;
            SetToolItemState("ItemDelete", true);
            SetToolItemState("ItemSelect", true);
            SetToolItemState("ItemUnSelect", true);

        }

        public frmSeaReportSnapShots()
        {
            InitializeComponent();
        }

        protected override void ExecItemRefresh()
        {
            picData.BackgroundImage = null;

            QuerySQL = Pub.GetSQL(DBCode.DB_006001, new string[] { "16",
        dtpStart.Value.ToString(SystemInfo.SQLDateFMT)+" 00:00:01", dtpEnd.Value.ToString(SystemInfo.SQLDateFMT)+" 23:59:59", OprtInfo.DepartPower });
            SetReportDate(dispView, label4.Text + ": " + dtpStart.Value.ToShortDateString() + " - " + dtpEnd.Value.ToShortDateString());
            base.ExecItemRefresh();
            SetReportTitle(dispView, this.Text);
            
        }

        protected override void GetDelSql(int rowIndex, ref List<string> sql)
        {
            string ret = Pub.GetSQL(DBCode.DB_006001, new string[] { "18", Report.FieldByName("GUID").AsString });
            sql.Add(ret);
        }

        protected override string GetDelMsg(int rowIndex)
        {
            string ret = base.GetDelMsg(rowIndex);
            ret = "[" + Report.FieldByName("GUID").AsString + "]";
            return ret;
        }

        private void dispView_SelectionCellChange(object sender, AxgrproLib._IGRDisplayViewerEvents_SelectionCellChangeEvent e)
        {
            picData.BackgroundImage = null;
            DataTableReader dr = null;
            try
            {
               
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_006001, new string[] { "17", Report.FieldByName("GUID").AsString }));
                if (dr.Read())
                {
                    if (dr["Photo"].ToString() != "")
                    {
                        byte[] buff = (byte[])(dr["Photo"]);
                        if (buff.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(buff);
                            picData.BackgroundImage = Image.FromStream(ms);
                            ms.Close();
                        }
                    }
                }

            }
            catch
            {
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
        }
    }
}