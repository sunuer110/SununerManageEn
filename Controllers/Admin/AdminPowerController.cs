using ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace SunuerManageEn.Controllers
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:AdminPower API
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPowerController : ControllerBase
    {
        // Use dependency injection to get IHttpContextAccessor – Retrieve the actual IP address
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminPowerController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        // POST: api/AdminPower/Add
        //Via POST request Request Add, parameter receives an int type, and if the parameter is not provided, the default value is 0. 
        [HttpPost("Add")]
        public ActionResult<ApiResponse<int>> Add([FromForm] int ParentID
, [FromForm] string PowerTitle
            )
        {  // Check if parameters are null
            if (string.IsNullOrWhiteSpace(PowerTitle) || ParentID < 0)
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
            if (AdminModel.Roles.IndexOf("|2|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  // Return the new ID
            }
            else
            {
                var Model = new AdminPower.AdminPowerModel
                {
                    // AdminModel Assign values to the data model
                    ParentID = ParentID,
                    PowerTitle = PowerTitle,
                    CreateUserID = AdminModel.AdminID
                };

                // Instantiate the data access layer object, which is responsible for database access
                AdminPower.AdminPowerDal Dal = new AdminPower.AdminPowerDal();
                int IsOk = Dal.Add(Model);
                if (IsOk > 0)
                {
                    return Ok(new ApiResponse<int> { code = 0, msg = "Add Success", count = 1, data = IsOk });  // Return the new ID
                }
                else
                {
                    return Ok(new ApiResponse<int> { code = 404, msg = "Add  Failed", count = 0, data = 0 });  // Return the new ID

                }
            }
        }
        // POST: api/AdminPower/Update
        //Update via a POST request and return the number of affected records。
        [HttpPost("Update")]//Define the Update method
        public ActionResult<ApiResponse<int>> Update([FromForm] int PowerID
, [FromForm] string PowerTitle
            )
        {

            // Check if parameters are null
            if (
             string.IsNullOrWhiteSpace(PowerTitle)
             || PowerID <= 0
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
            if (AdminModel.Roles.IndexOf("|3|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  // Return the new ID
            }
            else
            {
                var Model = new AdminPower.AdminPowerModel
                {
                    // AdminModel Assign values to the data model
                    PowerID = PowerID,
                    PowerTitle = PowerTitle,
                    UpdateUserID = AdminModel.AdminID
                };
                // Instantiate the data access layer object, which is responsible for database access
                AdminPower.AdminPowerDal Dal = new AdminPower.AdminPowerDal();
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

        // POST: api/AdminPower/Delete
        //Perform a DELETE via a POST request based on ID and return the number of deleted records。
        [HttpPost("Delete")]//Define the Delete method
        public ActionResult<ApiResponse<int>> Delete([FromForm] int PowerID)
        {
            // Check if parameters are null
            if (PowerID <= 0)
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
            if (AdminModel.Roles.IndexOf("|4|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  // Return the new ID
            }
            else
            {
                int UpdateUserID = AdminModel.AdminID;
                // Instantiate the data access layer object, which is responsible for database access
                AdminPower.AdminPowerDal Dal = new AdminPower.AdminPowerDal();
                int IsOk = Dal.Delete(PowerID, UpdateUserID);
                if (IsOk > 0)
                {
                    return Ok(new ApiResponse<int> { code = 0, msg = "Success", count = IsOk, data = IsOk });  //  Return the number of successful
                }
                else
                {
                    return Ok(new ApiResponse<int> { code = 404, msg = "Delete Failed", count = 0, data = 0 });  //  Return  Failed
                }
            }
        }
        // Post: api/AdminPower/Get
        // Via POST request。
        [HttpPost("Get")]  // Ensure the request path matches when the client requests the GET method api/AdminPower/Get
        public ActionResult<ApiResponse<IEnumerable<AdminPower.AdminPowerModel>>> Get([FromForm] int ParentID)
        {
           

            // Check if the pagination parameters are valid
            if (ParentID<0)
            {
                return BadRequest(new ApiResponse<int>
                {
                    code = 400,
                    msg = "Invalid input parameters.",
                    count = 0,
                    data = 0
                });
            }


            // Instantiate the data access layer object, which is responsible for database access
            AdminPower.AdminPowerDal Dal = new AdminPower.AdminPowerDal();

            // Call the Get method to retrieve data from the database
            DataTable Datas = Dal.Get(ParentID);

            // Use the utility method DataTableToList to convert the DataTable into a List<T>
            List<AdminPower.AdminPowerModel> List = Tools.DataTableToList.DatatableToList<AdminPower.AdminPowerModel>(Datas);

            // Return paginated data using a standardized API response format, including status code, message, total record count, and dat
            return Ok(new ApiResponse<IEnumerable<AdminPower.AdminPowerModel>>
            {
                code = 0,  // Status code 0 indicates success
                msg = "Success",  //  Return message "Success"
                count = List.Count,  //  Return the count of records on the current page
                data = List  //  Return the paginated data collection
            });
        }
        // Post: api/AdminPower/Get
        // Via POST request。
        [HttpPost("GetAll")]  // Ensure the request path matches when the client requests the GET method api/AdminPower/Get
        public ActionResult<ApiResponse<IEnumerable<AdminPower.AdminPowerModel>>> GetAll()
        {


            // Instantiate the data access layer object, which is responsible for database access
            AdminPower.AdminPowerDal Dal = new AdminPower.AdminPowerDal();

            // Call the Get method to retrieve data from the database
            DataTable Datas = Dal.Get();

            List<AdminPower.AdminPowerModel> List = Tools.DataTableToList.DatatableToList<AdminPower.AdminPowerModel>(Datas);

            // Return paginated data using a standardized API response format, including status code, message, total record count, and dat
            return Ok(new ApiResponse<IEnumerable<AdminPower.AdminPowerModel>>
            {
                code = 0,  // Status code 0 indicates success
                msg = "Success",  //  Return message "Success"
                count = List.Count,  //  Return the count of records on the current page
                data = List  //  Return the paginated data collection
            });
        }
    }
}
