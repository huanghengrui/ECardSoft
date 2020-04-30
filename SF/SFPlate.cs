using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmSFPlate : frmBaseMDIChild
    {
        private bool isOpen = false;
        private bool isConnect = false;
        private int infoIndex = 0;
        private string Title = "";
        private string GUID = "";
        private bool isBatch = false;
        private bool isStop = false;
        private bool isHand = false;
        public string readCardNumber= "";
        public string writeReadData = "";
        public int readCardIndex = 0;
        private DataTable dtReal = new DataTable();
        public StringBuilder cardData = new StringBuilder();
        List<string> CardList = new List<string>();
        public delegate void OutDelegate(string text);
        private SerialPort serialPort = null;

        public frmSFPlate(string title, string currentTool, string guid, bool batch)
        {
            Title = title;
            CurrentTool = currentTool;
            GUID = guid;
            isBatch = batch;
            InitializeComponent();
        }

        protected override void InitForm()
        {
            formCode = "SFPlate";

            SetToolItemState("ItemTAG2", true);
            SetToolItemState("ItemTAG3", true);

            SetToolItemState("ItemLine1", false);
            SetToolItemState("ItemAdd", true);
            SetToolItemState("ItemImport", false);
            SetToolItemState("ItemExport", false);
            SetToolItemState("ItemPrint", false);
            SetToolItemState("ItemEdit", false);
            SetToolItemState("ItemDelete", false);
            SetToolItemState("ItemSelect", false);
            SetToolItemState("ItemUnselect", false);
            SetToolItemState("ItemRefresh", false);
            SetToolItemState("ItemZoomIn", false);
            SetToolItemState("ItemZoomOut", false);
            DataTableReader dr = null;
            msgGrid.Columns.Clear();
            AddColumn(msgGrid, 0, "No", false, true, 1, 50);
            AddColumn(msgGrid, 0, "CardNo", false, true, 1, 120);
            AddColumn(msgGrid, 0, "CategoryID", false, true, 1, 60);
            AddColumn(msgGrid, 0, "CategoryName", false, true, 1, 60);
            AddColumn(msgGrid, 0, "ProductsID", false, true, 1, 60);
            AddColumn(msgGrid, 0, "ProductsName", false, true, 1, 60);
            AddColumn(msgGrid, 0, "ProductsMoney", false, true, 1, 60);
            AddColumn(msgGrid, 0, "State", false, true, 1, 150);

            dtReal.Columns.Add("No", typeof(string));
            dtReal.Columns.Add("CardNo", typeof(string));
            dtReal.Columns.Add("CategoryID", typeof(string));
            dtReal.Columns.Add("CategoryName", typeof(string));
            dtReal.Columns.Add("ProductsID", typeof(string));
            dtReal.Columns.Add("ProductsName", typeof(string));
            dtReal.Columns.Add("ProductsMoney", typeof(string));
            dtReal.Columns.Add("State", typeof(string));

            msgGrid.DataSource = dtReal;
            base.InitForm();
            this.Text = Title+"["+ CurrentTool+"]";
           
            List<string> baud = new List<string>();
            string[] sSubKeys = SerialPort.GetPortNames();
          
            cbbSerialPort.DataSource = sSubKeys;
            if (cbbSerialPort.Items.Count > 0)
                cbbSerialPort.SelectedIndex = 0;
            baud.AddRange(new string[] { "19200","38400", "57600", "115200", "230400" });
            cbbBaudRate.DataSource = baud;
            cbbBaudRate.SelectedIndex = 0;
            ItemAdd.Text = Pub.GetResText(formCode, "btnConnectPortOpen", "");
            lbFirmwareVersion.Text ="";
            lbAntennaID.Text = "";
            if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
            dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "4", GUID }));
            if (dr.Read())
            {
                cbbVarieties.Tag = dr["ProductsID"].ToString();
                cbbVarieties.Text = dr["ProductsName"].ToString();
                double d = 0;
                double.TryParse(dr["ProductsPrice"].ToString(), out d);
                cbbMoney.Text = d.ToString("#0.00");
                cbbCategory.Text = dr["CategoryName"].ToString();
                cbbCategory.Tag = dr["CategoryID"].ToString();
            }
            serialPort = new SerialPort();
            refreshForm(false);
            lblRecordState.Visible = false;
        }
        private void refreshForm(bool state)
        {
            ItemTAG1.Enabled = state;
            ItemTAG2.Enabled = state;
            ItemTAG3.Enabled = state;
            ItemTAG4.Enabled = state;
            ItemTAG5.Enabled = state;
            ItemTAG6.Enabled = state;
        }
        protected override void ExecItemAdd()
        {
            base.ExecItemAdd();
            refreshForm(false);
            ItemAdd.Enabled = false;

            if (!isOpen)
            {
                try
                {
                    serialPort.PortName = cbbSerialPort.Text;
                    serialPort.BaudRate = Convert.ToInt32(cbbBaudRate.Text, 10);
                    serialPort.Parity = Parity.Even;
                    serialPort.DataBits = 8;
                    serialPort.StopBits = StopBits.One;
                    serialPort.Encoding = Encoding.UTF8;
                    serialPort.Handshake = Handshake.None;
                   
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                        serialPort.Open();
                    }
                    else
                    {
                        serialPort.Open();   
                    }
                   
                    testConnect();
                    if (!isConnect)
                    {
                        serialPort.Close();     //关闭串口
                        Pub.MessageBoxShow(Pub.GetResText(formCode, "Error02", ""), MessageBoxIcon.Warning);
                        return;
                    }
                  
                    ItemAdd.Text = Pub.GetResText(formCode, "btnConnectPortClose", "");
                    cbbSerialPort.Enabled = false;//关闭使能
                    cbbBaudRate.Enabled = false;
                    isOpen = true;
                    refreshForm(true);
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }
                finally
                {
                    ItemAdd.Enabled = true;
                }
            }
            else
            {
                try
                {
                    serialPort.Close();     //关闭串口
                    ItemAdd.Text = Pub.GetResText(formCode, "btnConnectPortOpen", "");
                    lbFirmwareVersion.Text = "";
                    lbAntennaID.Text = "";
                    cbbSerialPort.Enabled = true;
                    cbbBaudRate.Enabled = true;
                    isOpen = false;
                    isConnect = false;
                    isStop = true;
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }
                finally
                {
                    ItemAdd.Enabled = true;
                }
            }
           
        }

        public void OutFirmwareVersionText(string text)
        {
            if (lbFirmwareVersion.InvokeRequired)
            {
                OutDelegate outdelegate = new OutDelegate(OutFirmwareVersionText);
                this.BeginInvoke(outdelegate, new object[] { text });
                return;
            }
            string[] tmp = text.Split(',');
            lbFirmwareVersion.Text = Pub.GetResText(formCode, "lbFirmwareVersion", "") + tmp[0];
            lbAntennaID.Text = Pub.GetResText(formCode, "lbAntennaID", "") + tmp[1];
        }

        public void GetAllNodes(TreeNodeCollection nodeCollection, List<TreeNode> nodeList)
        {
            foreach (TreeNode itemNode in nodeCollection)
            {
                nodeList.Add(itemNode);
                GetAllNodes(itemNode.Nodes, nodeList);
            }
        }

        public void OuttvInfoText(string text)
        {
            if (msgGrid.InvokeRequired)
            {
                OutDelegate outdelegate = new OutDelegate(OuttvInfoText);
                this.BeginInvoke(outdelegate, new object[] { text });
                return;
            }
            try
            {
                infoIndex = infoIndex + 1;
                DataTableReader dr = null;
                string[] tmp = text.Split(',');
                if (tmp.Length > 4)
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "5", tmp[2], tmp[1] }));
                    if (dr.Read())
                    {
                        dtReal.Rows.Add(new object[] { infoIndex.ToString(), tmp[0],tmp[1], dr["CategoryName"].ToString(),
                             tmp[2],dr["ProductsName"].ToString(),  double.Parse(dr["ProductsPrice"].ToString()).ToString("0.00"),  tmp[4] });
                    }
                    else
                    {
                        dtReal.Rows.Add(new object[] { infoIndex.ToString(), tmp[0],tmp[1], " ",
                             tmp[2]," ",  tmp[3],  tmp[4] });
                    }
                }
                else
                {
                    dtReal.Rows.Add(new object[] { infoIndex, " "," ", " ",
                             " "," ",  " ",  text });
                }

                Application.DoEvents();
            }
            catch(Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
          
        }

        private void post_DataReceived(bool IsRead)
        {
            Thread.Sleep(500);
            int dex = 0;
            int count = 0;
            try
            {
                while (serialPort.IsOpen)
                {
                    Thread.Sleep(200);
                    int bsize = serialPort.BytesToRead;
                    if(bsize == 0)
                    {
                        count++;
                        if (count > 3)
                            break;
                        else
                            continue;
                    }
                    byte[] tmp = new byte[bsize];
                    isConnect = true;
                    serialPort.Read(tmp, 0, bsize);
                    string readData = byteToHexStr(tmp);
                    if (!IsRead) continue;
                    dex = readData.IndexOf("5AA504");
                    if (dex >= 0)
                    {
                        if (readData.Length > 33)
                        {
                            string text = readData.Substring(dex + 9, 24) + "," + readData.Substring(dex + 33, 2);
                            OutFirmwareVersionText(text);
                        }
                    }
                    if (readData.IndexOf("5AA58000") >= 0)
                    {
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error04", ""));
                        return;
                    }
                    else if (readData.IndexOf("5AA58100") >= 0)
                    {
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error05", ""));
                        return;
                    }
                    else if (readData.IndexOf("5AA58200") >= 0)
                    {
                        Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error06", ""));
                        return;
                    }
                }  

            }
            catch(Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
          
        }

        private string getCardNo(string caNo)
        {
            char[] charCard = new char[0];
            charCard = caNo.ToCharArray();
            caNo = charCard[14].ToString() + charCard[15] + charCard[12] +
                charCard[13] + charCard[10] + charCard[11] +
                charCard[8] + charCard[9] + charCard[6] +
                charCard[7] + charCard[4] + charCard[5] +
                charCard[2] + charCard[3] + charCard[0] + charCard[1];
            return caNo;
        }

        private void testConnect()
        {
            if (serialPort.IsOpen)
            {
                Cmd cmd_buffer = new Cmd();
                cmd_buffer.Command1 = "00";
                cmd_buffer.Data1 = "01";
                cmd_buffer.Datalen1 = "01";
                cmd_buffer.Checksum1 = Check_sum(cmd_buffer.Header1.Trim() + " " + cmd_buffer.Command1.Trim() + " " + cmd_buffer.Datalen1.Trim());
                cmd_buffer.Data_checksum1 = DataCheck_sum(cmd_buffer.Data1.Trim());
                byte[] sendData = HexStringToByteArray(cmd_buffer.Buf());
                Thread.Sleep(300);
                serialPort.Write(sendData, 0, sendData.Length);
                post_DataReceived(true);
            }
            else
            {
                Pub.MessageBoxShow(Pub.GetResText(formCode, "Error01", ""), MessageBoxIcon.Error); ;
            }
        }
        private string Check_sum(string str)
        {
            byte[] sendData = HexStringToByteArray(str);
            uint num = 0;
            for (int i = 0; i < sendData.Length; i++)
            {
                num = num + sendData[i];
            }
            str = num.ToString("X4");
            str = str.Substring(2);
            return str;
        }

        private string DataCheck_sum(string str)
        {
            byte[] sendData = HexStringToByteArray(str);
            uint num = 0;
            for (int i = 0; i < sendData.Length; i++)
            {
                num = num + sendData[i];
            }
            str = Convert.ToString(num, 16);
            if (str.Length > 2)
                str = str.Substring(1);
            else if (str.Length < 2)
                str = "0" + str;
            return str;
        }
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        //字节数组转16进制字符串
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
    
        /// <summary>
        /// 获取信息
        /// </summary>
        protected override void ExecItemTAG2()
        {
            base.ExecItemTAG2();
            refreshForm(false);
            byte[] sendData = new byte[0];
            dtReal.Rows.Clear();
            CardList.Clear();
            infoIndex = 0;
            try
            {
                if (serialPort.IsOpen)
                {
                    string cmdStr = "D1 89 31 06 36 56";
                    sendData = HexStringToByteArray(cmdStr);
                    Thread.Sleep(200);
                    serialPort.Write(sendData, 0, sendData.Length);
                    isHand = true;
                    post_GetInfo(true);
                }
                else
                {
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error01", ""), MessageBoxIcon.Error);
                }
                if (CardList.Count <= 0)
                {
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error08", ""), MessageBoxIcon.Error);
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                refreshForm(true);
            }
        }

        private void post_GetInfo(bool IsRead)
        {
            string readData = "";
            cardData = new StringBuilder();
            int index = 0;
            Thread.Sleep(500);
            try
            {
                while (serialPort.IsOpen)
                {
                    Thread.Sleep(200);
                    int bsize = serialPort.BytesToRead;
                    if (bsize <= 0)
                    {
                        index++;
                        if (index > 3) return;
                        continue;
                    }
                    else
                    {
                        byte[] tem = new byte[bsize];
                        serialPort.Read(tem, 0, bsize);
                        readData = byteToHexStr(tem);

                        if (readData.IndexOf("5AA58000") >= 0)
                        {
                            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error04", ""));
                            return;
                        }
                        else if (readData.IndexOf("5AA58100") >= 0)
                        {
                            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error05", ""));
                            return;
                        }
                        else if (readData.IndexOf("5AA58200") >= 0)
                        {
                            Pub.ShowErrorMsg(Pub.GetResText(formCode, "Error06", ""));
                            return;
                        }

                        if (isHand && readData.Length > 3)
                        {
                            if (readData.IndexOf("02") != 0)
                                continue;
                            readCardNumber = readData.Substring(2, 2);
                            readCardIndex = Convert.ToInt32(readCardNumber, 16);
                            
                            isHand = false;
                        }

                        cardData.Append(readData);
                        if (cardData.Length > readCardIndex * 40 && cardData.ToString().Substring(cardData.Length - 2, 2) == "03")
                        {
                            for (int i = 0; i < readCardIndex; i++)
                            {
                                string cardNo = "";
                                cardNo = cardData.ToString().Substring(6 + 40 * i, 16);
                                cardNo = getCardNo(cardNo);
                                if(FindCard(cardNo)) continue;
                                CardList.Add(cardNo);
                                if (!IsRead) continue;
                                string varieties = cardData.ToString().Substring(6 + 16 + 40 * i, 8);//品种
                                string category = cardData.ToString().Substring(6 + 24 + 40 * i, 8);//类别
                                string money = cardData.ToString().Substring(6 + 34 + 40 * i, 6);//金额
                                int num = HexToIntNum(money);
                                int Cat = HexToIntNum(category);
                                int Var = HexToIntNum(varieties);
                                if (Cat > 0 && Var > 0)
                                {
                                    double moneys = (double)num / 100;
                                    OuttvInfoText(cardNo + "," + Cat + "," +
                                            Var + "," + moneys.ToString("#0.00") + "," + " ");
                                }
                                else
                                {
                                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error09", ""), MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }

        }
        /// <summary>
        /// 找卡
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        private bool FindCard(string cardNo)
        {
            for (int i = 0; i < CardList.Count; i++)
            {
                if(cardNo == CardList[i])
                {
                    return true;
                }
            }
            return false;
        }

        private int HexToIntNum(string num)
        {
            int ret = 0;
            try
            {
                ret = int.Parse(num, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        private string getUID(string str)
        {
            char[] msg = str.ToCharArray();
            str = "";
            for (int i = 0; i < msg.Length; i++)
            {
                str = str + msg[i];
                if (i % 2 != 0)
                    str = str + " ";
            }
            return str;
        }
        private string getData(string str)
        {
            byte[] sendData = HexStringToByteArray(str);
            byte[] msg = Add_CRC_code(sendData, sendData.Length);
            str = getUID(byteToHexStr(msg));
            return str;
        }
        private byte[] Add_CRC_code(byte[] cmd_buf, int cmd_len)
        {
            uint current_crc_value;

            current_crc_value = 0xFFFF; 
            for (int i = 0; i < cmd_buf.Length; i++)
            {
                current_crc_value ^= ((uint)cmd_buf[i]);
                for (int j = 0; j < 8; j++)
                {
                    if ((current_crc_value & 0x0001) > 0)
                        current_crc_value = (current_crc_value >> 1) ^ 0x8408;  // x^16 + x^12 + x^5 + 1
                    else
                        current_crc_value = (current_crc_value >> 1);
                }
            }
            byte[] buf = new byte[cmd_len + 2];
            for (int i = 0; i < cmd_len; i++)
            {
                buf[i] = cmd_buf[i];
            }
            current_crc_value = ~current_crc_value;
            buf[cmd_len++] = (byte)(current_crc_value & 0xFF);
            current_crc_value >>= 8;
            buf[cmd_len++] = (byte)(current_crc_value & 0xFF);

            return buf;
        }

        private void frmSFPlate_FormClosing(object sender, FormClosingEventArgs e)
        {
            isStop = true;
            if(serialPort!=null)
                serialPort.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPubSelectCategory frm = new frmPubSelectCategory();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string ID = frm.CategoryID;
                string Name = frm.CategoryName;
                DataTableReader dr = null;
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "110", ID }));
                if(dr.Read())
                {
                    cbbCategory.Tag = ID;
                    cbbCategory.Text = Name;
                    cbbVarieties.Tag = dr["ProductsID"].ToString();
                    cbbVarieties.Text = dr["ProductsName"].ToString();
                    cbbMoney.Text = Convert.ToDouble(dr["ProductsPrice"]).ToString("#0.00");
                }
                else
                {
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error07", ""), MessageBoxIcon.Error); ;
                }
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmPubSelectVarieties frm = new frmPubSelectVarieties(cbbCategory.Tag.ToString());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cbbVarieties.Tag = frm.ProductsID;
                cbbVarieties.Text = frm.ProductsName;
                DataTableReader dr = null;
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_004003, new string[] { "5", cbbVarieties.Tag.ToString(), cbbCategory.Tag.ToString() }));
                if (dr.Read())
                {
                    cbbMoney.Text = Convert.ToDouble(dr["ProductsPrice"]).ToString("#0.00");
                }
            }
        }

        /// <summary>
        /// 写入信息
        /// </summary>
        protected override void ExecItemTAG3()
        {
            base.ExecItemTAG3();
            refreshForm(false);
            DateTime StartTime = DateTime.Now;
            RefreshMsg(ItemTAG5.Text);
            byte[] sendData = new byte[0];
            string info = "";
            string Category = "01";
            string CardNo = "";
            string Varieties = "01";
            string Money = "0.00";
            string CategoryName = "01";
            string VarietiesName = "01";
            isStop = false;
            infoIndex = 0;
            try
            {
                if (serialPort.IsOpen)
                {
                    string cmdStr = "D1 89 31 06 36 56";
                    sendData = HexStringToByteArray(cmdStr);
                    Thread.Sleep(300);
                    serialPort.Write(sendData, 0, sendData.Length);
                    isHand = true;
                    CardList.Clear();
                    post_GetInfo(false);
                }
                else
                {
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error01", ""), MessageBoxIcon.Error);
                }

                if (CardList.Count <= 0)
                {
                    Pub.MessageBoxShow(Pub.GetResText(formCode, "Error08", ""), MessageBoxIcon.Error);
                }
                dtReal.Rows.Clear();
                for (int a = 0; a < CardList.Count; a++)
                {
                    if (isStop)
                    {
                        break;
                    }
                    if (serialPort.IsOpen)
                    {
                        writeReadData = "";
                        CardNo = CardList[a].ToString();

                        Varieties = cbbVarieties.Tag.ToString();
                        double d = 0;
                        double.TryParse(cbbMoney.Text.Trim(), out d);
                        Money = d.ToString("#0.00");
                        Category = cbbCategory.Tag.ToString();
                        CategoryName = cbbCategory.Text.Trim();
                        VarietiesName = cbbVarieties.Text.Trim();

                        for (int i = 1; i < 3; i++)
                        {
                            if (isStop)
                            {
                                break;
                            }
                            string UID = getUID(getCardNo(CardNo));
                            string blockNumber = i.ToString("X2");
                            string data = "";
                            switch (i)
                            {
                                case (int)CardSector.SectorOne:
                                    data = Convert.ToInt32(Varieties).ToString("X8");
                                    break;
                                case (int)CardSector.SectorTwo:
                                    data = Convert.ToInt32(Category).ToString("X8");
                                    break;
                                case (int)CardSector.SectorTree:
                                    data = 0.ToString("X2") + ((int)(Convert.ToDouble(Money) * 100)).ToString("X6");
                                    break;
                            }
                            data = getUID(data);
                            Cmd cmd_buffer = new Cmd();
                            cmd_buffer.Command1 = "06";
                            cmd_buffer.Data1 = getData("23 21 " + UID + " " + blockNumber + " " + data);
                           
                            string tmp = cmd_buffer.Data1.Replace(" ", "");
                            cmd_buffer.Datalen1 = (tmp.Length / 2).ToString("X2");

                            cmd_buffer.Checksum1 = Check_sum(cmd_buffer.Header1.Trim() + " " + cmd_buffer.Command1.Trim() + " " + cmd_buffer.Datalen1.Trim());
                            cmd_buffer.Data_checksum1 = DataCheck_sum(cmd_buffer.Data1.Trim());
                            string mag = cmd_buffer.Buf();
                            sendData = HexStringToByteArray(mag);
                            
                            Thread.Sleep(300);
                            serialPort.Write(sendData, 0, sendData.Length);
                        }
                        
                    }
                    else
                    {
                        Pub.MessageBoxShow(Pub.GetResText(formCode, "Error01", ""), MessageBoxIcon.Error); ;

                    }
                   
                    progBar.Value = (a + 1) * 100 / CardList.Count;
                    lblMsg.Text = ItemTAG5.Text + " " + (a + 1).ToString() + " / " + CardList.Count + " "+ CardNo + "["+ CategoryName + "]" + "[" + VarietiesName + "]";
                    Application.DoEvents();
                }
                post_DataReceived(false);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                RefreshMsg(Pub.GetDateDiffTimes(StartTime, DateTime.Now, true), true);
                refreshForm(true);
            }
            ExecItemTAG2();
            if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
            db.WriteSYLog(this.Text, CurrentTool, info);
        }

        protected override void ExecItemTAG6()
        {
            base.ExecItemTAG6();
            dtReal.Rows.Clear();
            isStop = true;
            Application.DoEvents();
        }

        private void msgGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }

    enum CardSector
    {
       SectorOne=1,
       SectorTwo=2,
       SectorTree=3
    }

    class Cmd
    {
        private string Header = "55 AA";
        private string Command = "00";
        private string Datalen = "00";
        private string Checksum = "00";
        private string Data = "00";
        private string Data_checksum = "00";

        public string Header1 { get => Header; }
        public string Command1 { get => Command; set => Command = value; }
        public string Datalen1 { get => Datalen; set => Datalen = value; }
        public string Checksum1 { get => Checksum; set => Checksum = value; }
        public string Data1 { get => Data; set => Data = value; }
        public string Data_checksum1 { get => Data_checksum; set => Data_checksum = value; }

        public string Buf()
        {
            string str = Header1.Trim() + " " + Command1.Trim() + " " + Datalen1.Trim() + " " + Checksum1.Trim() + " " + Data1.Trim() + " " + Data_checksum1.Trim();
            str = str.ToUpper();
            return str;
        }
    }
}
