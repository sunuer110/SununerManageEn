using DBHelper;
using Admin;
using Microsoft.Data.SqlClient;
using System.Data;
using Tools;
using Azure.Core;
using Newtonsoft.Json;

namespace Admin
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:AdminDal
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class AdminDal
    {
        /// <summary>
        /// Add Admin-SQL Method
        /// Model.CreateUserID Creator
        /// Model.AdminName Username
        /// Model.AdminNick Nickname
        /// Model.PassWord Password
        /// Model.RoleID Role ID
        /// Model.Statues Status 0 (Normal), 1 (Frozen)
        /// </summary>
        /// <param name="Model">AdminModel</param>
        /// <returns>Affected rows</returns>
        public int Add(AdminModel Model)
        {
            //Password encryption
            string PassWord = Tools.Tools.MD5(Model.PassWord);
            string Sql = "insert into Admin ( CreateUserID,  AdminName, AdminNick, PassWord, RoleID, Statues) VALUES (@CreateUserID, @AdminName, @AdminNick, @PassWord, @RoleID, @Statues); select @@IDENTITY;";
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
        new SqlParameter("@CreateUserID", SqlDbType.Int, 4) { Value = Model.CreateUserID },
        new SqlParameter("@AdminName", SqlDbType.NVarChar, 50) { Value = Model.AdminName },
        new SqlParameter("@AdminNick", SqlDbType.NVarChar, 50) { Value = Model.AdminNick },
        new SqlParameter("@PassWord", SqlDbType.NVarChar, 200) { Value = PassWord },
        new SqlParameter("@RoleID", SqlDbType.Int, 4) { Value = Model.RoleID },
        new SqlParameter("@Statues", SqlDbType.Int, 4) { Value = Model.Statues }
    };
            return (Convert.ToInt32(SQLRUN.ExecuteScalar(Sql, CommandType.Text, parameters)));
        }


        /// <summary>
        /// Edit Admin-SQL Method
        /// Model.AdminID 
        /// Model.UpdateUserID Updated by
        /// Model.AdminName Username
        /// Model.AdminNick Nickname
        /// Model.PassWord Password 
        /// Model.RoleID Role ID
        /// Model.Statues Status 0 (Normal), 1 (Frozen)
        /// </summary>
        /// <param name="Model">AdminModel</param>
        /// <returns>Affected rows</returns>
        public int Update(AdminModel Model)
        {
            string PassWord = "";
            string Search = "";
            
            if (Model.PassWord!="")
            {
                //Password encryption
                PassWord = Tools.Tools.MD5(Model.PassWord);
                Search = Search + $" , PassWord = @PassWord";
            }

            string Sql = "UPDATE Admin SET UpdateUserID = @UpdateUserID, UpdateDate = getdate(),  AdminName = @AdminName, AdminNick = @AdminNick, RoleID = @RoleID, Statues = @Statues "+ Search + " WHERE AdminID = @AdminID;select @@rowcount;";
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
        new SqlParameter("@AdminID", SqlDbType.Int, 4) { Value = Model.AdminID },
        new SqlParameter("@UpdateUserID", SqlDbType.Int, 4) { Value = Model.UpdateUserID },
        new SqlParameter("@AdminName", SqlDbType.NVarChar, 50) { Value = Model.AdminName },
        new SqlParameter("@AdminNick", SqlDbType.NVarChar, 50) { Value = Model.AdminNick },
        new SqlParameter("@PassWord", SqlDbType.NVarChar, 200) { Value = PassWord },
        new SqlParameter("@RoleID", SqlDbType.Int, 4) { Value = Model.RoleID },
        new SqlParameter("@Statues", SqlDbType.Int, 4) { Value = Model.Statues }
    };
            return (Convert.ToInt32(SQLRUN.ExecuteScalar(Sql, CommandType.Text, parameters)));
        }


        /// <summary>
        /// Delete Admin-SQL Method
        /// <param name="AdminID"></param>
        /// <param name="UpdateUserID"></param>
        /// <returns>Affected rows</returns>
        /// </summary>
        public int Delete(int AdminID, int UpdateUserID)
        {
            string Sql = "update  Admin set Del=1,UpdateUserID=@UpdateUserID, UpdateDate = getdate() where AdminID = @AdminID;select @@rowcount;";
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
        new SqlParameter("@AdminID", SqlDbType.Int, 4) { Value = AdminID },
        new SqlParameter("@UpdateUserID", SqlDbType.Int, 4) { Value = UpdateUserID }
    };
            return Convert.ToInt32(SQLRUN.ExecuteScalar(Sql, CommandType.Text, parameters));
        }

        /// <summary>
        /// Change password
        /// <param name="AdminID"></param>
        /// <param name="UpdateUserID"></param>
        /// <returns>Affected rows</returns>
        /// </summary>
        public int UpdatePassWord(int AdminID, string OldPass,string Pass)
        {

            OldPass = Tools.Tools.MD5(OldPass);
            Pass = Tools.Tools.MD5(Pass);
            string Sql = "update  Admin set PassWord=@Pass,UpdateUserID=@AdminID, UpdateDate = getdate() where AdminID = @AdminID and PassWord=@OldPass;select @@rowcount;";
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
        new SqlParameter("@AdminID", SqlDbType.Int, 4) { Value = AdminID },
        new SqlParameter("@OldPass", SqlDbType.NVarChar,50) { Value = OldPass },
        new SqlParameter("@Pass", SqlDbType.NVarChar,50) { Value = Pass }
    };
            return Convert.ToInt32(SQLRUN.ExecuteScalar(Sql, CommandType.Text, parameters));
        }


        /// <summary>
        /// Get a single Admin record-SQL Method
        /// <param name="AdminID"></param>
        /// <returns>Return a single record model</returns>
        /// </summary>
        public AdminModel GetModel(int AdminID)
        {
            string Sql = "select n.*,b.RolesTitle from Admin as n left join AdminRoles as b on n.RoleID=b.RoleID where n.Del=0 and n.AdminID = @AdminID;";
            AdminModel Model = new AdminModel();
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
            {
        new SqlParameter("@AdminID", SqlDbType.Int, 4) { Value = AdminID }
    };
            DataTable dataTable = SQLRUN.ExecuteDataTable(Sql, CommandType.Text, parameters);
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                if (dataTable.Rows[0]["AdminID"].ToString() != "")
                {
                    Model.AdminID = int.Parse(dataTable.Rows[0]["AdminID"].ToString()!);
                }

                if (dataTable.Rows[0]["CreateUserID"].ToString() != "")
                {
                    Model.CreateUserID = int.Parse(dataTable.Rows[0]["CreateUserID"].ToString()!);
                }

                if (dataTable.Rows[0]["CreateDate"].ToString() != "")
                {
                    Model.CreateDate = DateTime.Parse(dataTable.Rows[0]["CreateDate"].ToString()!);
                }

                if (dataTable.Rows[0]["UpdateUserID"].ToString() != "")
                {
                    Model.UpdateUserID = int.Parse(dataTable.Rows[0]["UpdateUserID"].ToString()!);
                }

                if (dataTable.Rows[0]["UpdateDate"].ToString() != "")
                {
                    Model.UpdateDate = DateTime.Parse(dataTable.Rows[0]["UpdateDate"].ToString()!);
                }

                if (dataTable.Rows[0]["Del"].ToString() != "")
                {
                    Model.Del = int.Parse(dataTable.Rows[0]["Del"].ToString()!);
                }

                Model.AdminName = dataTable.Rows[0]["AdminName"].ToString();
                Model.RolesTitle = dataTable.Rows[0]["RolesTitle"].ToString();
                
                Model.AdminNick = dataTable.Rows[0]["AdminNick"].ToString();

                Model.PassWord = dataTable.Rows[0]["PassWord"].ToString();

                if (dataTable.Rows[0]["RoleID"].ToString() != "")
                {
                    Model.RoleID = int.Parse(dataTable.Rows[0]["RoleID"].ToString());
                }

                if (dataTable.Rows[0]["Statues"].ToString() != "")
                {
                    Model.Statues = int.Parse(dataTable.Rows[0]["Statues"].ToString());
                }

                if (dataTable.Rows[0]["LoginAttempts"].ToString() != "")
                {
                    Model.LoginAttempts = int.Parse(dataTable.Rows[0]["LoginAttempts"].ToString());
                }

                if (dataTable.Rows[0]["LoginAttemptsLast"].ToString() != "")
                {
                    Model.LoginAttemptsLast = DateTime.Parse(dataTable.Rows[0]["LoginAttemptsLast"].ToString());
                }

                return Model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Get the Admin list
        /// <param name="AdminName"></param>
        /// <param name="StartRecord"></param>
        /// <param name="EndRecord"></param>
        /// <returns>Return DataTable records</returns>
        /// </summary>
        public DataTable Get(string AdminName,int StartRecord, int EndRecord)
        {
            string Search = "";
            if(AdminName!="")
            {
                Search = Search + $" and charindex('{AdminName}',n.AdminName)>0";
            }
            string Sql = "select a.*,b.RolesTitle from(select row_number() over(order by  n.AdminID desc) as aid ,n.* FROM  [dbo].[Admin] as n where n.del=0 " + Search + ") as a left join AdminRoles as b on a.RoleID=b.RoleID where a.aid between @StartRecord and (@EndRecord+@StartRecord-1) order by aid asc";
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Prepare parameters
            SqlParameter[] parameters =
            {
        new SqlParameter("@StartRecord", SqlDbType.Int,4) { Value = StartRecord },
        new SqlParameter("@EndRecord", SqlDbType.Int,4) { Value = EndRecord },
        new SqlParameter("@AdminName", SqlDbType.NVarChar, 50) { Value = AdminName }
    };
            DR = SQLRUN.ExecuteDataTable(Sql, CommandType.Text, parameters);
            return DR;
        }

        /// <summary>
        /// Get the total number of Admins
        /// <returns>Return DataTable records</returns>
        /// </summary>
        public DataTable GetCount(string AdminName)
        {
            string Search = "";
            if (AdminName != "")
            {
                Search = Search + $" and charindex('{AdminName}',n.AdminName)>0";
            }
            string Sql = "select Count(n.AdminID) as Num from  [dbo].[Admin] as n where n.del=0"+ Search;
            DbHelper SQLRUN = new DbHelper();
            DataTable DR = null;
            // Prepare parameters
            SqlParameter[] parameters =
            {
        new SqlParameter("@AdminName", SqlDbType.NVarChar, 50) { Value = AdminName }
             };
            DR = SQLRUN.ExecuteDataTable(Sql, CommandType.Text, parameters);
            return DR;
        }

        /// <summary>
        /// Update login attempt count-SQL Method
        /// </summary>
        /// <param name="AdminName">Username</param>
        /// <param name="LoginAttempts">Login attempt count</param>
        /// <returns>Affected rows</returns>
        public int UpdateLoginAttempts(string AdminName, int LoginAttempts)
        {
            // Execute update operation and return @@rowcount value - Affected rows (there will be affected rows after update)
            string Sql = "update  Admin set LoginAttempts=@LoginAttempts, LoginAttemptsLast=getdate() where AdminName=@AdminName; SELECT @@rowcount;";
            DbHelper SQLRUN = new DbHelper();
            SqlParameter[] parameters =
           {
                new SqlParameter("@AdminName", SqlDbType.NVarChar,50) { Value =AdminName },
                new SqlParameter("@LoginAttempts", SqlDbType.Int,4) { Value =LoginAttempts}
            };
            // Execute SQL
            return (Convert.ToInt32(SQLRUN.ExecuteScalar(Sql, CommandType.Text, parameters)));
        }
        /// <summary>
        /// Get a single data model - Login
        /// </summary>
        /// <param name="AdminName">Username</param>
        /// <returns>AdminModel</returns>
        public AdminModel login(string AdminName)
        {
            string Sql = $"SELECT n.*,b.Powers as Roles  FROM [Admin] as n left join AdminRoles as b on n.RoleID=b.RoleID WHERE n.Statues=0 and  n.AdminName=@AdminName;";
            AdminModel Model = new AdminModel();
            DbHelper SQLRUN = new DbHelper();
            // Prepare parameters
            SqlParameter[] parameters =
            {
                new SqlParameter("@AdminName", SqlDbType.NVarChar,50) { Value =AdminName }
            };
            DataTable dataTable = SQLRUN.ExecuteDataTable(Sql, CommandType.Text, parameters);
            if (dataTable.Rows.Count > 0)
            {
                if (dataTable.Rows[0]["AdminID"].ToString() != "")
                {
                    Model.AdminID = int.Parse(dataTable.Rows[0]["AdminID"].ToString()!);
                }
                if (dataTable.Rows[0]["CreateUserID"].ToString() != "")
                {
                    Model.CreateUserID = int.Parse(dataTable.Rows[0]["CreateUserID"].ToString()!);
                }
                if (dataTable.Rows[0]["UpdateUserID"].ToString() != "")
                {
                    Model.UpdateUserID = int.Parse(dataTable.Rows[0]["UpdateUserID"].ToString()!);
                }
                if (dataTable.Rows[0]["CreateDate"].ToString() != "")
                {
                    Model.CreateDate = DateTime.Parse(dataTable.Rows[0]["CreateDate"].ToString()!);
                }
                if (dataTable.Rows[0]["UpdateDate"].ToString() != "")
                {
                    Model.UpdateDate = DateTime.Parse(dataTable.Rows[0]["UpdateDate"].ToString()!);
                }
                if (dataTable.Rows[0]["Del"].ToString() != "")
                {
                    Model.Del = int.Parse(dataTable.Rows[0]["Del"].ToString()!);
                }
                Model.AdminName = dataTable.Rows[0]["AdminName"].ToString()!;
                Model.PassWord = dataTable.Rows[0]["PassWord"].ToString()!;
                Model.AdminNick = dataTable.Rows[0]["AdminNick"].ToString()!;
                Model.Roles = dataTable.Rows[0]["Roles"].ToString()!;
                if (dataTable.Rows[0]["RoleID"].ToString() != "")
                {
                    Model.RoleID = int.Parse(dataTable.Rows[0]["RoleID"].ToString()!);
                }
                if (dataTable.Rows[0]["LoginAttempts"].ToString() != "")
                {
                    Model.LoginAttempts = int.Parse(dataTable.Rows[0]["LoginAttempts"].ToString()!);
                }
                if (dataTable.Rows[0]["LoginAttemptsLast"].ToString() != "")
                {
                    Model.LoginAttemptsLast = DateTime.Parse(dataTable.Rows[0]["LoginAttemptsLast"].ToString()!);
                }
                if (dataTable.Rows[0]["Statues"].ToString() != "")
                {
                    Model.Statues = int.Parse(dataTable.Rows[0]["Statues"].ToString()!);
                }

                return Model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Check if the user is logged in and authorized, return result set
        /// </summary>
        public static AdminLoginModel GetAdminCheckLogin(IHttpContextAccessor httpContextAccessor)
        {
            AdminLoginModel model = new AdminLoginModel();

            try
            {
                if (httpContextAccessor == null)
                {
                    throw new InvalidOperationException("HttpContextAccessor is not configured.");
                }
                // Get HttpContext, ensure it is not null
                var httpContext = httpContextAccessor.HttpContext;

                if (httpContext == null)
                {
                    throw new InvalidOperationException("HttpContext is null, ensure your middleware is properly configured.");
                }

                // Read JSON string from Cookie
                if (httpContext.Request.Cookies.TryGetValue("SunuerCookie", out var jsonFromCookie) &&
                    !string.IsNullOrEmpty(jsonFromCookie))
                {
                    // Decrypt Cookie content
                    string decryptedCookie = Tools.CBC.DecryptHtmlDecode(jsonFromCookie);

                    if (decryptedCookie != "Error")
                    {
                        // Deserialize to AdminLoginModel
                        model = JsonConvert.DeserializeObject<AdminLoginModel>(decryptedCookie)!;
                        if (model.IP != Tools.Tools.GetUserIp(httpContext))
                        {
                            httpContext.Response.Redirect("/Manage/Login");
                        }
                        //Determine if it is timed out
                        if (Tools.ConfigurationHelper.GetConfigValue("CookieExpires") != "")
                            if (model.DateTime.AddHours(Int32.Parse(Tools.ConfigurationHelper.GetConfigValue("CookieExpires")!)) < DateTime.Now)
                            {
                                httpContext.Response.Redirect("/Manage/Login");
                            }
                    }
                    else
                    {
                        // Decryption failed, redirect to login page
                        httpContext.Response.Redirect("/Manage/Login");
                    }
                }
                else
                {
                    // Cookie Does not exist or is empty, redirect to login page
                    httpContext.Response.Redirect("/Manage/Login");
                }
            }
            catch (Exception ex)
            {
                // Catch exception and log it
                Console.WriteLine($"Login validation failed: {ex.Message}");
                httpContextAccessor.HttpContext?.Response.Redirect("/Manage/Login");
            }

            return model;
        }
    }
}
