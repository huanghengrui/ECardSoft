using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacInOutConfirm : frmMJMacDoorBase
  {
    protected override void InitForm()
    {
      formCode = "MJMacInOutConfirm";
      ExtField.Add("IsInoutCard");
      ExtField.Add("MacInoutCard");
      HideExtField = 1;
      base.InitForm();
    }

    public frmMJMacInOutConfirm()
    {
      InitializeComponent();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmMJMacInOutConfirmEdit frm = new frmMJMacInOutConfirmEdit(this.Text, CurrentTool, GetMacDoorSysID());
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
          UInt32 EnableGuardCard = 0;
          UInt32[] ExpertGuardCard = new UInt32[5];
          if (doorInfo.ExtField[0] == "Y")
          {
            EnableGuardCard = 1;
            TInOutCard card = new TInOutCard(doorInfo.ExtField[1]);
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
                    ExpertGuardCard[Index] = cardNo;
                  else
                    UInt32.TryParse(dr["CardPhysicsNo10"].ToString(), out ExpertGuardCard[Index]);
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
              expert.EnableGuardCard = EnableGuardCard;
              expert.ExpertGuardCard = ExpertGuardCard;
              ret = DeviceObject.objMJNew.SetDoorExpertInfo(doorInfo.DoorID, expert);
            }
          }
          break;
      }
      return ret;
    }
  }
}