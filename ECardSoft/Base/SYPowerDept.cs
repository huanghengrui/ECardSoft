using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYPowerDept : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SYPowerDept";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      InitDepartTreeView(tvDepart);
      LoadData();
    }

    public frmSYPowerDept(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadDataSub(TreeNode node)
    {
      DataTableReader dr = null;
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000003, new string[] { "106", SysID, node.Nodes[i].Tag.ToString() }));
        if (dr.Read())
        {
          node.Nodes[i].Checked = true;
        }
        LoadDataSub(node.Nodes[i]);
      }
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        for (int i = 0; i < tvDepart.Nodes.Count; i++)
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000003, new string[] { "106", SysID, tvDepart.Nodes[i].Tag.ToString() }));
          if (dr.Read())
          {
            tvDepart.Nodes[i].Checked = true;
          }
          dr.Close();
          LoadDataSub(tvDepart.Nodes[i]);
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

    private void tvDepart_AfterCheck(object sender, TreeViewEventArgs e)
    {
      if (optSelectAll.Checked) SelectTreeNode(e.Node);
    }

    private void AddDepartSql(TreeNode node, ref List<string> sql)
    {
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        if (node.Nodes[i].Checked)
        {
          sql.Add(Pub.GetSQL(DBCode.DB_000003, new string[] { "105", SysID, node.Nodes[i].Tag.ToString() }));
        }
        AddDepartSql(node.Nodes[i], ref sql);
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      List<string> sql = new List<string>();
      sql.Add(Pub.GetSQL(DBCode.DB_000003, new string[] { "104", SysID }));
      for (int i = 0; i < tvDepart.Nodes.Count; i++)
      {
        if (tvDepart.Nodes[i].Checked)
        {
          sql.Add(Pub.GetSQL(DBCode.DB_000003, new string[] { "105", SysID, tvDepart.Nodes[i].Tag.ToString() }));
        }
        AddDepartSql(tvDepart.Nodes[i], ref sql);
      }
      if (db.ExecSQL(sql) != 0) return;
      db.WriteSYLog(this.Text, CurrentOprt, sql);
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}