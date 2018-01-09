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
            if (!CheckTempDB())
            {
                MessageBox.Show("Configuring Temp DB failed. Please contact System Administrator");
            }
            //this.Hide();
            //HomePage page = new HomePage();
            //page.Show();
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter user name.");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password.");
                txtPassword.Focus();
                return;
            }
            if (lstFinancialYear.Text == "")
            {
                MessageBox.Show("Please select Financial Year.");
                lstFinancialYear.Focus();
                return;
            }
            if (VerifyUser())
            {
                //Program.FinancialYearId = Convert.ToInt32(lstFinancialYear.Properties.GetKeyValueByDisplayValue(lstFinancialYear.Text).ToString());
                //Program.FinancialYearName = lstFinancialYear.Text;
                this.Hide();
                HomePage page = new HomePage();
                //var page = (Form)Activator.CreateInstance(Type.GetType("RigServiceSystem.HomePage"));
                page.Show();
            }
            else
            {
                MessageBox.Show("Either Username or Password is Wrong.");
            }
            
        }
        bool VerifyUser()
        {
            try
            {
                string saltPrefix = ConfigurationManager.AppSettings["saltPrefix"].ToString();
                string saltSuffix = ConfigurationManager.AppSettings["saltSuffix"].ToString();
                string saltedPassword = String.Format("{0}{1}{2}", saltPrefix, txtPassword.Text, saltSuffix);
                string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(saltedPassword, "sha1");

                return GetUserData(txtUserName.Text, hashedPassword);
                
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
        private bool CheckTempDB()
        {
            try
            {
                SQLiteFunctionRepository tempRep = new SQLiteFunctionRepository();
                UserRepository repo = new UserRepository();
                if(!tempRep.IsTempDBExists())
                {
                    tempRep.CreateSqlLiteDatabase();
                    repo.CreateUserTable();
                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:" + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
                return false;
            }
        }
        private bool GetUserData(string username, string password)
        {
            try
            {
                UserRepository tCon = new UserRepository();
                DataSet ds = tCon.GetUserData(username, password);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
                return false;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Convert.ToInt32(e.KeyChar) == 13)
            {
                if(txtPassword.Text == "")
                {
                    MessageBox.Show("Please enter password");
                    txtPassword.Focus();
                    return;
                }
                else
                {
                    btnLogin_Click(sender, e);
                }
            }
        }
    }
}
