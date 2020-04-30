using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace ECard78
{
    public partial class frmAppMain : frmBaseForm
    {
        Assembly objRS = null;
        Type tpRS = null;
        Assembly objRSReport = null;
        Type tpRSReport = null;
        Assembly objKQ = null;
        Type tpKQ = null;
        Assembly objKQReport = null;
        Type tpKQReport = null;
        Assembly objMJ = null;
        Type tpMJ = null;
        Assembly objMJReport = null;
        Type tpMJReport = null;
        Assembly objSF = null;
        Type tpSF = null;
        Assembly objSFReport = null;
        Type tpSFReport = null;
        Assembly objSK = null;
        Type tpSK = null;
        Assembly objSKReport = null;
        Type tpSKReport = null;
        Assembly objSEA = null;
        Type tpSEA = null;
        Assembly objSEAReport = null;
        Type tpSEAReport = null;

        private static string MDICaption = "";
        private bool RegisterExit = false;
        private string LocalFormat = "";
        private string MobileStatusText = "";
        private string MobileStatusTextOld = "";

        private void LoadDll(ref Assembly obj, ref Type tp, string DllName, ref int itemIndex, System.EventHandler clickEvent)
        {
            LoadDll(ref obj, ref tp, DllName, ref itemIndex, clickEvent, true);
        }

        private void LoadDll(ref Assembly obj, ref Type tp, string DllName, ref int itemIndex,
          System.EventHandler clickEvent, bool NewFunc)
        {
            string FileName = SystemInfo.AppPath + DllName;
            FuncObject funcObj;
            FuncSubObject funcSubObj;
            ToolStripMenuItem item;
            ToolStripMenuItem itemSub;
            ToolStripMenuItem itemSubEx;
            obj = null;
            if (File.Exists(FileName))
            {
                try
                {
                    obj = Assembly.LoadFile(FileName);
                    if (obj.GetTypes().Length > 0)
                    {
                        tp = obj.GetType("ECard78.ShowForms");
                        if (tp != null)
                        {
                            Object objX = tp.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic |
                              BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);
                            funcObj = (FuncObject)tp.InvokeMember("GetFormsList", BindingFlags.DeclaredOnly | BindingFlags.Public |
                              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, objX, null);
                            if (NewFunc)
                            {
                                SystemInfo.funcList.Add(funcObj);
                                item = new ToolStripMenuItem(funcObj.Text);
                                item.Name = "mnu" + funcObj.Name;
                            }
                            else
                            {
                                ToolStripItem[] Find = MenuBar.Items.Find("mnu" + funcObj.Name, false);
                                item = (ToolStripMenuItem)Find[0];
                            }
                            itemSubEx = null;
                            for (int i = 0; i < funcObj.SubCount; i++)
                            {
                                funcSubObj = funcObj.SubGet(i);
                                if (funcSubObj.IsLine == 2)
                                {
                                    if (itemSubEx != null)
                                    {
                                        item.DropDownItems.Add(itemSubEx);
                                        itemSubEx = null;
                                    }
                                    itemSubEx = new ToolStripMenuItem(funcSubObj.Text);
                                    itemSubEx.Name = "mnu" + funcSubObj.Name;
                                    if (item.DropDownItems.Count > 0) item.DropDownItems.Add(new ToolStripSeparator());
                                    continue;
                                }
                                else if ((funcSubObj.IsLine == 3) || (funcSubObj.IsLine == 4))
                                {
                                    itemSub = new ToolStripMenuItem(funcSubObj.Text);
                                    itemSub.Name = "mnu" + funcSubObj.Name;
                                    itemSub.Click += clickEvent;
                                    itemSub.Tag = funcSubObj.Name;
                                    if (funcSubObj.IsLine == 4) itemSubEx.DropDownItems.Add(new ToolStripSeparator());
                                    itemSubEx.DropDownItems.Add(itemSub);
                                    continue;
                                }
                                if (itemSubEx != null)
                                {
                                    item.DropDownItems.Add(itemSubEx);
                                    itemSubEx = null;
                                }
                                itemSub = new ToolStripMenuItem(funcSubObj.Text);
                                itemSub.Name = "mnu" + funcSubObj.Name;
                                itemSub.Click += clickEvent;
                                itemSub.Tag = funcSubObj.Name;
                                if (funcSubObj.IsLine == 1) item.DropDownItems.Add(new ToolStripSeparator());
                                item.DropDownItems.Add(itemSub);
                            }
                            if (itemSubEx != null)
                            {
                                item.DropDownItems.Add(itemSubEx);
                                itemSubEx = null;
                            }
                            item.Tag = "1";
                            if (NewFunc)
                            {
                                MenuBar.Items.Insert(itemIndex, item);
                                itemIndex += 1;
                            }
                        }
                    }
                }
                catch (Exception E)
                {
                    Pub.ShowErrorMsg(E);
                }
            }
        }

        private bool ShowDllForm(Type tp, string frmName, string frmText)
        {
          
            bool ret = false;
            Form frm = null;
            if (tp == null) return false;
            try
            {
                Object objX = tp.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic |
                  BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);
                frm = (Form)tp.InvokeMember("GetForm", BindingFlags.DeclaredOnly | BindingFlags.Public |
                  BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, objX, new object[] { frmName });
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            if (frm != null)
            {
                ret = true;
                ((frmBaseMDIChild)frm).OnFormMinSize += new frmBaseMDIChild.FormMinSize(frmMain_OnFormMinSize);
                ShowMDIForm(frm, frmText);
            }
            return ret;
        }

        private byte KQFlag(Assembly obj, Type tp)
        {
            
            byte ret = 0;
            if ((obj == null) || (tp == null)) return 0;
            try
            {
                Object objX = tp.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic |
                  BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);
                ret = (byte)tp.InvokeMember("KQFlag", BindingFlags.DeclaredOnly | BindingFlags.Public |
                  BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, objX, null);
            }
            catch
            {
            }
            return ret;
        }

        private bool MJIsNew(Assembly obj, Type tp)
        {
            
            bool ret = false;
            if ((obj == null) || (tp == null)) return false;
            try
            {
                Object objX = tp.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic |
                  BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);
                ret = (bool)tp.InvokeMember("MJIsNew", BindingFlags.DeclaredOnly | BindingFlags.Public |
                  BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, objX, null);
            }
            catch
            {
            }
            return ret;
        }

        private string GetDllName(Assembly obj, Type tp)
        {
           
            string ret = "";
            if ((obj == null) || (tp == null)) return "";
            try
            {
                Object objX = tp.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic |
                  BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);
                ret = (string)tp.InvokeMember("GetDllName", BindingFlags.DeclaredOnly | BindingFlags.Public |
                  BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, objX, null);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
            return ret;
        }

        private void AddToolbarButton(string text, Image image, EventHandler onClick)
        {
            ToolBar.Items.Add(text, image, onClick);
            ToolBar.Items[ToolBar.Items.Count - 1].DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            ToolBar.Items[ToolBar.Items.Count - 1].TextImageRelation = TextImageRelation.ImageAboveText;
        }

        private void AddToolbarSeparator()
        {
            ToolBar.Items.Add(new ToolStripSeparator());
        }

        protected override void InitForm()
        {
            Pub.SetFormAppIcon(this);
            System.Globalization.DateTimeFormatInfo fmtInfo = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
            LocalFormat = "dddd  " + fmtInfo.LongDatePattern + " " + fmtInfo.LongTimePattern;
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            formCode = "Main";
            base.InitForm();
            MDICaption = SystemInfo.AppTitle + " " + SystemInfo.AppVersion;
            if (SystemInfo.CustomerName != "") MDICaption = MDICaption + "[" + SystemInfo.CustomerName + "]";
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Width = rect.Width;
            this.Height = rect.Height;
            this.WindowState = FormWindowState.Maximized;
            this.Text = SystemInfo.AppTitle;
            SystemInfo.SystemIsExit = false;
            SystemInfo.MainHandle = this.Handle;
            lblUser.Text = lblUser.Text + OprtInfo.OprtNoAndName;
            lblAcc.Text = lblAcc.Text + SystemInfo.AccDBName;
            if (SystemInfo.AccDBName != SystemInfo.DatabaseName) lblAcc.Text = lblAcc.Text + "[" + SystemInfo.DatabaseName + "]";
            SystemInfo.funcList.Clear();
            int itemIndex = 1;
            LoadDll(ref objRS, ref tpRS, "ECard78.RS.dll", ref itemIndex, mnuRS_Click);
            LoadDll(ref objKQ, ref tpKQ, "ECard78.KQ.dll", ref itemIndex, mnuKQ_Click);
            LoadDll(ref objMJ, ref tpMJ, "ECard78.MJNew.dll", ref itemIndex, mnuMJ_Click);
            if (objMJ == null || tpMJ == null) LoadDll(ref objMJ, ref tpMJ, "ECard78.MJ.dll", ref itemIndex, mnuMJ_Click);
            SystemInfo.IsNewMJ = MJIsNew(objMJ, tpMJ);
            LoadDll(ref objSF, ref tpSF, "ECard78.SF.dll", ref itemIndex, mnuSF_Click);
            LoadDll(ref objSK, ref tpSK, "ECard78.SK.dll", ref itemIndex, mnuSK_Click);
            LoadDll(ref objSEA, ref tpSEA, "ECard78.SEA.dll", ref itemIndex, mnuSEA_Click);
            SystemInfo.HasRS = (objRS != null) && (tpRS != null);
            SystemInfo.HasKQ = (objKQ != null) && (tpKQ != null);
            SystemInfo.HasMJ = (objMJ != null) && (tpMJ != null);
            SystemInfo.HasSF = (objSF != null) && (tpSF != null);
            SystemInfo.HasSK = (objSK != null) && (tpSK != null);
            SystemInfo.HasSEA = (objSEA != null) && (tpSEA != null);
            SystemInfo.KQFlag = KQFlag(objKQ, tpKQ);
            if (SystemInfo.HasRS)
            {
                LoadDll(ref objRSReport, ref tpRSReport, "RSReport.dll", ref itemIndex, mnuRSReport_Click, false);
            }
            if (SystemInfo.HasKQ)
            {
                LoadDll(ref objKQReport, ref tpKQReport, "KQReport.dll", ref itemIndex, mnuKQReport_Click, false);
            }
            if (SystemInfo.HasMJ)
            {
                LoadDll(ref objMJReport, ref tpMJReport, "MJReport.dll", ref itemIndex, mnuMJReport_Click, false);
            }
            if (SystemInfo.HasSF)
            {
                LoadDll(ref objSFReport, ref tpSFReport, "SFReport.dll", ref itemIndex, mnuSFReport_Click, false);
            }
            if (SystemInfo.HasSK)
            {
                LoadDll(ref objSKReport, ref tpSKReport, "SKReport.dll", ref itemIndex, mnuSKReport_Click, false);
            }
            if (SystemInfo.HasSEA)
            {
                LoadDll(ref objSEAReport, ref tpSEAReport, "SEAReport.dll", ref itemIndex, mnuSEAReport_Click, false);
            }
            SystemInfo.HasFaCard = false;
            if ((SystemInfo.HasKQ && ((SystemInfo.KQFlag == 0) || (SystemInfo.KQFlag == 2))) || SystemInfo.HasSF || SystemInfo.HasSK)
                SystemInfo.HasFaCard = true;
            ToolBar.Items.Clear();
            AddToolbarButton(mnuWindowClose.Text, mnuWindowClose.Image, mnuWindowClose_Click);
            AddToolbarSeparator();
            AddToolbarButton(mnuSYClose.Text, mnuSYClose.Image, mnuSYClose_Click);
            string dllName = "";
            System.Collections.ArrayList objList = new System.Collections.ArrayList();
            System.Collections.ArrayList tpList = new System.Collections.ArrayList();
            System.Collections.ArrayList naList = new System.Collections.ArrayList();
            Assembly obj;
            Type tp;
            string na;
            for (int i = 1; i <= 10; i++)
            {
                dllName = SystemInfo.ini.ReadIni("ExtDll", i.ToString(), "");
                if (dllName == "") continue;
                if (!File.Exists(SystemInfo.AppPath + dllName)) continue;
                obj = null;
                tp = null;
                LoadDll(ref obj, ref tp, dllName, ref itemIndex, mnuExt_Click);
                na = GetDllName(obj, tp);
                objList.Add(obj);
                tpList.Add(tp);
                naList.Add(na);
            }
            ExtModuleInfo.objDll = new Assembly[objList.Count];
            ExtModuleInfo.tpDll = new Type[objList.Count];
            ExtModuleInfo.homeName = new string[objList.Count];
            for (int i = 0; i < objList.Count; i++)
            {
                ExtModuleInfo.objDll[i] = (Assembly)objList[i];
                ExtModuleInfo.tpDll[i] = (Type)tpList[i];
                ExtModuleInfo.homeName[i] = (string)naList[i];
            }
            ShowMDIForm(new frmMainHome());
            db.SetConnStr(SystemInfo.ConnStr);
            RegisterInfo.Serial = db.GetRegSerial();
            RegisterInfo.EmpCount = db.GetEmpCount();
            RegisterInfo.ModuleCount = 0;
            if (SystemInfo.HasKQ) RegisterInfo.ModuleCount += 1;
            if (SystemInfo.HasMJ) RegisterInfo.ModuleCount += 1;
            if (SystemInfo.HasSF) RegisterInfo.ModuleCount += 1;
            if (SystemInfo.HasSK) RegisterInfo.ModuleCount += 1;
            if (SystemInfo.HasSEA) RegisterInfo.ModuleCount += 1;
            if (ExtModuleInfo.objDll != null) RegisterInfo.ModuleCount += ExtModuleInfo.objDll.Length;
            RegisterInfo.MustReg = db.ReadConfig("SystemRegister", "MustReg", false);
            if (SystemInfo.DBType == 1)
            {
                Database dbSerial = new Database(GetConnStrSystem());
                try
                {
                    if (!dbSerial.IsOpen) dbSerial.Open();
                    string tmpSerial = dbSerial.GetDBServerSerial();
                    if (tmpSerial != "") RegisterInfo.Serial = tmpSerial;
                }
                finally
                {
                    dbSerial.Close();
                }
            }
            RegisterInfo.AllowReg = (RegisterInfo.EmpCount >= 300) || (RegisterInfo.ModuleCount > 1) || RegisterInfo.MustReg;
            if (SystemInfo.IgnoreRegister) RegisterInfo.AllowReg = false;
            if (RegisterInfo.AllowReg) db.IsRegister(true, "", "");
            SetMDICaption();
            if (SystemInfo.HasRS) db.UpdateModuleResources(this.Text, objRS);
            if (SystemInfo.HasKQ) db.UpdateModuleResources(this.Text, objKQ);
            if (SystemInfo.HasMJ) db.UpdateModuleResources(this.Text, objMJ);
            if (SystemInfo.HasSF) db.UpdateModuleResources(this.Text, objSF);
            if (SystemInfo.HasSK) db.UpdateModuleResources(this.Text, objSK);
            if (SystemInfo.HasSEA) db.UpdateModuleResources(this.Text, objSEA);
            if (objRSReport != null) db.UpdateModuleResources(this.Text, objRSReport);
            if (objKQReport != null) db.UpdateModuleResources(this.Text, objKQReport);
            if (objMJReport != null) db.UpdateModuleResources(this.Text, objMJReport);
            if (objSFReport != null) db.UpdateModuleResources(this.Text, objSFReport);
            if (objSKReport != null) db.UpdateModuleResources(this.Text, objSKReport);
            if (objSEAReport != null) db.UpdateModuleResources(this.Text, objSEAReport);
            DataTableReader dr = null;
            try
            {
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000002, new string[] { "2" }));
                if (dr.Read())
                {
                    SystemInfo.AccDBVersion = dr["DbVersion"].ToString() + ".";
                    DateTime dt = Convert.ToDateTime(dr["DbDate"]);
                    SystemInfo.AccDBVersion = SystemInfo.AccDBVersion + dt.ToString("yyyy.MM.dd");
                }
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
        }

        protected override void FreeForm()
        {
            timer.Enabled = false;
            tpRS = null;
            objRS = null;
            tpRSReport = null;
            objRSReport = null;
            tpKQ = null;
            objKQ = null;
            tpKQReport = null;
            objKQReport = null;
            tpMJ = null;
            objMJ = null;
            tpMJReport = null;
            objMJReport = null;
            tpSF = null;
            objSF = null;
            tpSFReport = null;
            objSFReport = null;
            tpSK = null;
            objSK = null;
            tpSKReport = null;
            objSKReport = null;
            tpSEA = null;
            objSEA = null;
            tpSEAReport = null;
            objSEAReport = null;
            if (ExtModuleInfo.objDll != null)
            {
                for (int i = 0; i < ExtModuleInfo.objDll.Length; i++)
                {
                    ExtModuleInfo.tpDll[i] = null;
                    ExtModuleInfo.objDll[i] = null;
                }
            }
            base.FreeForm();
        }

        public frmAppMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (!RegisterExit)
            {
                if (Pub.MessageBoxShowQuestion(string.Format(Pub.GetResText(formCode, "MsgExitSystem", ""), MDICaption)))
                {
                    e.Cancel = true;
                    return;
                }
            }
            SystemInfo.SystemIsExit = true;
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                this.MdiChildren[i].Dispose();
            }
            e.Cancel = false;
            Environment.Exit(0);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
           
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                ResizeMDIForm((Form)this.MdiChildren[i]);
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
           
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                ResizeMDIForm((Form)this.MdiChildren[i]);
            }
            if (RegisterInfo.AllowReg)
            {
                if (RegisterInfo.IsValid || RegisterInfo.IsTest) ShowRegister();
            }
        }

        private void frmMain_OnFormMinSize(object sender, EventArgs e)
        {
           
            Form childForm = (Form)sender;
            if (childForm.Visible == true)
            {
                childForm.Hide();
                ToolStripStatusLabel statusLabel = new ToolStripStatusLabel();
                statusLabel.Text = childForm.Text;
                statusLabel.Tag = childForm;
                statusLabel.BorderSides = ToolStripStatusLabelBorderSides.All;
                statusLabel.BorderStyle = Border3DStyle.RaisedOuter;
                statusLabel.Margin = new Padding(0, 5, 5, 5);
                statusLabel.BackColor = Color.FromArgb(203, 225, 252);
                statusLabel.Click += new EventHandler(statusLabel_Click);
                this.StatusBar.Items.Add(statusLabel);
            }
            frmMain_Resize(null, null);
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {
           
            ToolStripStatusLabel statusLabel = (ToolStripStatusLabel)sender;
            if (statusLabel.Tag != null && statusLabel.Tag is Form)
            {
                Form frm = (Form)statusLabel.Tag;
                frm.WindowState = FormWindowState.Normal;
                string tmp = statusLabel.Text;
                this.StatusBar.Items.Remove(statusLabel);
                statusLabel.Dispose();
                ShowMDIFormEx(frm, tmp);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.lblTime.Text = DateTime.Now.ToString(LocalFormat);
            if (SystemInfo.IgnoreMobile) return;
            try
            {
                string CardID = "";
                if (!DeviceObject.objCard.MobileCheck(ref CardID))
                {
                    MobileStatusText = string.Format(Pub.GetResText(formCode, "MobileCancelOrd", ""), CardID);
                    if (MobileStatusTextOld != MobileStatusText)
                    {
                        SetMDICaption();
                        MobileStatusTextOld = MobileStatusText;
                    }
                    TMobileInfo MobileInfo;
                    MobileInfo = new TMobileInfo("");
                    DeviceObject.objCard.MobileInit(MobileInfo.MobTyp, MobileInfo.MercID, MobileInfo.TrmNo, MobileInfo.PWD,
                      MobileInfo.XJLName, MobileInfo.XJLPWD);
                    string ErrMsg = "";
                    if (DeviceObject.objCard.MobileCancel(ref ErrMsg)) db.MobileCancelOrdSave(CardID, ErrMsg);
                }
                else
                {
                    MobileStatusText = "";
                    if (MobileStatusTextOld != MobileStatusText)
                    {
                        SetMDICaption();
                        MobileStatusTextOld = MobileStatusText;
                    }
                }
            }
            catch
            {
            }
        }

        private void mnuSYPower_Click(object sender, EventArgs e)
        {
           
            ShowSYPower();
        }

        private void mnuSYDevice_Click(object sender, EventArgs e)
        {
          
            ShowSYDevice();
        }

        private void mnuSYOption_Click(object sender, EventArgs e)
        {
           
            ShowSYOption();
        }

        private void mnuSYAuto_Click(object sender, EventArgs e)
        {
           
            ShowSYAuto();
        }

        private void mnuSYPassword_Click(object sender, EventArgs e)
        {
           
            ExecShowFormDialog(new frmSYPassword(((ToolStripMenuItem)(sender)).Text));
        }

        private void mnuSYRegister_Click(object sender, EventArgs e)
        {
            ShowRegister();
        }

        private void mnuSYClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuRS_Click(object sender, EventArgs e)
        {
            
            ShowRS((ToolStripMenuItem)sender);
        }

        private void mnuRSReport_Click(object sender, EventArgs e)
        {
           
            ShowRSReport((ToolStripMenuItem)sender);
        }

        private void mnuKQ_Click(object sender, EventArgs e)
        {
           
            ShowKQ((ToolStripMenuItem)sender);
        }

        private void mnuKQReport_Click(object sender, EventArgs e)
        {
           
            ShowKQReport((ToolStripMenuItem)sender);
        }

        private void mnuMJ_Click(object sender, EventArgs e)
        {
           
            ShowMJ((ToolStripMenuItem)sender);
        }

        private void mnuMJReport_Click(object sender, EventArgs e)
        {
            
            ShowMJReport((ToolStripMenuItem)sender);
        }

        private void mnuSF_Click(object sender, EventArgs e)
        {
           
            ShowSF((ToolStripMenuItem)sender);
        }

        private void mnuSFReport_Click(object sender, EventArgs e)
        {
           
            ShowSFReport((ToolStripMenuItem)sender);
        }

        private void mnuSK_Click(object sender, EventArgs e)
        {
            
            ShowSK((ToolStripMenuItem)sender);
        }

        private void mnuSKReport_Click(object sender, EventArgs e)
        {
           
            ShowSKReport((ToolStripMenuItem)sender);
        }
        private void mnuSEA_Click(object sender, EventArgs e)
        {

            ShowSEA((ToolStripMenuItem)sender);
        }

        private void mnuSEAReport_Click(object sender, EventArgs e)
        {

            ShowSEAReport((ToolStripMenuItem)sender);
        }

        private void mnuExt_Click(object sender, EventArgs e)
        {
          
            ShowExt((ToolStripMenuItem)sender);
        }

        private void NormalAllWindow()
        {
          
            for (int i = this.MdiChildren.Length - 1; i >= 0; i--)
            {
                this.MdiChildren[i].WindowState = FormWindowState.Normal;
            }
        }

        private void mnuWindowCascade_Click(object sender, EventArgs e)
        {
           
            NormalAllWindow();
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuWindowTileHorizontal_Click(object sender, EventArgs e)
        {
           
            NormalAllWindow();
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuWindowTileVertical_Click(object sender, EventArgs e)
        {
           
            NormalAllWindow();
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuWindowClose_Click(object sender, EventArgs e)
        {
           
            if (this.ActiveMdiChild != null) this.ActiveMdiChild.Close();
        }

        private void mnuWindowCloseAll_Click(object sender, EventArgs e)
        {
           
            for (int i = this.MdiChildren.Length - 1; i >= 0; i--)
            {
                this.MdiChildren[i].Close();
            }
            List<ToolStripStatusLabel> lst = new List<ToolStripStatusLabel>();
            ToolStripStatusLabel statusLabel;
            for (int i = 0; i < StatusBar.Items.Count; i++)
            {
                if ((StatusBar.Items[i] is ToolStripStatusLabel) && (StatusBar.Items[i].Tag != null))
                {
                    statusLabel = (ToolStripStatusLabel)StatusBar.Items[i];
                    lst.Add(statusLabel);
                }
            }
            while (lst.Count > 0)
            {
                statusLabel = lst[0];
                this.StatusBar.Items.Remove(statusLabel);
                statusLabel.Dispose();
                lst.RemoveAt(0);
            }
            while (mnuWindowList.DropDownItems.Count > 1)
            {
                mnuWindowList.DropDownItems.RemoveAt(1);
            }
          ((ToolStripMenuItem)mnuWindowList.DropDownItems[0]).Checked = true;
        }

        private void mnuWindowList_Click(object sender, EventArgs e)
        {
           
            ShowWindowList((ToolStripMenuItem)sender);
        }

        private void mnuHelpTopic_Click(object sender, EventArgs e)
        {
          
            string FileName = SystemInfo.AppPath + "help.chm";
            string FileNameDoc = SystemInfo.AppPath + "help.doc";
            try
            {
                if (File.Exists(FileName))
                    System.Diagnostics.Process.Start(FileName);
                else if (File.Exists(FileNameDoc))
                    System.Diagnostics.Process.Start(FileNameDoc);
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
          
            ShowAbout();
        }

        private DialogResult ExecShowFormDialog(Form frm)
        {
            return frm.ShowDialog();
        }

        public void ExecShowForm(string frmName, string frmText)
        {
           
            ToolStripMenuItem item = null;
            for (int i = 0; i < mnuWindowList.DropDownItems.Count; i++)
            {
                ((ToolStripMenuItem)mnuWindowList.DropDownItems[i]).Checked = false;
            }
            for (int i = 0; i < mnuWindowList.DropDownItems.Count; i++)
            {
                if (((ToolStripMenuItem)mnuWindowList.DropDownItems[i]).Name == "mnu" + frmName)
                {
                    item = (ToolStripMenuItem)mnuWindowList.DropDownItems[i];
                    break;
                }
            }
            if (item == null)
            {
                item = new ToolStripMenuItem();
                item.Name = "mnu" + frmName;
                item.Text = frmText;
                item.Click += mnuWindowList_Click;
                mnuWindowList.DropDownItems.Add(item);
            }
            item.Checked = true;
            RefreshState();
        }

        public void ExecFreeForm(string frmName)
        {
          
            for (int i = 0; i < mnuWindowList.DropDownItems.Count; i++)
            {
                if (((ToolStripMenuItem)mnuWindowList.DropDownItems[i]).Name == "mnu" + frmName)
                {
                    mnuWindowList.DropDownItems[i].Dispose();
                    break;
                }
            }
            RefreshState();
        }

        private void SetFormMenuItemText(string frmName, string frmText)
        {
           
            for (int i = 0; i < mnuWindowList.DropDownItems.Count; i++)
            {
                if (((ToolStripMenuItem)mnuWindowList.DropDownItems[i]).Name == "mnu" + frmName)
                {
                    mnuWindowList.DropDownItems[i].Text = frmText;
                    break;
                }
            }
        }

        protected void ShowMDIForm(Form frm)
        {
           
            ShowMDIForm(frm, "");
        }

        protected void ShowMDIForm(Form frm, string frmText)
        {
         
            ShowMDIForm(frm, frmText, false);
        }

        protected void ShowMDIForm(Form frm, string frmText, bool AddMinSizeEvent)
        {
         
            bool isExists = false;
            if (AddMinSizeEvent)
            {
                ((frmBaseMDIChild)frm).OnFormMinSize += new frmBaseMDIChild.FormMinSize(frmMain_OnFormMinSize);
            }
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Name == frm.Name)
                {
                    frm.Dispose();
                    frm = (Form)this.MdiChildren[i];
                    frm.WindowState = FormWindowState.Normal;
                    isExists = true;
                    break;
                }
            }
            ToolStripStatusLabel statusLabel = null;
            if (isExists)
            {
                for (int i = 0; i < StatusBar.Items.Count; i++)
                {
                    if ((StatusBar.Items[i] is ToolStripStatusLabel) && (StatusBar.Items[i].Tag != null) &&
                      (((ToolStripStatusLabel)StatusBar.Items[i]).Tag == frm))
                    {
                        statusLabel = (ToolStripStatusLabel)StatusBar.Items[i];
                    }
                }
            }
            if (statusLabel == null)
                ShowMDIFormEx(frm, frmText);
            else
                statusLabel_Click(statusLabel, null);
        }

        protected void ShowMDIFormEx(Form frm, string frmText)
        {
          
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
            if (frm.Text == "") frm.Text = frmText;
            ResizeMDIForm(frm);
            frm.WindowState = FormWindowState.Maximized;
            SetFormMenuItemText(frm.Name, frm.Text);
            if (frm.Name == "frmMainHome") frm.Text = "";
        }

        protected void ResizeMDIForm(Form frm)
        {
           
            Size s = ClientSize;
            if (frm.WindowState != FormWindowState.Minimized)
            {
                frm.Left = 0;
                frm.Top = 0;
                frm.Width = s.Width - 4;
                frm.Height = s.Height - MenuBar.Height - ToolBar.Height - StatusBar.Height - 4;
            }
        }

        private void RefreshState()
        {
            //mnuWindowClose.Enabled = (this.MdiChildren.Length > 1);
            //mnuWindowCloseAll.Enabled = mnuWindowClose.Enabled;
        }

        private void SetMDICaptionState(ToolStripMenuItem item)
        {
          
            for (int j = 0; j < item.DropDownItems.Count; j++)
            {
                if (!(item.DropDownItems[j] is ToolStripMenuItem)) continue;
                item.DropDownItems[j].Enabled = !RegisterInfo.IsValid;
                SetMDICaptionState((ToolStripMenuItem)item.DropDownItems[j]);
            }
        }

        private void SetMDICaption()
        {
           
            ToolStripMenuItem item;
            this.Text = MDICaption;
            if (RegisterInfo.AllowReg)
            {
                this.Text = MDICaption + " - " + RegisterInfo.StateText;
                for (int i = 0; i < MenuBar.Items.Count; i++)
                {
                    item = (ToolStripMenuItem)MenuBar.Items[i];
                    if ((item.Tag != null) && (item.Tag.ToString() == "1")) SetMDICaptionState(item);
                }
            }
            else
            {
                mnuSYLine3.Visible = false;
                mnuSYRegister.Visible = false;
            }
            if (MobileStatusText != "") this.Text += "    " + MobileStatusText;
        }

        private void ShowSYPower()
        {
          
            if (!db.CheckOprtRole("SYPower", "E", true)) return;
            ShowMDIForm(new frmSYPower(), mnuSYPower.Text, true);
        }

        private void ShowSYDevice()
        {
         
            if (!db.CheckOprtRole("SYDevice", "E", true)) return;
            ShowMDIForm(new frmSYDevice(), mnuSYDevice.Text, true);
        }

        private void ShowSYOption()
        {
            if (!db.CheckOprtRole("SYOption", "E", true)) return;
            ExecShowFormDialog(new frmSYOption(mnuSYOption.Text));
        }

        private void ShowSYAuto()
        {
         
            if (!db.CheckOprtRole("SYAuto", "E", true)) return;
            ShowMDIForm(new frmSYAuto(), mnuSYAuto.Text, true);
        }

        public void ShowRegister()
        {
          
            if (ExecShowFormDialog(new frmSYRegister(mnuSYRegister.Text)) == DialogResult.OK)
            {
                RegisterExit = true;
                SystemInfo.IsRestart = true;
                this.Close();
            }
        }

        private void ShowAbout()
        {
          
            ExecShowFormDialog(new frmAbout(mnuHelpAbout.Text));
        }

        private bool ShowRS(ToolStripMenuItem item)
        {
         
            if (!db.CheckOprtRole(item.Name.Substring(3), "E", true)) return false;
            return ShowDllForm(tpRS, item.Tag.ToString(), item.Text);
        }

        private bool ShowRS(string ItemName)
        {
          
            return ShowDllForm(tpRS, ItemName, "");
        }

        private bool ShowRSReport(ToolStripMenuItem item)
        {
           
            return ShowDllForm(tpRSReport, item.Tag.ToString(), item.Text);
        }

        private bool ShowKQ(ToolStripMenuItem item)
        {
           
            if (!db.CheckOprtRole(item.Name.Substring(3), "E", true)) return false;
            return ShowDllForm(tpKQ, item.Tag.ToString(), item.Text);
        }

        private bool ShowKQ(string ItemName)
        {
            
            return ShowDllForm(tpKQ, ItemName, "");
        }

        private bool ShowKQReport(ToolStripMenuItem item)
        {
           
            return ShowDllForm(tpKQReport, item.Tag.ToString(), item.Text);
        }

        private bool ShowMJ(ToolStripMenuItem item)
        {
           
            if (!db.CheckOprtRole(item.Name.Substring(3), "E", true)) return false;
            return ShowDllForm(tpMJ, item.Tag.ToString(), item.Text);
        }

        private bool ShowMJ(string ItemName)
        {
           
            return ShowDllForm(tpMJ, ItemName, "");
        }

        private bool ShowMJReport(ToolStripMenuItem item)
        {
           
            return ShowDllForm(tpMJReport, item.Tag.ToString(), item.Text);
        }

        private bool ShowSF(ToolStripMenuItem item)
        {
          
            if (!db.CheckOprtRole(item.Name.Substring(3), "E", true)) return false;
            return ShowDllForm(tpSF, item.Tag.ToString(), item.Text);
        }

        private bool ShowSF(string ItemName)
        {
          
            return ShowDllForm(tpSF, ItemName, "");
        }

        private bool ShowSFReport(ToolStripMenuItem item)
        {
           
            return ShowDllForm(tpSFReport, item.Tag.ToString(), item.Text);
        }

        private bool ShowSK(ToolStripMenuItem item)
        {
         
            if (!db.CheckOprtRole(item.Name.Substring(3), "E", true)) return false;
            return ShowDllForm(tpSK, item.Tag.ToString(), item.Text);
        }

        private bool ShowSK(string ItemName)
        {
          
            return ShowDllForm(tpSK, ItemName, "");
        }

        private bool ShowSKReport(ToolStripMenuItem item)
        {
           
            return ShowDllForm(tpSKReport, item.Tag.ToString(), item.Text);
        }

        private bool ShowSEA(ToolStripMenuItem item)
        {

            if (!db.CheckOprtRole(item.Name.Substring(3), "E", true)) return false;
            return ShowDllForm(tpSEA, item.Tag.ToString(), item.Text);
        }

        private bool ShowSEA(string ItemName)
        {

            return ShowDllForm(tpSEA, ItemName, "");
        }

        private bool ShowSEAReport(ToolStripMenuItem item)
        {

            return ShowDllForm(tpSEAReport, item.Tag.ToString(), item.Text);
        }

        private bool ShowExt(ToolStripMenuItem item)
        {
            if (!db.CheckOprtRole(item.Name.Substring(3), "E", true)) return false;
            string tag = item.Tag.ToString();
            string text = item.Text;
            Type tp = null;
            while (item.OwnerItem != null)
            {
                item = (ToolStripMenuItem)item.OwnerItem;
                if (item.OwnerItem == null)
                {
                    string na = item.Name;
                    na = na.Substring(3);
                    for (int i = 0; i < ExtModuleInfo.homeName.Length; i++)
                    {
                        if (ExtModuleInfo.homeName[i] == na)
                        {
                            tp = (Type)ExtModuleInfo.tpDll[i];
                            break;
                        }
                    }
                    break;
                }
            }
           
            return ShowDllForm(tp, tag, text);
        }

        private bool ShowExt(string Module, string ItemName)
        {
            Type tp = null;
            for (int i = 0; i < ExtModuleInfo.homeName.Length; i++)
            {
                if (ExtModuleInfo.homeName[i] == Module)
                {
                    tp = (Type)ExtModuleInfo.tpDll[i];
                    break;
                }
            }
            if (tp == null)
                return false;
            else
                return ShowDllForm(tp, ItemName, "");
        }

        private void ShowWindowList(ToolStripMenuItem item)
        {
            string tmp = item.Name;
            Form frm = null;
            tmp = tmp.Substring(3);
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Name == tmp)
                {
                    frm = (Form)MdiChildren[i];
                    break;
                }
            }
            if (frm != null)
            {
                ToolStripStatusLabel statusLabel = null;
                for (int i = 0; i < StatusBar.Items.Count; i++)
                {
                    if ((StatusBar.Items[i] is ToolStripStatusLabel) && (StatusBar.Items[i].Tag != null) &&
                      (((ToolStripStatusLabel)StatusBar.Items[i]).Tag == frm))
                    {
                        statusLabel = (ToolStripStatusLabel)StatusBar.Items[i];
                    }
                }
                if (statusLabel == null)
                    ShowMDIFormEx(frm, item.Text);
                else
                    statusLabel_Click(statusLabel, null);
            }
       
        }

        private ToolStripMenuItem GetModuleItem(string ModuleName, ref bool state)
        {
            state = false;
            ToolStripMenuItem ret = null;
            ToolStripItem[] FindItem = MenuBar.Items.Find("mnu" + ModuleName, true);
            if (FindItem.Length == 1)
            {
                ret = (ToolStripMenuItem)FindItem[0];
                state = ret.Enabled;
            }
         
            return ret;
        }

        public void ExecRSCardOprter(byte flag)
        {
            if (tpRS == null) return;
            try
            {
                Object objX = tpRS.InvokeMember(null, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic |
                  BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);
                tpRS.InvokeMember("RSCardOprter", BindingFlags.DeclaredOnly | BindingFlags.Public |
                  BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, objX, new object[] { flag });
            }
            catch (Exception E)
            {
                Pub.ShowErrorMsg(E);
            }
       
        }

        public void ExecModule(string ModuleName, string Module)
        {
            ToolStripMenuItem item;
            bool state = false;
            switch (Module.ToUpper())
            {
                case "":
                case "SY":
                    switch (ModuleName)
                    {
                        case "SYPower":
                            ShowSYPower();
                            break;
                        case "SYDevice":
                            ShowSYDevice();
                            break;
                        case "SYOption":
                            ShowSYOption();
                            break;
                        case "SYAuto":
                            ShowSYAuto();
                            break;
                    }
                    break;
                case "RS":
                    item = GetModuleItem(ModuleName, ref state);
                    if (item != null)
                    {
                        if (!state) return;
                        ShowRS(item);
                    }
                    else
                        ShowRS(ModuleName);
                    break;
                case "KQ":
                    item = GetModuleItem(ModuleName, ref state);
                    if (item != null)
                    {
                        if (!state) return;
                        ShowKQ(item);
                    }
                    else
                        ShowKQ(ModuleName);
                    break;
                case "MJ":
                    item = GetModuleItem(ModuleName, ref state);
                    if (item != null)
                    {
                        if (!state) return;
                        ShowMJ(item);
                    }
                    else
                        ShowMJ(ModuleName);
                    break;
                case "SF":
                    item = GetModuleItem(ModuleName, ref state);
                    if (item != null)
                    {
                        if (!state) return;
                        ShowSF(item);
                    }
                    else
                        ShowSF(ModuleName);
                    break;
                case "SK":
                    item = GetModuleItem(ModuleName, ref state);
                    if (item != null)
                    {
                        if (!state) return;
                        ShowSK(item);
                    }
                    else
                        ShowSK(ModuleName);
                    break;
                case "SE":
                    item = GetModuleItem(ModuleName, ref state);
                    if (item != null)
                    {
                        if (!state) return;
                        ShowSEA(item);
                    }
                    else
                        ShowSEA(ModuleName);
                    break;
                case "EXT":
                    switch (ModuleName.ToLower())
                    {
                        case "about":
                            ShowAbout();
                            break;
                        case "exit":
                            this.Close();
                            break;
                    }
                    break;
            }
          
        }

        public void ExecShowReport(Form frm)
        {
            if (frm != null) ShowMDIForm(frm, "");
        }
    }
}