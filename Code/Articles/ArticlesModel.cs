using System;
using System.ComponentModel.DataAnnotations;

namespace Articles
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:ArticlesModel
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class ArticlesModel
    {
        public int ArticleID { get; set; } = 0; // 
        public int CreateUserID { get; set; } = 0; // Creator
        public DateTime CreateDate { get; set; } // Creation Time
        public int UpdateUserID { get; set; } = 0; // Updater
        public DateTime UpdateDate { get; set; } // Update Time
        public int Del { get; set; } = 0; // Delete 0 No 1 Yes
        public int BigID { get; set; } = 0; // Category
        public string ArticleTitle { get; set; } = ""; // Title 
        public string Articlekey { get; set; } = ""; // Keywords
        public string ArticleDesn { get; set; } = ""; // Description
        public int Statues { get; set; } = 0; // Display: 0 = Yes, 1 = No
        public int Sorts { get; set; } = 0; // Sort Order
        public string NavSites { get; set; } = ""; // Redirect URL
        public DateTime ReleaseTime { get; set; } // Publish Time
        public int Hits { get; set; } = 0; // Click Rate
        public string Image { get; set; } = ""; // Header Image
        public string Images { get; set; } = ""; // Image Collection
        public string Desn { get; set; } = ""; // Details
        public string BigTitle { get; set; } =""; // Category Title
    }
}