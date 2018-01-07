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
    public partial class UpdateOperations : Form
    {
        public int RigId = 0;
        public int WellOpId = 0;
        RigOperationsRepository repo = new RigOperationsRepository();
        int WellId = 0;
        bool fillOperation = true;
        public UpdateOperations()
        {
            InitializeComponent();
        }

        private void UpdateOperations_Load(object sender, EventArgs e)
        {
            if (RigId > 0 && WellOpId == 0)
            {
                FillWellDetails();
                fillDropdown();
                txtStartDatetime.DateTime = DateTime.Now;
                lblEndDateTime.Visible = false;
                txtEndDateTime.Visible = false;
            }
            if (RigId > 0 && WellOpId > 0)
            {
                FillWellDetails();
                fillDropdown();
                FillWellOperationDetails();
            }
        }

        private void FillWellDetails()
        {
            try
            {
                WellModel model = repo.GetWellDetails(RigId);
                WellId = model.WellId;
                if(model != null)
                {
                    txtLocation.Text = model.LocName;
                    txtPlannedDepth.Text = model.WellDepth.ToString("#0");
                    txtWellName.Text = model.WellName;
                    txtWellType.Text = model.WellTypeName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        private void fillDropdown()
        {
            try
            {
                DataSet ds = repo.GetOperations();
                lstOperationCategory.Properties.DataSource = ds.Tables[0];
                lstOperationCategory.Properties.DisplayMember = "OperationsName";
                lstOperationCategory.Properties.ValueMember = "OperationsId";
                lstOperationCategory.Properties.NullText = "";
                lstOperationCategory.Properties.PopulateColumns();
                lstOperationCategory.Properties.Columns["OperationsId"].Visible = false;
                lstOperationCategory.Properties.ShowHeader = false;

                DataSet dsSec = repo.GetSections(WellId);
                lstCurrentSection.Properties.DataSource = dsSec.Tables[0];
                lstCurrentSection.Properties.DisplayMember = "SectionName";
                lstCurrentSection.Properties.ValueMember = "SecId";
                lstCurrentSection.Properties.NullText = "";
                lstCurrentSection.Properties.PopulateColumns();
                lstCurrentSection.Properties.Columns["SecId"].Visible = false;
                lstCurrentSection.Properties.ShowHeader = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        private void FillWellOperationDetails()
        {
            try
            {
                WellOperationsModel model = repo.GetOperationEditDetails(WellOpId);
                if(model != null)
                {
                    fillOperation = false;
                    WellId = model.WellId;
                    lstOperationCategory.EditValue = model.OperationsId;
                    txtStartDatetime.DateTime = model.StartTime;
                    if(model.EndTime != null)
                    {
                        txtEndDateTime.DateTime = model.EndTime ?? DateTime.Now;
                    }
                    lstCurrentSection.EditValue = model.SecId;
                    txtCurrentDepth.Text = model.CurrentDepth.ToString();
                    txtRemarks.Text = model.Remarks;
                    
                    DataSet ds = repo.GetOperationsType(model.OperationsId);
                    lstOperation.Properties.DataSource = ds.Tables[0];
                    lstOperation.Properties.DisplayMember = "OprName";
                    lstOperation.Properties.ValueMember = "OprId";
                    lstOperation.Properties.NullText = "";
                    lstOperation.Properties.PopulateColumns();
                    lstOperation.Properties.Columns["OprId"].Visible = false;
                    lstOperation.Properties.ShowHeader = false;
                    lstOperation.EditValue = model.OprId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        private void lstOperationCategory_TextChanged(object sender, EventArgs e)
        {
            if(lstOperationCategory.Text != "" && fillOperation)
            {
                int Id = Convert.ToInt32(lstOperationCategory.Properties.GetKeyValueByDisplayValue(lstOperationCategory.Text));
                DataSet ds = repo.GetOperationsType(Id);
                lstOperation.Properties.DataSource = ds.Tables[0];
                lstOperation.Properties.DisplayMember = "OprName";
                lstOperation.Properties.ValueMember = "OprId";
                lstOperation.Properties.NullText = "";
                lstOperation.Properties.PopulateColumns();
                lstOperation.Properties.Columns["OprId"].Visible = false;
                lstOperation.Properties.ShowHeader = false;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                if (MessageBox.Show("Do you want to Save?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if(WellOpId == 0)
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
        private bool Validate()
        {
            if(lstOperationCategory.Text == "")
            {
                MessageBox.Show("please select Operation Category");
                lstOperationCategory.Focus();
                return false;
            }
            if (lstOperation.Text == "")
            {
                MessageBox.Show("please select Operation");
                lstOperation.Focus();
                return false;
            }
            if (txtStartDatetime.Text == "")
            {
                MessageBox.Show("please select Start Time");
                txtStartDatetime.Focus();
                return false;
            }
            if (lstCurrentSection.Text == "")
            {
                MessageBox.Show("please select Current Section");
                lstCurrentSection.Focus();
                return false;
            }
            if (txtCurrentDepth.Text == "" || txtCurrentDepth.Text == "0")
            {
                MessageBox.Show("please enter Depth");
                txtCurrentDepth.Focus();
                return false;
            }
            return true;
        }

        private void Insert()
        {
            try
            {
                WellOperationsModel model = new WellOperationsModel();
                model.CreatedDateTime = DateTime.Now;
                model.CurrentDepth = Convert.ToDecimal(txtCurrentDepth.Text);
                model.OprId = Convert.ToInt32(lstOperation.Properties.GetKeyValueByDisplayValue(lstOperation.Text));
                model.OperationsId = Convert.ToInt32(lstOperationCategory.Properties.GetKeyValueByDisplayValue(lstOperationCategory.Text));
                model.Remarks = txtRemarks.Text;
                model.SecId = Convert.ToInt32(lstCurrentSection.Properties.GetKeyValueByDisplayValue(lstCurrentSection.Text));
                model.StartTime = txtStartDatetime.DateTime;
                model.WellId = WellId;

                model = repo.Insert(model);
                if(model.WellOpId > 0)
                {
                    MessageBox.Show("Saved Successfully.");
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
                WellOperationsModel model = new WellOperationsModel();
                model.CreatedDateTime = DateTime.Now;
                model.CurrentDepth = Convert.ToDecimal(txtCurrentDepth.Text);
                model.OprId = Convert.ToInt32(lstOperation.Properties.GetKeyValueByDisplayValue(lstOperation.Text));
                model.OperationsId = Convert.ToInt32(lstOperationCategory.Properties.GetKeyValueByDisplayValue(lstOperationCategory.Text));
                model.Remarks = txtRemarks.Text;
                model.SecId = Convert.ToInt32(lstCurrentSection.Properties.GetKeyValueByDisplayValue(lstCurrentSection.Text));
                model.StartTime = txtStartDatetime.DateTime;
                model.WellId = WellId;
                model.WellOpId = WellOpId;
                if(txtEndDateTime.Text != "")
                {
                    model.EndTime = txtEndDateTime.DateTime;
                }
                else
                {
                    model.EndTime = null;
                }

                model = repo.Update(model);
                if (model.WellOpId > 0)
                {
                    MessageBox.Show("Saved Successfully.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
