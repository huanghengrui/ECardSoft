using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYAuto : frmBaseMDIChildGrid
  {
    private bool isRealing = false;
    private KQTextFormatInfo textFormat = new KQTextFormatInfo("");
    private string MsgString = "";
    private DateTime CurrentDate = new DateTime();

    protected override void InitForm()
    {
      formCode = "SYAuto";
      AddColumn(1, "SelectCheck", false, false, 1, 60);
      AddColumn(0, "GUID", true, false, 0);
      AddColumn(0, "No", true, true, 80);
      AddColumn(0, "AutoTime", false, false, 1, 100);
      AddColumn(0, "AutoType", true, false, 0);
      AddColumn(0, "AutoName", false, false, 0, 300);
      AddColumn(1, "IsExec", true, false, 0);
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemTAG2", true);
      SetToolItemState("ItemLine3", true);
      IsToggleCheckStateAll = true;
      base.InitForm();
      ExecItemRefresh();
      DataTable dt = null;
      TreeNode node;
      TreeNode nod;
      QHKS.TConnInfo connInfo;
      QHKS.TMJConnInfo mjConn;
      TConnInfoNewMJ mjNewConn;
      TConnInfoFinger connFinger;
      string s = "";
      tvMac.Nodes.Clear();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (SystemInfo.HasKQ && ((SystemInfo.KQFlag == 0) || (SystemInfo.KQFlag == 2)))
        {
          dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_002001, new string[] { "0" }));
          if (dt.Rows.Count > 0)
          {
            node = tvMac.Nodes.Add(Pub.GetResText(formCode, "mnuKQMac", ""));
            node.Tag = 0;
            if (tvMac.StateImageList != null) node.StateImageIndex = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              s = dt.Rows[i]["MacConnType"].ToString();
              if (s == MacConnTypeString.Comm)
                s = s + "  " + dt.Rows[i]["MacPort"].ToString() + "/" + dt.Rows[i]["MacConnPWD"].ToString();
              else if (s == MacConnTypeString.LAN)
                s = s + "  " + dt.Rows[i]["MacIpAddress"].ToString() + "/" + dt.Rows[i]["MacPort"].ToString();
              else if (s == MacConnTypeString.GPRS)
                s = s + "  " + dt.Rows[i]["MacIpAddress"].ToString() + "/" + dt.Rows[i]["MacPort"].ToString() + "/" +
                  dt.Rows[i]["MacPhysicsAddress"].ToString();
              connInfo = Pub.ValueToConnInfo(Convert.ToByte(dt.Rows[i]["IsBigMac"]),
                Convert.ToInt32(dt.Rows[i]["MacSN"]), 1, dt.Rows[i]["MacConnType"].ToString(),
                dt.Rows[i]["MacIpAddress"].ToString(), dt.Rows[i]["MacPort"].ToString(),
                dt.Rows[i]["MacConnPWD"].ToString(), dt.Rows[i]["MacPhysicsAddress"].ToString());
              nod = node.Nodes.Add(dt.Rows[i]["MacSN"].ToString() + "  " + s);
              nod.Tag = connInfo;
              if (tvMac.StateImageList != null) nod.StateImageIndex = 0;
            }
            node.Expand();
          }
          dt.Clear();
          dt.Reset();
          dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_002001, new string[] { "2000" }));
          if (dt.Rows.Count > 0)
          {
            node = tvMac.Nodes.Add(Pub.GetResText(formCode, "mnuKQFace", ""));
            node.Tag = 3;
            if (tvMac.StateImageList != null) node.StateImageIndex = 0;
            int MacSN = 0;
            string MacSN_GRPS = "";
            bool IsGPRS = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              s = dt.Rows[i]["MacConnType"].ToString();
              if (s == MacConnTypeString.Comm)
                s = s + "  " + dt.Rows[i]["MacPort"].ToString() + "/" + dt.Rows[i]["MacConnPWD"].ToString();
              else if (s == MacConnTypeString.LAN)
                s = s + "  " + dt.Rows[i]["MacIpAddress"].ToString() + "/" + dt.Rows[i]["MacPort"].ToString();
              else if (s == MacConnTypeString.GPRS)
                s = s + "  " + dt.Rows[i]["MacIpAddress"].ToString() + "/" + dt.Rows[i]["MacPort"].ToString() + "/" +
                  dt.Rows[i]["MacPhysicsAddress"].ToString();
              MacSN = 0;
              MacSN_GRPS = "";
              IsGPRS = Pub.ValueToBool(dt.Rows[i]["IsGPRS"]);
              if (IsGPRS)
                MacSN_GRPS = dt.Rows[i]["MacSN"].ToString();
              else
              {
                MacSN = Convert.ToInt32(dt.Rows[i]["MacSN"]);
                MacSN_GRPS = MacSN.ToString();
              }
              connFinger = Pub.ValueToConnInfoFinger(MacSN, MacSN_GRPS, 
                dt.Rows[i]["MacConnType"].ToString(), dt.Rows[i]["MacIpAddress"].ToString(),
                dt.Rows[i]["MacPort"].ToString(), dt.Rows[i]["MacConnPWD"].ToString(), IsGPRS);
              nod = node.Nodes.Add(dt.Rows[i]["MacSN"].ToString() + "  " + s);
              nod.Tag = connFinger;
              if (tvMac.StateImageList != null) nod.StateImageIndex = 0;
            }
            node.Expand();
          }
          dt.Clear();
          dt.Reset();
        }
        if (SystemInfo.HasMJ)
        {
          dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_003001, new string[] { "0" }));
          if (dt.Rows.Count > 0)
          {
            node = tvMac.Nodes.Add(Pub.GetResText(formCode, "DeviceTypeMJ", ""));
            node.Tag = 1;
            if (tvMac.StateImageList != null) node.StateImageIndex = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              s = dt.Rows[i]["MacConnType"].ToString();
              if (s == MacConnTypeString.Comm)
                s = s + "  " + dt.Rows[i]["MacPort"].ToString() + "/" + dt.Rows[i]["MacConnPWD"].ToString();
              else if (s == MacConnTypeString.LAN)
                s = s + "  " + dt.Rows[i]["MacIpAddress"].ToString() + "/" + dt.Rows[i]["MacPort"].ToString();
              if (SystemInfo.IsNewMJ)
              {
                mjNewConn = Pub.ValueToNewMJConnInfo(dt.Rows[i]["MacSN"].ToString(), dt.Rows[i]["MacConnType"].ToString(),
                  dt.Rows[i]["MacIpAddress"].ToString(), dt.Rows[i]["MacPort"].ToString(),
                  dt.Rows[i]["MacConnPWD"].ToString());
                nod = node.Nodes.Add(dt.Rows[i]["MacSN"].ToString() + "  " + s);
                nod.Tag = mjNewConn;
              }
              else
              {
                mjConn = Pub.ValueToMJConnInfo(dt.Rows[i]["MacSN"].ToString(), dt.Rows[i]["MacConnType"].ToString(),
                  dt.Rows[i]["MacIpAddress"].ToString(), dt.Rows[i]["MacPort"].ToString(),
                  dt.Rows[i]["MacConnPWD"].ToString());
                nod = node.Nodes.Add(dt.Rows[i]["MacSN"].ToString() + "  " + s);
                nod.Tag = mjConn;
              }
              if (tvMac.StateImageList != null) nod.StateImageIndex = 0;
            }
            node.Expand();
          }
          dt.Clear();
          dt.Reset();
        }
        if (SystemInfo.HasSF)
        {
          dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_004004, new string[] { "0" }));
          if (dt.Rows.Count > 0)
          {
            node = tvMac.Nodes.Add(Pub.GetResText(formCode, "DeviceTypeSF", ""));
            node.Tag = 2;
            if (tvMac.StateImageList != null) node.StateImageIndex = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              s = dt.Rows[i]["MacConnType"].ToString();
              if (s == MacConnTypeString.Comm)
                s = s + "  " + dt.Rows[i]["MacPort"].ToString() + "/" + dt.Rows[i]["MacConnPWD"].ToString();
              else if (s == MacConnTypeString.LAN)
                s = s + "  " + dt.Rows[i]["MacIpAddress"].ToString() + "/" + dt.Rows[i]["MacPort"].ToString();
              else if (s == MacConnTypeString.GPRS)
                s = s + "  " + dt.Rows[i]["MacIpAddress"].ToString() + "/" + dt.Rows[i]["MacPort"].ToString() + "/" +
                  dt.Rows[i]["MacPhysicsAddress"].ToString();
              connInfo = Pub.ValueToConnInfo(Convert.ToByte(dt.Rows[i]["IsBigMac"]),
                Convert.ToInt32(dt.Rows[i]["MacSN"]), Convert.ToByte(Convert.ToInt16(dt.Rows[i]["MacTypeID"]) - 30),
                dt.Rows[i]["MacConnType"].ToString(), dt.Rows[i]["MacIpAddress"].ToString(),
                dt.Rows[i]["MacPort"].ToString(), dt.Rows[i]["MacConnPWD"].ToString(),
                dt.Rows[i]["MacPhysicsAddress"].ToString());
              nod = node.Nodes.Add(dt.Rows[i]["MacSN"].ToString() + "  " + dt.Rows[i]["MacType"] + "  " + s);
              nod.Tag = connInfo;
              if (tvMac.StateImageList != null) nod.StateImageIndex = 0;
            }
            node.Expand();
          }
          dt.Clear();
          dt.Reset();
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
      if (tvMac.StateImageList == null)
      {
        tvMac.AfterCheck += TreeViewAfterCheck;
        tvMac.CheckBoxes = true;
      }
      else
      {
        tvMac.KeyUp += TreeViewKeyUp;
        tvMac.NodeMouseClick += TreeViewNodeMouseClick;
      }
      LoadTextFormat();
    }

    private void LoadTextFormat()
    {
      DataTableReader dr = null;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "112", KQTextFormatInfo.KQ_ConfigID, 
          KQTextFormatInfo.KQ_TextFormat }));
        if (dr.Read()) textFormat = new KQTextFormatInfo(dr["Value"].ToString());
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

    public frmSYAuto()
    {
      InitializeComponent();
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmSYAutoAdd frm = new frmSYAutoAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmSYAutoAdd frm = new frmSYAutoAdd(this.Text, CurrentTool, GetSysID());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemTAG1()
    {
      int SelectCount = 0;
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue)) SelectCount++;
      }
      if (SelectCount == 0)
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorSelectAutoOprt", ""));
        return;
      }
      base.ExecItemTAG1();
      isRealing = true;
      RefreshForm(true);
      CurrentDate = DateTime.Now.Date;
      msgGrid.Rows.Clear();
      timer1.Enabled = true;
    }

    protected override void ExecItemTAG2()
    {
      base.ExecItemTAG2();
      isRealing = false;
    }

    protected override void ExecItemRefresh()
    {
      QuerySQL = Pub.GetSQL(DBCode.DB_000005, new string[] { "0" });
      base.ExecItemRefresh();
    }

    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(State);
      ItemAdd.Enabled = ItemAdd.Enabled && !isRealing;
      ItemEdit.Enabled = ItemEdit.Enabled && !isRealing;
      ItemDelete.Enabled = ItemDelete.Enabled && !isRealing;
      ItemTAG1.Enabled = ItemTAG1.Enabled && !isRealing;
      ItemTAG2.Enabled = ItemTAG2.Enabled && isRealing;
      ItemSelect.Enabled = ItemSelect.Enabled && !isRealing;
      ItemUnselect.Enabled = ItemSelect.Enabled && !isRealing;
      ItemRefresh.Enabled = ItemRefresh.Enabled && !isRealing;
      dataGrid.Enabled = dataGrid.Enabled && !isRealing;
      tvMac.Enabled = !isRealing;
      SetContextMenuState();
    }

    private string GetSysID()
    {
      DataRowView drv = (DataRowView)bindingSource.Current;
      return drv.Row["GUID"].ToString();
    }

    protected override void GetDelSql(int rowIndex, ref List<string> sql)
    {
      string ret = Pub.GetSQL(DBCode.DB_000005, new string[] { "3", dataGrid[1, rowIndex].Value.ToString() });
      sql.Add(ret);
    }

    protected override string GetDelMsg(int rowIndex)
    {
      string ret = base.GetDelMsg(rowIndex);
      ret = dataGrid.Columns[3].HeaderText + "=" + dataGrid[3, rowIndex].Value.ToString() + "," +
        dataGrid.Columns[5].HeaderText + "=" + dataGrid[5, rowIndex].Value.ToString();
      return ret;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      timer1.Enabled = false;
      string timeStr = DateTime.Now.ToString("HH:mm");
      string AutoTime = "";
      int AutoType = 0;
      string AutoName = "";
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        if (!isRealing) break;
        AutoTime = dataGrid[3, i].Value.ToString();
        if ((CurrentDate != DateTime.Now.Date) && Pub.ValueToBool(dataGrid[6, i].Value)) dataGrid[6, i].Value = false;
        if (Pub.ValueToBool(dataGrid[0, i].EditedFormattedValue) && (AutoTime == timeStr) && 
          !Pub.ValueToBool(dataGrid[6, i].Value))
        {
          dataGrid[6, i].Value = true;
          AutoType = Convert.ToInt32(dataGrid[4, i].Value.ToString());
          AutoName = dataGrid[5, i].Value.ToString();
          AutoName = AutoName.Split('-')[1];
          ExecDeviceCommand(AutoType, AutoName);
        }
        Application.DoEvents();
      }
      progBar.Style = ProgressBarStyle.Blocks;
      progBar.Value = 0;
      lblMsg.Text = "";
      CurrentDate = DateTime.Now.Date;
      if (isRealing)
        timer1.Enabled = true;
      else
        RefreshForm(true);
    }

    private void ExecDeviceCommand(int AutoType, string AutoName)
    {
      DateTime dt = new DateTime();
      if (!db.GetServerDate(ref dt)) return;
      DataTable dtBlack = null;
      DataTable dtPower = null;
      byte devType = 0;
      string devName = "";
      QHKS.TConnInfo connInfo;
      QHKS.TMJConnInfo mjConn;
      TConnInfoNewMJ mjNewConn;
      TConnInfoFinger connFinger;
      string msg = "";
      bool state = false;
      string MacVer = "";
      int RecordCount = 0;
      int RecordIndex = 0;
      string dataMsg = "";
      progBar.Style = ProgressBarStyle.Marquee;
      progBar.Value = 50;
      if ((AutoType == 2) || (AutoType == 4))
      {
        progBar.Style = ProgressBarStyle.Blocks;
        progBar.Value = 0;
      }
      if (AutoType == 3)
      {
        try
        {
          dtBlack = db.GetDataTable(Pub.GetSQL(DBCode.DB_001003, new string[] { "501" }));
        }
        catch (Exception E)
        {
          Pub.ShowErrorMsg(E);
          return;
        }
      }
      for (int i = 0; i < tvMac.Nodes.Count; i++)
      {
        Application.DoEvents();
        if (!isRealing) break;
        if (tvMac.StateImageList == null)
        {
          if (!tvMac.Nodes[i].Checked) continue;
        }
        else
        {
          if (tvMac.Nodes[i].StateImageIndex == 0) continue;
        }
        devType = Convert.ToByte(tvMac.Nodes[i].Tag);
        devName = tvMac.Nodes[i].Text;
        for (int j = 0; j < tvMac.Nodes[i].Nodes.Count; j++)
        {
          Application.DoEvents();
          if (!isRealing) break;
          if (tvMac.StateImageList == null)
          {
            if (!tvMac.Nodes[i].Nodes[j].Checked) continue;
          }
          else
          {
            if (tvMac.Nodes[i].Nodes[j].StateImageIndex != 1) continue;
          }
          switch (devType)
          {
            case 0:
              connInfo = (QHKS.TConnInfo)tvMac.Nodes[i].Nodes[j].Tag;
              switch (AutoType)
              {
                case 1://同步时间
                  msg = string.Format(Pub.GetResText(formCode, "MsgSyncTime", ""), devName, connInfo.MacSN);
                  break;
                case 2://回收数据
                  msg = string.Format(Pub.GetResText(formCode, "MsgGetData", ""), devName, connInfo.MacSN);
                  break;
                case 3://下载黑名单
                  msg = string.Format(Pub.GetResText(formCode, "MsgBlackKQ", ""), connInfo.MacSN);
                  break;
                case 4://下载权限
                  msg = string.Format(Pub.GetResText(formCode, "MsgDownPower", ""), devName, connInfo.MacSN);
                  break;
              }
              MsgString = msg;
              ShowMsg(msg);
              DeviceObject.objKS.Init(ref connInfo);
              state = DeviceObject.objKS.SysDeviceInfoGet(ref MacVer);
              if (state) DeviceObject.objKS.InitMacVer(MacVer);
              switch (AutoType)
              {
                case 1://同步时间
                  if (state) state = DeviceObject.objKS.PubTimeSet(dt);
                  UpdateMsg(state);
                  break;
                case 2://回收数据
                  DeviceObject.objKS.SysSetState(false);
                  KQReadData readData = new KQReadData(this.Text + "[" + AutoName + "]", true);
                  if (state)
                  {
                    state = readData.ReadData(db, textFormat, connInfo.MacSN, ref RecordCount, ref RecordIndex, 
                      false, ShowReadDataProcess);
                  }
                  DeviceObject.objKS.SysSetState(true);
                  UpdateMsg(state, string.Format("{0}/{1}", RecordIndex, RecordCount));
                  break;
                case 3://下载黑名单
                  if (state)
                  {
                    KQDownBlack kqBlack = new KQDownBlack(dtBlack, connInfo);
                    if (state) state = kqBlack.Down();
                  }
                  UpdateMsg(state);
                  break;
                case 4://下载权限
                  break;
              }
              break;
            case 1:
              if (SystemInfo.IsNewMJ)
              {
                mjNewConn = (TConnInfoNewMJ)tvMac.Nodes[i].Nodes[j].Tag;
                switch (AutoType)
                {
                  case 1://同步时间
                    msg = string.Format(Pub.GetResText(formCode, "MsgSyncTime", ""), devName, mjNewConn.MacSN);
                    break;
                  case 2://回收数据
                    msg = string.Format(Pub.GetResText(formCode, "MsgGetData", ""), devName, mjNewConn.MacSN);
                    break;
                  case 3://下载黑名单
                    msg = string.Format(Pub.GetResText(formCode, "MsgBlackMJ", ""), mjNewConn.MacSN);
                    break;
                  case 4://下载权限
                    msg = string.Format(Pub.GetResText(formCode, "MsgDownPower", ""), devName, mjNewConn.MacSN);
                    break;
                }
                MsgString = msg;
                ShowMsg(msg);
                DeviceObject.objMJNew.NewDevice(mjNewConn);
                switch (AutoType)
                {
                  case 1://同步时间
                    AccessV2API.TYPE_Setting setting = new AccessV2API.TYPE_Setting();
                    state = DeviceObject.objMJNew.ReadSetting(out setting);
                    if (state)
                    {
                      DeviceObject.objMJNew.DateTimeToMJDateTime(dt, ref setting.DateTime);
                      state = DeviceObject.objMJNew.SetSetting(setting);
                    }
                    UpdateMsg(state);
                    break;
                  case 2://回收数据
                    MJReadData readData = new MJReadData(this.Text + "[" + AutoName + "]");
                    state = readData.ReadDataNew(db, mjNewConn.MacSN.ToString(), ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    UpdateMsg(state, string.Format("{0}/{1}", RecordIndex, RecordCount));
                    break;
                  case 3://下载黑名单
                    MJDownBlack mjBlack = new MJDownBlack(dtBlack, mjNewConn);
                    state = mjBlack.DownNew();
                    UpdateMsg(state);
                    break;
                  case 4://下载权限
                    RecordIndex = 0;
                    RecordCount = 0;
                    try
                    {
                      dtPower = db.GetDataTable(Pub.GetSQL(DBCode.DB_003004, new string[] { "0", "" }));
                      state = DeviceObject.objMJNew.ClearRegister();
                      if (state)
                      {
                        bool IsE = false;
                        byte DoorID = 0;
                        UInt32 cardNo = 0;
                        UInt32 OtherCardNo = 0;
                        string EmpNo = "";
                        string EmpName = "";
                        string EmpPass = "";
                        AccessV2API.TYPE_Register Register;
                        RecordCount = dtPower.Rows.Count;
                        for (int k = 0; k < RecordCount; k++)
                        {
                          ShowReadDataProcess(RecordCount, k + 1);
                          IsE = dtPower.Rows[k]["IsEnable"].ToString().ToUpper() == "Y";
                          DoorID = Convert.ToByte(dtPower.Rows[k]["MacDoorID"].ToString());
                          UInt32.TryParse(dtPower.Rows[k]["CardPhysicsNo10"].ToString(), out cardNo);
                          UInt32.TryParse(dtPower.Rows[k]["OtherCardNo"].ToString(), out OtherCardNo);
                          EmpNo = DeviceObject.objMJNew.GetLengthText(dtPower.Rows[k]["EmpNo"].ToString(), 16);
                          EmpName = DeviceObject.objMJNew.GetLengthText(dtPower.Rows[k]["EmpName"].ToString(), 16);
                          EmpPass = DeviceObject.objMJNew.GetLengthText(dtPower.Rows[k]["CardPWD"].ToString(), 8);
                          if (EmpPass == null) EmpPass = "";
                          EmpPass = EmpPass.Length > 8 ? EmpPass.Substring(0, 8) : EmpPass;
                          if (IsE)
                          {
                            if (cardNo > 0)
                            {
                              Register = new AccessV2API.TYPE_Register();
                              Register.CardNo = cardNo;
                              Register.Door = DoorID;
                              Register.Password = EmpPass;
                              UInt32.TryParse(dtPower.Rows[k]["MacTimeNo"].ToString(), out Register.TimeGroup);
                              DeviceObject.objMJNew.DateTimeToMJDateTime(Convert.ToDateTime(dtPower.Rows[k]["CardStartDate"].ToString()), ref Register.DateBegin);
                              DeviceObject.objMJNew.DateTimeToMJDateTime(Convert.ToDateTime(dtPower.Rows[k]["CardEndDate"].ToString()), ref Register.DateEnd);
                              Register.UserID = EmpNo;
                              Register.UserName = EmpName;
                              state = DeviceObject.objMJNew.AddRegister(Register);
                            }
                            if (state && OtherCardNo > 0)
                            {
                              Register = new AccessV2API.TYPE_Register();
                              Register.CardNo = OtherCardNo;
                              Register.Door = DoorID;
                              Register.Password = EmpPass;
                              UInt32.TryParse(dtPower.Rows[k]["MacTimeNo"].ToString(), out Register.TimeGroup);
                              DeviceObject.objMJNew.DateTimeToMJDateTime(Convert.ToDateTime(dtPower.Rows[k]["CardStartDate"].ToString()), ref Register.DateBegin);
                              DeviceObject.objMJNew.DateTimeToMJDateTime(Convert.ToDateTime(dtPower.Rows[k]["CardEndDate"].ToString()), ref Register.DateEnd);
                              Register.UserID = EmpNo;
                              Register.UserName = EmpName;
                              state = DeviceObject.objMJNew.AddRegister(Register);
                            }
                          }
                          else
                          {
                            state = true;
                          }
                          if (!state) break;
                          RecordIndex++;
                        }
                      }
                    }
                    catch (Exception E)
                    {
                      state = false;
                      Pub.ShowErrorMsg(E);
                    }
                    UpdateMsg(state, string.Format("{0}/{1}", RecordIndex, RecordCount));
                    break;
                }
              }
              else
              {
                mjConn = (QHKS.TMJConnInfo)tvMac.Nodes[i].Nodes[j].Tag;
                switch (AutoType)
                {
                  case 1://同步时间
                    msg = string.Format(Pub.GetResText(formCode, "MsgSyncTime", ""), devName, mjConn.MacSN);
                    break;
                  case 2://回收数据
                    msg = string.Format(Pub.GetResText(formCode, "MsgGetData", ""), devName, mjConn.MacSN);
                    break;
                  case 3://下载黑名单
                    msg = string.Format(Pub.GetResText(formCode, "MsgBlackMJ", ""), mjConn.MacSN);
                    break;
                  case 4://下载权限
                    msg = string.Format(Pub.GetResText(formCode, "MsgDownPower", ""), devName, mjConn.MacSN);
                    break;
                }
                MsgString = msg;
                ShowMsg(msg);
                DeviceObject.objMJ.Init(ref mjConn);
                switch (AutoType)
                {
                  case 1://同步时间
                    state = DeviceObject.objMJ.SetMacTime(dt);
                    UpdateMsg(state);
                    break;
                  case 2://回收数据
                    MJReadData readData = new MJReadData(this.Text + "[" + AutoName + "]");
                    state = readData.ReadData(db, mjConn.MacSN, ref RecordCount, ref RecordIndex, ShowReadDataProcess);
                    UpdateMsg(state, string.Format("{0}/{1}", RecordIndex, RecordCount));
                    break;
                  case 3://下载黑名单
                    MJDownBlack mjBlack = new MJDownBlack(dtBlack, mjConn);
                    state = mjBlack.Down();
                    UpdateMsg(state);
                    break;
                  case 4://下载权限
                    RecordIndex = 0;
                    RecordCount = 0;
                    try
                    {
                      dtPower = db.GetDataTable(Pub.GetSQL(DBCode.DB_003004, new string[] { "0", "" }));
                      state = DeviceObject.objMJ.ClearMacPower();
                      if (state)
                      {
                        bool IsE = false;
                        byte DoorID = 0;
                        string cardNo = "";
                        string OtherCardNo = "";
                        QHKS.TMJUpPowerInfo power;
                        RecordCount = dtPower.Rows.Count;
                        for (int k = 0; k < RecordCount; k++)
                        {
                          ShowReadDataProcess(RecordCount, k + 1);
                          IsE = dtPower.Rows[k]["IsEnable"].ToString().ToUpper() == "Y";
                          DoorID = Convert.ToByte(dtPower.Rows[k]["MacDoorID"].ToString());
                          cardNo = dtPower.Rows[k]["CardPhysicsNo10"].ToString();
                          OtherCardNo = dtPower.Rows[k]["OtherCardNo"].ToString();
                          if (IsE)
                          {
                            power = new QHKS.TMJUpPowerInfo();
                            power.CardNo = cardNo;
                            power.OtherCardNo = OtherCardNo;
                            power.StartDate = Convert.ToDateTime(dtPower.Rows[k]["CardStartDate"].ToString());
                            power.EndDate = Convert.ToDateTime(dtPower.Rows[k]["CardEndDate"].ToString());
                            power.Password = dtPower.Rows[k]["CardPWD"].ToString();
                            power.EmpNo = dtPower.Rows[k]["EmpNo"].ToString();
                            power.EmpName = dtPower.Rows[k]["EmpName"].ToString();
                            power.DoorID = DoorID;
                            byte.TryParse(dtPower.Rows[k]["MacTimeNo"].ToString(), out power.TimeID);
                            state = DeviceObject.objMJ.SetMacUpPowerInfo(ref power);
                          }
                          else
                          {
                            state = true;
                          }
                          if (!state) break;
                          RecordIndex++;
                        }
                      }
                    }
                    catch (Exception E)
                    {
                      state = false;
                      Pub.ShowErrorMsg(E);
                    }
                    UpdateMsg(state, string.Format("{0}/{1}", RecordIndex, RecordCount));
                    break;
                }
              }
              break;
            case 2:
              connInfo = (QHKS.TConnInfo)tvMac.Nodes[i].Nodes[j].Tag;
              switch (AutoType)
              {
                case 1://同步时间
                  msg = string.Format(Pub.GetResText(formCode, "MsgSyncTime", ""), devName, connInfo.MacSN);
                  break;
                case 2://回收数据
                  msg = string.Format(Pub.GetResText(formCode, "MsgGetData", ""), devName, connInfo.MacSN);
                  break;
                case 3://下载黑名单
                  msg = string.Format(Pub.GetResText(formCode, "MsgBlackSF", ""), connInfo.MacSN);
                  break;
                case 4://下载权限
                  msg = string.Format(Pub.GetResText(formCode, "MsgDownPower", ""), devName, connInfo.MacSN);
                  break;
              }
              MsgString = msg;
              ShowMsg(msg);
              DeviceObject.objKS.Init(ref connInfo);
              state = DeviceObject.objKS.SysDeviceInfoGet(ref MacVer);
              if (state) DeviceObject.objKS.InitMacVer(MacVer);
              switch (AutoType)
              {
                case 1://同步时间
                  if (state) state = DeviceObject.objKS.PubTimeSet(dt);
                  UpdateMsg(state);
                  break;
                case 2://回收数据
                  DeviceObject.objKS.SysSetState(false);
                  SFReadData readData = new SFReadData(this.Text + "[" + AutoName + "]", true);
                  if (state)
                  {
                    state = readData.ReadData(db, connInfo.MacSN, connInfo.MacType, ref dataMsg, false,
                      ShowSFReadDataProcess);
                  }
                  DeviceObject.objKS.SysSetState(true);
                  UpdateMsg(state, dataMsg);
                  break;
                case 3://下载黑名单
                  if (state)
                  {
                    SFDownBlack sfBlack = new SFDownBlack(dtBlack, connInfo);
                    if (state) state = sfBlack.Down();
                  }
                  UpdateMsg(state);
                  break;
                case 4://下载权限
                  break;
              }
              break;
            case 3:
              connFinger = (TConnInfoFinger)tvMac.Nodes[i].Nodes[j].Tag;
              switch (AutoType)
              {
                case 1://同步时间
                  msg = string.Format(Pub.GetResText(formCode, "MsgSyncTime", ""), devName, connFinger.MacSN);
                  break;
                case 2://回收数据
                  msg = string.Format(Pub.GetResText(formCode, "MsgGetData", ""), devName, connFinger.MacSN);
                  break;
                case 3://下载黑名单
                  break;
                case 4://下载权限
                  break;
              }
              MsgString = msg;
              ShowMsg(msg);
              DeviceObject.objFK623.InitConn(connFinger);
              switch (AutoType)
              {
                case 1://同步时间
                  DeviceObject.objFK623.Open();
                  state = DeviceObject.objFK623.IsOpen;
                  if (state) state = DeviceObject.objFK623.SetDeviceTime(dt);
                  DeviceObject.objFK623.Close();
                  UpdateMsg(state);
                  break;
                case 2://回收数据
                  FingerReadData readData = new FingerReadData(this.Text + "[" + AutoName + "]", 1);
                  state = readData.FK623ReadData(db, textFormat, connFinger.MacSN, ref RecordCount,
                    ref RecordIndex, ShowReadDataProcess);
                  UpdateMsg(state, string.Format("{0}/{1}", RecordIndex, RecordCount));
                  break;
                case 3://下载黑名单
                  break;
                case 4://下载权限
                  break;
              }
              break;
          }
        }
      }
      if (dtBlack != null) dtBlack.Reset();
      if (dtPower != null) dtPower.Reset();
      db.WriteSYLog(this.Text, AutoName, lblMsg.Text);
    }

    private void SelectLast()
    {
      msgGrid.Rows[msgGrid.RowCount - 1].Selected = true;
      msgGrid.CurrentCell = msgGrid.Rows[msgGrid.RowCount - 1].Cells[0];
    }

    private void ShowMsg(string msg)
    {
      msgGrid.Rows.Add();
      msgGrid[0, msgGrid.RowCount - 1].Value = DateTime.Now.ToString();
      msgGrid[1, msgGrid.RowCount - 1].Value = msg;
      lblMsg.Text = msg;
      SelectLast();
    }

    private void UpdateMsg(bool state)
    {
      UpdateMsg(state, "");
    }

    private void UpdateMsg(bool state, string MacMsg)
    {
      string msg = "";
      if (state)
        msg = Pub.GetResText(formCode, "MsgSuccess", "");
      else
        msg = Pub.GetResText(formCode, "MsgFailure", "");
      msg = msgGrid[1, msgGrid.RowCount - 1].Value.ToString() + msg;
      if (MacMsg != "") msg = msg + "  [" + MacMsg + "]";
      msgGrid[1, msgGrid.RowCount - 1].Value = msg;
      lblMsg.Text = msg;
      SelectLast();
    }

    private void frmSYAuto_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (isRealing)
      {
        ExecItemTAG2();
        e.Cancel = true;
      }
    }

    public void ShowReadDataProcess(int RecordCount, int RecordIndex)
    {
      progBar.Value = RecordIndex * 100 / RecordCount;
      lblMsg.Text = MsgString + string.Format("{0}/{1}", RecordIndex, RecordCount);
      Application.DoEvents();
    }

    public void ShowSFReadDataProcess(int RecordCount, int RecordIndex, string msg)
    {
      progBar.Value = RecordIndex * 100 / RecordCount;
      lblMsg.Text = MsgString + msg;
      Application.DoEvents();
    }
  }
}