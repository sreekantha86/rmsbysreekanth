using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RigRepository
{
    public class RigOperationsRepository
    {
        DBFunctionRepository fun = new DBFunctionRepository();
        SQLiteFunctionRepository temp = new SQLiteFunctionRepository();
        public WellModel GetWellDetails(int RigId)
        {
            WellModel model = new WellModel();
            try
            {
                string query = @"SELECT TOP 1 A.WellId
                      ,A.WellCode
                      ,A.WellName
                      ,A.LocationId
                      ,A.WellTypeId
                      ,A.WellPlannedDate
                      ,A.WellDepth
                      ,A.RigId
	                  ,B.WellTypeName
	                  ,C.LocName
                  FROM Well A
                  INNER join WellType B on A.WellTypeId = B.WellTypeId
                  INNER JOIN Location C on C.LocId = A.LocationId
                  WHERE A.RigId = " + RigId.ToString();
                fun.OpenConnection();
                if(fun.getConnection().State == System.Data.ConnectionState.Open)
                {
                    DataSet ds = fun.fillComboDataset(query);
                    if(ds.Tables.Count>0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            model.LocationId = Convert.ToInt32(item["LocationId"].ToString());
                            model.LocName = item["LocName"].ToString();
                            model.RigId = Convert.ToInt32(item["RigId"].ToString());
                            model.WellCode = item["WellCode"].ToString();
                            model.WellDepth = Convert.ToDecimal(item["WellDepth"].ToString());
                            model.WellId = Convert.ToInt32(item["WellId"].ToString());
                            model.WellName = item["WellName"].ToString();
                            model.WellPlannedDate = Convert.ToDateTime(item["WellPlannedDate"].ToString());
                            model.WellTypeId = Convert.ToInt32(item["WellTypeId"].ToString());
                            model.WellTypeName = item["WellTypeName"].ToString();
                        }
                    }
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
        public DataSet GetOperations()
        {
            try
            {
                string query = "select OperationsId, OperationsName from Operations order by OperationsName";
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
        public DataSet GetOperationsType(int OperationsId)
        {
            try
            {
                string query = String.Format("select OprId, OprName from OperationsType where OperationsId = {0} order by OprName", OperationsId);
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
        public DataSet GetSections(int WellId)
        {
            try
            {
                string query = String.Format(@"select isnull(A.SecId,0)SecId, 
                A.SectionName
                from SectionalDetails A
                inner join WellSections B on A.SecId = B.SecId and B.WellId = {0}", WellId);
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
        public WellOperationsModel Insert(WellOperationsModel model)
        {
            try 
	        {
                string query = @"INSERT INTO WellOperations(
                                WellId
                                ,OperationsId
                                ,OprId
                                ,Remarks
                                ,StartTime
                                ,SecId
                                ,CurrentDepth
                                ,CreatedDateTime)
                                OUTPUT INSERTED.WellOpId
                                VALUES(
                                @WellId
                                ,@OperationsId
                                ,@OprId
                                ,@Remarks
                                ,@StartTime
                                ,@SecId
                                ,@CurrentDepth
                                ,@CreatedDateTime)";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@WellId", model.WellId));
                param.Add(new SqlParameter("@OperationsId", model.OperationsId));
                param.Add(new SqlParameter("@OprId", model.OprId));
                param.Add(new SqlParameter("@Remarks", model.Remarks));
                param.Add(new SqlParameter("@StartTime", model.StartTime));
                param.Add(new SqlParameter("@SecId", model.SecId));
                param.Add(new SqlParameter("@CurrentDepth", model.CurrentDepth));
                param.Add(new SqlParameter("@CreatedDateTime", model.CreatedDateTime));

                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    model.WellOpId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                    if(model.WellOpId > 0)
                    {
                        query = @"with A as (
                                select WellOpId, ROW_NUMBER()OVER(ORDER BY WellOpId Desc)RowNumber from WellOperations where WellId = @WellId and WellOpId <> @WellOpId
                                )update B set B.EndTime = @EndTime from A inner join WellOperations B on A.WellOpId = B.WellOpId and A.RowNumber = 1";
                        param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@WellId", model.WellId));
                        param.Add(new SqlParameter("@WellOpId", model.WellOpId));
                        param.Add(new SqlParameter("@EndTime", model.StartTime));
                        fun.execQry(query,param);
                    }
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
        public WellOperationsModel Update(WellOperationsModel model)
        {
            try
            {
                string query = @"UPDATE WellOperations SET
                                OperationsId = @OperationsId
                                ,OprId = @OprId
                                ,Remarks = @Remarks
                                ,StartTime = @StartTime
                                ,SecId = @SecId
                                ,CurrentDepth = @CurrentDepth
                                ,LastUpdatedDateTime = @LastUpdatedDateTime
                                WHERE WellOpId = @WellOpId";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@OperationsId", model.OperationsId));
                param.Add(new SqlParameter("@OprId", model.OprId));
                param.Add(new SqlParameter("@Remarks", model.Remarks));
                param.Add(new SqlParameter("@StartTime", model.StartTime));
                param.Add(new SqlParameter("@SecId", model.SecId));
                param.Add(new SqlParameter("@CurrentDepth", model.CurrentDepth));
                param.Add(new SqlParameter("@LastUpdatedDateTime", model.CreatedDateTime));
                param.Add(new SqlParameter("@WellOpId", model.WellOpId));
                fun.OpenConnection();
                if (fun.getConnection().State == ConnectionState.Open)
                {
                    fun.ExecuteQueryWithParameters(query, param);         
                    if(model.EndTime != null)
                    {
                        query = @"UPDATE WellOperations SET
                                EndTime = @EndTime
                                WHERE WellOpId = @WellOpId";
                        param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@EndTime", model.EndTime));
                        param.Add(new SqlParameter("@WellOpId", model.WellOpId));
                        fun.ExecuteQueryWithParameters(query, param);     
                    }
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
        public List<CurrentOperationModel> GetOperationsHistory(int RigId)
        {
            List<CurrentOperationModel> model = new List<CurrentOperationModel>();
            try
            {
                string query = String.Format(@"select WellOpId, ROW_NUMBER()OVER(ORDER BY WellOpId Desc)ROWNUM,
                WellName, LocName, WellTypeName, SectionName, B.WellDepth, A.CurrentDepth,
                OperationsName, Datediff(dd, getdate(),WellPlannedDate)DaysOnWell,
                StartTime, EndTime
                from WellOperations A 
                inner join Well B on A.WellId = B.WellId
                inner join WellType C on B.WellTypeId = C.WellTypeId
                inner join Location D on D.LocId = B.LocationId
                inner join SectionalDetails E on E.SecId = A.SecId
                inner join Operations F on F.OperationsId = A.OperationsId
                where B.RigId = {0}
                order by WellOpId desc", RigId);

                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    DataSet ds = fun.fillComboDataset(query);
                    if(ds.Tables.Count>0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            CurrentOperationModel cOpr = new CurrentOperationModel();
                            cOpr.WellName = item["WellName"].ToString();
                            cOpr.LocName = item["LocName"].ToString();
                            cOpr.WellTypeName = item["WellTypeName"].ToString();
                            cOpr.SectionName = item["SectionName"].ToString();
                            cOpr.WellDepth = Convert.ToDecimal(item["WellDepth"].ToString());
                            cOpr.CurrentDepth = Convert.ToDecimal(item["CurrentDepth"].ToString());
                            cOpr.OperationsName = item["OperationsName"].ToString();
                            cOpr.DaysOnWell = Convert.ToInt32(item["DaysOnWell"].ToString());
                            cOpr.ROWNUM =  Convert.ToInt32(item["ROWNUM"].ToString());
                            cOpr.StartTime =  Convert.ToDateTime(item["StartTime"].ToString());
                            if (item["EndTime"].ToString() != "")
                            {
                                cOpr.EndTime = Convert.ToDateTime(item["EndTime"].ToString());
                            }                            
                            cOpr.WellOpId = Convert.ToInt32(item["WellOpId"].ToString());
                            model.Add(cOpr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        public WellOperationsModel GetOperationEditDetails(int WellOpId)
        {
            WellOperationsModel model = new WellOperationsModel();
            try
            {
                string query = String.Format(@"select WellOpId, WellId, OperationsId, OprId, StartTime, EndTime, SecId, CurrentDepth, Remarks
                from WellOperations 
                where WellOpId = {0}", WellOpId);

                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    DataSet ds = fun.fillComboDataset(query);
                    if(ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            model.WellOpId = Convert.ToInt32(item["WellOpId"].ToString());
                            model.WellId = Convert.ToInt32(item["WellId"].ToString());
                            model.SecId = Convert.ToInt32(item["SecId"].ToString());
                            model.OperationsId = Convert.ToInt32(item["OperationsId"].ToString());
                            model.OprId = Convert.ToInt32(item["OprId"].ToString());
                            model.StartTime = Convert.ToDateTime(item["StartTime"].ToString());
                            if (item["EndTime"].ToString() != "")
                            {
                                model.EndTime = Convert.ToDateTime(item["EndTime"].ToString());
                            }
                            model.Remarks = item["Remarks"].ToString();
                            model.CurrentDepth = Convert.ToInt32(item["CurrentDepth"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
    public class WellOperationsModel
    {
        public int WellOpId {get;set;}
        public int WellId {get;set;}
        public int OperationsId {get;set;}
        public int OprId {get;set;}
        public string Remarks {get;set;}
        public DateTime StartTime {get;set;}
        public DateTime? EndTime { get; set; }
        public int SecId {get;set;}
        public decimal CurrentDepth {get;set;}
        public DateTime CreatedDateTime {get;set;}
        public DateTime LastUpdatedDateTime { get; set; }

    }
}
