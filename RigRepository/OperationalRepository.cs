﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RigRepository
{
    public class OperationalRepository
    {
        DBFunctionRepository fun = new DBFunctionRepository();
        SQLiteFunctionRepository temp = new SQLiteFunctionRepository();

        public DataSet GetBillingDetails()
        {
            try
            {
                string query = @"SELECT ROW_NUMBER()OVER(ORDER BY BillingId)SlNo
	                              ,[BillingId]
                                  ,[BillingClass]
                                  ,[BillingDescription]
                                  ,[BillingDayPerc]
                                  ,[BillingDay]
                              FROM [dbo].[BillingDetails]";
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
        public List<BillingDetails> UpdateBillingDetails(List<BillingDetails> model)
        {
            try
            {
                foreach (var item in model)
                {
                    if (item.BillingClass != "")
                    {
                        if (item.BillingId == 0)
                        {
                            string query = @"INSERT INTO BillingDetails(
                                BillingClass
                                ,BillingDescription
                                ,BillingDayPerc
                                ,BillingDay)
                                output INSERTED.BillingId
                                VALUES(
                                @BillingClass
                                ,@BillingDescription
                                ,@BillingDayPerc
                                ,@BillingDay)
                                ";
                            List<SqlParameter> param = new List<SqlParameter>();
                            param.Add(new SqlParameter("@BillingClass", item.BillingClass));
                            param.Add(new SqlParameter("@BillingDescription", item.BillingDescription));
                            param.Add(new SqlParameter("@BillingDayPerc", item.BillingDayPerc));
                            param.Add(new SqlParameter("@BillingDay", item.BillingDay));

                            fun.OpenConnection();
                            if (fun.getConnection().State == System.Data.ConnectionState.Open)
                            {
                                item.BillingId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                            }
                            else
                            {
                                throw new Exception("Please check network connection");
                            }
                        }
                        else
                        {
                            string query = @"UPDATE BillingDetails SET
                                BillingClass = @BillingClass
                                ,BillingDescription = @BillingDescription
                                ,BillingDayPerc = @BillingDayPerc
                                ,BillingDay = @BillingDay
                                WHERE BillingId = @BillingId";

                            List<SqlParameter> param = new List<SqlParameter>();
                            param.Add(new SqlParameter("@BillingId", item.BillingId));
                            param.Add(new SqlParameter("@BillingClass", item.BillingClass));
                            param.Add(new SqlParameter("@BillingDescription", item.BillingDescription));
                            param.Add(new SqlParameter("@BillingDayPerc", item.BillingDayPerc));
                            param.Add(new SqlParameter("@BillingDay", item.BillingDay));

                            fun.OpenConnection();
                            if (fun.getConnection().State == System.Data.ConnectionState.Open)
                            {
                                fun.ExecuteQueryWithParameters(query, param);
                            }
                            else
                            {
                                throw new Exception("Please check network connection");
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
        public DataSet GetSectionalDetails()
        {
            try
            {
                string query = @"select ROW_NUMBER()OVER(ORDER BY SecId)SlNo,SecId
                                ,SectionName
                                ,SectionComment from SectionalDetails";

                fun.OpenConnection();
                if (fun.getConnection().State == ConnectionState.Open)
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
        public List<SectionalDetails> UpdateSectionalDetails(List<SectionalDetails> model)
        {
            try
            {
                foreach (var item in model)
                {
                    if (item.SectionName != "")
                    {
                        if (item.SecId == 0)
                        {
                            string query = @"INSERT INTO SectionalDetails(
                                SectionName
                                ,SectionComment)
                                output INSERTED.SecId
                                VALUES(
                                @SectionName
                                ,@SectionComment)
                                ";
                            List<SqlParameter> param = new List<SqlParameter>();
                            param.Add(new SqlParameter("@SectionName", item.SectionName));
                            param.Add(new SqlParameter("@SectionComment", item.SectionComment));

                            fun.OpenConnection();
                            if (fun.getConnection().State == System.Data.ConnectionState.Open)
                            {
                                item.SecId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                            }
                            else
                            {
                                throw new Exception("Please check network connection");
                            }
                        }
                        else
                        {
                            string query = @"UPDATE SectionalDetails SET
                                SectionName = @SectionName
                                ,SectionComment = @SectionComment
                                WHERE SecId = @SecId";

                            List<SqlParameter> param = new List<SqlParameter>();
                            param.Add(new SqlParameter("@SecId", item.SecId));
                            param.Add(new SqlParameter("@SectionName", item.SectionName));
                            param.Add(new SqlParameter("@SectionComment", item.SectionComment));

                            fun.OpenConnection();
                            if (fun.getConnection().State == System.Data.ConnectionState.Open)
                            {
                                fun.ExecuteQueryWithParameters(query, param);
                            }
                            else
                            {
                                throw new Exception("Please check network connection");
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
        public DataSet GetWellType()
        {
            try
            {
                string query = @"select ROW_NUMBER()OVER(ORDER BY WellTypeId)SlNo,WellTypeId
                                ,WellTypeName
                                ,WellTypeDescription from WellType";

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
        public List<WellType> UpdateWell(List<WellType> model)
        {
            try
            {                
                foreach (var item in model)
                {
                    if(item.WellTypeName != "")
                    {
                        if(item.WellTypeId == 0)
                        {
                            string query = @"INSERT INTO WellType(
                                WellTypeName
                                ,WellTypeDescription)
                                output INSERTED.WellTypeId
                                VALUES(
                                @WellTypeName
                                ,@WellTypeDescription)
                                ";
                            List<SqlParameter> param = new List<SqlParameter>();
                            param.Add(new SqlParameter("@WellTypeName", item.WellTypeName));
                            param.Add(new SqlParameter("@WellTypeDescription", item.WellTypeDescription));

                            fun.OpenConnection();
                            if(fun.getConnection().State == System.Data.ConnectionState.Open)
                            {
                                item.WellTypeId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                            }
                            else
                            {
                                throw new Exception("Please check network connection");
                            }
                        }
                        else
                        {
                            string query = @"UPDATE WellType SET
                                WellTypeName = @WellTypeName
                                ,WellTypeDescription = @WellTypeDescription
                                WHERE WellTypeId = @WellTypeId";

                            List<SqlParameter> param = new List<SqlParameter>();
                            param.Add(new SqlParameter("@WellTypeId", item.WellTypeId));
                            param.Add(new SqlParameter("@WellTypeName", item.WellTypeName));
                            param.Add(new SqlParameter("@WellTypeDescription", item.WellTypeDescription));

                            fun.OpenConnection();
                            if (fun.getConnection().State == System.Data.ConnectionState.Open)
                            {
                                fun.ExecuteQueryWithParameters(query, param);
                            }
                            else
                            {
                                throw new Exception("Please check network connection");
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
    }
    public class BillingDetails
    {
        public int BillingId {get;set;}
        public string BillingClass {get;set;}
        public string BillingDescription {get;set;}
        public int BillingDayPerc {get;set;}
        public int BillingDay { get; set; }

    }
    public class SectionalDetails
    {
        public int SecId { get; set; }
        public string SectionName { get; set; }
        public string SectionComment { get; set; }
    }
    public class WellType
    {
        public int WellTypeId {get;set;}
        public string WellTypeName {get;set;}
        public string WellTypeDescription { get; set; }

    }
}
