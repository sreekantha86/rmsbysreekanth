using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public DataSet GetVendorData(int Id)
        {
            try
            {
                string sql = @"SELECT [VendorId]
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
                          FROM [dbo].[Vendor] WHERE [VendorId] = " + Id.ToString();
                fun.OpenConnection();
                if(fun.getConnection().State != ConnectionState.Open)
                {
                    return temp.fillComboDataset(sql);
                }
                else
                {
                    return fun.fillComboDataset(sql);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataSet GetCountry()
        {
            try
            {
                string sql = @"select CountryId, CountryName from Country;";
                fun.OpenConnection();
                if(fun.getConnection().State != ConnectionState.Open)
                {
                    return temp.fillComboDataset(sql);
                }
                else
                {
                    return fun.fillComboDataset(sql);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public DataSet GetVendorType()
        {
            try
            {
                string sql = @"select VendorTypeId, VendorTypeName from VendorType;";
                fun.OpenConnection();
                if (fun.getConnection().State != ConnectionState.Open)
                {
                    return temp.fillComboDataset(sql);
                }
                else
                {
                    return fun.fillComboDataset(sql);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VendorModel Insert(VendorModel model)
        {
            int i = 0;
            try
            {
                string sql = @"INSERT INTO Vendor
                               (VendorCode
                               ,VendorName
                               ,Address
                               ,PhoneNumber
                               ,City
                               ,FAX
                               ,VAT
                               ,ContactPerson
                               ,Email
                               ,CrNo
                               ,GosiNo
                               ,Zakaat
                               ,ChamberNo
                               ,VATExpiry
                               ,ChamberNoExpiry
                               ,CrNoExpiry
                               ,GosiNoExpiry
                               ,ZakaatExpiry)
                         output INSERTED.VendorId
                         VALUES
                               (@VendorCode
                               ,@VendorName
                               ,@Address
                               ,@PhoneNumber
                               ,@City
                               ,@FAX
                               ,@VAT
                               ,@ContactPerson
                               ,@Email
                               ,@CrNo
                               ,@GosiNo
                               ,@Zakaat
                               ,@ChamberNo
                               ,@VATExpiry
                               ,@ChamberNoExpiry
                               ,@CrNoExpiry
                               ,@GosiNoExpiry
                               ,@ZakaatExpiry)";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@VendorCode", model.VendorCode));
                param.Add(new SqlParameter("@VendorName", model.VendorName));
                param.Add(new SqlParameter("@Address", model.Address));
                param.Add(new SqlParameter("@PhoneNumber", model.PhoneNumber));
                param.Add(new SqlParameter("@City", model.City));
                param.Add(new SqlParameter("@FAX", model.FAX));
                param.Add(new SqlParameter("@VAT", model.VAT));
                param.Add(new SqlParameter("@ContactPerson", model.ContactPerson));
                param.Add(new SqlParameter("@Email", model.Email));
                param.Add(new SqlParameter("@CrNo", model.CrNo));
                param.Add(new SqlParameter("@GosiNo", model.GosiNo));
                param.Add(new SqlParameter("@Zakaat", model.Zakaat));
                param.Add(new SqlParameter("@ChamberNo", model.ChamberNo));

                if (model.VATExpiry == "")
                    param.Add(new SqlParameter("@VATExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@VATExpiry", model.VATExpiry));

                if (model.ChamberNoExpiry == "")
                    param.Add(new SqlParameter("@ChamberNoExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@ChamberNoExpiry", model.ChamberNoExpiry));

                if (model.CrNoExpiry == "")
                    param.Add(new SqlParameter("@CrNoExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@CrNoExpiry", model.CrNoExpiry));

                if (model.GosiNoExpiry == "")
                    param.Add(new SqlParameter("@GosiNoExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@GosiNoExpiry", model.GosiNoExpiry));

                if (model.ZakaatExpiry == "")
                    param.Add(new SqlParameter("@ZakaatExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@ZakaatExpiry", model.ZakaatExpiry));

                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    int Id = fun.ExecuteQueryWithParameters(sql, param, "Yes");
                    if (Id>0)
                    {
                        if (model.CountryId>0)
                        {
                            sql = @"Update Vendor set CountryId = '" + model.CountryId.ToString() + @"'
                                where VendorId = " + Id.ToString();
                            fun.execQry(sql);
                        }
                        if (model.VendorTypeId >0)
                        {
                            sql = @"Update Vendor set VendorTypeId = '" + model.VendorTypeId.ToString() + @"'
                                where VendorId = " + Id.ToString();
                            fun.execQry(sql);
                        }
                    }
                    model.VendorId = Id;
                    return model;
                }
                else
                {
                    throw new Exception("Please check network connection");
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return model;
        }
        public VendorModel Update(VendorModel model)
        {
            try
            {
                 string sql = @"UPDATE [dbo].[Vendor] SET
                                [VendorCode] = @VendorCode
                               ,[VendorName] = @VendorName
                               ,[Address] = @Address
                               ,[PhoneNumber] = @PhoneNumber
                               ,[City] = @City
                               ,[FAX] = @FAX
                               ,[VAT] = @VAT
                               ,[ContactPerson] = @ContactPerson
                               ,[Email] = @Email
                               ,[CrNo] = @CrNo
                               ,[GosiNo] = @GosiNo
                               ,[Zakaat] = @Zakaat
                               ,[ChamberNo] = @ChamberNo
                               ,[VATExpiry] = @VATExpiry
                               ,[ChamberNoExpiry] = @ChamberNoExpiry
                               ,[CrNoExpiry] = @CrNoExpiry
                               ,[GosiNoExpiry] = @GosiNoExpiry
                               ,[ZakaatExpiry] = @ZakaatExpiry
                         WHERE VendorId = '" + model.VendorId + @"'";

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@VendorCode", model.VendorCode));
                param.Add(new SqlParameter("@VendorName", model.VendorName));
                param.Add(new SqlParameter("@Address", model.Address));
                param.Add(new SqlParameter("@PhoneNumber", model.PhoneNumber));
                param.Add(new SqlParameter("@City", model.City));
                param.Add(new SqlParameter("@FAX", model.FAX));
                param.Add(new SqlParameter("@VAT", model.VAT));
                param.Add(new SqlParameter("@ContactPerson", model.ContactPerson));
                param.Add(new SqlParameter("@Email", model.Email));
                param.Add(new SqlParameter("@CrNo", model.CrNo));
                param.Add(new SqlParameter("@GosiNo", model.GosiNo));
                param.Add(new SqlParameter("@Zakaat", model.Zakaat));
                param.Add(new SqlParameter("@ChamberNo", model.ChamberNo));

                if (model.VATExpiry == "")
                    param.Add(new SqlParameter("@VATExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@VATExpiry", model.VATExpiry));

                if (model.ChamberNoExpiry == "")
                    param.Add(new SqlParameter("@ChamberNoExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@ChamberNoExpiry", model.ChamberNoExpiry));

                if (model.CrNoExpiry == "")
                    param.Add(new SqlParameter("@CrNoExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@CrNoExpiry", model.CrNoExpiry));

                if (model.GosiNoExpiry == "")
                    param.Add(new SqlParameter("@GosiNoExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@GosiNoExpiry", model.GosiNoExpiry));

                if (model.ZakaatExpiry == "")
                    param.Add(new SqlParameter("@ZakaatExpiry", System.DBNull.Value));
                else
                    param.Add(new SqlParameter("@ZakaatExpiry", model.ZakaatExpiry));

                fun.OpenConnection();
                if (fun.getConnection().State == ConnectionState.Open)
                {
                    int Id = fun.ExecuteQueryWithParameters(sql, param, "Yes");
                    if (Id > 0)
                    {
                        if (model.CountryId > 0)
                        {
                            sql = @"Update Vendor set CountryId = '" + model.CountryId.ToString() + @"'
                                where VendorId = " + Id.ToString();
                            fun.execQry(sql);
                        }
                        if (model.VendorTypeId > 0)
                        {
                            sql = @"Update Vendor set VendorTypeId = '" + model.VendorTypeId.ToString() + @"'
                                where VendorId = " + Id.ToString();
                            fun.execQry(sql);
                        }
                    }
                    model.VendorId = Id;
                    return model;
                }
                else
                {
                    throw new Exception("Please check network connection");
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return model;
        }
        public DataSet GetVendorList()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = @"select B.VendorId, B.VendorName, B.ContactPerson, C.CountryName, E.VendorTypeName
                            from Vendor B 
                            left join Country C on B.CountryId = C.CountryId
                            left join VendorType E on B.VendorTypeId = E.VendorTypeId
                            order by B.VendorName";
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    return fun.fillComboDataset(query);
                }
                else
                {
                    return temp.fillComboDataset(query);
                }
                return ds;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
    public class VendorModel
    {
        public int VendorId { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string FAX { get; set; }
        public string VAT { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public int VendorTypeId { get; set; }
        public int CountryId { get; set; }
        public string CrNo { get; set; }
        public string GosiNo { get; set; }
        public string Zakaat { get; set; }
        public string ChamberNo { get; set; }
        public string VATExpiry { get; set; }
        public string ChamberNoExpiry { get; set; }
        public string CrNoExpiry { get; set; }
        public string GosiNoExpiry { get; set; }
        public string ZakaatExpiry { get; set; }
    }
}
