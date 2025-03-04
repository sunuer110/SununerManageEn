using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace SunuerManageEn.Pages.Manage.Admins
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:PermissionsEdit
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class AdminPowerEdtModel : PageModel
    {
        [BindProperty(SupportsGet = true)] // Allow binding via GET request
        public int PowerID { get; set; } = 0;
        public  AdminPower.AdminPowerModel Model = new AdminPower.AdminPowerModel();
        //Pass HTTP injection for GetIP
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminPowerEdtModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
        public void OnGet()
        {

            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|3|") < 0)
            {
                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }
            if (PowerID == 0)
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
            AdminPower.AdminPowerDal Dal = new AdminPower.AdminPowerDal();
            Model= Dal.GetModel(PowerID);
            if(Model==null)
            {
                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }
        }
    }
}
