using RigRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RigServiceSystem
{
    public partial class Vendor : Form
    {
        VendorRepository vendor = new VendorRepository();
        public int VendorId;
        public Vendor()
        {
            InitializeComponent();
        }

        private void Vendor_Load(object sender, EventArgs e)
        {
            fillCountry();
            fillVendorType();
            if (VendorId > 0)
            {
                ShowData();
            }
        }
        private void ShowData()
        {
            try
            {
                DataSet ds = vendor.GetVendorData(VendorId);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        txtVendorCode.Text = item["VendorCode"].ToString();
                        txtName.Text = item["VendorName"].ToString();
                        txtPhoneNumber.Text = item["PhoneNumber"].ToString();
                        txtFax.Text = item["Fax"].ToString();
                        txtContactPerson.Text = item["ContactPerson"].ToString();
                        txtCity.Text = item["City"].ToString();
                        txtAdress.Text = item["Address"].ToString();
                        txtEmail.Text = item["Email"].ToString();
                        txtVat.Text = item["VAT"].ToString();
                        if (item["VendorTypeId"].ToString() != "0")
                        {
                            lstVendorType.EditValue = Convert.ToInt32(item["VendorTypeId"].ToString());
                        }
                        if (item["CountryId"].ToString() != "0")
                        {
                            lstCountry.EditValue = Convert.ToInt32(item["CountryId"].ToString());
                        }
                        txtCRNo.Text = item["CrNo"].ToString();
                        txtGosiNo.Text = item["GosiNo"].ToString();
                        txtZakaat.Text = item["Zakaat"].ToString();
                        txtChamberNo.Text = item["ChamberNo"].ToString();
                        txtVATExpiry.Text = item["VATExpiry"].ToString() != "" ? Convert.ToDateTime(item["VATExpiry"].ToString()).ToString("dd/MMM/yyyy"):"";
                        txtChamberExpiry.Text = item["ChamberNoExpiry"].ToString() != "" ? Convert.ToDateTime(item["ChamberNoExpiry"].ToString()).ToString("dd/MMM/yyyy"):"";
                        txtCRExpiry.Text = item["CrNoExpiry"].ToString() != "" ? Convert.ToDateTime(item["CrNoExpiry"].ToString()).ToString("dd/MMM/yyyy") : "";
                        txtGosiExpiry.Text = item["GosiNoExpiry"].ToString() != "" ? Convert.ToDateTime(item["GosiNoExpiry"].ToString()).ToString("dd/MMM/yyyy") : "";
                        txtZakaatExpiry.Text = item["ZakaatExpiry"].ToString() != "" ? Convert.ToDateTime(item["ZakaatExpiry"].ToString()).ToString("dd/MMM/yyyy") : "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        void fillCountry()
        {
            DataSet ds = vendor.GetCountry();
            lstCountry.Properties.DataSource = ds.Tables[0];
            lstCountry.Properties.DisplayMember = "CountryName";
            lstCountry.Properties.ValueMember = "CountryId";
            lstCountry.Properties.NullText = "";
            lstCountry.Properties.PopulateColumns();
            lstCountry.Properties.Columns["CountryId"].Visible = false;
            lstCountry.Properties.ShowHeader = false;
        }
        void fillVendorType()
        {
            DataSet ds = vendor.GetVendorType();
            lstVendorType.Properties.DataSource = ds.Tables[0];
            lstVendorType.Properties.DisplayMember = "VendorTypeName";
            lstVendorType.Properties.ValueMember = "VendorTypeId";
            lstVendorType.Properties.NullText = "";
            lstVendorType.Properties.PopulateColumns();
            lstVendorType.Properties.Columns["VendorTypeId"].Visible = false;
            lstVendorType.Properties.ShowHeader = false;
        }
        private bool Validate()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Vendor Name.");
                txtName.Focus();
                return false;
            }
            return true;
        }
        private void Insert()
        {
            try
            {
                VendorModel model = new VendorModel();
                model.VendorId = 0;
                model.VendorCode = txtVendorCode.Text;
                model.VendorName = txtName.Text;
                model.Address = txtAdress.Text;
                model.PhoneNumber = txtPhoneNumber.Text;
                model.City = txtCity.Text;
                model.FAX = txtFax.Text;
                model.VAT = txtVat.Text;
                model.ContactPerson = txtContactPerson.Text;
                model.Email = txtEmail.Text;
                model.VendorTypeId = Convert.ToInt32(lstVendorType.Properties.GetKeyValueByDisplayValue(lstVendorType.Text).ToString());
                model.CountryId = Convert.ToInt32(lstCountry.Properties.GetKeyValueByDisplayValue(lstCountry.Text).ToString());
                model.CrNo = txtCRNo.Text;
                model.GosiNo = txtGosiNo.Text;
                model.Zakaat = txtZakaat.Text;
                model.ChamberNo = txtChamberNo.Text;
                model.VATExpiry = txtVATExpiry.Text != "" ? txtVATExpiry.DateTime.ToString("dd/MMM/yyyy") : txtVATExpiry.Text;
                model.ChamberNoExpiry = txtChamberExpiry.Text != "" ? txtChamberExpiry.DateTime.ToString("dd/MMM/yyyy") : txtChamberExpiry.Text;
                model.CrNoExpiry = txtCRExpiry.Text != "" ? txtCRExpiry.DateTime.ToString("dd/MMM/yyyy") : txtCRExpiry.Text;
                model.GosiNoExpiry = txtGosiExpiry.Text != "" ? txtGosiExpiry.DateTime.ToString("dd/MMM/yyyy") : txtGosiExpiry.Text;
                model.ZakaatExpiry = txtZakaatExpiry.Text != "" ? txtZakaatExpiry.DateTime.ToString("dd/MMM/yyyy") : txtZakaatExpiry.Text;

                model = vendor.Insert(model);

                if (model.VendorId > 0)
                {
                    MessageBox.Show("Successfully Saved..");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        private void Update()
        {
            try
            {
                VendorModel model = new VendorModel();
                model.VendorId = VendorId;
                model.VendorCode = txtVendorCode.Text;
                model.VendorName = txtName.Text;
                model.Address = txtAdress.Text;
                model.PhoneNumber = txtPhoneNumber.Text;
                model.City = txtCity.Text;
                model.FAX = txtFax.Text;
                model.VAT = txtVat.Text;
                model.ContactPerson = txtContactPerson.Text;
                model.Email = txtEmail.Text;
                model.VendorTypeId = Convert.ToInt32(lstVendorType.Properties.GetKeyValueByDisplayValue(lstVendorType.Text).ToString());
                model.CountryId =Convert.ToInt32(lstCountry.Properties.GetKeyValueByDisplayValue(lstCountry.Text).ToString());
                model.CrNo = txtCRNo.Text;
                model.GosiNo = txtGosiNo.Text;
                model.Zakaat = txtZakaat.Text;
                model.ChamberNo = txtChamberNo.Text;
                model.VATExpiry = txtVATExpiry.Text != "" ? txtVATExpiry.DateTime.ToString("dd/MMM/yyyy") : txtVATExpiry.Text;
                model.ChamberNoExpiry = txtChamberExpiry.Text != "" ? txtChamberExpiry.DateTime.ToString("dd/MMM/yyyy") : txtChamberExpiry.Text;
                model.CrNoExpiry = txtCRExpiry.Text != "" ? txtCRExpiry.DateTime.ToString("dd/MMM/yyyy") : txtCRExpiry.Text;
                model.GosiNoExpiry = txtGosiExpiry.Text != "" ? txtGosiExpiry.DateTime.ToString("dd/MMM/yyyy") : txtGosiExpiry.Text;
                model.ZakaatExpiry = txtZakaatExpiry.Text != "" ? txtZakaatExpiry.DateTime.ToString("dd/MMM/yyyy") : txtZakaatExpiry.Text;


                model = vendor.Update(model);

                if (model.VendorId > 0)
                {   
                    MessageBox.Show("Successfully Saved..");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                if (VendorId == 0)
                {
                    Insert();
                }
                else
                {
                    Update();
                }
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
