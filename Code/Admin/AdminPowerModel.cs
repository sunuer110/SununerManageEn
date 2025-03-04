using System;
using System.ComponentModel.DataAnnotations;

namespace AdminPower
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:AdminPowerModel
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class AdminPowerModel
    {
        public int PowerID { get; set; } = 0; // 
        public int CreateUserID { get; set; } = 0; // Creator
        public DateTime CreateDate { get; set; } // Creation Time
        public int UpdateUserID { get; set; } = 0; // Updater
        public DateTime UpdateDate { get; set; } // Update Time
        public int Del { get; set; } = 0; // Delete 0 No 1 Yes
        public int ParentID { get; set; } = 0; // Parent ID
        public string PowerTitle { get; set; } = ""; // Permission name
    }
}