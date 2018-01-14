using DevExpress.XtraGrid.Views.Grid;
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
    public partial class MyFavorites : Form
    {
        public MyFavorites()
        {
            InitializeComponent();
        }

        private void MyFavorites_Load(object sender, EventArgs e)
        {
            fillGrid();
        }
        void fillGrid()
        {
            try
            {
                UserRepository repo = new UserRepository();
                DataSet ds = repo.FillFavorites(Program.UserId);
                gridFavorites.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) !=
                  DialogResult.Yes)
                    return;
                GridView view = sender as GridView;
                string FormName = view.GetRowCellValue(view.FocusedRowHandle, "FormName").ToString();
                UserRepository repo = new UserRepository();
                repo.DeleteFavorite(FormName, Program.UserId);
                view.DeleteRow(view.FocusedRowHandle);
            }
        }
    }
}
