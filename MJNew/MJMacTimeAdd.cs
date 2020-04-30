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
      SetTextboxNumber(txtTime1);
      SetTextboxNumber(txtTime2);
      SetTextboxNumber(txtTime3);
      SetTextboxNumber(txtTime4);
      SetTextboxNumber(txtTime5);
      SetTextboxNumber(txtTime6);
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
      cbbMode1.Items.Clear();
      cbbMode2.Items.Clear();
      cbbMode2.Items.Clear();
      cbbMode3.Items.Clear();
      cbbMode4.Items.Clear();
      cbbMode5.Items.Clear();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "103" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["TimeInTypeSysID"].ToString(), dr["TimeInTypeID"].ToString(),
            dr["TimeInTypeName"].ToString(), true);
          cbbMode1.Items.Add(ctype);
          cbbMode2.Items.Add(ctype);
          cbbMode3.Items.Add(ctype);
          cbbMode4.Items.Add(ctype);
          cbbMode5.Items.Add(ctype);
          cbbMode6.Items.Add(ctype);
        }
        if (SysID == "")
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "101" }));
          if (dr.Read())
          {
            int no = 0;
            int.TryParse(dr[0].ToString(), out no);
            if (no > SystemInfo.MaxTimeNoNew) no = SystemInfo.MaxTimeNoNew;
            txtID.Text = no.ToString();
          }
          cbbMode1.SelectedIndex = 1;
          cbbMode2.SelectedIndex = 1;
          cbbMode3.SelectedIndex = 1;
          cbbMode4.SelectedIndex = 1;
          cbbMode5.SelectedIndex = 1;
          cbbMode6.SelectedIndex = 1;
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003003, new string[] { "6", SysID }));
          if (dr.Read())
          {
            txtID.Text = dr["MacTimeNo"].ToString();
            txtName.Text = dr["MacTimeName"].ToString();
            TextBox txt;
            MaskedTextBox mtxt;
            for (int i = 1; i <= 6; i++)
            {
              txt = (TextBox)groupBox1.Controls["txtTime" + i.ToString()];
              txt.Text = dr["MacTimeTimes" + i.ToString()].ToString();
              mtxt = (MaskedTextBox)groupBox1.Controls["txtBegin" + i.ToString()];
              mtxt.Text = dr["MacTimeBeginTime" + i.ToString()].ToString();
              mtxt = (MaskedTextBox)groupBox1.Controls["txtEnd" + i.ToString()];
              mtxt.Text = dr["MacTimeEndTime" + i.ToString()].ToString();
            }
            SetInTypeIndex(cbbMode1, dr["MacTimeMode1"].ToString());
            SetInTypeIndex(cbbMode2, dr["MacTimeMode2"].ToString());
            SetInTypeIndex(cbbMode3, dr["MacTimeMode3"].ToString());
            SetInTypeIndex(cbbMode4, dr["MacTimeMode4"].ToString());
            SetInTypeIndex(cbbMode5, dr["MacTimeMode5"].ToString());
            SetInTypeIndex(cbbMode6, dr["MacTimeMode6"].ToString());
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
        Pub.ShowErrorMsg(string.Format(Pub.GetResText(formCode, "Error101", ""), 0, SystemInfo.MaxTimeNoNew));
        return;
      }
      string name = txtName.Text.Trim();
      if (!Pub.CheckTextMaxLength(label10.Text, name, txtName.MaxLength)) return;
      int v = 0;
      DateTime dt = new DateTime();
      TextBox txt;
      MaskedTextBox mtxt;
      ComboBox cbb;
      string[] Times = new string[6];
      string[] timeBegin = new string[6];
      string[] timeEnd = new string[6];
      string[] Mode = new string[6];
      for (int i = 1; i <= 6; i++)
      {
        txt = (TextBox)groupBox1.Controls["txtTime" + i.ToString()];
        if (!int.TryParse(txt.Text, out v) || v < 0 || v > 255)
        {
          txt.Focus();
          Pub.ShowErrorMsg(label2.Text + string.Format(Pub.GetResText(formCode, "ErrorTimes", ""), 0, 255));
          return;
        }
        Times[i - 1] = v.ToString();
        mtxt = (MaskedTextBox)groupBox1.Controls["txtBegin" + i.ToString()];
        if (!DateTime.TryParse(mtxt.Text, out dt))
        {
          mtxt.Focus();
          Pub.ShowErrorMsg(label4.Text + Pub.GetResText(formCode, "ErrorTime", ""));
          return;
        }
        timeBegin[i - 1] = mtxt.Text;
        mtxt = (MaskedTextBox)groupBox1.Controls["txtEnd" + i.ToString()];
        if (!DateTime.TryParse(mtxt.Text, out dt))
        {
          mtxt.Focus();
          Pub.ShowErrorMsg(label5.Text + Pub.GetResText(formCode, "ErrorTime", ""));
          return;
        }
        timeEnd[i - 1] = mtxt.Text;
        cbb = (ComboBox)groupBox1.Controls["cbbMode" + i.ToString()];
        if (cbb.SelectedIndex < 0)
        {
          ShowErrorSelectCorrect(label13.Text);
          return;
        }
        Mode[i - 1] = ((TCommonType)cbb.Items[cbb.SelectedIndex]).id;
      }
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
            sql = Pub.GetSQL(DBCode.DB_003003, new string[] { "2000", id.ToString(), name, Times[0], timeBegin[0], timeEnd[0], Mode[0],
              Times[1], timeBegin[1], timeEnd[1], Mode[1],Times[2], timeBegin[2], timeEnd[2], Mode[2],Times[3], timeBegin[3], 
              timeEnd[3], Mode[3], Times[4], timeBegin[4], timeEnd[4], Mode[4],Times[5], timeBegin[5], timeEnd[5], Mode[5]});
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
            sql = Pub.GetSQL(DBCode.DB_003003, new string[] { "2001", id.ToString(), name, Times[0], timeBegin[0], timeEnd[0], Mode[0],
              Times[1], timeBegin[1], timeEnd[1], Mode[1],Times[2], timeBegin[2], timeEnd[2], Mode[2],Times[3], timeBegin[3], 
              timeEnd[3], Mode[3], Times[4], timeBegin[4], timeEnd[4], Mode[4],Times[5], timeBegin[5], timeEnd[5], Mode[5], SysID });
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