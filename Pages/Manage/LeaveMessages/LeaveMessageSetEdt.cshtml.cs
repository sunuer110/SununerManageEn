using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Web.Pages.Manage.LeaveMessages
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Message Configuration 
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class LeaveMessageSetEdtModel : PageModel
    {

        public LeaveMessageSet.LeaveMessageSetModel Model = new LeaveMessageSet.LeaveMessageSetModel();
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LeaveMessageSetEdtModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
        public void OnGet()
        {

            //Check Login Status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);

            if (AdminModel.Roles.IndexOf("|401|") < 0)
            {
                // Redirect to Login Page
                Response.Redirect("/Manage/Login");
            }
           
                GetModel();

            ViewData["Title"] = "Sunuer Managae";
            ViewData["KeyWords"] = "Sunuer Managae";
            ViewData["Description"] = "Sunuer Managae";
        }

        public void GetModel()
        {
            LeaveMessageSet.LeaveMessageSetDal Dal = new LeaveMessageSet.LeaveMessageSetDal();
            Model = Dal.GetModel(1);
            if (Model == null)
            {
                // Redirect to Login Page
                Response.Redirect("/Manage/Login");
            }
        }
        
    }
}
