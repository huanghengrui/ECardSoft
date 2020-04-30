using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmMJMacFirstOpenDoor : frmMJMacDoorBase
    {
        protected override void InitForm()
        {
            formCode = "MJMacFirstOpenDoor";
            ExtField.Add("IsFirstCard");
            ExtField.Add("MacFirstCard");
            HideExtField = 1;
            base.InitForm();
        }

        public frmMJMacFirstOpenDoor()
        {
            InitializeComponent();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmMJMacFirstOpenDoorEdit frm = new frmMJMacFirstOpenDoorEdit(this.Text, CurrentTool, GetMacDoorSysID());
            if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
        }

        protected override void ExecItemTAG1()
        {
            base.ExecItemTAG1();
            ExecMacDoorOprt(0);
        }

        protected override bool ExecMacDoorCommand(byte flag, TMJDoorInfo doorInfo, ref string MacMsg)
        {
            bool ret = base.ExecMacDoorCommand(flag, doorInfo, ref MacMsg);
            bool IsError = false;
            int Index = 0;
            UInt32 cardNo = 0;
            switch (flag)
            {
                case 0:
                    AccessV2API.TYPE_DoorExpert_First cardInfo = new AccessV2API.TYPE_DoorExpert_First();
                    cardInfo.CardNo = new UInt32[10];
                    cardInfo.WeekConfig = new byte[8];
                    if (doorInfo.ExtField[0] == "Y")
                    {
                        TMacFirstCard card = new TMacFirstCard(doorInfo.ExtField[1]);
                        cardInfo.InsideMode = card.Way[0];
                        cardInfo.OutsideMode = card.Way[1];
                        for (int i = 0; i < 7; i++)
                        {
                            if(card.Week[i]==0)
                                cardInfo.WeekConfig[i] = 1;
                            else
                                cardInfo.WeekConfig[i] = 0;
                        }
                        if (card.StartTime.Length == 5)
                        {
                            cardInfo.TimeBegin.wHour = Convert.ToUInt16(card.StartTime.Substring(0, 2));
                            cardInfo.TimeBegin.wMinute = Convert.ToUInt16(card.StartTime.Substring(3, 2));
                        }
                        if (card.EndTime.Length == 5)
                        {
                            cardInfo.TimeEnd.wHour = Convert.ToUInt16(card.EndTime.Substring(0, 2));
                            cardInfo.TimeEnd.wMinute = Convert.ToUInt16(card.EndTime.Substring(3, 2));
                        }
                        if (card.EmpList != "")
                        {
                            DataTableReader dr = null;
                            try
                            {
                                string sql = "";
                                if (SystemInfo.HasFaCard)
                                    sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "108", card.EmpList });
                                else
                                    sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "301", card.EmpList });
                                dr = db.GetDataReader(sql);
                                while (dr.Read())
                                {
                                    UInt32.TryParse(dr["OtherCardNo"].ToString(), out cardNo);
                                    if (SystemInfo.AdvUseOtherCard && cardNo > 0)
                                        cardInfo.CardNo[Index] = cardNo;
                                    else
                                        UInt32.TryParse(dr["CardPhysicsNo10"].ToString(), out cardInfo.CardNo[Index]);
                                    Index++;
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
                        }
                    }
                    if (!IsError)
                    {
                        AccessV2API.TYPE_DoorBasic basic = new AccessV2API.TYPE_DoorBasic();
                        AccessV2API.TYPE_DoorExpert expert = new AccessV2API.TYPE_DoorExpert();
                        ret = DeviceObject.objMJNew.ReadDoorInfo(doorInfo.DoorID, ref basic, ref expert);
                        if (ret)
                        {
                            expert.ExpertFirstCard = cardInfo;
                            if (doorInfo.ExtField[0] == "Y")
                            {
                                expert.EnableFirstCard = 1;
                            }
                            else
                                expert.EnableFirstCard = 0;
                            ret = DeviceObject.objMJNew.SetDoorExpertInfo(doorInfo.DoorID, expert);
                        }
                    }
                    break;
            }
            return ret;
        }
    }
}