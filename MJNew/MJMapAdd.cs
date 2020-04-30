using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace ECard78
{
  public partial class frmMJMapAdd : frmBaseDialog
  {
    private bool IsAdd = false;
    private TMapDoorInfo doorInfo;
    private const int mapSize = 57;

    protected override void InitForm()
    {
      formCode = "MJMapAdd";
      base.InitForm();
      this.Text = Title + "[" + CurrentOprt + "]";
      IsAdd = SysID == "";
      LoadData();
    }

    public frmMJMapAdd(string title, string CurrentTool, string GUID)
    {
      Title = title;
      CurrentOprt = CurrentTool;
      SysID = GUID;
      InitializeComponent();
    }

    private void LoadData()
    {
      button2.Enabled = false;
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (!IsAdd)
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003007, new string[] { "1", SysID }));
          if (dr.Read())
          {
            txtName.Text = dr["MapName"].ToString();
            byte[] buff = (byte[])(dr["mapPic"]);
            if (buff.Length > 0)
            {
              MemoryStream ms = new MemoryStream(buff);
              picMap.Image = Image.FromStream(ms);
              ms.Close();
              button2.Enabled = true;
            }
          }
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003007, new string[] { "8", SysID }));
          int x = 0;
          int y = 0;
          while (dr.Read())
          {
            doorInfo = new TMapDoorInfo(dr["MacDoorSysID"].ToString(), dr["MacSN"].ToString(),
              dr["MacDoorID"].ToString(), dr["MacDoorName"].ToString());
            int.TryParse(dr["LocationX"].ToString(), out x);
            int.TryParse(dr["LocationY"].ToString(), out y);
            DrawMapDot(x, y);
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

    private void button1_Click(object sender, EventArgs e)
    {
      if (dlgOpen.ShowDialog() != DialogResult.OK) return;
      picMap.Image = Image.FromFile(dlgOpen.FileName);
      button2.Enabled = true;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string name = txtName.Text.Trim();
      if (name == "")
      {
        txtName.Focus();
        ShowErrorEnterCorrect(label1.Text);
        return;
      }
      if (!Pub.CheckTextMaxLength(label1.Text, name, txtName.MaxLength))
      {
        txtName.Focus();
        return;
      }
      if (picMap.Image == null)
      {
        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
        return;
      }
      DataTableReader dr = null;
      bool IsOk = true;
      List<string> sql = new List<string>();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (IsAdd)
        {
          if (!db.GetServerGUID(ref SysID)) return;
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003007, new string[] { "2", name }));
          if (dr.Read())
          {
            txtName.Focus();
            ShowErrorCannotRepeated(label1.Text);
            IsOk = false;
          }
          sql.Add(Pub.GetSQL(DBCode.DB_003007, new string[] { "4", SysID, name }));
        }
        else
        {
          dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003007, new string[] { "3", SysID, name }));
          if (dr.Read())
          {
            txtName.Focus();
            ShowErrorCannotRepeated(label1.Text);
            IsOk = false;
          }
          sql.Add(Pub.GetSQL(DBCode.DB_003007, new string[] { "5", SysID, name }));
        }
        if (IsOk)
        {
          sql.Add(Pub.GetSQL(DBCode.DB_003007, new string[] { "9", SysID }));
          for (int j = 0; j < picMap.Controls.Count; j++)
          {
            doorInfo = (TMapDoorInfo)picMap.Controls[j].Tag;
            sql.Add(Pub.GetSQL(DBCode.DB_003007, new string[] { "10", SysID, doorInfo.DoorSysID, 
                picMap.Controls[j].Location.X.ToString(), picMap.Controls[j].Location.Y.ToString() }));
          }
          if (db.ExecSQL(sql) != 0) IsOk = false;
        }
        if (IsOk)
        {
          byte[] buff = new byte[0];
          MemoryStream ms = new MemoryStream();
          Bitmap t = new Bitmap(picMap.Image);
          t.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
          buff = ms.ToArray();
          db.UpdateByteData(Pub.GetSQL(DBCode.DB_003007, new string[] { "6", SysID }), "mapPic", buff);
        }
      }
      catch (Exception E)
      {
        IsOk = false;
        Pub.ShowErrorMsg(E);
      }
      finally
      {
        if (dr != null) dr.Close();
        dr = null;
      }
      if (IsOk)
      {
        db.WriteSYLog(this.Text, CurrentOprt, sql);
        Pub.MessageBoxShow(Pub.GetResText(formCode, "MsgSaveSucceed", ""), MessageBoxIcon.Information);
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      frmMJMapAddDoor frm = new frmMJMapAddDoor(Title, button2.Text, SysID);
      frm.doorList.Clear();
      for (int j = 0; j < picMap.Controls.Count; j++)
      {
        doorInfo = (TMapDoorInfo)picMap.Controls[j].Tag;
        frm.doorList.Add(doorInfo);
      }
      if (frm.ShowDialog() == DialogResult.OK)
      {
        bool isFind;
        int l = 0;
        int t = 0;
        const int spa = 5;
        while (picMap.Controls.Count > 0)
        {
          picMap.Controls[0].Dispose();
        }
        for (int i = 0; i < frm.doorList.Count; i++)
        {
          isFind = false;
          for (int j = 0; j < picMap.Controls.Count; j++)
          {
            doorInfo = (TMapDoorInfo)picMap.Controls[j].Tag;
            if (doorInfo.DoorSysID == frm.doorList[i].DoorSysID)
            {
              isFind = true;
              break;
            }
          }
          if (isFind) continue;
          doorInfo = frm.doorList[i];
          DrawMapDot(l, t);
          l += mapSize + spa;
          if (l + mapSize + spa > picMap.Width)
          {
            l = 0;
            t += mapSize + spa;
          }
        }
      }
    }

    [DllImport("user32.dll", EntryPoint = "SendMessageA")]
    private static extern int SendMessage(IntPtr hwnd, uint wMsg, uint wParam, uint lParam);
    [DllImport("user32.dll")]
    private static extern int ReleaseCapture();
    const uint WM_SYSCOMMAND = 0x0112;
    const uint SC_MOVE = 0xF010;
    const uint HTCAPTION = 0x0002;
    private void PictureBox_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left) return;
      if (!(sender is PictureBox)) return;
      ReleaseCapture();
      SendMessage((sender as Control).Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
    }

    private void DrawMapDot(int l, int t)
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
      btn.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
      toolTip.SetToolTip(btn, doorInfo.MacSN + "\r\n[" + doorInfo.DoorID + "]" + doorInfo.DoorName);
      picMap.Controls.Add(btn);
    }
  }
}