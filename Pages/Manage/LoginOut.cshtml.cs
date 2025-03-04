using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace SunuerManageEn.Pages.Manage
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Ligout
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class LoginOutModel : PageModel
    {
       
        public void OnGet()
        {
            
            // Set cookie options
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, // Prevent access from client-side scripts                                
                SameSite = SameSiteMode.Strict, // Prevent CSRF attacks
                Expires = DateTime.Now.AddHours(-1) // Set expiration time based on hours
                ,Path = "/" // Ensure the path matches
            };
            // Save the JSON string to the cookie
            Response.Cookies.Append("SunuerCookie", "", cookieOptions);

            // Redirect to the login page
            Response.Redirect("/Manage/Login");

            ViewData["Title"] = "Sunuer Managae";
            ViewData["KeyWords"] = "Sunuer Managae";
            ViewData["Description"] = "Sunuer Managae";
        }
    }
}
