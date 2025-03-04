using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SunuerManageEn.Pages.Manage.Articless
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Article Edit
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class ArticlesEdtModel : PageModel
    {
        [BindProperty(SupportsGet = true)] // Allow binding via GET request
        public int ArticleID { get; set; } = 0;
        public Articles.ArticlesModel Model = new Articles.ArticlesModel();
        //Pass HTTP injection for GetIP
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ArticlesEdtModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
        public void OnGet()
        {

            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);

            if (AdminModel.Roles.IndexOf("|22|") < 0)
            {
                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }
            if (ArticleID == 0)
            {

                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }
            else
            {
                GetModel();
            }

            ViewData["Title"] = "Sunuer Managae";
            ViewData["KeyWords"] = "Sunuer Managae";
            ViewData["Description"] = "Sunuer Managae";
        }

        public void GetModel()
        {
            Articles.ArticlesDal Dal = new Articles.ArticlesDal();
            Model = Dal.GetModel(ArticleID);
            if (Model == null)
            {
                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }
        }
    }
}
