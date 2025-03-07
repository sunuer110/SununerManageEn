using System;
using DBHelper;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeaveMessage
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:LeaveMessageDal
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class LeaveMessageDal
    {
        /// <summary>
        /// Add LeaveMessage Message 
        /// Model.CreateUserID Creator
        /// Model.Title Title
        /// Model.Phone Phone
        /// Model.UserName Name
        /// Model.Content Content
        /// Model.Email Email

        /// </summary>
        public int Add(LeaveMessageModel Model)
        {
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
              
                new SqlParameter("@CreateUserID", SqlDbType.Int, 4) { Value = Model.CreateUserID },
                new SqlParameter("@Title", SqlDbType.NVarChar, 50) { Value = Model.Title },
                new SqlParameter("@Phone", SqlDbType.NVarChar, 50) { Value = Model.Phone },
                new SqlParameter("@UserName", SqlDbType.NVarChar, 50) { Value = Model.UserName },
                new SqlParameter("@Content", SqlDbType.NVarChar, 500) { Value = Model.Content },
                new SqlParameter("@Email", SqlDbType.NVarChar, 50) { Value = Model.Email },
              
            };
            return SQLRUN.ExecuteStoredProcedureReturnValue("LeaveMessage_Add", parameters);
        }
        /// <summary>
        /// Delete LeaveMessage Message
        /// <param name="LeaveMessageID">Message ID</param>
        /// <param name="UpdateUserID">Updater</param>
        /// <returns>Number of Rows Affected</returns>
        /// </summary>
        public int Delete(int LeaveMessageID, int UpdateUserID)
        {
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
         new SqlParameter("@LeaveMessageID", SqlDbType.Int, 4) { Value = LeaveMessageID },
         new SqlParameter("@UpdateUserID", SqlDbType.Int,4) { Value = UpdateUserID }
     };
            return SQLRUN.ExecuteStoredProcedureReturnValue("LeaveMessage_Delete", parameters);
        }
        /// <summary>
        /// Get Single Data Model - LeaveMessage
        /// </summary>
        /// <param name="LeaveMessageID">Primary Key Value</param>
        /// <returns>LeaveMessageModel</returns>
        public LeaveMessageModel GetModel(int LeaveMessageID)
        {
            LeaveMessageModel model = new LeaveMessageModel();
            DbHelper SQLRUN = new DbHelper();

            // Parameter
            SqlParameter[] parameters =
            {
                new SqlParameter("@LeaveMessageID", SqlDbType.Int, 4) { Value = LeaveMessageID }
             };

            DataTable dataTable = SQLRUN.ExecuteStoredProcedureWithDataTable("LeaveMessage_GetModel", parameters);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["LeaveMessageID"].ToString() != "")
                {
                    model.LeaveMessageID = int.Parse(dataTable.Rows[0]["LeaveMessageID"].ToString());
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

                model.Title = dataTable.Rows[0]["Title"].ToString();

                model.Phone = dataTable.Rows[0]["Phone"].ToString();

                model.UserName = dataTable.Rows[0]["UserName"].ToString();

                model.Content = dataTable.Rows[0]["Content"].ToString();

                model.Email = dataTable.Rows[0]["Email"].ToString();

                if (dataTable.Rows[0]["AuditUserID"].ToString() != "")
                {
                    model.AuditUserID = int.Parse(dataTable.Rows[0]["AuditUserID"].ToString());
                }

                if (dataTable.Rows[0]["AuditStatus"].ToString() != "")
                {
                    model.AuditStatus = int.Parse(dataTable.Rows[0]["AuditStatus"].ToString());
                }

                if (dataTable.Rows[0]["AuditTime"].ToString() != "")
                {
                    model.AuditTime = DateTime.Parse(dataTable.Rows[0]["AuditTime"].ToString());
                }

                model.AuditDesn = dataTable.Rows[0]["AuditDesn"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get LeaveMessage List
        /// </summary>
        /// <param name="StartRecord">Page Number</param>
        /// <param name="EndRecord">Items Per Page</param>
        /// <returns>DataTable</returns>
        public DataTable Get(int StartRecord, int EndRecord,string Title,string UserName,int AuditStatus)
        {
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Parameter
            SqlParameter[] parameters =
            {
                new SqlParameter("@StartRecord", SqlDbType.Int,4) { Value = StartRecord },
                new SqlParameter("@EndRecord", SqlDbType.Int,4) { Value = EndRecord },
                new SqlParameter("@Title", SqlDbType.NVarChar, 50) { Value = Title },
                new SqlParameter("@UserName", SqlDbType.NVarChar, 50) { Value = UserName },
                new SqlParameter("@AuditStatus", SqlDbType.Int, 4) { Value = AuditStatus },

            };
            DR = SQLRUN.ExecuteStoredProcedureWithDataTable("LeaveMessage_Get", parameters);
            return DR;
        }

        /// <summary>
        /// Get LeaveMessage List
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetCount(string Title, string UserName,int AuditStatus)
        {
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Parameter
            SqlParameter[] parameters =
            {
                new SqlParameter("@Title", SqlDbType.NVarChar, 50) { Value = Title },
                new SqlParameter("@UserName", SqlDbType.NVarChar, 50) { Value = UserName },
                new SqlParameter("@AuditStatus", SqlDbType.Int, 4) { Value = AuditStatus },

            };
            DR = SQLRUN.ExecuteStoredProcedureWithDataTable("LeaveMessage_GetCount", parameters);
            return DR;
        }
        /// <summary>
        /// Audit LeaveMessage 
        /// <param name="LeaveMessageID"></param>
        /// <param name="UpdateUserID"></param>
        /// <param name="AuditStatus"></param>
        /// <param name="AuditDesn"></param>
        /// <returns>Number of Rows Affected</returns>
        /// </summary>
        public int Audit(int LeaveMessageID, int UpdateUserID, int AuditStatus, string AuditDesn)
        {
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
                new SqlParameter("@LeaveMessageID", SqlDbType.Int, 4) { Value = LeaveMessageID },
                new SqlParameter("@UpdateUserID", SqlDbType.Int, 4) { Value = UpdateUserID },
                new SqlParameter("@AuditStatus", SqlDbType.Int, 4) { Value = AuditStatus },
                new SqlParameter("@AuditDesn", SqlDbType.NVarChar, 500) { Value = AuditDesn },

            };
            return SQLRUN.ExecuteStoredProcedureReturnValue("LeaveMessage_Audit", parameters);
        }
    }

}
