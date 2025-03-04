using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SunuerManageEn.Pages.Manage.Articless
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Article Add 
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class ArticlesAddModel : PageModel
    {

        [BindProperty(SupportsGet = true)] // Allow binding via GET request
        public int BigID { get; set; } = 0;
        //Pass HTTP injection for GetIP
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ArticlesAddModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
        public void OnGet()
        {
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|21|") < 0)
            {
                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }
            if (BigID < 0)
            {
                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }

            ViewData["Title"] = "Sunuer Managae";
            ViewData["KeyWords"] = "Sunuer Managae";
            ViewData["Description"] = "Sunuer Managae";
        }
    }
}
