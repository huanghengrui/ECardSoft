using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using grproLib;

namespace ECard78
{
  public partial class frmPubFind : frmBaseDialog
  {
    private string title = "";
    public string QuerySQL = "";
    public string OrderBy = "";
    private string KeyWord = "";
    private bool _ShowTime = false;
    private List<string> _FieldText = new List<string>();
    private List<string> _FieldName = new List<string>();
    private List<GRFieldType> _FieldType = new List<GRFieldType>();
    private string fileFind = "";
    private string fileOrder = "";

    protected override void InitForm()
    {
      formCode = "PubFind";
      base.InitForm();
      this.Text = title;
      Column2.Items.Clear();
      Column9.Items.Clear();
      for (int i = 0; i < _FieldText.Count; i++)
      {
        Column2.Items.Add(_FieldText[i]);
        Column9.Items.Add(_FieldText[i]);
      }
      Column3.Items.Clear();
      for (int i = 0; i <= 7; i++)
      {
        Column3.Items.Add(Pub.GetResText(formCode, "Mark" + i.ToString(), ""));
      }
      Column5.Items.Clear();
      Column5.Items.Add(Pub.GetResText(formCode, "AND", ""));
      Column5.Items.Add(Pub.GetResText(formCode, "OR", ""));
      Column10.Items.Clear();
      Column10.Items.Add(Pub.GetResText(formCode, "ASC", ""));
      Column10.Items.Add(Pub.GetResText(formCode, "DESC", ""));
      fileFind = SystemInfo.AppPath + "Cookie\\" + KeyWord + ".fnd";
      StreamReader sr = null;
      string line = "";
      string[] tmp;
      if (File.Exists(fileFind))
      {
        sr = new StreamReader(fileFind);
        while (!sr.EndOfStream)
        {
          line = sr.ReadLine();
          tmp = line.Split('\t');
          if (tmp.Length != 8) continue;
          dataGrid.Rows.Add();
          dataGrid[0, dataGrid.RowCount - 1].Value = tmp[0];
          dataGrid[1, dataGrid.RowCount - 1].Value = tmp[1];
          dataGrid[2, dataGrid.RowCount - 1].Value = tmp[2];
          dataGrid[3, dataGrid.RowCount - 1].Value = tmp[3];
          dataGrid[4, dataGrid.RowCount - 1].Value = tmp[4];
          dataGrid[5, dataGrid.RowCount - 1].Value = "...";
          dataGrid[6, dataGrid.RowCount - 1].Value = tmp[5];
          dataGrid[7, dataGrid.RowCount - 1].Value = tmp[6];
          dataGrid[8, dataGrid.RowCount - 1].Value = tmp[7];
        }
        sr.Close();
      }
      fileOrder = SystemInfo.AppPath + "Cookie\\" + KeyWord + ".ord";
      if (File.Exists(fileOrder))
      {
        sr = new StreamReader(fileOrder);
        while (!sr.EndOfStream)
        {
          line = sr.ReadLine();
          tmp = line.Split('\t');
          if (tmp.Length != 4) continue;
          orderGrid.Rows.Add();
          orderGrid[0, orderGrid.RowCount - 1].Value = tmp[0];
          orderGrid[1, orderGrid.RowCount - 1].Value = tmp[1];
          orderGrid[2, orderGrid.RowCount - 1].Value = tmp[2];
          orderGrid[3, orderGrid.RowCount - 1].Value = tmp[3];
        }
        sr.Close();
      }
      for (int j = 0; j < dataGrid.ColumnCount; j++)
      {
        dataGrid.Columns[j].ReadOnly = false;
      }
      for (int j = 0; j < orderGrid.ColumnCount; j++)
      {
        orderGrid.Columns[j].ReadOnly = false;
      }
    }

    public frmPubFind(string Title, string FindSQL, string FindOrderBy, string FindKeyWord, List<string> FieldText,
      List<string> FieldName, List<GRFieldType> FieldType, bool ShowTime)
    {
      title = Title;
      QuerySQL = FindSQL;
      OrderBy = FindOrderBy;
      KeyWord = FindKeyWord;
      _FieldText = FieldText;
      _FieldName = FieldName;
      _FieldType = FieldType;
      _ShowTime = ShowTime;
      InitializeComponent();
    }

    private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      frmPubSelectDepart frmDepart;
      frmPubSelectEmp frmEmp;
      frmPubSelectIDName frmID;
      if ((e.RowIndex < 0) || (e.ColumnIndex != 5)) return;
      string title = dataGrid[2, e.RowIndex].Value.ToString();
      switch (dataGrid[7, e.RowIndex].Value.ToString().ToLower())
      {
        case "empno":
          frmEmp = new frmPubSelectEmp();
          if (frmEmp.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmEmp.EmpNo;
            dataGrid[8, e.RowIndex].Value = frmEmp.EmpNo;
          }
          break;
        case "empname":
          frmEmp = new frmPubSelectEmp();
          if (frmEmp.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmEmp.EmpName;
            dataGrid[8, e.RowIndex].Value = frmEmp.EmpNo;
          }
          break;
        case "departid":
          frmDepart = new frmPubSelectDepart();
          if (frmDepart.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmDepart.DepartID;
            dataGrid[8, e.RowIndex].Value = frmDepart.DepartID;
          }
          break;
        case "departname":
          frmDepart = new frmPubSelectDepart();
          if (frmDepart.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmDepart.DepartName;
            dataGrid[8, e.RowIndex].Value = frmDepart.DepartID;
          }
          break;
        case "cardsectorno":
        case "cardno":
          frmEmp = new frmPubSelectEmp();
          if (frmEmp.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmEmp.CardSectorNo;
            dataGrid[8, e.RowIndex].Value = frmEmp.CardSectorNo;
          }
          break;
        case "cardphysicsno10":
          frmEmp = new frmPubSelectEmp();
          if (frmEmp.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmEmp.CardPhysicsNo10;
            dataGrid[8, e.RowIndex].Value = frmEmp.CardPhysicsNo10;
          }
          break;
        case "cardphysicsno8":
          frmEmp = new frmPubSelectEmp();
          if (frmEmp.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmEmp.CardPhysicsNo8;
            dataGrid[8, e.RowIndex].Value = frmEmp.CardPhysicsNo8;
          }
          break;
        case "sftypeid":
          frmID = new frmPubSelectIDName(Column13.HeaderText + "[" + dataGrid[1, e.RowIndex].Value.ToString() + "]",
             Pub.GetSQL(DBCode.DB_000001, new string[] { "501" }), "SFTypeID", "SFTypeName");
          if (frmID.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmID.SelectID;
            dataGrid[8, e.RowIndex].Value = frmID.SelectID;
          }
          break;
        case "sftypename":
          frmID = new frmPubSelectIDName(Column13.HeaderText + "[" + dataGrid[1, e.RowIndex].Value.ToString() + "]",
             Pub.GetSQL(DBCode.DB_000001, new string[] { "501" }), "SFTypeID", "SFTypeName");
          if (frmID.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmID.SelectName;
            dataGrid[8, e.RowIndex].Value = frmID.SelectName;
          }
          break;
        case "sfmealtypeid":
          frmID = new frmPubSelectIDName(Column13.HeaderText + "[" + dataGrid[1, e.RowIndex].Value.ToString() + "]",
             Pub.GetSQL(DBCode.DB_000001, new string[] { "502" }), "SFMealTypeID", "SFMealTypeName");
          if (frmID.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmID.SelectID;
            dataGrid[8, e.RowIndex].Value = frmID.SelectID;
          }
          break;
        case "sfmealtypename":
          frmID = new frmPubSelectIDName(Column13.HeaderText + "[" + dataGrid[1, e.RowIndex].Value.ToString() + "]",
             Pub.GetSQL(DBCode.DB_000001, new string[] { "502" }), "SFMealTypeID", "SFMealTypeName");
          if (frmID.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmID.SelectName;
            dataGrid[8, e.RowIndex].Value = frmID.SelectName;
          }
          break;
        case "cardstatusid":
          frmID = new frmPubSelectIDName(Column13.HeaderText + "[" + dataGrid[1, e.RowIndex].Value.ToString() + "]",
             Pub.GetSQL(DBCode.DB_000001, new string[] { "503" }), "CardStatusID", "CardStatusName");
          if (frmID.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmID.SelectID;
            dataGrid[8, e.RowIndex].Value = frmID.SelectID;
          }
          break;
        case "cardstatusname":
          frmID = new frmPubSelectIDName(Column13.HeaderText + "[" + dataGrid[1, e.RowIndex].Value.ToString() + "]",
             Pub.GetSQL(DBCode.DB_000001, new string[] { "503" }), "CardStatusID", "CardStatusName");
          if (frmID.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmID.SelectName;
            dataGrid[8, e.RowIndex].Value = frmID.SelectName;
          }
          break;
        case "syopterid":
          frmID = new frmPubSelectIDName(Column13.HeaderText + "[" + dataGrid[1, e.RowIndex].Value.ToString() + "]",
             Pub.GetSQL(DBCode.DB_000001, new string[] { "504" }), "SYOpterID", "SYOpterName");
          if (frmID.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmID.SelectID;
            dataGrid[8, e.RowIndex].Value = frmID.SelectID;
          }
          break;
        case "syoptername":
          frmID = new frmPubSelectIDName(Column13.HeaderText + "[" + dataGrid[1, e.RowIndex].Value.ToString() + "]",
             Pub.GetSQL(DBCode.DB_000001, new string[] { "504" }), "SYOpterID", "SYOpterName");
          if (frmID.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmID.SelectName;
            dataGrid[8, e.RowIndex].Value = frmID.SelectName;
          }
          break;
        case "cardtypeid":
          frmID = new frmPubSelectIDName(Column13.HeaderText + "[" + dataGrid[1, e.RowIndex].Value.ToString() + "]",
             Pub.GetSQL(DBCode.DB_000001, new string[] { "203" }), "CardTypeID", "CardTypeName");
          if (frmID.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmID.SelectID;
            dataGrid[8, e.RowIndex].Value = frmID.SelectID;
          }
          break;
        case "cardtypename":
          frmID = new frmPubSelectIDName(Column13.HeaderText + "[" + dataGrid[1, e.RowIndex].Value.ToString() + "]",
             Pub.GetSQL(DBCode.DB_000001, new string[] { "203" }), "CardTypeID", "CardTypeName");
          if (frmID.ShowDialog() == DialogResult.OK)
          {
            dataGrid[4, e.RowIndex].Value = frmID.SelectName;
            dataGrid[8, e.RowIndex].Value = frmID.SelectName;
          }
          break;
      }
      string v = "";
      v = dataGrid[2, e.RowIndex].Value.ToString();
      int index = _FieldText.IndexOf(v);
      if (index < 0) return;
      DateTime d = new DateTime();
      switch (_FieldType[index])
      {
        case GRFieldType.grftDateTime:
          DateTime.TryParse(dataGrid[3, e.RowIndex].Value.ToString(), out d);
          if (Pub.GetSelectDate(_ShowTime, ref d))
          {
            if (_ShowTime)
              dataGrid[4, e.RowIndex].Value = d.ToString(SystemInfo.SQLDateTimeFMT);
            else
              dataGrid[4, e.RowIndex].Value = d.ToString(SystemInfo.SQLDateFMT);
            dataGrid[8, e.RowIndex].Value = dataGrid[4, e.RowIndex].Value;
          }
          break;
      }
    }

    private void dataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex < 0) return;
      string v = "";
      int index = 0;
      if (e.ColumnIndex == 2)
      {
        v = dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
        index = _FieldText.IndexOf(v);
        if (index >= 0) dataGrid[7, e.RowIndex].Value = _FieldName[index];
      }
    }

    private void dataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      e.Cancel = true;
    }

    private void orderGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex < 0) return;
      string v = "";
      int index = 0;
      if (e.ColumnIndex == 0)
      {
        v = orderGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
        index = _FieldText.IndexOf(v);
        if (index >= 0) orderGrid[2, e.RowIndex].Value = _FieldName[index];
      }
    }

    private void orderGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      e.Cancel = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      dataGrid.Rows.Add();
      int i = dataGrid.RowCount - 1;
      dataGrid[0, i].Value = Column5.Items[0];
      dataGrid[1, i].Value = "";
      if (i < _FieldText.Count)
      {
        dataGrid[2, i].Value = _FieldText[i];
        dataGrid[7, i].Value = _FieldName[i];
      }
      dataGrid[3, i].Value = Column3.Items[0];
      dataGrid[4, i].Value = "";
      dataGrid[5, i].Value = "...";
      dataGrid[6, i].Value = "";
      dataGrid[8, i].Value = "";
      dataGrid.Rows[i].Selected = true;
      dataGrid.CurrentCell = dataGrid.Rows[i].Cells[3];
      for (int j = 0; j < dataGrid.ColumnCount; j++)
      {
        dataGrid.Columns[j].ReadOnly = false;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (dataGrid.CurrentRow != null) dataGrid.Rows.Remove(dataGrid.CurrentRow);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      orderGrid.Rows.Add();
      int i = orderGrid.RowCount - 1;
      if (i < _FieldText.Count)
      {
        orderGrid[0, i].Value = _FieldText[i];
        orderGrid[2, i].Value = _FieldName[i];
      }
      orderGrid[1, i].Value = Column10.Items[0];
      orderGrid.Rows[i].Selected = true;
      orderGrid.CurrentCell = orderGrid.Rows[i].Cells[0];
      for (int j = 0; j < orderGrid.ColumnCount; j++)
      {
        orderGrid.Columns[j].ReadOnly = false;
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      if (orderGrid.CurrentRow != null) orderGrid.Rows.Remove(orderGrid.CurrentRow);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (dataGrid.RowCount == 0)
      {
        if (Pub.MessageBoxShowQuestion(Pub.GetResText(formCode, "Msg001", ""))) return;
      }
      string sql = QuerySQL;
      string fd = "";
      string fv = "";
      string v = "";
      string DepartList = "";
      int index = 0;
      int idx = 0;
      string fc = "";
      string andOr = "";
      string lBrk = "";
      string rBrk = "";
      string cBrk = "";
      GRFieldType fdT;
      if (File.Exists(fileFind)) File.Delete(fileFind);
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        andOr = " AND ";
        if (Column5.Items.IndexOf(dataGrid[0, i].Value.ToString()) == 1) andOr = " OR ";
        lBrk = dataGrid[1, i].Value.ToString();
        v = dataGrid[2, i].Value.ToString();
        idx = Column3.Items.IndexOf(dataGrid[3, i].Value.ToString());
        cBrk = Pub.GetSQL(DBCode.DB_000001, new string[] { "402", idx.ToString() });
        fv = dataGrid[4, i].Value.ToString();
        rBrk = dataGrid[6, i].Value.ToString();
        fd = dataGrid[7, i].Value.ToString();
        index = _FieldText.IndexOf(v);
        if ((index < 0) || (idx < 0)) continue;
        fc = "";
        for (int j = 0; j < dataGrid.ColumnCount; j++)
        {
          if (j == 5) continue;
          if (dataGrid[j, i].Value != null)
            fc = fc + dataGrid[j, i].Value.ToString() + "\t";
          else
            fc = fc + "" + "\t";
        }
        fc = fc.Substring(0, fc.Length - 1);
        Pub.WriteTextFile(fileFind, fc);
        fdT = _FieldType[index];
        switch (fdT)
        {
          case GRFieldType.grftInteger:
          case GRFieldType.grftFloat:
          case GRFieldType.grftCurrency:
          case GRFieldType.grftBoolean:
            break;
          default:
            fv = Pub.GetSQL(DBCode.DB_000001, new string[] { "401", idx.ToString(), fv });
            break;
        }
        if ((fdT == GRFieldType.grftDateTime) && !_ShowTime)
        {
          fd = Pub.GetSQL(DBCode.DB_000001, new string[] { "407", fd });
        }
        switch (fd.ToLower())
        {
          case "departid":
            fv = dataGrid[4, i].Value.ToString();
            DepartList = "";
            if (fv != "") DepartList = db.GetDepartChildID(fv);
            if (DepartList == "") DepartList = "''";
            fv = Pub.GetSQL(DBCode.DB_000001, new string[] { "401", idx.ToString(), fv });
            sql = sql + andOr + Pub.GetSQL(DBCode.DB_000001, new string[] { "403", fd, cBrk, fv, DepartList });
            break;
          case "cardsectorno":
          case "cardno":
          case "cardphysicsno10":
            if ((fv != "") && (Pub.IsNumeric(fv)))
            {
              fv = Convert.ToUInt32(fv).ToString("0000000000");
              fv = Pub.GetSQL(DBCode.DB_000001, new string[] { "401", idx.ToString(), fv });
            }
            sql = sql + andOr + Pub.GetSQL(DBCode.DB_000001, new string[] { "404", fd, cBrk, fv, lBrk, rBrk });
            break;
          case "cardphysicsno8":
            if ((fv != "") && (Pub.IsNumeric(fv)))
            {
              fv = Convert.ToUInt32(fv).ToString("00000000");
              fv = Pub.GetSQL(DBCode.DB_000001, new string[] { "401", idx.ToString(), fv });
            }
            sql = sql + andOr + Pub.GetSQL(DBCode.DB_000001, new string[] { "404", fd, cBrk, fv, lBrk, rBrk });
            break;
          default:
            sql = sql + andOr + Pub.GetSQL(DBCode.DB_000001, new string[] { "404", fd, cBrk, fv, lBrk, rBrk });
            break;
        }
      }
      string ord = "";
      if (File.Exists(fileOrder)) File.Delete(fileOrder);
      for (int i = 0; i < orderGrid.RowCount; i++)
      {
        fc = "";
        for (int j = 0; j < orderGrid.ColumnCount; j++)
        {
          if (orderGrid[j, i].Value != null)
            fc = fc + orderGrid[j, i].Value.ToString() + "\t";
          else
            fc = fc + "" + "\t";
        }
        fc = fc.Substring(0, fc.Length - 1);
        Pub.WriteTextFile(fileOrder, fc);
        idx = Column10.Items.IndexOf(orderGrid[1, i].Value.ToString());
        if (idx < 0) idx = 0;
        ord = ord + Pub.GetSQL(DBCode.DB_000001, new string[] { "405", idx.ToString(), orderGrid[2, i].Value.ToString() });
      }
      if (ord != "") ord = Pub.GetSQL(DBCode.DB_000001, new string[] { "406", ord });
      if (ord == "") ord = OrderBy;
      QuerySQL = sql + ord;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}