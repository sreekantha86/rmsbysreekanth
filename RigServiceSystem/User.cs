using RigRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace RigServiceSystem
{
    public partial class User : Form
    {
        DBFunctionRepository repo = new DBFunctionRepository();
        public int UserId;
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            FillUserRole();
            if(UserId != 0)
            {
                ShowUser();
            }
        }
        void ShowUser()
        {
            try
            {
                string query = @"SELECT [UserId]
                              ,[UserName]
                              ,[UserPassword]
                              ,[UserFullName]
                              ,[ContactNumber]
                              ,[EmailId]
                              ,[RoleId]
                              ,[Position]
                          FROM [dbo].[Users] WHERE [UserId] = " + UserId.ToString();

                DataSet ds = repo.fillComboDataset(query);
                if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        txtUserName.Text = dr["UserName"].ToString();
                        txtContactNumber.Text = dr["ContactNumber"].ToString();
                        txtEmployeeName.Text = dr["UserFullName"].ToString();
                        txtEmailId.Text = dr["EmailId"].ToString();
                        lstUserRole.EditValue = Convert.ToInt32(dr["RoleId"].ToString());
                        txtPosition.Text = dr["Position"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        private void FillUserRole()
        {
            DataSet ds = repo.fillComboDataset("select RoleId, RoleName from UserRole;");
            lstUserRole.Properties.DataSource = ds.Tables[0];
            lstUserRole.Properties.DisplayMember = "RoleName";
            lstUserRole.Properties.ValueMember = "RoleId";
            lstUserRole.Properties.NullText = "";
            lstUserRole.Properties.PopulateColumns();
            lstUserRole.Properties.Columns["RoleId"].Visible = false;
            lstUserRole.Properties.ShowHeader = false;
        }

        private void Insert()
        {
            try
            {
                string saltPrefix = ConfigurationManager.AppSettings["saltPrefix"].ToString();
                string saltSuffix = ConfigurationManager.AppSettings["saltSuffix"].ToString();
                string saltedPassword = String.Format("{0}{1}{2}", saltPrefix, txtPassword.Text, saltSuffix);
                string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(saltedPassword, "sha1");

                string query = @"INSERT INTO [dbo].[Users]
                               ([UserName]
                               ,[UserPassword]
                               ,[UserFullName]
                               ,[ContactNumber]
                               ,[EmailId]
                               ,[RoleId]
                               ,[Position])
                         VALUES
                               (@UserName
                               ,@UserPassword
                               ,@UserFullName
                               ,@ContactNumber
                               ,@EmailId
                               ,@RoleId
                               ,@Position)";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@UserName", txtUserName.Text));
                param.Add(new SqlParameter("@UserPassword", hashedPassword));
                param.Add(new SqlParameter("@UserFullName", txtEmployeeName.Text));
                param.Add(new SqlParameter("@ContactNumber", txtContactNumber.Text));
                param.Add(new SqlParameter("@EmailId", txtEmailId.Text));
                param.Add(new SqlParameter("@RoleId", lstUserRole.EditValue));
                param.Add(new SqlParameter("@Position", txtPosition.Text));

                int count = repo.ExecuteQueryWithParameters(query, param);

                if (count > 0)
                {
                    MessageBox.Show("Successfully Saved.");
                }
                else
                {
                    MessageBox.Show("Data not saved.");
                }
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        void Update()
        {
            try
            {
                string query = @"UPDATE Users
                                SET UserName = @UserName
                                ,UserFullName = @UserFullName
                                ,ContactNumber = @ContactNumber
                                ,EmailId = @EmailId
                                ,RoleId = @RoleId
                                ,Position = @Position
                                WHERE UserId = " + UserId.ToString();

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@UserName", txtUserName.Text));
                param.Add(new SqlParameter("@UserFullName", txtEmployeeName.Text));
                param.Add(new SqlParameter("@ContactNumber", txtContactNumber.Text));
                param.Add(new SqlParameter("@EmailId", txtEmailId.Text));
                param.Add(new SqlParameter("@RoleId", lstUserRole.EditValue));
                param.Add(new SqlParameter("@Position", txtPosition.Text));

                int count = repo.ExecuteQueryWithParameters(query, param);
                if (count > 0)
                {
                    if(txtPassword.Text != "")
                    {
                        if(MessageBox.Show("Do you want to reset password?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            string saltPrefix = ConfigurationManager.AppSettings["saltPrefix"].ToString();
                            string saltSuffix = ConfigurationManager.AppSettings["saltSuffix"].ToString();
                            string saltedPassword = String.Format("{0}{1}{2}", saltPrefix, txtPassword.Text, saltSuffix);
                            string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(saltedPassword, "sha1");

                            query = @"UPDATE Users
                                SET UserPassword = @UserPassword
                                WHERE UserId = " + UserId.ToString();

                            List<SqlParameter> param1 = new List<SqlParameter>();
                            param1.Add(new SqlParameter("@UserPassword", hashedPassword));

                            int pass = repo.ExecuteQueryWithParameters(query, param1);

                            if(pass > 0)
                            {
                                MessageBox.Show("Password successfully reset.");
                            }
                            else
                            {
                                MessageBox.Show("Password reset failed.");
                            }
                        }
                    }
                    MessageBox.Show("Successfully Updated.");
                }
                else
                {
                    MessageBox.Show("Data not updated.");
                }
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        private bool Validate()
        {
            if(txtUserName.Text == "")
            {
                MessageBox.Show("Please enter username");
                txtUserName.Focus();
                return false;
            }
            if(UserId == 0)
            {
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Please enter password");
                    txtPassword.Focus();
                    return false;
                }
                if (txtPassword.Text.Length < 5)
                {
                    MessageBox.Show("Password have atleast 5 charector.");
                    txtPassword.Focus();
                    return false;
                }
            }
            
            if (lstUserRole.EditValue == "")
            {
                MessageBox.Show("Please select user Role");
                lstUserRole.Focus();
                return false;
            }
            return true;
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSave_Click_1(object sender, EventArgs e)
        {
            if (Validate())
            {
                if (UserId == 0)
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
