using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFAllowanceDown : frmSFMacBase
    {
        private string Title = "";
        private string CurrentOprt = "";
        private int selCount = 0;
        private string selCard = "";

        protected override void InitForm()
        {
            formCode = "SFAllowanceDown";
            QueryFlag = SystemInfo.AllDevAllowance ? 2 : 3;
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemAdd", false);
            SetToolItemState("ItemEdit", false);
            SetToolItemState("ItemDelete", false);
            SetToolItemState("ItemLine2", false);
            SetToolItemState("ItemTAG1", true);
            SetToolItemState("ItemTAG2", true);
            SetToolItemState("ItemTAG3", true);
            SetToolItemState("ItemLine3", true);
            SetToolItemState("ItemLine5", true);
            SetToolItemState("ItemFindLabel", true);
            AllowCheckOprtRole = false;
            ItemFindLabel.ForeColor = Color.Blue;
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
            msgGrid_Resize(null, null);
        }

        public frmSFAllowanceDown(string title, string CurrentTool)
        {
            Title = title;
            CurrentOprt = CurrentTool;
            InitializeComponent();
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            ExecMacOprt(0);
        }

        protected override void ExecItemTAG2()
        {
            msgGrid.Rows.Clear();
            frmSFAllowanceDownSelect frm = new frmSFAllowanceDownSelect(CurrentTool);
            if (frm.ShowDialog() != DialogResult.OK) return;
            selCount = frm.selCount;
            selCard = frm.selCard;
            if (selCount == 0)
            {
                DataTableReader dr = null;
                bool IsError = false;
                QHKS.TFeeAllowance Allowance;
                try
                {
                    if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004006, new string[] { "20", OprtInfo.DepartPower }));
                    while (dr.Read())
                    {
                        if (dr["CardSectorNo"].ToString() == "") continue;
                        Allowance = new QHKS.TFeeAllowance();
                        Allowance.CardID = dr["CardSectorNo"].ToString();
                        DateTime.TryParse(dr["AllowanceFlag"].ToString(), out Allowance.Flag);
                        Allowance.Money = 0;
                        double.TryParse(dr["AllowanceAmountSum"].ToString(), out Allowance.Money);
                        Allowance.Model = 0;
                        byte.TryParse(dr["AllowanceWay"].ToString(), out Allowance.Model);
                        if (Allowance.Model == 0 || Allowance.Model == 1 || Allowance.Model == 2)
                            Allowance.Model += 1;
                        else
                            continue;
                        Allowance.ChangeCardType = 0;
                        if (SystemInfo.AllowanceCardType) Allowance.ChangeCardType = 1;
                        Allowance.CardType = 0;
                        byte.TryParse(dr["CardTypeID"].ToString(), out Allowance.CardType);
                        DeviceObject.objKS.FeeAllowanceInit(Allowance, selCount == 0);
                        selCard = selCard + Allowance.CardID + ",";
                        selCount++;
                    }
                }
                catch (Exception E)
                {
                    IsError = true;
                    Pub.ShowErrorMsg(E);
                }
                finally
                {
                    if (dr != null) dr.Close();
                    dr = null;
                }
                if (IsError) return;
                if (selCount == 0)
                {
                    Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
                    return;
                }
            }
            base.ExecItemTAG2();
            ExecMacOprt(1);
           
        }

        protected override void ExecItemTAG3()
        {
            base.ExecItemTAG3();
            ExecMacOprt(2);
          
        }

        protected override bool ExecMacCommand(byte flag, int MacSN, ref string MacMsg)
        {
            bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
            string msg = "";
            DeviceObject.objKS.SysSetState(false);
            switch (flag)
            {
                case 0:
                    ret = SyncTime();
                    break;
                case 1:
                    ret = DeviceObject.objKS.FeeAllowanceDown(SystemInfo.MainHandle.ToInt32());
                    msg = selCard + "[" + MacSN.ToString() + "]:" + DeviceObject.objKS.ErrMsg;
                    db.WriteSYLog(this.Text, CurrentTool, msg);
                    msgGrid.Rows.Add();
                    msgGrid[0, msgGrid.RowCount - 1].Value = selCount.ToString() + "[" + MacSN.ToString() + "]:" + DeviceObject.objKS.ErrMsg;
                    msgGrid.Rows[msgGrid.RowCount - 1].Selected = true;
                    msgGrid.CurrentCell = msgGrid.Rows[msgGrid.RowCount - 1].Cells[0];
                    break;
                case 2:
                    ret = DeviceObject.objKS.FeeAllowanceClear();
                    msg = "[" + MacSN.ToString() + "]:" + DeviceObject.objKS.ErrMsg;
                    db.WriteSYLog(this.Text, CurrentTool, msg);
                    break;
            }
            DeviceObject.objKS.SysSetState(true);
          
            return ret;
        }

        private void msgGrid_Resize(object sender, EventArgs e)
        {
            Column1.Width = msgGrid.Width - 20;
        }
    }
}