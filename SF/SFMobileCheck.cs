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
    public partial class frmSFMobileCheck : frmBaseDialog
    {
        private List<TMobileInfo> UserList = new List<TMobileInfo>();
        private DateTime dtStart = new DateTime();
        private DateTime dtEnd = new DateTime();
        private bool Stop = false;
        private string StartTime = "";
        private string EndTime = "";

        protected override void InitForm()
        {
            formCode = "SFMobileCheck";
            retGrid.Columns.Clear();
            AddColumn(retGrid, 0, "RecordNo", false, true, 1, 60);
            AddColumn(retGrid, 0, "OrderNo", false, true, 1, 200);
            AddColumn(retGrid, 0, "OrderTime", false, true, 1, 130);
            AddColumn(retGrid, 0, "PayTime", false, true, 1, 130);
            AddColumn(retGrid, 1, "IsWX", false, true, 1, 70);
            AddColumn(retGrid, 0, "Amount", false, true, 1, 70);
            AddColumn(retGrid, 0, "OrderRemark", false, true, 1, 270);
            base.InitForm();
            for (int i = 0; i < retGrid.ColumnCount; i++)
            {
                retGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            dtpEnd.Value = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            if (StartTime != "")
            {
                dtpStart.Value = DateTime.Parse(StartTime);
                dtpEnd.Value = DateTime.Parse(EndTime);
            }
            dtpStart.CustomFormat = SystemInfo.DateTimeFormat;
            dtpEnd.CustomFormat = SystemInfo.DateTimeFormat;
            UserList.Clear();
            List<string> SysID = new List<string>();
            TMobileInfo info = new TMobileInfo("");
            //info.MobTyp = 1;
            //UserList.Add(info);
            DataTableReader dr = null;
            string s1 = "";
            string s2 = "";
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "0" }));
                while (dr.Read())
                {
                    SysID.Add(dr["MacSysID"].ToString());
                }
                for (int i = 0; i < SysID.Count; i++)
                {
                    dr.Close();
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "7", SysID[i] }));
                    if (dr.Read())
                    {
                        s1 = dr["MobileInfo"].ToString();
                        if (s1 == "") continue;
                        info = new TMobileInfo(s1);
                        if (UserList.Count > 0)
                        {
                            s1 = UserList[UserList.Count - 1].XJLName + UserList[UserList.Count - 1].XJLPWD;
                            s2 = info.XJLName + info.XJLPWD;
                            if (UserList[UserList.Count - 1].MobTyp == 1 && s1 != s2) UserList.Add(info);
                        }
                        else
                        {
                            UserList.Add(info);
                            i = 0;
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
            clbUserInfo.Items.Clear();
            for (int i = 0; i < UserList.Count; i++)
            {
                info = UserList[i];
                s1 = info.XJLName + "[" + info.XJLPWD + "]\r\n";
                clbUserInfo.Items.Add(s1);
                clbUserInfo.SetItemChecked(clbUserInfo.Items.Count - 1, true);
            }
        }

        public frmSFMobileCheck(string startTime, string endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!db.CheckOprtRole(formCode, "M", true)) return;
            Stop = false;

            progressBar1.Visible = true;
            CurrentOprt = btnOk.Text;
            dtStart = dtpStart.Value;
            dtEnd = dtpEnd.Value;
            lbRet.Items.Clear();
            retGrid.DataSource = null;
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("RecordNo", typeof(int));
            dtGrid.Columns.Add("OrderNo", typeof(string));
            dtGrid.Columns.Add("OrderTime", typeof(string));
            dtGrid.Columns.Add("PayTime", typeof(string));
            dtGrid.Columns.Add("IsWX", typeof(bool));
            dtGrid.Columns.Add("Amount", typeof(double));
            dtGrid.Columns.Add("OrderRemark", typeof(string));
            string StartTime = dtStart.ToString("yyyyMMddHHmmss");
            string EndTime = dtEnd.ToString("yyyyMMddHHmmss");
            string ErrMsg = "";
            int PageCount = 0;
            int RecordNo = 1;
            double money = 0.00;
            double Allmoney = 0.00;
            HSUNFK.Card objCard = new HSUNFK.Card();
            HSUNFK.TBillOrderInfo BillData = new HSUNFK.TBillOrderInfo();
            BillData.Data = new HSUNFK.TOrderInfo[20];
            TMobileInfo info;
            for (int i = 0; i < clbUserInfo.Items.Count; i++)
            {
                if (Stop) break;
                info = null;
                Allmoney = 0.00;
                if (!clbUserInfo.GetItemChecked(i)) continue;
                info = UserList[i];
                objCard.MobileInit(info.MobTyp, info.MercID, info.TrmNo, info.PWD, info.XJLName, info.XJLPWD);

                if (!objCard.BillFirst(StartTime, EndTime, ref ErrMsg, ref PageCount, ref BillData))
                {
                    if (ErrMsg == "") ErrMsg = Pub.GetResText(formCode, "CheckFail", "");
                    lbRet.Items.Add("[" + DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT) + "] " + info.XJLName + "[" + info.XJLPWD + "]" + ErrMsg);
                    continue;
                }

                if (PageCount == 0)
                {
                    if (ErrMsg == "") ErrMsg = Pub.GetResText(formCode, "NoData", "");
                    lbRet.Items.Add("[" + DateTime.Now.ToString() + "] " + info.XJLName + "[" + info.XJLPWD + "]" + ErrMsg);
                    continue;
                }
                for (int k = 0; k < BillData.Count; k++)
                {
                    if (Stop) break;
                    if (BillData.Data[k].OrderNo.Length != 32 || BillData.Data[k].OrderTime.ToOADate() == 0) continue;
                    dtGrid.Rows.Add(new object[] { RecordNo, BillData.Data[k].OrderNo, BillData.Data[k].OrderTime.ToString(SystemInfo.SQLDateTimeFMT),
            BillData.Data[k].PayTime.ToString(SystemInfo.SQLDateTimeFMT), BillData.Data[k].IsWX == 1, BillData.Data[k].Amount,
            BillData.Data[k].OrderRemark});
                    RecordNo++;
                    money = money + BillData.Data[k].Amount;
                    Allmoney = Allmoney + BillData.Data[k].Amount;
                    lbCount.Text = string.Format("[{0}][{1}][{2}][{3}][{4}][{5}]", (RecordNo - 1).ToString(),
                           BillData.Data[k].OrderRemark, BillData.Data[k].OrderNo, BillData.Data[k].PayTime.ToString(SystemInfo.SQLDateTimeFMT),
                           BillData.Data[k].Amount.ToString(SystemInfo.CurrencySymbol + "0.00"), money.ToString(SystemInfo.CurrencySymbol + "0.00"));
                    Application.DoEvents();
                }
                for (int j = 2; j <= PageCount; j++)
                {
                    if (objCard.BillNext(StartTime, EndTime, j, ref ErrMsg, ref BillData))
                    {
                        for (int k = 0; k < BillData.Count; k++)
                        {

                            if (BillData.Data[k].OrderNo.Length != 32 || BillData.Data[k].OrderTime.ToOADate() == 0) continue;
                            dtGrid.Rows.Add(new object[] { RecordNo, BillData.Data[k].OrderNo, BillData.Data[k].OrderTime.ToString(SystemInfo.SQLDateTimeFMT),
                BillData.Data[k].PayTime.ToString(SystemInfo.SQLDateTimeFMT), BillData.Data[k].IsWX == 1, BillData.Data[k].Amount,
                BillData.Data[k].OrderRemark });
                            if (Stop) break;
                            RecordNo++;
                            money = money + BillData.Data[k].Amount;
                            Allmoney = Allmoney + BillData.Data[k].Amount;
                            lbCount.Text = string.Format("[{0}][{1}][{2}][{3}][{4}][{5}]", (RecordNo - 1).ToString(),
                                BillData.Data[k].OrderRemark, BillData.Data[k].OrderNo, BillData.Data[k].PayTime.ToString(SystemInfo.SQLDateTimeFMT),
                                BillData.Data[k].Amount.ToString(SystemInfo.CurrencySymbol + "0.00"), money.ToString(SystemInfo.CurrencySymbol + "0.00"));
                            Application.DoEvents();
                        }
                        if (Stop) break;
                    }
                    else
                    {
                        if (ErrMsg == "") ErrMsg = Pub.GetResText(formCode, "CheckFail", "");
                        lbRet.Items.Add("[" + DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT) + "] " + info.XJLName + "[" + info.XJLPWD + "]" + ErrMsg);
                    }
                }
                lbRet.Items.Add("[" + DateTime.Now.ToString(SystemInfo.SQLDateTimeFMT) + "] " +
                    "[" + BillData.Data[0].OrderRemark + "] " + info.XJLName + " [" + info.XJLPWD + "] " + Allmoney.ToString(SystemInfo.CurrencySymbol + "0.00"));
            }
            try
            {
                retGrid.DataSource = dtGrid;
                if (retGrid.RowCount > 0)
                {
                    retGrid.Rows[0].Selected = true;
                    retGrid.CurrentCell = retGrid.Rows[0].Cells[0];
                }
                progressBar1.Visible = false;
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!db.CheckOprtRole(formCode, "M", true)) return;
            if (retGrid.Rows.Count == 0) return;
            CurrentOprt = btnOk.Text;
            progressBar1.Visible = true;
            int SFType = 0;
            string SFDate = "";
            string CZAmount = "";
            string MacSN = "";
            string TradeNo = "";
            string IsWin = "";
            int Count = 0;
            string msg = "";
            double money = 0.00;
            double Allmoney = 0.00;
            //int macsn = 0;
            string MacPhysicsAddress = "";
            List<string> sql = new List<string>();
            DataRow dr = null;
            //DataTableReader drt = null;
            DataTable dt = (DataTable)retGrid.DataSource;
            sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "16", dtStart.ToString(SystemInfo.SQLDateTimeFMT),
              dtEnd.ToString(SystemInfo.SQLDateTimeFMT) }));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Application.DoEvents();
                dr = dt.Rows[i];
                SFDate = dr["OrderTime"].ToString();
                CZAmount = dr["Amount"].ToString();
                money = -double.Parse(CZAmount);
                MacSN = dr["OrderRemark"].ToString();
                TradeNo = dr["OrderNo"].ToString();
                IsWin = dr["IsWX"].ToString();
                MacPhysicsAddress = dr["OrderNo"].ToString().Substring(0, 16);
                if (IsWin == "True")
                    SFType = 0;
                else
                    SFType = 1;
                if (/*IsNumeric(MacSN) && !string.IsNullOrEmpty(MacSN) &&*/ MacSN.Length <= 5)
                {
                    //drt = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "11", MacPhysicsAddress }));//当数据库的序列号是空的时候根据机器号获取序列号
                    //if (!drt.Read())
                    //{
                    //    macsn = int.Parse(MacSN);
                    //    string sqls = Pub.GetSQL(DBCode.DB_004004, new string[] { "10", MacPhysicsAddress, macsn.ToString() });
                    //    db.ExecSQL(sqls);
                    //}

                    sql.Add(Pub.GetSQL(DBCode.DB_004005, new string[] { "10", SFType.ToString(),
              SFDate, money.ToString(), MacSN.ToString(),
             "", TradeNo, 0.ToString(),0.ToString(), OprtInfo.OprtSysID}));
                    Count++;
                    Allmoney = Allmoney + double.Parse(CZAmount);
                    lbCount.Text = string.Format("[{0}][{1}][{2}][{3}][{4}]", i + 1, MacSN, TradeNo, SFDate, Allmoney.ToString(SystemInfo.CurrencySymbol + "0.00"));
                    Application.DoEvents();
                }

                //if (string.IsNullOrEmpty(MacSN)) //当备注是空的时候根据订单号获取机器号
                //{ 
                //    drt = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "11", MacPhysicsAddress }));
                //    if (drt.Read())
                //    {
                //        MacSN = drt["MacSN"].ToString();
                //        sql.Add( Pub.GetSQL(DBCode.DB_004005, new string[] { "10", SFType.ToString(),
                //         SFDate, money.ToString(), MacSN.ToString(),
                //        "", TradeNo, 0.ToString(),0.ToString(), OprtInfo.OprtSysID}));
                //         Count++;
                //         Allmoney =Allmoney + double.Parse(CZAmount);
                //        lbCount.Text = string.Format("[{0}][{1}][{2}][{3}][{4}]",i+1,MacSN,TradeNo,SFDate,Allmoney.ToString(SystemInfo.CurrencySymbol + "0.00"));
                //         Application.DoEvents();
                //    } 
                //}
                msg = money.ToString(SystemInfo.CurrencySymbol + "0.00");
            }
            db.ExecSQL(sql);
            //progressBar1.Visible = false;
            db.WriteSYLog(this.Text, Pub.GetResText("SFMacParam", "button10", ""), msg);

            retGrid.DataSource = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool IsNumeric(string str) //接收一个string类型的参数,保存到str里
        {
            if (str == null || str.Length == 0)    //验证这个参数是否为空
                return false;                           //是，就返回False
            ASCIIEncoding ascii = new ASCIIEncoding();//new ASCIIEncoding 的实例
            byte[] bytestr = ascii.GetBytes(str);         //把string类型的参数保存到数组里

            foreach (byte c in bytestr)                   //遍历这个数组里的内容
            {
                if (c < 48 || c > 57)                          //判断是否为数字
                {
                    return false;                              //不是，就返回False
                }
            }
            return true;                                        //是，就返回True
        }

        private void lblUserInfo_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < UserList.Count; i++)
            {
                clbUserInfo.SetItemChecked(i, lblUserInfo.Checked);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}