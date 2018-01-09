using RigRepository;
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
    public partial class UserList : Form
    {
        DBFunctionRepository repo = new DBFunctionRepository();
        public UserList()
        {
            InitializeComponent();
            FillGrid();
        }
        void FillGrid()
        {
            try
            {
                string query = @"select U.UserId, U.UserName, U.UserFullName, U.EmailId, U.ContactNumber, R.RoleName
                from Users U inner join UserRole R on R.RoleId = U.RoleId order by U.UserFullName";

                DataSet ds = repo.fillComboDataset(query);
                gridControl1.DataSource = ds.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UserId").ToString());
            if (RowId > 0)
            {
                try
                {
                    if (MessageBox.Show("Do you want to Delete?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string sql = @"Delete From [Users] where UserId = " + RowId.ToString() + ";select @@ROWCOUNT";
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

        private void cmdAddNew_Click(object sender, EventArgs e)
        {
            User obj = new User();
            obj.ShowDialog(this);
            FillGrid();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UserId").ToString());
            if(RowId > 0)
            {
                User obj = new User();
                obj.UserId = RowId;
                obj.ShowDialog(this);
                FillGrid();
            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            User obj = new User();
            obj.ShowDialog(this);
            FillGrid();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "UserId").ToString());
            if (RowId > 0)
            {
                User obj = new User();
                obj.UserId = RowId;
                obj.ShowDialog(this);
                FillGrid();
            }
        }
    }
}
