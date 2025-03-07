using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Manage.LeaveMessages
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Audit
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class LeaveMessageAuditModel : PageModel
    {
        public LeaveMessageSet.LeaveMessageSetModel ModelSet = new LeaveMessageSet.LeaveMessageSetModel();
        public LeaveMessage.LeaveMessageModel Model = new LeaveMessage.LeaveMessageModel();
        [BindProperty(SupportsGet = true)] // Allow Binding via GET Request
        public string LeaveMessageIDs { get; set; } = "";
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LeaveMessageAuditModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
        public void OnGet()
        {
            //Check Login Status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check Permissions
            if (AdminModel.Roles.IndexOf("|403|") < 0)
            {
                // Redirect to Login Page
                Response.Redirect("/Manage/Login");
            }
            if (string.IsNullOrEmpty(LeaveMessageIDs)) {
                // Redirect to Login Page
                Response.Redirect("/Manage/Login");
            }
            GetModel();
            GetModelSet();
            ViewData["Title"] = "Sunuer Managae";
            ViewData["KeyWords"] = "Sunuer Managae";
            ViewData["Description"] = "Sunuer Managae";
        }
        public void GetModelSet()
        {
            LeaveMessageSet.LeaveMessageSetDal Dal = new LeaveMessageSet.LeaveMessageSetDal();
            ModelSet = Dal.GetModel(1);
            if (ModelSet == null)
            {
                //Configuration Information Not Found, Redirecting to Homepage.
                Response.Redirect("/");
            }
        }
        public void GetModel()
        {
            LeaveMessage.LeaveMessageDal Dal = new LeaveMessage.LeaveMessageDal();
            Model = Dal.GetModel(Int32.Parse(LeaveMessageIDs.Replace(",","").Trim()));
            if (Model == null)
            {
                //Configuration Information Not Found, Redirecting to Homepage.
                Response.Redirect("/");
            }
        }
    }
}
