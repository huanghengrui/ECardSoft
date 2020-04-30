using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ECard78
{
    class ShowForms
    {
        private const string formCode = "Main";
        private FuncObject FormsList = new FuncObject();

        private void SubAdd(string Name, byte IsLine)
        {
            FormsList.SubAdd(Name, SystemInfo.res.GetResText(formCode, "mnu" + Name, ""), IsLine);
        }

        public FuncObject GetFormsList()
        {
            FormsList.Name = "SEA";
            FormsList.Text = SystemInfo.res.GetResText(formCode, "mnu" + FormsList.Name, "");
            SubAdd("SeaFaceInfo", 0);
            SubAdd("SeaFaceReal", 0);
            SubAdd("SeaFaceData", 0);
            SubAdd("SeaReportData", 0);
            SubAdd("SeaReportSnapShots", 0);
            SubAdd("SeaPower", 0);
            SubAdd("SeaDoorCondition", 0);
            SubAdd("SeaRealTimeSet", 0);
            SubAdd("SeaSetSound", 0);
            SubAdd("SeaDoorOpen", 0);
            SubAdd("SeaNetParam", 0);
           // SubAdd("SeaUserPwd", 0);
            SubAdd("SeaTemperature", 0);
            return FormsList;
        }

        public Form GetForm(string frmName)
        {
            Form ret = null;
            switch (frmName)
            {
              
                case "SeaFaceInfo":
                    ret = new frmSeaFaceInfo();
                    break;
                case "SeaFaceReal":
                    ret = new frmSeaFaceReal();
                    break;
                case "SeaFaceData":
                    ret = new frmSeaFaceData();
                    break;
                case "SeaReportData":
                    ret = new frmSeaReportData();
                    break;
                case "SeaReportSnapShots":
                    ret = new frmSeaReportSnapShots();
                    break;
                case "SeaPower":
                    ret = new frmSeaPower();
                    break;
                case "SeaRealTimeSet":
                    ShowSeaRealTimeSet();
                    break;
                case "SeaSetSound":
                    ShowSeaSetSound();
                    break;
                case "SeaDoorCondition":
                    ShowSeaDoorCondition();
                    break;
                case "SeaDoorOpen":
                    ShowSeaDoorOpen();
                    break;
                case "SeaNetParam":
                    ShowSeaNetParam();
                    break;
                //case "SeaUserPwd":
                //    ShowSeaUserPwd();
                //    break;
                case "SeaTemperature":
                    ShowSeaTemperature();
                    break;
            }
            return ret;
        }
        public void ShowSeaRealTimeSet()
        {
            frmSeaRealTimeSet frm = new frmSeaRealTimeSet();
            frm.ShowDialog();
        }
        public void ShowSeaSetSound()
        {
            frmSeaSetSound frm = new frmSeaSetSound();
            frm.ShowDialog();
        }
        public void ShowSeaDoorCondition()
        {
            frmSeaDoorCondition frm = new frmSeaDoorCondition();
            frm.ShowDialog();
        }
        private void ShowSeaDoorOpen()
        {
            frmSeaOprt frm = new frmSeaOprt("", "", "", 0, null);
            frm.ShowDialog();
        }
        private void ShowSeaNetParam()
        {
            frmSeaNetParam frm = new frmSeaNetParam();
            frm.ShowDialog();
        }
        private void ShowSeaUserPwd()
        {
            frmSeaUserPwd frm = new frmSeaUserPwd();
            frm.ShowDialog();
        }
        private void ShowSeaTemperature()
        {
            frmSeaTemperature frm = new frmSeaTemperature();
            frm.ShowDialog();
        }
    }
}