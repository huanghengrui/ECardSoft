using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacTimeAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "MJMacTimeAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      label1.ForeColor = Color.Red;
      checkBox1.ForeColor = Color.Blue;
      checkBox7.ForeColor = Color.Navy;
      SetTextboxNumber(txtID);
      groupBox3.Enabled = !SystemInfo.AdvTimeGroup;
      groupBox3.Visible = groupBox3.Enabled;
      panel1.Enabled = SystemInfo.AdvTimeGroup;
      panel1.Visible = panel1.Enabled;
      LoadData();
    }

    public frmMJMacTimeAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      TCommonType ctype;
      cbbInType1.Items.Clear();
      cbbInType2.Items.Clear();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SystemInfo.AdvTimeGroup)
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "103" }));
        else
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "102" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["TimeInTypeSysID"].ToString(), dr["TimeInTypeID"].ToString(),
            dr["TimeInTypeName"].ToString(), true);
          cbbInType1.Items.Add(ctype);
          cbbInType2.Items.Add(ctype);
        }
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "101" }));
          if (dr.Read())
          {
            int no = 0;
            int.TryParse(dr[0].ToString(), out no);
            if (no > SystemInfo.MaxTimeNo) no = SystemInfo.MaxTimeNo;
            txtID.Text = no.ToString();
          }
          cbbInType1.SelectedIndex = 0;
          cbbInType2.SelectedIndex = 0;
          if (SystemInfo.AdvTimeGroup)
          {
            cbbInType1.SelectedIndex = 1;
            cbbInType2.SelectedIndex = 1;
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "6", SysID }));
          if (dr.Read())
          {
            txtID.Text = dr["MacTimeNo"].ToString();
            txtName.Text = dr["MacTimeName"].ToString();
            MaskedTextBox txt;
            for (int i = 1; i <= 3; i++)
            {
              txt = (MaskedTextBox)groupBox1.Controls["txtBeginTime" + i.ToString()];
              txt.Text = dr["MacTimeBeginTime" + i.ToString()].ToString();
              txt = (MaskedTextBox)groupBox1.Controls["txtEndTime" + i.ToString()];
              txt.Text = dr["MacTimeEndTime" + i.ToString()].ToString();
            }
            for (int i = 4; i <= 6; i++)
            {
              txt = (MaskedTextBox)groupBox2.Controls["txtBeginTime" + i.ToString()];
              txt.Text = dr["MacTimeBeginTime" + i.ToString()].ToString();
              txt = (MaskedTextBox)groupBox2.Controls["txtEndTime" + i.ToString()];
              txt.Text = dr["MacTimeEndTime" + i.ToString()].ToString();
            }
            SetInTypeIndex(cbbInType1, dr["MacTimeInType1"].ToString());
            SetInTypeIndex(cbbInType2, dr["MacTimeInType2"].ToString());
            string binStr = Pub.DecToBin(dr["MacTimeWeekIndex"].ToString(), 7);
            if (binStr.Length == 7)
            {
              checkBox1.Checked = binStr.Substring(6, 1) == "1";
              checkBox2.Checked = binStr.Substring(0, 1) == "1";
              checkBox3.Checked = binStr.Substring(1, 1) == "1";
              checkBox4.Checked = binStr.Substring(2, 1) == "1";
              checkBox5.Checked = binStr.Substring(3, 1) == "1";
              checkBox6.Checked = binStr.Substring(4, 1) == "1";
              checkBox7.Checked = binStr.Substring(5, 1) == "1";
            }
            if (dr["MacTimeLimit"].ToString() == "1") rbLimitOne.Checked = true;
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

    private void SetInTypeIndex(ComboBox cbb, string id)
    {
      for (int i = 0; i < cbb.Items.Count; i++)
      {
        if (((TCommonType)cbb.Items[i]).id == id)
        {
          cbb.SelectedIndex = i;
          break;
        }
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!Pub.IsNumeric(txtID.Text.Trim()))
      {
        txtID.Focus();
        ShowErrorEnterCorrect(label1.Text);
        return;
      }
      int id = 0;
      int.TryParse(txtID.Text.Trim(), out id);
      if ((id < 0) || (id > SystemInfo.MaxTimeNo))
      {
        txtID.Focus();
        Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "Error101", ""), 0, SystemInfo.MaxTimeNo));
        return;
      }
      string name = txtName.Text.Trim();
      if (!Pub.CheckTextMaxLength(label10.Text, name, txtName.MaxLength)) return;
      DateTime dt = new DateTime();
      MaskedTextBox txt;
      string[] timeGroup1Begin = new string[6];
      string[] timeGroup1End = new string[6];
      for (int i = 1; i <= 3; i++)
      {
        txt = (MaskedTextBox)groupBox1.Controls["txtBeginTime" + i.ToString()];
        if (!DateTime.TryParse(txt.Text, out dt))
        {
          txt.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error00" + i.ToString(), ""));
          return;
        }
        timeGroup1Begin[i - 1] = txt.Text;
        txt = (MaskedTextBox)groupBox1.Controls["txtEndTime" + i.ToString()];
        if (!DateTime.TryParse(txt.Text, out dt))
        {
          txt.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error00" + i.ToString(), ""));
          return;
        }
        timeGroup1End[i - 1] = txt.Text;
      }
      for (int i = 4; i <= 6; i++)
      {
        txt = (MaskedTextBox)groupBox2.Controls["txtBeginTime" + i.ToString()];
        if (!DateTime.TryParse(txt.Text, out dt))
        {
          txt.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error00" + i.ToString(), ""));
          return;
        }
        timeGroup1Begin[i - 1] = txt.Text;
        txt = (MaskedTextBox)groupBox2.Controls["txtEndTime" + i.ToString()];
        if (!DateTime.TryParse(txt.Text, out dt))
        {
          txt.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error00" + i.ToString(), ""));
          return;
        }
        timeGroup1End[i - 1] = txt.Text;
      }
      if (cbbInType1.SelectedIndex < 0)
      {
        ShowErrorSelectCorrect(label5.Text);
        return;
      }
      string InType1 = ((TCommonType)cbbInType1.Items[cbbInType1.SelectedIndex]).id;
      if (cbbInType2.SelectedIndex < 0)
      {
        ShowErrorSelectCorrect(label6.Text);
        return;
      }
      string InType2 = ((TCommonType)cbbInType2.Items[cbbInType2.SelectedIndex]).id;
      int WeekIndex = Convert.ToByte(checkBox2.Checked) * 64;
      WeekIndex += Convert.ToByte(checkBox3.Checked) * 32;
      WeekIndex += Convert.ToByte(checkBox4.Checked) * 16;
      WeekIndex += Convert.ToByte(checkBox5.Checked) * 8;
      WeekIndex += Convert.ToByte(checkBox6.Checked) * 4;
      WeekIndex += Convert.ToByte(checkBox7.Checked) * 2;
      WeekIndex += Convert.ToByte(checkBox1.Checked) * 1;
      int TimeLimit = 0;
      if (rbLimitOne.Checked) TimeLimit = 1;
      DataTableReader dr = null;
      bool IsOk = false;
      string sql = "";
      try
      {
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "4", id.ToString() }));
          if (dr.Read())
          {
            txtID.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_003003, new string[] { "1", id.ToString(), name, timeGroup1Begin[0], timeGroup1End[0], 
              timeGroup1Begin[1], timeGroup1End[1], timeGroup1Begin[2], timeGroup1End[2], InType1, timeGroup1Begin[3], 
              timeGroup1End[3], timeGroup1Begin[4], timeGroup1End[4], timeGroup1Begin[5], timeGroup1End[5], InType2,
              WeekIndex.ToString(), TimeLimit.ToString() });
            db.ExecSQL(sql);
            IsOk = true;
          }
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "5", SysID, id.ToString() }));
          if (dr.Read())
          {
            txtID.Focus();
            ShowErrorCannotRepeated(label1.Text);
          }
          else
          {
            sql = Pub.GetSQL(DBCode.DB_003003, new string[] { "2", id.ToString(), name, timeGroup1Begin[0], timeGroup1End[0], 
              timeGroup1Begin[1], timeGroup1End[1], timeGroup1Begin[2], timeGroup1End[2], InType1, timeGroup1Begin[3], 
              timeGroup1End[3], timeGroup1Begin[4], timeGroup1End[4], timeGroup1Begin[5], timeGroup1End[5], InType2,
              WeekIndex.ToString(), TimeLimit.ToString(), SysID });
            db.ExecSQL(sql);
            IsOk = true;
          }
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E, sql);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (IsOk)
      {
        db.WriteSYLog(this.Text, CurrentOprt, sql);
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }
  }
}