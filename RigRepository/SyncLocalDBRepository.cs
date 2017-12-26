using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RigRepository
{
    public class SyncLocalDBRepository
    {
        DBFunctionRepository fun = new DBFunctionRepository();
        SQLiteFunctionRepository temp = new SQLiteFunctionRepository();

        public bool SyncVendorType()
        {
            try
            {
                VendorRepository vendor = new VendorRepository();
                vendor.CreateVendorTypeTable();
                vendor.CreateVendorTable();

                string query = @"select VendorTypeId, VendorTypeName from VendorType";
                DataSet ds = fun.fillComboDataset(query);
                if(ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                {
                    query = "Delete from VendorType";
                    temp.ExecuteQuery(query);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        query = String.Format(@"INSERT INTO VendorType(VendorTypeId, VendorTypeName)
                        VALUES({0},'{1}')", dr["VendorTypeId"].ToString(), dr["VendorTypeName"].ToString());
                        temp.ExecuteQuery(query);
                    }
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return true;
        }
        public bool SyncCountry()
        {
            try
            {
                string query = @"SELECT name FROM sqlite_master WHERE type='table' AND name='Country';";
                DataSet ds = temp.fillComboDataset(query);
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    query = @"CREATE TABLE [Country](
	                [CountryId] [int] NOT NULL,
	                [CountryName] [varchar](500) NOT NULL,
	                [Region] [varchar](50) NOT NULL)";
                    temp.ExecuteQuery(query);
                }
                query = @"select CountryId, CountryName, Region from Country";
                ds = fun.fillComboDataset(query);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    query = "Delete from Country";
                    temp.ExecuteQuery(query);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        query = String.Format(@"INSERT INTO Country(CountryId, CountryName, Region)
                        VALUES({0},'{1}','{2}')", dr["CountryId"].ToString(), dr["CountryName"].ToString(), dr["Region"].ToString());
                        temp.ExecuteQuery(query);
                    }
                }

            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return true;
        }
    }
}
