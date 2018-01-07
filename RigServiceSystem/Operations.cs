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
    public partial class Operations : Form
    {
        WellRepository well = new WellRepository();
        public Operations()
        {
            InitializeComponent();
        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void cmdNewWell_Click(object sender, EventArgs e)
        {
            Well obj = new Well();
            if (lstRig.Text != "")
                obj.RigId = Convert.ToInt32(lstRig.Properties.GetKeyValueByDisplayValue(lstRig.Text));
            obj.ShowDialog(this);
            obj.Dispose();
        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(lstRig.Text == "")
            {
                MessageBox.Show("Please select a Rig.");
                return;
            }
            UpdateOperations obj = new UpdateOperations();
            obj.RigId = Convert.ToInt32(lstRig.Properties.GetKeyValueByDisplayValue(lstRig.Text));
            obj.ShowDialog();
            obj.Dispose();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OperationsEditList obj = new OperationsEditList();
            obj.ShowDialog();
            obj.Dispose();
        }

        private void Operations_Load(object sender, EventArgs e)
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

        private void labelControl6_Click_1(object sender, EventArgs e)
        {

        }

        private void lstRig_TextChanged(object sender, EventArgs e)
        {
            if(lstRig.Text != "")
            {
                int RigId = Convert.ToInt32(lstRig.Properties.GetKeyValueByDisplayValue(lstRig.Text));
                CurrentOperationModel model = well.GetCurrentOperation(RigId);
                if(model != null)
                {
                    txtWell.Text = model.WellName;
                    txtWellType.Text = model.WellTypeName;
                    txtSection.Text = model.SectionName;
                    txtPlanDepth.Text = model.WellDepth.ToString();
                    txtOperation.Text = model.OperationsName;
                    txtLocation.Text = model.LocName;
                    txtDaysOnWell.Text = model.DaysOnWell.ToString();
                    txtCurrentDepth.Text = model.CurrentDepth.ToString();
                }
            }
        }
    }
}
