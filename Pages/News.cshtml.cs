using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SunuerManageEn.Pages
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:News
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class NewsModel : PageModel
    {
        public string Phone = "";
        public List<Articles.ArticlesModel> NewsList = new List<Articles.ArticlesModel>();
        public ArticleCategory.ArticleCategoryModel Model = new ArticleCategory.ArticleCategoryModel();
        public List<ArticleCategory.ArticleCategoryModel> ModelList = new List<ArticleCategory.ArticleCategoryModel>();
        public int TotalRecords { get; set; }
        [BindProperty(SupportsGet = true)] // Allow binding via GET request
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 6; // Items per page
        public int ShowSize { get; set; } = 2; // Show how many pagination buttons

        [BindProperty(SupportsGet = true)] // Allow binding via GET request
        public int nid { get; set; } = 3;
        //Passing Parameters to Layout Page
        public SunuerManageEn.Pages.Shared.MenuModel? Menu { get; set; }
        public void OnGet()
        {
            //Passing Parameters to Layout Page
            var menu = new SunuerManageEn.Pages.Shared.MenuModel();
            menu.GetMenu();
            Menu = menu;  // Passing Menu Data

            Phone =Tools.ConfigurationHelper.GetConfigValue("ManageSet:Phone");
            GetCategoryModel();
            GetCase(CurrentPage);

        }

        public void GetCase(int Page)
        {
            int StartRecord = (Page - 1) * PageSize + 1;

            // Calculate the number of records per page
            int EndRecord = PageSize;
            //Slideshow
            Articles.ArticlesDal Dal = new Articles.ArticlesDal();
            TotalRecords = Int32.Parse(Dal.GetTopCount(nid, "").Rows[0]["Num"].ToString()!);
            DataTable Datas = Dal.GetTop(nid, "", StartRecord, EndRecord);
            NewsList = Tools.DataTableToList.DatatableToList<Articles.ArticlesModel>(Datas);
        }

        public void GetCategoryModel()
        {
            ArticleCategory.ArticleCategoryDal Dal = new ArticleCategory.ArticleCategoryDal();
            Model = Dal.GetModel(nid);
            if (Model == null)
            {
                //Redirect to Home Page
                RedirectToPage("/");
            }
            else
            {

                ViewData["Title"] = Model.KeyTitle;
                ViewData["KeyWords"] = Model.KeyWord;
                ViewData["Description"] = Model.KeyDesn;
            }
            //Get subcategories under a main category
            DataTable Datas = Dal.Get(3);
            ModelList = Tools.DataTableToList.DatatableToList<ArticleCategory.ArticleCategoryModel>(Datas);
        }
    }
}
