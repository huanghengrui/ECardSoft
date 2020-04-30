using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSYRegister : frmBaseDialog
  {
    protected override void InitForm()
    {
      formCode = "SYRegister";
      base.InitForm();
      this.Text = Title;
      txtSerial.Text = RegisterInfo.Serial;
      txtUser.Text = RegisterInfo.RegUser;
      txtKey.Text = RegisterInfo.RegKey;
    }

    public frmSYRegister(string title)
    {
      Title = title;
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      string RegUser = txtUser.Text.Trim();
      if (RegUser == "")
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
        txtUser.Focus();
        return;
      }
      string RegKey = txtKey.Text.Trim();
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        if (!db.IsRegister(false, RegUser, RegKey))
        {
          Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg001", ""));
          return;
        }
      }
      catch (Exception E)
      {
        Pub.ShowErrorMsg(E);
        return;
      }
      Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg002", ""), MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void frmSYRegister_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Control && e.Alt)
      {
        switch (e.KeyCode)
        {
          case Keys.E:
            frmSYRegisterDate frm = new frmSYRegisterDate(label3.Text);
            if (frm.ShowDialog() != DialogResult.OK) return;
            string User = frm.UserName;
            bool IsAlways = frm.IsAlways;
            DateTime ValidDate = frm.SelectDate;
            int Times = 0;
            int ret = DeviceObject.objCPIC.RegInfoRead(ref Times);
            if (ret == -1)
            {
              Pub.MessageBoxShow(Pub.GetResText(formCode, "Error002", ""));
              return;
            }
            if (ret != 0)
            {
              Pub.MessageBoxShow(Pub.GetResText(formCode, "Error003", ""));
              return;
            }
            string Key = db.GetRegKey(User, IsAlways, ValidDate);
            txtUser.Text = User;
            txtKey.Text = Key;
            Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Msg003", ""), Times), MessageBoxIcon.Information);
            break;
        }
      }
    }
  }
}