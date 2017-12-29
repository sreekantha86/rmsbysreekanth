using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RigRepository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace RigServiceSystem
{
    public partial class FinancialYearList : Form
    {
        DBFunctionRepository repo = new DBFunctionRepository();
        public FinancialYearList()
        {
            InitializeComponent();
        }

        private void FinancialYearList_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
        private void FillGrid()
        {
            DataSet ds = repo.fillComboDataset("select * from FinancialYear");
            gridControl1.DataSource = ds.Tables[0];
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAddnew_Click(object sender, EventArgs e)
        {
            FinancialYear obj = new FinancialYear();
            //obj.MdiParent = this;
            obj.Text = "Add New";
            obj.ShowDialog();
            FillGrid();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if(info.InRow || info.InRowCell)
            {
                int fyId = Convert.ToInt32(view.GetRowCellValue(info.RowHandle, "FyID").ToString());

                FinancialYear obj = new FinancialYear();
                obj.Text = "Modify";
                obj.FyId = fyId;
                obj.ShowDialog();
                FillGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FyID").ToString());
            if(RowId > 0)
            {
                try
                {
                    if (MessageBox.Show("Do you want to Delete?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string sql = @"Delete From FinancialYear where FyID = " + RowId.ToString() + ";select @@ROWCOUNT";
                        DataSet ds = repo.fillComboDataset(sql);
                        if (ds.Tables[0].Rows[0][0].ToString() != "0")
                        {
                            MessageBox.Show("Successfully Deleted.");
                        }
                        else
                        {
                            MessageBox.Show("Data not deleted.");
                        }

                        FillGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                }
            }
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            FinancialYear obj = new FinancialYear();
            //obj.MdiParent = this;
            obj.Text = "Add New";
            obj.ShowDialog();
            FillGrid();
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FyID").ToString());
            if (RowId > 0)
            {
                try
                {
                    if (MessageBox.Show("Do you want to Delete?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string sql = @"Delete From FinancialYear where FyID = " + RowId.ToString() + ";select @@ROWCOUNT";
                        DataSet ds = repo.fillComboDataset(sql);
                        if (ds.Tables[0].Rows[0][0].ToString() != "0")
                        {
                            MessageBox.Show("Successfully Deleted.");
                        }
                        else
                        {
                            MessageBox.Show("Data not deleted.");
                        }

                        FillGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                }
            }
        }

        private void cmdPin_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmdPin_Click(object sender, EventArgs e)
        {
            UserRepository user = new UserRepository();
            user.AddToFavoriteForms(this.Name, this.Text, Program.UserId);
        }
    }
}
