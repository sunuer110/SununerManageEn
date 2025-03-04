using System;
using System.ComponentModel.DataAnnotations;

namespace ManageSet
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:ManageSetModel
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class ManageSetModel
    {
        public int ID { get; set; } = 0; // 
        public string ManageTitle { get; set; } = ""; // Manage Title
        public string ManageKey { get; set; } = ""; // Manage Keywords
        public string ManageDesn { get; set; } = ""; // Manage Description
        public string ManageUrl { get; set; } = ""; // Manage Link
        public string Phone { get; set; } = ""; // Phone
        public string Email { get; set; } = ""; // Email
        public string Address { get; set; } = ""; // Address
        public string CopyRight { get; set; } = ""; // CopyRight
        public string ImageUrl { get; set; } = ""; // Images URL
        public string About { get; set; } = ""; // Manage Description
        public string Logo { get; set; } = ""; // Logo
    }
}
