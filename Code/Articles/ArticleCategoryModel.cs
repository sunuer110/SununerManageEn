using System;
using System.ComponentModel.DataAnnotations;

namespace ArticleCategory
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:ArticleCategoryModel
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class ArticleCategoryModel
    {
        public int BigID { get; set; } = 0; // Article Category
        public int CreateUserID { get; set; } = 0; // Creator
        public DateTime CreateDate { get; set; } // Creation Time
        public int UpdateUserID { get; set; } = 0; // Updater
        public DateTime UpdateDate { get; set; } // Update Time
        public int Del { get; set; } = 0; // Delete 0 No 1 Yes
        public int ParentID { get; set; } = 0; // Parent ID
        public int Depths { get; set; } = 0; // Depth defaults to 0, top-level is 1
        public string ParentIDs { get; set; } = ""; // All Parent IDs separated by commas
        public int ParentIDFirst { get; set; } = 0; // Top-level Parent ID
        public int Statues { get; set; } = 0; // Navigation (0: No, 1: Yes)
        public string BigTitle { get; set; } = ""; // Category Name
        public string KeyTitle { get; set; } = ""; // Optimized Title
        public string KeyWord { get; set; } = ""; // Keywords
        public string KeyDesn { get; set; } = ""; // Description
        public string Images { get; set; } = ""; // Images
        public string ImagesPhone { get; set; } = ""; // Mobile Image
        public string SiteUrl { get; set; } = ""; // Redirect Link
        public int Sorts { get; set; } = 0; // Sort in descending order (largest first)
    }
    public class SelectList
    {
        public string name { get; set; }//Attribute ID
        public int value { get; set; }  //Category ID
        public bool selected { get; set; }  //Is Selected
        public List<SelectList> children { get; set; }  //Category ID
    }
}