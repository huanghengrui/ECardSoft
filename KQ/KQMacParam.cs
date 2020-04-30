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
    public partial class frmKQMacParam : frmKQMacBase
    {
        private string usbPath = "";

        protected override void InitForm()
        {
            formCode = "KQMacParam";
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
            base.InitForm();
            lblBegin1.Text = lblBegin.Text;
            lblEnd1.Text = lblEnd.Text;
            lblBegin2.Text = lblBegin.Text;
            lblEnd2.Text = lblEnd.Text;
            GetCardTypeList();
            chkCardType.Items.Clear();
            for (int i = 0; i < cardTypeList.Count; i++)
            {
                chkCardType.Items.Add(cardTypeList[i]);
            }
            ComboBox cbb;
            CheckBox chk;
            for (int i = 0; i <= 3; i++)
            {
                cbb = (ComboBox)tabPage3.Controls[string.Format("cbbOrder{0}", i + 1)];
                cbb.Items.Clear();
                cbb.Items.Add(Pub.GetResText(formCode, "ThatDay", ""));
                cbb.Items.Add(Pub.GetResText(formCode, "NextDay", ""));
                chk = (CheckBox)tabPage3.Controls[string.Format("chkOrder{0}1", i + 1)];
                chk.Text = Pub.GetResText(formCode, "Breakfast", "");
                chk = (CheckBox)tabPage3.Controls[string.Format("chkOrder{0}2", i + 1)];
                chk.Text = Pub.GetResText(formCode, "Lunch", "");
                chk = (CheckBox)tabPage3.Controls[string.Format("chkOrder{0}3", i + 1)];
                chk.Text = Pub.GetResText(formCode, "Dinner", "");
                chk = (CheckBox)tabPage3.Controls[string.Format("chkOrder{0}4", i + 1)];
                chk.Text = Pub.GetResText(formCode, "Snack", "");
            }
            chkOrder61.Text = Pub.GetResText(formCode, "SunID", "");
            chkOrder62.Text = Pub.GetResText(formCode, "MonID", "");
            chkOrder63.Text = Pub.GetResText(formCode, "TueID", "");
            chkOrder64.Text = Pub.GetResText(formCode, "WedID", "");
            chkOrder65.Text = Pub.GetResText(formCode, "ThuID", "");
            chkOrder66.Text = Pub.GetResText(formCode, "FriID", "");
            chkOrder67.Text = Pub.GetResText(formCode, "SatID", "");
            RefreshForm(true);
        }

        public frmKQMacParam()
        {
            InitializeComponent();
        }

        protected override void ExecItemTAG1()
        {
            if (!CheckOrderInfo(tabPage3)) return;
            base.ExecItemTAG1();
            ExecMacOprt(0, false);
            
        }

        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            ExecMacOprt(1);
           
        }

        protected override void ExecItemTAG3()
        {
            if (dlgFolder.ShowDialog() != DialogResult.OK) return;
            usbPath = dlgFolder.SelectedPath;
            if (usbPath.Substring(usbPath.Length - 1, 1) != "\\") usbPath = usbPath + "\\";
            base.ExecItemTAG3();
            ExecMacOprt(2, false);
            
        }

        protected override void RefreshForm(bool State)
        {
            base.RefreshForm(State);
            DataTableReader dr = null;
            string ParamStr = "";
            string AttendStr = "";
            string BellStr = "";
            try
            {
                pnlParam.Enabled = State && ItemTAG1.Enabled;
            }
            catch
            {
            }
            if (ItemTAG1.Enabled)
            {
                try
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "4", GetMacSysID() }));
                    if (dr.Read())
                    {
                        ParamStr = dr["ParamInfo"].ToString();
                        AttendStr = dr["AttendTime"].ToString();
                        BellStr = dr["BellTime"].ToString();
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
                KQParamInfo param = new KQParamInfo(ParamStr);
                txtAttend.Value = param.RelayOutputActionTime1;
                txtBells.Value = param.RelayOutputActionTime2;
                chkOrder.Checked = param.EnabledCardOrder == 1;
                chkAccess.Checked = param.ShowCardInfo == 1;
                chkBells.Checked = param.RingingBells == 1;
                chkDeviceOprt.Checked = param.EnabledOpter == 1;
                txtTitle.Text = param.AttendanceTitle;
                txtMessage.Text = param.Message;
                chkMessage.Checked = param.MessageEnabled == 1;
                CheckBox chk;
                ComboBox cbb;
                MaskedTextBox txt;
                for (int i = 0; i <= 3; i++)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        chk = (CheckBox)tabPage3.Controls[string.Format("chkOrder{0}{1}", i + 1, j + 1)];
                        chk.Checked = param.Order[i].Substring(j, 1) == "1";
                    }
                    cbb = (ComboBox)tabPage3.Controls[string.Format("cbbOrder{0}", i + 1)];
                    if (cbb.Items.Count > param.NextDay[i]) cbb.SelectedIndex = param.NextDay[i];
                    txt = (MaskedTextBox)tabPage3.Controls[string.Format("txtOrder{0}1", i + 1)];
                    txt.Text = param.OrderFrom[i];
                    txt = (MaskedTextBox)tabPage3.Controls[string.Format("txtOrder{0}2", i + 1)];
                    txt.Text = param.OrderTo[i];
                }
                string cardtype = param.CardType;
                if ((cardtype == "") || (!Pub.IsNumeric(cardtype)))
                {
                    cardtype = SystemInfo.CardTypeDefault;
                }
                for (int i = 0; i < chkCardType.Items.Count; i++)
                {
                    chkCardType.SetItemChecked(i, cardtype.Substring(i, 1) == "1");
                }
                KQTimeInfo time = new KQTimeInfo(AttendStr);
                for (int i = 0; i <= 5; i++)
                {
                    txt = (MaskedTextBox)tabPage1.Controls[string.Format("txtAttend{0}1", i + 1)];
                    txt.Text = time.BeginTime[i];
                    txt = (MaskedTextBox)tabPage1.Controls[string.Format("txtAttend{0}2", i + 1)];
                    txt.Text = time.EndTime[i];
                }
                KQBellTimeInfo bell = new KQBellTimeInfo(BellStr);
                for (int i = 0; i <= 5; i++)
                {
                    txt = (MaskedTextBox)tabPage2.Controls[string.Format("txtBells{0}", i + 1)];
                    txt.Text = bell.BellTime[i];
                }
                for (int i = 0; i <= 6; i++)
                {
                    chk = (CheckBox)tabPage3.Controls[string.Format("chkOrder6{0}", i + 1)];
                    chk.Checked = param.Restday[i].ToString() == "1";
                }
            }
          
        }

        protected override bool ExecMacCommand(byte flag, int MacSN, ref string MacMsg)
        {
            DataTableReader dr = null;
            bool ret = base.ExecMacCommand(flag, MacSN, ref MacMsg);
            string cardType = "";
            string paramStr = "";
            string timeStr = "";
            string bellStr = "";
            string msgContinue = Pub.GetResText(formCode, "MsgContinue", "");
            string tmpMsg = "";
            string tmp = "";
            TFeePrintTitle feePrint = new TFeePrintTitle();
            feePrint.Zoom = new byte[5];
            feePrint.Title = new string[5];
            bool IsError = false;
            TCardTAG cardTAG = new TCardTAG();
            cardTAG.Count = 0;
            cardTAG.TAG = new string[200];
            switch (flag)
            {
                case 0:
                    for (int i = 0; i < chkCardType.Items.Count; i++)
                    {
                        cardType += Convert.ToByte(chkCardType.GetItemChecked(i)).ToString();
                    }
                    paramStr = string.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}#{9}#{10}#", 0, 0, 0, txtAttend.Value,
                      txtBells.Value, Convert.ToByte(chkOrder.Checked), Convert.ToByte(chkAccess.Checked),
                      Convert.ToByte(chkBells.Checked), txtTitle.Text, cardType, Convert.ToByte(chkDeviceOprt.Checked));
                    CheckBox chk;
                    ComboBox cbb;
                    MaskedTextBox txt;
                    for (int i = 0; i <= 3; i++)
                    {
                        for (int j = 0; j <= 3; j++)
                        {
                            chk = (CheckBox)tabPage3.Controls[string.Format("chkOrder{0}{1}", i + 1, j + 1)];
                            paramStr += Convert.ToByte(chk.Checked).ToString();
                        }
                        paramStr += "#";
                    }
                    for (int i = 0; i <= 3; i++)
                    {
                        cbb = (ComboBox)tabPage3.Controls[string.Format("cbbOrder{0}", i + 1)];
                        paramStr += cbb.SelectedIndex.ToString() + "#";
                    }
                    for (int i = 0; i <= 3; i++)
                    {
                        txt = (MaskedTextBox)tabPage3.Controls[string.Format("txtOrder{0}1", i + 1)];
                        paramStr += txt.Text + "#";
                    }
                    for (int i = 0; i <= 3; i++)
                    {
                        txt = (MaskedTextBox)tabPage3.Controls[string.Format("txtOrder{0}2", i + 1)];
                        paramStr += txt.Text + "#";
                    }
                    paramStr += Convert.ToByte(chkMessage.Checked).ToString() + "#" + txtMessage.Text;
                    for (int i = 0; i <= 5; i++)
                    {
                        txt = (MaskedTextBox)tabPage1.Controls[string.Format("txtAttend{0}1", i + 1)];
                        timeStr += txt.Text + "#";
                    }
                    for (int i = 0; i <= 5; i++)
                    {
                        txt = (MaskedTextBox)tabPage1.Controls[string.Format("txtAttend{0}2", i + 1)];
                        timeStr += txt.Text + "#";
                    }
                    for (int i = 0; i <= 5; i++)
                    {
                        txt = (MaskedTextBox)tabPage2.Controls[string.Format("txtBells{0}", i + 1)];
                        bellStr += txt.Text + "#";
                    }
                    for (int i = 0; i <= 6; i++)
                    {
                        chk = (CheckBox)tabPage3.Controls[string.Format("chkOrder6{0}", i + 1)];
                        paramStr += "#" + Convert.ToByte(chk.Checked).ToString();
                    }
                    MacMsg = Pub.GetSQL(DBCode.DB_002001, new string[] { "102", paramStr, timeStr, bellStr, MacSN.ToString() });
                    try
                    {
                        db.ExecSQL(MacMsg);
                        ret = true;
                    }
                    catch (Exception E)
                    {
                        Pub.ShowErrorMsg(E);
                    }
                    break;
                case 1:
                case 2:
                    DataTable dtBlack = null;
                    try
                    {
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "4", GetMacSysID(MacSN.ToString()) }));
                        if (dr.Read())
                        {
                            paramStr = dr["ParamInfo"].ToString();
                            timeStr = dr["AttendTime"].ToString();
                            bellStr = dr["BellTime"].ToString();
                        }
                        dr.Close();
                        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "3002" }));
                        while (dr.Read())
                        {
                            tmp = dr[0].ToString();
                            if (tmp.Length == 32)
                            {
                                tmp = Pub.GetOprtDecrypt(tmp);
                                cardTAG.TAG[cardTAG.Count] = tmp;
                                cardTAG.Count++;
                            }
                        }
                        dtBlack = db.GetDataTable(Pub.GetSQL(DBCode.DB_001003, new string[] { "501" }));
                        TPrintTitleInfo ptInfo = new TPrintTitleInfo("");
                        for (int i = 0; i < 5; i++)
                        {
                            feePrint.Zoom[i] = (byte)(ptInfo.Zoom[i] + 1);
                            feePrint.Title[i] = ptInfo.Title[i];
                        }
                        feePrint.SpaceLine = ptInfo.Line;
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
                    QHKS.TCheckIsOrder IsOrder = new TCheckIsOrder();
                    if (!db.GetCheckIsOrder(ref IsOrder)) IsError = false;
                    if (!IsError)
                    {
                        KQParamInfo param = new KQParamInfo(paramStr);
                        KQTimeInfo time = new KQTimeInfo(timeStr);
                        KQBellTimeInfo bell = new KQBellTimeInfo(bellStr);
                        TAttParamSet paramSet = new TAttParamSet();
                        paramSet.AllowOrder = param.EnabledCardOrder;
                        paramSet.AllowAccess = param.ShowCardInfo;
                        paramSet.AccessTimeout = param.RelayOutputActionTime1;
                        paramSet.AllowRinging = param.RingingBells;
                        paramSet.RingingTimeout = param.RelayOutputActionTime2;
                        paramSet.CardType = new byte[256];
                        for (int i = 0; i < SystemInfo.CardTypeCount; i++)
                        {
                            paramSet.CardType[i] = 0;
                            if (param.CardType.Substring(i, 1) == "1") paramSet.CardType[i] = 1;
                        }
                        paramSet.IsLongID = Convert.ToByte(SystemInfo.IsLongEmpID);
                        TAttPubMessage attMsg = new TAttPubMessage();
                        attMsg.Allow = param.MessageEnabled;
                        attMsg.Message = param.Message;
                        TAttTimeSet timeSet = new TAttTimeSet();
                        timeSet.BeginTime = new string[6];
                        timeSet.EndTime = new string[6];
                        for (int i = 0; i <= 5; i++)
                        {
                            timeSet.BeginTime[i] = time.BeginTime[i];
                            timeSet.EndTime[i] = time.EndTime[i];
                        }
                        TAttRinging bellSet = new TAttRinging();
                        bellSet.Allow = param.RingingBells;
                        bellSet.Ringing = new string[6];
                        for (int i = 0; i <= 5; i++)
                        {
                            bellSet.Ringing[i] = bell.BellTime[i];
                        }
                        TAttOrderSet orderSet = new TAttOrderSet();
                        orderSet.NextDay = new byte[4];
                        orderSet.BeginTime = new string[4];
                        orderSet.EndTime = new string[4];
                        orderSet.OrderInfo = new byte[16];
                        orderSet.Restday = new byte[7];
                        for (int i = 0; i <= 3; i++)
                        {
                            orderSet.NextDay[i] = param.NextDay[i];
                            orderSet.BeginTime[i] = param.OrderFrom[i];
                            orderSet.EndTime[i] = param.OrderTo[i];
                            for (int j = 0; j <= 3; j++)
                            {
                                orderSet.OrderInfo[i * 4 + j] = 0;
                                if (param.Order[i].Substring(j, 1) == "1") orderSet.OrderInfo[i * 4 + j] = 1;
                            }
                        }
                        for (int i = 0; i <= 6; i++)
                        {
                            orderSet.Restday[i] = param.Restday[i];
                        }
                        TAdminUser adminSer = new TAdminUser();
                        adminSer.ID = new byte[20];
                        adminSer.Pass = new int[20];
                        if (param.EnabledOpter == 1)
                        {
                            try
                            {
                                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000004, new string[] { "0" }));
                                while (dr.Read())
                                {
                                    adminSer.ID[adminSer.Count] = Convert.ToByte(dr["MacOpterID"]);
                                    adminSer.Pass[adminSer.Count] = Convert.ToInt32(dr["MacOpterPWD"]);
                                    adminSer.Count++;
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
                        }
                        if (flag == 1)
                        {
                            DeviceObject.objKS.SysSetState(false);
                            DeviceObject.objKS.AttClear();
                            tmpMsg = Pub.GetResText(formCode, "MsgSyncTime", "");
                        RetrySyncTime:
                            ret = SyncTime();
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetrySyncTime;
                            }
                            tmpMsg = Pub.GetResText(formCode, "MsgCardSector", "");
                        RetryCard:
                            ret = DeviceObject.objKS.PubSectorSet();
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryCard;
                            }
                            tmpMsg = Pub.GetResText(formCode, "MsgCardKey", "");
                        RetryCardKey:
                            ret = DeviceObject.objKS.SysCardKey();
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryCardKey;
                            }
                            tmpMsg = Pub.GetResText(formCode, "Msg001", "");
                        RetryParam:
                            ret = DeviceObject.objKS.AttParamSet(ref paramSet);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryParam;
                            }
                            tmpMsg = Pub.GetResText(formCode, "Msg002", "");
                        RetryMessage:
                            ret = DeviceObject.objKS.AttMessage(ref attMsg);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryMessage;
                            }
                            tmpMsg = Pub.GetResText(formCode, "Msg003", "");
                        RetryTitle:
                            ret = DeviceObject.objKS.PubTitleSet(param.AttendanceTitle);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryTitle;
                            }
                            tmpMsg = Pub.GetResText(formCode, "Msg004", "");
                        RetryAttend:
                            ret = DeviceObject.objKS.AttTimeSet(ref timeSet);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryAttend;
                            }
                            tmpMsg = Pub.GetResText(formCode, "Msg005", "");
                        RetryBell:
                            ret = DeviceObject.objKS.AttRingingSet(ref bellSet);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryBell;
                            }
                            tmpMsg = Pub.GetResText(formCode, "Msg006", "");
                        RetryOrder:
                            ret = DeviceObject.objKS.AttOrderSet(ref orderSet);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryOrder;
                            }
                            tmpMsg = Pub.GetResText(formCode, "MsgDeviceOprt", "");
                        RetryOprtClear:
                            ret = DeviceObject.objKS.PubAdminUserClear();
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryOprtClear;
                            }
                        RetryOprt:
                            ret = DeviceObject.objKS.PubAdminUserSet(ref adminSer);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryOprt;
                            }
                            tmpMsg = Pub.GetResText(formCode, "MsgDeviceBlack", "");
                        RetryBlackClear:
                            ret = DeviceObject.objKS.PubBlackClear();
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryBlackClear;
                            }
                        RetryBlack:
                            int max = dtBlack.Rows.Count;
                            if (max > 0)
                            {
                                string cardNo = "";
                                for (int i = 0; i < max; i++)
                                {
                                    if (SystemInfo.CardType == 0)
                                        cardNo = dtBlack.Rows[i]["CardSectorNo"].ToString();
                                    else
                                        cardNo = dtBlack.Rows[i]["CardPhysicsNo10"].ToString();
                                    DeviceObject.objKS.PubBlackInit(cardNo, i == 0, false);
                                }
                                ret = DeviceObject.objKS.PubBlackData(SystemInfo.MainHandle.ToInt32());
                                if (!ret)
                                {
                                    if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                    {
                                        MacMsg = tmpMsg;
                                        break;
                                    }
                                    else
                                        goto RetryBlack;
                                }
                            }
                            tmpMsg = Pub.GetResText(formCode, "Msg007", "");
                        RetryCheckOrder:
                            ret = DeviceObject.objKS.PubSetCheckOrder(ref IsOrder);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryCheckOrder;
                            }
                        RetryCardTAG:
                            ret = DeviceObject.objKS.PubCardTAG(ref cardTAG);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryCardTAG;
                            }
                            tmpMsg = Pub.GetResText(formCode, "Msg008", "");
                        RetryPrint:
                            ret = DeviceObject.objKS.FeePrintTitle(ref feePrint);
                            if (!ret)
                            {
                                if (Pub.MessageBoxShowQuestion(tmpMsg + "\r\n\r\n" + DeviceObject.objKS.ErrMsg + "\r\n\r\n" + msgContinue))
                                {
                                    MacMsg = tmpMsg;
                                    break;
                                }
                                else
                                    goto RetryPrint;
                            }
                        }
                        else
                        {
                            DeviceObject.objKS.InitUSBFile(usbPath);
                            DeviceObject.objKS.PubSectorSetUSB();
                            DeviceObject.objKS.SysCardKeyUSB();
                            DeviceObject.objKS.AttParamSetUSB(ref paramSet);
                            DeviceObject.objKS.AttMessageUSB(ref attMsg);
                            DeviceObject.objKS.PubTitleSetUSB(param.AttendanceTitle);
                            DeviceObject.objKS.AttTimeSetUSB(ref timeSet);
                            DeviceObject.objKS.AttRingingSetUSB(ref bellSet);
                            DeviceObject.objKS.AttOrderSetUSB(ref orderSet);
                            DeviceObject.objKS.PubAdminUserClearUSB();
                            DeviceObject.objKS.PubAdminUserSetUSB(ref adminSer);
                            DeviceObject.objKS.PubBlackClearUSB();
                            int max = dtBlack.Rows.Count;
                            if (max > 0)
                            {
                                string cardNo = "";
                                for (int i = 0; i < max; i++)
                                {
                                    if (SystemInfo.CardType == 0)
                                        cardNo = dtBlack.Rows[i]["CardSectorNo"].ToString();
                                    else
                                        cardNo = dtBlack.Rows[i]["CardPhysicsNo10"].ToString();
                                    DeviceObject.objKS.PubBlackInit(cardNo, i == 0, true);
                                }
                                DeviceObject.objKS.PubBlackDataUSB();
                            }
                            DeviceObject.objKS.PubSetCheckOrderUSB(ref IsOrder);
                            DeviceObject.objKS.PubCardTAGUSB(ref cardTAG);
                            DeviceObject.objKS.FeePrintTitleUSB(ref feePrint);
                            ret = true;
                        }
                    }
                    if (flag == 1) DeviceObject.objKS.SysSetState(true);
                    if (dtBlack != null)
                    {
                        dtBlack.Clear();
                        dtBlack.Reset();
                    }
                    break;
            }
            
            return ret;
        }

        private void OrderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshOrderControl(tabPage3);
        }

        private void OrderCheckBox_Click(object sender, EventArgs e)
        {
            RefreshOrderControl(tabPage3);
        }
    }
}