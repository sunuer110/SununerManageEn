using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace SunuerManageEn.Pages
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Home
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class IndexModel : PageModel
    {
        //List Menu
        public List<Articles.ArticlesModel> ArticlesList = new List<Articles.ArticlesModel>();
        public List<Articles.ArticlesModel> CaseList = new List<Articles.ArticlesModel>();
        public List<Articles.ArticlesModel> NewsList4 = new List<Articles.ArticlesModel>();
        public List<Articles.ArticlesModel> NewsList5 = new List<Articles.ArticlesModel>();
        public List<Articles.ArticlesModel> NewsList6 = new List<Articles.ArticlesModel>();

        public bool IsMobile { get; set; } = false;

        //Passing Parameters to Layout Page
        public SunuerManageEn.Pages.Shared.MenuModel? Menu { get; set; }
        public void OnGet()
        {
            //Passing Parameters to Layout Page
            var menu = new SunuerManageEn.Pages.Shared.MenuModel();
            menu.GetMenu();
            Menu = menu;  // Passing Menu Data

            //Assigning Basic Parameters to the Page
            ViewData["Title"] = Tools.ConfigurationHelper.GetConfigValue("ManageSet:ManageTitle");
            ViewData["KeyWords"] = Tools.ConfigurationHelper.GetConfigValue("ManageSet:ManageKey");
            ViewData["Description"] = Tools.ConfigurationHelper.GetConfigValue("ManageSet:ManageDesn");
            if (Tools.Tools.IsMobileDevice(HttpContext.Request))
            {
                IsMobile = true;
            }
            GetLunxian();
            GetCase();
            GetNews4();
            GetNews5();
            GetNews6();
        }
        public void GetLunxian()
        {
            //Slideshow
            Articles.ArticlesDal Dal = new Articles.ArticlesDal();
            if (IsMobile)
            {
                DataTable Datas = Dal.GetTop(12, "", 1, 12);
                ArticlesList = Tools.DataTableToList.DatatableToList<Articles.ArticlesModel>(Datas);
            }
            else
            {
                DataTable Datas = Dal.GetTop(11, "", 1, 12);
                ArticlesList = Tools.DataTableToList.DatatableToList<Articles.ArticlesModel>(Datas);
            }
        }
        public void GetCase()
        {
            //Cases
            Articles.ArticlesDal Dal = new Articles.ArticlesDal();

            DataTable Datas = Dal.GetTop(2, "", 1, 6);
            CaseList = Tools.DataTableToList.DatatableToList<Articles.ArticlesModel>(Datas);
        }
        public void GetNews4()
        {
            //News ID=4
            Articles.ArticlesDal Dal = new Articles.ArticlesDal();

            DataTable Datas = Dal.GetTop(4, "", 1, 5);
            NewsList4 = Tools.DataTableToList.DatatableToList<Articles.ArticlesModel>(Datas);
        }
        public void GetNews5()
        {
            //News ID=5
            Articles.ArticlesDal Dal = new Articles.ArticlesDal();

            DataTable Datas = Dal.GetTop(5, "", 1, 5);
            NewsList5 = Tools.DataTableToList.DatatableToList<Articles.ArticlesModel>(Datas);
        }
        public void GetNews6()
        {
            //News ID=6
            Articles.ArticlesDal Dal = new Articles.ArticlesDal();

            DataTable Datas = Dal.GetTop(6, "", 1, 5);
            NewsList6 = Tools.DataTableToList.DatatableToList<Articles.ArticlesModel>(Datas);
        }
    }

}