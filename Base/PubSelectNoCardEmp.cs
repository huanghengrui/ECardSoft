using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmPubSelectNoCardEmp : frmBaseDialog
  {
    private string title = "";
    private string otherCoin = "";
    public DataTable dtData = new DataTable();

    protected override void InitForm()
    {
      formCode = "PubSelectEmpList";
      if (IsAllowanceDownSelect)
      {
        AddColumn(cardGrid, 0, "CardSectorNo", false, true, 1, 80);
        AddColumn(cardGrid, 0, "EmpNo", false, true, 1, 80);
        AddColumn(cardGrid, 0, "EmpName", false, true, 1, 80);
        AddColumn(cardGrid, 0, "AllowanceFlag", false, true, 1, 80);
        AddColumn(cardGrid, 0, "AllowanceWayName", false, true, 1, 80);
        AddColumn(cardGrid, 0, "AllowanceAmountUp", false, true, 1, 100);
        AddColumn(cardGrid, 0, "AllowanceAmount", false, true, 1, 100);
        AddColumn(cardGrid, 0, "AllowanceAmountSum", false, true, 1, 100);
      }
      else
      {
        CreateCardGridView(cardGrid);
      }
      IsToggleCheckStateAll = true;
      base.InitForm();
      this.Text = title;
      dtpDate.Value = DateTime.Now.Date;
      //InitDimissionTreeView(tvDepart,false, false, "");
      //InitDimissionTreeView(tvEmp, true, true, otherCoin);
      GetCardTypeList();
      for (int i = 0; i < cardTypeList.Count; i++)
      {
        clbCardType.Items.Add(cardTypeList[i]);
      }
      dtData.Clear();
      dtData.Reset();
      if (tvEmp.StateImageList == null)
      {
        tvEmp.AfterCheck += tvEmp_AfterCheck;
        tvEmp.CheckBoxes = true;
      }
    }

    public frmPubSelectNoCardEmp(string Title, string OtherCoin)
    {
      title = Title;
      otherCoin = OtherCoin;
      InitializeComponent();
    }

    private bool FindSelectedEmp(string EmpSysID)
    {
      bool ret = false;
      for (int i = 0; i < dtData.Rows.Count; i++)
      {
        if (dtData.Rows[i]["EmpSysID"].ToString() == EmpSysID)
        {
          ret = true;
          break;
        }
      }
      return ret;
    }

    private void SelectDepart(TreeNode node)
    {
      string DepartSysID = node.Tag.ToString();
      DataTable dt = null;
      try
      {
        if (IsAllowanceDownSelect)
        {
          if (node.Checked)
          {
            if (dtData.Rows.Count == 0)
            {
              dtData = db.GetDataTable(Pub.GetSQL(DBCode.DB_004006, new string[] { "101", DepartSysID, otherCoin, 
                OprtInfo.DepartPower }));
            }
            else
            {
              dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_004006, new string[] { "101", DepartSysID, otherCoin, 
                OprtInfo.DepartPower }));
              for (int i = 0; i < dt.Rows.Count; i++)
              {
                if (!FindSelectedEmp(dt.Rows[i]["EmpSysID"].ToString())) dtData.Rows.Add(dt.Rows[i].ItemArray);
              }
            }
          }
          else
          {
            for (int i = dtData.Rows.Count - 1; i >= 0; i--)
            {
              if (dtData.Rows[i]["DepartSysID"].ToString() == DepartSysID)
              {
                dtData.Rows.RemoveAt(i);
              }
            }
          }
        }
        else
        {
          if (node.Checked)
          {
            if (dtData.Rows.Count == 0)
            {
              dtData = db.GetDataTable(Pub.GetSQL(DBCode.DB_001002, new string[] { "8", DepartSysID, otherCoin, 
                OprtInfo.DepartPower }));
            }
            else
            {
              dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_001002, new string[] { "8", DepartSysID, otherCoin, 
                OprtInfo.DepartPower }));
              for (int i = 0; i < dt.Rows.Count; i++)
              {
                if (!FindSelectedEmp(dt.Rows[i]["EmpSysID"].ToString())) dtData.Rows.Add(dt.Rows[i].ItemArray);
              }
            }
          }
          else
          {
            for (int i = dtData.Rows.Count - 1; i >= 0; i--)
            {
              if (dtData.Rows[i]["DepartSysID"].ToString() == DepartSysID)
              {
                dtData.Rows.RemoveAt(i);
              }
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
        if (dt != null)
        {
          dt.Clear();
          dt.Reset();
        }
      }
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        SelectDepart(node.Nodes[i]);
      }
      bindingSource.DataSource = dtData;
    }

    private void tvDepart_AfterCheck(object sender, TreeViewEventArgs e)
    {
      if (optSelectAll.Checked) SelectTreeNode(e.Node);
      SelectDepart(e.Node);
    }

    private void SelectEmp(TreeNode node)
    {
      string EmpSysID = node.Tag.ToString();
      if (EmpSysID.Length == 37)
      {
        EmpSysID = EmpSysID.Substring(1);
        DataTable dt = null;
        bool state = false;
        if (tvEmp.StateImageList == null)
          state = node.Checked;
        else
          state = node.StateImageIndex == 1;
        dtData.BeginInit();
        try
        {
          if (IsAllowanceDownSelect)
          {
            if (state)
            {
              if (dtData.Rows.Count == 0)
              {
                dtData = db.GetDataTable(Pub.GetSQL(DBCode.DB_004006, new string[] { "104", EmpSysID, otherCoin, 
                  OprtInfo.DepartPower }));
              }
              else
              {
                dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_004006, new string[] { "104", EmpSysID, otherCoin, 
                  OprtInfo.DepartPower }));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                  if (!FindSelectedEmp(dt.Rows[i]["EmpSysID"].ToString()))
                  {
                    dtData.Rows.Add(dt.Rows[i].ItemArray);
                    break;
                  }
                }
              }
            }
            else
            {
              for (int i = dtData.Rows.Count - 1; i >= 0; i--)
              {
                if (dtData.Rows[i]["EmpSysID"].ToString() == EmpSysID)
                {
                  dtData.Rows.RemoveAt(i);
                  break;
                }
              }
            }
          }
          else
          {
            if (state)
            {
              if (dtData.Rows.Count == 0)
              {
                dtData = db.GetDataTable(Pub.GetSQL(DBCode.DB_001003, new string[] { "1", EmpSysID, otherCoin, 
                  OprtInfo.DepartPower }));
              }
              else
              {
                dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_001003, new string[] { "1", EmpSysID, otherCoin, 
                  OprtInfo.DepartPower }));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                  if (!FindSelectedEmp(dt.Rows[i]["EmpSysID"].ToString()))
                  {
                    dtData.Rows.Add(dt.Rows[i].ItemArray);
                    break;
                  }
                }
              }
            }
            else
            {
              for (int i = dtData.Rows.Count - 1; i >= 0; i--)
              {
                if (dtData.Rows[i]["EmpSysID"].ToString() == EmpSysID)
                {
                  dtData.Rows.RemoveAt(i);
                  break;
                }
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
          if (dt != null)
          {
            dt.Clear();
            dt.Reset();
          }
        }
      }
      dtData.EndInit();
      for (int i = 0; i < node.Nodes.Count; i++)
      {
        SelectEmp(node.Nodes[i]);
      }
      bindingSource.DataSource = dtData;
    }

    protected override void ToggleCheckStateAll(TreeNode node)
    {
      base.ToggleCheckStateAll(node);
      SelectEmp(node);
    }

    private void tvEmp_AfterCheck(object sender, TreeViewEventArgs e)
    {
      SelectTreeNode(e.Node);
      SelectEmp(e.Node);
    }

    private void clbCardType_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      int CardTypeID = ((TCardType)clbCardType.Items[e.Index]).id;
      DataTable dt = null;
      try
      {
        if (IsAllowanceDownSelect)
        {
          if (e.NewValue == CheckState.Checked)
          {
            if (dtData.Rows.Count == 0)
            {
              dtData = db.GetDataTable(Pub.GetSQL(DBCode.DB_004006, new string[] { "102", CardTypeID.ToString(), otherCoin, 
                OprtInfo.DepartPower }));
            }
            else
            {
              dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_004006, new string[] { "102", CardTypeID.ToString(), otherCoin, 
                OprtInfo.DepartPower }));
              for (int i = 0; i < dt.Rows.Count; i++)
              {
                if (!FindSelectedEmp(dt.Rows[i]["EmpSysID"].ToString())) dtData.Rows.Add(dt.Rows[i].ItemArray);
              }
            }
          }
          else
          {
            for (int i = dtData.Rows.Count - 1; i >= 0; i--)
            {
              if (dtData.Rows[i]["CardTypeID"].ToString() == CardTypeID.ToString())
              {
                dtData.Rows.RemoveAt(i);
              }
            }
          }
        }
        else
        {
          if (e.NewValue == CheckState.Checked)
          {
            if (dtData.Rows.Count == 0)
            {
              dtData = db.GetDataTable(Pub.GetSQL(DBCode.DB_001003, new string[] { "219", CardTypeID.ToString(), otherCoin, 
                OprtInfo.DepartPower }));
            }
            else
            {
              dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_001003, new string[] { "219", CardTypeID.ToString(), otherCoin, 
                OprtInfo.DepartPower }));
              for (int i = 0; i < dt.Rows.Count; i++)
              {
                if (!FindSelectedEmp(dt.Rows[i]["EmpSysID"].ToString())) dtData.Rows.Add(dt.Rows[i].ItemArray);
              }
            }
          }
          else
          {
            for (int i = dtData.Rows.Count - 1; i >= 0; i--)
            {
              if (dtData.Rows[i]["CardTypeID"].ToString() == CardTypeID.ToString())
              {
                dtData.Rows.RemoveAt(i);
              }
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
        if (dt != null)
        {
          dt.Clear();
          dt.Reset();
        }
      }
      bindingSource.DataSource = dtData;
    }

    private void btnAddEmp_Click(object sender, EventArgs e)
    {
      DateTime d = dtpDate.Value;
      DataTable dt = null;
      try
      {
        if (IsAllowanceDownSelect)
        {
          if (dtData.Rows.Count == 0)
          {
            dtData = db.GetDataTable(Pub.GetSQL(DBCode.DB_004006, new string[] { "103", 
              d.ToString(SystemInfo.SQLDateFMT), otherCoin, OprtInfo.DepartPower }));
          }
          else
          {
            dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_004006, new string[] { "103", d.ToString(SystemInfo.SQLDateFMT), 
              otherCoin, OprtInfo.DepartPower }));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              if (!FindSelectedEmp(dt.Rows[i]["EmpSysID"].ToString())) dtData.Rows.Add(dt.Rows[i].ItemArray);
            }
          }
        }
        else
        {
          if (dtData.Rows.Count == 0)
          {
            dtData = db.GetDataTable(Pub.GetSQL(DBCode.DB_001003, new string[] { "220", 
              d.ToString(SystemInfo.SQLDateFMT), otherCoin, OprtInfo.DepartPower }));
          }
          else
          {
            dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_001003, new string[] { "220", d.ToString(SystemInfo.SQLDateFMT), 
              otherCoin, OprtInfo.DepartPower }));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              if (!FindSelectedEmp(dt.Rows[i]["EmpSysID"].ToString())) dtData.Rows.Add(dt.Rows[i].ItemArray);
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
        if (dt != null)
        {
          dt.Clear();
          dt.Reset();
        }
      }
      bindingSource.DataSource = dtData;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (dtData.Rows.Count > 0)
      {
        DataRowView drv = (DataRowView)bindingSource.Current;
        dtData.Rows.Remove(drv.Row);
      }
      bindingSource.DataSource = dtData;
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      dtData.Clear();
      dtData.Reset();
      bindingSource.DataSource = dtData;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (dtData.Rows.Count == 0)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "ErrorSelectEmp", ""));
        return;
      }
      this.Close();
      this.DialogResult = DialogResult.OK;
    }
  }
}