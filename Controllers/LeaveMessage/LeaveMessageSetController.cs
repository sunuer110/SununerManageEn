using ApiResponse;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace Web.Controllers.LeaveMessageSets
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:LeaveMessageSet API
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveMessageSetController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LeaveMessageSetController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        // POST: api/LeaveMessageSet/Update
        //Modify Data via POST Request, Accepting an int Parameter (Default = 0 if Not Provided).
        [HttpPost("Update")]
        public ActionResult<ApiResponse<int>> Update(
        [FromForm] int SetID

        , [FromForm] int PhoneRequire
        , [FromForm] int NameRequire
        , [FromForm] int EmailRequire
        , [FromForm] string SystemEmail
        )
        {
            // Check if Parameters are Empty
            if (
            SetID < 0


            || PhoneRequire < 0
            || NameRequire < 0
            || EmailRequire < 0
            || string.IsNullOrWhiteSpace(SystemEmail)
            )
            {
                return BadRequest(new ApiResponse<int>
                {
                    code = 400,
                    msg = "Invalid Parameter Error",
                    count = 0,
                    data = 0
                });
            }

            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check Login Status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check Permissions
            if (AdminModel.Roles.IndexOf("|401|") < 0)
            {
                return Ok(new ApiResponse<int>
                {
                    code = 404,
                    msg = "No Permission",
                    count = 0,
                    data = 0
                });
            }
            else
            {
                var Model = new LeaveMessageSet.LeaveMessageSetModel
                {
                    // Assign Values to Data Model
                    SetID = SetID,// Configuration ID 
                    UpdateUserID = AdminModel.AdminID,// Updater 
                    PhoneRequire = PhoneRequire,// Phone (0 = Optional, 1 = Required) 
                    NameRequire = NameRequire,// Name (0 = Optional, 1 = Required) 
                    EmailRequire = EmailRequire,// Email (0 = Optional, 1 = Required) 
                    SystemEmail = SystemEmail,// System Email 
                };
                // Instantiate Data Access Layer Object (Responsible for Database Access Class)
                LeaveMessageSet.LeaveMessageSetDal Dal = new LeaveMessageSet.LeaveMessageSetDal();
                int ID = Dal.Update(Model);
                if (ID > 0)
                {
                    return Ok(new ApiResponse<int>
                    {
                        code = 0,
                        msg = "Update Success",
                        count = ID,
                        data = ID
                    });
                }
                else
                {
                    return Ok(new ApiResponse<int>
                    {
                        code = 404,
                        msg = "Update Failure",
                        count = 0,
                        data = 0
                    });
                }
            }
        }
    }
}