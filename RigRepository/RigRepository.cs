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
                                ,RigDeployed)
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
                                ,@RigDeployed)
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
                                ,A.LocId
                                ,A.RigTypeId
                                ,A.RigModelNo
                                ,A.RigRemarks
                                ,B.LocName
                                ,A.RigDeployed
                                FROM Rig A 
                                INNER JOIN Location B on A.LocId = B.LocId";

                return fun.fillComboDataset(query);
            }
            catch (Exception ex)
            {                
                throw ex;
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

    }
}
