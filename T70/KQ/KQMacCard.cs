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
  public partial class frmKQMacCard : frmKQMacBase
  {
    private List<TAttCardReg> cardList = new List<TAttCardReg>();

    protected override void InitForm()
    {
      formCode = "KQMacCard";
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
      if (SystemInfo.CardType == 0) QueryFlag = 255;
      base.InitForm();
      lblQuickSearchToolTip.ForeColor = Color.Blue;
    }

    public frmKQMacCard()
    {
      InitializeComponent();
    }

    protected override void ExecItemTAG1()
    {
      if (!InitCardList()) return;
      base.ExecItemTAG1();
      ExecMacOprt(0);
    }

    protected override void ExecItemTAG2()
    {
      if (!InitCardList()) return;
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
      TAttCardReg cardReg;
      string msg;
      for (int i = 0; i < cardList.Count; i++)
      {
        cardReg = cardList[i];
        switch (flag)
        {
          case 0:
            ret = DeviceObject.objKS.AttCardReg(false, ref cardReg);
            break;
          case 1:
            ret = DeviceObject.objKS.AttCardDel(cardReg.CardID);
            break;
        }
        msg = GetMacMsg(MacSN) + "[" + cardReg.CardID + "]:" + DeviceObject.objKS.ErrMsg;
        db.WriteSYLog(this.Text, CurrentTool, msg);
        if (!ret) break;
      }
      return ret;
    }

    private bool InitCardList()
    {
      TAttCardReg cardReg;
      cardList.Clear();
      if (cardGrid.DataSource != null)
      {
        DataTable dtGrid = (DataTable)cardGrid.DataSource;
        for (int i = 0; i < dtGrid.Rows.Count; i++)
        {
          cardReg = new TAttCardReg();
          cardReg.CardID = dtGrid.Rows[i]["CardPhysicsNo10"].ToString();
          cardReg.EmpID = dtGrid.Rows[i]["EmpNo"].ToString();
          cardReg.EmpName = dtGrid.Rows[i]["EmpName"].ToString();
          DateTime.TryParse(dtGrid.Rows[i]["CardStartDate"].ToString(), out cardReg.BeginDate);
          DateTime.TryParse(dtGrid.Rows[i]["CardEndDate"].ToString(), out cardReg.EndDate);
          cardList.Add(cardReg);
        }
      }
      if (cardList.Count == 0)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
      }
      return cardList.Count > 0;
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