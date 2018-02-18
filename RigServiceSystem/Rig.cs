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
    public partial class Rig : Form
    {
        RigMasterRepository repo = new RigMasterRepository();
        public int RigId = 0;
        public Rig()
        {
            InitializeComponent();
        }

        private void Rig_Load(object sender, EventArgs e)
        {
            fillDropDowns();
            if(RigId > 0)
            {
                FillData();
            }
            else
            {
                txtCode.Text = repo.GetNewNumber();
            }
        }
        private void FillData()
        {
            try
            {
                RigModel model = repo.GetRig(RigId);
                txtCode.Text = model.RigCode;
                if(model.RigDeployed != null)
                {
                    txtDateOfDeploy.DateTime = model.RigDeployed ?? DateTime.Now;
                }                
                txtManufacturer.Text = model.RigManufacturer;
                txtModelNo.Text = model.RigModelNo;
                txtName.Text = model.RigName;
                txtProject.Text = model.RigProject;
                txtRemarks.Text = model.RigRemarks;
                //lstLocation.EditValue = model.LocId;
                lstRigType.EditValue = model.RigTypeId;
                txtLocation.Text = model.RigLocation;
                txtRigType.Text = model.RigTypeName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        private void fillDropDowns()
        {
            try
            {
                //DataSet dsLoc = repo.fillLocation();
                //lstLocation.Properties.DataSource = dsLoc.Tables[0];
                //lstLocation.Properties.DisplayMember = "LocName";
                //lstLocation.Properties.ValueMember = "LocId";
                //lstLocation.Properties.NullText = "";
                //lstLocation.Properties.PopulateColumns();
                //lstLocation.Properties.Columns["LocId"].Visible = false;
                //lstLocation.Properties.ShowHeader = false;

                //DataSet dsRigType = repo.fillRigType();
                //lstRigType.Properties.DataSource = dsRigType.Tables[0];
                //lstRigType.Properties.DisplayMember = "RigTypeName";
                //lstRigType.Properties.ValueMember = "RigTypeId";
                //lstRigType.Properties.NullText = "";
                //lstRigType.Properties.PopulateColumns();
                //lstRigType.Properties.Columns["RigTypeId"].Visible = false;
                //lstRigType.Properties.ShowHeader = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        private void cmdSave_EditValueChanged(object sender, EventArgs e)
        {
            if(Validate())
            {
                if(RigId == 0)
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
                RigModel model = new RigModel();
                //model.LocId = Convert.ToInt32(lstLocation.Properties.GetKeyValueByDisplayValue(lstLocation.Text));
                model.RigCode = txtCode.Text;
                model.RigId = 0;
                model.RigManufacturer = txtManufacturer.Text;
                model.RigModelNo = txtModelNo.Text;
                model.RigName = txtName.Text;
                model.RigProject = txtProject.Text;
                model.RigRemarks = txtRemarks.Text;
                model.RigTypeId = Convert.ToInt32(lstRigType.Properties.GetKeyValueByDisplayValue(lstRigType.Text));
                model.RigDeployed = txtDateOfDeploy.DateTime;
                model.RigLocation = txtLocation.Text;
                model.RigTypeName = txtRigType.Text;
                model = repo.Insert(model);
                if(model.RigId > 0)
                {
                    MessageBox.Show("Successfully Saved");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        private void Update()
        {
            try
            {
                RigModel model = new RigModel();
                //model.LocId = Convert.ToInt32(lstLocation.Properties.GetKeyValueByDisplayValue(lstLocation.Text));
                model.RigCode = txtCode.Text;
                model.RigId = RigId;
                model.RigManufacturer = txtManufacturer.Text;
                model.RigModelNo = txtModelNo.Text;
                model.RigName = txtName.Text;
                model.RigProject = txtProject.Text;
                model.RigRemarks = txtRemarks.Text;
                model.RigTypeId = Convert.ToInt32(lstRigType.Properties.GetKeyValueByDisplayValue(lstRigType.Text));
                model.RigDeployed = txtDateOfDeploy.DateTime;
                model.RigLocation = txtLocation.Text;
                model.RigTypeName = txtRigType.Text;
                model = repo.Update(model);
                if (model.RigId > 0)
                {
                    MessageBox.Show("Successfully updated");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        private bool Validate()
        {
            if(txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code");
                txtCode.Focus();
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name");
                txtName.Focus();
                return false;
            }
            //if (txtLocation.Text == "")
            //{
            //    MessageBox.Show("Please enter Location");
            //    lstLocation.Focus();
            //    return false;
            //}
            //if (txtRigType.Text == "")
            //{
            //    MessageBox.Show("Please enter Rig type");
            //    lstRigType.Focus();
            //    return false;
            //}
            if(txtDateOfDeploy.Text == "")
            {
                MessageBox.Show("Please select date of Diploy");
                txtDateOfDeploy.Focus();
                return false;
            }
            return true;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if(Validate())
            {
                if(MessageBox.Show("Do you want to save?","", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if(RigId == 0)
                    {
                        Insert();
                    }
                    else
                    {
                        Update();
                    }
                }
            }
        }
    }
}
