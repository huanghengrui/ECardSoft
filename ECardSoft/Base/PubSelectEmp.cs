using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmPubSelectEmp : frmBaseDialog
  {
    private TreeNode findNode = null;
    private string otherCoin = "";
    public string EmpSysID = "";
    public string EmpNo = "";
    public string EmpName = "";
    public string CardSectorNo = "";
    public string CardPhysicsNo10 = "";
    public string CardPhysicsNo8 = "";

    protected override void InitForm()
    {
      formCode = "PubSelectEmp";
      base.InitForm();
      EmpSysID = "";
      EmpNo = "";
      EmpName = "";
      CardSectorNo = "";
      CardPhysicsNo10 = "";
      CardPhysicsNo8 = "";
      InitDepartTreeView(tvEmp, true, true, otherCoin);
      lblQuickSearchToolTip.ForeColor = Color.Blue;
    }

    public frmPubSelectEmp()
    {
      InitializeComponent();
    }

    public frmPubSelectEmp(string OtherCoin)
    {
      otherCoin = OtherCoin;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (tvEmp.SelectedNode == null)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
        return;
      }
      EmpSysID = tvEmp.SelectedNode.Tag.ToString();
      if (EmpSysID.Length != 37)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
        return;
      }
      EmpSysID = EmpSysID.Substring(1);
      string DepartSysID = tvEmp.SelectedNode.Parent.Tag.ToString();
      if (!db.CheckDepartPowerByDeptSysID(DepartSysID)) return;
      if (!db.GetEmpInfoCard(EmpSysID, ref EmpNo, ref EmpName, ref CardSectorNo, ref CardPhysicsNo10, ref CardPhysicsNo8)) return;
      if (EmpName.Trim() == "") EmpName = EmpNo;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void tvEmp_DoubleClick(object sender, EventArgs e)
    {
      btnOk.PerformClick();
    }

    private bool FindNode(string findText, TreeNode nod)
    {
      bool ret = false;
      for (int i = 0; i < nod.Nodes.Count; i++)
      {
        if (nod.Nodes[i].Tag.ToString().Length != 37)
        {
          ret = FindNode(findText, nod.Nodes[i]);
          if (ret) break;
          continue;
        }
        if (nod.Nodes[i].Text.IndexOf(findText) != -1)
        {
          if (findNode != null && findNode.Index >= nod.Nodes[i].Index) continue;
          findNode = nod.Nodes[i];
          ret = true;
          break;
        }
      }
      return ret;
    }

    private void txtFind_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Enter) return;
      string s = txtFind.Text;
      if (s == "") return;
      bool isFind = false;
      for (int i = 0; i < tvEmp.Nodes.Count; i++)
      {
        if (tvEmp.Nodes[i].Tag.ToString().Length != 37)
        {
          isFind = FindNode(s, tvEmp.Nodes[i]);
          if (isFind) break;
          continue;
        }
        if (tvEmp.Nodes[i].Text.IndexOf(s) != -1)
        {
          if (findNode != null && findNode.Index >= tvEmp.Nodes[i].Index) continue;
          findNode = tvEmp.Nodes[i];
          isFind = true;
          break;
        }
      }
      if (!isFind) findNode = null;
      if (findNode != null) tvEmp.SelectedNode = findNode;
    }
  }
}