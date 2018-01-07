using RigRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RigServiceSystem
{
    public partial class Well : Form
    {
        WellRepository well = new WellRepository();
        public int WellId = 0;
        public int RigId = 0;
        public Well()
        {
            InitializeComponent();
        }

        private void Well_Load(object sender, EventArgs e)
        {
            FillDropDowns();
            if(WellId > 0)
            {
                ShowWell();
            }
            else
            {
                ShowWellSections();
            }            
        }
        private void ShowWell()
        {
            try
            {
                WellModel model = well.GetWellDetails(WellId);
                txtCode.Text = model.WellCode;
                txtName.Text = model.WellName;
                txtPlannedDate.DateTime = model.WellPlannedDate;
                txtWellDepth.Text = model.WellDepth.ToString();
                lstLocation.EditValue = model.LocationId;
                lstRig.EditValue = model.RigId;
                lstWellType.EditValue = model.WellTypeId;
                txtPlannedDays.Text = model.PlannedDays.ToString();

                gridControl1.DataSource = model.DrillingPlanDoc;
                gridControl2.DataSource = model.WellSections;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        private void ShowWellSections()
        {
            try
            {
                List<WellSectionModel> model = well.GetSectionDetails(WellId);
                gridControl2.DataSource = model;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        private void FillDropDowns()
        {
            try
            {
                DataSet dsLoc = well.fillLocation();
                lstLocation.Properties.DataSource = dsLoc.Tables[0];
                lstLocation.Properties.DisplayMember = "LocName";
                lstLocation.Properties.ValueMember = "LocId";
                lstLocation.Properties.NullText = "";
                lstLocation.Properties.PopulateColumns();
                lstLocation.Properties.Columns["LocId"].Visible = false;
                lstLocation.Properties.ShowHeader = false;

                DataSet dsWellType = well.fillWellType();
                lstWellType.Properties.DataSource = dsWellType.Tables[0];
                lstWellType.Properties.DisplayMember = "WellTypeName";
                lstWellType.Properties.ValueMember = "WellTypeId";
                lstWellType.Properties.NullText = "";
                lstWellType.Properties.PopulateColumns();
                lstWellType.Properties.Columns["WellTypeId"].Visible = false;
                lstWellType.Properties.ShowHeader = false;

                DataSet dsRig = well.fillRig();
                lstRig.Properties.DataSource = dsRig.Tables[0];
                lstRig.Properties.DisplayMember = "RigName";
                lstRig.Properties.ValueMember = "RigId";
                lstRig.Properties.NullText = "";
                lstRig.Properties.PopulateColumns();
                lstRig.Properties.Columns["RigId"].Visible = false;
                lstRig.Properties.ShowHeader = false;

                if(RigId > 0)
                {
                    lstRig.EditValue = RigId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if(Validate())
            {
                if(MessageBox.Show("Do you want to Save?","", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (WellId == 0)
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
        public void Insert()
        {
            try
            {
                WellModel model = new WellModel();
                model.DrillingPlanDoc = new List<WellDrillingPlanModel>();
                try
                {
                    FileStream stream = File.OpenRead(openFileDialog1.FileName);
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();

                    model.DrillingPlanDoc.Add(new WellDrillingPlanModel
                    {
                        WellId = WellId,
                        WellDrillPlanId = 0,
                        WellDrillDocExt = System.IO.Path.GetExtension(openFileDialog1.FileName.ToString()),
                        WellDrillDoc = fileBytes,
                        WellDrilDocName = lblFileName.Text
                    });
                }
                catch (Exception)
                {
                }
                model.LocationId = Convert.ToInt32(lstLocation.Properties.GetKeyValueByDisplayValue(lstLocation.Text));
                model.WellCode = txtCode.Text;
                model.WellDepth = Convert.ToDecimal(txtWellDepth.Text.Replace(",", ""));
                model.WellId = 0;
                model.WellName = txtName.Text;
                model.WellPlannedDate = txtPlannedDate.DateTime;
                model.WellTypeId = Convert.ToInt32(lstWellType.Properties.GetKeyValueByDisplayValue(lstWellType.Text));
                model.RigId = Convert.ToInt32(lstRig.Properties.GetKeyValueByDisplayValue(lstRig.Text));

                model.WellSections = new List<WellSectionModel>();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    model.WellSections.Add(new WellSectionModel()
                    {
                        SecDepth = Convert.ToDecimal(gridView2.GetRowCellValue(i, "SecDepth").ToString()),
                        SecId = Convert.ToInt32(gridView2.GetRowCellValue(i, "SecId").ToString()),
                        SectionName = gridView2.GetRowCellValue(i, "SectionName").ToString(),
                        WellId = 0,
                        WellSecId = Convert.ToInt32(gridView2.GetRowCellValue(i, "WellSecId").ToString())
                    });
                }

                model = well.Insert(model);

                if(model.WellId >0)
                {
                    MessageBox.Show("Saved Successfully");
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
                WellModel model = new WellModel();
                model.DrillingPlanDoc = new List<WellDrillingPlanModel>();
                try
                {
                    FileStream stream = File.OpenRead(openFileDialog1.FileName);
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();

                    model.DrillingPlanDoc.Add(new WellDrillingPlanModel
                    {
                        WellId = WellId,
                        WellDrillPlanId = 0,
                        WellDrillDocExt = System.IO.Path.GetExtension(openFileDialog1.FileName.ToString()),
                        WellDrillDoc = fileBytes,
                        WellDrilDocName = lblFileName.Text
                    });
                }
                catch (Exception)
                {
                }
                
                model.LocationId = Convert.ToInt32(lstLocation.Properties.GetKeyValueByDisplayValue(lstLocation.Text));
                model.WellCode = txtCode.Text;
                model.WellDepth = Convert.ToDecimal(txtWellDepth.Text.Replace(",", ""));
                model.WellId = WellId;
                model.WellName = txtName.Text;
                model.WellPlannedDate = txtPlannedDate.DateTime;
                model.WellTypeId = Convert.ToInt32(lstWellType.Properties.GetKeyValueByDisplayValue(lstWellType.Text));
                model.RigId = Convert.ToInt32(lstRig.Properties.GetKeyValueByDisplayValue(lstRig.Text));

                model.WellSections = new List<WellSectionModel>();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    model.WellSections.Add(new WellSectionModel()
                    {
                        SecDepth = Convert.ToDecimal(gridView2.GetRowCellValue(i, "SecDepth").ToString()),
                        SecId = Convert.ToInt32(gridView2.GetRowCellValue(i, "SecId").ToString()),
                        SectionName = gridView2.GetRowCellValue(i, "SectionName").ToString(),
                        WellId = WellId,
                        WellSecId = Convert.ToInt32(gridView2.GetRowCellValue(i, "WellSecId").ToString())
                    });
                }

                model = well.Update(model);

                if (model.WellId > 0)
                {
                    MessageBox.Show("Saved Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
        private bool Validate()
        {
            if(txtCode.Text == "")
            {
                MessageBox.Show("Please enter Well Code.");
                txtCode.Focus();
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Well Name.");
                txtName.Focus();
                return false;
            }
            if (lstRig.Text == "")
            {
                MessageBox.Show("Please select Rig.");
                lstRig.Focus();
                return false;
            }
            if (lstLocation.Text == "")
            {
                MessageBox.Show("Please select Location.");
                lstLocation.Focus();
                return false;
            }
            if(txtPlannedDays.Text == "" || Convert.ToInt32(txtPlannedDays.Text) <= 0)
            {
                MessageBox.Show("Enter valid Planned Days.");
                txtPlannedDays.Focus();
                return false;
            }
            return true;
        }

        private void cmdUploadDrillingPlan_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            lblFileName.Text = System.IO.Path.GetFileName(openFileDialog1.FileName.ToString()); 
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            WellList list = new WellList();
            list.ShowDialog();
        }

        private void lstLocation_TextChanged(object sender, EventArgs e)
        {
            if(lstLocation.Text != "")
            {
                int locId = Convert.ToInt32(lstLocation.Properties.GetKeyValueByDisplayValue(lstLocation.Text));
                LocationModel loc = well.GetLocationDetails(locId);
                if(loc != null)
                {
                    txtLatitude.Text = loc.LocLatitude;
                    txtLongitude.Text = loc.LocLongitude;
                }
            }
        }
    }
}
