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
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003009, new string[] { "1", SysID }));
        if (dr.Read())
        {
          MaskedTextBox txt;
          for (int i = 1; i <= 3; i++)
          {
            txt = (MaskedTextBox)this.Controls["txtBeginTime" + i.ToString()];
            txt.Text = dr["BeginTime" + i.ToString()].ToString();
            txt = (MaskedTextBox)this.Controls["txtEndTime" + i.ToString()];
            txt.Text = dr["EndTime" + i.ToString()].ToString();
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
      string[] timeBegin = new string[3];
      string[] timeEnd = new string[3];
      for (int i = 1; i <= 3; i++)
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
      }
      string sql = Pub.GetSQL(DBCode.DB_003009, new string[] { "2", timeBegin[0], timeEnd[0], timeBegin[1], 
        timeEnd[1], timeBegin[2], timeEnd[2], SysID });
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
  }
}