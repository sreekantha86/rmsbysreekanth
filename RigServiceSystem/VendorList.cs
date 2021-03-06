﻿using RigRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RigServiceSystem
{
    public partial class VendorList : Form
    {
        DBFunctionRepository repo = new DBFunctionRepository();
        VendorRepository vendor = new VendorRepository();
        public VendorList()
        {
            InitializeComponent();
        }
        
        private void VendorList_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
        void FillGrid()
        {
            try
            {
                DataSet ds = vendor.GetVendorList(txtKeys.Text);

                gridControl1.DataSource = ds.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VendorId").ToString());
            if (RowId > 0)
            {
                Vendor obj = new Vendor();
                obj.VendorId = RowId;
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.ShowDialog(this);
                FillGrid();
            }
        }

        
        private void cmdNew_Click(object sender, EventArgs e)
        {
            Vendor obj = new Vendor();
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.ShowDialog(this);
            FillGrid();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VendorId").ToString());
            if (RowId > 0)
            {
                Vendor obj = new Vendor();
                obj.VendorId = RowId;
                obj.StartPosition = FormStartPosition.CenterScreen;
                obj.ShowDialog(this);
                FillGrid();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VendorId").ToString());
            try
            {
                if (RowId > 0)
                {
                    if (MessageBox.Show("Do you want to Delete?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string sql = @"Delete From Vendor where Vendorid = " + RowId.ToString() + ";select @@ROWCOUNT";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private void cmdPin_Click(object sender, EventArgs e)
        {
            UserRepository user = new UserRepository();
            user.AddToFavoriteForms(this.Name, this.Text, Program.UserId);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
