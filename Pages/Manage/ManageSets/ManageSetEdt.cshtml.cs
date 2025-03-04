using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SunuerManageEn.Pages.Manage.ManageSets
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:System Settings
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class ManageSetEdtModel : PageModel
    {

        public ManageSet.ManageSetModel Model = new ManageSet.ManageSetModel();
        //Pass HTTP injection for GetIP
        private readonly IHttpContextAccessor _httpContextAccessor;
        //Inject the Getappsettings.json string
        private readonly IConfiguration _configuration;
        public ManageSetEdtModel(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        public Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
        public void OnGet()
        {

            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);

            if (AdminModel.Roles.IndexOf("|24|") < 0)
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
            Model.ManageTitle= _configuration["ManageSet:ManageTitle"]!;
            Model.ManageKey = _configuration["ManageSet:ManageKey"]!;
            Model.ManageDesn = _configuration["ManageSet:ManageDesn"]!;
            Model.ManageUrl = _configuration["ManageSet:ManageUrl"]!;
            Model.Phone = _configuration["ManageSet:Phone"]!;
            Model.Email = _configuration["ManageSet:Email"]!;
            Model.Address = _configuration["ManageSet:Address"]!;
            Model.CopyRight = _configuration["ManageSet:CopyRight"]!;
            Model.ImageUrl = _configuration["ManageSet:ImageUrl"]!;
            Model.About = _configuration["ManageSet:About"]!;
            Model.Logo = _configuration["ManageSet:Logo"]!;
        }
        
    }
}
