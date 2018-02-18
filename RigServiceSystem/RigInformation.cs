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
    public partial class RigInformation : Form
    {
        WellRepository well = new WellRepository();
        public RigInformation()
        {
            InitializeComponent();
        }

        private void RigInformation_Load(object sender, EventArgs e)
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

        private void lstRig_TextChanged(object sender, EventArgs e)
        {
            if (lstRig.Text != "")
            {
                int RigId = Convert.ToInt32(lstRig.Properties.GetKeyValueByDisplayValue(lstRig.Text));
                CurrentOperationModel model = well.GetCurrentOperation(RigId);
                RigModel rig = new RigMasterRepository().GetRig(RigId);
                List<CurrentOperationModel> wells = well.GetCurrentOperationOnWells(RigId);
                if (model != null)
                {
                    txtCurrentWell.Text = model.WellName;
                    txtCurrentOperation.Text = model.OperationsName;
                    txtCurrentLocation.Text = model.LocName;
                    txtOperatingDays.Text = model.DaysOnWell.ToString();
                    txtModelNo.Text = rig.RigModelNo;
                    txtManufacturer.Text = rig.RigManufacturer;
                    txtProject.Text = rig.RigProject;
                    txtRigSpecification.Text = rig.RigRemarks;                    
                }
                gridControl1.DataSource = wells;
            }
        }
    }
}
