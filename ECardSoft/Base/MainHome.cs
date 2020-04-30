using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;

namespace ECard78
{
  public partial class frmMainHome : frmBaseMDIChild
  {
    private int ColCount = 5;
    private const int btnWidth = 81;
    private int currentIndex = 1;
    private string imagePath = "";

    private void WriteMainButton(ref int topIndex, int buttonIndex, string ButtonName)
    {
      string title = Pub.GetResText(formCode, ButtonName, "");
      if (title == "") title = Pub.GetResText(formCode, "mnu" + ButtonName, "");
      Panel btn = new Panel();
      btn.BackgroundImageLayout = ImageLayout.Stretch;
      if (buttonIndex == currentIndex)
      {
        btn.BackgroundImage = ECard78.Properties.Resources.button1;
        lblMenuTitle.Text = title;
      }
      else
        btn.BackgroundImage = ECard78.Properties.Resources.button2;
      btn.Name = "btn" + ButtonName;
      btn.Width = 120;
      btn.Height = 45;
      btn.TabStop = false;
      btn.Left = 0;
      btn.Top = (btn.Height + 10) * (topIndex - 1);
      btn.Font = new Font(Font.Name, 12, FontStyle.Bold);
      Label lbl = new Label();
      lbl.BackColor = Color.Transparent;
      lbl.Cursor = Cursors.Hand;
      lbl.Dock = DockStyle.Fill;
      if (buttonIndex == currentIndex)
        lbl.ForeColor = Color.White;
      else
        lbl.ForeColor = Color.Black;
      lbl.Location = new Point(0, 0);
      lbl.Name = "btn" + ButtonName + "L";
      lbl.Text = title;
      lbl.TextAlign = ContentAlignment.MiddleCenter;
      lbl.AutoSize = false;
      lbl.Tag = buttonIndex;
      lbl.Click += LabelMain__Click;
      btn.Controls.Add(lbl);
      panel42.Controls.Add(btn);
      topIndex++;
    }

    private void WriteMenuItem(Panel P, ref int num, ref int btnLeft, ref int btnTop, string ModuleName, string item)
    {
      string s = Pub.GetResText(formCode, "mnu" + item, "");
      if ((s == "") && (ModuleName == "RSCardOprter"))
      {
        switch (item)
        {
          case "0"://·¢¿¨
            s = Pub.GetResText("RSEmp", "ItemTAG1", "");
            break;
          case "1"://¹ÒÊ§µÇ¼Ç
            s = Pub.GetResText("RSEmp", "ItemTAG2", "");
            break;
          case "2"://½â¹ÒµÇ¼Ç
            s = Pub.GetResText("RSEmp", "ItemTAG3", "");
            break;
          case "3"://»»¿¨
            s = Pub.GetResText("RSEmp", "ItemTAG4", "");
            break;
          case "4"://ÍË¿¨
            s = Pub.GetResText("RSEmp", "ItemTAG5", "");
            break;
          case "5"://¿¨Æ¬ÐÞ¸´
            s = Pub.GetResText("RSEmp", "ItemTAG6", "");
            break;
          case "6"://²é¿¨
            s = Pub.GetResText("RSEmp", "ItemTAG7", "");
            break;
          case "7"://¸Ä¿¨
            s = Pub.GetResText("RSEmp", "CardModify", "");
            break;
          case "8"://ºÚÃûµ¥
            s = Pub.GetResText("RSEmp", "ItemCardBlack", "");
            break;
        }
      }
      string picName = item;
      if (ModuleName == "" && item != "")
        item = item.Substring(0, 2) + "@" + item;
      else
      {
        picName = ModuleName + item;
        item = ModuleName + "@" + item;
      }
      Panel pnl = new Panel();
      pnl.Name = "pnl" + picName;
      pnl.BackColor = Color.Transparent;
      pnl.Width = btnWidth;
      pnl.Height = 100;
      if (num % ColCount == 1)
      {
        btnLeft = 0;
        if (num > 1) btnTop += 150;
      }
      else
      {
        btnLeft += 100;
      }
      pnl.Left = btnLeft;
      pnl.Top = btnTop;
      Panel btn = new Panel();
      btn.BackgroundImageLayout = ImageLayout.Stretch;
      btn.Dock = DockStyle.Top;
      btn.Height = 74;
      btn.Cursor = Cursors.Hand;
      btn.Click += LabelMenu__Click;
      btn.Tag = item;
      string imageFile = imagePath + picName + ".jpg";
      if (File.Exists(imageFile)) btn.BackgroundImage = Image.FromFile(imageFile);
      Label lbl = new Label();
      lbl.Dock = DockStyle.Fill;
      lbl.BackColor = Color.Transparent;
      lbl.ForeColor = Color.Black;
      lbl.AutoSize = false;
      lbl.AutoEllipsis = true;
      lbl.TextAlign = ContentAlignment.MiddleCenter;
      lbl.Text = s;
      lbl.Click += LabelMenu__Click;
      lbl.Cursor = Cursors.Hand;
      lbl.Tag = item;
      toolTip.SetToolTip(btn, s);
      toolTip.SetToolTip(lbl, s);
      pnl.Controls.Add(lbl);
      pnl.Controls.Add(btn);
      P.Controls.Add(pnl);
      num++;
    }

    private void WriteMenu(int ModuleType, string menuName)
    {
      WriteMenu(ModuleType, menuName, "");
    }

    private void WriteMenu(int ModuleType, string menuName, string IniSection)
    {
      WriteMenu(ModuleType, menuName, IniSection, "");
    }

    private void WriteMenu(int ModuleType, string menuName, string IniSection, string ModuleName)
    {
      Panel P = null;

      for (int i = 0; i < panel44.Controls.Count; i++)
      {
        if (panel44.Controls[i].Name == "div" + menuName)
        {
          P = (Panel)panel44.Controls[i];
          break;
        }
      }
      if (P != null)
      {
        Panel btn;
        for (int i = 0; i < P.Controls.Count; i++)
        {
          btn = (Panel)P.Controls[i];
          for (int j = 0; j < btn.Controls.Count; j++)
          {
            btn.Controls[j].Dispose();         
          }
          btn.Controls.Clear();
          btn.Dispose();
        }
        P.Controls.Clear();
      }
      else
      {
        P = new Panel();
        P.Enabled = ModuleType == currentIndex;
        P.Visible = P.Enabled;
        P.Name = "div" + menuName;
        P.BackColor = Color.Transparent;
        P.AutoScroll = true;
        panel44.Controls.Add(P);
      }
      string incFile = SystemInfo.AppPath + "www\\menu.inc";
      int num = 1;
      string item = "";
      DataTable dt = null;
      int btnLeft = 0;
      int btnTop = 10;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dt = db.GetDataTable(Pub.GetSQL(DBCode.DB_000002, new string[] { "301", OprtInfo.OprtSysID, ModuleType.ToString() }));
        if (dt.Rows.Count == 0)
        {
          do
          {
            if (IniSection == "")
              item = SystemInfo.webIni.ReadIni(menuName, num.ToString("000000"), "");
            else
              item = SystemInfo.webIni.ReadIni(IniSection, num.ToString("000000"), "");
            if (item != "")
            {
              WriteMenuItem(P, ref num, ref btnLeft, ref btnTop, ModuleName, item);
            }
          }
          while (item != "");
        }
        else
        {
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            ModuleName = dt.Rows[i]["ModuleID"].ToString();
            if (ModuleName.ToLower() != "rscardoprter") ModuleName = "";
            item = dt.Rows[i]["SubID"].ToString();
            if (item != "")
            {
              WriteMenuItem(P, ref num, ref btnLeft, ref btnTop, ModuleName, item);
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
          dt.Dispose();
        }
        dt = null;
      }
    }

    private void InitHome()
    {
      int topIndex = 1;
      WriteMainButton(ref topIndex, 1, "Desktop");
      WriteMainButton(ref topIndex, 2, "BasicInfo");
      if (SystemInfo.HasFaCard) WriteMainButton(ref topIndex, 3, "CardInfo");
      if (SystemInfo.HasKQ) WriteMainButton(ref topIndex, 4, "KQ");
      if (SystemInfo.HasMJ) WriteMainButton(ref topIndex, 5, "MJ");
      if (SystemInfo.HasSF) WriteMainButton(ref topIndex, 6, "SF");
      if (SystemInfo.HasSK) WriteMainButton(ref topIndex, 7, "SK");
      if (ExtModuleInfo.homeName != null && ExtModuleInfo.homeName.Length > 0)
      {
        for (int i = 0; i < ExtModuleInfo.homeName.Length; i++)
        {
          WriteMainButton(ref topIndex, i + 8, ExtModuleInfo.homeName[i]);
        }
      }
      WriteMenu(1, "Desktop");
      WriteMenu(2, "BasicInfo");
      if (SystemInfo.HasFaCard) WriteMenu(3, "CardInfo", "", "RSCardOprter");
      if (SystemInfo.HasKQ)
      {
        switch (SystemInfo.KQFlag)
        {
          case 0:
            WriteMenu(4, "KQ");
            break;
          case 1:
            WriteMenu(4, "KQ", "KQFinger");
            break;
          case 2:
            WriteMenu(4, "KQ", "KQAll");
            break;
          case 3:
            WriteMenu(4, "KQ", "KQNo");
            break;
        }
      }
      if (SystemInfo.HasMJ) WriteMenu(5, "MJ");
      if (SystemInfo.HasSF)
      {
        if (SystemInfo.SFCardDRMode)
          WriteMenu(6, "SF", "SFRef");
        else
          WriteMenu(6, "SF");
      }
      if (SystemInfo.HasSK) WriteMenu(7, "SK");
      if (ExtModuleInfo.homeName != null && ExtModuleInfo.homeName.Length > 0)
      {
        for (int i = 0; i < ExtModuleInfo.homeName.Length; i++)
        {
          WriteMenu(i + 8, ExtModuleInfo.homeName[i]);
        }
      }
    }

    protected override void InitForm()
    {
      formCode = "MainHome";
      base.InitForm();
      this.Toolbar.Visible = false;
      this.Statusbar.Visible = false;
      ColCount = SystemInfo.webIni.ReadIni("Public", "ColCount", 5);
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "301", OprtInfo.OprtSysID, "1" }));
        if (!dr.Read()) currentIndex = 2;
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
      lblAppTitle.Font = new Font(Font.Name, 22, FontStyle.Bold);
      lblMenuTitle.Font = new Font(Font.Name, 18, FontStyle.Bold);
      btnCustomL.Font = new Font(Font.Name, 11, FontStyle.Bold);
      btnAboutL.Font = new Font(Font.Name, 11, FontStyle.Bold);
      btnExitL.Font = new Font(Font.Name, 11, FontStyle.Bold);
      lblAppTitle.Text = SystemInfo.AppTitle + Pub.GetResText(formCode, "apptitle", "");
      imagePath = SystemInfo.AppPath + "www\\Images\\";
      btnCustomL.Text = Pub.GetResText(formCode, "DesktopHint", "");
      btnAboutL.Text = Pub.GetResText(formCode, "mnuHelpAbout", "");
      btnExitL.Text = Pub.GetResText(formCode, "mnuSYClose", "");
      toolTip.SetToolTip(btnCustomL, btnCustomL.Text);
      toolTip.SetToolTip(btnAboutL, btnAboutL.Text + " " + SystemInfo.AppTitle);
      toolTip.SetToolTip(btnExitL, btnExitL.Text + " " + SystemInfo.AppTitle);
      InitHome();
      lblPhone.Font = new Font(Font.Name, 12, FontStyle.Bold);
      lblPhone.Left = lblAppTitle.Left + lblAppTitle.Width + 20;
      lblPhone.Top = lblAppTitle.Top + lblAppTitle.Height - lblPhone.Height;
    }

    public frmMainHome()
    {
      InitializeComponent();
    }

    private void frmMainHome_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!SystemInfo.SystemIsExit) e.Cancel = true;
    }

    private void btnCustomL_Click(object sender, EventArgs e)
    {
      frmMainHomeAdd frm = new frmMainHomeAdd(btnCustomL.Text, lblMenuTitle.Text, currentIndex.ToString());
      if (frm.ShowDialog() == DialogResult.OK)
      {
        switch (currentIndex)
        {
          case 1:
            WriteMenu(1, "Desktop");
            break;
          case 2:
            WriteMenu(2, "BasicInfo");
            break;
          case 3:
            WriteMenu(3, "CardInfo", "", "RSCardOprter");
            break;
          case 4:
            switch (SystemInfo.KQFlag)
            {
              case 0:
                WriteMenu(4, "KQ");
                break;
              case 1:
                WriteMenu(4, "KQ", "KQFinger");
                break;
              case 2:
                WriteMenu(4, "KQ", "KQAll");
                break;
              case 3:
                WriteMenu(4, "KQ", "KQNo");
                break;
            }
            break;
          case 5:
            WriteMenu(5, "MJ");
            break;
          case 6:
            if (SystemInfo.SFCardDRMode)
              WriteMenu(6, "SF", "SFRef");
            else
              WriteMenu(6, "SF");
            break;
          case 7:
            WriteMenu(7, "SK");
            break;
          default:
            if (ExtModuleInfo.homeName != null && ExtModuleInfo.homeName.Length > 0)
            {
              for (int i = 0; i < ExtModuleInfo.homeName.Length; i++)
              {
                WriteMenu(i + 8, ExtModuleInfo.homeName[i]);
              }
            }
            break;
        }
        frmMainHome_Resize(this, e);
      }
    }

    private void ExecModule(frmAppMain frm, string ModuleName, string Module)
    {
      if (frm == null) frm = Pub.GetAppMainForm();
      if (frm != null) frm.ExecModule(ModuleName, Module);
    }

    private void btnAboutL_Click(object sender, EventArgs e)
    {
      ExecModule(null, "About", "EXT");
    }

    private void btnExitL_Click(object sender, EventArgs e)
    {
      ExecModule(null, "Exit", "EXT");
    }

    private void LabelMain__Click(object sender, EventArgs e)
    {
      Label lbl = (Label)sender;
      Panel pnl = (Panel)lbl.Parent;
      Panel P;
      Label L;

      for (int i = 0; i < panel42.Controls.Count; i++)
      {
        P = (Panel)panel42.Controls[i];
        if (P == pnl)
        {
          P.BackgroundImage = ECard78.Properties.Resources.button1;
          lbl.ForeColor = Color.White;
          lblMenuTitle.Text = lbl.Text;
          currentIndex = Convert.ToInt32(lbl.Tag);
        }
        else
        {
          P.BackgroundImage = ECard78.Properties.Resources.button2;
          L = (Label)P.Controls[0];
          L.ForeColor = Color.Black;
        }
        P = (Panel)panel44.Controls[i];
        if (P.Name.Substring(3) == pnl.Name.Substring(3))
        {
          P.Enabled = true;
          P.Visible = true;
        }
        else
        {
          P.Enabled = false;
          P.Visible = false;
        }
      }
    }

    private void LabelMenu__Click(object sender, EventArgs e)
    {
      string tag = "";
      if (sender is Label)
        tag = ((Label)sender).Tag.ToString();
      else if (sender is Panel)
        tag = ((Panel)sender).Tag.ToString();
      string[] ss = tag.Split('@');
      if (ss.Length != 2) return;
      string ModuleName = ss[1];
      string Module = ss[0];
      frmAppMain frm = Pub.GetAppMainForm();
      if (Module == "RSCardOprter")
      {
        byte flag = Convert.ToByte(ModuleName);
        if (frm != null) frm.ExecRSCardOprter(flag);
      }
      else
        ExecModule(frm, ModuleName, Module);
    }

    private void frmMainHome_Resize(object sender, EventArgs e)
    {
      Panel P;
      Panel btn;
      int w, l;

      if (panel44.Width - ColCount * btnWidth <= 0)
        w = 5;
      else
        w = (panel44.Width - ColCount * btnWidth) / (ColCount + 1);
      for (int i = 0; i < panel44.Controls.Count; i++)
      {
        P = (Panel)panel44.Controls[i];
        P.Width = panel44.Width;
        P.Height = panel44.Height;
        l = w;
        for (int j = 0; j < P.Controls.Count; j++)
        {
          btn = (Panel)P.Controls[j];
          btn.Left = l;
          l += btn.Width + w;
          if ((j > 0) && ((j + 1) % ColCount == 0)) l = w;
        }
      }
    }
  }
}