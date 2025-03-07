using System;
using System.ComponentModel.DataAnnotations;

namespace LeaveMessageSet
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:LeaveMessageSetModel
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class LeaveMessageSetModel
    {
        public int SetID { get; set; } = 0; // Configuration ID
        public int CreateUserID { get; set; } = 0; // Creator
        public DateTime CreateDate { get; set; } // Creation Time
        public int UpdateUserID { get; set; } = 0; // Updater
        public DateTime UpdateDate { get; set; } // Update Time
        public int Del { get; set; } = 0; // Deleted (0 = No, 1 = Yes)
        public int PhoneRequire { get; set; } = 0; // Phone (0 = Optional, 1 = Required)
        public int NameRequire { get; set; } = 0; // Name (0 = Optional, 1 = Required)
        public int EmailRequire { get; set; } = 0; // Email (0 = Optional, 1 = Required)
        public string SystemEmail { get; set; } = ""; // System Email
    }
}