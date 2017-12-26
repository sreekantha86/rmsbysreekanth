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
        DBFunctionRepository repo = new DBFunctionRepository();
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
                string sql = @"SELECT [VendorId]
                              ,[VendorCode]
                              ,[VendorName]
                              ,[Address]
                              ,[PhoneNumber]
                              ,[City]
                              ,[FAX]
                              ,[VAT]
                              ,[ContactPerson]
                              ,[Email]
                              ,[VendorTypeId]
                              ,[CountryId]
                              ,[CrNo]
                              ,[GosiNo]
                              ,[Zakaat]
                              ,[ChamberNo]
                              ,[VATExpiry]
                              ,[ChamberNoExpiry]
                              ,[CrNoExpiry]
                              ,[GosiNoExpiry]
                              ,[ZakaatExpiry]
                          FROM [dbo].[Vendor] WHERE [VendorId] = " + VendorId.ToString();

                DataSet ds = repo.fillComboDataset(sql);

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
            DataSet ds = repo.fillComboDataset("select CountryId, CountryName from Country;");
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
            DataSet ds = repo.fillComboDataset("select VendorTypeId, VendorTypeName from VendorType;");
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
                string sql = @"INSERT INTO Vendor
                               (VendorCode
                               ,VendorName
                               ,Address
                               ,PhoneNumber
                               ,City
                               ,FAX
                               ,VAT
                               ,ContactPerson
                               ,Email
                               ,CrNo
                               ,GosiNo
                               ,Zakaat
                               ,ChamberNo
                               ,VATExpiry
                               ,ChamberNoExpiry
                               ,CrNoExpiry
                               ,GosiNoExpiry
                               ,ZakaatExpiry)
                         output INSERTED.VendorId
                         VALUES
                               (@VendorCode
                               ,@VendorName
                               ,@Address
                               ,@PhoneNumber
                               ,@City
                               ,@FAX
                               ,@VAT
                               ,@ContactPerson
                               ,@Email
                               ,@CrNo
                               ,@GosiNo
                               ,@Zakaat
                               ,@ChamberNo
                               ,@VATExpiry
                               ,@ChamberNoExpiry
                               ,@CrNoExpiry
                               ,@GosiNoExpiry
                               ,@ZakaatExpiry)";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@VendorCode", txtVendorCode.Text));
                param.Add(new SqlParameter("@VendorName", txtName.Text));
                param.Add(new SqlParameter("@Address", txtAdress.Text));
                param.Add(new SqlParameter("@PhoneNumber", txtPhoneNumber.Text));
                param.Add(new SqlParameter("@City", txtCity.Text));
                param.Add(new SqlParameter("@FAX", txtFax.Text));
                param.Add(new SqlParameter("@VAT", txtVat.Text));
                param.Add(new SqlParameter("@ContactPerson", txtContactPerson.Text));
                param.Add(new SqlParameter("@Email", txtEmail.Text));
                param.Add(new SqlParameter("@CrNo", txtCRNo.Text));
                param.Add(new SqlParameter("@GosiNo", txtGosiNo.Text));
                param.Add(new SqlParameter("@Zakaat", txtZakaat.Text));
                param.Add(new SqlParameter("@ChamberNo", txtChamberNo.Text));

                if (txtVATExpiry.Text == "")
                    param.Add(new SqlParameter("@VATExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@VATExpiry", txtVATExpiry.DateTime.ToString("dd/MMM/yyyy")));

                if (txtChamberExpiry.Text == "")
                    param.Add(new SqlParameter("@ChamberNoExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@ChamberNoExpiry", txtChamberExpiry.DateTime.ToString("dd/MMM/yyyy")));

                if (txtCRExpiry.Text == "")
                    param.Add(new SqlParameter("@CrNoExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@CrNoExpiry", txtCRExpiry.DateTime.ToString("dd/MMM/yyyy")));

                if (txtGosiExpiry.Text == "")
                    param.Add(new SqlParameter("@GosiNoExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@GosiNoExpiry", txtGosiExpiry.DateTime.ToString("dd/MMM/yyyy")));

                if (txtZakaatExpiry.Text == "")
                    param.Add(new SqlParameter("@ZakaatExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@ZakaatExpiry", txtZakaatExpiry.DateTime.ToString("dd/MMM/yyyy")));

                int Id = repo.ExecuteQueryWithParameters(sql, param, "Yes");

                if (Id > 0)
                {
                    if (lstCountry.Text != "")
                    {
                        sql = @"Update Vendor set CountryId = '" + lstCountry.Properties.GetKeyValueByDisplayValue(lstCountry.Text).ToString() + @"'
                                where VendorId = " + Id.ToString();
                        repo.execQry(sql);
                    }
                    if (lstVendorType.Text != "")
                    {
                        sql = @"Update Vendor set VendorTypeId = '" + lstVendorType.Properties.GetKeyValueByDisplayValue(lstVendorType.Text).ToString() + @"'
                                where VendorId = " + Id.ToString();
                        repo.execQry(sql);
                    }
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
                string sql = @"UPDATE [dbo].[Vendor] SET
                                [VendorCode] = @VendorCode
                               ,[VendorName] = @VendorName
                               ,[Address] = @Address
                               ,[PhoneNumber] = @PhoneNumber
                               ,[City] = @City
                               ,[FAX] = @FAX
                               ,[VAT] = @VAT
                               ,[ContactPerson] = @ContactPerson
                               ,[Email] = @Email
                               ,[CrNo] = @CrNo
                               ,[GosiNo] = @GosiNo
                               ,[Zakaat] = @Zakaat
                               ,[ChamberNo] = @ChamberNo
                               ,[VATExpiry] = @VATExpiry
                               ,[ChamberNoExpiry] = @ChamberNoExpiry
                               ,[CrNoExpiry] = @CrNoExpiry
                               ,[GosiNoExpiry] = @GosiNoExpiry
                               ,[ZakaatExpiry] = @ZakaatExpiry
                         WHERE VendorId = '" + VendorId + @"'";

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@VendorCode", txtVendorCode.Text));
                param.Add(new SqlParameter("@VendorName", txtName.Text));
                param.Add(new SqlParameter("@Address", txtAdress.Text));
                param.Add(new SqlParameter("@PhoneNumber", txtPhoneNumber.Text));
                param.Add(new SqlParameter("@City", txtCity.Text));
                param.Add(new SqlParameter("@FAX", txtFax.Text));
                param.Add(new SqlParameter("@VAT", txtVat.Text));
                param.Add(new SqlParameter("@ContactPerson", txtContactPerson.Text));
                param.Add(new SqlParameter("@Email", txtEmail.Text));
                param.Add(new SqlParameter("@CrNo", txtCRNo.Text));
                param.Add(new SqlParameter("@GosiNo", txtGosiNo.Text));
                param.Add(new SqlParameter("@Zakaat", txtZakaat.Text));
                param.Add(new SqlParameter("@ChamberNo", txtChamberNo.Text));

                if (txtVATExpiry.Text == "")
                     param.Add(new SqlParameter("@VATExpiry", System.DBNull.Value));
                else
                     param.Add(new SqlParameter("@VATExpiry", txtVATExpiry.DateTime.ToString("dd/MMM/yyyy")));

                if (txtChamberExpiry.Text == "")
                    param.Add(new SqlParameter("@ChamberNoExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@ChamberNoExpiry", txtChamberExpiry.DateTime.ToString("dd/MMM/yyyy")));

                if (txtCRExpiry.Text == "")
                    param.Add(new SqlParameter("@CrNoExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@CrNoExpiry", txtCRExpiry.DateTime.ToString("dd/MMM/yyyy")));

                if (txtGosiExpiry.Text == "")
                    param.Add(new SqlParameter("@GosiNoExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@GosiNoExpiry", txtGosiExpiry.DateTime.ToString("dd/MMM/yyyy")));

                if (txtZakaatExpiry.Text == "")
                    param.Add(new SqlParameter("@ZakaatExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@ZakaatExpiry", txtZakaatExpiry.DateTime.ToString("dd/MMM/yyyy")));
                                
                int Id = repo.ExecuteQueryWithParameters(sql, param);

                if (Id > 0)
                {                   
                    if (lstCountry.Text != "")
                    {
                        sql = @"Update Vendor set CountryId = '" + lstCountry.Properties.GetKeyValueByDisplayValue(lstCountry.Text).ToString() + @"'
                                where VendorId = " + VendorId.ToString();
                        repo.execQry(sql);
                    }
                    if (lstVendorType.Text != "")
                    {
                        sql = @"Update Vendor set VendorTypeId = '" + lstVendorType.Properties.GetKeyValueByDisplayValue(lstVendorType.Text).ToString() + @"'
                                where VendorId = " + VendorId.ToString();
                        repo.execQry(sql);
                    }
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
