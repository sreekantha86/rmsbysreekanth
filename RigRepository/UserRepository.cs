using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RigRepository
{
    public class UserRepository
    {
        DBFunctionRepository fun = new DBFunctionRepository();
        SQLiteFunctionRepository temp = new SQLiteFunctionRepository();

        public void CreateUserTable()
        {
            try
            {
                string query = @"CREATE TABLE Users(
	            [UserId] [int] NOT NULL,
	            [UserName] [varchar](50) NOT NULL,
	            [UserPassword] [varchar](500) NOT NULL,
	            [UserFullName] [varchar](500) NULL,
	            [ContactNumber] [varchar](50) NULL,
	            [EmailId] [varchar](50) NULL,
	            [RoleId] [int] NOT NULL
	            )";
                temp.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetUserData(string username, string password)
        {
            try
            {
                string @query = String.Format(@"select UserId, UserName, UserPassword, UserFullName,ContactNumber, EmailId, RoleId 
                                from [Users]
                                where UserName='{0}' and UserPassword='{1}'",username, password);
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    DataSet ds = fun.fillComboDataset(query);
                    temp.ExecuteQuery("Delete from [Users]");
                    temp.ExecuteQuery(String.Format(@"INSERT INTO [Users](UserId, UserName, UserPassword, UserFullName,ContactNumber, EmailId, RoleId)
                     VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}')",ds.Tables[0].Rows[0]["UserId"]
                                                                     ,ds.Tables[0].Rows[0]["UserName"]
                                                                     ,ds.Tables[0].Rows[0]["UserPassword"]
                                                                     ,ds.Tables[0].Rows[0]["UserFullName"]
                                                                     ,ds.Tables[0].Rows[0]["ContactNumber"]
                                                                     ,ds.Tables[0].Rows[0]["EmailId"]
                                                                     ,ds.Tables[0].Rows[0]["RoleId"]));
                    return ds;
                }
                else
                {
                    return temp.fillComboDataset(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddToFavoriteForms(string FormName, string TitleName, string UserId)
        {
            try
            {
                string query = @"INSERT INTO [UserFavoriteForms](UserId, FormName, FormTitle)
                VALUES(@UserId, @FormName, @FormTitle)";

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@UserId", UserId));
                param.Add(new SqlParameter("@FormName", FormName));
                param.Add(new SqlParameter("@FormTitle", TitleName));

                fun.OpenConnection();
                fun.execQry(query,param);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataSet FillFavorites(string userId)
        {
            try
            {
                string query = @"select FormName, FormTitle from UserFavoriteForms where UserId = " + userId.ToString();
                DataSet ds = fun.fillComboDataset(query);
                return ds;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
