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
                string query = String.Format(@"select LocId, LocName, LocLatitude, LocLongitude from Location where LocId = {0}", LocId);
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

                }
                return model;
            }
            catch (Exception ex)
            {
                
                throw;
            }
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
                                ,RigId)
                                OUTPUT Inserted.WellId
                                VALUES(
                                @WellCode
                                ,@WellName
                                ,@LocationId
                                ,@WellTypeId
                                ,@WellPlannedDate
                                ,@WellDepth
                                ,@RigId)";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@WellCode", model.WellCode));
                param.Add(new SqlParameter("@WellName", model.WellName));
                param.Add(new SqlParameter("@LocationId", model.LocationId));
                param.Add(new SqlParameter("@WellTypeId", model.WellTypeId));
                param.Add(new SqlParameter("@WellPlannedDate", model.WellPlannedDate));
                param.Add(new SqlParameter("@WellDepth", model.WellDepth));
                param.Add(new SqlParameter("@RigId", model.RigId));

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
//                            else
//                            {
//                                query = @"UPDATE WellDrillingPlan  SET
//                                    WellId = @WellId
//                                    ,WellDrillDoc = @WellDrillDoc
//                                    ,WellDrilDocName = @WellDrilDocName
//                                    ,WellDrillDocExt = @WellDrillDocExt)
//                                    WHERE WellDrillPlanId = @WellDrillPlanId";
//                                param = new List<SqlParameter>();
//                                param.Add(new SqlParameter("@WellDrillPlanId", item.WellDrillPlanId));
//                                param.Add(new SqlParameter("@WellId", model.WellId));
//                                param.Add(new SqlParameter("@WellDrillDoc", item.WellDrillDoc));
//                                param.Add(new SqlParameter("@WellDrilDocName", item.WellDrilDocName));
//                                param.Add(new SqlParameter("@WellDrillDocExt", item.WellDrillDocExt));
//                                item.WellDrillPlanId = fun.ExecuteQueryWithParameters(query, param, "Yes");
//                            }                            
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
                              FROM [Well] WHERE [WellId] = {0};
                                SELECT [WellDrillPlanId]
                                  ,[WellId]
                                  ,[WellDrillDoc]
                                  ,[WellDrilDocName]
                                  ,[WellDrillDocExt]
                                  ,[WellDrillDocUploadDate]
                              FROM [dbo].[WellDrillingPlan]WHERE [WellId] = {0}", wellId);

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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
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
        public int RigId { get; set; }
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
}
