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
      string cardNo = "";
      switch (flag)
      {
        case 0:
          QHKS.TMJMoreCardInfo cardInfo = new QHKS.TMJMoreCardInfo();
          cardInfo.DoorID = Convert.ToByte(doorInfo.DoorID);
          cardInfo.CardList = new string[20];
          if (doorInfo.ExtField[0] == "Y")
          {
            TMacMoreCard card = new TMacMoreCard(doorInfo.ExtField[1]);
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
                  cardNo = dr["OtherCardNo"].ToString();
                  if (SystemInfo.AdvUseOtherCard && cardNo != "")
                    cardInfo.CardList[Index] = "1-" + cardNo;
                  else
                    cardInfo.CardList[Index] = dr["CardPhysicsNo10"].ToString();
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
            for (int i = Index; i < 20; i++)
            {
              cardInfo.CardList[i] = "";
            }
            cardInfo.CardCount = card.EmpCount;
            cardInfo.CardIn = card.EnabledIn;
            cardInfo.CardOut = card.EnabledOut;
          }
          if (!IsError) ret = DeviceObject.objMJ.SetMacMoreCardInfo(ref cardInfo);
          break;
      }
      return ret;
    }
  }
}