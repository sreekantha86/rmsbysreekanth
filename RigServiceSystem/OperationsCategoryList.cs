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
    public partial class OperationsCategoryList : Form
    {
        OperationsCategoryListRepository repo = new OperationsCategoryListRepository();
        public OperationsCategoryList()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void OperationsList_Load(object sender, EventArgs e)
        {
            fillGrid();
        }
        private void fillGrid()
        {
            try
            {
                DataSet ds = repo.GetOperationsList();
                if (ds.Tables.Count > 0)
                    gridControl1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            OperationsCategory obj = new OperationsCategory();
            obj.ShowDialog();
            fillGrid();
        }

        private void cmdPin_Click(object sender, EventArgs e)
        {
            UserRepository user = new UserRepository();
            user.AddToFavoriteForms(this.Name, this.Text, Program.UserId);
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            int RowId = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "OperationsId").ToString());
            if (RowId > 0)
            {
                OperationsCategory obj = new OperationsCategory();
                obj.OperationId = RowId;
                obj.ShowDialog(this);
                fillGrid();
            }
        }
    }
}
