using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigRepository
{
    public class DBConnectionRepository
    {
        string conString;
        private SqlConnection con;

        public void OpenConnection()
        {
            try
            {
                conString = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ToString();
                con = new SqlConnection(conString);
                con.Open();
            }
            catch
            {
                con.Close();
                con.Open();
            }
        }
        public void closeConneCtion()
        {
            try
            {
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return con;
        }
    }
}
