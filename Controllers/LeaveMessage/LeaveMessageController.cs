using ApiResponse;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Web.Controllers.LeaveMessages
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:LeaveMessage API
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveMessageController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LeaveMessageController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        // POST: api/LeaveMessage/Add
        //Add New Data via POST Request Parameter Type: int (Default = 0 if not provided)
        [HttpPost("Add")]
        public ActionResult<ApiResponse<int>> Add(
       
        [FromForm] string Title
        , [FromForm] string? Phone
        , [FromForm] string? UserName
        , [FromForm] string Content
        , [FromForm] string? Email
        
        )
        {
            //Check if Parameters are Empty
            if (
           
             string.IsNullOrWhiteSpace(Title)
            
            || string.IsNullOrWhiteSpace(Content)
         
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
            //Backend Parameter Validation
            //Phone Verification
            if (string.IsNullOrWhiteSpace(Phone))
            {
                Phone = "";
            }
            //UserName Verification
            if (string.IsNullOrWhiteSpace(UserName))
            {
                UserName = "";
            }
            //Email Verification
            if (string.IsNullOrWhiteSpace(Email))
            {
                Email = "";
            }
           
                var Model = new LeaveMessage.LeaveMessageModel
                {
                    //Assign Values to Data Model
                    CreateUserID = 0,// CreatorID=0
                    Title = Title,// Title 
                    Phone = Phone,// Phone 
                    UserName = UserName,// Name 
                    Content = Content,// Content 
                    Email = Email,// Email 

                };
                // Instantiate Data Access Layer Object (Responsible for Database Access Class)
                LeaveMessage.LeaveMessageDal Dal = new LeaveMessage.LeaveMessageDal();
                int ID = Dal.Add(Model);
                if (ID > 0)
                {
                    LeaveMessageSet.LeaveMessageSetDal Dal2 = new LeaveMessageSet.LeaveMessageSetDal();
                    LeaveMessageSet.LeaveMessageSetModel Model2 = Dal2.GetModel(1);
                    // Send Email Notification to Administrator After Successfully Adding a Message
                    bindEmail(Model, Model2.SystemEmail);



                    return Ok(new ApiResponse<int>
                    {
                        code = 0,
                        msg = "Add Success",
                        count = 1,
                        data = ID
                    });
                }
                else
                {
                    return Ok(new ApiResponse<int>
                    {
                        code = 404,
                        msg = "Add Failure",
                        count = 0,
                        data = 0
                    });
                }
           
        }

        // Get: api/LeaveMessage/Get
        //Retrieve Paginated Data via GET Request, Controlled by Title, Page, and PageSize Parameters.
        [HttpGet("Get")]
        public ActionResult<ApiResponse<int>> Get(
        [FromQuery] string? Title, [FromQuery] string? UserName,[FromQuery] int? AuditStatus, [FromQuery] int Page, [FromQuery] int PageSize
        )
        {
            //If Title is null or empty, set it to "" to indicate no filtering. 
            if (string.IsNullOrEmpty(Title))
            {
                Title = ""; //If no value is passed or an empty string is provided, no filtering will be applied during the query.
            }
            //If UserName is null or empty, set it to "" to indicate no filtering.
            if (string.IsNullOrEmpty(UserName))
            {
                UserName = ""; //If no value is passed or an empty string is provided, no filtering will be applied during the query.
            }
            // If AuditStatus is null or empty, set it to "" to indicate no filtering.
            if (string.IsNullOrEmpty(AuditStatus.ToString()) || AuditStatus < 0)
            {
                AuditStatus = -1; // If no value is passed or an empty string is provided, no filtering will be applied during the query.
            }
            // Check if Pagination Parameters are Valid
            if (
            Page <= 0 || PageSize <= 0
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
            //Calculate Start Record: The index of the first data entry in pagination. Page represents the current page number, and PageSize represents the number of records displayed per page.
            int StartRecord = (Page - 1) * PageSize + 1;
            //Calculate the Number of Records per Page 
            int EndRecord = PageSize;
            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check Login Status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check Permissions
            if (AdminModel.Roles.IndexOf("|402|") < 0)
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
                int UpdateUserID = AdminModel.AdminID;
                // Instantiate Data Access Layer Object (Responsible for Database Access Class)
                LeaveMessage.LeaveMessageDal Dal = new LeaveMessage.LeaveMessageDal();
                //Call the Get Method to Retrieve Data from the Database, passing pagination parameters: Title, Start Record, and PageSize.
                DataTable Datas = Dal.Get(StartRecord, EndRecord,Title, UserName, (int)AuditStatus);
                // Convert DataTable to List<T> using the Utility Method DataTableToList, where T is an instance of the AdminModel class.
                List<LeaveMessage.LeaveMessageModel> List = Tools.DataTableToList.DatatableToList<LeaveMessage.LeaveMessageModel>(Datas);
                DataTable Data = Dal.GetCount(Title, UserName, (int)AuditStatus);
                int Number = Int32.Parse(Data.Rows[0]["Num"].ToString()!);
                // Return Paginated Data Using a Unified API Response Format, including status code, message, total record count, and data collection.
                return Ok(new ApiResponse<IEnumerable<LeaveMessage.LeaveMessageModel>>
                {
                    code = 0,
                    msg = " Success",
                    count = Number,
                    data = List
                });
            }
        }

        // POST: api/LeaveMessage/Audit
        // Review via POST Request Based on ID and Return the Number of Reviewed Records.
        [HttpPost("Audit")]
        public ActionResult<ApiResponse<int>> Audit(
        [FromForm] string LeaveMessageIDs,
        [FromForm] int AuditStatus,
        [FromForm] string? AuditDesn
        )
        {
            // Check if Parameters are Empty
            if (
            string.IsNullOrWhiteSpace(LeaveMessageIDs)
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

            if (string.IsNullOrEmpty(AuditDesn))
            {
                AuditDesn = "";
            }

            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check Login Status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check Permissions
            if (AdminModel.Roles.IndexOf("|403|") < 0)
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
                int UpdateUserID = AdminModel.AdminID;
                // Instantiate Data Access Layer Object (Responsible for Database Access Class)
                LeaveMessage.LeaveMessageDal Dal = new LeaveMessage.LeaveMessageDal();
                //Convert a Comma-Separated String into an Integer List.
                var idList = LeaveMessageIDs.Split(',').Where(id => int.TryParse(id.Trim(), out _)).Select(id => int.Parse(id.Trim())).ToList();
                //Initialize a Variable to Store the IDs to be Deleted.
                var removedIds = new List<int>();
                int ID = 0;
                // Iterate Through Each ID to Find and Delete the Corresponding Item.
                foreach (var id in idList)
                {
                    // Loop Through and Review Data.
                    ID = Dal.Audit(id, UpdateUserID, AuditStatus, AuditDesn);
                }
                if (ID > 0)
                {
                    return Ok(new ApiResponse<int>
                    {
                        code = 0,
                        msg = "Audit Success",
                        count = ID,
                        data = ID
                    });
                }
                else
                {
                    return Ok(new ApiResponse<int>
                    {
                        code = 404,
                        msg = "Audit Failure",
                        count = 0,
                        data = 0
                    });
                }
            }
        }
        // POST: api/LeaveMessage/Delete
        //Delete by ID via POST Request and Return the Number of Deleted Records.
        [HttpPost("Delete")]
        public ActionResult<ApiResponse<int>> Delete(
        [FromForm] string LeaveMessageIDs
        )
        {
            // Check if Parameters are Empty
            if (
            string.IsNullOrWhiteSpace(LeaveMessageIDs)
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
            if (AdminModel.Roles.IndexOf("|404|") < 0)
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
                int UpdateUserID = AdminModel.AdminID;
                // Instantiate Data Access Layer Object (Responsible for Database Access Class)
                LeaveMessage.LeaveMessageDal Dal = new LeaveMessage.LeaveMessageDal();
                //Convert a Comma-Separated String into an Integer List.
                var idList = LeaveMessageIDs.Split(',').Where(id => int.TryParse(id.Trim(), out _)).Select(id => int.Parse(id.Trim())).ToList();
                //Initialize a Variable to Store the IDs to be Deleted.
                var removedIds = new List<int>();
                int ID = 0;
                // Iterate Through Each ID to Find and Delete the Corresponding Item.
                foreach (var id in idList)
                {
                    ID = Dal.Delete(id, UpdateUserID);
                }
                if (ID > 0)
                {
                    return Ok(new ApiResponse<int>
                    {
                        code = 0,
                        msg = "Delete Success",
                        count = ID,
                        data = ID
                    });
                }
                else
                {
                    return Ok(new ApiResponse<int>
                    {
                        code = 404,
                        msg = "Delete Failure",
                        count = 0,
                        data = 0
                    });
                }
            }
        }

        // ************ Send Email-Star ************//
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            //Always Return true for Certificate Verification.
            return true;
        }
        // Send Email
        public void bindEmail(LeaveMessage.LeaveMessageModel model, string receiveEmail)
        {
            string Subject = "Sunner Manage--Message Reminder";
            string Content = $"New Message Received:<br/>Message User:{model.UserName}<br/>Phone:{model.Phone}<br/>Email:{model.Email}<br/>Title:{model.Title}<br/>Content:{model.Content}";

            string Receiver = receiveEmail;

            SmtpClient client = new SmtpClient("emall smtp", 587);
            MailMessage msg = new MailMessage("you email address", Receiver, Subject, Content);
            msg.IsBodyHtml = true;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("you email address", "you email send password");
            client.Credentials = basicAuthenticationInfo;
            client.Send(msg);

        }
        // ************ Send Email-End ************//

    }
}