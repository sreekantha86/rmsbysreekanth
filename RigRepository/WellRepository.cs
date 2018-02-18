using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RigRepository
{
    public class WellRepository
    {
        DBFunctionRepository fun = new DBFunctionRepository();
        SQLiteFunctionRepository temp = new SQLiteFunctionRepository();
        public string GetNewNumber()
        {
            try
            {
                string query = @"select 'WELL/'+right('0000000'+cast(isnull(max(WellId),0)+1 as varchar(10)),4) from Well";
                fun.OpenConnection();
                if (fun.getConnection().State == ConnectionState.Open)
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
        public LocationModel GetLocationDetails(int LocId)
        {
            try
            {
                string query = String.Format(@"select LocId,LocCode, LocName, LocLatitude, LocLongitude,LocRemarks 
                from Location where LocId = {0}", LocId);
                DataSet ds = new DataSet();
                LocationModel model = new LocationModel();
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    ds = fun.fillComboDataset(query);
                }
                else
                {
                    ds = temp.fillComboDataset(query);
                }
                if(ds.Tables.Count>0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        model.LocCode = item["LocCode"].ToString();
                        model.LocId = Convert.ToInt32(item["LocId"].ToString());
                        model.LocLatitude = item["LocLatitude"].ToString();
                        model.LocLongitude = item["LocLongitude"].ToString();
                        model.LocName = item["LocName"].ToString();
                        model.LocRemarks = item["LocRemarks"].ToString();                        
                    }
                }
                return model;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public List<WellSectionModel> GetSectionDetails(int WellId)
        {
            List<WellSectionModel> model = new List<WellSectionModel>();
            try
            {
                string query = @"select isnull(B.WellSecId,0)WellSecId,isnull(B.WellId,0)WellId,isnull(A.SecId,0)SecId, 
                A.SectionName, isnull(B.SecDepth,0)SecDepth
                from SectionalDetails A
                left join WellSections B on A.SecId = B.SecId and B.WellId = " + WellId;
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    DataSet ds = fun.fillComboDataset(query);
                    if(ds.Tables.Count>0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            model.Add(new WellSectionModel()
                            {
                                SecDepth = Convert.ToDecimal(item["SecDepth"].ToString()),
                                SecId = Convert.ToInt32(item["SecId"].ToString()),
                                SectionName = item["SectionName"].ToString(),
                                WellId = Convert.ToInt32(item["WellId"].ToString()),
                                WellSecId = Convert.ToInt32(item["WellSecId"].ToString())
                            });
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
        public DataSet fillWellType()
        {
            try
            {
                string query = @"select WellTypeId, WellTypeName from WellType";
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
        public DataSet fillRig()
        {
            try
            {
                string query = @"select RigId, RigName from Rig";
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
        public WellModel Insert(WellModel model)
        {
            try
            {
                string query = @"INSERT INTO Well(
                                WellCode
                                ,WellName
                                ,LocationId
                                ,WellTypeId
                                ,WellPlannedDate
                                ,WellDepth
                                ,RigId
                                ,PlannedDays)
                                OUTPUT Inserted.WellId
                                VALUES(
                                @WellCode
                                ,@WellName
                                ,@LocationId
                                ,@WellTypeId
                                ,@WellPlannedDate
                                ,@WellDepth
                                ,@RigId
                                ,@PlannedDays)";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@WellCode", model.WellCode));
                param.Add(new SqlParameter("@WellName", model.WellName));
                param.Add(new SqlParameter("@LocationId", model.LocationId));
                param.Add(new SqlParameter("@WellTypeId", model.WellTypeId));
                param.Add(new SqlParameter("@WellPlannedDate", model.WellPlannedDate));
                param.Add(new SqlParameter("@WellDepth", model.WellDepth));
                param.Add(new SqlParameter("@RigId", model.RigId));
                param.Add(new SqlParameter("@PlannedDays", model.PlannedDays));

                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    model.WellId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                    if(model.WellId > 0)
                    {
                        query = @"INSERT INTO WellDrillingPlan(
                                    WellId
                                    ,WellDrillDoc
                                    ,WellDrilDocName
                                    ,WellDrillDocExt
                                    ,WellDrillDocUploadDate)
                                    OUTPUT Inserted.WellDrillPlanId
                                    VALUES(
                                    @WellId
                                    ,@WellDrillDoc
                                    ,@WellDrilDocName
                                    ,@WellDrillDocExt
                                    ,@WellDrillDocUploadDate)";
                        foreach (WellDrillingPlanModel item in model.DrillingPlanDoc)
                        {
                            item.WellId = model.WellId;
                            param = new List<SqlParameter>();
                            param.Add(new SqlParameter("@WellId", model.WellId));
                            param.Add(new SqlParameter("@WellDrillDoc", item.WellDrillDoc));
                            param.Add(new SqlParameter("@WellDrilDocName", item.WellDrilDocName));
                            param.Add(new SqlParameter("@WellDrillDocExt", item.WellDrillDocExt));
                            param.Add(new SqlParameter("@WellDrillDocUploadDate", DateTime.Now));
                            item.WellDrillPlanId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                        }
                        query = @"INSERT INTO WellSections(
                                    WellId
                                    ,SecId
                                    ,SecDepth)
                                    OUTPUT INSERTED.WellSecId
                                    VALUES(
                                    @WellId
                                    ,@SecId
                                    ,@SecDepth)
                                    ";
                        foreach (var item in model.WellSections)
                        {
                            if(item.SecDepth > 0)
                            {
                                param = new List<SqlParameter>();
                                param.Add(new SqlParameter("@WellId", model.WellId));
                                param.Add(new SqlParameter("@SecId", item.SecId));
                                param.Add(new SqlParameter("@SecDepth", item.SecDepth));
                                item.WellSecId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                            }
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
        public WellModel Update(WellModel model)
        {
            try
            {
                string query = @"Update Well set
                                 WellCode = @WellCode
                                ,WellName = @WellName
                                ,LocationId = @LocationId
                                ,WellTypeId = @WellTypeId
                                ,WellPlannedDate = @WellPlannedDate
                                ,WellDepth = @WellDepth
                                ,RigId = @RigId
                                ,PlannedDays = @PlannedDays
                                 WHERE WellId = @WellId";

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@WellId", model.WellId));
                param.Add(new SqlParameter("@WellCode", model.WellCode));
                param.Add(new SqlParameter("@WellName", model.WellName));
                param.Add(new SqlParameter("@LocationId", model.LocationId));
                param.Add(new SqlParameter("@WellTypeId", model.WellTypeId));
                param.Add(new SqlParameter("@WellPlannedDate", model.WellPlannedDate));
                param.Add(new SqlParameter("@WellDepth", model.WellDepth));
                param.Add(new SqlParameter("@RigId", model.RigId));
                param.Add(new SqlParameter("@PlannedDays", model.PlannedDays));

                fun.OpenConnection();
                if (fun.getConnection().State == ConnectionState.Open)
                {
                    fun.ExecuteQueryWithParameters(query, param);
                    if (model.WellId > 0)
                    {                        
                        foreach (WellDrillingPlanModel item in model.DrillingPlanDoc)
                        {
                            if(item.WellDrillPlanId == 0)
                            {
                                query = @"INSERT INTO WellDrillingPlan(
                                    WellId
                                    ,WellDrillDoc
                                    ,WellDrilDocName
                                    ,WellDrillDocExt
                                    ,WellDrillDocUploadDate)
                                    OUTPUT Inserted.WellDrillPlanId
                                    VALUES(
                                    @WellId
                                    ,@WellDrillDoc
                                    ,@WellDrilDocName
                                    ,@WellDrillDocExt
                                    ,@WellDrillDocUploadDate)";
                                item.WellId = model.WellId;
                                param = new List<SqlParameter>();
                                param.Add(new SqlParameter("@WellId", model.WellId));
                                param.Add(new SqlParameter("@WellDrillDoc", item.WellDrillDoc));
                                param.Add(new SqlParameter("@WellDrilDocName", item.WellDrilDocName));
                                param.Add(new SqlParameter("@WellDrillDocExt", item.WellDrillDocExt));
                                param.Add(new SqlParameter("@WellDrillDocUploadDate", DateTime.Now));
                                item.WellDrillPlanId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                            }                      
                        }
                       
                        foreach (var item in model.WellSections)
                        {
                            if (item.SecDepth > 0)
                            {
                                if(item.WellSecId == 0)
                                {
                                    query = @"INSERT INTO WellSections(
                                    WellId
                                    ,SecId
                                    ,SecDepth)
                                    OUTPUT INSERTED.WellSecId
                                    VALUES(
                                    @WellId
                                    ,@SecId
                                    ,@SecDepth)
                                    ";
                                    param = new List<SqlParameter>();
                                    param.Add(new SqlParameter("@WellId", model.WellId));
                                    param.Add(new SqlParameter("@SecId", item.SecId));
                                    param.Add(new SqlParameter("@SecDepth", item.SecDepth));
                                    item.WellSecId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                                }
                                else
                                {
                                    query = @"UPDATE WellSections SET SecDepth = @SecDepth
                                     WHERE WellId = @WellId 
                                     AND SecId = @SecId
                                     AND SecDepth = @SecDepth";

                                    param = new List<SqlParameter>();
                                    param.Add(new SqlParameter("@WellId", model.WellId));
                                    param.Add(new SqlParameter("@SecId", item.SecId));
                                    param.Add(new SqlParameter("@SecDepth", item.SecDepth));
                                    fun.ExecuteQueryWithParameters(query, param);
                                }
                                
                            }
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
        public DataSet getWellList()
        {
            try
            {
                string query = @"select A.WellId, A.WellCode, A.WellName, WT.WellTypeName, L.LocName, R.RigName, A.WellDepth
                from Well A
                inner join Location  L on A.LocationId = L.LocId
                inner join WellType WT on WT.WellTypeId = A.WellTypeId
                inner join Rig R on R.RigId = A.RigId";

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
        public WellModel GetWellDetails(int wellId)
        {
            WellModel model = new WellModel();
            model.DrillingPlanDoc = new List<WellDrillingPlanModel>();
            model.WellSections = new List<WellSectionModel>();
            try
            {
                string query = String.Format(@"SELECT [WellId]
                                  ,[WellCode]
                                  ,[WellName]
                                  ,[LocationId]
                                  ,[WellTypeId]
                                  ,[WellPlannedDate]
                                  ,[WellDepth]
                                  ,[RigId]
                                  ,[PlannedDays]
                              FROM [Well] WHERE [WellId] = {0};
                                SELECT [WellDrillPlanId]
                                  ,[WellId]
                                  ,[WellDrillDoc]
                                  ,[WellDrilDocName]
                                  ,[WellDrillDocExt]
                                  ,[WellDrillDocUploadDate]
                              FROM [dbo].[WellDrillingPlan]WHERE [WellId] = {0};
                                select isnull(B.WellSecId,0)WellSecId,isnull(B.WellId,0)WellId,isnull(A.SecId,0)SecId, 
                                A.SectionName, isnull(B.SecDepth,0)SecDepth
                                from SectionalDetails A
                                left join WellSections B on A.SecId = B.SecId and B.WellId = {0}", wellId);

                DataSet ds = new DataSet();
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    ds = fun.fillComboDataset(query);
                }
                else
                {
                    ds = temp.fillComboDataset(query);
                }
                if(ds.Tables.Count>0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        model.LocationId = Convert.ToInt32(item["LocationId"].ToString());
                        model.RigId = Convert.ToInt32(item["RigId"].ToString());
                        model.WellCode = item["WellCode"].ToString();
                        model.WellDepth = Convert.ToDecimal(item["WellDepth"].ToString());
                        model.WellId = Convert.ToInt32(item["WellId"].ToString());
                        model.WellName = item["WellName"].ToString();
                        model.WellPlannedDate = Convert.ToDateTime(item["WellPlannedDate"].ToString());
                        model.WellTypeId = Convert.ToInt32(item["WellTypeId"].ToString());
                        model.PlannedDays = Convert.ToInt32(item["PlannedDays"].ToString());
                    }
                    foreach (DataRow item in ds.Tables[1].Rows)
                    {
                        model.DrillingPlanDoc.Add(new WellDrillingPlanModel() {
                            WellDrilDocName = item["WellDrilDocName"].ToString(),
                            WellDrillDoc = (byte[])item["WellDrillDoc"],
                            WellDrillDocExt = item["WellDrillDocExt"].ToString(),
                            WellDrillPlanId = (int)item["WellDrillPlanId"],
                            WellId = (int)item["WellId"],
                            WellDrillDocUploadDate = (DateTime)item["WellDrillDocUploadDate"]
                        });
                    }
                    foreach (DataRow item in ds.Tables[2].Rows)
                    {
                        model.WellSections.Add(new WellSectionModel()
                        {
                            SecDepth = Convert.ToDecimal(item["SecDepth"].ToString()),
                            SecId = Convert.ToInt32(item["SecId"].ToString()),
                            SectionName = item["SectionName"].ToString(),
                            WellId = Convert.ToInt32(item["WellId"].ToString()),
                            WellSecId = Convert.ToInt32(item["WellSecId"].ToString())
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
        public CurrentOperationModel GetCurrentOperation(int RigId)
        {
            CurrentOperationModel model = new CurrentOperationModel();
            try
            {
                string query = String.Format(@"select top 1 
                WellName, LocName, WellTypeName, SectionName, B.WellDepth, A.CurrentDepth,
                OperationsName, Datediff(dd, getdate(),WellPlannedDate)DaysOnWell 
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
                            model.WellName = item["WellName"].ToString();
                            model.LocName = item["LocName"].ToString();
                            model.WellTypeName = item["WellTypeName"].ToString();
                            model.SectionName = item["SectionName"].ToString();
                            model.WellDepth = Convert.ToDecimal(item["WellDepth"].ToString());
                            model.CurrentDepth = Convert.ToDecimal(item["CurrentDepth"].ToString());
                            model.OperationsName = item["OperationsName"].ToString();
                            model.DaysOnWell = Convert.ToInt32(item["DaysOnWell"].ToString());
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
        public List<CurrentOperationModel> GetCurrentOperationOnWells(int RigId)
        {
            List<CurrentOperationModel> model = new List<CurrentOperationModel>();
            try
            {
                string query = String.Format(@"select top 1 
                WellName, LocName, WellTypeName, SectionName, B.WellDepth, A.CurrentDepth,
                OperationsName, Datediff(dd, getdate(),WellPlannedDate)DaysOnWell 
                from WellOperations A 
                inner join Well B on A.WellId = B.WellId
                inner join WellType C on B.WellTypeId = C.WellTypeId
                inner join Location D on D.LocId = B.LocationId
                inner join SectionalDetails E on E.SecId = A.SecId
                inner join Operations F on F.OperationsId = A.OperationsId
                where B.RigId = {0}
                order by WellOpId desc", RigId);

                fun.OpenConnection();
                if (fun.getConnection().State == ConnectionState.Open)
                {
                    DataSet ds = fun.fillComboDataset(query);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            model.Add(new CurrentOperationModel(){
                                WellName = item["WellName"].ToString(),
                                LocName = item["LocName"].ToString(),
                                WellTypeName = item["WellTypeName"].ToString(),
                                SectionName = item["SectionName"].ToString(),
                                WellDepth = Convert.ToDecimal(item["WellDepth"].ToString()),
                                CurrentDepth = Convert.ToDecimal(item["CurrentDepth"].ToString()),
                                OperationsName = item["OperationsName"].ToString(),
                                DaysOnWell = Convert.ToInt32(item["DaysOnWell"].ToString())
                            });
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
        public DataSet GetDetailedOperationReportOnRig(int RigId)
        {
            try
            {
                string query = String.Format(@"select A.WellOpId,ROW_NUMBER()OVER(ORDER BY WellOpId Asc)ROWNUM,
                WellName, RigName, LocName, WellTypeName, SectionName, B.WellDepth, A.CurrentDepth,
                OperationsName, OprName, Datediff(dd, getdate(),WellPlannedDate)DaysOnWell,
                StartTime, EndTime, B.PlannedDays
                from WellOperations A 
                inner join Well B on A.WellId = B.WellId
                inner join Rig R on B.RigId = R.RigId
                inner join WellType C on B.WellTypeId = C.WellTypeId
                inner join Location D on D.LocId = B.LocationId
                inner join SectionalDetails E on E.SecId = A.SecId
                inner join Operations F on F.OperationsId = A.OperationsId
                inner join OperationsType OT on OT.OprId = A.OprId
                where B.RigId = {0}
                order by WellOpId Asc", RigId);

                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    return fun.fillComboDataset(query);
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
        }
    }
    public class WellModel
    {
        public int WellId {get;set;}
        public string WellCode {get;set;}
        public string WellName {get;set;}
        public int LocationId {get;set;}
        public int WellTypeId {get;set;}
        public DateTime WellPlannedDate {get;set;}
        public decimal WellDepth { get; set; }
        public List<WellDrillingPlanModel> DrillingPlanDoc { get; set; }
        public List<WellSectionModel> WellSections { get; set; }
        public int RigId { get; set; }
        public string LocName { get; set; }
        public string WellTypeName { get; set; }
        public int PlannedDays { get; set; }
    }
    public class WellDrillingPlanModel
    {
        public int WellDrillPlanId {get;set;}
        public int WellId {get;set;}
        public byte[] WellDrillDoc {get;set;}
        public string WellDrilDocName {get;set;}
        public string WellDrillDocExt { get; set; }
        public DateTime WellDrillDocUploadDate { get; set; }
    }
    public class WellSectionModel
    {
        public int WellSecId {get;set;}
        public int WellId {get;set;}
        public int SecId {get;set;}
        public decimal SecDepth { get; set; }
        public string SectionName { get; set; }
    }
    public class CurrentOperationModel
    {
        public int WellOpId { get; set; }
        public int ROWNUM { get; set; }
        public string WellName { get; set; }
        public string LocName { get; set; }
        public string WellTypeName { get; set; }
        public string SectionName { get; set; }
        public decimal WellDepth { get; set; }
        public decimal CurrentDepth { get; set; }
        public string OperationsName { get; set; }
        public int DaysOnWell { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
