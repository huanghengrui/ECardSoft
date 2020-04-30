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
  public partial class frmSYOption : frmBaseDialog
  {
    private bool IsAddEmpNo = SystemInfo.IsAddEmpNo;
    private string EmpNoPrefix = SystemInfo.EmpNoPrefix;
    private byte EmpNoNumBit = SystemInfo.EmpNoNumBit;
    private byte PubCardSector = SystemInfo.PubCardSector;
    private int CustomersCode = SystemInfo.CustomersCode;
    private byte SFBtBagFlag = SystemInfo.SFBtBagFlag;
    private byte SFBtBagDate = SystemInfo.SFBtBagDate;
    private int CardValidDays = SystemInfo.CardValidDays;

    protected override void InitForm()
    {
      formCode = "SYOption";
      base.InitForm();
      this.Text = Title;
      SetTextboxNumber(txtEmpNoNumBit);
      SetTextboxNumber(txtCustomersCode);
      SetTextboxNumber(txtPubCardSector);
      SetTextboxNumber(txtCardValidDays);
      SetTextboxNumber(txtRecordInterval);
      SetTextboxNumber(txtLeastWorkMin);
      SetTextboxNumber(txtLeastOtMin);
      SetTextboxNumber(txtResultDecimalPlaces);
      SetTextboxNumber(txtSFBtBagDate);
      cbbNormalShow.Items.Clear();
      cbbOtShow.Items.Clear();
      cbbNormalShow.Items.Add(Pub.GetResText(formCode, "ByHour", ""));
      cbbNormalShow.Items.Add(Pub.GetResText(formCode, "ByMinute", ""));
      cbbOtShow.Items.Add(Pub.GetResText(formCode, "ByHour", ""));
      cbbOtShow.Items.Add(Pub.GetResText(formCode, "ByMinute", ""));
      cbbKQCardType.Items.Clear();
      cbbKQCardType.Items.Add(Pub.GetResText(formCode, "KQMacType0", ""));
      cbbKQCardType.Items.Add(Pub.GetResText(formCode, "KQMacType1", ""));
      LoadData();
      txtPubCardSector.Enabled = db.GetFaCardCount() == 0;
      if (!txtCustomersCode.Enabled) txtCustomersCode.ReadOnly = true;
      if (!txtPubCardSector.Enabled) txtPubCardSector.ReadOnly = true;
      btnLoadKey.Enabled = txtPubCardSector.Enabled;
      bool HideLoadKey = false;
      if (!SystemInfo.HasRS)
      {
        tabControl1.TabPages.Remove(tabPage1);
        tabControl1.TabPages.Remove(tabPage2);
      }
      if (!SystemInfo.HasKQ)
      {
        tabControl1.TabPages.Remove(tabPage3);
        HideLoadKey = true;
      }
      else
      {
        if ((SystemInfo.KQFlag != 0) && (SystemInfo.KQFlag != 2))
        {
          label1.Visible = false;
          cbbKQCardType.Visible = false;
          cbbKQCardType.Enabled = false;
          if (!SystemInfo.HasSF && !SystemInfo.HasSK)
          {
            tabControl1.TabPages.Remove(tabPage2);
            HideLoadKey = true;
          }
        }
      }
      if (SystemInfo.HasMJ)
      {
        if (SystemInfo.IsNewMJ)
        {
          label2.Visible = false;
          cbbCardProtocol.Visible = false;
          cbbCardProtocol.Enabled = false;
          chkAdvTimeGroup.Visible = false;
          chkAdvTimeGroup.Enabled = false;
          chkAdvUseOtherCard.Top = cbbCardProtocol.Top;
        }
      }
      else
      {
        tabControl1.TabPages.Remove(tabPage4);
      }
      if (!SystemInfo.HasSF)
      {
        tabControl1.TabPages.Remove(tabPage5);
        if ((HideLoadKey) && !SystemInfo.HasSK)
        {
          btnLoadKey.Enabled = false;
          btnLoadKey.Visible = false;
          tabControl1.TabPages.Remove(tabPage2);
        }
      }
      chkEmpDelete.ForeColor = Color.Red;
      if (SystemInfo.IsLongEmpID) txtEmpNoPrefix.MaxLength = 1;
      chkExtScreen_CheckedChanged(null, null);
    }

    public frmSYOption(string title)
    {
      Title = title;
      InitializeComponent();
    }

    private void LoadData()
    {
      chkEmpAuto.Checked = SystemInfo.IsAddEmpNo;
      txtEmpNoPrefix.Text = SystemInfo.EmpNoPrefix;
      txtEmpNoNumBit.Text = SystemInfo.EmpNoNumBit.ToString();
      chkEmpDelete.Checked = SystemInfo.EmpDelete;
      chkFaCardFee.Checked = SystemInfo.FaCardFee;
      chkLongEmpID.Checked = SystemInfo.IsLongEmpID;
      chkFaDeposit.Checked = SystemInfo.AllowFaDeposit;
      txtCustomersCode.Text = SystemInfo.CustomersCode.ToString("000000");
      txtPubCardSector.Text = SystemInfo.PubCardSector.ToString();
      txtCardValidDays.Text = SystemInfo.CardValidDays.ToString();
      chkLossSelect.Checked = SystemInfo.AllowLossSelect;
      radioButton1.Checked = true;
      if (SystemInfo.SFBtBagFlag == 1) radioButton2.Checked = true;
      if (SystemInfo.SFBtBagFlag == 2) radioButton3.Checked = true;
      txtSFBtBagDate.Text = SystemInfo.SFBtBagDate.ToString();
      chkAllDevAllowance.Checked = SystemInfo.AllDevAllowance;
      chkExtScreen.Checked = SystemInfo.AllowExtScreen;
      chkRefAllowance.Checked = SystemInfo.AllowRefAllowance;
      chkMoreDepositType.Checked = SystemInfo.HasMoreDepositType;
      txtRecordInterval.Text = "30";
      txtLeastWorkMin.Text = "30";
      txtLeastOtMin.Text = "30";
      txtResultDecimalPlaces.Text = "2";
      chkIsNeedOtSure.Checked = true;
      cbbNormalShow.SelectedIndex = 0;
      cbbOtShow.SelectedIndex = 0;
      cbbKQCardType.SelectedIndex = SystemInfo.CardType;
      cbbCardProtocol.SelectedIndex = SystemInfo.CardProtocol;
      chkAdvTimeGroup.Checked = SystemInfo.AdvTimeGroup;
      chkAdvUseOtherCard.Checked = SystemInfo.AdvUseOtherCard;
      DataTableReader dr = null;
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "204" }));
        if (dr.Read())
        {
          txtRecordInterval.Text = dr["RecordInterval"].ToString();
          txtLeastWorkMin.Text = dr["LeastWorkMin"].ToString();
          txtLeastOtMin.Text = dr["LeastOtMin"].ToString();
          txtResultDecimalPlaces.Text = dr["ResultDecimalPlaces"].ToString();
          chkIsNeedOtSure.Checked = dr["IsNeedOtSure"].ToString().ToUpper() == "Y";
          byte byt = 1;
          byte.TryParse(dr["NormalShow"].ToString(), out byt);
          if (byt == 0) byt = 1;
          cbbNormalShow.SelectedIndex = byt - 1;
          byte.TryParse(dr["OtShow"].ToString(), out byt);
          if (byt == 0) byt = 1;
          cbbOtShow.SelectedIndex = byt - 1;
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

    private void btnEmp_Click(object sender, EventArgs e)
    {
      if (!CheckEmpParam()) return;
      txtEmp.Text = db.GetAutoEmpNo(1, EmpNoPrefix, EmpNoNumBit);
    }

    private void btnLoadKey_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "M", true)) return;
      DialogResult ret = Pub.MessageBoxQuestion(Pub.GetResText(formCode, "Msg001", ""));
      string SectorData = "";
      switch (ret)
      {
        case DialogResult.Yes:
          int rtn = DeviceObject.objCPIC.ReadCardKeySectorData(ref SectorData);
          if ((rtn != 0) || (SectorData == ""))
          {
            Pub.MessageBoxShow(Pub.GetCardMsg(rtn));
            return;
          }
          break;
        case DialogResult.No:
          dlgOpen.Filter = Pub.GetResText(formCode, "FilterKey", "") + "(*.key)|*.key";
          if (dlgOpen.ShowDialog() != DialogResult.OK) return;
          StreamReader sr = new StreamReader(dlgOpen.FileName, Encoding.Default);
          SectorData = sr.ReadLine();
          sr.Close();
          sr.Dispose();
          if (SectorData.Length != 96)
          {
            FileStream fs = new FileStream(dlgOpen.FileName, FileMode.Open);
            byte[] buf = new byte[fs.Length];
            fs.Read(buf, 0, (int)fs.Length);
            fs.Close();
            fs.Dispose();
            SectorData = "";
            for (int i = 0; i < buf.Length; i++)
            {
              SectorData += Pub.ByteToHex(buf[i]);
            }
          }
          break;
        default:
          break;
      }
      string key = "";
      string code = "";
      if (!DeviceObject.objCPIC.ReadCardKey(SectorData, ref key, ref code))
      {
        Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg003", ""));
        return;
      }
      if (!db.WriteConfig("RS_System", "DealersCode", code, this.Text, CurrentOprt)) return;
      SystemInfo.DealersCode = code;
      if (!db.WriteConfig("RS_System", "CardKey", key, this.Text, CurrentOprt)) return;
      SystemInfo.CardKey = DeviceObject.objCPIC.GetCardKey(key, "yyc120114");
      Pub.InitCardInfo();
      Pub.MessageBoxShow(Pub.GetResText(formCode, "Msg002", ""), MessageBoxIcon.Information);
    }

    private bool SaveKQParam()
    {
      bool ret = false;
      DataTableReader dr = null;
      string sql = "";
      int RecordInterval = Convert.ToInt32(txtRecordInterval.Text);
      int LeastWorkMin = Convert.ToInt32(txtLeastWorkMin.Text);
      int LeastOtMin = Convert.ToInt32(txtLeastOtMin.Text);
      int ResultDecimalPlaces = Convert.ToInt32(txtResultDecimalPlaces.Text);
      string IsNeedOtSure = "Y";
      if (!chkIsNeedOtSure.Checked) IsNeedOtSure = "N";
      byte NormalShow = Convert.ToByte(cbbNormalShow.SelectedIndex + 1);
      byte OtShow = Convert.ToByte(cbbOtShow.SelectedIndex + 1);
      try
      {
        if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
        dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "204" }));
        if (dr.Read())
          sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "206", RecordInterval.ToString(), LeastWorkMin.ToString(), 
            LeastOtMin.ToString(), ResultDecimalPlaces.ToString(), IsNeedOtSure, NormalShow.ToString(), OtShow.ToString() });
        else
          sql = Pub.GetSQL(DBCode.DB_000001, new string[] { "205", RecordInterval.ToString(), LeastWorkMin.ToString(), 
            LeastOtMin.ToString(), ResultDecimalPlaces.ToString(), IsNeedOtSure, NormalShow.ToString(), OtShow.ToString() });
        db.ExecSQL(sql);
        switch (SystemInfo.DBType)
        {
          case 1:
          case 2:
            db.ExecSQL("EXEC PKQ_CreateKQResult");
            break;
        }
        ret = true;
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
      if (ret)
      {
        db.WriteSYLog(this.Text, CurrentOprt + "[" + tabPage3.Text + "]", sql);
      }
      return ret;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (!db.CheckOprtRole(formCode, "M", true)) return;
      if (!CheckEmpParam()) return;
      if (!CheckCardParam()) return;
      if (!CheckKQParam()) return;
      if (!CheckSFParam()) return;
      CurrentOprt = btnOk.Text;
      string IsAdd = "Y";
      if (!IsAddEmpNo) IsAdd = "N";
      if (!db.WriteConfig("RS_System", "IsAddEmpNo", IsAdd, this.Text, CurrentOprt)) return;
      SystemInfo.IsAddEmpNo = IsAddEmpNo;
      if (!db.WriteConfig("RS_System", "EmpNoPrefix", EmpNoPrefix, this.Text, CurrentOprt)) return;
      SystemInfo.EmpNoPrefix = EmpNoPrefix;
      if (!db.WriteConfig("RS_System", "EmpNoNumBit", EmpNoNumBit, this.Text, CurrentOprt)) return;
      SystemInfo.EmpNoNumBit = EmpNoNumBit;
      if (!db.WriteConfig("RS_System", "EmpDelete", chkEmpDelete.Checked, this.Text, CurrentOprt)) return;
      SystemInfo.EmpDelete = chkEmpDelete.Checked;
      if (!db.WriteConfig("RS_System", "IsLongEmpID", chkLongEmpID.Checked, this.Text, CurrentOprt)) return;
      SystemInfo.IsLongEmpID = chkLongEmpID.Checked;
      if (!db.WriteConfig("RS_System", "FaCardFee", chkFaCardFee.Checked, this.Text, CurrentOprt)) return;
      SystemInfo.FaCardFee = chkFaCardFee.Checked;
      if (!db.WriteConfig("RS_System", "AllowFaDeposit", chkFaDeposit.Checked, this.Text, CurrentOprt)) return;
      SystemInfo.AllowFaDeposit = chkFaDeposit.Checked;
      if (txtCustomersCode.Enabled)
      {
        if (!db.WriteConfig("RS_System", "CustomersCode", CustomersCode, this.Text, CurrentOprt)) return;
        SystemInfo.CustomersCode = CustomersCode;
      }
      if (txtPubCardSector.Enabled)
      {
        if (!db.WriteConfig("RS_System", "PubCardSector", PubCardSector, this.Text, CurrentOprt)) return;
        SystemInfo.PubCardSector = PubCardSector;
        db.SetSFCardSector();
      }
      if (!db.WriteConfig("RS_System", "CardValidDays", CardValidDays, this.Text, CurrentOprt)) return;
      SystemInfo.CardValidDays = CardValidDays;
      if (!db.WriteConfig("RS_System", "AllowLossSelect", chkLossSelect.Checked, this.Text, CurrentOprt)) return;
      SystemInfo.AllowLossSelect = chkLossSelect.Checked;
      if (tabControl1.TabPages[tabPage3.Name] != null)
      {
        if (!SaveKQParam()) return;
        if (!db.WriteConfig("KQ_System", "CardType", cbbKQCardType.SelectedIndex, this.Text, CurrentOprt)) return;
        SystemInfo.CardType = Convert.ToByte(cbbKQCardType.SelectedIndex);
      }
      if (tabControl1.TabPages[tabPage4.Name] != null)
      {
        if (!db.WriteConfig("MJ_System", "CardProtocol", cbbCardProtocol.SelectedIndex, this.Text, CurrentOprt)) return;
        SystemInfo.CardProtocol = Convert.ToByte(cbbCardProtocol.SelectedIndex);
        if (!db.WriteConfig("MJ_System", "AdvTimeGroup", Convert.ToByte(chkAdvTimeGroup.Checked), this.Text, CurrentOprt)) return;
        SystemInfo.AdvTimeGroup = chkAdvTimeGroup.Checked;
        if (!db.WriteConfig("MJ_System", "AdvUseOtherCard", Convert.ToByte(chkAdvUseOtherCard.Checked), this.Text, CurrentOprt)) return;
        SystemInfo.AdvUseOtherCard = chkAdvUseOtherCard.Checked;
      }
      if (tabControl1.TabPages[tabPage5.Name] != null)
      {
        if (!db.WriteConfig("RS_System", "SFBtBagFlag", SFBtBagFlag, this.Text, CurrentOprt)) return;
        SystemInfo.SFBtBagFlag = SFBtBagFlag;
        if (txtSFBtBagDate.Enabled)
        {
          if (!db.WriteConfig("RS_System", "SFBtBagDate", SFBtBagDate, this.Text, CurrentOprt)) return;
          SystemInfo.SFBtBagDate = SFBtBagDate;
        }
        if (!db.WriteConfig("RS_System", "AllDevAllowance", chkAllDevAllowance.Checked, this.Text, CurrentOprt)) return;
        SystemInfo.AllDevAllowance = chkAllDevAllowance.Checked;
        if (!db.WriteConfig("RS_System", "AllowExtScreen", chkExtScreen.Checked, this.Text, CurrentOprt)) return;
        SystemInfo.AllowExtScreen = chkExtScreen.Checked;
        if (!db.WriteConfig("RS_System", "AllowRefAllowance", chkRefAllowance.Checked, this.Text, CurrentOprt)) return;
        SystemInfo.AllowRefAllowance = chkRefAllowance.Checked;
        if (!db.WriteConfig("RS_System", "MoreDepositType", chkMoreDepositType.Checked, this.Text, CurrentOprt)) return;
        SystemInfo.HasMoreDepositType = chkMoreDepositType.Checked;
      }
      Pub.InitCardInfo();
      string msg = Pub.GetResText(formCode, "MsgSaveSucceed", "");
      db.WriteSYLog(this.Text, CurrentOprt, msg);
      Pub.MessageBoxShow(msg, MessageBoxIcon.Information);
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private bool CheckEmpParam()
    {
      IsAddEmpNo = chkEmpAuto.Checked;
      EmpNoPrefix = txtEmpNoPrefix.Text.Trim();
      if (!Pub.IsNumeric(txtEmpNoNumBit.Text.Trim()))
      {
        txtEmpNoNumBit.Focus();
        Pub.MessageBoxShow(Pub.GetResText(formCode, "Error001", ""));
        return false;
      }
      EmpNoNumBit = Convert.ToByte(txtEmpNoNumBit.Text.Trim());
      if (chkLongEmpID.Checked)
      {
        if (Pub.GetTextLength(EmpNoPrefix) + EmpNoNumBit > 9)
        {
          txtEmpNoNumBit.Focus();
          Pub.MessageBoxShow(Pub.GetResText(formCode, "Error011", ""));
          return false;
        }
      }
      else
      {
        if (Pub.GetTextLength(EmpNoPrefix) + EmpNoNumBit > 20)
        {
          txtEmpNoNumBit.Focus();
          Pub.MessageBoxShow(Pub.GetResText(formCode, "Error002", ""));
          return false;
        }
      }
      return true;
    }

    private bool CheckCardParam()
    {
      if (txtCustomersCode.Enabled)
      {
        if (!Pub.IsNumeric(txtCustomersCode.Text.Trim()))
        {
          txtCustomersCode.Focus();
          Pub.MessageBoxShow(Pub.GetResText(formCode, "Error003", ""));
          return false;
        }
        CustomersCode = Convert.ToInt32(txtCustomersCode.Text.Trim());
        if ((CustomersCode <= 0) || (CustomersCode > 999999))
        {
          txtCustomersCode.Focus();
          Pub.MessageBoxShow(Pub.GetResText(formCode, "Error003", ""));
          return false;
        }
      }
      if (txtPubCardSector.Enabled)
      {
        if (!Pub.IsNumeric(txtPubCardSector.Text.Trim()))
        {
          txtPubCardSector.Focus();
          Pub.MessageBoxShow(Pub.GetResText(formCode, "Error004", ""));
          return false;
        }
        PubCardSector = Convert.ToByte(txtPubCardSector.Text.Trim());
        if ((PubCardSector < 1) || (PubCardSector > 11))
        {
          txtPubCardSector.Focus();
          Pub.MessageBoxShow(Pub.GetResText(formCode, "Error004", ""));
          return false;
        }
      }
      if (!Pub.IsNumeric(txtCardValidDays.Text.Trim()))
        CardValidDays = 0;
      else
        CardValidDays = Convert.ToInt32(txtCardValidDays.Text.Trim());
      return true;
    }

    public bool CheckKQParam()
    {
      if (tabControl1.TabPages[tabPage3.Name] != null)
      {
        if (!Pub.IsNumeric(txtRecordInterval.Text.Trim()))
        {
          txtRecordInterval.Focus();
          Pub.MessageBoxShow(Pub.GetResText(formCode, "Error005", ""));
          return false;
        }
        if (!Pub.IsNumeric(txtLeastWorkMin.Text.Trim()))
        {
          txtLeastWorkMin.Focus();
          Pub.MessageBoxShow(Pub.GetResText(formCode, "Error006", ""));
          return false;
        }
        if (!Pub.IsNumeric(txtLeastOtMin.Text.Trim()))
        {
          txtLeastOtMin.Focus();
          Pub.MessageBoxShow(Pub.GetResText(formCode, "Error007", ""));
          return false;
        }
        if (!Pub.IsNumeric(txtResultDecimalPlaces.Text.Trim()))
        {
          txtResultDecimalPlaces.Focus();
          Pub.MessageBoxShow(Pub.GetResText(formCode, "Error008", ""));
          return false;
        }
      }
      return true;
    }

    public bool CheckSFParam()
    {
      if (tabControl1.TabPages[tabPage5.Name] != null)
      {
        SFBtBagFlag = 0;
        if (radioButton2.Checked) SFBtBagFlag = 1;
        if (radioButton3.Checked) SFBtBagFlag = 2;
        if (txtSFBtBagDate.Enabled)
        {
          if (SFBtBagFlag == 0)
          {
            if (!Pub.IsNumeric(txtSFBtBagDate.Text.Trim()))
            {
              txtSFBtBagDate.Focus();
              Pub.MessageBoxShow(Pub.GetResText(formCode, "Error009", ""));
              return false;
            }
            SFBtBagDate = Convert.ToByte(txtSFBtBagDate.Text.Trim());
            if (SFBtBagDate > 255)
            {
              txtSFBtBagDate.Focus();
              Pub.MessageBoxShow(Pub.GetResText(formCode, "Error009", ""));
              return false;
            }
          }
          else if (SFBtBagFlag == 1)
          {
            if (!Pub.IsNumeric(txtSFBtBagDate.Text.Trim()))
            {
              txtSFBtBagDate.Focus();
              Pub.MessageBoxShow(Pub.GetResText(formCode, "Error010", ""));
              return false;
            }
            SFBtBagDate = Convert.ToByte(txtSFBtBagDate.Text.Trim());
            if (SFBtBagDate > 31)
            {
              txtSFBtBagDate.Focus();
              Pub.MessageBoxShow(Pub.GetResText(formCode, "Error010", ""));
              return false;
            }
          }
          else
          {
            if (!Pub.IsNumeric(txtSFBtBagDate.Text.Trim()))
            {
              txtSFBtBagDate.Focus();
              Pub.MessageBoxShow(Pub.GetResText(formCode, "Error012", ""));
              return false;
            }
            SFBtBagDate = Convert.ToByte(txtSFBtBagDate.Text.Trim());
            if (SFBtBagDate < 1 || SFBtBagDate > 12)
            {
              txtSFBtBagDate.Focus();
              Pub.MessageBoxShow(Pub.GetResText(formCode, "Error012", ""));
              return false;
            }
          }
        }
      }
      return true;
    }

    private void frmSYOption_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Control && e.Alt)
      {
        switch (e.KeyCode)
        {
          case Keys.C:
            if (btnLoadKey.Enabled)
            {
              frmSYCustomersCode frm = new frmSYCustomersCode();
              frm.ShowDialog();
            }
            break;
        }
      }
    }

    private void chkExtScreen_CheckedChanged(object sender, EventArgs e)
    {
      btnDispSetup.Enabled = chkExtScreen.Checked;
    }

    private void btnDispSetup_Click(object sender, EventArgs e)
    {
      DeviceObject.objApp.DispSetup(SystemInfo.MainHandle.ToInt32());
    }
  }
}