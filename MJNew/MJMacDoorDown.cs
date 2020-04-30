using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    public partial class frmMJMacDoorDown : frmMJMacDoorBase
    {
        private byte DownFlag = 0;
        private string Title = "";
        private string CurrentOprt = "";
        private AccessV2API.TYPE_DoorExpertTiming[] ExpertTiming = new AccessV2API.TYPE_DoorExpertTiming[7];

        protected override void InitForm()
        {
            formCode = "MJMacDoorDown";
            SetToolItemState("ItemEdit", false);
            SetToolItemState("ItemLine2", false);
            SetToolItemState("ItemTAG3", false);
            HideStop = true;
            base.InitForm();
            this.Text = Title + "[" + CurrentOprt + "]";
        }

        public frmMJMacDoorDown(string title, string CurrentTool, byte flag)
        {
            DownFlag = flag;
            Title = title;
            CurrentOprt = CurrentTool;
            InitializeComponent();
        }

        protected override void ExecItemTAG1()
        {
            bool IsError = false;
            DataTableReader dr = null;
            AccessV2API.TYPE_DoorExpertTiming Timing;
            try
            {
                if (DownFlag == 0)
                {
                    dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_003009, new string[] { "100" }));
                    int index = 0;
                    string s = "";
                    while (dr.Read())
                    {
                        Timing = new AccessV2API.TYPE_DoorExpertTiming();
                        Timing.DayOfWeek = (UInt32)index;
                        Timing.TimeBegin = new AccessV2API.SYSTEMTIME[4];
                        Timing.TimeEnd = new AccessV2API.SYSTEMTIME[4];
                        Timing.DoorMode = new UInt32[4];
                        for (int i = 1; i <= 4; i++)
                        {
                            s = dr["BeginTime" + i.ToString()].ToString();
                            if (s.Length == 5)
                            {
                                Timing.TimeBegin[i - 1].wHour = Convert.ToUInt16(s.Substring(0, 2));
                                Timing.TimeBegin[i - 1].wMinute = Convert.ToUInt16(s.Substring(3, 2));
                            }
                            s = dr["EndTime" + i.ToString()].ToString();
                            if (s.Length == 5)
                            {
                                Timing.TimeEnd[i - 1].wHour = Convert.ToUInt16(s.Substring(0, 2));
                                Timing.TimeEnd[i - 1].wMinute = Convert.ToUInt16(s.Substring(3, 2));
                            }
                            UInt32.TryParse(dr["Mode" + i.ToString()].ToString(), out Timing.DoorMode[i - 1]);
                        }
                        ExpertTiming[index] = Timing;
                        index++;                       
                    }
                }

            }
            catch (Exception E)
            {
                IsError = true;
                Pub.ShowErrorMsg(E);
            }
            finally
            {
                if (dr != null) dr.Close();
                dr = null;
            }
            if (IsError) return;
            base.ExecItemTAG1();
            ExecMacDoorOprt(0);
        }

        protected override void ExecItemTAG3()
        {
            base.ExecItemTAG3();
            ExecMacDoorOprt(1);
        }

        protected override bool ExecMacDoorCommand(byte flag, TMJDoorInfo doorInfo, ref string MacMsg)
        {
            bool ret = base.ExecMacDoorCommand(flag, doorInfo, ref MacMsg);
            byte doorID = Convert.ToByte(doorInfo.DoorID);
            switch (flag)
            {
                case 0:
                    if (DownFlag == 0)
                    {
                        AccessV2API.TYPE_DoorBasic basic = new AccessV2API.TYPE_DoorBasic();
                        AccessV2API.TYPE_DoorExpert expert = new AccessV2API.TYPE_DoorExpert();
                        ret = DeviceObject.objMJNew.ReadDoorInfo(doorID, ref basic, ref expert);
                        if (ret)
                        {
                            expert.EnableTiming = 1;
                            expert.ExpertTiming = ExpertTiming;
                            ret = DeviceObject.objMJNew.SetDoorExpertInfo(doorID, expert);
                        }
                    }
                    break;
            }
            return ret;
        }
    }
}