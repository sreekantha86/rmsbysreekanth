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
    public partial class RigList : Form
    {
        RigMasterRepository repo = new RigMasterRepository();
        public RigList()
        {
            InitializeComponent();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            Rig newRig = new Rig();
            newRig.ShowDialog(this);
            FillGrid();
        }

        private void RigList_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
        private void FillGrid()
        {
            try
            {
                DataSet ds = repo.GetRigList();
                gridControl1.DataSource = ds.Tables[0];
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

        private void pictureEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RigId").ToString());
            if (RowId > 0)
            {
                Rig obj = new Rig();
                obj.RigId = RowId;
                obj.ShowDialog(this);
                FillGrid();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "RigId").ToString());
                if (RowId > 0)
                {
                    bool res = repo.DeleteRig(RowId);
                    if (res)
                    {
                        MessageBox.Show("Deleted Successfully..");
                        FillGrid();
                    }
                    else
                    {
                        MessageBox.Show("Rig already in Use. Cannot delete.");
                    }
                }
            }
        }
    }
}
