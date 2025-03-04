using Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebSite.Pages.Manage
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Admin Dashboard
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class admin_indexModel : PageModel
    {

        //Pass HTTP injection for GetIP
        private readonly IHttpContextAccessor _httpContextAccessor;
        public admin_indexModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
        public void OnGet()
        {
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);

            ViewData["Title"] = "Sunuer Managae";
            ViewData["KeyWords"] = "Sunuer Managae";
            ViewData["Description"] = "Sunuer Managae";
        }
    }
}
