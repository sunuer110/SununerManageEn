using Admin;
using ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace SunuerManageEn.Controllers
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Admin API
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        // Use dependency injection to get IHttpContextAccessor – Retrieve the actual IP address
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        // POST: api/Admin/Login
        //Login via POST request, receive parameters
        [HttpPost("Login")]
        public ActionResult<ApiResponse<int>> Login([FromForm] string AdminName, [FromForm] string PassWord, [FromForm] string text)
        {  // Check if parameters are null
            if (string.IsNullOrWhiteSpace(AdminName) || string.IsNullOrWhiteSpace(PassWord) || string.IsNullOrWhiteSpace(text))
            {
                return BadRequest(new ApiResponse<int>
                {
                    code = 400,
                    msg = "Ensure the passed parameters are not null",
                    count = 0,
                    data = 0
                });
            }
            //Encrypt on the frontend using JavaScript and decrypt on the backend to ensure the login process is secure
            JsEncrypt.JsEncryptHelper newRSA = new JsEncrypt.JsEncryptHelper();
            //Perform decryption
            text = newRSA.Decrypt(text);
            AdminName = newRSA.Decrypt(AdminName);
            PassWord = newRSA.Decrypt(PassWord);

            string chkcode = Request.Cookies["CaptchaCode"] ?? string.Empty;
            if (!string.IsNullOrEmpty(chkcode) && Tools.CBC.DecryptHtmlDecode(chkcode) != "Error")
            {
                chkcode = Tools.CBC.DecryptHtmlDecode(chkcode);
                if (!chkcode.Equals(chkcode.ToUpper()))//Convert the system-generated value to uppercase if it is not already in uppercase
                    chkcode.ToUpper();
                if (text.ToUpper().Trim().Equals(chkcode.Trim())) //Convert the input verification code to uppercase and compare it with the system-generated one
                {

                    //  Console.WriteLine("AdminName"+ AdminName);
                    // Instantiate the data access layer object; AdminDal is the class responsible for database access
                    Admin.AdminDal Dal = new Admin.AdminDal();
                    Admin.AdminModel Model = new Admin.AdminModel();
                    Model = Dal.login(AdminName);
                    if (Model != null)
                    {
                        int LoginAttempts = Model.LoginAttempts;
                        //Lock the account after three failed login attempts
                        if (Model.LoginAttempts >= 3 && Model.LoginAttemptsLast.AddMinutes(30) > DateTime.Now)
                        {
                            return Ok(new ApiResponse<int> { code = 404, msg = "Please try again in 30 minutes", count = 0, data = -2 });  // Return login failed message
                        }
                        else
                        {
                            if (Model.PassWord == Tools.Tools.MD5(PassWord))
                            {


                                //Save Cookies
                                // Create an object to store in the cookie
                                var cookieData = new
                                {
                                    AdminID = Model.AdminID,//User ID
                                    Roles = Model.Roles, // User Role Name
                                    AdminNick = Model.AdminNick, // Nickname
                                    IP = Tools.Tools.GetUserIp(_httpContextAccessor.HttpContext ?? throw new InvalidOperationException("HttpContext is null.")),// Call the GetUserIp method and pass the current HttpContext
                                    DateTime = DateTime.Now
                                };
                                // Serialize the object to a JSON string
                                string jsonString = JsonConvert.SerializeObject(cookieData);
                                //Encrypt the string
                                jsonString = Tools.CBC.HtmlEncodeEncrypt(jsonString);
                                int Hours = 0;

                                if (Tools.ConfigurationHelper.GetConfigValue("CookieExpires") != "")
                                {
                                    Hours = Int32.Parse(Tools.ConfigurationHelper.GetConfigValue("CookieExpires")!);
                                }
                                // Set cookie options
                                var cookieOptions = new CookieOptions
                                {
                                    HttpOnly = true, // Prevent access from client-side scripts
                                    //  Secure = true, // Transmit only over HTTPS connections
                                    SameSite = SameSiteMode.Strict, // Prevent CSRF attacks
                                    Expires = Hours == 0 ? null : DateTime.Now.AddHours(Hours) // Set expiration time based on hours
                                    ,
                                    Path = "/" // Ensure the path matches
                                };
                                // Save the JSON string to the cookie
                                Response.Cookies.Append("SunuerCookie", jsonString, cookieOptions);

                                //Update the login attempt count
                                Dal.UpdateLoginAttempts(AdminName, 0);
                                return Ok(new ApiResponse<int> { code = 0, msg = "Success", count = 1, data = 1 });  // Return login successful
                            }
                            else
                            {
                                Dal.UpdateLoginAttempts(AdminName, LoginAttempts + 1);
                                return Ok(new ApiResponse<int> { code = 404, msg = "Account or password error", count = 0, data = 0 });  // Return login failed message

                            }
                        }
                    }
                    else
                    {
                        return Ok(new ApiResponse<int> { code = 404, msg = "User does not exist", count = 0, data = -1 });  // User does not exist
                    }
                }
                else
                {

                    return Ok(new ApiResponse<int> { code = 404, msg = "Verification code error", count = 0, data = 0 });  // Verification code error
                }
            }
            else
            {

                return Ok(new ApiResponse<int> { code = 404, msg = "Verification code error", count = 0, data = 0 });  // Verification code error
            }
        }
        // POST: api/Admin/Add
        //Add new data via a POST request, receiving an integer parameter; if the parameter is not provided, the default value is 0 
        [HttpPost("Add")]
        public ActionResult<ApiResponse<int>> Add([FromForm] string AdminName
, [FromForm] string AdminNick
, [FromForm] string PassWord
, [FromForm] int RoleID
, [FromForm] int Statues
            )
        {  // Check if parameters are null
            if (string.IsNullOrWhiteSpace(AdminName) || string.IsNullOrWhiteSpace(AdminNick) || string.IsNullOrWhiteSpace(PassWord))
            {
                return BadRequest(new ApiResponse<int>
                {
                    code = 400,
                    msg = "Ensure the passed parameters are not null",
                    count = 0,
                    data = 0
                });
            }
            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|10|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  // Return the new ID
            }
            else
            {
                var Model = new Admin.AdminModel
                {
                    // AdminModel Assign values to the data model
                    AdminName = AdminName,
                    AdminNick = AdminNick,
                    PassWord = PassWord,
                    RoleID = RoleID,
                    Statues = Statues,
                    CreateUserID = AdminModel.AdminID
                };

                // Instantiate the data access layer object, which is responsible for database access
                Admin.AdminDal Dal = new Admin.AdminDal();
                int UserID = Dal.Add(Model);
                if (UserID > 0)
                {
                    return Ok(new ApiResponse<int> { code = 0, msg = "Add Success", count = 1, data = UserID });  // Return the new ID
                }
                else
                {
                    return Ok(new ApiResponse<int> { code = 404, msg = "Add Failed", count = 0, data = 0 });  // Return the new ID

                }
            }
        }
        // POST: api/Admin/Update
        //Update via a POST request and return the number of affected records。
        [HttpPost("Update")]//Define the Update method
        public ActionResult<ApiResponse<int>> Update([FromForm] int AdminID
           , [FromForm] string AdminName
, [FromForm] string AdminNick
, [FromForm] string? PassWord
, [FromForm] int RoleID
, [FromForm] int Statues)
        {
            // Check if parameters are null
            if (string.IsNullOrWhiteSpace(AdminName) || string.IsNullOrWhiteSpace(AdminNick) || AdminID <= 0)
            {
                return BadRequest(new ApiResponse<int>
                {
                    code = 400,
                    msg = "Ensure the passed parameters are not null",
                    count = 0,
                    data = 0
                });
            }
            // If PassWord is null or empty, set it to "", indicating no filtering will be applied.
            if (string.IsNullOrEmpty(PassWord))
            {
                PassWord = ""; 
            }

            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|11|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  // Return the new ID
            }
            else
            {
                var Model = new Admin.AdminModel
                {
                    // AdminModel Assign values to the data model
                    AdminID = AdminID,
                    AdminName = AdminName,
                    AdminNick = AdminNick,
                    PassWord = PassWord,
                    RoleID = RoleID,
                    Statues = Statues,
                    UpdateUserID = AdminModel.AdminID
                };
                // Instantiate the data access layer object, which is responsible for database access
                Admin.AdminDal Dal = new Admin.AdminDal();
                int IsOk = Dal.Update(Model);

                if (IsOk > 0)
                {
                    return Ok(new ApiResponse<int> { code = 0, msg = "UpdateSuccess", count = IsOk, data = IsOk });  //  Return the number of successful
                }
                else
                {
                    return Ok(new ApiResponse<int> { code = 404, msg = "Update Failed", count = 0, data = 0 });  // Return Failed
                }
            }
        }

        // POST: api/Admin/Delete
        //Perform a DELETE via a POST request based on ID and return the number of deleted records。
        [HttpPost("Delete")]//Define the Delete method
        public ActionResult<ApiResponse<int>> Delete([FromForm] string AdminIDs)
        {
            // Check if parameters are null
            if (

             string.IsNullOrWhiteSpace(AdminIDs)
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
            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|12|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  // Return the new ID
            }
            else
            {
                int UpdateUserID = AdminModel.AdminID;
                // Instantiate the data access layer object, which is responsible for database access
                Admin.AdminDal Dal = new Admin.AdminDal();
                // Convert the comma-separated string to a list of integers
                var idList = AdminIDs.Split(',')
                             .Where(id => int.TryParse(id.Trim(), out _)) // Ensure each value is a valid number
                             .Select(id => int.Parse(id.Trim()))
                             .ToList();

                // Initialize a variable to store the IDs to be deleted
                var removedIds = new List<int>();
                int IsOk = 0;
                // Iterate through each ID, find and delete the corresponding item
                foreach (var id in idList)
                {
                    IsOk = Dal.Delete(id, UpdateUserID);
                }
                if (IsOk > 0)
                {
                    return Ok(new ApiResponse<int> { code = 0, msg = "DeleteSuccess", count = IsOk, data = IsOk });  //  Return the number of successful
                }
                else
                {
                    return Ok(new ApiResponse<int> { code = 404, msg = "Delete Failed", count = 0, data = 0 });  //  Return  Failed
                }
            }
        }

        // POST: api/Admin/PassWordChange password
        //Perform a DELETE via a POST request based on ID and return the number of deleted records。
        [HttpPost("PassWord")]//Define the Delete method
        public ActionResult<ApiResponse<int>> PassWord([FromForm] string OldPass, [FromForm] string Pass)
        {
            // Check if parameters are null
            if (
             string.IsNullOrWhiteSpace(OldPass)
             || string.IsNullOrWhiteSpace(Pass)
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
            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|15|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  // Return the new ID
            }
            else
            {
                int AdminID = AdminModel.AdminID;
                // Instantiate the data access layer object, which is responsible for database access
                Admin.AdminDal Dal = new Admin.AdminDal();
                int IsOk = Dal.UpdatePassWord(AdminID, OldPass, Pass);

                if (IsOk > 0)
                {
                    return Ok(new ApiResponse<int> { code = 0, msg = "UpdateSuccess", count = IsOk, data = IsOk });  //  Return the number of successful
                }
                else
                {
                    return Ok(new ApiResponse<int> { code = 404, msg = "Update Failed,Please confirm if the password is correct", count = 0, data = 0 });  //  Return  Failed
                }
            }
        }
        // GET: api/Admin/Get
        // Get paginated data via a GET request, controlled by AdminName, Page, and PageSize parameter。
        [HttpGet("Get")]  // Ensure the request path matches when the client requests the GET method api/Admin/Get
        public ActionResult<ApiResponse<IEnumerable<Admin.AdminModel>>> Get([FromQuery] string? AdminName, [FromQuery] int Page, [FromQuery] int PageSize)
        {

            // If AdminName is null or empty, set it to "", meaning no filtering will be applied
            if (string.IsNullOrEmpty(AdminName))
            {
                AdminName = ""; // If no value or an empty string is passed, do not filter by name during the query
            }

            // Check if the pagination parameters are valid
            if (Page <= 0 || PageSize <= 0)
            {
                return BadRequest(new ApiResponse<int>
                {
                    code = 400,
                    msg = "Invalid pagination parameters received",
                    count = 0,
                    data = 0
                });
            }

            // Calculate the starting record: the index of the first data entry for pagination, where Page is the current page number and PageSize is the number of records per page
            int StartRecord = (Page - 1) * PageSize + 1;

            // Calculate the number of records per page
            int EndRecord = PageSize;

            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|9|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  // Return the new ID
            }
            else
            {
                // Instantiate the data access layer object, which is responsible for database access
                Admin.AdminDal Dal = new Admin.AdminDal();

                // Call the Get method to retrieve data from the database with pagination parameters: AdminName, starting record index, and records per page
                DataTable Datas = Dal.Get(AdminName, StartRecord, EndRecord);

                // Use the utility method DataTableToList to convert the DataTable into a List<T>, where T is an instance of the AdminModel class
                List<Admin.AdminModel> List = Tools.DataTableToList.DatatableToList<Admin.AdminModel>(Datas);

                DataTable Data = Dal.GetCount(AdminName);
                int Number = Int32.Parse(Data.Rows[0]["Num"].ToString()!);
                // Return paginated data using a standardized API response format, including status code, message, total record count, and data
                return Ok(new ApiResponse<IEnumerable<Admin.AdminModel>>
                {
                    code = 0,  // Status code 0 indicates success
                    msg = "Success",  //  Return message "Success"
                    count = Number,  //  Return the count of records on the current page
                    data = List  //  Return the paginated data collection
                });
            }
        }
    }
}
