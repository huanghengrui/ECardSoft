using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQShiftAdd : frmBaseDialog
  {
    private bool _ReadOnly = false;

    protected override void InitForm()
    {
      formCode = "KQShiftAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      TextBox txt;
      for (int i = 1; i <= 5; i++)
      {
        txt = (TextBox)tabPage1.Controls["txtInBefore" + i.ToString()];
        SetTextboxNumber(txt);
        txt = (TextBox)tabPage1.Controls["txtOutAfter" + i.ToString()];
        SetTextboxNumber(txt);
        txt = (TextBox)tabPage1.Controls["txtInLater" + i.ToString()];
        SetTextboxNumber(txt);
        txt = (TextBox)tabPage1.Controls["txtInMaxLater" + i.ToString()];
        SetTextboxNumber(txt);
        txt = (TextBox)tabPage1.Controls["txtOutLeaveEarly" + i.ToString()];
        SetTextboxNumber(txt);
        txt = (TextBox)tabPage1.Controls["txtOutMaxLeaveEarly" + i.ToString()];
        SetTextboxNumber(txt);
      }
      SetTextboxNumber(txtInBeforeOtMin);
      SetTextboxNumber(txtOutAfterOtMin);
      SetTextboxNumber(textBox1);
      SetTextboxNumber(textBox2);
      SetTextboxNumber(textBox3);
      SetTextboxNumber(textBox4);
      LoadData();
      button1.ContextMenuStrip = null;
      button1.Enabled = SysID == "";
      button1.Visible = button1.Enabled;
      if (_ReadOnly)
      {
        label1.Enabled = false;
        txtNo.Enabled = false;
        label2.Enabled = false;
        txtName.Enabled = false;
        label3.Enabled = false;
        txtShiftNormalMin.Enabled = false;
        for (int i = 0; i < tabPage1.Controls.Count; i++)
        {
          tabPage1.Controls[i].Enabled = false;
        }
        for (int i = 0; i < tabPage2.Controls.Count; i++)
        {
          tabPage2.Controls[i].Enabled = false;
        }
      }
    }

    public frmKQShiftAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      _ReadOnly = false;
      InitializeComponent();
    }

    public frmKQShiftAdd(string title, string CurrentTool, string GUID, bool ReadOnly)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      _ReadOnly = ReadOnly;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      TCommonType ctype = new TCommonType("", "", "", true);
      TextBox txt;
      MaskedTextBox txtA;
      MaskedTextBox txtB;
      ComboBox cbb;
      CheckBox chk;
      int v = 0;
      for (int i = 1; i <= 5; i++)
      {
        cbb = (ComboBox)tabPage1.Controls["cbbOtType" + i.ToString()];
        cbb.Items.Clear();
        cbb.Items.Add(ctype);
      }
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002002, new string[] { "0" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["OtTypeSysID"].ToString(), dr["OtTypeNo"].ToString(), dr["OtTypeName"].ToString(), true);
          for (int i = 1; i <= 5; i++)
          {
            cbb = (ComboBox)tabPage1.Controls["cbbOtType" + i.ToString()];
            cbb.Items.Add(ctype);
          }
        }
        if (SysID == "")
        {
          for (int i = 1; i <= 5; i++)
          {
            cbb = (ComboBox)tabPage1.Controls["cbbOtType" + i.ToString()];
            cbb.SelectedIndex = 0;
            cbb = (ComboBox)tabPage1.Controls["cbbInNextDay" + i.ToString()];
            cbb.SelectedIndex = 0;
            cbb = (ComboBox)tabPage1.Controls["cbbOutNextDay" + i.ToString()];
            cbb.SelectedIndex = 0;
          }
        }
        else
        {
          txtNo.Enabled = false;
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002003, new string[] { "4", SysID }));
          if (dr.Read())
          {
            txtNo.Text = dr["ShiftNo"].ToString();
            txtName.Text = dr["ShiftName"].ToString();
            txtShiftNormalMin.Text = dr["ShiftNormalHrs"].ToString();
            for (int i = 1; i <= 5; i++)
            {
              txtA = (MaskedTextBox)tabPage1.Controls["txtInTime" + i.ToString()];
              txtB = (MaskedTextBox)tabPage1.Controls["txtOutTime" + i.ToString()];
              txtA.Text = Pub.ValidatTime(dr["InTime" + i.ToString() + "Str"].ToString());
              txtB.Text = Pub.ValidatTime(dr["OutTime" + i.ToString() + "Str"].ToString());
              cbb = (ComboBox)tabPage1.Controls["cbbInNextDay" + i.ToString()];
              cbb.SelectedIndex = dr["InNextDay" + i.ToString()].ToString().ToUpper() == "Y" ? 1 : 0;
              cbb = (ComboBox)tabPage1.Controls["cbbOutNextDay" + i.ToString()];
              cbb.SelectedIndex = dr["OutNextDay" + i.ToString()].ToString().ToUpper() == "Y" ? 1 : 0;
              chk = (CheckBox)tabPage1.Controls["chkInIsPressed" + i.ToString()];
              chk.Checked = dr["InIsPressed" + i.ToString()].ToString().ToUpper() == "Y";
              chk = (CheckBox)tabPage1.Controls["chkOutIsPressed" + i.ToString()];
              chk.Checked = dr["OutIsPressed" + i.ToString()].ToString().ToUpper() == "Y";
              txt = (TextBox)tabPage1.Controls["txtInBefore" + i.ToString()];
              int.TryParse(dr["InBefore" + i.ToString()].ToString(), out v);
              v = v / 60;
              txt.Text = v.ToString();
              txt = (TextBox)tabPage1.Controls["txtOutAfter" + i.ToString()];
              int.TryParse(dr["OutAfter" + i.ToString()].ToString(), out v);
              v = v / 60;
              txt.Text = v.ToString();
              txt = (TextBox)tabPage1.Controls["txtInLater" + i.ToString()];
              int.TryParse(dr["InLater" + i.ToString()].ToString(), out v);
              v = v / 60;
              txt.Text = v.ToString();
              txt = (TextBox)tabPage1.Controls["txtInMaxLater" + i.ToString()];
              int.TryParse(dr["InMaxLater" + i.ToString()].ToString(), out v);
              v = v / 60;
              txt.Text = v.ToString();
              txt = (TextBox)tabPage1.Controls["txtOutLeaveEarly" + i.ToString()];
              int.TryParse(dr["OutLeaveEarly" + i.ToString()].ToString(), out v);
              v = v / 60;
              txt.Text = v.ToString();
              txt = (TextBox)tabPage1.Controls["txtOutMaxLeaveEarly" + i.ToString()];
              int.TryParse(dr["OutMaxLeaveEarly" + i.ToString()].ToString(), out v);
              v = v / 60;
              txt.Text = v.ToString();
              cbb = (ComboBox)tabPage1.Controls["cbbOtType" + i.ToString()];
              cbb.SelectedIndex = 0;
              for (int j = 0; j < cbb.Items.Count; j++)
              {
                if (((TCommonType)cbb.Items[j]).id == dr["OtTypeSysID" + i.ToString()].ToString())
                {
                  cbb.SelectedIndex = j;
                  break;
                }
              }
            }
            chkNormalRound.Checked = dr["AddISNormalGetInt"].ToString().ToUpper() == "Y";
            chkOtRound.Checked = dr["AddISOtGetInt"].ToString().ToUpper() == "Y";
            rbRoundHour.Checked = dr["AddGetInt"].ToString() == "2";
            rbRoundHalf.Checked = !rbRoundHour.Checked;
            chkInBeforeOt.Checked = dr["AddIsAutoInBeforeOt"].ToString().ToUpper() == "Y";
            txtInBeforeOtMin.Text = dr["AddInBeforeOtMin"].ToString();
            chkOutAfterOt.Checked = dr["AddIsAutoOutAfterOt"].ToString().ToUpper() == "Y";
            txtOutAfterOtMin.Text = dr["AddOutAfterOtMin"].ToString();
            textBox1.Text = dr["AddRestMin1"].ToString();
            textBox2.Text = dr["AddRestMin2"].ToString();
            textBox3.Text = dr["AddRestMin3"].ToString();
            textBox4.Text = dr["AddRestMin4"].ToString();
            for (int i = 1; i <= 5; i++)
            {
              chk = (CheckBox)tabPage2.Controls["chkISFu" + i.ToString()];
              chk.Checked = dr["AddISFu" + i.ToString()].ToString().ToUpper() == "Y";
            }
            checkBox1.Checked = Pub.ValueToBool(dr["AddIsZL1"].ToString());
            checkBox2.Checked = Pub.ValueToBool(dr["AddIsZL2"].ToString());
            checkBox3.Checked = Pub.ValueToBool(dr["AddIsZL3"].ToString());
            checkBox4.Checked = Pub.ValueToBool(dr["AddIsZL4"].ToString());
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
    }

    private void button1_Click(object sender, EventArgs e)
    {
      int x = button1.ClientRectangle.X + button1.Width;
      int y = button1.ClientRectangle.Y;
      this.contextMenu.Show((Control)sender, x, y);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string ShiftNo = txtNo.Text.Trim();
      string ShiftName = txtName.Text.Trim();
      if (!Pub.CheckTextMaxLength(label1.Text, ShiftNo, txtNo.MaxLength)) return;
      if (!Pub.CheckTextMaxLength(label2.Text, ShiftName, txtName.MaxLength)) return;
      if (ShiftNo == "")
      {
        txtNo.Focus();
        ShowErrorEnterCorrect(label1.Text);
        return;
      }
      if (ShiftName == "")
      {
        txtName.Focus();
        ShowErrorEnterCorrect(label2.Text);
        return;
      }
      int[] InTime = new int[5];
      int[] OutTime = new int[5];
      string[] InIsPressed = new string[5];
      string[] OutIsPressed = new string[5];
      int[] InBefore = new int[5];
      int[] OutAfter = new int[5];
      int[] InLater = new int[5];
      int[] InMaxLater = new int[5];
      int[] OutLeaveEarly = new int[5];
      int[] OutMaxLeaveEarly = new int[5];
      string[] OtTypeSysID = new string[5];
      int ShiftNormalMin = 0;
      int ShiftOTMin = 0;
      int[] RestMin = new int[4];
      string[] ISFu = new string[5];
      const int DaySeconds = 24 * 3600;
      TextBox txt;
      MaskedTextBox txtA;
      MaskedTextBox txtB;
      ComboBox cbb;
      CheckBox chk;
      DateTime dt = new DateTime();
      for (int i = 1; i <= 5; i++)
      {
        txtA = (MaskedTextBox)tabPage1.Controls["txtInTime" + i.ToString()];
        txtB = (MaskedTextBox)tabPage1.Controls["txtOutTime" + i.ToString()];
        if ((txtA.Text == "00:00") && (txtB.Text == "00:00")) continue;
        if (!DateTime.TryParse(txtA.Text, out dt)) continue;
        InTime[i - 1] = dt.Hour * 3600 + dt.Minute * 60;
        cbb = (ComboBox)tabPage1.Controls["cbbInNextDay" + i.ToString()];
        if (cbb.SelectedIndex == 1) InTime[i - 1] += DaySeconds;
        if (!DateTime.TryParse(txtB.Text, out dt)) continue;
        OutTime[i - 1] = dt.Hour * 3600 + dt.Minute * 60;
        cbb = (ComboBox)tabPage1.Controls["cbbOutNextDay" + i.ToString()];
        if (cbb.SelectedIndex == 1) OutTime[i - 1] += DaySeconds;
        if (InTime[i - 1] >= OutTime[i - 1])
        {
          txtB.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
          return;
        }
        chk = (CheckBox)tabPage1.Controls["chkInIsPressed" + i.ToString()];
        InIsPressed[i - 1] = chk.Checked ? "Y" : "N";
        chk = (CheckBox)tabPage1.Controls["chkOutIsPressed" + i.ToString()];
        OutIsPressed[i - 1] = chk.Checked ? "Y" : "N";
        txt = (TextBox)tabPage1.Controls["txtInBefore" + i.ToString()];
        int.TryParse(txt.Text.Trim(), out InBefore[i - 1]);
        InBefore[i - 1] *= 60;
        txt = (TextBox)tabPage1.Controls["txtOutAfter" + i.ToString()];
        int.TryParse(txt.Text.Trim(), out OutAfter[i - 1]);
        OutAfter[i - 1] *= 60;
        txt = (TextBox)tabPage1.Controls["txtInLater" + i.ToString()];
        int.TryParse(txt.Text.Trim(), out InLater[i - 1]);
        InLater[i - 1] *= 60;
        txt = (TextBox)tabPage1.Controls["txtInMaxLater" + i.ToString()];
        int.TryParse(txt.Text.Trim(), out InMaxLater[i - 1]);
        InMaxLater[i - 1] *= 60;
        txt = (TextBox)tabPage1.Controls["txtOutLeaveEarly" + i.ToString()];
        int.TryParse(txt.Text.Trim(), out OutLeaveEarly[i - 1]);
        OutLeaveEarly[i - 1] *= 60;
        txt = (TextBox)tabPage1.Controls["txtOutMaxLeaveEarly" + i.ToString()];
        int.TryParse(txt.Text.Trim(), out OutMaxLeaveEarly[i - 1]);
        OutMaxLeaveEarly[i - 1] *= 60;
        cbb = (ComboBox)tabPage1.Controls["cbbOtType" + i.ToString()];
        OtTypeSysID[i - 1] = ((TCommonType)cbb.Items[cbb.SelectedIndex]).id;
        if (OtTypeSysID[i - 1] == "")
          ShiftNormalMin += OutTime[i - 1] - InTime[i - 1];
        else
          ShiftOTMin += OutTime[i - 1] - InTime[i - 1];
      }
      ShiftNormalMin = ShiftNormalMin / 60;
      ShiftOTMin = ShiftOTMin / 60;
      double ShiftNormalHrs = Convert.ToDouble(ShiftNormalMin) / 60;
      string NormalRound = chkNormalRound.Checked ? "Y" : "N";
      string OtRound = chkOtRound.Checked ? "Y" : "N";
      string RoundFlag = rbRoundHalf.Checked ? "1" : "2";
      string InBeforeOt = chkInBeforeOt.Checked ? "Y" : "N";
      int InBeforeOtMin = 0;
      int.TryParse(txtInBeforeOtMin.Text.Trim(), out InBeforeOtMin);
      string OutAfterOt = chkOutAfterOt.Checked ? "Y" : "N";
      int OutAfterOtMin = 0;
      int.TryParse(txtOutAfterOtMin.Text.Trim(), out OutAfterOtMin);
      int.TryParse(textBox1.Text.Trim(), out RestMin[0]);
      int.TryParse(textBox2.Text.Trim(), out RestMin[1]);
      int.TryParse(textBox3.Text.Trim(), out RestMin[2]);
      int.TryParse(textBox4.Text.Trim(), out RestMin[3]);
      for (int i = 1; i <= 5; i++)
      {
        chk = (CheckBox)tabPage2.Controls["chkISFu" + i.ToString()];
        ISFu[i - 1] = chk.Checked ? "Y" : "N";
      }
      string[] vl = new string[84];
      vl[1] = "'" + ShiftNo + "'";
      vl[2] = "'" + ShiftName + "'";
      vl[3] = ShiftNormalHrs.ToString();
      vl[4] = ShiftNormalMin.ToString();
      vl[5] = ShiftOTMin.ToString();
      for (int i = 0; i < 5; i++)
      {
        if ((InTime[i] == 0) && OutTime[i] == 0)
        {
          vl[5 + i * 11 + 1] = "NULL";
          vl[5 + i * 11 + 2] = "NULL";
          vl[5 + i * 11 + 3] = "NULL";
          vl[5 + i * 11 + 4] = "NULL";
          vl[5 + i * 11 + 5] = "NULL";
          vl[5 + i * 11 + 6] = "NULL";
          vl[5 + i * 11 + 7] = "NULL";
          vl[5 + i * 11 + 8] = "NULL";
          vl[5 + i * 11 + 9] = "NULL";
          vl[5 + i * 11 + 10] = "NULL";
          vl[5 + i * 11 + 11] = "NULL";
        }
        else
        {
          vl[5 + i * 11 + 1] = InTime[i].ToString();
          vl[5 + i * 11 + 2] = OutTime[i].ToString();
          vl[5 + i * 11 + 3] = "'" + InIsPressed[i] + "'";
          vl[5 + i * 11 + 4] = "'" + OutIsPressed[i] + "'";
          vl[5 + i * 11 + 5] = InBefore[i].ToString();
          vl[5 + i * 11 + 6] = OutAfter[i].ToString();
          vl[5 + i * 11 + 7] = InLater[i].ToString();
          vl[5 + i * 11 + 8] = InMaxLater[i].ToString();
          vl[5 + i * 11 + 9] = OutLeaveEarly[i].ToString();
          vl[5 + i * 11 + 10] = OutMaxLeaveEarly[i].ToString();
          vl[5 + i * 11 + 11] = "'" + OtTypeSysID[i] + "'";
        }
      }
      for (int i = 0; i < 4; i++)
      {
        vl[61 + i] = RestMin[i].ToString();
      }
      vl[65] = "NULL";
      vl[66] = "NULL";
      vl[67] = "'" + NormalRound + "'";
      vl[68] = "'" + OtRound + "'";
      vl[69] = "'" + RoundFlag + "'";
      vl[70] = "'" + InBeforeOt + "'";
      vl[71] = InBeforeOtMin.ToString();
      vl[72] = "'" + OutAfterOt + "'";
      vl[73] = OutAfterOtMin.ToString();
      for (int i = 0; i < 5; i++)
      {
        vl[74 + i] = "'" + ISFu[i] + "'";
      }
      vl[79] = "0";
      vl[80] = checkBox1.Checked ? "1" : "0";
      vl[81] = checkBox2.Checked ? "1" : "0";
      vl[82] = checkBox3.Checked ? "1" : "0";
      vl[83] = checkBox4.Checked ? "1" : "0";
      DataTableReader dr = null;
      bool IsOk = true;
      List<string> sql = new List<string>();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002003, new string[] { "5", ShiftNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            vl[0] = "1";
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002003, new string[] { "6", SysID, ShiftNo }));
          if (dr.Read())
          {
            IsOk = false;
            txtNo.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            vl[0] = "2";
            vl[79] = "'" + SysID + "'";
          }
        }
      }
      catch (Exception E)
      {
        IsOk = false;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (!IsOk) return;
      sql.Add(Pub.GetSQL(DBCode.DB_002003, vl));
      if (db.ExecSQL(sql) != 0) IsOk = false;
      if (IsOk)
      {
        db.WriteSYLog(this.Text, CurrentOprt, sql);
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void Item001_Click(object sender, EventArgs e)
    {
      TextBox txt;
      MaskedTextBox txtA;
      MaskedTextBox txtB;
      ComboBox cbb;
      CheckBox chk;
      txtName.Text = ((ToolStripMenuItem)sender).Text;
      for (int i = 1; i <= 5; i++)
      {
        txtA = (MaskedTextBox)tabPage1.Controls["txtInTime" + i.ToString()];
        txtB = (MaskedTextBox)tabPage1.Controls["txtOutTime" + i.ToString()];
        if ((i == 1) || (i == 2))
        {
          txtA.Text = i == 1 ? "09:00" : "13:30";
          txtB.Text = i == 1 ? "12:00" : "18:00";
        }
        else
        {
          txtA.Text = "00:00";
          txtB.Text = "00:00";
        }
        cbb = (ComboBox)tabPage1.Controls["cbbInNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        cbb = (ComboBox)tabPage1.Controls["cbbOutNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        chk = (CheckBox)tabPage1.Controls["chkInIsPressed" + i.ToString()];
        chk.Checked = false;
        if (i == 1) chk.Checked = true;
        chk = (CheckBox)tabPage1.Controls["chkOutIsPressed" + i.ToString()];
        chk.Checked = false;
        if (i == 2) chk.Checked = true;
        txt = (TextBox)tabPage1.Controls["txtInBefore" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "120";
        txt = (TextBox)tabPage1.Controls["txtOutAfter" + i.ToString()];
        txt.Text = "0";
        if (i == 2) txt.Text = "360";
        txt = (TextBox)tabPage1.Controls["txtInLater" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtInMaxLater" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "60";
        txt = (TextBox)tabPage1.Controls["txtOutLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if (i == 2) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtOutMaxLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if (i == 2) txt.Text = "60";
        cbb = (ComboBox)tabPage1.Controls["cbbOtType" + i.ToString()];
        cbb.SelectedIndex = 0;
      }
      chkNormalRound.Checked = false;
      chkOtRound.Checked = false;
      rbRoundHour.Checked = false;
      rbRoundHalf.Checked = !rbRoundHour.Checked;
      chkInBeforeOt.Checked = false;
      txtInBeforeOtMin.Text = "0";
      chkOutAfterOt.Checked = false;
      txtOutAfterOtMin.Text = "0";
      textBox1.Text = "0";
      textBox2.Text = "0";
      textBox3.Text = "0";
      textBox4.Text = "0";
      for (int i = 1; i <= 5; i++)
      {
        chk = (CheckBox)tabPage2.Controls["chkISFu" + i.ToString()];
        chk.Checked = false;
      }
    }

    private void Item002_Click(object sender, EventArgs e)
    {
      TextBox txt;
      MaskedTextBox txtA;
      MaskedTextBox txtB;
      ComboBox cbb;
      CheckBox chk;
      txtName.Text = ((ToolStripMenuItem)sender).Text;
      for (int i = 1; i <= 5; i++)
      {
        txtA = (MaskedTextBox)tabPage1.Controls["txtInTime" + i.ToString()];
        txtB = (MaskedTextBox)tabPage1.Controls["txtOutTime" + i.ToString()];
        if (i == 1)
        {
          txtA.Text = "08:00";
          txtB.Text = "20:00";
        }
        else
        {
          txtA.Text = "00:00";
          txtB.Text = "00:00";
        }
        cbb = (ComboBox)tabPage1.Controls["cbbInNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        cbb = (ComboBox)tabPage1.Controls["cbbOutNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        chk = (CheckBox)tabPage1.Controls["chkInIsPressed" + i.ToString()];
        chk.Checked = false;
        if (i == 1) chk.Checked = true;
        chk = (CheckBox)tabPage1.Controls["chkOutIsPressed" + i.ToString()];
        chk.Checked = false;
        if (i == 1) chk.Checked = true;
        txt = (TextBox)tabPage1.Controls["txtInBefore" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "120";
        txt = (TextBox)tabPage1.Controls["txtOutAfter" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "240";
        txt = (TextBox)tabPage1.Controls["txtInLater" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtInMaxLater" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "60";
        txt = (TextBox)tabPage1.Controls["txtOutLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtOutMaxLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "60";
        cbb = (ComboBox)tabPage1.Controls["cbbOtType" + i.ToString()];
        cbb.SelectedIndex = 0;
      }
      chkNormalRound.Checked = false;
      chkOtRound.Checked = false;
      rbRoundHour.Checked = false;
      rbRoundHalf.Checked = !rbRoundHour.Checked;
      chkInBeforeOt.Checked = false;
      txtInBeforeOtMin.Text = "0";
      chkOutAfterOt.Checked = false;
      txtOutAfterOtMin.Text = "0";
      textBox1.Text = "0";
      textBox2.Text = "0";
      textBox3.Text = "0";
      textBox4.Text = "0";
      for (int i = 1; i <= 5; i++)
      {
        chk = (CheckBox)tabPage2.Controls["chkISFu" + i.ToString()];
        chk.Checked = false;
      }
    }

    private void Item003_Click(object sender, EventArgs e)
    {
      TextBox txt;
      MaskedTextBox txtA;
      MaskedTextBox txtB;
      ComboBox cbb;
      CheckBox chk;
      txtName.Text = ((ToolStripMenuItem)sender).Text;
      for (int i = 1; i <= 5; i++)
      {
        txtA = (MaskedTextBox)tabPage1.Controls["txtInTime" + i.ToString()];
        txtB = (MaskedTextBox)tabPage1.Controls["txtOutTime" + i.ToString()];
        if (i == 1)
        {
          txtA.Text = "20:00";
          txtB.Text = "08:00";
        }
        else
        {
          txtA.Text = "00:00";
          txtB.Text = "00:00";
        }
        cbb = (ComboBox)tabPage1.Controls["cbbInNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        cbb = (ComboBox)tabPage1.Controls["cbbOutNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        if (i == 1) cbb.SelectedIndex = 1;
        chk = (CheckBox)tabPage1.Controls["chkInIsPressed" + i.ToString()];
        chk.Checked = false;
        if (i == 1) chk.Checked = true;
        chk = (CheckBox)tabPage1.Controls["chkOutIsPressed" + i.ToString()];
        chk.Checked = false;
        if (i == 1) chk.Checked = true;
        txt = (TextBox)tabPage1.Controls["txtInBefore" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "120";
        txt = (TextBox)tabPage1.Controls["txtOutAfter" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "240";
        txt = (TextBox)tabPage1.Controls["txtInLater" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtInMaxLater" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "60";
        txt = (TextBox)tabPage1.Controls["txtOutLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtOutMaxLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "60";
        cbb = (ComboBox)tabPage1.Controls["cbbOtType" + i.ToString()];
        cbb.SelectedIndex = 0;
      }
      chkNormalRound.Checked = false;
      chkOtRound.Checked = false;
      rbRoundHour.Checked = false;
      rbRoundHalf.Checked = !rbRoundHour.Checked;
      chkInBeforeOt.Checked = false;
      txtInBeforeOtMin.Text = "0";
      chkOutAfterOt.Checked = false;
      txtOutAfterOtMin.Text = "0";
      textBox1.Text = "0";
      textBox2.Text = "0";
      textBox3.Text = "0";
      textBox4.Text = "0";
      for (int i = 1; i <= 5; i++)
      {
        chk = (CheckBox)tabPage2.Controls["chkISFu" + i.ToString()];
        chk.Checked = false;
      }
    }

    private void Item004_Click(object sender, EventArgs e)
    {
      TextBox txt;
      MaskedTextBox txtA;
      MaskedTextBox txtB;
      ComboBox cbb;
      CheckBox chk;
      txtName.Text = ((ToolStripMenuItem)sender).Text;
      for (int i = 1; i <= 5; i++)
      {
        txtA = (MaskedTextBox)tabPage1.Controls["txtInTime" + i.ToString()];
        txtB = (MaskedTextBox)tabPage1.Controls["txtOutTime" + i.ToString()];
        if (i == 1)
        {
          txtA.Text = "08:00";
          txtB.Text = "16:00";
        }
        else
        {
          txtA.Text = "00:00";
          txtB.Text = "00:00";
        }
        cbb = (ComboBox)tabPage1.Controls["cbbInNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        cbb = (ComboBox)tabPage1.Controls["cbbOutNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        chk = (CheckBox)tabPage1.Controls["chkInIsPressed" + i.ToString()];
        chk.Checked = false;
        if (i == 1) chk.Checked = true;
        chk = (CheckBox)tabPage1.Controls["chkOutIsPressed" + i.ToString()];
        chk.Checked = false;
        if (i == 1) chk.Checked = true;
        txt = (TextBox)tabPage1.Controls["txtInBefore" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "120";
        txt = (TextBox)tabPage1.Controls["txtOutAfter" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "240";
        txt = (TextBox)tabPage1.Controls["txtInLater" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtInMaxLater" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "60";
        txt = (TextBox)tabPage1.Controls["txtOutLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtOutMaxLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "60";
        cbb = (ComboBox)tabPage1.Controls["cbbOtType" + i.ToString()];
        cbb.SelectedIndex = 0;
      }
      chkNormalRound.Checked = false;
      chkOtRound.Checked = false;
      rbRoundHour.Checked = false;
      rbRoundHalf.Checked = !rbRoundHour.Checked;
      chkInBeforeOt.Checked = false;
      txtInBeforeOtMin.Text = "0";
      chkOutAfterOt.Checked = false;
      txtOutAfterOtMin.Text = "0";
      textBox1.Text = "0";
      textBox2.Text = "0";
      textBox3.Text = "0";
      textBox4.Text = "0";
      for (int i = 1; i <= 5; i++)
      {
        chk = (CheckBox)tabPage2.Controls["chkISFu" + i.ToString()];
        chk.Checked = false;
      }
    }

    private void Item005_Click(object sender, EventArgs e)
    {
      TextBox txt;
      MaskedTextBox txtA;
      MaskedTextBox txtB;
      ComboBox cbb;
      CheckBox chk;
      txtName.Text = ((ToolStripMenuItem)sender).Text;
      for (int i = 1; i <= 5; i++)
      {
        txtA = (MaskedTextBox)tabPage1.Controls["txtInTime" + i.ToString()];
        txtB = (MaskedTextBox)tabPage1.Controls["txtOutTime" + i.ToString()];
        if (i == 1)
        {
          txtA.Text = "16:00";
          txtB.Text = "00:00";
        }
        else
        {
          txtA.Text = "00:00";
          txtB.Text = "00:00";
        }
        cbb = (ComboBox)tabPage1.Controls["cbbInNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        cbb = (ComboBox)tabPage1.Controls["cbbOutNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        if (i == 1) cbb.SelectedIndex = 1;
        chk = (CheckBox)tabPage1.Controls["chkInIsPressed" + i.ToString()];
        chk.Checked = false;
        if (i == 1) chk.Checked = true;
        chk = (CheckBox)tabPage1.Controls["chkOutIsPressed" + i.ToString()];
        chk.Checked = false;
        if (i == 1) chk.Checked = true;
        txt = (TextBox)tabPage1.Controls["txtInBefore" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "120";
        txt = (TextBox)tabPage1.Controls["txtOutAfter" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "240";
        txt = (TextBox)tabPage1.Controls["txtInLater" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtInMaxLater" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "60";
        txt = (TextBox)tabPage1.Controls["txtOutLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtOutMaxLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "60";
        cbb = (ComboBox)tabPage1.Controls["cbbOtType" + i.ToString()];
        cbb.SelectedIndex = 0;
      }
      chkNormalRound.Checked = false;
      chkOtRound.Checked = false;
      rbRoundHour.Checked = false;
      rbRoundHalf.Checked = !rbRoundHour.Checked;
      chkInBeforeOt.Checked = false;
      txtInBeforeOtMin.Text = "0";
      chkOutAfterOt.Checked = false;
      txtOutAfterOtMin.Text = "0";
      textBox1.Text = "0";
      textBox2.Text = "0";
      textBox3.Text = "0";
      textBox4.Text = "0";
      for (int i = 1; i <= 5; i++)
      {
        chk = (CheckBox)tabPage2.Controls["chkISFu" + i.ToString()];
        chk.Checked = false;
      }
    }

    private void Item006_Click(object sender, EventArgs e)
    {
      TextBox txt;
      MaskedTextBox txtA;
      MaskedTextBox txtB;
      ComboBox cbb;
      CheckBox chk;
      txtName.Text = ((ToolStripMenuItem)sender).Text;
      for (int i = 1; i <= 5; i++)
      {
        txtA = (MaskedTextBox)tabPage1.Controls["txtInTime" + i.ToString()];
        txtB = (MaskedTextBox)tabPage1.Controls["txtOutTime" + i.ToString()];
        if (i == 1)
        {
          txtA.Text = "00:00";
          txtB.Text = "08:00";
        }
        else
        {
          txtA.Text = "00:00";
          txtB.Text = "00:00";
        }
        cbb = (ComboBox)tabPage1.Controls["cbbInNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        cbb = (ComboBox)tabPage1.Controls["cbbOutNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        chk = (CheckBox)tabPage1.Controls["chkInIsPressed" + i.ToString()];
        chk.Checked = false;
        if (i == 1) chk.Checked = true;
        chk = (CheckBox)tabPage1.Controls["chkOutIsPressed" + i.ToString()];
        chk.Checked = false;
        if (i == 1) chk.Checked = true;
        txt = (TextBox)tabPage1.Controls["txtInBefore" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "120";
        txt = (TextBox)tabPage1.Controls["txtOutAfter" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "240";
        txt = (TextBox)tabPage1.Controls["txtInLater" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtInMaxLater" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "60";
        txt = (TextBox)tabPage1.Controls["txtOutLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtOutMaxLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if (i == 1) txt.Text = "60";
        cbb = (ComboBox)tabPage1.Controls["cbbOtType" + i.ToString()];
        cbb.SelectedIndex = 0;
      }
      chkNormalRound.Checked = false;
      chkOtRound.Checked = false;
      rbRoundHour.Checked = false;
      rbRoundHalf.Checked = !rbRoundHour.Checked;
      chkInBeforeOt.Checked = false;
      txtInBeforeOtMin.Text = "0";
      chkOutAfterOt.Checked = false;
      txtOutAfterOtMin.Text = "0";
      textBox1.Text = "0";
      textBox2.Text = "0";
      textBox3.Text = "0";
      textBox4.Text = "0";
      for (int i = 1; i <= 5; i++)
      {
        chk = (CheckBox)tabPage2.Controls["chkISFu" + i.ToString()];
        chk.Checked = false;
      }
    }

    private void Item007_Click(object sender, EventArgs e)
    {
      TextBox txt;
      MaskedTextBox txtA;
      MaskedTextBox txtB;
      ComboBox cbb;
      CheckBox chk;
      txtName.Text = ((ToolStripMenuItem)sender).Text;
      for (int i = 1; i <= 5; i++)
      {
        txtA = (MaskedTextBox)tabPage1.Controls["txtInTime" + i.ToString()];
        txtB = (MaskedTextBox)tabPage1.Controls["txtOutTime" + i.ToString()];
        if ((i == 1) || (i == 2))
        {
          txtA.Text = i == 1 ? "09:00" : "13:30";
          txtB.Text = i == 1 ? "12:00" : "18:00";
        }
        else if (i == 3)
        {
          txtA.Text = "18:30";
          txtB.Text = "23:00";
        }
        else
        {
          txtA.Text = "00:00";
          txtB.Text = "00:00";
        }
        cbb = (ComboBox)tabPage1.Controls["cbbInNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        cbb = (ComboBox)tabPage1.Controls["cbbOutNextDay" + i.ToString()];
        cbb.SelectedIndex = 0;
        chk = (CheckBox)tabPage1.Controls["chkInIsPressed" + i.ToString()];
        chk.Checked = false;
        if ((i == 1) || (i == 3)) chk.Checked = true;
        chk = (CheckBox)tabPage1.Controls["chkOutIsPressed" + i.ToString()];
        chk.Checked = false;
        if ((i == 2) || (i == 3)) chk.Checked = true;
        txt = (TextBox)tabPage1.Controls["txtInBefore" + i.ToString()];
        txt.Text = "0";
        if ((i == 1) || (i == 3)) txt.Text = "120";
        txt = (TextBox)tabPage1.Controls["txtOutAfter" + i.ToString()];
        txt.Text = "0";
        if ((i == 2) || (i == 3)) txt.Text = "360";
        txt = (TextBox)tabPage1.Controls["txtInLater" + i.ToString()];
        txt.Text = "0";
        if ((i == 1) || (i == 3)) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtInMaxLater" + i.ToString()];
        txt.Text = "0";
        if ((i == 1) || (i == 3)) txt.Text = "60";
        txt = (TextBox)tabPage1.Controls["txtOutLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if ((i == 2) || (i == 3)) txt.Text = "5";
        txt = (TextBox)tabPage1.Controls["txtOutMaxLeaveEarly" + i.ToString()];
        txt.Text = "0";
        if ((i == 2) || (i == 3)) txt.Text = "60";
        cbb = (ComboBox)tabPage1.Controls["cbbOtType" + i.ToString()];
        cbb.SelectedIndex = 0;
        if ((i == 3) && (cbb.Items.Count > 2)) cbb.SelectedIndex = 1;
      }
      chkNormalRound.Checked = false;
      chkOtRound.Checked = false;
      rbRoundHour.Checked = false;
      rbRoundHalf.Checked = !rbRoundHour.Checked;
      chkInBeforeOt.Checked = false;
      txtInBeforeOtMin.Text = "0";
      chkOutAfterOt.Checked = false;
      txtOutAfterOtMin.Text = "0";
      textBox1.Text = "0";
      textBox2.Text = "0";
      textBox3.Text = "0";
      textBox4.Text = "0";
      for (int i = 1; i <= 5; i++)
      {
        chk = (CheckBox)tabPage2.Controls["chkISFu" + i.ToString()];
        chk.Checked = false;
      }
    }
  }
}