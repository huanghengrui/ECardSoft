using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QHKS;

namespace ECard78
{
    public partial class frmKQMessage : frmKQMacBase
    {
        private List<TAttMessageReg> messageList = new List<TAttMessageReg>();
        private string downMsg = "";
        private int downCount = 0;

        protected override void InitForm()
        {
            formCode = "KQMessage";
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
            SetToolItemState("ItemLine3", true);
            CreateCardGridView(cardGrid);
            base.InitForm();
            lblQuickSearchToolTip.ForeColor = Color.Blue;
        }

        public frmKQMessage()
        {
            InitializeComponent();
        }

        protected override void ExecItemTAG1()
        {
            if (!InitMessageList()) return;
            base.ExecItemTAG1();
            ExecMacOprt(0);
           
        }

        protected override void ExecItemTAG2()
        {
            if (!InitMessageList()) return;
            base.ExecItemTAG2();
            ExecMacOprt(1);
           
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            pnlCard.Enabled = State;
            
        }

        protected override bool ExecMacCommand(byte flag, int MacSN, ref string MacMsg)
        {
            bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
            TAttMessageReg msgReg;
            string msg;
            DeviceObject.objKS.SysSetState(false);
            if (flag == 0)
            {
                ret = DeviceObject.objKS.AttMessageDown(SystemInfo.MainHandle.ToInt32());
            }
            else
            {
                for (int i = 0; i < messageList.Count; i++)
                {
                    msgReg = messageList[i];
                    ret = DeviceObject.objKS.AttMessageDel(msgReg.CardID);
                    msg = GetMacMsg(MacSN) + "[" + msgReg.CardID + "]:" + DeviceObject.objKS.ErrMsg;
                    db.WriteSYLog(this.Text, CurrentTool, msg);
                    if (!ret) break;
                }
            }
            DeviceObject.objKS.SysSetState(true);
           
            return ret;
        }

        private bool InitMessageList()
        {
            TAttMessageReg MessageReg;
            messageList.Clear();
            downMsg = "";
            downCount = 0;
            if (cardGrid.DataSource != null)
            {
                DataTable dtGrid = (DataTable)cardGrid.DataSource;
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    MessageReg = new TAttMessageReg();
                    if (SystemInfo.CardType == 0)
                        MessageReg.CardID = dtGrid.Rows[i]["CardSectorNo"].ToString();
                    else
                        MessageReg.CardID = dtGrid.Rows[i]["CardPhysicsNo10"].ToString();
                    MessageReg.Message = txtMessage.Text;
                    messageList.Add(MessageReg);
                    DeviceObject.objKS.AttMessageInit(MessageReg, downCount == 0);
                    downMsg = downMsg + MessageReg.CardID + ",";
                    downCount++;
                }
            }
            if (messageList.Count == 0)
            {
                Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
            }
            
            return messageList.Count > 0;
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            QuickSearchNormalCard(btnQuickSearch.Text, cardGrid);
        }

        private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {
            QuickSearchNormalCard(txtQuickSearch, e, cardGrid);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cardGrid.DataSource = null;
        }
    }
}