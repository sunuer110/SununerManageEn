using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SunuerManageEn.Pages.Manage.Admins
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:User edit
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class AdminEdtModel : PageModel
    { 
        [BindProperty(SupportsGet = true)] // Allow binding via GET request
        public int AdminID { get; set; } = 0;
        public Admin.AdminModel Model = new Admin.AdminModel();
        //Pass HTTP injection for GetIP
        private readonly IHttpContextAccessor _httpContextAccessor;
        //Inject the Getappsettings.json string
        private readonly IConfiguration _configuration;
        public AdminEdtModel(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        public Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
        public void OnGet()
        {
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|11|")  < 0)
            {
                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }
            if (AdminID == 0)
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
            Admin.AdminDal Dal = new Admin.AdminDal();
            Model = Dal.GetModel(AdminID);
            if (Model == null)
            {
                // Redirect to the login page
                Response.Redirect("/Manage/Login");
            }
        }
    }
}
