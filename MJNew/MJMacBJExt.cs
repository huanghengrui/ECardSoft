using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacBJExt : frmBaseDialog
  {
    private const int MaxTime = 1000;
    private string[] source = new string[4];
    private bool IsInit = false;

    protected override void InitForm()
    {
      formCode = "MJMacBJExt";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      IsInit = true;
      LoadData();
      IsInit = false;
      SetTextboxNumber(txtTime1);
      SetTextboxNumber(txtTime2);
      SetTextboxNumber(txtTime3);
      SetTextboxNumber(txtTime4);
      SetTextboxNumber(txtLoop1);
      SetTextboxNumber(txtLoop2);
      SetTextboxNumber(txtLoop3);
      SetTextboxNumber(txtLoop4);
    }

    public frmMJMacBJExt(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      clb11.Items.Clear();
      clb12.Items.Clear();
      clb21.Items.Clear();
      clb22.Items.Clear();
      clb31.Items.Clear();
      clb32.Items.Clear();
      clb41.Items.Clear();
      clb42.Items.Clear();
      string s = "";
      for (int i = 1; i <= 7; i++)
      {
        s = Pub.GetResText(formCode, "Item" + i.ToString(), "");
        clb12.Items.Add(s);
        clb22.Items.Add(s);
        clb32.Items.Add(s);
        clb42.Items.Add(s);
      }
      string MacExtensionBoard = "";
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        TCommonType ctype;
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "7", SysID }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["MacDoorSysID"].ToString(), dr["MacDoorID"].ToString(),
            dr["MacDoorName"].ToString(), true);
          clb11.Items.Add(ctype);
          clb21.Items.Add(ctype);
          clb31.Items.Add(ctype);
          clb41.Items.Add(ctype);
        }
        dr.Close();
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "4", SysID }));
        if (dr.Read()) MacExtensionBoard = dr["MacExtensionBoard"].ToString();
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
      TMacExtensionBoardNew extBoard = new TMacExtensionBoardNew(MacExtensionBoard);
      CheckedListBox clb;
      CheckedListBox clb1;
      Button btn;
      TextBox txt1;
      TextBox txt2;
      for (int i = 0; i < 4; i++)
      {
        if (i == 0)
        {
          clb = clb11;
          clb1 = clb12;
          btn = btnAdv1;
          txt1 = txtTime1;
          txt2 = txtLoop1;
        }
        else if (i == 1)
        {
          clb = clb21;
          clb1 = clb22;
          btn = btnAdv2;
          txt1 = txtTime2;
          txt2 = txtLoop2;
        }
        else if (i == 2)
        {
          clb = clb31;
          clb1 = clb32;
          btn = btnAdv3;
          txt1 = txtTime3;
          txt2 = txtLoop3;
        }
        else
        {
          clb = clb41;
          clb1 = clb42;
          btn = btnAdv4;
          txt1 = txtTime4;
          txt2 = txtLoop4;
        }
        for (int j = 0; j < clb.Items.Count; j++)
        {
          if (((TCommonType)clb.Items[j]).id == extBoard.DoorID[i].ToString())
          {
            clb.SetItemChecked(j, true);
            break;
          }
        }
        for (int j = 0; j < clb1.Items.Count; j++)
        {
          clb1.SetItemChecked(j, extBoard.Events[i].Substring(j, 1) == "1");
        }
        txt1.Text = extBoard.TimeOut[i].ToString();
        txt2.Text = extBoard.TimeLoop[i].ToString();
        source[i] = extBoard.Souce[i];
      }
    }

    private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (IsInit) return;
      if (!(sender is CheckedListBox)) return;
      CheckedListBox clb = ((CheckedListBox)sender);
      for (int i = 0; i < clb.Items.Count; i++)
      {
        if (i != e.Index) clb.SetItemChecked(i, false);
      }
    }

    private void btnAdv_Click(object sender, EventArgs e)
    {
      if (!(sender is Button)) return;
      Button btn = ((Button)sender);
      string cap = "";
      int index = 0;
      if (btn.Name == btnAdv1.Name)
      {
        index = 0;
        cap = groupBox1.Text;
      }
      else if (btn.Name == btnAdv2.Name)
      {
        index = 1;
        cap = groupBox2.Text;
      }
      else if (btn.Name == btnAdv3.Name)
      {
        index = 2;
        cap = groupBox3.Text;
      }
      else if (btn.Name == btnAdv4.Name)
      {
        index = 3;
        cap = groupBox4.Text;
      }
      frmMJMacBJExtAdv frm = new frmMJMacBJExtAdv(cap, btn.Text, source[index]);
      if (frm.ShowDialog() == DialogResult.OK) source[index] = frm.Source;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string port = "1234";
      byte[] doorid = new byte[4];
      string[] events = new string[4];
      short[] timeOut = new short[4];
      short[] timeLoop = new short[4];
      CheckedListBox clb;
      CheckedListBox clb1;
      TextBox txt1;
      TextBox txt2;
      string errMsg1 = string.Format(Pub.GetResText(formCode, "Error001", ""), 0, MaxTime);
      string errMsg2 = string.Format(Pub.GetResText(formCode, "Error002", ""), 0, MaxTime);
      for (int i = 0; i < 4; i++)
      {
        if (i == 0)
        {
          clb = clb11;
          clb1 = clb12;
          txt1 = txtTime1;
          txt2 = txtLoop1;
        }
        else if (i == 1)
        {
          clb = clb21;
          clb1 = clb22;
          txt1 = txtTime2;
          txt2 = txtLoop2;
        }
        else if (i == 2)
        {
          clb = clb31;
          clb1 = clb32;
          txt1 = txtTime3;
          txt2 = txtLoop3;
        }
        else
        {
          clb = clb41;
          clb1 = clb42;
          txt1 = txtTime4;
          txt2 = txtLoop4;
        }
        for (int j = 0; j < clb.Items.Count; j++)
        {
          if (clb.GetItemChecked(j)) doorid[i] = Convert.ToByte(((TCommonType)clb.Items[j]).id);
        }
        for (int j = 0; j < clb1.Items.Count; j++)
        {
          if (doorid[i] == 0)
            events[i] += "0";
          else
            events[i] += Convert.ToByte(clb1.GetItemChecked(j)).ToString();
        }
        if (!Pub.IsNumeric(txt1.Text.Trim()))
        {
          txt1.Focus();
          ShowErrorEnterCorrect(label3.Text);
          return;
        }
        if ((Convert.ToInt32(txt1.Text.Trim()) < 0) || (Convert.ToInt32(txt1.Text.Trim()) > MaxTime))
        {
          txt1.Focus();
          Pub.ShowErrorMsg(errMsg1);
          return;
        }
        timeOut[i] = Convert.ToInt16(txt1.Text.Trim());
        if (!Pub.IsNumeric(txt2.Text.Trim()))
        {
          txt2.Focus();
          ShowErrorEnterCorrect(label4.Text);
          return;
        }
        if ((Convert.ToInt32(txt2.Text.Trim()) < 0) || (Convert.ToInt32(txt2.Text.Trim()) > MaxTime))
        {
          txt2.Focus();
          Pub.ShowErrorMsg(errMsg2);
          return;
        }
        timeLoop[i] = Convert.ToInt16(txt2.Text.Trim());
      }
      string MacExtensionBoard = string.Format("{0}@{1}{2}{3}{4}@{5}{6}{7}{8}@{9}{10}{11}{12}@{13}{14}{15}{16}@{17}{18}{19}{20}",
        port, doorid[0], doorid[1], doorid[2], doorid[3], events[0], events[1], events[2], events[3], source[0],
        source[1], source[2], source[3], timeOut[0].ToString("0000"), timeOut[1].ToString("0000"),
        timeOut[2].ToString("0000"), timeOut[3].ToString("0000"), timeLoop[0].ToString("0000"), 
        timeLoop[1].ToString("0000"), timeLoop[2].ToString("0000"), timeLoop[3].ToString("0000"));
      string sql = "";
      try
      {
        sql = Pub.GetSQL(DBCode.DB_003001, new string[] { "112", MacExtensionBoard, SysID });
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
  }
}