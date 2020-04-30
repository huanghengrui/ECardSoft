using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
  public partial class frmSKMakeCard : frmBaseDialog
  {
    private string CardData10 = "";
    private string CardDataH = "";
    private string CardData8 = "";
    private bool IsWorking = false;

    protected override void InitForm()
    {
      formCode = "SKMakeCard";
      base.InitForm();
      this.Text = Pub.GetResText(formCode, "mnu" + formCode, "", new string[] { "Main" });
      SetTextboxNumber(textBox1);
      SetTextboxNumber(textBox2);
      SetTextboxNumber(textBox3);
      SetTextboxNumber(textBox4);
      cbbCardType.Items.Clear();
      for (int i = 0; i <= 4; i++)
      {
        cbbCardType.Items.Add(Pub.GetResText(formCode, "CardType" + i.ToString(), ""));
      }
      cbbCardType.SelectedIndex = SystemInfo.ini.ReadIni(formCode, "CardType", 0);
      int v = db.ReadConfig(formCode, "Text1", 1);
      textBox1.Text = v.ToString();
      v = db.ReadConfig(formCode, "Text2", 0);
      textBox2.Text = v.ToString();
      v = db.ReadConfig(formCode, "Text3", 1);
      textBox3.Text = v.ToString();
      v = db.ReadConfig(formCode, "Text4", 0);
      textBox4.Text = v.ToString();
      int MacMode = db.ReadConfig(formCode, "MacMode", 1);
      rbHour.Checked = MacMode == 1;
      rbCount.Checked = MacMode == 2;
      rbXHour.Checked = MacMode == 3;
      rbXCount.Checked = MacMode == 4;
      RadioButton_Click(null, null);
    }

    public frmSKMakeCard()
    {
      InitializeComponent();
    }

    private void RadioButton_Click(object sender, EventArgs e)
    {
      if ((rbHour.Checked) || (rbXHour.Checked))
        label7.Text = Pub.GetResText(formCode, label7.Name, "");
      else
        label7.Text = Pub.GetResText(formCode, label7.Name + "1", "");
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "M", true)) return;
      if (IsWorking) return;
      IsWorking = true;
      RefreshForm();
      WriteCard();
      IsWorking = false;
      RefreshForm();
    }

    private void WriteCard()
    {
      int cardRet = 0;
      string msg = "";
      string info = "";
      DateTime dt = new DateTime();
      if (!db.GetServerDate(ref dt)) return;
      if (!Pub.CheckCardExists(ref CardData10, ref CardDataH, ref CardData8)) return;
      switch (cbbCardType.SelectedIndex)
      {
        case 0://制作设置时间卡
          msg = "Msg001";
          info = dt.ToString();
          cardRet = DeviceObject.objCPIC.WriteCardSKTime(dt);
          break;
        case 1://制作授权卡
          msg = "Msg002";
          HSUNFK.TCardSKAuth skAuth = new HSUNFK.TCardSKAuth();
          skAuth.TimeMode = 0;
          skAuth.UsedFlag = 0;
          skAuth.TrafficFlag = 0;
          skAuth.TotalFlag = 0;
          byte MacMode = 0;
          if (rbHour.Checked)
          {
            skAuth.TimeMode = 1;
            MacMode = 1;
          }
          else if (rbCount.Checked)
          {
            skAuth.UsedFlag = 1;
            MacMode = 2;
          }
          else if (rbXHour.Checked)
          {
            skAuth.TrafficFlag = 1;
            MacMode = 3;
          }
          else if (rbXCount.Checked)
          {
            skAuth.TotalFlag = 1;
            MacMode = 4;
          }
          if (!db.WriteConfig(formCode, "MacMode", MacMode, this.Text, cbbCardType.Text)) return;
          info = string.Format("TimeMode={0},UsedFlag={1},TrafficFlag={2},TotalFlag={3}",
            skAuth.TimeMode, skAuth.UsedFlag, skAuth.TrafficFlag, skAuth.TotalFlag);
          skAuth.PassVer = 1;
          skAuth.UsedMode = 0;
          cardRet = DeviceObject.objCPIC.WriteCardSKAuth(ref skAuth);
          break;
        case 2://制作费率卡
          msg = "Msg003";
          info = dt.ToString();
          int v1 = 0;
          int v2 = 0;
          int v3 = 0;
          int v4 = 0;
          if (!Pub.IsNumeric(textBox1.Text))
          {
            textBox1.Focus();
            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
            return;
          }
          int.TryParse(textBox1.Text, out v1);
          if ((v1 < 0) || (v1 > 255))
          {
            textBox1.Focus();
            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
            return;
          }
          if (!Pub.IsNumeric(textBox2.Text))
          {
            textBox2.Focus();
            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
            return;
          }
          int.TryParse(textBox2.Text, out v2);
          if ((v2 < 0) || (v2 > 255))
          {
            textBox2.Focus();
            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
            return;
          }
          if (!Pub.IsNumeric(textBox3.Text))
          {
            textBox3.Focus();
            if ((rbHour.Checked) || (rbXHour.Checked))
              Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error003", ""));
            else
              Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error002", ""));
            return;
          }
          int.TryParse(textBox3.Text, out v3);
          if ((rbHour.Checked) || (rbXHour.Checked))
          {
            if ((v3 < 0) || (v3 > 85))
            {
              textBox3.Focus();
              Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error003", ""));
              return;
            }
            v3 = v3 * 3;
          }
          else
          {
            if ((v3 < 0) || (v3 > 127))
            {
              textBox3.Focus();
              Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error002", ""));
              return;
            }
            v3 = v3 * 2;
          }
          if (!Pub.IsNumeric(textBox4.Text))
          {
            textBox4.Focus();
            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
            return;
          }
          int.TryParse(textBox4.Text, out v4);
          if ((v4 < 0) || (v4 > 255))
          {
            textBox4.Focus();
            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error001", ""));
            return;
          }
          if (!db.WriteConfig(formCode, "Text1", v1, this.Text, cbbCardType.Text)) return;
          if (!db.WriteConfig(formCode, "Text2", v2, this.Text, cbbCardType.Text)) return;
          if (!db.WriteConfig(formCode, "Text3", v3, this.Text, cbbCardType.Text)) return;
          if (!db.WriteConfig(formCode, "Text4", v4, this.Text, cbbCardType.Text)) return;
          info = string.Format("Time={0},Rates1={1},Time1={2},Rates2={3},Time2={4}", dt, v1, v3, v2, v4);
          HSUNFK.TCardSKRates skRates = new HSUNFK.TCardSKRates();
          skRates.CardTime = dt;
          skRates.Rates1 = Convert.ToByte(v1);
          skRates.Time1 = Convert.ToByte(v3);
          skRates.Rates2 = Convert.ToByte(v2);
          skRates.Time2 = Convert.ToByte(v4);
          skRates.BalanceLimit = 0;
          cardRet = DeviceObject.objCPIC.WriteCardSKRates(ref skRates);
          break;
        case 3:
          msg = "Msg004";
          info = dt.ToString();
          cardRet = DeviceObject.objCPIC.WriteCardSKClear(dt);
          break;
        case 4:
          msg = "Msg005";
          info = dt.ToString();
          cardRet = DeviceObject.objCPIC.WriteCardSKInit(dt);
          break;
      }
      if (cardRet == 0)
      {
        msg = Pub.GetResText(formCode, msg, "");
        db.WriteSYLog(this.Text, cbbCardType.Text, msg + "[" + CardData10 + "]" + info);
        Pub.CardBuzzer();
        Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
      }
      else
        Pub.ShowErrorMsg(Pub.GetCardMsg(cardRet));
    }

    private void RefreshForm()
    {
      label1.Enabled = !IsWorking;
      panel1.Enabled = !IsWorking;
      btnOk.Enabled = !IsWorking;
      btnCancel.Enabled = !IsWorking;
    }

    private void frmSKMakeCard_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (IsWorking) e.Cancel = true;
    }
  }
}