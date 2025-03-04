using System;
using System.ComponentModel.DataAnnotations;

namespace AdminRoles
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:AdminRolesModel
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class AdminRolesModel
    {
        public int RoleID { get; set; } = 0; // 
        public int CreateUserID { get; set; } = 0; // Creator
        public DateTime CreateDate { get; set; } // Creation Time
        public int UpdateUserID { get; set; } = 0; // Updater
        public DateTime UpdateDate { get; set; } // Update Time
        public int Del { get; set; } = 0; // Delete 0 No 1 Yes
        public string RolesTitle { get; set; } = ""; // Role name
        public string Powers { get; set; } = ""; // Permission collection
    }
}