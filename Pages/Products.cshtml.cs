using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace SunuerManageEn.Pages
{
    /// <summary>
      /// Project:Sunuer Manage
      /// Description:Products
      /// Author£ºHaiDong
      /// Site:https://www.sunuer.com
      /// Version: 1.0
      /// License£ºApache License 2.0
      /// </summary>
        public class ProductsModel : PageModel
        {
            public string Phone = "";
            public List<ArticleCategory.ArticleCategoryModel> ArticleCategoryList = new List<ArticleCategory.ArticleCategoryModel>();
            public List<Articles.ArticlesModel> CaseList = new List<Articles.ArticlesModel>();
            public ArticleCategory.ArticleCategoryModel Model = new ArticleCategory.ArticleCategoryModel();
            public int TotalRecords { get; set; }
            [BindProperty(SupportsGet = true)] // Allow binding through GET request
            public int CurrentPage { get; set; } = 1;
            public int PageSize { get; set; } = 6; // Items per page
            public int ShowSize { get; set; } = 2; // Show a specific number of pagination buttons

            [BindProperty(SupportsGet = true)] // Allow binding through GET request
            public int nid { get; set; } = 10;


            //Passing Parameters to Layout Page
            public SunuerManageEn.Pages.Shared.MenuModel? Menu { get; set; }
            public void OnGet()
            {
                //Passing Parameters to Layout Page
                var menu = new SunuerManageEn.Pages.Shared.MenuModel();
                menu.GetMenu();
                Menu = menu;  // Passing Menu Data
                Phone = Tools.ConfigurationHelper.GetConfigValue("ManageSet:Phone")!;
                GetMenu();
                GetCategoryModel();
                GetCase(CurrentPage);

            }

            public void GetMenu()
            {
                //Menu Information
                ArticleCategory.ArticleCategoryDal Dal = new ArticleCategory.ArticleCategoryDal();

                DataTable Datas = Dal.Get(1);
                ArticleCategoryList = Tools.DataTableToList.DatatableToList<ArticleCategory.ArticleCategoryModel>(Datas);
            }
            public void GetCase(int Page)
            {
                Console.WriteLine(Page.ToString());
                int StartRecord = (Page - 1) * PageSize + 1;

                // Calculate the number of items displayed per page
                int EndRecord = PageSize;
                //Slideshow
                Articles.ArticlesDal Dal = new Articles.ArticlesDal();
                TotalRecords = Int32.Parse(Dal.GetTopCount(nid, "").Rows[0]["Num"].ToString()!);
                DataTable Datas = Dal.GetTop(nid, "", StartRecord, EndRecord);
                CaseList = Tools.DataTableToList.DatatableToList<Articles.ArticlesModel>(Datas);
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
            }
        }
    }
