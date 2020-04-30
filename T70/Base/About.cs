using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace ECard78
{
  public partial class frmAbout : frmBaseDialog
  {
    private string GetFileInfo(string fileName)
    {
      string ret = "";
      if (File.Exists(fileName))
      {
        string fileTime = Pub.GetFileTimeString(fileName);
        FileVersionInfo fileVer = FileVersionInfo.GetVersionInfo(fileName);
        ret = fileVer.ProductVersion;
        if (ret == null) ret = "";
        if (ret == "")
          ret = fileTime;
        else
        {
          ret = ret.Replace(" ", "");
          ret = ret.Replace(',', '.');
          ret = ret + "(" + fileTime + ")";
        }
        ret = Pub.GetFileName(fileName) + ": " + ret + "\r\n";
      }
      return ret;
    }

    protected override void InitForm()
    {
      formCode = "About";
      base.InitForm();
      this.Text = Title + " " + SystemInfo.AppTitle;
      string grPath = Pub.GetObjFilePath("grdes.DesignerProps");
      string fileInfo = Pub.GetResText(formCode, "Version", "") + ":  " + SystemInfo.AppVersion + "(" +
        Pub.GetFileTimeString(Application.ExecutablePath).ToString() + ")\r\n" +
        Pub.GetResText(formCode, "DBVersion", "") + ":  " + SystemInfo.AccDBVersion + "\r\n" +
        GetFileInfo(Pub.GetObjFileName("QHAPI.CPIC")) + GetFileInfo(Pub.GetObjFileName("QHKS.KS")) +
        GetFileInfo(grPath + "grdes50.dll") + GetFileInfo(grPath + "gregn50.dll") +
        GetFileInfo(grPath + "FK623Attend.dll") + GetFileInfo(grPath + "FKAttend.dll") +
        GetFileInfo(grPath + "FKViaDev.dll") + GetFileInfo(grPath + "FpDataConv.dll") +
        GetFileInfo(grPath + "FaceDataConv.dll") + GetFileInfo(grPath + "LFWViaDev.dll") + 
        GetFileInfo(grPath + "RealSvrOcxTcp.ocx");
      txtInfo.Text = fileInfo.Trim();
      string oem = SystemInfo.ini.ReadIni("Public", "OemInfo", "");
      oem = oem.Replace("\\r\\n", "\r\n");
      lblOem.Text = oem;
      label1.Text += DeviceObject.objCPIC.GetMacTAG();
    }

    public frmAbout(string title)
    {
      Title = title;
      InitializeComponent();
    }

    private void frmAbout_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Control && e.Alt)
      {
        int h = SystemInfo.MainHandle.ToInt32();
        switch (e.KeyCode)
        {
          case Keys.Y:
            DeviceObject.objCard.Verify(h, SystemInfo.AppPath, 2);
            break;
          case Keys.P:
            frmAppMain frmAppMainForm = Pub.GetAppMainForm();
            if (frmAppMainForm != null) frmAppMainForm.ShowRegister();
            break;
          case Keys.E:
            string s = RegisterInfo.RegDateText == "" ? RegisterInfo.StateText : RegisterInfo.RegDateText;
            Pub.MessageBoxShow(s, MessageBoxIcon.Information);
            break;
          case Keys.R:
            if (SystemInfo.CardKey == "")
            {
              Pub.MessageBoxShow(Pub.GetResText(formCode, "ErrorCardkey", ""));
              return;
            }
            DeviceObject.objCard.Recover(h, SystemInfo.WaterFlag);
            break;
          case Keys.G:
            DeviceObject.objCard.Make(h);
            break;
          case Keys.D:
            DeviceObject.objCard.Dealers(h);
            break;
          case Keys.M:
            DeviceObject.objCard.MakeReg(h);
            break;
          case Keys.T:
            frmSyncTime frm = new frmSyncTime();
            frm.ShowDialog();
            break;
          case Keys.N:
            string ver = "";
            if (DeviceObject.objCPIC.GetVer(ref ver))
              Pub.MessageBoxShow(Pub.GetResText(formCode, "ReaderVersion", "") + ": " + ver, MessageBoxIcon.Information);
            else
              Pub.MessageBoxShow(Pub.GetResText(formCode, "ReadCardError1", ""));
            break;
          case Keys.S:
            string pass = "";
            if (Pub.InputBox(Pub.GetResText(formCode, "PassTitle", ""), Pub.GetResText(formCode, "PassPrompt", ""), true, ref pass))
            {
              DeviceObject.objCard.Card(h, SystemInfo.WaterFlag, pass);
            }
            break;
          case Keys.H:
            DeviceObject.objApp.DeviceSetup(h, SystemInfo.IsBigMacAdd);
            break;
          case Keys.L:
            new frmSYLog().ShowDialog();
            break;
        }
      }
    }
  }
}