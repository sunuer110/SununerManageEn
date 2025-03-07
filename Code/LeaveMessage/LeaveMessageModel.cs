using System;
using System.ComponentModel.DataAnnotations;

namespace LeaveMessage
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:LeaveMessageModel
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class LeaveMessageModel
    {
        public int LeaveMessageID { get; set; } = 0; // Message ID
        public int CreateUserID { get; set; } = 0; // Creator
        public DateTime CreateDate { get; set; } // Creation Time
        public int UpdateUserID { get; set; } = 0; // Updater
        public DateTime UpdateDate { get; set; } // Update Time
        public int Del { get; set; } = 0; // Deleted (0 = No, 1 = Yes)
        public string Title { get; set; } = ""; // Title
        public string Phone { get; set; } = ""; // Phone
        public string UserName { get; set; } = ""; // Name
        public string Content { get; set; } = ""; // Content
        public string Email { get; set; } = ""; // Email
        public int AuditUserID { get; set; } = 0; // Audit Person
        public int AuditStatus { get; set; } = 0; // Audit Status (0 = Not Audited, 1 = Approved, 2 = Rejected)
        public DateTime AuditTime { get; set; } // Audit Time
        public string AuditDesn { get; set; } = ""; // Audit Remarks
        public string AuditUserName { get; set; } = ""; // Audit Person Name
    }
}