using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SunuerManageEn.Pages.Manage.Admins
{/// <summary>
 /// Project:Sunuer Manage
 /// Description:Change password
 /// Author£ºHaiDong
 /// Site:https://www.sunuer.com
 /// Version: 1.0
 /// License£ºApache License 2.0
 /// </summary>
    public class AdminPassWordModel : PageModel
    {
        [BindProperty(SupportsGet = true)] // Allow binding via GET request
        public int RoleID { get; set; } = 0;
        public Admin.AdminModel Model = new Admin.AdminModel();
        //Pass HTTP injection for GetIP
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminPassWordModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
        public void OnGet()
        {
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|14|") < 0)
            {
                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }
            GetModel();

            ViewData["Title"] = "Sunuer Managae";
            ViewData["KeyWords"] = "Sunuer Managae";
            ViewData["Description"] = "Sunuer Managae";
        }

        public void GetModel()
        {
            Admin.AdminDal Dal = new Admin.AdminDal();
            Model = Dal.GetModel(AdminModel.AdminID);
            if (Model == null)
            {
                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }
        }
    }
}
