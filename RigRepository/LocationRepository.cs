using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RigRepository
{
    public class LocationRepository
    {
        DBFunctionRepository fun = new DBFunctionRepository();
        SQLiteFunctionRepository temp = new SQLiteFunctionRepository();

        public LocationModel Insert(LocationModel model)
        {
            try
            {
                string query = @"INSERT INTO Location(
                                 LocCode
                                ,LocName
                                ,LocLatitude
                                ,LocLongitude
                                ,LocRemarks)
                                output INSERTED.LocId
                                VALUES(
                                 @LocCode
                                ,@LocName
                                ,@LocLatitude
                                ,@LocLongitude
                                ,@LocRemarks)
                                ";

                fun.OpenConnection();
                if(fun.getConnection().State == System.Data.ConnectionState.Open)
                {
                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@LocCode", model.LocCode));
                    param.Add(new SqlParameter("@LocName", model.LocName));
                    param.Add(new SqlParameter("@LocLatitude", model.LocLatitude));
                    param.Add(new SqlParameter("@LocLongitude", model.LocLongitude));
                    param.Add(new SqlParameter("@LocRemarks", model.LocRemarks));

                    model.LocId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                }
                else
                {
                    throw new Exception("Please check Network connection");
                }
                return model;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public LocationModel Update(LocationModel model)
        {
            try
            {
                string query = @"UPDATE Location SET
                                 LocCode = @LocCode
                                ,LocName = @LocName
                                ,LocLatitude = @LocLatitude
                                ,LocLongitude = @LocLongitude
                                ,LocRemarks = @LocRemarks
                                WHERE LocId = @LocId
                                ";

                fun.OpenConnection();
                if (fun.getConnection().State == System.Data.ConnectionState.Open)
                {
                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@LocId", model.LocId));
                    param.Add(new SqlParameter("@LocCode", model.LocCode));
                    param.Add(new SqlParameter("@LocName", model.LocName));
                    param.Add(new SqlParameter("@LocLatitude", model.LocLatitude));
                    param.Add(new SqlParameter("@LocLongitude", model.LocLongitude));
                    param.Add(new SqlParameter("@LocRemarks", model.LocRemarks));

                    fun.ExecuteQueryWithParameters(query, param);
                }
                else
                {
                    throw new Exception("Please check Network connection");
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetLocationList()
        {
            try
            {
                string query = @"select LocId
                                ,LocCode
                                ,LocName
                                ,LocLatitude
                                ,LocLongitude
                                ,LocRemarks
                                FROM Location";

                return fun.fillComboDataset(query);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public LocationModel GetLocation(int locId)
        {
            try
            {
                LocationModel model = new LocationModel();
                string query = String.Format(@"SELECT [LocId]
                                  ,[LocCode]
                                  ,[LocName]
                                  ,[LocLatitude]
                                  ,[LocLongitude]
                                  ,[LocRemarks]
                              FROM [Location] WHERE [LocId] = {0}",locId);

                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    DataSet ds = fun.fillComboDataset(query);
                    if(ds.Tables.Count>0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            model.LocCode = item["LocCode"].ToString();
                            model.LocId = locId;
                            model.LocLatitude = item["LocLatitude"].ToString();
                            model.LocLongitude = item["LocLongitude"].ToString();
                            model.LocName = item["LocName"].ToString();
                            model.LocRemarks = item["LocRemarks"].ToString();
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
        public bool DeleteLocation(int LocId)
        {
            try
            {
                string query = @"Delete from Location where LocId = @LocId;";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@LocId", LocId));
                fun.OpenConnection();
                if(fun.getConnection().State == ConnectionState.Open)
                {
                    fun.execQry(query, param);
                    return true;
                }
                else
                {
                    throw new Exception("Please check network connection");
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
    public class LocationModel
    {
        public int LocId { get; set; }
        public string LocCode { get; set; }
        public string LocName { get; set; }
        public string LocLatitude { get; set; }
        public string LocLongitude { get; set; }
        public string LocRemarks { get; set; }
    }
}
