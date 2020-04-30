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
      Mutex mutex = new Mutex(true, "ECardDB78V3", out createdNew);
      if (createdNew)
      {
        System.Globalization.CultureInfo UICulture = new Base().InitLangName();
        SystemInfo.AppTitleLNG[0] = "一卡通";
        SystemInfo.AppTitleLNG[1] = "一卡通";
        SystemInfo.AppTitleLNG[SystemInfo.AppTitleLNG.Length - 1] = "ECard";
        switch (SystemInfo.LangName)
        {
          case "CHS"://简体中文
            SystemInfo.AppTitle = SystemInfo.AppTitleLNG[0];
            break;
          case "CHT"://繁体中文
            SystemInfo.AppTitle = SystemInfo.AppTitleLNG[1];
            break;
          default:
            SystemInfo.AppTitle = SystemInfo.AppTitleLNG[SystemInfo.AppTitleLNG.Length - 1];
            break;
        }
        Thread.CurrentThread.CurrentUICulture = UICulture;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        if (new frmDBLogin().ShowDialog() == DialogResult.OK)
        {
          Application.Run(new frmDBMain());
        }
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
  }
}