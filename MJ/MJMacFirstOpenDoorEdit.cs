using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacFirstOpenDoorEdit : frmBaseDialog
  {
    private const int MaxCard = 10;

    protected override void InitForm()
    {
      formCode = "MJMacFirstOpenDoorEdit";
      CreateCardGridView(cardGrid);
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      checkBox1.ForeColor = Color.Blue;
      checkBox7.ForeColor = Color.Navy;
      LoadData();
    }

    public frmMJMacFirstOpenDoorEdit(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      string IsFirstCard = "";
      string MacFirstCard = "";
      DataTableReader dr = null;
      cbbMode1.Items.Clear();
      cbbMode2.Items.Clear();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        TCommonType ctype;
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "110" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["MacDoorCommandWaySysID"].ToString(), dr["MacDoorCommandWayID"].ToString(), 
            dr["MacDoorCommandWayName"].ToString(), true);
          cbbMode1.Items.Add(ctype);
          cbbMode2.Items.Add(ctype);
        }
        dr.Close();
        cbbMode1.SelectedIndex = 0;
        cbbMode2.SelectedIndex = 0;
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "102", SysID }));
        if (dr.Read())
        {
          IsFirstCard = dr["IsFirstCard"].ToString();
          MacFirstCard = dr["MacFirstCard"].ToString();
        }
        dr.Close();
        TMacFirstCard card = new TMacFirstCard(MacFirstCard);
        txtBeginTime.Text = card.StartTime;
        txtEndTime.Text = card.EndTime;
        SetWayIndex(cbbMode1, card.Way[0]);
        SetWayIndex(cbbMode2, card.Way[1]);
        checkBox1.Checked = card.Week[6] == 1;
        checkBox2.Checked = card.Week[0] == 1;
        checkBox3.Checked = card.Week[1] == 1;
        checkBox4.Checked = card.Week[2] == 1;
        checkBox5.Checked = card.Week[3] == 1;
        checkBox6.Checked = card.Week[4] == 1;
        checkBox7.Checked = card.Week[5] == 1;
        if (card.EmpList != "")
        {
          string sql = "";
          if (SystemInfo.HasFaCard)
            sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "108", card.EmpList });
          else
            sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "301", card.EmpList });
          dr = db.GetDataReader(sql);
          while (dr.Read())
          {
            QuickSearchNormalCardByEmpSysID(dr["EmpSysID"].ToString(), cardGrid, MaxCard);
          }
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
      chkEnabled.Checked = IsFirstCard.ToUpper() == "Y";
      chkEnabled_CheckedChanged(null, null);
    }

    private void chkEnabled_CheckedChanged(object sender, EventArgs e)
    {
      groupBox1.Enabled = chkEnabled.Checked;
      gbxEmpInfo.Enabled = chkEnabled.Checked;
    }

    private void btnQuickSearch_Click(object sender, EventArgs e)
    {
      QuickSearchNormalCard(btnQuickSearch.Text, cardGrid, MaxCard);
    }

    private void txtQuickSearch_KeyDown(object sender, KeyEventArgs e)
    {
      QuickSearchNormalCard(txtQuickSearch, e, cardGrid, MaxCard);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string IsFirstCard = "N";
      string way = "00";
      string week = "0000000";
      string MacFirstCard = "";
      if (chkEnabled.Checked)
      {
        IsFirstCard = "Y";
        way = string.Format("{0}{1}", ((TCommonType)cbbMode1.Items[cbbMode1.SelectedIndex]).id,
          ((TCommonType)cbbMode2.Items[cbbMode2.SelectedIndex]).id);
        week = string.Format("{0}{1}{2}{3}{4}{5}{6}", Convert.ToByte(checkBox2.Checked), 
          Convert.ToByte(checkBox3.Checked), Convert.ToByte(checkBox4.Checked), 
          Convert.ToByte(checkBox5.Checked), Convert.ToByte(checkBox6.Checked), 
          Convert.ToByte(checkBox7.Checked), Convert.ToByte(checkBox1.Checked));
        DateTime dt = new DateTime();
        if (!DateTime.TryParse(txtBeginTime.Text, out dt))
        {
          txtBeginTime.Focus();
          ShowErrorEnterCorrect(label1.Text);
          return;
        }
        if (!DateTime.TryParse(txtEndTime.Text, out dt))
        {
          txtEndTime.Focus();
          ShowErrorEnterCorrect(label4.Text);
          return;
        }
        DataTable dtGrid = (DataTable)cardGrid.DataSource;
        for (int i = 0; i < dtGrid.Rows.Count; i++)
        {
          MacFirstCard += dtGrid.Rows[i]["EmpSysID"].ToString() + "#";
        }
        MacFirstCard = string.Format("{0}@{1}@{2}@{3}@{4}", way, week, txtBeginTime.Text, txtEndTime.Text, MacFirstCard);
      }
      string sql = "";
      try
      {
        sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "109", IsFirstCard, MacFirstCard, SysID });
        db.ExecSQL(sql);
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
        return;
      }
      db.WriteSYLog(this.Text, CurrentOprt, sql);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void SetWayIndex(ComboBox cbb, byte way)
    {
      for (int i = 0; i < cbb.Items.Count; i++)
      {
        if (((TCommonType)cbb.Items[i]).id == way.ToString())
        {
          cbb.SelectedIndex = i;
          break;
        }
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      cardGrid.DataSource = null;
    }
  }
}