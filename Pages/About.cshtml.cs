using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace SunuerManageEn.Pages
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:About Us
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class AboutModel : PageModel
    {

        public string Phone = "";
        public string Next = "";
        public string Last = "";
        public Articles.ArticlesModel NewsList = new Articles.ArticlesModel();
        public ArticleCategory.ArticleCategoryModel Model = new ArticleCategory.ArticleCategoryModel();

        private int nid { get; set; } = 5;
        //Passing Parameters to Layout Page
        public SunuerManageEn.Pages.Shared.MenuModel? Menu { get; set; }
        public void OnGet()
        {
            //Passing Parameters to Layout Page
            var menu = new SunuerManageEn.Pages.Shared.MenuModel();
            menu.GetMenu();
            Menu = menu;  // Passing Menu Data

            Phone = Tools.ConfigurationHelper.GetConfigValue("ManageSet:Phone")!;
            GetModel();

        }
        public void GetModel()
        {
            Articles.ArticlesDal Dal = new Articles.ArticlesDal();
            NewsList = Dal.GetModel(nid);
            if (NewsList == null)
            {
                //Redirect to Home Page
                RedirectToPage("/");
            }
            else
            {
                GetCategoryModel(NewsList.BigID);
                ViewData["Title"] = NewsList.ArticleTitle;
                ViewData["KeyWords"] = NewsList.Articlekey;
                ViewData["Description"] = NewsList.ArticleDesn;
            }
        }

        public void GetCategoryModel(int nid)
        {
            ArticleCategory.ArticleCategoryDal Dal = new ArticleCategory.ArticleCategoryDal();
            Model = Dal.GetModel(nid);
            if (Model == null)
            {
                //Redirect to Home Page
                RedirectToPage("/");
            }
        }

       
    }
}
