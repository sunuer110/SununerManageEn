using System;
using DBHelper;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Articles
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:ArticlesDal
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class ArticlesDal
    {
        /// <summary>
        /// Add Articles
        /// Model.CreateUserID Creator
        /// Model.BigID Category
        /// Model.ArticleTitle Title 
        /// Model.Articlekey Keywords
        /// Model.ArticleDesn Description
        /// Model.Statues Display: 0 = Yes, 1 = No
        /// Model.Sorts Sort Order
        /// Model.NavSites Redirect URL
        /// Model.ReleaseTime Publish Time
        /// Model.Hits Click Rate
        /// Model.Image Header Image
        /// Model.Images Image Collection
        /// Model.Desn Details
        /// </summary>
        public int Add(ArticlesModel Model)
        {
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
                new SqlParameter("@CreateUserID", SqlDbType.Int, 4) { Value = Model.CreateUserID },
                new SqlParameter("@BigID", SqlDbType.Int, 4) { Value = Model.BigID },
                new SqlParameter("@ArticleTitle", SqlDbType.NVarChar, 200) { Value = Model.ArticleTitle },
                new SqlParameter("@Articlekey", SqlDbType.NVarChar, 200) { Value = Model.Articlekey },
                new SqlParameter("@ArticleDesn", SqlDbType.NVarChar, 500) { Value = Model.ArticleDesn },
                new SqlParameter("@Statues", SqlDbType.Int, 4) { Value = Model.Statues },
                new SqlParameter("@Sorts", SqlDbType.Int, 4) { Value = Model.Sorts },
                new SqlParameter("@NavSites", SqlDbType.NVarChar, 200) { Value = Model.NavSites },
                new SqlParameter("@ReleaseTime", SqlDbType.DateTime, 8) { Value = Model.ReleaseTime },
                new SqlParameter("@Hits", SqlDbType.Int, 4) { Value = Model.Hits },
                new SqlParameter("@Image", SqlDbType.NVarChar, 500) { Value = Model.Image },
                new SqlParameter("@Images", SqlDbType.NVarChar, 500) { Value = Model.Images },
                new SqlParameter("@Desn", SqlDbType.NVarChar, -1) { Value = Model.Desn }
            };
            return SQLRUN.ExecuteStoredProcedureReturnValue("Articles_Add", parameters);
        }


        /// <summary>
        /// Update Articles
        /// Model.ArticleID 
        /// Model.UpdateUserID Updated by
        /// Model.BigID Category
        /// Model.ArticleTitle Title 
        /// Model.Articlekey Keywords
        /// Model.ArticleDesn Description
        /// Model.Statues Display: 0 = Yes, 1 = No
        /// Model.Sorts Sort Order
        /// Model.NavSites Redirect URL
        /// Model.ReleaseTime Publish Time
        /// Model.Hits Click Rate
        /// Model.Image Header Image
        /// Model.Images Image Collection
        /// Model.Desn Details
        /// </summary>
        public int Update(ArticlesModel Model)
        {
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ArticleID", SqlDbType.Int, 4) { Value = Model.ArticleID },
                new SqlParameter("@UpdateUserID", SqlDbType.Int, 4) { Value = Model.UpdateUserID },
                new SqlParameter("@BigID", SqlDbType.Int, 4) { Value = Model.BigID },
                new SqlParameter("@ArticleTitle", SqlDbType.NVarChar, 200) { Value = Model.ArticleTitle },
                new SqlParameter("@Articlekey", SqlDbType.NVarChar, 200) { Value = Model.Articlekey },
                new SqlParameter("@ArticleDesn", SqlDbType.NVarChar, 500) { Value = Model.ArticleDesn },
                new SqlParameter("@Statues", SqlDbType.Int, 4) { Value = Model.Statues },
                new SqlParameter("@Sorts", SqlDbType.Int, 4) { Value = Model.Sorts },
                new SqlParameter("@NavSites", SqlDbType.NVarChar, 200) { Value = Model.NavSites },
                new SqlParameter("@ReleaseTime", SqlDbType.DateTime, 8) { Value = Model.ReleaseTime },
                new SqlParameter("@Hits", SqlDbType.Int, 4) { Value = Model.Hits },
                new SqlParameter("@Image", SqlDbType.NVarChar, 500) { Value = Model.Image },
                new SqlParameter("@Images", SqlDbType.NVarChar, 500) { Value = Model.Images },
                new SqlParameter("@Desn", SqlDbType.NVarChar, -1) { Value = Model.Desn }
            };
            return SQLRUN.ExecuteStoredProcedureReturnValue("Articles_Update", parameters);
        }


        /// <summary>
        /// Delete Articles
        /// <param name="ArticleID"></param>
        /// <param name="UpdateUserID"></param>
        /// <returns>Affected rows</returns>
        /// </summary>
        public int Delete(int ArticleID,int UpdateUserID)
        {
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ArticleID", SqlDbType.Int, 4) { Value = ArticleID },
                new SqlParameter("@UpdateUserID", SqlDbType.Int, 4) { Value = UpdateUserID }
            };
            return SQLRUN.ExecuteStoredProcedureReturnValue("Articles_Delete", parameters);
        }


        /// <summary>
        /// Get single Articles
        /// </summary>
        /// <param name="ArticleID">Primary Key Value</param>
        /// <returns>ArticlesModel</returns>
        public ArticlesModel GetModel(int ArticleID)
        {
            ArticlesModel model = new ArticlesModel();
            DbHelper SQLRUN = new DbHelper();

            // Prepare parameters
            SqlParameter[] parameters =
            {
                new SqlParameter("@ArticleID", SqlDbType.Int, 4) { Value = ArticleID }
             };

            DataTable dataTable = SQLRUN.ExecuteStoredProcedureWithDataTable("Articles_GetModel", parameters);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["ArticleID"].ToString() != "")
                {
                    model.ArticleID = int.Parse(dataTable.Rows[0]["ArticleID"].ToString());
                }

                if (dataTable.Rows[0]["CreateUserID"].ToString() != "")
                {
                    model.CreateUserID = int.Parse(dataTable.Rows[0]["CreateUserID"].ToString());
                }

                if (dataTable.Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(dataTable.Rows[0]["CreateDate"].ToString());
                }

                if (dataTable.Rows[0]["UpdateUserID"].ToString() != "")
                {
                    model.UpdateUserID = int.Parse(dataTable.Rows[0]["UpdateUserID"].ToString());
                }

                if (dataTable.Rows[0]["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(dataTable.Rows[0]["UpdateDate"].ToString());
                }

                if (dataTable.Rows[0]["Del"].ToString() != "")
                {
                    model.Del = int.Parse(dataTable.Rows[0]["Del"].ToString());
                }

                if (dataTable.Rows[0]["BigID"].ToString() != "")
                {
                    model.BigID = int.Parse(dataTable.Rows[0]["BigID"].ToString());
                }

                model.ArticleTitle = dataTable.Rows[0]["ArticleTitle"].ToString();

                model.Articlekey = dataTable.Rows[0]["Articlekey"].ToString();

                model.ArticleDesn = dataTable.Rows[0]["ArticleDesn"].ToString();

                if (dataTable.Rows[0]["Statues"].ToString() != "")
                {
                    model.Statues = int.Parse(dataTable.Rows[0]["Statues"].ToString());
                }

                if (dataTable.Rows[0]["Sorts"].ToString() != "")
                {
                    model.Sorts = int.Parse(dataTable.Rows[0]["Sorts"].ToString());
                }

                model.NavSites = dataTable.Rows[0]["NavSites"].ToString();

                if (dataTable.Rows[0]["ReleaseTime"].ToString() != "")
                {
                    model.ReleaseTime = DateTime.Parse(dataTable.Rows[0]["ReleaseTime"].ToString());
                }

                if (dataTable.Rows[0]["Hits"].ToString() != "")
                {
                    model.Hits = int.Parse(dataTable.Rows[0]["Hits"].ToString());
                }

                model.Image = dataTable.Rows[0]["Image"].ToString();

                model.Images = dataTable.Rows[0]["Images"].ToString();

                model.Desn = dataTable.Rows[0]["Desn"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get Articles List
        /// </summary>
        /// <param name="BigID"></param>
        /// <param name="ArticleTitle"></param>
        /// <param name="StartRecord"></param>
        /// <param name="EndRecord"></param>
        /// <returns>DataTable</returns>
        public DataTable Get(int BigID,string ArticleTitle, int StartRecord, int EndRecord)
        {
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Prepare parameters
            SqlParameter[] parameters =
            {
                new SqlParameter("@BigID", SqlDbType.Int,4) { Value = BigID },
                new SqlParameter("@ArticleTitle", SqlDbType.NVarChar,50) { Value = ArticleTitle },
                new SqlParameter("@StartRecord", SqlDbType.Int,4) { Value = StartRecord },
                new SqlParameter("@EndRecord", SqlDbType.Int,4) { Value = EndRecord }
            };
            DR = SQLRUN.ExecuteStoredProcedureWithDataTable("Articles_Get", parameters);
            return DR;
        }

        /// <summary>
        /// Get Articles  Count
        /// </summary>
        /// <param name="BigID"></param>
        /// <param name="ArticleTitle"></param>
        /// <returns>DataTable</returns>
        public DataTable GetCount(int BigID, string ArticleTitle)
        {
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Prepare parameters
            SqlParameter[] parameters =
            {
                new SqlParameter("@BigID", SqlDbType.Int,4) { Value = BigID },
                new SqlParameter("@ArticleTitle", SqlDbType.NVarChar,50) { Value = ArticleTitle },
            };
            DR = SQLRUN.ExecuteStoredProcedureWithDataTable("Articles_GetCount", parameters);
            return DR;
        }

        /// <summary>
        /// Get Articles List
        /// </summary>
        /// <param name="BigID"></param>
        /// <param name="ArticleTitle"></param>
        /// <param name="StartRecord"></param>
        /// <param name="EndRecord"></param>
        /// <returns>DataTable</returns>
        public DataTable GetTop(int BigID, string ArticleTitle, int StartRecord, int EndRecord)
        {
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Prepare parameters
            SqlParameter[] parameters =
            {
                new SqlParameter("@BigID", SqlDbType.Int,4) { Value = BigID },
                new SqlParameter("@ArticleTitle", SqlDbType.NVarChar,50) { Value = ArticleTitle },
                new SqlParameter("@StartRecord", SqlDbType.Int,4) { Value = StartRecord },
                new SqlParameter("@EndRecord", SqlDbType.Int,4) { Value = EndRecord }
            };
            DR = SQLRUN.ExecuteStoredProcedureWithDataTable("Articles_GetTop", parameters);
            return DR;
        }

        /// <summary>
        /// Get Articles Count
        /// </summary>
        /// <param name="BigID"></param>
        /// <param name="ArticleTitle"></param>
        /// <returns>DataTable</returns>
        public DataTable GetTopCount(int BigID, string ArticleTitle)
        {
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Prepare parameters
            SqlParameter[] parameters =
            {
                new SqlParameter("@BigID", SqlDbType.Int,4) { Value = BigID },
                new SqlParameter("@ArticleTitle", SqlDbType.NVarChar,50) { Value = ArticleTitle },
            };
            DR = SQLRUN.ExecuteStoredProcedureWithDataTable("Articles_GetTopCount", parameters);
            return DR;
        }
        /// <summary>
        /// Get Articles List Daily Count for 30 Days
        /// </summary>
        /// <param name="StarTime">Start Time</param>
        /// <param name="EndTime">End Time</param>
        /// <returns>DataTable</returns>
        public DataTable GetCount30(DateTime StarTime,DateTime EndTime)
        {
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Prepare parameters
            SqlParameter[] parameters =
            {
                new SqlParameter("@StarTime", SqlDbType.DateTime,8) { Value = StarTime },
                new SqlParameter("@EndTime", SqlDbType.DateTime,8) { Value = EndTime },
            };
            DR = SQLRUN.ExecuteStoredProcedureWithDataTable("Articles_GetCount30", parameters);
            return DR;
        }

        /// <summary>
        /// Get Next Article
        /// </summary>
        /// <param name="ArticleID">Article ID</param>
        /// <returns>DataTable</returns>
        public DataTable GetNext(int ArticleID)
        {
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Prepare parameters
            SqlParameter[] parameters =
            {
                new SqlParameter("@ArticleID", SqlDbType.Int,4) { Value = ArticleID },
            };
            DR = SQLRUN.ExecuteStoredProcedureWithDataTable("Articles_GetNext", parameters);
            return DR;
        }
        /// <summary>
        /// Get Previous Article
        /// </summary>
        /// <param name="ArticleID">Article ID</param>
        /// <returns>DataTable</returns>
        public DataTable GetLast(int ArticleID)
        {
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Prepare parameters
            SqlParameter[] parameters =
            {
                new SqlParameter("@ArticleID", SqlDbType.Int,4) { Value = ArticleID },
            };
            DR = SQLRUN.ExecuteStoredProcedureWithDataTable("Articles_GetLast", parameters);
            return DR;
        }
    }

}
