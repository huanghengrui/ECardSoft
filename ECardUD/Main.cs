using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Net;

namespace ECard78
{
  public partial class frmMain : Form
  {
    private const string formCode = "UDMain";
    private string AppPath = "";
    private string UpdatePath = "";
    private string UpdateTempPath = "";
    private string URL = "";
    private bool ReStart = false;
    private string AppName = "";
    private bool IsWorking = false;
    private IniFile ini = null;
    private LangRes res = null;
    private WebClient client = new System.Net.WebClient();

    private const string ufTxt = "update.txt";
    private const string ufCab = "update.cab";

    private List<TUpdateFileInfo> updateList = new List<TUpdateFileInfo>();

    public frmMain()
    {
      InitializeComponent();
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsWorking)
      {
        IsWorking = false;
        e.Cancel = true;
      }
    }

    private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
    {
      string fileName = AppPath + AppName;
      if (ReStart && File.Exists(fileName))
      {
        try
        {
          System.Diagnostics.Process.Start(fileName);
        }
        catch
        {
        }
      }
    }
    
    private void frmMain_Load(object sender, EventArgs e)
    {
      SetFormAppIcon(this);
      AppPath = GetFileNamePath(Application.ExecutablePath);
      UpdatePath = AppPath + "Update\\";
      if (!Directory.Exists(UpdatePath)) Directory.CreateDirectory(UpdatePath);
      UpdateTempPath = UpdatePath + "Temp\\";
      if (!Directory.Exists(UpdateTempPath)) Directory.CreateDirectory(UpdateTempPath);
      string fn = UpdatePath + "ECardUD.dat";
      ini = new IniFile(fn);
      res = new LangRes(AppPath);
      SetControlsText(this);
      this.Text = GetResText(formCode, "Caption", this.Text);
      this.Text = SystemInfo.AppTitle + " - " + this.Text;
      URL = ini.ReadIni("Info", "URL", "http://www.hsun.cn/update/ecard78 v3/");
      ReStart = ini.ReadIni("Info", "ReStart", true);
      AppName = ini.ReadIni("Info", "AppName", "ECard78.exe");
      RefreshForm();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      lv.Items.Clear();
      IsWorking = true;
      RefreshForm();
      ListViewItem item = lv.Items.Add(DateTime.Now.ToString());
      item.SubItems.Add(string.Format(GetResText(formCode, "Msg001", ""), ufTxt));
      item.SubItems.Add("");
      item.Selected = true;
      item.EnsureVisible();
      updateList.Clear();
      Application.DoEvents();
      string src = URL + ufTxt;
      string dest = UpdateTempPath + ufTxt;
      string msg = DownloadFile(src, dest);
      Application.DoEvents();
      if (msg != "")
      {
        item.SubItems[2].Text = msg;
        goto LoopEnd;
      }
      if (!IsWorking) goto LoopEnd;
      if (!File.Exists(dest)) goto LoopFailed;
      IniFile iniU = new IniFile(dest);
      int i = 1;
      string s = " ";
      string[] tmp;
      string FileName = "";
      bool CheckExists = false;
      int PathFlag = 0;
      bool ReqReg = false;
      TUpdateFileInfo updateInfo;
      while (s != "")
      {
        s = iniU.ReadIni("File", i.ToString(), "");
        if (s != "")
        {
          tmp = s.Split(' ');
          FileName = tmp[0];
          CheckExists = tmp[1] == "1";
          int.TryParse(tmp[2], out PathFlag);
          ReqReg = tmp[3] == "1";
          updateInfo = new TUpdateFileInfo(FileName, CheckExists, PathFlag, ReqReg);
          updateList.Add(updateInfo);
        }
        i++;
      }
      DeleteFile(dest);
      if (updateList.Count == 0) goto LoopFailed;
      item.SubItems[2].Text = GetResText(formCode, "Msg004", "");
      item = lv.Items.Add(DateTime.Now.ToString());
      item.SubItems.Add(string.Format(GetResText(formCode, "Msg001", ""), ufCab));
      item.SubItems.Add("");
      item.Selected = true;
      item.EnsureVisible();
      Application.DoEvents();
      src = URL + ufCab;
      dest = UpdateTempPath + ufCab;
      msg = DownloadFile(src, dest);
      Application.DoEvents();
      if (msg != "")
      {
        item.SubItems[2].Text = msg;
        goto LoopEnd;
      }
      if (!IsWorking) goto LoopEnd;
      if (!File.Exists(dest)) goto LoopFailed;
      item.SubItems[2].Text = GetResText(formCode, "Msg004", "");
      ExpandFile(dest, UpdateTempPath);
      DeleteFile(dest);
      string filePath = "";
      DateTime scrTime;
      DateTime destTime;
      bool IsUpdate = false;
      for (int j = 1; j <= updateList.Count; j++)
      {
        if (!IsWorking) break;
        Application.DoEvents();
        item = lv.Items.Add(DateTime.Now.ToString());
        updateInfo = updateList[j - 1];
        item.SubItems.Add(string.Format(GetResText(formCode, "Msg003", ""), updateInfo.FileName));
        item.SubItems.Add("");
        item.Selected = true;
        item.EnsureVisible();
        switch (updateInfo.PathFlag)
        {
          case 1:
            filePath = AppPath;
            break;
          case 2:
            filePath = Environment.SystemDirectory;
            break;
          default:
            filePath = AppPath;
            break;
        }
        if (filePath.Substring(filePath.Length - 1) != "\\") filePath = filePath + "\\";
        dest = filePath + updateInfo.FileName;
        src = UpdateTempPath + updateInfo.FileName;
        if (!File.Exists(src))
        {
          item.SubItems[2].Text = GetResText(formCode, "Msg006", "");
          continue;
        }
        if (updateInfo.CheckExists && !File.Exists(dest))
        {
          item.SubItems[2].Text = GetResText(formCode, "Msg007", "");
          DeleteFile(src);
          continue;
        }
        IsUpdate = false;
        scrTime = File.GetLastWriteTime(src);
        destTime = File.GetLastWriteTime(dest);
        scrTime = new DateTime(scrTime.Year, scrTime.Month, scrTime.Day);
        destTime = new DateTime(destTime.Year, destTime.Month, destTime.Day);
        if (scrTime > destTime)
        {
          try
          {
            File.Copy(src, dest, true);
            item.SubItems[2].Text = GetResText(formCode, "Msg005", "");
            IsUpdate = true;
          }
          catch (Exception E)
          {
            item.SubItems[2].Text = E.Message;
          }
        }
        else
          item.SubItems[2].Text = GetResText(formCode, "Msg008", "");
        if (IsUpdate && updateInfo.ReqReg) RegisterDllOcx(dest);
        DeleteFile(src);
      }
      goto LoopEnd;
    LoopFailed:
      item.SubItems[2].Text = GetResText(formCode, "Msg002", "");
    LoopEnd:
      IsWorking = false;
      RefreshForm();
    }

    private void DeleteFile(string fileName)
    {
      try
      {
        File.Delete(fileName);
      }
      catch
      {
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      IsWorking = false;
      RefreshForm();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.Close();
    }
   
    private void RefreshForm()
    {
      button1.Enabled = !IsWorking;
      button2.Enabled = IsWorking;
      button3.Enabled = !IsWorking;
    }

    private string DownloadFile(string source, string fileName)
    {
      string ret = "";
      try
      {
        client.DownloadFile(source, fileName);
      }
      catch (Exception E)
      {
        ret = E.Message;
      }
      return ret;
    }

    [DllImport("shell32")]
    private static extern IntPtr SHGetFileInfo(string pszPath, uint dwAttribs, out SHFileInfo lpfi, int cb, SHGFI flags);
    public void SetFormAppIcon(Form frm)
    {
      string filename = Application.ExecutablePath;
      SHFileInfo fileiconinfo = new SHFileInfo();
      SHGetFileInfo(filename, 0, out fileiconinfo, Marshal.SizeOf(fileiconinfo), SHGFI.ICON | SHGFI.SmallIcon);
      try
      {
        Icon thefileicon = Icon.FromHandle(fileiconinfo.hIcon);
        frm.Icon = thefileicon;
      }
      catch
      {
      }
    }

    public string GetFileNamePath(string FileName)
    {
      string ret = "";
      string[] tmp = FileName.Split('\\');
      for (int i = 0; i < tmp.Length - 1; i++)
      {
        ret += tmp[i] + "\\";
      }
      return ret;
    }

    public string GetResText(string Code, string ID, string Def)
    {
      return res.GetResText(Code, ID, Def);
    }

    public string GetResText(string Code, string ID, string Def, string[] Codes)
    {
      return res.GetResText(Code, ID, Def, Codes);
    }

    protected void SetControlsText(Control obj)
    {
      ListView listView;
      GroupBox gbx;
      Label lab;
      Button btn;
      for (int i = 0; i < obj.Controls.Count; i++)
      {
        if (obj.Controls[i] is ListView)
        {
          listView = (ListView)obj.Controls[i];
          for (int j = 0; j < listView.Columns.Count; j++)
          {
            if (listView.Columns[j].Tag != null)
              listView.Columns[j].Text = GetResText(formCode, listView.Columns[j].Tag.ToString(), listView.Columns[j].Text);
            else
              listView.Columns[j].Text = GetResText(formCode, listView.Columns[j].Name, listView.Columns[j].Text);
          }
        }
        else if (obj.Controls[i] is GroupBox)
        {
          gbx = (GroupBox)obj.Controls[i];
          gbx.Text = GetResText(formCode, gbx.Name, gbx.Text);
          if ((gbx.Text == "") && (gbx.Tag != null))
          {
            gbx.Text = GetResText(formCode, gbx.Tag.ToString(), gbx.Text);
          }
          SetControlsText(gbx);
        }
        else if (obj.Controls[i] is Label)
        {
          lab = (Label)obj.Controls[i];
          lab.BackColor = Color.Transparent;
          lab.Text = GetResText(formCode, lab.Name, lab.Text);
          if ((lab.Text == "") && (lab.Tag != null))
          {
            lab.Text = GetResText(formCode, lab.Tag.ToString(), lab.Text);
          }
        }
        else if (obj.Controls[i] is Button)
        {
          btn = (Button)obj.Controls[i];
          btn.Text = GetResText(formCode, btn.Name, btn.Text);
          if ((btn.Text == "") && (btn.Tag != null))
          {
            btn.Text = GetResText(formCode, btn.Tag.ToString(), btn.Text);
          }
        }
      }
    }

    [DllImport("shell32")]
    private static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);
    [StructLayout(LayoutKind.Sequential)]
    private struct SHELLEXECUTEINFO
    {
      public int cbSize;
      public uint fMask;
      public IntPtr hwnd;
      public string lpVerb;
      public string lpFile;
      public string lpParameters;
      public string lpDirectory;
      public int nShow;
      public IntPtr hInstApp;
      public IntPtr IDList;
      public string lpClass;
      public IntPtr hkeyClass;
      public uint dwHotKey;
      public IntPtr hIcon;
      public IntPtr hProcess;
    }
    [DllImport("Kernel32.dll ")]
    private static extern int WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern int CloseHandle(IntPtr hObject);
    public void ExpandFile(string fileName, string path)
    {
      try
      {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
        info.cbSize = Marshal.SizeOf(info);
        info.lpVerb = "open";
        info.lpFile = "expand.exe";
        info.lpDirectory = path;
        if (path.Substring(path.Length - 1, 1) == "\\") path = path.Substring(0, path.Length - 1);
        info.lpParameters = "-F:* \"" + fileName + "\" \"" + path + "\"";
        info.fMask = 67142464;
        ShellExecuteEx(ref info);
        if (info.hProcess != new IntPtr(0))
        {
          WaitForSingleObject(info.hProcess, 0xFFFFFFFF);
          CloseHandle(info.hProcess);
        }
      }
      catch (Exception E)
      {
        MessageBoxShow(E.Source + "\r\n" + E.StackTrace + "\r\n" + E.Message);
      }
    }

    public void MessageBoxShow(string Msg)
    {
      MessageBoxShow(Msg, MessageBoxIcon.Exclamation);
    }

    public void MessageBoxShow(string Msg, MessageBoxIcon Icon)
    {
      string Title = this.Text;
      MessageBox.Show(Msg, Title, MessageBoxButtons.OK, Icon);
    }

    unsafe internal delegate UInt32 DllRegisterServer();
    [DllImport("kernel32.dll")]
    private extern static IntPtr LoadLibrary(String LibFileName);
    [DllImport("kernel32.dll")]
    private extern static IntPtr GetProcAddress(IntPtr hModule, String ProcName);
    [DllImport("kernel32.dll")]
    private extern static bool FreeLibrary(IntPtr hModule);
    public void RegisterDllOcx(string fileName)
    {
      IntPtr hLib = LoadLibrary(fileName);
      IntPtr proc = GetProcAddress(hLib, "DllRegisterServer");
      if (proc != IntPtr.Zero)
      {
        DllRegisterServer drs = (DllRegisterServer)Marshal.GetDelegateForFunctionPointer(proc, typeof(DllRegisterServer));
        drs();
      }
      FreeLibrary(hLib);
    }
  }

  public class TUpdateFileInfo
  {
    private string _file;
    private bool _exists;
    private int _path;
    private bool _reg;

    public TUpdateFileInfo(string FileName, bool CheckExists, int PathFlag, bool ReqReg)
    {
      _file = FileName;
      _exists = CheckExists;
      _path = PathFlag;
      _reg = ReqReg;
    }

    public string FileName
    {
      get { return _file; }
      set { _file = value; }
    }

    public bool CheckExists
    {
      get { return _exists; }
      set { _exists = value; }
    }

    public int PathFlag
    {
      get { return _path; }
      set { _path = value; }
    }

    public bool ReqReg
    {
      get { return _reg; }
      set { _reg = value; }
    }

    public override string ToString()
    {
      return FileName;
    }
  }

  public class IniFile
  {
    private string FileName;

    private bool IsNumeric(string str)
    {
      if (str == null) str = "";
      System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
      return reg.IsMatch(str);
    }

    public IniFile(string IniFileName)
    {
      FileName = IniFileName;
    }
    [DllImport("kernel32")]
    private static extern bool GetPrivateProfileString(string section, string key, string def,
      StringBuilder retVal, int size, string fileName);
    public string ReadIni(string Section, string Key, string Def)
    {
      StringBuilder temp = new StringBuilder(1024);
      GetPrivateProfileString(Section, Key, "", temp, 1024, FileName);
      string ret = temp.ToString().Trim();
      if (ret == "") ret = Def;
      return ret;
    }

    public byte ReadIni(string Section, string Key, byte Def)
    {
      string ret = ReadIni(Section, Key, Def.ToString());
      if (!IsNumeric(ret)) ret = "0";
      return Convert.ToByte(ret);
    }

    public int ReadIni(string Section, string Key, int Def)
    {
      string ret = ReadIni(Section, Key, Def.ToString());
      if (!IsNumeric(ret)) ret = "0";
      return Convert.ToInt32(ret);
    }

    public bool ReadIni(string Section, string Key, bool Def)
    {
      byte ret = ReadIni(Section, Key, Convert.ToByte(Def));
      return ret == 1;
    }

    [DllImport("kernel32")]
    private static extern bool WritePrivateProfileString(string section, string key, string Val, string fileName);
    public void WriteIni(string Section, string Key, string Val)
    {
      WritePrivateProfileString(Section, Key, Val, FileName);
    }

    public void WriteIni(string Section, string Key, byte Val)
    {
      WriteIni(Section, Key, Val.ToString());
    }

    public void WriteIni(string Section, string Key, int Val)
    {
      WriteIni(Section, Key, Val.ToString());
    }

    public void WriteIni(string Section, string Key, bool Val)
    {
      WriteIni(Section, Key, Convert.ToByte(Val));
    }
  }

  public class LangRes
  {
    private static string AppDir;
    private static string LangName;
    private static IniFile LangIni;
    private static string LangFile;
    private static bool IsBig5 = false;

    private bool IsNumeric(string str)
    {
      if (str == null) str = "";
      System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
      return reg.IsMatch(str);
    }

    public LangRes(string AppPath)
    {
      AppDir = AppPath;
      LangName = SystemInfo.LangName;
      LangFile = AppDir + "Lang\\" + LangName + ".lng";
      if (LangName == "CHT")
      {
        if (File.Exists(LangFile))
          IsBig5 = true;
        else if (File.Exists(AppDir + "Lang\\CHS.lng"))
        {
          LangFile = AppDir + "Lang\\CHS.lng";
        }
      }
      LangIni = new IniFile(LangFile);
    }

    [DllImport("Kernel32", CharSet = CharSet.Auto)]
    private static extern Int32 MultiByteToWideChar(UInt32 codePage, UInt32 dwFlags,
      [In, MarshalAs(UnmanagedType.LPStr)] String lpMultiByteStr, Int32 cbMultiByte,
      [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpWideCharStr, Int32 cchWideChar);
    [DllImport("Kernel32.dll")]
    private static extern int WideCharToMultiByte(uint CodePage, uint dwFlags,
      [In, MarshalAs(UnmanagedType.LPWStr)]string lpWideCharStr, int cchWideChar,
      [Out, MarshalAs(UnmanagedType.LPStr)]StringBuilder lpMultiByteStr, int cbMultiByte,
      IntPtr lpDefaultChar, IntPtr lpUsedDefaultChar);
    [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int LCMapString(int Locale, int dwMapFlags, string lpSrcStr, int cchSrc,
      [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpDestStr, int cchDest);
    public string GBtoBIG5(string src)
    {
      string ret = "";
      int len = MultiByteToWideChar(936, 0, src, -1, null, 0);
      StringBuilder wideStr = new StringBuilder(len * 2 + 1);
      len = LCMapString(0x0804, 0x04000000, src, -1, wideStr, len * 2);
      StringBuilder ws = new StringBuilder(len + 1);
      MultiByteToWideChar(936, 0, wideStr.ToString(), -1, ws, len);
      len = WideCharToMultiByte(950, 0, ws.ToString(), -1, null, 0, IntPtr.Zero, IntPtr.Zero);
      ret = ws.ToString();
      return ret;
    }

    public string GetResText(string Code, string ID, string Def)
    {
      if (ID == null) ID = "";
      string ret = LangIni.ReadIni(Code, ID, "");
      if (ret == "") ret = LangIni.ReadIni("Public", ID, "");
      if (ret == "") ret = LangIni.ReadIni("Main", ID, "");
      if ((ret == "") && ((IsNumeric(Def) || (Def.Trim() == "-")))) ret = Def;
      ret = ret.Replace("#13#10", "\r\n");
      if ((LangName == "CHT") && !IsBig5) ret = GBtoBIG5(ret);
      return ret;
    }

    public string GetResText(string Code, string ID, string Def, string[] Codes)
    {
      string ret = GetResText(Code, ID, Def);
      if (ret == "")
      {
        for (int i = Codes.GetLowerBound(0); i <= Codes.GetUpperBound(0); i++)
        {
          ret = GetResText(Codes[i], ID, Def);
          if (ret != "") break;
        }
      }
      return ret;
    }
  }

  public enum SHGFI
  {
    SmallIcon = 0x00000001,
    LargeIcon = 0x00000000,
    ICON = 0x000000100,
    DISPLAYNAME = 0x000000200,
    TYPENAME = 0x000000400,
    SysIconIndex = 0x00004000,
    UseFileAttributes = 0x00000010
  }

  public struct SHFileInfo
  {
    public IntPtr hIcon;
    public int iIcon;
    public uint dwAttribs;
    [MarshalAs(UnmanagedType.LPStr, SizeConst = 260)]
    public string pszDisplayName;
    [MarshalAs(UnmanagedType.LPStr, SizeConst = 80)]
    public string pszTypeName;
  };

  public struct SystemInfo
  {
    public static string LangName = "";
    public static string AppTitle = "";
  }
}