using RigRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RigServiceSystem
{
    public partial class LocationList : Form
    {
        LocationRepository repo = new LocationRepository();
        public LocationList()
        {
            InitializeComponent();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            Location loc = new Location();
            loc.ShowDialog();
            FillGrid();
        }

        private void LocationList_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
        private void FillGrid()
        {
            try
            {
                DataSet ds = repo.GetLocationList();
                if(ds.Tables.Count>0)
                {
                    gridControl1.DataSource = ds.Tables[0];
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

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LocId").ToString());
            if (RowId > 0)
            {
                Location obj = new Location();
                obj.LocId = RowId;
                obj.ShowDialog(this);
                FillGrid();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LocId").ToString());
                if (RowId > 0)
                {
                    bool res = repo.DeleteLocation(RowId);
                    if (res)
                    {
                        MessageBox.Show("Deleted Successfully..");
                        FillGrid();
                    }
                    else
                    {
                        MessageBox.Show("Location already in Use. Cannot delete.");
                    }
                }
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
