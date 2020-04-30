using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmMJMacMoreCard : frmMJMacDoorBase
    {
        protected override void InitForm()
        {
            formCode = "MJMacMoreCard";
            ExtField.Add("IsMoreCard");
            ExtField.Add("MacMoreCard");
            HideExtField = 1;
            base.InitForm();
        }

        public frmMJMacMoreCard()
        {
            InitializeComponent();
        }

        protected override void ExecItemEdit()
        {
            base.ExecItemEdit();
            frmMJMacMoreCardEdit frm = new frmMJMacMoreCardEdit(this.Text, CurrentTool, GetMacDoorSysID());
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
            UInt32 cardNo1 = 0;
            UInt32 cardNo2 = 0;
            switch (flag)
            {
                case 0:
                    AccessV2API.TYPE_MulitCardDat cardInfo = new AccessV2API.TYPE_MulitCardDat();
                    cardInfo.GroupA = new UInt32[50];
                    cardInfo.GroupB = new UInt32[50];
                    cardInfo.GroupC = new UInt32[50];
                    cardInfo.GroupD = new UInt32[50];
                    cardInfo.GroupE = new UInt32[50];
                    cardInfo.GroupF = new UInt32[50];
                    cardInfo.GroupG = new UInt32[50];
                    cardInfo.GroupH = new UInt32[50];
                    cardInfo.GroupI = new UInt32[50];
                    cardInfo.GroupJ = new UInt32[50];
                    AccessV2API.TYPE_MulitCardMap CardMap = new AccessV2API.TYPE_MulitCardMap();
                    CardMap.ProgramA = new UInt32[10];
                    CardMap.ProgramB = new UInt32[10];
                    CardMap.ProgramC = new UInt32[10];
                    CardMap.ProgramD = new UInt32[10];
                    if (doorInfo.ExtField[0] == "Y")
                    {
                        TMacMoreCardNew card = new TMacMoreCardNew(doorInfo.ExtField[1]);
                        for (int i = 0; i < 10; i++)
                        {
                            if (card.EmpList[i] != "")
                            {
                                DataTableReader dr = null;
                                try
                                {
                                    string sql = "";
                                    if (SystemInfo.HasFaCard)
                                        sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "108", card.EmpList[i] });
                                    else
                                        sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "301", card.EmpList[i] });
                                    dr = db.GetDataReader(sql);
                                    Index = 0;
                                    while (dr.Read())
                                    {
                                        UInt32.TryParse(dr["CardPhysicsNo10"].ToString(), out cardNo1);
                                        UInt32.TryParse(dr["OtherCardNo"].ToString(), out cardNo2);
                                        switch (i)
                                        {
                                            case 0:
                                                cardInfo.GroupA[Index] = SystemInfo.AdvUseOtherCard && cardNo2 > 0 ? cardNo2 : cardNo1;
                                                break;
                                            case 1:
                                                cardInfo.GroupB[Index] = SystemInfo.AdvUseOtherCard && cardNo2 > 0 ? cardNo2 : cardNo1;
                                                break;
                                            case 2:
                                                cardInfo.GroupC[Index] = SystemInfo.AdvUseOtherCard && cardNo2 > 0 ? cardNo2 : cardNo1;
                                                break;
                                            case 3:
                                                cardInfo.GroupD[Index] = SystemInfo.AdvUseOtherCard && cardNo2 > 0 ? cardNo2 : cardNo1;
                                                break;
                                            case 4:
                                                cardInfo.GroupE[Index] = SystemInfo.AdvUseOtherCard && cardNo2 > 0 ? cardNo2 : cardNo1;
                                                break;
                                            case 5:
                                                cardInfo.GroupF[Index] = SystemInfo.AdvUseOtherCard && cardNo2 > 0 ? cardNo2 : cardNo1;
                                                break;
                                            case 6:
                                                cardInfo.GroupG[Index] = SystemInfo.AdvUseOtherCard && cardNo2 > 0 ? cardNo2 : cardNo1;
                                                break;
                                            case 7:
                                                cardInfo.GroupH[Index] = SystemInfo.AdvUseOtherCard && cardNo2 > 0 ? cardNo2 : cardNo1;
                                                break;
                                            case 8:
                                                cardInfo.GroupI[Index] = SystemInfo.AdvUseOtherCard && cardNo2 > 0 ? cardNo2 : cardNo1;
                                                break;
                                            case 9:
                                                cardInfo.GroupJ[Index] = SystemInfo.AdvUseOtherCard && cardNo2 > 0 ? cardNo2 : cardNo1;
                                                break;
                                        }
                                        Index += 1;
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
                        switch (doorInfo.DoorID)
                        {
                            case 1:
                                for (int i = 0; i < 10; i++)
                                {
                                    CardMap.ProgramA[i] = (UInt32)card.CountList[i];
                                }
                                break;
                            case 2:
                                for (int i = 0; i < 10; i++)
                                {
                                    CardMap.ProgramB[i] = (UInt32)card.CountList[i];
                                }
                                break;
                            case 3:
                                for (int i = 0; i < 10; i++)
                                {
                                    CardMap.ProgramC[i] = (UInt32)card.CountList[i];
                                }
                                break;
                            case 4:
                                for (int i = 0; i < 10; i++)
                                {
                                    CardMap.ProgramD[i] = (UInt32)card.CountList[i];
                                }
                                break;
                        }
                    }
                    if (!IsError)
                    {
                        ret = DeviceObject.objMJNew.SetMultiCardDat(doorInfo.DoorID, cardInfo);
                        if (ret) ret = DeviceObject.objMJNew.SetMultiCardMap(CardMap);
                        if (ret)
                        {
                            AccessV2API.TYPE_DoorBasic basic = new AccessV2API.TYPE_DoorBasic();
                            AccessV2API.TYPE_DoorExpert expert = new AccessV2API.TYPE_DoorExpert();
                            ret = DeviceObject.objMJNew.ReadDoorInfo(doorInfo.DoorID, ref basic, ref expert);
                            if (ret)
                            {
                                if (doorInfo.ExtField[0] == "Y")
                                    expert.EnableMulitCard = 1;
                                else
                                    expert.EnableMulitCard = 0;
                                
                                ret = DeviceObject.objMJNew.SetDoorExpertInfo(doorInfo.DoorID, expert);
                            }
                        }
                    }
                    break;
            }
            return ret;
        }
    }
}