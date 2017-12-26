using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RigRepository
{
    public class VendorRepository
    {
        DBFunctionRepository fun = new DBFunctionRepository();
        SQLiteFunctionRepository temp = new SQLiteFunctionRepository();

        public void CreateVendorTypeTable()
        {
            try
            {
                string query = @"SELECT name FROM sqlite_master WHERE type='table' AND name='VendorType';";
                DataSet ds = temp.fillComboDataset(query);
                if(ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    query = @"CREATE TABLE [VendorType](
	                [VendorTypeId] [int] NOT NULL,
	                [VendorTypeName] [varchar](50) NOT NULL
                    )";
                    temp.ExecuteQuery(query);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public void CreateVendorTable()
        {
            try
            {
                string query = @"SELECT name FROM sqlite_master WHERE type='table' AND name='Vendor';";
                DataSet ds = temp.fillComboDataset(query);
                if(ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    query = @"CREATE TABLE [Vendor](
	                [VendorId] [int] NOT NULL,
	                [VendorCode] [varchar](50) NULL,
	                [VendorName] [varchar](50) NOT NULL,
	                [Address] [varchar](500) NULL,
	                [PhoneNumber] [varchar](50) NULL,
	                [City] [varchar](50) NULL,
	                [FAX] [varchar](50) NULL,
	                [VAT] [varchar](50) NULL,
	                [ContactPerson] [varchar](50) NULL,
	                [Email] [varchar](50) NULL,
	                [VendorTypeId] [int] NULL,
	                [CountryId] [int] NULL,
	                [CrNo] [varchar](50) NULL,
	                [GosiNo] [varchar](50) NULL,
	                [Zakaat] [varchar](50) NULL,
	                [ChamberNo] [varchar](50) NULL,
	                [VATExpiry] [datetime] NULL,
	                [ChamberNoExpiry] [datetime] NULL,
	                [CrNoExpiry] [datetime] NULL,
	                [GosiNoExpiry] [datetime] NULL,
	                [ZakaatExpiry] [datetime] NULL
	                )";
                    temp.ExecuteQuery(query);
                }                
            }   
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
