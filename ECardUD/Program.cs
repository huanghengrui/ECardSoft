using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace ECard78
{
  static class Program
  {
    [DllImport("User32.dll", EntryPoint = "IsIconic")]
    private static extern int IsIconic(IntPtr hWnd);
    [DllImport("User32.dll", EntryPoint = "OpenIcon")]
    private static extern long OpenIcon(IntPtr hWnd);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    /// <summary>
    /// 应用程序的主入口点。
    /// </summary>
    [STAThread]
    static void Main()
    {
      bool createdNew = true;
      Mutex mutex = new Mutex(true, "ECardUDV3", out createdNew);
      if (createdNew)
      {
        System.Globalization.CultureInfo UICulture = InitLangName();
        switch (SystemInfo.LangName)
        {
          case "CHS"://繁体中文
            SystemInfo.AppTitle = "浩顺一卡通";
            break;
          case "CHT"://繁体中文
            SystemInfo.AppTitle = "浩順一卡通";
            break;
          default://英语
            SystemInfo.AppTitle = "HYSOON ECard";
            break;
        }
        Thread.CurrentThread.CurrentUICulture = UICulture;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new frmMain());
        mutex.Close();
      }
      else
      {
        Process current = Process.GetCurrentProcess();
        foreach (Process process in Process.GetProcessesByName(current.ProcessName))
        {
          if (process.Id != current.Id)
          {
            if (IsIconic(process.MainWindowHandle) > 0)
              OpenIcon(process.MainWindowHandle);
            else
              SetForegroundWindow(process.MainWindowHandle);
            break;
          }
        }
      }
    }

    private static System.Globalization.CultureInfo InitLangName()
    {
      System.Globalization.CultureInfo UICulture = null;
      switch (Application.CurrentCulture.LCID)
      {
        case 0x804://简体中文
          UICulture = new System.Globalization.CultureInfo("zh-CN");
          SystemInfo.LangName = "CHS";
          break;
        case 0x404://繁体中文
        case 0x0c04:
        case 0x1004:
        case 0x1404:
          UICulture = new System.Globalization.CultureInfo("zh-TW");
          SystemInfo.LangName = "CHT";
          break;
        case 0x0411: //日语
          UICulture = new System.Globalization.CultureInfo("ja-JP");
          SystemInfo.LangName = "JPN";
          break;
        case 0x0412: //朝鲜语
          UICulture = new System.Globalization.CultureInfo("ko-KR");
          SystemInfo.LangName = "KOR";
          break;
        case 0x0c07://德语
        case 0x0407:
        case 0x1407:
        case 0x1007:
        case 0x0807:
          UICulture = new System.Globalization.CultureInfo("de-DE");
          SystemInfo.LangName = "DEU";
          break;
        case 0x0419: //俄语
          UICulture = new System.Globalization.CultureInfo("ru-RU");
          SystemInfo.LangName = "RUS";
          break;
        case 0x080c://法语
        case 0x040c:
        case 0x0c0c:
        case 0x140c:
        case 0x180c:
        case 0x100c:
          UICulture = new System.Globalization.CultureInfo("fr-FR");
          SystemInfo.LangName = "FRA";
          break;
        case 0x2c0a://西班牙语
        case 0x3c0a:
        case 0x180a:
        case 0x500a:
        case 0x400a:
        case 0x040a:
        case 0x1c0a:
        case 0x300a:
        case 0x240a:
        case 0x140a:
        case 0x0c0a:
        case 0x480a:
        case 0x280a:
        case 0x080a:
        case 0x4c0a:
        case 0x440a:
        case 0x100a:
        case 0x200a:
        case 0x380a:
        case 0x340a:
          UICulture = new System.Globalization.CultureInfo("es-ES");
          SystemInfo.LangName = "ESN";
          break;
        case 0x0810://意大利语
        case 0x0410:
          UICulture = new System.Globalization.CultureInfo("it-IT");
          SystemInfo.LangName = "ITA";
          break;
        case 0x0416://葡萄牙语
        case 0x0816:
          UICulture = new System.Globalization.CultureInfo("pt-PT");
          SystemInfo.LangName = "PTG";
          break;
        default:
          UICulture = new System.Globalization.CultureInfo("en-US");
          SystemInfo.LangName = "ENG";
          break;
      }
      return UICulture;
    }
  }
}