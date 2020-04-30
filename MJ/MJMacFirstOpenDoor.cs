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
      string cardNo = "";
      switch (flag)
      {
        case 0:
          QHKS.TMJFirstCardInfo cardInfo = new QHKS.TMJFirstCardInfo();
          cardInfo.DoorID = Convert.ToByte(doorInfo.DoorID);
          cardInfo.CommandWay = new byte[2];
          cardInfo.Week = new byte[7];
          cardInfo.StartTime = "00:00";
          cardInfo.EndTime = "00:00";
          cardInfo.CardList = new string[10];
          if (doorInfo.ExtField[0] == "Y")
          {
            TMacFirstCard card = new TMacFirstCard(doorInfo.ExtField[1]);
            for (int i = 0; i < 2; i++)
            {
              cardInfo.CommandWay[i] = card.Way[i];
            }
            for (int i = 0; i < 7; i++)
            {
              cardInfo.Week[i] = card.Week[i];
            }
            cardInfo.StartTime = card.StartTime;
            cardInfo.EndTime = card.EndTime;
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
            for (int i = Index; i < 10; i++)
            {
              cardInfo.CardList[i] = "";
            }
          }
          if (!IsError) ret = DeviceObject.objMJ.SetMacFirstCardInfo(ref cardInfo);
          break;
      }
      return ret;
    }
  }
}