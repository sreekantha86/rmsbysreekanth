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
    public partial class OperationsCategory : Form
    {
        OperationsCategoryListRepository repo = new OperationsCategoryListRepository();
        public int OperationId = 0;
        public OperationsCategory()
        {
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if(Validate())
            {
                if(OperationId == 0)
                {
                    Insert();
                }
                else
                {
                    Update();
                }
            }
        }
        private void Insert()
        {
            try
            {
                OperationsModel model = new OperationsModel();
                model.OperationsName = txtName.Text;
                model.OperationsDescription = txtRemarks.Text;
                model.OperationTypes = new List<OperationTypeModel>();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "OprName").ToString() != "")
                    {
                        model.OperationTypes.Add(new OperationTypeModel()
                        {
                            OperationsId = 0,
                            OprId = Convert.ToInt32(gridView1.GetRowCellValue(i, "OprId").ToString()),
                            OprName = gridView1.GetRowCellValue(i, "OprName").ToString()
                        });
                    }
                }
                model = repo.Insert(model);
                if(model.OperationsId >0)
                {
                    MessageBox.Show("Saved Successfully");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        private void Update()
        {
            try
            {
                OperationsModel model = new OperationsModel();
                model.OperationsId = OperationId;
                model.OperationsName = txtName.Text;
                model.OperationsDescription = txtRemarks.Text;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "OprName").ToString() != "")
                    {
                        model.OperationTypes.Add(new OperationTypeModel()
                        {
                            OperationsId = OperationId,
                            OprId = Convert.ToInt32(gridView1.GetRowCellValue(i, "OprId").ToString()),
                            OprName = gridView1.GetRowCellValue(i, "OprName").ToString()
                        });
                    }
                }
                model = repo.Update(model);
                if (model.OperationsId > 0)
                {
                    MessageBox.Show("Updated Successfully");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        private bool Validate()
        {
            if(txtName.Text == "")
            {
                MessageBox.Show("Please enter Operation Name");
                txtName.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void OperationsCategory_Load(object sender, EventArgs e)
        {
            if(OperationId == 0)
            {
                InitializeGrid();
            }
        }
        private void InitializeGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("OprId");
                dt.Columns.Add("OprName");
                for (int i = 0; i < 50; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["OprId"] = 0;
                    dr["OprName"] = "";
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
