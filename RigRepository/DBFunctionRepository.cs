using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RigRepository
{
    public class DBFunctionRepository:DBConnectionRepository
    {
        public SqlDataAdapter execAdapter(string qry)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                OpenConnection();
                cmd.Connection = getConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = qry;

                da.SelectCommand = cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                closeConneCtion();
            }


            return da;
        }

        public void execQry(string qry)
        {
            SqlCommand cmd = new SqlCommand();
            
            try
            {
                OpenConnection();
                cmd.Connection = getConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = qry;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                closeConneCtion();
            }
        }
        public void execQry(string qry, List<SqlParameter> param)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                OpenConnection();
                cmd.Connection = getConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = qry;
                if (param.Count > 0)
                {
                    foreach (SqlParameter p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                closeConneCtion();
            }
        }

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            return dTable;
        }

        public SqlDataReader execReader(string qry)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            OpenConnection();
            cmd.Connection = getConnection();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = qry;
            dr = cmd.ExecuteReader();
            cmd.Dispose();

            return dr;
        }

        public string execScalar(string qry)
        {
            SqlCommand cmd = new SqlCommand();
            
            string res = "";
            try
            {
                OpenConnection();
                cmd.Connection = getConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = qry;
                res = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                closeConneCtion();
                cmd.Dispose();
            }
            return res;
        }

        public List<SqlParameter> executeStoredProc(string procName, List<SqlParameter> param)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                OpenConnection();
                cmd.Connection = getConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procName;

                cmd.Parameters.Clear();

                if (param.Count > 0)
                {
                    foreach (SqlParameter p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                }

                cmd.ExecuteNonQuery();

            }
            catch
            {
                return param;

            }
            finally
            {
                int i = 0;
                foreach (SqlParameter p in cmd.Parameters)
                {
                    if (p.Direction == ParameterDirection.Output)
                    {
                        param[i].Value = p.Value;
                    }
                    i++;
                }

                closeConneCtion();
                cmd.Dispose();
            }

            return param;
        }

        public DataSet fillComboDataset(string query)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet DS = new DataSet();
            SqlDataAdapter DA = new SqlDataAdapter();
            try
            {
                OpenConnection();
                cmd.Connection = getConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.CommandTimeout = 10000;
                DA.SelectCommand = cmd;
                DA.Fill(DS, "DATA");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                closeConneCtion();
                cmd.Dispose();
            }
            return DS;
        }

        public DataSet FillDataSetAsXml(string procName, List<SqlParameter> param)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet DS = new DataSet();
            XmlReader XR;
            try
            {
                OpenConnection();
                cmd.Connection = getConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procName;
                cmd.Parameters.Clear();
                cmd.CommandTimeout = 10000;
                if (param.Count > 0)
                {
                    foreach (SqlParameter p in param)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                XR = cmd.ExecuteXmlReader();
                DS.ReadXml(XR);
            }
            catch
            {
                return DS;
            }
            finally
            {
                closeConneCtion();
                cmd.Dispose();
            }

            return DS;
        }

        public DataSet fillDatasetNonXml(string procName, List<SqlParameter> param)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet Ds = new DataSet();
            SqlDataAdapter Da = new SqlDataAdapter();
            try
            {
                OpenConnection();
                cmd.Connection = getConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procName;
                cmd.CommandTimeout = 10000;
                cmd.Parameters.Clear();

                if (param.Count > 0)
                {
                    foreach (SqlParameter p in param)
                    {
                        cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                    }
                }

                Da.SelectCommand = cmd;
                Da.Fill(Ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                closeConneCtion();
                cmd.Dispose();
            }

            return Ds;
        }
        public int ExecuteQueryWithParameters(string Query, List<SqlParameter> parameter, string ReturnId = "No")
        {
            SqlCommand cmd;
            int count = 0;
            try
            {
                cmd = new SqlCommand(Query, getConnection());
                OpenConnection();

                cmd = new SqlCommand(Query, getConnection());

                if (parameter.Count > 0)
                {
                    foreach (SqlParameter p in parameter)
                    {
                        cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                    }
                }
                if (ReturnId == "No")
                {
                    count = cmd.ExecuteNonQuery();
                }
                else
                {
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                closeConneCtion();
            }

            return count;
        }
    }
}
