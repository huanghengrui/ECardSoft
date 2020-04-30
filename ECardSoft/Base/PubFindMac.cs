using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmPubFindMac : frmBaseDialog
  {
    private byte FindType = 0;
    private List<TSFMacType> sfMacList = new List<TSFMacType>();

    protected override void InitForm()
    {
      formCode = "PubFindMac";
      dataGrid.Columns.Clear();
      AddColumn(dataGrid, 1, "SelectCheck", false, false, 1, 50);
      AddColumn(dataGrid, 0, "MacSN", false, false, 1, 0);
      AddColumn(dataGrid, 1, "IsBigMac", true, false, 1, 50);
      AddColumn(dataGrid, 0, "MacIPAddress", false, false, 1, 0);
      AddColumn(dataGrid, 0, "MacType", FindType == 0, false, 1, 0);
      AddColumn(dataGrid, 0, "MacGateway", false, false, 1, 0);
      AddColumn(dataGrid, 0, "MacSubnetMask", false, false, 1, 0);
      AddColumn(dataGrid, 0, "MacPort", false, false, 1, 0);
      AddColumn(dataGrid, 0, "MacConnPWD", true, false, 1, 0);
      AddColumn(dataGrid, 0, "MacPhysicsAddress", false, false, 1, 0);
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      RefreshForm(true);
      LoadData();
    }

    public frmPubFindMac(string title, string CurrentTool, byte FindMacType)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      FindType = FindMacType;
      InitializeComponent();
    }

    private void LoadData()
    {
      DataTableReader dr = null;
      TSFMacType macType;
      sfMacList.Clear();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "202" }));
        while (dr.Read())
        {
          macType = new TSFMacType(Convert.ToInt32(dr["ID"]), dr["Name"].ToString());
          sfMacList.Add(macType);
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

    private void btnFind_Click(object sender, EventArgs e)
    {
      dataGrid.Rows.Clear();
      int MacFindCount = 0;
      string s = "";
      RefreshForm(false);
      if (FindType == 0)
      {
        if (SystemInfo.IsNewMJ)
        {
          List<AccessV2API.TYPE_NetSearch> list = DeviceObject.objMJNew.Search();
          for (int i = 0; i < list.Count; i++)
          {
            dataGrid.Rows.Add();
            dataGrid[0, dataGrid.RowCount - 1].Value = true;
            dataGrid[1, dataGrid.RowCount - 1].Value = list[i].DevSN;
            dataGrid[3, dataGrid.RowCount - 1].Value = list[i].DevAddr;
            dataGrid[4, dataGrid.RowCount - 1].Value = FindType.ToString();
            dataGrid[5, dataGrid.RowCount - 1].Value = list[i].GateWay;
            dataGrid[6, dataGrid.RowCount - 1].Value = list[i].NetMask;
            dataGrid[7, dataGrid.RowCount - 1].Value = list[i].DevPort;
            dataGrid[8, dataGrid.RowCount - 1].Value = "";
            dataGrid[9, dataGrid.RowCount - 1].Value = list[i].DevMac;
          }
        }
        else
        {
          QHKS.TMJFindMacInfo findInfo = new QHKS.TMJFindMacInfo();
          if (DeviceObject.objMJ.NetMacSearch(60000, 0, 0, ref MacFindCount))
          {
            for (int i = 0; i < MacFindCount; i++)
            {
              if ((DeviceObject.objMJ.NetMacSearchInfo(i, ref findInfo)) && (findInfo.MacSN != ""))
              {
                dataGrid.Rows.Add();
                dataGrid[0, dataGrid.RowCount - 1].Value = true;
                dataGrid[1, dataGrid.RowCount - 1].Value = findInfo.MacSN;
                dataGrid[3, dataGrid.RowCount - 1].Value = findInfo.IP;
                dataGrid[4, dataGrid.RowCount - 1].Value = FindType.ToString();
                dataGrid[5, dataGrid.RowCount - 1].Value = findInfo.Gateway;
                dataGrid[6, dataGrid.RowCount - 1].Value = findInfo.NetMask;
                dataGrid[7, dataGrid.RowCount - 1].Value = findInfo.Port;
                dataGrid[8, dataGrid.RowCount - 1].Value = "";
                dataGrid[9, dataGrid.RowCount - 1].Value = findInfo.MacAddress;
              }
            }
          }
        }
      }
      else
      {
        QHKS.TFindDeviceInfo findInfo = new QHKS.TFindDeviceInfo();
        if (DeviceObject.objKS.SysDeviceFind(SystemInfo.IsBigMacAdd, 6000, ref MacFindCount))
        {
          for (int i = 0; i < MacFindCount; i++)
          {
            if ((DeviceObject.objKS.SysDeviceFindValue(i, ref findInfo)) && (findInfo.MacSN > 0) &&
              (findInfo.MacSN <= SystemInfo.MaxSN603Ex))
            {
              if ((FindType == findInfo.DeviceType) ||
                ((FindType == 2) && (findInfo.DeviceType == 2) || (findInfo.DeviceType == 3) ||
                (findInfo.DeviceType == 4) || (findInfo.DeviceType == 5) || (findInfo.DeviceType == 6)))
              {
                dataGrid.Rows.Add();
                dataGrid[0, dataGrid.RowCount - 1].Value = true;
                dataGrid[1, dataGrid.RowCount - 1].Value = findInfo.MacSN;
                dataGrid[2, dataGrid.RowCount - 1].Value = SystemInfo.IsBigMacAdd;
                dataGrid[3, dataGrid.RowCount - 1].Value = findInfo.IP;
                if (FindType == 1)
                {
                  if (findInfo.CardType == 1)
                    s = "1-" + Pub.GetResText("", "KQMacType1", "");
                  else if (findInfo.CardType == 2)
                    s = "0-" + Pub.GetResText("", "KQMacType0", "");
                }
                else
                {
                  s = (findInfo.DeviceType + 30).ToString();
                  s = "[" + s + "]" + GetSFMacTypeName(findInfo.DeviceType + 30);
                }
                dataGrid[4, dataGrid.RowCount - 1].Value = s;
                dataGrid[5, dataGrid.RowCount - 1].Value = findInfo.Gateway;
                dataGrid[6, dataGrid.RowCount - 1].Value = findInfo.NetMask;
                dataGrid[7, dataGrid.RowCount - 1].Value = findInfo.Port;
                dataGrid[8, dataGrid.RowCount - 1].Value = "";
                dataGrid[9, dataGrid.RowCount - 1].Value = findInfo.MacAddress;
              }
            }
          }
        }
      }
      if (dataGrid.RowCount > 0)
      {
        dataGrid.Rows[0].Selected = true;
        dataGrid.CurrentCell = dataGrid.Rows[0].Cells[0];
      }
      RefreshForm(true);
    }

    private void RefreshForm(bool state)
    {
      this.Enabled = state;
      dataGrid.Enabled = state;
      btnFind.Enabled = state;
      btnEdit.Enabled = state;
      btnOk.Enabled = state;
      btnCancel.Enabled = state;
    }

    private string GetSFMacTypeName(int id)
    {
      string ret = "";
      for (int i = 0; i < sfMacList.Count; i++)
      {
        if (sfMacList[i].id == id)
        {
          ret = sfMacList[i].name;
          break;
        }
      }
      return ret;
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      if (dataGrid.SelectedRows.Count < 1) return;
      bool ret = false;
      string errMsg = "";
      frmPubFindMacEdit frm = new frmPubFindMacEdit();
      frm.NetMask = dataGrid.SelectedRows[0].Cells[6].Value.ToString();
      frm.Gateway = dataGrid.SelectedRows[0].Cells[5].Value.ToString();
      if (FindType == 0)
      {
        if (SystemInfo.IsNewMJ)
        {
          UInt32 devSN = Convert.ToUInt32(dataGrid.SelectedRows[0].Cells[1].Value.ToString());
          frm.IP = dataGrid.SelectedRows[0].Cells[3].Value.ToString();
          frm.Port = Convert.ToInt32(dataGrid.SelectedRows[0].Cells[7].Value.ToString());
          if (frm.ShowDialog() != DialogResult.OK) return;
          AccessV2API.TYPE_Network network = new AccessV2API.TYPE_Network();
          network.DevAddr = frm.IP;
          network.DevPort = Convert.ToUInt32(frm.Port);
          network.GateWay = frm.Gateway;
          network.NetMask = frm.NetMask;
          ret = DeviceObject.objMJNew.SetNetwork(devSN, network);
        }
        else
        {
          QHKS.TMJConnInfo connInfo = new QHKS.TMJConnInfo();
          connInfo.ConnType = 1;
          connInfo.MacSN = dataGrid.SelectedRows[0].Cells[1].Value.ToString();
          connInfo.NetHost = dataGrid.SelectedRows[0].Cells[3].Value.ToString();
          connInfo.NetPort = Convert.ToInt32(dataGrid.SelectedRows[0].Cells[7].Value.ToString());
          connInfo.CardProtocol = SystemInfo.CardProtocol;
          frm.IP = connInfo.NetHost;
          frm.Port = connInfo.NetPort;
          if (frm.ShowDialog() != DialogResult.OK) return;
          DeviceObject.objMJ.Init(ref connInfo);
          QHKS.TMJFindMacInfo macInfo = new QHKS.TMJFindMacInfo();
          macInfo.MacSN = connInfo.MacSN;
          macInfo.IP = frm.IP;
          macInfo.NetMask = frm.NetMask;
          macInfo.Gateway = frm.Gateway;
          macInfo.Port = frm.Port;
          ret = DeviceObject.objMJ.NetMacSetInfo(60000, ref macInfo);
        }
      }
      else
      {
        QHKS.TConnInfo connInfo = new QHKS.TConnInfo();
        connInfo.ConnType = 2;
        connInfo.MacSN = Convert.ToInt32(dataGrid.SelectedRows[0].Cells[1].Value.ToString());
        connInfo.IsBigMac = Convert.ToByte(dataGrid.SelectedRows[0].Cells[2].Value);
        if (FindType == 1)
          connInfo.MacType = 1;
        else
        {
          string s = dataGrid.SelectedRows[0].Cells[4].Value.ToString();
          if (!Pub.IsNumeric(s)) s = s.Substring(1, 2);
          connInfo.MacType = Convert.ToByte(Convert.ToInt32(s) - 30);
        }
        connInfo.NetHost = dataGrid.SelectedRows[0].Cells[3].Value.ToString();
        connInfo.NetPort = Convert.ToInt32(dataGrid.SelectedRows[0].Cells[7].Value.ToString());
        frm.IP = connInfo.NetHost;
        frm.Port = connInfo.NetPort;
        if (frm.ShowDialog() != DialogResult.OK) return;
        QHKS.TTCPIPSet ipSet = new QHKS.TTCPIPSet();
        ipSet.IP = frm.IP;
        ipSet.NetMask = frm.NetMask;
        ipSet.Gateway = frm.Gateway;
        ipSet.Port = frm.Port;
        DeviceObject.objKS.Init(ref connInfo);
        ret = DeviceObject.objKS.PubTCPIPSet(ref ipSet);
        errMsg = DeviceObject.objKS.ErrMsg;
      }
      if (ret)
      {
        dataGrid.SelectedRows[0].Cells[3].Value = frm.IP;
        dataGrid.SelectedRows[0].Cells[6].Value = frm.NetMask;
        dataGrid.SelectedRows[0].Cells[5].Value = frm.Gateway;
        dataGrid.SelectedRows[0].Cells[7].Value = frm.Port;
        Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg001", ""), MessageBoxIcon.Information);
      }
      else
        Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", "") + "\r\n\r\n" + errMsg);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string MacSN = "";
      string IP = "";
      string MacConnType = MacConnTypeString.LAN;
      string MacPort = "";
      byte MacType = 0;
      byte IsBigMac = 0;
      string s = "";
      DataTableReader dr = null;
      List<string> sql = new List<string>();
      for (int i = 0; i < dataGrid.RowCount; i++)
      {
        MacSN = dataGrid[1, i].Value.ToString();
        IP = dataGrid[3, i].Value.ToString();
        MacPort = dataGrid[7, i].Value.ToString();
        IsBigMac = Convert.ToByte(dataGrid[2, i].Value);
        try
        {
          if (FindType == 0)
          {
            if (SystemInfo.IsNewMJ)
              dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "1004", MacSN }));
            else
              dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003001, new string[] { "5", MacSN }));
            if (!dr.Read())
            {
              byte MacDoorType = 0;
              if (SystemInfo.IsNewMJ)
              {
                MacDoorType = Convert.ToByte(MacSN.Substring(1, 1));
                sql.Add(Pub.GetSQL(DBCode.DB_003001, new string[] { "1", MacSN, MacDoorType.ToString(), 
                  MacConnType, IP, MacPort, "", "", SystemInfo.CardProtocol.ToString() }));
              }
              else
              {
                MacDoorType = Convert.ToByte(MacSN.Substring(0, 2));
                sql.Add(Pub.GetSQL(DBCode.DB_003001, new string[] { "1", MacSN.Substring(2), MacDoorType.ToString(), 
                  MacConnType, IP, MacPort, "", "", SystemInfo.CardProtocol.ToString() }));
              }
            }
          }
          else if (FindType == 1)
          {
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_002001, new string[] { "5", MacSN }));
            if (!dr.Read())
            {
              sql.Add(Pub.GetSQL(DBCode.DB_002001, new string[] { "1", MacSN, SystemInfo.CardType.ToString(), 
                MacConnType, IP, MacPort, "", "", "", IsBigMac.ToString() }));
            }
          }
          else if (FindType == 2)
          {
            s = dataGrid.SelectedRows[0].Cells[4].Value.ToString();
            if (!Pub.IsNumeric(s)) s = s.Substring(1, 2);
            MacType = Convert.ToByte(s);
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004004, new string[] { "5", MacSN }));
            if (!dr.Read())
            {
              sql.Add(Pub.GetSQL(DBCode.DB_004004, new string[] { "1", MacSN, MacType.ToString(), 
                MacConnType, IP, MacPort, "", "", "", "", IsBigMac.ToString() }));
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
      if (sql.Count > 0)
      {
        if (db.ExecSQL(sql) != 0) return;
        db.WriteSYLog(this.Text, CurrentOprt, sql);
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
      }
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void frmPubFindMac_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!btnCancel.Enabled) e.Cancel = true;
    }
  }
}