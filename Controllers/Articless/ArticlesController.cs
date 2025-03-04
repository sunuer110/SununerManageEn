using ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace SunuerManageEn.Controllers.Articless
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Articles API
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        // Use dependency injection to get IHttpContextAccessor – Retrieve the actual IP address
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ArticlesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        // POST: api/Articles/Add
        //Via POST request Request to Add new data, receiving an integer parameter; if the parameter is not provided, the default value is 0 
        [HttpPost("Add")]
        public ActionResult<ApiResponse<int>> Add(
         [FromForm] int BigID
        , [FromForm] string ArticleTitle
        , [FromForm] string? Articlekey
        , [FromForm] string? ArticleDesn
        , [FromForm] int Statues
        , [FromForm] int Sorts
        , [FromForm] int Hits
        , [FromForm] string? NavSites
        , [FromForm] string ReleaseTime
        , [FromForm] string? Image
        , [FromForm] string? Images
        , [FromForm] string? Desn
            )
        {  // Check if parameters are null
            if (string.IsNullOrWhiteSpace(ArticleTitle)  || string.IsNullOrWhiteSpace(ReleaseTime) || BigID < 0 || Sorts < 0 || Statues < 0 || Hits < 0
               || !DateTime.TryParse(ReleaseTime, out DateTime releaseDate)
                )
            {
                return BadRequest(new ApiResponse<int>
                {
                    code = 400,
                    msg = "Invalid input parameters",
                    count = 0,
                    data = 0
                });
            }

            //Backend parameter check for null or empty

            //Articlekey Validation
            if (string.IsNullOrWhiteSpace(Articlekey))
            {
                Articlekey = "";
            }
            //ArticleDesn Validation
            if (string.IsNullOrWhiteSpace(ArticleDesn))
            {
                ArticleDesn = "";
            }
            //NavSites Validation
            if (string.IsNullOrWhiteSpace(NavSites))
            {
                NavSites = "";
            }
            //ReleaseTime Validation
            if (string.IsNullOrWhiteSpace(ReleaseTime))
            {
                ReleaseTime = "";
            }
            //Image Validation
            if (string.IsNullOrWhiteSpace(Image))
            {
                Image = "";
            }
            //Images Validation
            if (string.IsNullOrWhiteSpace(Images))
            {
                Images = "";
            }
            //Desn Validation
            if (string.IsNullOrWhiteSpace(Desn))
            {
                Desn = "";
            }


            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|21|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  //  Return New data ID
            }
            else
            {
                var Model = new Articles.ArticlesModel
                {

                    //Assign values to the data model
                    BigID = BigID,// Category 
                    ArticleTitle = ArticleTitle,// Title  
                    Articlekey = Articlekey,// Keywords 
                    ArticleDesn = ArticleDesn,// Description 
                    Statues = Statues,// Display: 0 = Yes, 1 = No 
                    Sorts = Sorts,// Sort Order 
                    NavSites = NavSites,// Redirect URL 
                    ReleaseTime = DateTime.Parse(ReleaseTime),// Publish Time 
                    Image = Image,// Header Image 
                    Images = Images,// Image Collection 
                    Hits = Hits,
                    Desn = Desn,// Sort in descending order (largest first) 
                    CreateUserID = AdminModel.AdminID
                };

                // Instantiate the data access layer object, which is responsible for database access
                Articles.ArticlesDal Dal = new Articles.ArticlesDal();
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
        // POST: api/Articles/Update
        //Via POST request Request to Update the data password and return the number of affected records.。
        [HttpPost("Update")]//Define the Update method
        public ActionResult<ApiResponse<int>> Update([FromForm] int ArticleID,
         [FromForm] int BigID
        , [FromForm] string ArticleTitle
        , [FromForm] string? Articlekey
        , [FromForm] string? ArticleDesn
        , [FromForm] int Statues
        , [FromForm] int Sorts
        , [FromForm] int Hits
        , [FromForm] string? NavSites
        , [FromForm] string ReleaseTime
        , [FromForm] string? Image
        , [FromForm] string? Images
        , [FromForm] string? Desn
            )
        {



            // Check if parameters are null
            if (string.IsNullOrWhiteSpace(ArticleTitle) || Statues < 0 || Sorts < 0 || ArticleID < 0
             || BigID < 0 || Hits < 0
             || !DateTime.TryParse(ReleaseTime, out DateTime releaseDate)
             )
            {
                return BadRequest(new ApiResponse<int>
                {
                    code = 400,
                    msg = "Invalid input parameters",
                    count = 0,
                    data = 0
                });
            }

            //Backend parameter check for null or empty

            //Articlekey Validation
            if (string.IsNullOrWhiteSpace(Articlekey))
            {
                Articlekey = "";
            }
            //ArticleDesn Validation
            if (string.IsNullOrWhiteSpace(ArticleDesn))
            {
                ArticleDesn = "";
            }
            //NavSites Validation
            if (string.IsNullOrWhiteSpace(NavSites))
            {
                NavSites = "";
            }
            //ReleaseTime Validation
            if (string.IsNullOrWhiteSpace(ReleaseTime))
            {
                ReleaseTime = "";
            }
            //Image Validation
            if (string.IsNullOrWhiteSpace(Image))
            {
                Image = "";
            }
            //Images Validation
            if (string.IsNullOrWhiteSpace(Images))
            {
                Images = "";
            }
            //Desn Validation
            if (string.IsNullOrWhiteSpace(Desn))
            {
                Desn = "";
            }


            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|22|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  //  Return New data ID
            }
            else
            {
                var Model = new Articles.ArticlesModel
                {
                    //Assign values to the data model
                    ArticleID = ArticleID,//  
                    BigID = BigID,// Category 
                    ArticleTitle = ArticleTitle,// Title  
                    Articlekey = Articlekey,// Keywords 
                    ArticleDesn = ArticleDesn,// Description 
                    Statues = Statues,// Display: 0 = Yes, 1 = No 
                    Sorts = Sorts,// Sort Order 
                    NavSites = NavSites,// Redirect URL 
                    ReleaseTime = DateTime.Parse(ReleaseTime),// Publish Time 
                    Image = Image,// Header Image 
                    Images = Images,// Image Collection 
                    Desn = Desn,// Sort in descending order (largest first) 
                    Hits = Hits,// 热度
                    UpdateUserID = AdminModel.AdminID
                };
                // Instantiate the data access layer object, which is responsible for database access
                Articles.ArticlesDal Dal = new Articles.ArticlesDal();
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

        // POST: api/Articles/Delete
        //Perform a DELETE via a POST request based on ID and return the number of deleted records。
        [HttpPost("Delete")]//Define the Delete method
        public ActionResult<ApiResponse<int>> Delete([FromForm] string ArticleIDs)
        {
            // Check if parameters are null
            if (

             string.IsNullOrWhiteSpace(ArticleIDs)
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
                Articles.ArticlesDal Dal = new Articles.ArticlesDal();
                // Convert the comma-separated string to a list of integers
                var idList = ArticleIDs.Split(',')
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

        // GET: api/Admin/Get
        // Get paginated data via a GET request, controlled by AdminName, Page, and PageSize parameter。
        [HttpGet("Get")]  // When the client requests the GET method, the path needs to match api/Admin/Get
        public ActionResult<ApiResponse<IEnumerable<Articles.ArticlesModel>>> Get([FromQuery] string? ArticleTitle, [FromQuery] int BigID, [FromQuery] int Page, [FromQuery] int PageSize)
        {

            // If ArticleTitle is null or empty, set it to "", meaning no filtering will be applied
            if (string.IsNullOrEmpty(ArticleTitle))
            {
                ArticleTitle = ""; // If no value or an empty string is passed, do not filter by name during the query
            }

            // Check if the pagination parameters are valid
            if (Page <= 0 || PageSize <= 0)
            {
                return BadRequest(new ApiResponse<int>
                {
                    code = 400,
                    msg = "Invalid input parameters",
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
            if (AdminModel.Roles.IndexOf("|17|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  // Return the new ID
            }
            else
            {
                // Instantiate the data access layer object, which is responsible for database access
                Articles.ArticlesDal Dal = new Articles.ArticlesDal();

                // Call the Get method to retrieve data from the database，Pass the pagination parameters: BigID, ArticleTitle, starting record, and records per page.
                DataTable Datas = Dal.Get(BigID, ArticleTitle, StartRecord, EndRecord);

                // Use the utility method DataTableToList to convert the DataTable into a List<T>, where T is an instance of the AdminModel class
                List<Articles.ArticlesModel> List = Tools.DataTableToList.DatatableToList<Articles.ArticlesModel>(Datas);

                DataTable Data = Dal.GetCount(BigID, ArticleTitle);
                int Number = Int32.Parse(Data.Rows[0]["Num"].ToString()!);
                // Return paginated data using a standardized API response format, including status code, message, total record count, and dat
                return Ok(new ApiResponse<IEnumerable<Articles.ArticlesModel>>
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