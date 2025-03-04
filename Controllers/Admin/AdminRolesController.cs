using ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace SunuerManageEn.Controllers
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:AdminRoles API
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRolesController : ControllerBase
    {
        // Use dependency injection to get IHttpContextAccessor – Retrieve the actual IP address
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminRolesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        // POST: api/AdminRoles/Add
        //Via POST request Request to Add new data, receiving an integer parameter; if the parameter is not provided, the default value is 0 
        [HttpPost("Add")]
        public ActionResult<ApiResponse<int>> Add(
                        [FromForm] string RolesTitle,
                        [FromForm] string Powers
            )
        {  // Check if parameters are null
            if (string.IsNullOrWhiteSpace(RolesTitle)|| string.IsNullOrWhiteSpace(Powers) )
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
            if (AdminModel.Roles.IndexOf("|6|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  //  Return New data ID
            }
            else
            {
                var Model = new AdminRoles.AdminRolesModel
                {
                    //Assign values to the data model
                    RolesTitle = RolesTitle,
                    Powers = Powers,
                    CreateUserID = AdminModel.AdminID
                };

                // Instantiate the data access layer object; ExampleDal is the class responsible for database access
                AdminRoles.AdminRolesDal Dal = new AdminRoles.AdminRolesDal();
                int UserID = Dal.Add(Model);
                if (UserID > 0)
                {
                    return Ok(new ApiResponse<int> { code = 0, msg = "Add Success", count = 1, data = UserID });
                }
                else
                {
                    return Ok(new ApiResponse<int> { code = 404, msg = "Add  Failed", count = 0, data = 0 });

                }
            }
        }
        // POST: api/AdminRoles/Update
        //Via POST request Request to Update the data password and return the number of affected records.。
        [HttpPost("Update")]//Define the Update method
        public ActionResult<ApiResponse<int>> Update([FromForm] int RoleID,
                        [FromForm] string RolesTitle,
                        [FromForm] string Powers
            )
        {

            // Check if parameters are null
            if (
             string.IsNullOrWhiteSpace(RolesTitle)
             ||string.IsNullOrWhiteSpace(Powers)
             || RoleID <= 0
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
            if (AdminModel.Roles.IndexOf("|7|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  //  Return New data ID
            }
            else
            {
                var Model = new AdminRoles.AdminRolesModel
                {
                    //Assign values to the data model
                    RoleID = RoleID,
                    RolesTitle = RolesTitle,
                    Powers = Powers,
                    UpdateUserID = AdminModel.AdminID
                };
                // Instantiate the data access layer object; AdminDal is the class responsible for database access
                AdminRoles.AdminRolesDal Dal = new AdminRoles.AdminRolesDal();
                int IsOk = Dal.Update(Model);

                if (IsOk > 0)
                {
                    return Ok(new ApiResponse<int> { code = 0, msg = "UpdateSuccess", count = IsOk, data = IsOk });  //  Return the number of successful
                }
                else
                {
                    return Ok(new ApiResponse<int> { code = 404, msg = "Update Failed", count = 0, data = 0 });  //  Return  Failed
                }
            }
        }

        // POST: api/AdminRoles/Delete
        //Perform a DELETE via a POST request based on ID and return the number of deleted records。
        [HttpPost("Delete")]//Define the Delete method
        public ActionResult<ApiResponse<int>> Delete([FromForm] string RoleIDs)
        {
            // Check if parameters are null
            if (
             string.IsNullOrWhiteSpace(RoleIDs) 
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
            if (AdminModel.Roles.IndexOf("|8|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  //  Return New data ID
            }
            else
            {
                int UpdateUserID = AdminModel.AdminID;
                // Instantiate the data access layer object; ExampleDal is the class responsible for database access
                AdminRoles.AdminRolesDal Dal = new AdminRoles.AdminRolesDal();
                // Convert the comma-separated string to a list of integers
                var idList = RoleIDs.Split(',')
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
        // Get: api/AdminRoles/Get
        // Via GET request。
        [HttpGet("Get")]  // When the client requests the GET method, the path needs to match api/AdminRoles/Get
        public ActionResult<ApiResponse<IEnumerable<AdminRoles.AdminRolesModel>>> Get([FromQuery] string? RolesTitle, [FromQuery] int Page, [FromQuery] int PageSize)
        {

            // If RolesTitle is null or empty, set it to "", meaning no filtering will be applied
            if (string.IsNullOrEmpty(RolesTitle))
            {
                RolesTitle = ""; // If no value or an empty string is passed, do not filter by name during the query
            }

            // Check if the pagination parameters are valid
            if (Page <= 0 || PageSize <= 0)
            {
                return BadRequest(new ApiResponse<int>
                {
                    code = 400,
                    msg = "Invalid input parameters.",
                    count = 0,
                    data = 0
                });
            }

            // Calculate the starting record: the index of the first data entry for pagination, where Page is the current page number and PageSize is the number of records per page
            int StartRecord = (Page - 1) * PageSize + 1;

            // Calculate the number of records per page
            int EndRecord = PageSize;
            // Calculate the number of records per page

            // Instantiate the data access layer object; AdminDal is the class responsible for database access
            AdminRoles.AdminRolesDal Dal = new AdminRoles.AdminRolesDal();

            // Call the Get method to retrieve data from the database
            DataTable Datas = Dal.Get(RolesTitle,StartRecord, EndRecord);

            // Use the utility method DataTableToList to convert the DataTable into a List<T>
            List<AdminRoles.AdminRolesModel> List = Tools.DataTableToList.DatatableToList<AdminRoles.AdminRolesModel>(Datas);

            DataTable Data = Dal.GetCount(RolesTitle);
            int Number = Int32.Parse(Data.Rows[0]["Num"].ToString()!);
            // Return paginated data using a standardized API response format, including status code, message, total record count, and dat
            return Ok(new ApiResponse<IEnumerable<AdminRoles.AdminRolesModel>>
            {
                code = 0,  // Status code 0 indicates success
                msg = "Success",  //  Return message "Success"
                count = Number,  //  Return the count of records on the current page
                data = List  //  Return the paginated data collection
            });
        }
    }
}
