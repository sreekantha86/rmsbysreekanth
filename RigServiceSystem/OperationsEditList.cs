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
using System.Windows.Forms;

namespace RigServiceSystem
{
    public partial class OperationsEditList : Form
    {
        WellRepository well = new WellRepository();
        RigOperationsRepository repo = new RigOperationsRepository();
        public OperationsEditList()
        {
            InitializeComponent();
        }

        private void OperationsEditList_Load(object sender, EventArgs e)
        {
            FillRig();
        }
        private void FillRig()
        {
            try
            {
                DataSet dsRig = well.fillRig();
                lstRig.Properties.DataSource = dsRig.Tables[0];
                lstRig.Properties.DisplayMember = "RigName";
                lstRig.Properties.ValueMember = "RigId";
                lstRig.Properties.NullText = "";
                lstRig.Properties.PopulateColumns();
                lstRig.Properties.Columns["RigId"].Visible = false;
                lstRig.Properties.ShowHeader = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        private void lstRig_EditValueChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
        private void FillGrid()
        {
            try
            {
                if (lstRig.Text != "")
                {
                    int RigId = Convert.ToInt32(lstRig.Properties.GetKeyValueByDisplayValue(lstRig.Text));
                    List<CurrentOperationModel> model = repo.GetOperationsHistory(RigId);
                    gridControl2.DataSource = model;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                int wellOpId = Convert.ToInt32(view.GetRowCellValue(info.RowHandle, "WellOpId").ToString());
                int RigId = Convert.ToInt32(lstRig.Properties.GetKeyValueByDisplayValue(lstRig.Text));

                UpdateOperations obj = new UpdateOperations();
                obj.Text = "Edit Operation";
                obj.WellOpId = wellOpId;
                obj.RigId = RigId;
                obj.ShowDialog();
                FillGrid();
            }
        }
    }
}
