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
    public partial class FinancialYear : Form
    {
        DBFunctionRepository repo = new DBFunctionRepository();
        public int FyId;
        public FinancialYear()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
             
        }
        void Insert()
        {
            try
            {

                String query = "INSERT INTO dbo.FinancialYear (FyName, FyFrom, FyTo) VALUES(@FyName, @FyFrom, @FyTo)";

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@FyName", txtFYName.Text));
                param.Add(new SqlParameter("@FyFrom", mskFrom.Text));
                param.Add(new SqlParameter("@FyTo", mskTo.Text));

                int count = repo.ExecuteQueryWithParameters(query, param);

                if (count>0)
                {
                    MessageBox.Show("Successfully Saved.");
                }
                else
                {
                    MessageBox.Show("Data not saved.");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        void UpdateFy()
        {
            try
            {
                string sql = @"update FinancialYear set FyName = '" + txtFYName.Text + "', FyFrom = '" + mskFrom.Text + "', FyTo = '" + mskTo.Text + "' where FyID = " + FyId.ToString() + ";select @@ROWCOUNT";
                DataSet ds = repo.fillComboDataset(sql);
                if (ds.Tables[0].Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show("Successfully Updated.");
                }
                else
                {
                    MessageBox.Show("Data not saved.");
                }
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.InnerException.Message : ex.Message);
            }
        }
        private bool Validate()
        {
            if(txtFYName.Text == "")
            {
                MessageBox.Show("Please enter Financial Year Name.");
                txtFYName.Focus();
                return false;
            }
            if (mskFrom.Text == "")
            {
                MessageBox.Show("Please enter Financial Start Date.");
                mskFrom.Focus();
                return false;
            }
            if (mskTo.Text == "")
            {
                MessageBox.Show("Please enter Financial End Date.");
                mskTo.Focus();
                return false;
            }
            return true;
        }

        private void FinancialYear_Load(object sender, EventArgs e)
        {
            if(FyId != 0)
            {
                LoadFinancialYear();
            }
        }
        void LoadFinancialYear()
        {
            try
            {
                string sql = "select FyName, FyFrom, FyTo from FinancialYear where FyID = " + FyId.ToString();
                DataSet ds = repo.fillComboDataset(sql);
                txtFYName.Text = ds.Tables[0].Rows[0]["FyName"].ToString();
                mskFrom.DateTime = DateTime.Parse(ds.Tables[0].Rows[0]["FyFrom"].ToString());
                mskTo.DateTime = DateTime.Parse(ds.Tables[0].Rows[0]["FyTo"].ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private void cmdSave_Click_1(object sender, EventArgs e)
        {
            if (Validate())
            {
                if (FyId == 0)
                    Insert();
                else
                    UpdateFy();
            }  
        }

        private void FinancialYear_Click(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
