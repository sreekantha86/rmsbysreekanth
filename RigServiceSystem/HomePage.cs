﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using RigRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.RibbonHelpers;

namespace RigServiceSystem
{
    public partial class HomePage : RibbonForm
    {
        private int childFormNumber = 0;

        public HomePage()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            //childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.ShowDialog(this);
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void helpMenu_Click(object sender, EventArgs e)
        {

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rSSDataSet.Resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.rSSDataSet.Resources);
            // TODO: This line of code loads data into the 'rSSDataSet.Appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.rSSDataSet.Appointments);
            this.Text = this.Text + " - " + Program.FinancialYearName;
            toolStripStatusLabel.Text = "User - " + Program.UserName;
                        
            SyncLocalDB.RunWorkerAsync();            
        }
        private void HomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Menu")
                    Application.OpenForms[i].Close();
            } 
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void buyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to Logout?","RSS", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void buyerOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void supplyOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void mRNToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void mRNDirectToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void inspectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void packingSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void despatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cashBankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void payableReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void additionDeductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void stockCreationFromSecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exportBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
        }

        private void stockCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void updateSupplyOrderRefNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void monthlyStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void packedCartonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void duplicationOfRemarkedItemsInPackingSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cartonTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void debitNoteMRNToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cmdUserRole_Click(object sender, EventArgs e)
        {
            UserRoleList obj = new UserRoleList();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void cmdUsers_Click(object sender, EventArgs e)
        {
            UserList obj = new UserList();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void cmdFinancialYear_Click(object sender, EventArgs e)
        {
            FinancialYearList obj = new FinancialYearList();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void cmdRig_Click(object sender, EventArgs e)
        {
            RigList obj = new RigList();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void cmdLocation_Click(object sender, EventArgs e)
        {
            LocationList obj = new LocationList();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void cmdOperationSearch_Click(object sender, EventArgs e)
        {
            Operations obj = new Operations();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void cmdScheduleList_Click(object sender, EventArgs e)
        {
            RunningSchedules obj = new RunningSchedules();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void cmdEquipment_Click(object sender, EventArgs e)
        {
            Equipment obj = new Equipment();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void cmdRigInformation_Click(object sender, EventArgs e)
        {
            RigInformation obj = new RigInformation();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void ribbonButton11_Click(object sender, EventArgs e)
        {
            Workbench obj = new Workbench();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void ribbonButton12_Click(object sender, EventArgs e)
        {
            Equipment obj = new Equipment();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void ribbonButton13_Click(object sender, EventArgs e)
        {
            VendorList obj = new VendorList();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void SyncLocalDB_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while(!SyncLocalDB.CancellationPending)
                {
                    SyncLocalDBRepository repo = new SyncLocalDBRepository();
                    DataSet ds = GetFavorites();
                    SyncLocalDB.ReportProgress(0, ds);
                    repo.SyncCountry();
                    repo.SyncVendorType();
                    repo.SyncVendorMaster();
                    repo.SyncLocation();
                    repo.SyncRigType();                    
                    Thread.Sleep(500);
                }
                e.Cancel = true;
                //SyncLocalDBRepository repo = new SyncLocalDBRepository();
                //repo.SyncCountry();
                //repo.SyncVendorType();
                //repo.SyncVendorMaster();
                //Thread.Sleep(1000);             
            }
            catch(Exception ex)
            {
                SyncLocalDB.CancelAsync();
                MessageBox.Show("Syncing of Local DB failed. Error:" + ex.Message);
            }
        }
        private DataSet GetFavorites()
        {
            UserRepository user = new UserRepository();
            DataSet ds = user.FillFavorites(Program.UserId);
            return ds;
        }

        private void SyncLocalDB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void SyncLocalDB_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!SyncLocalDB.CancellationPending)
            {
                DataSet ds = GetFavorites();
                if (ds.Tables.Count > 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SimpleButton b = new SimpleButton();
                        b.Text = dr["FormTitle"].ToString();
                        b.Tag = dr["FormName"].ToString();
                        b.Width = 100;
                        b.Height = 50;
                        b.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                        b.Click += new System.EventHandler(this.btnFavorite_Click);
                        flowLayoutPanel1.Controls.Add(b);
                    }
                }
            }
        }
        private void btnFavorite_Click(object sender, EventArgs e)
        {
            SimpleButton b = (SimpleButton)sender;
            string form = b.Tag.ToString();
            var page = (Form)Activator.CreateInstance(Type.GetType("RigServiceSystem." + form));
            page.StartPosition = FormStartPosition.CenterScreen;
            page.ShowDialog(this);

        }
        private void gridFavorites_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                string form = view.GetRowCellValue(info.RowHandle, "FormName").ToString();
                var page = (Form)Activator.CreateInstance(Type.GetType("RigServiceSystem." + form));
                page.ShowDialog(this);
            }
        }

        private void cmdRigLocationMap_Click(object sender, EventArgs e)
        {
            LocationList loc = new LocationList();
            //loc.MdiParent = this;
            loc.StartPosition = FormStartPosition.CenterScreen;
            loc.ShowDialog(this);
        }

        private void cmdOperationsCategory_Click(object sender, EventArgs e)
        {
            OperationsCategoryList obj = new OperationsCategoryList();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void Operationals_Click(object sender, EventArgs e)
        {
            OperationalDetails obj = new OperationalDetails();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void ribbonButton10_Click(object sender, EventArgs e)
        {
            OperationsCategoryList obj = new OperationsCategoryList();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void cmdRigReportGeneration_Click(object sender, EventArgs e)
        {
            RigOperationsDailyReport obj = new RigOperationsDailyReport();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
        }

        private void ribbonButton14_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void ribbonButton14_Click(object sender, EventArgs e)
        {
            MyFavorites obj = new MyFavorites();
            //obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterScreen;                        
            obj.ShowDialog(this);
        }
    }
}
