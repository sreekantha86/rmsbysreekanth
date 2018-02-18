using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RigRepository
{
    public class RigMasterRepository
    {
        DBFunctionRepository fun = new DBFunctionRepository();
        SQLiteFunctionRepository temp = new SQLiteFunctionRepository();
        public string GetNewNumber()
        {
            try
            {
                string query = @"select 'RIG/'+right('0000000'+cast(isnull(max(RigId),0)+1 as varchar(10)),4) from Rig;";
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    return fun.execScalar(query);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public DataSet fillLocation()
        {
            try
            {
                string query = @"select LocId, LocName from Location";
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    return fun.fillComboDataset(query);
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
        public DataSet fillRigType()
        {
            try
            {
                string query = @"select RigTypeId, RigTypeName from RigType";
                fun.OpenConnection();
                if (fun.getConnection().State == ConnectionState.Open)
                {
                    return fun.fillComboDataset(query);
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

        public RigModel Insert(RigModel model)
        {
            try
            {
                string query = @"INSERT INTO Rig(
                                 RigCode
                                ,RigName
                                ,RigManufacturer
                                ,RigProject
                                ,LocId
                                ,RigTypeId
                                ,RigModelNo
                                ,RigRemarks
                                ,RigDeployed
                                ,RigLocation
                                ,RigTypeName)
                                output INSERTED.RigId
                                VALUES(
                                 @RigCode
                                ,@RigName
                                ,@RigManufacturer
                                ,@RigProject
                                ,@LocId
                                ,@RigTypeId
                                ,@RigModelNo
                                ,@RigRemarks
                                ,@RigDeployed
                                ,@RigLocation
                                ,@RigTypeName)
                                ";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@RigCode",model.RigCode));
                param.Add(new SqlParameter("@RigName",model.RigName));
                param.Add(new SqlParameter("@RigManufacturer",model.RigManufacturer));
                param.Add(new SqlParameter("@RigProject",model.RigProject));
                param.Add(new SqlParameter("@LocId",model.LocId));
                param.Add(new SqlParameter("@RigTypeId",model.RigTypeId));
                param.Add(new SqlParameter("@RigModelNo",model.RigModelNo));
                param.Add(new SqlParameter("@RigRemarks", model.RigRemarks));
                param.Add(new SqlParameter("@RigDeployed", model.RigDeployed));
                param.Add(new SqlParameter("@RigLocation", model.RigLocation));
                param.Add(new SqlParameter("@RigTypeName", model.RigTypeName));
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    model.RigId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                }
                else
                {
                    throw new Exception("Please check connection");
                }
                return model;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public RigModel Update(RigModel model)
        {
            try
            {
                string query = @"UPDATE Rig SET
                                 RigCode = @RigCode
                                ,RigName = @RigName
                                ,RigManufacturer = @RigManufacturer
                                ,RigProject = @RigProject
                                ,LocId = @LocId
                                ,RigTypeId = @RigTypeId
                                ,RigModelNo = @RigModelNo
                                ,RigRemarks = @RigRemarks
                                ,RigDeployed = @RigDeployed
                                ,RigLocation = @RigLocation
                                ,RigTypeName = @RigTypeName
                                WHERE RigId = @RigId
                                ";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@RigId", model.RigId));
                param.Add(new SqlParameter("@RigCode", model.RigCode));
                param.Add(new SqlParameter("@RigName", model.RigName));
                param.Add(new SqlParameter("@RigManufacturer", model.RigManufacturer));
                param.Add(new SqlParameter("@RigProject", model.RigProject));
                param.Add(new SqlParameter("@LocId", model.LocId));
                param.Add(new SqlParameter("@RigTypeId", model.RigTypeId));
                param.Add(new SqlParameter("@RigModelNo", model.RigModelNo));
                param.Add(new SqlParameter("@RigRemarks", model.RigRemarks));
                param.Add(new SqlParameter("@RigDeployed", model.RigDeployed));
                param.Add(new SqlParameter("@RigLocation", model.RigLocation));
                param.Add(new SqlParameter("@RigTypeName", model.RigTypeName));

                fun.OpenConnection();
                if (fun.getConnection().State == ConnectionState.Open)
                {
                    model.RigId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                }
                else
                {
                    throw new Exception("Please check connection");
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetRigList()
        {
            try
            {
                string query = @"select A.RigId
                                ,A.RigCode
                                ,A.RigName
                                ,A.RigManufacturer
                                ,A.RigProject
                                ,A.RigTypeId
                                ,A.RigModelNo
                                ,A.RigRemarks
                                ,A.RigDeployed
                                ,A.RigLocation as LocName
                                FROM Rig A";
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    return fun.fillComboDataset(query);
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
        public RigModel GetRig(int RigId)
        {
            RigModel model = new RigModel();
            try
            {
                string query = String.Format(@"SELECT [RigId]
                                  ,[RigCode]
                                  ,[RigName]
                                  ,[RigManufacturer]
                                  ,[RigProject]
                                  ,[LocId]
                                  ,[RigTypeId]
                                  ,[RigModelNo]
                                  ,[RigRemarks]
                                  ,[RigDeployed]
                                  ,[RigLocation]
                                  ,[RigTypeName]
                              FROM [Rig] WHERE [RigId] = {0}", RigId);
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    DataSet ds = fun.fillComboDataset(query);
                    if(ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            model.LocId = Convert.ToInt32(item["LocId"].ToString());
                            model.RigCode = item["RigCode"].ToString();
                            if (item["RigDeployed"].ToString() == "")
                                model.RigDeployed = null; 
                            else
                                model.RigDeployed = Convert.ToDateTime(item["RigDeployed"].ToString());                            
                            model.RigId = RigId;
                            model.RigManufacturer = item["RigManufacturer"].ToString();
                            model.RigModelNo = item["RigModelNo"].ToString();
                            model.RigName = item["RigName"].ToString();
                            model.RigProject = item["RigProject"].ToString();
                            model.RigRemarks = item["RigRemarks"].ToString();
                            model.RigTypeId = Convert.ToInt32(item["RigTypeId"].ToString());
                            model.RigLocation = item["RigLocation"].ToString();
                            model.RigTypeName = item["RigTypeName"].ToString();
                        }
                    }
                }
                else
                {
                    throw new Exception("Please check network connection");
                }
                return model;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public bool DeleteRig(int RigId)
        {
            try
            {
                string query = @"Delete From Rig where RigId = @RigId";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@RigId", RigId));
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    fun.execQry(query, param);
                }
                else
                {
                    throw new Exception("Please check network connection");
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    public class RigModel
    {
        public int RigId {get;set;}
        public string RigCode {get;set;}
        public string RigName {get;set;}
        public string RigManufacturer {get;set;}
        public string RigProject {get;set;}
        public int LocId {get;set;}
        public int RigTypeId {get;set;}
        public string RigModelNo {get;set;}
        public string RigRemarks {get;set;}
        public DateTime? RigDeployed { get; set; }
        public string RigLocation { get; set; }
        public string RigTypeName { get; set; }

    }
}
