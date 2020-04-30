using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ECard78
{
    public partial class frmDBMain : frmBaseForm
    {
        private void AddToolbarItem(ToolStripMenuItem menuItem, EventHandler onClick, bool IsContext)
        {
            ToolStripItem item;

            if (menuItem == null)
                ToolBar.Items.Add(new ToolStripSeparator());
            else
            {
                item = ToolBar.Items.Add(menuItem.Text, menuItem.Image, onClick);
                item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                item.TextImageRelation = TextImageRelation.ImageAboveText;
            }
            if (IsContext)
            {
                if (menuItem == null)
                    contextMenu.Items.Add(new ToolStripSeparator());
                else
                {
                    contextMenu.Items.Add(menuItem.Text, menuItem.Image, onClick);
                }
            }
        }

        protected override void InitForm()
        {
            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            formCode = "DBMain";
            bool Has = SystemInfo.DBType != 0;
            base.InitForm();
            this.Left = rect.Left;
            this.Top = rect.Top;
            this.Width = rect.Width;
            this.Height = rect.Height;
            this.WindowState = FormWindowState.Maximized;
            this.Text = SystemInfo.AppTitle + " - " + this.Text;
            mnuLine2.Visible = Has;
            mnuAuto.Visible = Has;
            mnuCompact.Visible = Has;
            ToolBar.Items.Clear();
            contextMenu.Items.Clear();
            AddToolbarItem(mnuPassword, mnuPassword_Click, false);
            AddToolbarItem(mnuExit, mnuExit_Click, false);
            AddToolbarItem(null, null, false);
            AddToolbarItem(mnuNewAccount, mnuNewAccount_Click, true);
            AddToolbarItem(mnuDelAccount, mnuDelAccount_Click, true);
            AddToolbarItem(null, null, true);
            AddToolbarItem(mnuBack, mnuBack_Click, true);
            AddToolbarItem(mnuRest, mnuRest_Click, true);
            AddToolbarItem(mnuUpdate, mnuUpdate_Click, true);
            AddToolbarItem(null, null, true);
            AddToolbarItem(mnuAuto, mnuAuto_Click, true);
            AddToolbarItem(mnuCompact, mnuCompact_Click, true);
            ToolBar.Items[9].Visible = Has;
            ToolBar.Items[10].Visible = Has;
            ToolBar.Items[11].Visible = Has;
            contextMenu.Items[6].Visible = Has;
            contextMenu.Items[7].Visible = Has;
            contextMenu.Items[8].Visible = Has;
            LoadData();
        }

        public frmDBMain()
        {
            InitializeComponent();
        }

        private void frmDBMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Pub.MessageBoxShowQuestion(string.Format(Pub.GetResText(formCode, "MsgExitSystem", ""), this.Text)))
            {
                e.Cancel = true;
            }
        }

        private void frmDBMain_Resize(object sender, EventArgs e)
        {
            ChangeListViewWidth();
        }

        private void mnuPassword_Click(object sender, EventArgs e)
        {
            new frmDBPassword().ShowDialog();
            formCode = "DBMain";
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuNewAccount_Click(object sender, EventArgs e)
        {
            frmNewAccount frm = new frmNewAccount();

            if (frm.ShowDialog() == DialogResult.OK) LoadData();
            formCode = "DBMain";
        }

        private void mnuDelAccount_Click(object sender, EventArgs e)
        {

            string AccName = GetSelectAccName().ToString();
            string DBName = GetSelectDBName().ToString();
            frmDelAccount frm = new frmDelAccount();

            frm.AccName = AccName;
            frm.DBName = DBName;
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
            formCode = "DBMain";

        }

        private void mnuBack_Click(object sender, EventArgs e)
        {

            string AccName = GetSelectAccName().ToString();
            string DBName = GetSelectDBName().ToString();
            frmDBBack frm = new frmDBBack();

            frm.AccName = AccName;
            frm.DBName = DBName;
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
            formCode = "DBMain";

        }

        private void mnuRest_Click(object sender, EventArgs e)
        {

            string AccName = GetSelectAccName().ToString();
            string DBName = GetSelectDBName().ToString();
            frmDBRest frm = null;
            frmDBRestPWD frmPWD = new frmDBRestPWD(mnuRest.Text);

            if (frmPWD.ShowDialog() == DialogResult.OK)
            {
                frm = new frmDBRest();
                frm.AccName = AccName;
                frm.DBName = DBName;
                if (frm.ShowDialog() == DialogResult.OK) LoadData();
            }
            formCode = "DBMain";

        }

        private void mnuUpdate_Click(object sender, EventArgs e)
        {

            string AccName = GetSelectAccName().ToString();
            string DBName = GetSelectDBName().ToString();
            frmDBUpdate frm = new frmDBUpdate();

            frm.AccName = AccName;
            frm.DBName = DBName;
            if (frm.ShowDialog() == DialogResult.OK) LoadData();
            formCode = "DBMain";

        }

        private void mnuAuto_Click(object sender, EventArgs e)
        {
            string AccName = GetSelectAccName().ToString();
            string DBName = GetSelectDBName().ToString();
            frmDBAuto frm = new frmDBAuto();

            frm.AccName = AccName;
            frm.DBName = DBName;
            frm.ShowDialog();
            formCode = "DBMain";

        }

        private void mnuCompact_Click(object sender, EventArgs e)
        {
            string AccName = GetSelectAccName().ToString();
            string DBName = GetSelectDBName().ToString();

            if (DBName == "") return;
            if (Pub.ShowMessageDialog(string.Format(Pub.GetResText(formCode, "Msg001", ""), AccName), "CompactDB", new string[] { DBName }))
            {
                LoadData();
                Pub.MessageBoxShow(string.Format(Pub.GetResText(formCode, "Msg002", ""), AccName), MessageBoxIcon.Information);
            }
            formCode = "DBMain";

        }

        private void dataGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            switch (e.Column.Index)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    ChangeListViewWidth();
                    break;
            }
        }

        private void ChangeListViewWidth()
        {
            int w = this.dataGrid.Width;

            for (int i = 0; i < dataGrid.ColumnCount - 1; i++)
            {
                w = w - dataGrid.Columns[i].Width;
            }
            dataGrid.Columns[dataGrid.ColumnCount - 1].Width = w - 20;
        }

        private void LoadData()
        {
            formCode = "DBMain";
            string DBName = "";
            string tmp = "";
            string tmp1 = "";
            string Path = "";
            string space = "";
            DateTime dt;
            bool IsFirst;
            Database dbEx = new Database("");
            DataTableReader dr = null;
            DataTableReader drEx = null;
            dataGrid.Rows.Clear();
            bool ReadDBIsFirst = false;
            try
            {
                if (!db.IsOpen) db.Open(SystemInfo.ConnStr);
                dr = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "100" }));
                while (dr.Read())
                {
                    DBName = dr["DBName"].ToString();
                    dataGrid.Rows.Add();
                    dataGrid[0, dataGrid.RowCount - 1].Value = dr["AccName"].ToString();
                    dataGrid[1, dataGrid.RowCount - 1].Value = DBName;
                    dataGrid[2, dataGrid.RowCount - 1].Value = dr["CrtdDay"].ToString();
                    dataGrid[3, dataGrid.RowCount - 1].Value = dr["IsForward"].ToString() == "Y";
                    dataGrid[4, dataGrid.RowCount - 1].Value = dr["BackupDay"].ToString();
                    dataGrid[5, dataGrid.RowCount - 1].Value = dr["RestoreDay"].ToString();
                    dataGrid[6, dataGrid.RowCount - 1].Value = "";
                    tmp = dr["ForwardNote"].ToString();
                    if (tmp != "") tmp = "  [" + tmp + "]";
                    Path = dr["DBPath"].ToString();
                    if (Path == "")
                    {
                        drEx = db.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "101", DBName }));
                        switch (SystemInfo.DBType)
                        {
                            case 1:
                            case 2:
                                if (drEx.Read()) Path = drEx["FileName"].ToString().Trim();
                                break;
                        }
                        if (Path != "") db.ExecSQL(Pub.GetSQL(DBCode.DB_000001, new string[] { "102", Path, DBName }), true);
                    }
                    if (Path != "") Path = GetFileNamePath(Path);
                    IsFirst = true;
                    ReadDBIsFirst = true;
                ContinueConnect:
                    try
                    {
                        if (dbEx.IsOpen) dbEx.Close();
                        dbEx.Open(GetConnStr(DBName));
                        drEx = dbEx.GetDataReader(Pub.GetSQL(DBCode.DB_000001, new string[] { "103" }));
                        if (drEx.Read())
                        {
                            dt = (DateTime)drEx["DbDate"];
                            tmp = Pub.GetResText(formCode, "MsgVer", "") + drEx["DbVersion"].ToString() + "  " +
                              Pub.GetResText(formCode, "MsgDate", "") + dt.ToShortDateString() + tmp;
                            space = dbEx.GetDatabaseSpace(DBName);
                            space = space == "" ? "" : "    (" + space + ")";
                            dataGrid[6, dataGrid.RowCount - 1].Value = tmp + space;
                        }
                    }
                    catch
                    {
                        if (ReadDBIsFirst)
                        {
                            ReadDBIsFirst = false;
                            goto ContinueConnect;
                        }
                        if ((Path != "") && IsFirst)
                        {
                            IsFirst = false;
                            tmp1 = db.AttachDB(Path, DBName);
                            if (tmp1 == "") goto ContinueConnect;
                        }
                    }
                    finally
                    {
                        if (drEx != null) drEx.Close();
                        if (dbEx != null) dbEx.Close();
                    }
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
                if (drEx != null) drEx.Close();
                drEx = null;
                if (dbEx != null) dbEx.Close();
            }
            if (dataGrid.RowCount > 0)
            {
                dataGrid.Rows[0].Selected = true;
            }
            RefreshForm();
            formCode = "DBMain";
        }

        private void RefreshForm()
        {
         
            mnuDelAccount.Enabled = dataGrid.RowCount > 0;
            mnuBack.Enabled = mnuDelAccount.Enabled;
            mnuRest.Enabled = mnuDelAccount.Enabled;
            mnuUpdate.Enabled = mnuDelAccount.Enabled;
            mnuAuto.Enabled = mnuDelAccount.Enabled;
            mnuCompact.Enabled = mnuDelAccount.Enabled;
            ToolBar.Items[4].Enabled = mnuDelAccount.Enabled;
            ToolBar.Items[6].Enabled = mnuDelAccount.Enabled;
            ToolBar.Items[7].Enabled = mnuDelAccount.Enabled;
            ToolBar.Items[8].Enabled = mnuDelAccount.Enabled;
            ToolBar.Items[10].Enabled = mnuDelAccount.Enabled;
            ToolBar.Items[11].Enabled = mnuDelAccount.Enabled;
            contextMenu.Items[1].Enabled = mnuDelAccount.Enabled;
            contextMenu.Items[3].Enabled = mnuDelAccount.Enabled;
            contextMenu.Items[4].Enabled = mnuDelAccount.Enabled;
            contextMenu.Items[5].Enabled = mnuDelAccount.Enabled;
            contextMenu.Items[7].Enabled = mnuDelAccount.Enabled;
            contextMenu.Items[8].Enabled = mnuDelAccount.Enabled;
        }

        private string GetSelectAccName()
        {
            string ret = "";

            if ((dataGrid.SelectedRows.Count == 0) && (dataGrid.RowCount > 0))
            {
                dataGrid.Rows[0].Selected = true;
            }
            if (dataGrid.SelectedRows.Count > 0) ret = dataGrid.SelectedRows[0].Cells[0].Value.ToString();
            return ret;
        }

        private string GetSelectDBName()
        {
            string ret = "";

            if ((dataGrid.SelectedRows.Count == 0) && (dataGrid.RowCount > 0))
            {
                dataGrid.Rows[0].Selected = true;
            }
            if (dataGrid.SelectedRows.Count > 0) ret = dataGrid.SelectedRows[0].Cells[1].Value.ToString();
            return ret;
        }
    }
}