using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ECard78
{
  public partial class frmMJMap : frmBaseMDIChild
  {
    private bool isRealing = false;
    private List<TMJWatch> watchIndex = new List<TMJWatch>();
    private int[] picW;
    private int[] picH;
    private double[] zoom;
    private TMapDoorInfo doorInfo;
    private const int mapSize = 57;
    private string wavPath = "";
    private int maxCount = 1000;

    protected override void InitForm()
    {
      formCode = "MJMap";
      SetToolItemState("ItemImport", false);
      SetToolItemState("ItemExport", false);
      SetToolItemState("ItemPrint", false);
      SetToolItemState("ItemLine1", false);
      SetToolItemState("ItemTAG1", true);
      SetToolItemState("ItemTAG2", true);
      SetToolItemState("ItemLine3", true);
      SetToolItemState("ItemZoomIn", true);
      SetToolItemState("ItemZoomOut", true);
      SetToolItemState("ItemLine6", true);
      IgnoreSelect = true;
      base.InitForm();
      DeleteMsg = Pub.GetResText(formCode, "Msg001", "");
      ExecItemRefresh();
      wavPath = SystemInfo.AppPath + "wav\\";
      maxCount = SystemInfo.ini.ReadIni("Public", "RealMax", 1000);
    }

    public frmMJMap()
    {
      InitializeComponent();
    }

    private void frmMJMap_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (isRealing)
      {
        ExecItemTAG2();
        e.Cancel = true;
      }
    }

    protected override void ExecItemAdd()
    {
      base.ExecItemAdd();
      frmMJMapAdd frm = new frmMJMapAdd(this.Text, CurrentTool, "");
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemEdit()
    {
      base.ExecItemEdit();
      frmMJMapAdd frm = new frmMJMapAdd(this.Text, CurrentTool, tabControl1.SelectedTab.Tag.ToString());
      if (frm.ShowDialog() == DialogResult.OK) ExecItemRefresh();
    }

    protected override void ExecItemDelete()
    {
      List<string> sql = new List<string>();
      sql.Add(Pub.GetSQL(DBCode.DB_003007, new string[] { "7", tabControl1.SelectedTab.Tag.ToString() }));
      string msg = tabControl1.SelectedTab.Text;
      if (db.ExecSQL(sql) != 0) return;
      db.WriteSYLog(this.Text, CurrentTool, msg);
      ExecItemRefresh();
      Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgDeleteSucceed", ""), MessageBoxIcon.Information);
    }

    protected override void ExecItemTAG1()
    {
      base.ExecItemTAG1();
      isRealing = true;
      RefreshForm(true);
      watchIndex.Clear();
      lbMsg.Items.Clear();
      timer1.Enabled = true;
    }

    protected override void ExecItemTAG2()
    {
      base.ExecItemTAG2();
      timer1.Enabled = false;
      isRealing = false;
      RefreshForm(true);
    }

    protected override void ExecItemZoomIn()
    {
      base.ExecItemZoomIn();
      ZoomCurrentMap(0);
    }

    protected override void ExecItemZoomOut()
    {
      base.ExecItemZoomOut();
      ZoomCurrentMap(1);
    }

    protected override void ExecItemRefresh()
    {
      DateTime StartTime = DateTime.Now;
      RefreshMsg(StrReading);
      while (tabControl1.TabPages.Count > 0)
      {
        while (tabControl1.TabPages[0].Controls.Count > 0)
        {
          tabControl1.TabPages[0].Controls[0].Dispose();
        }
        tabControl1.TabPages[0].Dispose();
      }
      tabControl1.TabPages.Clear();
      DataTableReader dr = null;
      DataTableReader dr1 = null;
      TabPage page;
      PictureBox pic;
      MemoryStream ms;
      int w;
      int h;
      int x = 0;
      int y = 0;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003007, new string[] { "0" }));
        while (dr.Read())
        {
          page = new TabPage();
          page.Text = dr["MapName"].ToString();
          page.Tag = dr["MapSysID"].ToString();
          page.AutoScroll = true;
          page.Name = "tabPage" + tabControl1.TabPages.Count.ToString();
          pic = new PictureBox();
          pic.Name = "pic" + tabControl1.TabPages.Count.ToString();
          pic.SizeMode = PictureBoxSizeMode.AutoSize;
          byte[] buff = (byte[])(dr["mapPic"]);
          if (buff.Length > 0)
          {
            ms = new MemoryStream(buff);
            pic.Image = Image.FromStream(ms);
            ms.Dispose();
          }
          w = pic.Width;
          h = pic.Height;
          pic.SizeMode = PictureBoxSizeMode.Zoom;
          pic.Width = w;
          pic.Height = h;
          page.Controls.Add(pic);
          pic.Left = 0;
          pic.Top = 0;
          tabControl1.TabPages.Add(page);
          dr1 = db.GetDataReader(Pub.GetSQL(DBCode.DB_003007, new string[] { "8", page.Tag.ToString() }));
          while (dr1.Read())
          {
            doorInfo = new TMapDoorInfo(dr1["MacDoorSysID"].ToString(), dr1["MacSN"].ToString(),
              dr1["MacDoorID"].ToString(), dr1["MacDoorName"].ToString());
            int.TryParse(dr1["LocationX"].ToString(), out x);
            int.TryParse(dr1["LocationY"].ToString(), out y);
            doorInfo.X = x;
            doorInfo.Y = y;
            doorInfo.MacConnType = dr1["MacConnType"].ToString();
            doorInfo.MacIPAddress = dr1["MacIPAddress"].ToString();
            doorInfo.MacPort = dr1["MacPort"].ToString();
            doorInfo.MacConnPWD = dr1["MacConnPWD"].ToString();
            DrawMapDot(pic, x, y);
          }
          dr1.Close();
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
        if (dr1 != null) dr1.Close();
        dr1 = null;
      }
      RefreshForm(true);
      RefreshMsg(StrReadEnd + Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
      picW = new int[tabControl1.TabPages.Count];
      picH = new int[tabControl1.TabPages.Count];
      zoom = new double[tabControl1.TabPages.Count];
      for (int i = 0; i < zoom.Length; i++)
      {
        picW[i] = tabControl1.TabPages[i].Controls[0].Width;
        picH[i] = tabControl1.TabPages[i].Controls[0].Height;
        zoom[i] = 1;
      }
    }

    protected override void RefreshForm(bool State)
    {
      base.RefreshForm(State);
      ItemAdd.Enabled = !isRealing;
      ItemEdit.Enabled = !isRealing && (tabControl1.TabCount > 0);
      ItemDelete.Enabled = !isRealing && (tabControl1.TabCount > 0);
      ItemTAG1.Enabled = !isRealing && (tabControl1.TabCount > 0);
      ItemTAG2.Enabled = isRealing && (tabControl1.TabCount > 0);
      ItemRefresh.Enabled = !isRealing;
      ItemZoomIn.Enabled = tabControl1.TabCount > 0;
      ItemZoomOut.Enabled = tabControl1.TabCount > 0;
      lblRecordState.Visible = false;
    }

    private void DrawMapDot(PictureBox picMap, int l, int t)
    {
      PictureBox btn;
      btn = new PictureBox();
      btn.Tag = doorInfo;
      btn.Left = l;
      btn.Top = t;
      btn.Width = mapSize;
      btn.Height = mapSize;
      btn.Image = Properties.Resources.doorclose;
      btn.SizeMode = PictureBoxSizeMode.Zoom;
      toolTip.SetToolTip(btn, doorInfo.MacSN + "\r\n[" + doorInfo.DoorID + "]" + doorInfo.DoorName);
      picMap.Controls.Add(btn);
    }

    private void ZoomCurrentMap(byte flag)
    {
      int index = tabControl1.SelectedIndex;
      if (flag == 0)
        zoom[index] += 0.1;
      else
        zoom[index] -= 0.1;
      int x = 0;
      int y = 0;
      tabControl1.TabPages[index].Controls[0].Width = Convert.ToInt32(picW[index] * zoom[index]);
      tabControl1.TabPages[index].Controls[0].Height = Convert.ToInt32(picH[index] * zoom[index]);
      for (int i = 0; i < tabControl1.TabPages[index].Controls[0].Controls.Count; i++)
      {
        doorInfo = (TMapDoorInfo)tabControl1.TabPages[index].Controls[0].Controls[i].Tag;
        tabControl1.TabPages[index].Controls[0].Controls[i].Width = Convert.ToInt32(mapSize * zoom[index]);
        tabControl1.TabPages[index].Controls[0].Controls[i].Height = Convert.ToInt32(mapSize * zoom[index]);
        x = Convert.ToInt32(doorInfo.X * zoom[index]);
        y = Convert.ToInt32(doorInfo.Y * zoom[index]);
        tabControl1.TabPages[index].Controls[0].Controls[i].Location = new Point(x, y);
      }
    }

    private bool FindDoorID(int DoorID)
    {
      bool ret = false;
      PictureBox btn;
      TMapDoorInfo door;
      int index = tabControl1.SelectedIndex;
      for (int i = 0; i < tabControl1.TabPages[index].Controls[0].Controls.Count; i++)
      {
        btn = (PictureBox)tabControl1.TabPages[index].Controls[0].Controls[i];
        door = (TMapDoorInfo)btn.Tag;
        if (door.DoorID == DoorID.ToString())
        {
          ret = true;
          break;
        }
      }
      return ret;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      int index = tabControl1.SelectedIndex;
      TMapDoorInfo door;
      TMJWatch watch = new TMJWatch("", 0);
      TConnInfoNewMJ connInfo;
      timer1.Enabled = false;
      bool findWatch;
      PictureBox btn;
      AccessV2API.TYPE_Setting setting = new AccessV2API.TYPE_Setting();
      for (int i = 0; i < tabControl1.TabPages[index].Controls[0].Controls.Count; i++)
      {
        Application.DoEvents();
        if (!isRealing) break;
        btn = (PictureBox)tabControl1.TabPages[index].Controls[0].Controls[i];
        door = (TMapDoorInfo)btn.Tag;
        connInfo = Pub.ValueToNewMJConnInfo(door.MacSN, door.MacConnType, door.MacIPAddress, door.MacPort, door.MacConnPWD);
        DeviceObject.objMJNew.NewDevice(connInfo, 0);
        findWatch = false;
        for (int j = 0; j < watchIndex.Count; j++)
        {
          if (watchIndex[j].MacSN == door.MacSN)
          {
            findWatch = true;
            watch = watchIndex[j];
            break;
          }
        }
        if (!findWatch)
        {
          watch = new TMJWatch(door.MacSN, 0);
          watchIndex.Add(watch);
        }
        if (!DeviceObject.objMJNew.ReadSetting(out setting)) continue;
        int DoorID = 0;
        int.TryParse(door.DoorID, out DoorID);
        if (DoorID > 0 && DoorID <= 4)
        {
          if (setting.DoorState[DoorID - 1] == 0)
            btn.Image = Properties.Resources.doorclose;
          else
            btn.Image = Properties.Resources.dooropen;
        }
        if (watch.Index == 0)
        {
          watch.Index = setting.LogCount;
          if (watch.Index == 1) watch.Index = 0;
        }
        AccessV2API.TYPE_Log log;
        if (!DeviceObject.objMJNew.ReadLog(watch.Index, out log)) continue;
        if (log.Door == 0 || log.Door == 255) continue;
        QHKS.TMJRecordInfo recInfo = new QHKS.TMJRecordInfo();
        recInfo.AlarmType = Convert.ToByte(log.WarnCode);
        recInfo.CardNo = log.CardNo.ToString("0000000000");
        recInfo.CardTime = DeviceObject.objMJNew.MJDateTimeToDateTime(log.DateTime);
        recInfo.DoorID = Convert.ToByte(log.Door);
        recInfo.IsCard = Convert.ToByte(log.CardNo > 0);
        if (recInfo.DoorID > 0 && recInfo.DoorID <= 4)
        {
          recInfo.IsPass = Convert.ToByte(log.DoorState[recInfo.DoorID - 1] > 0);
          if (recInfo.IsCard == 1 && recInfo.AlarmType >= 0x80 && recInfo.AlarmType <= 0x86) recInfo.IsPass = 1;
        }
        recInfo.ReaderID = Convert.ToByte(log.Reader);
        ShowRealData(recInfo, connInfo.MacSN.ToString());
        watch.Index++;
        Application.DoEvents();
      }
      if (isRealing) timer1.Enabled = true;
    }

    public void ShowRealData(QHKS.TMJRecordInfo recInfo, string MacSN)
    {
      string EmpSysID = "";
      string EmpNo = "";
      string EmpName = "";
      string DepartID = "";
      string DepartName = "";
      string CardSectorNo = "";
      string MacDoorName = "";
      string MacPassState = Pub.GetResText("MJMacReal", "AllowPass", "");
      string MacReadImpact = "";
      string Memo = "";
      string readerid = Pub.GetMJReaderID(MacSN, recInfo.ReaderID);
      string wavFile = "";
      DataTableReader dr = null;
      try
      {
        if (recInfo.IsCard == 1)
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003006, new string[] { "1", recInfo.CardNo }));
          if (dr.Read())
          {
            EmpSysID = dr["EmpSysID"].ToString();
            EmpNo = dr["EmpNo"].ToString();
            EmpName = dr["EmpName"].ToString();
            DepartID = dr["DepartID"].ToString();
            DepartName = dr["DepartName"].ToString();
            if (SystemInfo.HasFaCard)
              CardSectorNo = dr["CardSectorNo"].ToString();
            else
              CardSectorNo = dr["CardPhysicsNo10"].ToString();
          }
          dr.Close();
        }
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003006, new string[] { "3", MacSN, readerid }));
        if (dr.Read())
        {
          MacDoorName = dr["MacDoorName"].ToString();
          MacReadImpact = dr["MacReadImpact"].ToString();
        }
      }
      catch
      {
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      string msg = "";
      if ((EmpSysID == "") || (recInfo.IsPass == 0))
      {
        int IndexNum = recInfo.AlarmType;
        if (recInfo.IsCard == 1) IndexNum = 144;
        Memo = Pub.GetResText(formCode, "MJRecordMemo" + IndexNum.ToString(), "");
        if (recInfo.IsCard == 1)
        {
          Memo += "[" + recInfo.CardNo + "]";
          wavFile = "PassDis.wav";
        }
        else if (IndexNum == 140)
          wavFile = "NormalIn.wav";
        else if (IndexNum == 141)
          wavFile = "AlarmDur.wav";
        else if (IndexNum == 142)
          wavFile = "DoorTime.wav";
        else if ((IndexNum == 143) || (IndexNum == 145) || (IndexNum == 146))
          wavFile = "Alarm.wav";
        else if (IndexNum == 148)
          wavFile = "AlarmDis.wav";
        if (wavFile != "")
        {
          wavFile = wavPath + wavFile;
          Pub.PlaySound(wavFile);
        }
        msg = recInfo.CardTime.ToString() + "  " + MacSN + "  " + MacDoorName + "  " + Memo;
      }
      else
      {
        if (MacReadImpact.ToLower() == "in")
          wavFile = "NormalIn.wav";
        else
          wavFile = "NormalIn.wav";
        wavFile = wavPath + wavFile;
        Pub.PlaySound(wavFile);
        msg = CardSectorNo + "  " + recInfo.CardTime.ToString() + "  " + EmpNo + "  " + EmpName + "  " + 
          DepartID + "  " + DepartName + "  " + MacSN + "  " + MacDoorName + "  " + MacPassState + "  " + MacReadImpact;
      }
      TCommonType ctype = new TCommonType(EmpSysID, "", msg, true);
      lbMsg.Items.Add(ctype);
      while (lbMsg.Items.Count > maxCount) lbMsg.Items.RemoveAt(0);
      lbMsg.SelectedIndex = lbMsg.Items.Count - 1;
    }

    private void lbMsg_SelectedIndexChanged(object sender, EventArgs e)
    {
      picPhoto.BackgroundImage = null;
      if (lbMsg.SelectedIndex == -1) return;
      string EmpSysID = ((TCommonType)lbMsg.Items[lbMsg.SelectedIndex]).sysID;
      if (EmpSysID == "") return;
      DataTableReader dr = null;
      try
      {
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_001003, new string[] { "104", EmpSysID }));
        if (dr.Read())
        {
          if (dr["EmpPhotoImage"].ToString() != "")
          {
            byte[] buff = (byte[])(dr["EmpPhotoImage"]);
            if (buff.Length > 0)
            {
              MemoryStream ms = new MemoryStream(buff);
              picPhoto.BackgroundImage = Image.FromStream(ms);
              ms.Close();
            }
          }
        }
      }
      catch
      {
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
    }
  }

  public class TMJWatch
  {
    private string _MacSN = "";
    private UInt32 _Index = 0;

    public TMJWatch(string MacSN, UInt32 Index)
    {
      _MacSN = MacSN;
      _Index = Index;
    }

    public string MacSN
    {
      get { return _MacSN; }
    }

    public UInt32 Index
    {
      get { return _Index; }
      set { _Index = value; }
    }
  }
}