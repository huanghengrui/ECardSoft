using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYAutoAdd : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SYAutoAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      TCommonType ctype;
      cbbType.Items.Clear();
      for (int i = 1; i <= 4; i++)
      {
        ctype = new TCommonType(i.ToString(), i.ToString(), Pub.GetResText(formCode, "AutoType" + i.ToString(), ""), true);
        cbbType.Items.Add(ctype);
      }
      cbbType.SelectedIndex = 0;
      if (SysID != "") LoadData();
    }

    public frmSYAutoAdd(string title, string CurrentTool, string GUID)
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
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000005, new string[] { "4", SysID }));
        if (dr.Read())
        {
          DateTime dt = new DateTime();
          DateTime.TryParse(dr["AutoTime"].ToString(), out dt);
          dtpTime.Value = dt;
          for (int i = 0; i < cbbType.Items.Count; i++)
          {
            if (((TCommonType)cbbType.Items[i]).id == dr["AutoType"].ToString())
            {
              cbbType.SelectedIndex = i;
              break;
            }
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
      string AutoTime = dtpTime.Value.ToString("HH:mm");
      string AutoType = ((TCommonType)cbbType.Items[cbbType.SelectedIndex]).id;
      string AutoName = ((TCommonType)cbbType.Items[cbbType.SelectedIndex]).name;
      string sql = "";
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SysID == "")
        {
          sql = Pub.GetSQL(DBCode.DB_000005, new string[] { "1", AutoTime, AutoType, AutoName });
          db.ExecSQL(sql);
        }
        else
        {
          sql = Pub.GetSQL(DBCode.DB_000005, new string[] { "2", AutoTime, AutoType, AutoName, SysID });
          db.ExecSQL(sql);
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
      }
      db.WriteSYLog(this.Text, CurrentOprt, sql);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}