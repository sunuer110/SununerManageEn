using System;
using DBHelper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdminPower
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:AdminPowerDal
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class AdminPowerDal
    {

        /// <summary>
        /// Add AdminPower-SQL Method
        /// Model.CreateUserID Creator
        /// Model.ParentID Parent ID
        /// Model.PowerTitle Permission name
        /// </summary>
        /// <param name="Model">AdminPowerModel</param>
        /// <returns>Affected rows</returns>
        public int Add(AdminPowerModel Model)
        {
            string Sql = "insert into AdminPower (CreateUserID, ParentID, PowerTitle) VALUES (@CreateUserID, @ParentID, @PowerTitle); select @@IDENTITY;";
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
                new SqlParameter("@CreateUserID", SqlDbType.Int, 4) { Value = Model.CreateUserID },
                new SqlParameter("@ParentID", SqlDbType.Int, 4) { Value = Model.ParentID },
                new SqlParameter("@PowerTitle", SqlDbType.NVarChar, 50) { Value = Model.PowerTitle }
            };
            return (Convert.ToInt32(SQLRUN.ExecuteScalar(Sql, CommandType.Text, parameters)));
        }


        /// <summary>
        /// Edit AdminPower-SQL Method
        /// Model.PowerID 
        /// Model.UpdateUserID Updated by
        /// Model.ParentID Parent ID
        /// Model.PowerTitle Permission name
        /// </summary>
        /// <param name="Model">AdminPowerModel</param>
        /// <returns>Affected rows</returns>
        public int Update(AdminPowerModel Model)
        {
            string Sql = "UPDATE AdminPower SET  UpdateUserID = @UpdateUserID, UpdateDate = getdate(),  PowerTitle = @PowerTitle WHERE PowerID = @PowerID;select @@rowcount;";
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
                new SqlParameter("@PowerID", SqlDbType.Int, 4) { Value = Model.PowerID },
                new SqlParameter("@UpdateUserID", SqlDbType.Int, 4) { Value = Model.UpdateUserID },
                new SqlParameter("@PowerTitle", SqlDbType.NVarChar, 50) { Value = Model.PowerTitle },
            };
            return (Convert.ToInt32(SQLRUN.ExecuteScalar(Sql, CommandType.Text, parameters)));
        }


        /// <summary>
        /// Delete AdminPower-SQL Method
        /// <param name="PowerID"></param>
        /// <param name="UpdateUserID"></param>
        /// <returns>Affected rows</returns>
        /// </summary>
        public int Delete(int PowerID,int UpdateUserID)
        {
            string Sql = "update AdminPower set del=1 where PowerID = @PowerID;select @@rowcount;";
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
                new SqlParameter("@PowerID", SqlDbType.Int,4) { Value = PowerID },
                new SqlParameter("@UpdateUserID", SqlDbType.Int,4) { Value = UpdateUserID }
            };
            return Convert.ToInt32(SQLRUN.ExecuteScalar(Sql, CommandType.Text, parameters));
        }


        /// <summary>
        /// Get a single AdminPower record-SQL Method
        /// <param name="PowerID"></param>
        /// <returns>Return a single record model</returns>
        /// </summary>
        public AdminPowerModel GetModel(int PowerID)
        {
            string Sql = "select * from AdminPower where PowerID = @PowerID;";
            AdminPowerModel Model = new AdminPowerModel();
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
                new SqlParameter("@PowerID", SqlDbType.Int,4) { Value = PowerID }
    };
            DataTable dataTable = SQLRUN.ExecuteDataTable(Sql, CommandType.Text, parameters);
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                if (dataTable.Rows[0]["PowerID"].ToString() != "")
                {
                    Model.PowerID = int.Parse(dataTable.Rows[0]["PowerID"].ToString());
                }

                if (dataTable.Rows[0]["CreateUserID"].ToString() != "")
                {
                    Model.CreateUserID = int.Parse(dataTable.Rows[0]["CreateUserID"].ToString());
                }

                if (dataTable.Rows[0]["CreateDate"].ToString() != "")
                {
                    Model.CreateDate = DateTime.Parse(dataTable.Rows[0]["CreateDate"].ToString());
                }

                if (dataTable.Rows[0]["UpdateUserID"].ToString() != "")
                {
                    Model.UpdateUserID = int.Parse(dataTable.Rows[0]["UpdateUserID"].ToString());
                }

                if (dataTable.Rows[0]["UpdateDate"].ToString() != "")
                {
                    Model.UpdateDate = DateTime.Parse(dataTable.Rows[0]["UpdateDate"].ToString());
                }

                if (dataTable.Rows[0]["Del"].ToString() != "")
                {
                    Model.Del = int.Parse(dataTable.Rows[0]["Del"].ToString());
                }

                if (dataTable.Rows[0]["ParentID"].ToString() != "")
                {
                    Model.ParentID = int.Parse(dataTable.Rows[0]["ParentID"].ToString());
                }

                Model.PowerTitle = dataTable.Rows[0]["PowerTitle"].ToString();

                return Model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Get the AdminPower list
        /// <param name="ParentID"></param>
        /// <returns>Return DataTable records</returns>
        /// </summary>
        public DataTable Get(int ParentID)
        {
            string Sql = "select n.* FROM  [dbo].[AdminPower] as n where n.del=0 and ParentID=@ParentID order by PowerID asc";
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Prepare parameters
            SqlParameter[] parameters =
            {
                new SqlParameter("@ParentID", SqlDbType.Int,4) { Value = ParentID }
            };
            DR = SQLRUN.ExecuteDataTable(Sql, CommandType.Text, parameters);
            return DR;
        }

        /// <summary>
        /// Get the entire AdminPower list
        /// <returns>Return DataTable records</returns>
        /// </summary>
        public DataTable Get()
        {
            string Sql = "select n.* FROM  [dbo].[AdminPower] as n where n.del=0 order by ParentID asc";
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Prepare parameters
            SqlParameter[] parameters =
            {
            };
            DR = SQLRUN.ExecuteDataTable(Sql, CommandType.Text, parameters);
            return DR;
        }



    }

}