using ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace SunuerManageEn.Controllers.ManageSets
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:System Settings
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ManageSetController : ControllerBase
    {

        // Use dependency injection to get IHttpContextAccessor – Retrieve the actual IP address
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ManageSetController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        // POST: api/ManageSet/Update
        //Via POST request Request to Update the data password and return the number of affected records.。
        [HttpPost("Update")]//Define the Update method
        public ActionResult<ApiResponse<int>> Update(
              [FromForm] string ManageTitle
            , [FromForm] string? ManageKey
            , [FromForm] string? ManageDesn
            , [FromForm] string? ManageUrl
            , [FromForm] string? Phone
            , [FromForm] string? Email
            , [FromForm] string? Address
            , [FromForm] string? CopyRight
            , [FromForm] string? ImageUrl
            , [FromForm] string? About
            , [FromForm] string? Logo
            )
        {

            // Check if parameters are null
            if (string.IsNullOrWhiteSpace(ManageTitle)
             )
            {
                return BadRequest(new ApiResponse<int>
                {
                    code = 400,
                    msg = "Ensure the passed parameters are not null",
                    count = 0,
                    data = 0
                });
            }

            //Backend parameter check for null or empty
            //ManageKey Validation
            if (string.IsNullOrWhiteSpace(ManageKey))
            {
                ManageKey = "";
            }
            //ManageDesn Validation
            if (string.IsNullOrWhiteSpace(ManageDesn))
            {
                ManageDesn = "";
            }
            //ManageUrl Validation
            if (string.IsNullOrWhiteSpace(ManageUrl))
            {
                ManageUrl = "";
            }
            //Phone Validation
            if (string.IsNullOrWhiteSpace(Phone))
            {
                Phone = "";
            }
            //Email Validation
            if (string.IsNullOrWhiteSpace(Email))
            {
                Email = "";
            }
            //Address Validation
            if (string.IsNullOrWhiteSpace(Address))
            {
                Address = "";
            }
            //CopyRight Validation
            if (string.IsNullOrWhiteSpace(CopyRight))
            {
                CopyRight = "";
            }
            //ImageUrl Validation
            if (string.IsNullOrWhiteSpace(ImageUrl))
            {
                ImageUrl = "";
            }
            //About Validation
            if (string.IsNullOrWhiteSpace(About))
            {
                About = "";
            }
            //Logo Validation
            if (string.IsNullOrWhiteSpace(Logo))
            {
                Logo = "";
            }
            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|24|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  //  Return New data ID
            }
            else
            {
                // Read the existing appsettings.json file
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                var json = System.IO.File.ReadAllText(filePath);
                // Parse the JSON content
                var jsonObj = JObject.Parse(json);

                // Update the specified key-value pairs
                var appSettings = jsonObj["ManageSet"];
                if (appSettings != null)
                {
                    appSettings["ManageTitle"] = ManageTitle;
                    appSettings["ManageKey"] = ManageKey;
                    appSettings["ManageDesn"] = ManageDesn;
                    appSettings["ManageUrl"] = ManageUrl;
                    appSettings["Phone"] = Phone;
                    appSettings["Email"] = Email;
                    appSettings["Address"] = Address;
                    appSettings["CopyRight"] = CopyRight;
                    appSettings["ImageUrl"] = ImageUrl;
                    appSettings["About"] = About;
                    appSettings["Logo"] = Logo;
                }

                // Write the updated JSON content back to appsettings.json
                System.IO.File.WriteAllText(filePath, jsonObj.ToString());
                return Ok(new ApiResponse<int> { code = 0, msg = "UpdateSuccess", count = 1, data = 1 });  //  Return the number of successful
                
            }
        }

    }
}
