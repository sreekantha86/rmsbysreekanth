using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RigRepository;
using System.Configuration;
using System.Web.Security;
namespace RigServiceSystem
{
    public partial class Login : Form
    {
        DBFunctionRepository repo = new DBFunctionRepository();
        public Login()
        {
            InitializeComponent();            
        }

        void fillFinancialYear()
        {
            //DataSet ds = repo.fillComboDataset("select FyID, FyName from FinancialYear;");            
            //lstFinancialYear.Properties.DataSource = ds.Tables[0];
            //lstFinancialYear.Properties.DisplayMember = "FyName";
            //lstFinancialYear.Properties.ValueMember = "FyID";
            //lstFinancialYear.Properties.NullText = "";
            //lstFinancialYear.Properties.PopulateColumns();
            //lstFinancialYear.Properties.Columns["FyID"].Visible = false;
            //lstFinancialYear.Properties.ShowHeader = false;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage page = new HomePage();
            page.Show();
            //if (txtUserName.Text == "")
            //{
            //    MessageBox.Show("Please enter user name.");
            //    txtUserName.Focus();
            //    return;
            //}
            //if (txtPassword.Text == "")
            //{
            //    MessageBox.Show("Please enter password.");
            //    txtPassword.Focus();
            //    return;
            //}
            //if(lstFinancialYear.Text == "")
            //{
            //    MessageBox.Show("Please select Financial Year.");
            //    lstFinancialYear.Focus();
            //    return;
            //}
            //if(VerifyUser())
            //{
            //    Program.FinancialYearId = Convert.ToInt32(lstFinancialYear.Properties.GetKeyValueByDisplayValue(lstFinancialYear.Text).ToString());
            //    Program.FinancialYearName = lstFinancialYear.Text;
            //    this.Hide();
            //    HomePage page = new HomePage();
            //    page.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Either Username or Password is Wrong.");
            //}
            
        }
        bool VerifyUser()
        {
            try
            {
                string saltPrefix = ConfigurationManager.AppSettings["saltPrefix"].ToString();
                string saltSuffix = ConfigurationManager.AppSettings["saltSuffix"].ToString();
                string saltedPassword = String.Format("{0}{1}{2}", saltPrefix, txtPassword.Text, saltSuffix);
                string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(saltedPassword, "sha1");

                string query = "select * from Users where username = '" + txtUserName.Text + "' and UserPassword = '" + hashedPassword + "';";
                DataSet ds = repo.fillComboDataset(query);
                if(ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                {
                    Program.UserName = ds.Tables[0].Rows[0]["UserFullName"].ToString();
                    Program.UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:" + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
                return false;
            }
            return true;
        }
        private void Login_Load(object sender, EventArgs e)
        {
            fillFinancialYear();
        }
    }
}
