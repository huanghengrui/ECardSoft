using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmKQShiftAssertDep : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "KQShiftAssertDep";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      LoadData();
    }

    public frmKQShiftAssertDep(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      TCommonType ctype = new TCommonType("", "", "", true);
      cbbShiftNo.Items.Clear();
      cbbShiftNo.Items.Add(ctype);
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002004, new string[] { "3" }));
        while (dr.Read())
        {
          ctype = new TCommonType(dr["GUID"].ToString(), dr["ShiftNo"].ToString(), dr["ShiftName"].ToString(), true);
          cbbShiftNo.Items.Add(ctype);
        }
        dr.Close();
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002007, new string[] { "10", SysID }));
        if (dr.Read())
        {
          txtDepartID.Text = dr["DepartID"].ToString();
          txtDepartName.Text = dr["DepartName"].ToString();
          DateTime dt = new DateTime();
          DateTime.TryParse(dr["DepShiftDate"].ToString(), out dt);
          txtDate.Text = dt.ToShortDateString();
          for (int i = 0; i < cbbShiftNo.Items.Count; i++)
          {
            if (((TCommonType)cbbShiftNo.Items[i]).id == dr["ShiftNo"].ToString())
            {
              cbbShiftNo.SelectedIndex = i;
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
      string sql = Pub.GetSQL(DBCode.DB_002007, new string[] { "11", 
        ((TCommonType)cbbShiftNo.Items[cbbShiftNo.SelectedIndex]).id, SysID });
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