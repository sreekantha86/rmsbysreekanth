using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    string query = @"select VendorTypeId, VendorTypeName from VendorType";
                    DataSet ds = fun.fillComboDataset(query);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
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
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return true;
        }
        public bool SyncVendorMaster()
        {
            try
            {
                string query = @"SELECT name FROM sqlite_master WHERE type='table' AND name='Vendor';";
                DataSet ds = temp.fillComboDataset(query);
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    query = @"CREATE TABLE [dbo].[Vendor](
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
	                [ZakaatExpiry] [datetime] NULL)";
                    temp.ExecuteQuery(query);
                }
                fun.OpenConnection();
                if (fun.getConnection().State == ConnectionState.Open)
                {
                    query = @"SELECT [VendorId]
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
                        FROM [dbo].[Vendor]";
                    ds = fun.fillComboDataset(query);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        query = "Delete from Vendor";
                        temp.ExecuteQuery(query);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            query = @"INSERT INTO [Vendor]([VendorId]
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
                            ,[ZakaatExpiry])
                        VALUES(
                             @VendorId
                            ,@VendorCode
                            ,@VendorName
                            ,@Address
                            ,@PhoneNumber
                            ,@City
                            ,@FAX
                            ,@VAT
                            ,@ContactPerson
                            ,@Email
                            ,@VendorTypeId
                            ,@CountryId
                            ,@CrNo
                            ,@GosiNo
                            ,@Zakaat
                            ,@ChamberNo
                            ,@VATExpiry
                            ,@ChamberNoExpiry
                            ,@CrNoExpiry
                            ,@GosiNoExpiry
                            ,@ZakaatExpiry)";
                            List<SQLiteParameter> param = new List<SQLiteParameter>();
                            param.Add(new SQLiteParameter("@VendorId", dr["VendorId"]));
                            param.Add(new SQLiteParameter("@VendorCode", dr["VendorCode"]));
                            param.Add(new SQLiteParameter("@VendorName", dr["VendorName"]));
                            param.Add(new SQLiteParameter("@Address", dr["Address"]));
                            param.Add(new SQLiteParameter("@PhoneNumber", dr["PhoneNumber"]));
                            param.Add(new SQLiteParameter("@City", dr["City"]));
                            param.Add(new SQLiteParameter("@FAX", dr["FAX"]));
                            param.Add(new SQLiteParameter("@VAT", dr["VAT"]));
                            param.Add(new SQLiteParameter("@ContactPerson", dr["ContactPerson"]));
                            param.Add(new SQLiteParameter("@Email", dr["Email"]));
                            param.Add(new SQLiteParameter("@VendorTypeId", dr["VendorTypeId"]));
                            param.Add(new SQLiteParameter("@CountryId", dr["CountryId"]));
                            param.Add(new SQLiteParameter("@CrNo", dr["CrNo"]));
                            param.Add(new SQLiteParameter("@GosiNo", dr["GosiNo"]));
                            param.Add(new SQLiteParameter("@Zakaat", dr["Zakaat"]));
                            param.Add(new SQLiteParameter("@ChamberNo", dr["ChamberNo"]));
                            param.Add(new SQLiteParameter("@VATExpiry", dr["VATExpiry"]));
                            param.Add(new SQLiteParameter("@ChamberNoExpiry", dr["ChamberNoExpiry"]));
                            param.Add(new SQLiteParameter("@CrNoExpiry", dr["CrNoExpiry"]));
                            param.Add(new SQLiteParameter("@GosiNoExpiry", dr["GosiNoExpiry"]));
                            param.Add(new SQLiteParameter("@ZakaatExpiry", dr["ZakaatExpiry"]));
                            temp.ExecuteQuery(query,param);
                        }
                    }
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return true;
        }
        public bool SyncLocation()
        {
            try
            {
                string query = @"SELECT name FROM sqlite_master WHERE type='table' AND name='Location';";
                DataSet ds = temp.fillComboDataset(query);
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    query = @"CREATE TABLE Location(
	                [LocId] [int] NOT NULL,
	                [LocCode] [varchar](50) NOT NULL,
	                [LocName] [varchar](500) NOT NULL,
	                [LocLatitude] [varchar](500) NOT NULL,
	                [LocLongitude] [varchar](500) NOT NULL,
	                [LocRemarks] [varchar](5000) NULL)";
                    temp.ExecuteQuery(query);
                }

                fun.OpenConnection();
                if (fun.getConnection().State == ConnectionState.Open)
                {
                    query = @"select LocId
                                ,LocCode
                                ,LocName
                                ,LocLatitude
                                ,LocLongitude
                                ,LocRemarks
                                FROM Location";
                    ds = fun.fillComboDataset(query);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        query = "Delete from Location";
                        temp.ExecuteQuery(query);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            query = @"INSERT INTO Location(
                                 LocId
                                ,LocCode
                                ,LocName
                                ,LocLatitude
                                ,LocLongitude
                                ,LocRemarks)
                                VALUES(
                                 @LocId
                                ,@LocCode
                                ,@LocName
                                ,@LocLatitude
                                ,@LocLongitude
                                ,@LocRemarks)
                                ";

                            List<SQLiteParameter> param = new List<SQLiteParameter>();
                            param.Add(new SQLiteParameter("@LocId", dr["LocId"]));
                            param.Add(new SQLiteParameter("@LocCode", dr["LocCode"]));
                            param.Add(new SQLiteParameter("@LocName", dr["LocName"]));
                            param.Add(new SQLiteParameter("@LocLatitude", dr["LocLatitude"]));
                            param.Add(new SQLiteParameter("@LocLongitude", dr["LocLongitude"]));
                            param.Add(new SQLiteParameter("@LocRemarks", dr["LocRemarks"]));

                            temp.ExecuteQuery(query, param);
                        }
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
