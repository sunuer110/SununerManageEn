using System.Data;

namespace Admin
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:AdminModel
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class AdminModel
    {
        public int AdminID { get; set; } = 0; // Administrator
        public int CreateUserID { get; set; } = 0; // Creator
        public DateTime CreateDate { get; set; } // Creation Time
        public int UpdateUserID { get; set; } = 0; // Updater
        public DateTime UpdateDate { get; set; } // Update Time
        public int Del { get; set; } = 0; // Delete 0 No 1 Yes
        public string AdminName { get; set; } = "";//Username
        public string PassWord { get; set; } = "";//Password
        public int RoleID { get; set; } = 0;//Role ID
        public string Roles { get; set; } = "";//Role collection
        public string RolesTitle { get; set; } = "";//Role name
        public string AdminNick { get; set; } = "";//Nickname
        public int Statues { get; set; } = 0;//Status 0 (Normal), 1 (Frozen)
        public int LoginAttempts { get; set; } = 0;// Login attempt count-Failed login attempts within 30 minutes will be recorded, and after 3 failed attempts within 30 minutes, login will be blocked to reduce the probability of brute force attacks
        public DateTime LoginAttemptsLast { get; set; }//Last login attempt time-Each time a login fails, the current login attempt time will be recorded
    }
    /// <summary>
    /// AdminLoginModel Login model
    /// </summary>
    public class AdminLoginModel
    {
        public int AdminID { get; set; } = 0;//Administrator ID
        public string AdminNick { get; set; } = "";//Nickname
        public string Roles { get; set; } = "";//Role collection
        public string IP { get; set; } = "";//IP
        public DateTime DateTime { get; set; }//Login time
    }
}
