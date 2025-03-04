using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SunuerManageEn.Pages.Manage.Articless
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:CategoryEdit
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class ArticleCategoryEdtModel : PageModel
    {
        [BindProperty(SupportsGet = true)] // Allow binding via GET request
        public int BigID { get; set; } = 0;
        public ArticleCategory.ArticleCategoryModel Model = new ArticleCategory.ArticleCategoryModel();
        //Pass HTTP injection for GetIP
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ArticleCategoryEdtModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
        public void OnGet()
        {
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|19|") < 0)
            {
                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }
            if (BigID == 0)
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
            ArticleCategory.ArticleCategoryDal Dal = new ArticleCategory.ArticleCategoryDal();
            Model = Dal.GetModel(BigID);
            if (Model == null)
            {
                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }
        }
    }
}
