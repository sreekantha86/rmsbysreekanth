using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RigRepository
{
    public class OperationsCategoryListRepository
    {
        DBFunctionRepository fun = new DBFunctionRepository();
        SQLiteFunctionRepository temp = new SQLiteFunctionRepository();

        public OperationsModel Insert(OperationsModel model)
        {
            try
            {
                string query = @"INSERT INTO Operations(OperationsName, OperationsDescription)
                output INSERTED.OperationsId
                VALUES(@OperationsName, @OperationsDescription)";

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@OperationsName", model.OperationsName));
                param.Add(new SqlParameter("@OperationsDescription", model.OperationsDescription));

                fun.OpenConnection();
                if(fun.getConnection().State == System.Data.ConnectionState.Open)
                {
                    model.OperationsId = fun.ExecuteQueryWithParameters(query, param, "Yes");
                    if(model.OperationsId > 0)
                    {
                        query = @"INSERT INTO OperationsType(OperationsId, OprName) 
                                OUTPUT Inserted.OprId
                                VALUES(@OperationsId, @OprName)";
                        foreach (OperationTypeModel item in model.OperationTypes)
                        {
                            List<SqlParameter> p = new List<SqlParameter>();
                            p.Add(new SqlParameter("@OperationsId", model.OperationsId));
                            p.Add(new SqlParameter("@OprName", item.OprName));

                            item.OprId = fun.ExecuteQueryWithParameters(query, p, "Yes");
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
        public OperationsModel Update(OperationsModel model)
        {
            try
            {
                string query = @"UPDATE Operations SET 
                OperationsName =@OperationsName 
                ,OperationsDescription = @OperationsDescription
                WHERE OperationsId = @OperationsId";

                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@OperationsId", model.OperationsId));
                param.Add(new SqlParameter("@OperationsName", model.OperationsName));
                param.Add(new SqlParameter("@OperationsDescription", model.OperationsDescription));

                fun.OpenConnection();
                if (fun.getConnection().State == System.Data.ConnectionState.Open)
                {
                    fun.ExecuteQueryWithParameters(query, param, "Yes");

                    if (model.OperationsId > 0)
                    {                        
                        foreach (OperationTypeModel item in model.OperationTypes)
                        {
                            if(item.OprId == 0)
                            {
                                query = @"INSERT INTO OperationsType(OperationsId, OprName) 
                                OUTPUT Inserted.OprId
                                VALUES(@OperationsId, @OprName)";
                                List<SqlParameter> p = new List<SqlParameter>();
                                p.Add(new SqlParameter("@OperationsId", model.OperationsId));
                                p.Add(new SqlParameter("@OprName", item.OprName));

                                item.OprId = fun.ExecuteQueryWithParameters(query, p, "Yes");
                            }
                            else
                            {
                                query = @"UPDATE OperationsType SET 
                                OperationsId = @OperationsId, 
                                OprName = @OprName WHERE OprId = @OprId";
                                List<SqlParameter> p = new List<SqlParameter>();
                                p.Add(new SqlParameter("@OperationsId", model.OperationsId));
                                p.Add(new SqlParameter("@OprName", item.OprName));
                                p.Add(new SqlParameter("@OprId", item.OprId));

                                fun.ExecuteQueryWithParameters(query, p);
                            }
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

        public DataSet GetOperationsList()
        {
            try
            {
                fun.OpenConnection();
                return fun.fillComboDataset("select OperationsId, OperationsName from Operations");
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
    public class OperationsModel
    {
        public int OperationsId{get;set;}
        public string OperationsName{get;set;}
        public string OperationsDescription { get; set; }
        public List<OperationTypeModel> OperationTypes { get; set; }

    }
    public class OperationTypeModel
    {
        public int OprId { get; set; }
        public int OperationsId { get; set; }
        public string OprName { get; set; }
    }
}
