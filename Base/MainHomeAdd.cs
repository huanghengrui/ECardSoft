using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmMainHomeAdd : frmBaseDialog
    {
        private int defValue = 0xffff;

        private void AddSub(string Module, string SubName)
        {
            funcGrid.Rows.Add();
            funcGrid[0, funcGrid.RowCount - 1].Value = Pub.GetResText("MainHome", "BasicInfo", "");
            funcGrid[1, funcGrid.RowCount - 1].Value = Pub.GetResText("MainHome", SubName, "");
            funcGrid[2, funcGrid.RowCount - 1].Value = false;
            funcGrid[3, funcGrid.RowCount - 1].Value = defValue;
            funcGrid[4, funcGrid.RowCount - 1].Value = Module.Substring(3);
            funcGrid[5, funcGrid.RowCount - 1].Value = SubName.Substring(3);
        }

        private void AddRSCardOprter(string item)
        {
            string s = "";
            switch (item)
            {
                case "0"://·¢¿¨
                    s = Pub.GetResText("RSEmp", "ItemTAG1", "");
                    break;
                case "1"://¹ÒÊ§µÇ¼Ç
                    s = Pub.GetResText("RSEmp", "ItemTAG2", "");
                    break;
                case "2"://½â¹ÒµÇ¼Ç
                    s = Pub.GetResText("RSEmp", "ItemTAG3", "");
                    break;
                case "3"://»»¿¨
                    s = Pub.GetResText("RSEmp", "ItemTAG4", "");
                    break;
                case "4"://ÍË¿¨
                    s = Pub.GetResText("RSEmp", "ItemTAG5", "");
                    break;
                case "5"://¿¨Æ¬ÐÞ¸´
                    s = Pub.GetResText("RSEmp", "ItemTAG6", "");
                    break;
                case "6"://²é¿¨
                    s = Pub.GetResText("RSEmp", "ItemTAG7", "");
                    break;
                case "7"://¸Ä¿¨
                    s = Pub.GetResText("RSEmp", "CardModify", "");
                    break;
                case "8"://ºÚÃûµ¥
                    s = Pub.GetResText("RSEmp", "ItemCardBlack", "");
                    break;
            }
            funcGrid.Rows.Add();
            funcGrid[0, funcGrid.RowCount - 1].Value = Pub.GetResText("MainHome", "CardInfo", "");
            funcGrid[1, funcGrid.RowCount - 1].Value = s;
            funcGrid[2, funcGrid.RowCount - 1].Value = false;
            funcGrid[3, funcGrid.RowCount - 1].Value = defValue;
            funcGrid[4, funcGrid.RowCount - 1].Value = "RSCardOprter";
            funcGrid[5, funcGrid.RowCount - 1].Value = item;
        }

        protected override void InitForm()
        {
            formCode = "MainHomeAdd";
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            FuncObject funcObj;
            FuncSubObject funcSubObj;
            funcGrid.Rows.Clear();
            if ((SysID == "1") || (SysID == "2"))
            {
                AddSub("mnuSY", "mnuSYPower");
                AddSub("mnuSY", "mnuSYDevice");
                AddSub("mnuSY", "mnuSYOption");
                AddSub("mnuSY", "mnuSYAuto");
                for (int i = 0; i < SystemInfo.funcList.Count; i++)
                {
                    funcObj = SystemInfo.funcList[i];
                    if (funcObj.Name == "RS")
                    {
                        for (int j = 0; j < funcObj.SubCount; j++)
                        {
                            funcSubObj = funcObj.SubGet(j);
                            if (funcSubObj.IsLine != 2)
                            {
                                funcGrid.Rows.Add();
                                funcGrid[0, funcGrid.RowCount - 1].Value = Pub.GetResText("MainHome", "BasicInfo", "");
                                funcGrid[1, funcGrid.RowCount - 1].Value = funcSubObj.Text;
                                funcGrid[2, funcGrid.RowCount - 1].Value = false;
                                funcGrid[3, funcGrid.RowCount - 1].Value = defValue;
                                funcGrid[4, funcGrid.RowCount - 1].Value = funcObj.Name;
                                funcGrid[5, funcGrid.RowCount - 1].Value = funcSubObj.Name;
                            }
                        }
                        break;
                    }
                }
            }
            if (((SysID == "1") || (SysID == "3")) && SystemInfo.HasFaCard)
            {
                for (int i = 0; i <= 8; i++) AddRSCardOprter(i.ToString());
            }
            if ((SysID != "2") && (SysID != "3"))
            {
                for (int i = 0; i < SystemInfo.funcList.Count; i++)
                {
                    funcObj = SystemInfo.funcList[i];
                    if (funcObj.Name == "RS") continue;
                    if ((SysID == "4") && (funcObj.Name != "KQ")) continue;
                    if ((SysID == "5") && (funcObj.Name != "MJ")) continue;
                    if ((SysID == "6") && (funcObj.Name != "SF")) continue;
                    if ((SysID == "7") && (funcObj.Name != "SK")) continue;
                    if ((SysID == "8") && (funcObj.Name != "SEA")) continue;
                    for (int j = 0; j < funcObj.SubCount; j++)
                    {
                        funcSubObj = funcObj.SubGet(j);
                        if (funcSubObj.IsLine != 2)
                        {
                            funcGrid.Rows.Add();
                            funcGrid[0, funcGrid.RowCount - 1].Value = funcObj.Text;
                            funcGrid[1, funcGrid.RowCount - 1].Value = funcSubObj.Text;
                            funcGrid[2, funcGrid.RowCount - 1].Value = false;
                            funcGrid[3, funcGrid.RowCount - 1].Value = defValue;
                            funcGrid[4, funcGrid.RowCount - 1].Value = funcObj.Name;
                            funcGrid[5, funcGrid.RowCount - 1].Value = funcSubObj.Name;
                        }
                    }
                }
            }
            funcGrid.MergeColumnNames.Add("Column1");
            LoadData();
            funcGrid.Columns[2].ReadOnly = false;
            funcGrid.Columns[3].ReadOnly = false;
        }

        public frmMainHomeAdd(string title, string CurrentTool, string GUID)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            SysID = GUID;
            InitializeComponent();
        }

        private bool FindItem(string SubID, string IniSection)
        {
            bool ret = false;
            string item = "";
            int num = 1;
            do
            {
                item = SystemInfo.webIni.ReadIni(IniSection, num.ToString("000000"), "");
                if (item != "")
                {
                    if (SubID == item)
                    {
                        ret = true;
                        break;
                    }
                    num++;
                }
            }
            while (item != "");
            return ret;
        }

        private bool FindItem(string SubID)
        {
            bool ret = false;
            switch (SysID)
            {
                case "2":
                    ret = FindItem(SubID, "BasicInfo");
                    break;
                case "3":
                    ret = FindItem(SubID, "CardInfo");
                    break;
                case "4":
                    switch (SystemInfo.KQFlag)
                    {
                        case 0:
                            ret = FindItem(SubID, "KQ");
                            break;
                        case 1:
                            ret = FindItem(SubID, "KQFinger");
                            break;
                        case 2:
                            ret = FindItem(SubID, "KQAll");
                            break;
                        case 3:
                            ret = FindItem(SubID, "KQNo");
                            break;
                    }
                    break;
                case "5":
                    ret = FindItem(SubID, "MJ");
                    break;
                case "6":
                    if (SystemInfo.SFCardDRMode)
                        ret = FindItem(SubID, "SFRef");
                    else
                        ret = FindItem(SubID, "SF");
                    break;
                case "7":
                    ret = FindItem(SubID, "SK");
                    break;
                case "8":
                    ret = FindItem(SubID, "SEA");
                    break;
            }
            return ret;
        }

        private void LoadData()
        {
            DataTable dt = null;
            string ModuleID;
            string SubID;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_000002, new string[] { "301", OprtInfo.OprtSysID, SysID }));
                if (dt.Rows.Count == 0)
                {
                    if (SysID != "1")
                    {
                        int no = 1;
                        for (int i = 0; i < funcGrid.RowCount; i++)
                        {
                            if (FindItem(funcGrid[5, i].Value.ToString()))
                            {
                                funcGrid[2, i].Value = true;
                                funcGrid[3, i].Value = no;
                                no++;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ModuleID = dt.Rows[i]["ModuleID"].ToString();
                        SubID = dt.Rows[i]["SubID"].ToString();
                        for (int j = 0; j < funcGrid.RowCount; j++)
                        {
                            if ((ModuleID == funcGrid[4, j].Value.ToString()) && (SubID == funcGrid[5, j].Value.ToString()))
                            {
                                funcGrid[2, j].Value = true;
                                funcGrid[3, j].Value = Convert.ToInt32(dt.Rows[i]["No"].ToString());
                                break;
                            }
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
                if (dt != null)
                {
                    dt.Clear();
                    dt.Dispose();
                }
            }
            SortGridOrder();
        }

        private void funcGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private bool FindSameNo(int no, int index)
        {
            bool ret = false;
            int v1 = Convert.ToInt32(funcGrid[3, index].Value);
            int v2 = 0;
            for (int i = 0; i < funcGrid.RowCount; i++)
            {
                if (i == index) continue;
                if (Pub.ValueToBool(funcGrid[2, i].Value))
                {
                    v2 = Convert.ToInt32(funcGrid[3, i].Value);
                    if (v1 == v2)
                    {
                        ret = true;
                        break;
                    }
                }
            }
            return ret;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<string> sql = new List<string>();
            cbbOrder.Items.Clear();
            THomeOrder order;
            int maxNo = 0;
            for (int i = 0; i < funcGrid.RowCount; i++)
            {
                if (Pub.ValueToBool(funcGrid[2, i].Value))
                {
                    int n = 0;
                    int.TryParse(funcGrid[3, i].Value.ToString(), out n);
                    if ((n < 0) || (n > defValue)) n = 0;
                    if ((n > maxNo) && (n != defValue)) maxNo = n;
                }
            }
            for (int i = 0; i < funcGrid.RowCount; i++)
            {
                if (Pub.ValueToBool(funcGrid[2, i].Value))
                {
                    int n = 0;
                    int.TryParse(funcGrid[3, i].Value.ToString(), out n);
                    if ((n < 0) || (n > defValue)) n = 0;
                    if ((n > maxNo) && (n != defValue)) maxNo = n;
                    if ((n > 0) && (n < defValue))
                    {
                        if (FindSameNo(n, i))
                        {
                            ShowErrorCannotRepeated(funcGrid.Columns[3].HeaderText);
                            return;
                        }
                    }
                    if ((n == 0) || (n == defValue))
                    {
                        n = maxNo + 1;
                        maxNo = n;
                    }
                    order = new THomeOrder(funcGrid[4, i].Value.ToString(), funcGrid[5, i].Value.ToString(), n);
                    cbbOrder.Items.Add(order);
                }
            }
            sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "302", OprtInfo.OprtSysID, SysID }));
            for (int i = 1; i <= cbbOrder.Items.Count; i++)
            {
                order = (THomeOrder)cbbOrder.Items[i - 1];
                sql.Add(Pub.GetSQL(DBCode.DB_000002, new string[] { "303", OprtInfo.OprtSysID, SysID, order.ModuleID,
          order.SubID, i.ToString(), "1" }));
            }
            if (db.ExecSQL(sql) != 0) return;
            Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void funcGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string v = funcGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                v = Pub.IsNumeric(v) ? v : "0";
                v = Convert.ToInt32(v) < 0 ? "0" : v;
                v = Convert.ToInt32(v) > defValue ? "0" : v;
                funcGrid[e.ColumnIndex, e.RowIndex].Value = Convert.ToInt32(v);
                SortGridOrder();
                funcGrid[2, e.RowIndex].Value = true;
            }
        }

        private void SortGridOrder()
        {
            try
            {
                funcGrid.Sort(funcGrid.Columns[3], ListSortDirection.Ascending);
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectModule(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectModule(false);
        }

        private void SelectModule(bool state)
        {
            for (int i = 0; i < funcGrid.RowCount; i++)
            {
                funcGrid[2, i].Value = state;
            }
        }
    }

    public class THomeOrder
    {
        private string _module;
        private string _sub;
        private int _no;

        public THomeOrder(string moduleID, string subID, int no)
        {
            _module = moduleID;
            _sub = subID;
            _no = no;
        }

        public string ModuleID
        {
            get { return _module; }
            set { _module = value; }
        }

        public string SubID
        {
            get { return _sub; }
            set { _sub = value; }
        }

        public int No
        {
            get { return _no; }
            set { _no = value; }
        }

        public override string ToString()
        {
            return _no.ToString("000000");
        }
    }
}