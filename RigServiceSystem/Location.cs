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
    public partial class Location : Form
    {
        LocationRepository repo = new LocationRepository();
        public int LocId = 0;
        public Location()
        {
            //test
            InitializeComponent();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to Save?","", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if(LocId == 0)
                {
                    if(Validate())
                    {
                        Insert();
                    }
                }
                else
                {
                    if (Validate())
                        Update();
                }
            }
        }
        private bool Validate()
        {
            if(txtCode.Text == "")
            {
                MessageBox.Show("please enter Code");
                txtCode.Focus();
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("please enter Name");
                txtName.Focus();
                return false;
            }
            return true;
        }
        private void Insert()
        {
            try
            {
                LocationModel model = new LocationModel();
                model.LocId = 0;
                model.LocCode = txtCode.Text;
                model.LocName = txtName.Text;
                model.LocLatitude = txtLatitude.Text;
                model.LocLongitude = txtLongitude.Text;
                model.LocRemarks = txtRemarks.Text;

                model = repo.Insert(model);
                if(model.LocId >0)
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
                LocationModel model = new LocationModel();
                model.LocId = LocId;
                model.LocCode = txtCode.Text;
                model.LocName = txtName.Text;
                model.LocLatitude = txtLatitude.Text;
                model.LocLongitude = txtLongitude.Text;
                model.LocRemarks = txtRemarks.Text;

                model = repo.Update(model);
                if (model.LocId > 0)
                {
                    MessageBox.Show("Successfully Updated");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private void Location_Load(object sender, EventArgs e)
        {
            if(LocId > 0)
            {
                fillData();
            }
        }
        private void fillData()
        {
            try
            {
                LocationModel model = repo.GetLocation(LocId);
                if(model != null)
                {
                    txtCode.Text = model.LocCode;
                    txtLatitude.Text = model.LocLatitude;
                    txtLongitude.Text = model.LocLongitude;
                    txtName.Text = model.LocName;
                    txtRemarks.Text = model.LocRemarks;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
