using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmMJMacTimeOpenDoorEdit : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "MJMacTimeOpenDoorEdit";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadData();
    }

    public frmMJMacTimeOpenDoorEdit(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
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
          cbbMode3.Items.Add(ctype);
          cbbMode4.Items.Add(ctype);
        }
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003009, new string[] { "1", SysID }));
        if (dr.Read())
        {
          MaskedTextBox txt;
          ComboBox cbb;
          for (int i = 1; i <= 4; i++)
          {
            txt = (MaskedTextBox)this.Controls["txtBeginTime" + i.ToString()];
            txt.Text = dr["BeginTime" + i.ToString()].ToString();
            txt = (MaskedTextBox)this.Controls["txtEndTime" + i.ToString()];
            txt.Text = dr["EndTime" + i.ToString()].ToString();
            cbb = (ComboBox)this.Controls["cbbMode" + i.ToString()];
            SetModeIndex(cbb, dr["Mode" + i.ToString()].ToString());
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

    private void btnOk_Click(object sender, EventArgs e)
    {
      DateTime dt = new DateTime();
      MaskedTextBox txt;
      ComboBox cbb;
      string[] timeBegin = new string[4];
      string[] timeEnd = new string[4];
      string[] mode = new string[4];
      for (int i = 1; i <= 4; i++)
      {
        txt = (MaskedTextBox)this.Controls["txtBeginTime" + i.ToString()];
        if (!DateTime.TryParse(txt.Text, out dt))
        {
          txt.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error00" + i.ToString(), ""));
          return;
        }
        timeBegin[i - 1] = txt.Text;
        txt = (MaskedTextBox)this.Controls["txtEndTime" + i.ToString()];
        if (!DateTime.TryParse(txt.Text, out dt))
        {
          txt.Focus();
          Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error00" + i.ToString(), ""));
          return;
        }
        timeEnd[i - 1] = txt.Text;
        cbb = (ComboBox)this.Controls["cbbMode" + i.ToString()];
        if (cbb.SelectedIndex < 0) cbb.SelectedIndex = 0;
        mode[i - 1] = ((TCommonType)cbb.Items[cbb.SelectedIndex]).id;
      }
      string sql = Pub.GetSQL(DBCode.DB_003009, new string[] { "101", timeBegin[0], timeEnd[0], mode[0], timeBegin[1], 
        timeEnd[1], mode[1], timeBegin[2], timeEnd[2], mode[2], timeBegin[3], timeEnd[3], mode[3], SysID });
      try
      {
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

    private void SetModeIndex(ComboBox cbb, string mode)
    {
      for (int i = 0; i < cbb.Items.Count; i++)
      {
        if (((TCommonType)cbb.Items[i]).id == mode)
        {
          cbb.SelectedIndex = i;
          break;
        }
      }
    }
  }
}