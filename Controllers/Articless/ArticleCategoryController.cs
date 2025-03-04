using ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace SunuerManageEn.Controllers
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:ArticleCategory API
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCategoryController : ControllerBase
    {
        // Use dependency injection to get IHttpContextAccessor – Retrieve the actual IP address
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ArticleCategoryController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        // POST: api/ArticleCategory/Add
        //Via POST request Request to Add new data, receiving an integer parameter; if the parameter is not provided, the default value is 0 
        [HttpPost("Add")]
        public ActionResult<ApiResponse<int>> Add(
              [FromForm] int ParentID
            , [FromForm] int Statues
            , [FromForm] string BigTitle
            , [FromForm] string? KeyTitle
            , [FromForm] string? KeyWord
            , [FromForm] string? KeyDesn
            , [FromForm] string? Images
            , [FromForm] string? ImagesPhone
            , [FromForm] string? SiteUrl
            , [FromForm] int Sorts
            )
        {  // Check if parameters are null
            if (string.IsNullOrWhiteSpace(BigTitle) || ParentID < 0 || Sorts < 0)
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

            //BigTitle Validation
            if (string.IsNullOrWhiteSpace(BigTitle))
            {
                BigTitle = "";
            }
            //KeyTitle Validation
            if (string.IsNullOrWhiteSpace(KeyTitle))
            {
                KeyTitle = "";
            }
            //KeyWord Validation
            if (string.IsNullOrWhiteSpace(KeyWord))
            {
                KeyWord = "";
            }
            //KeyDesn Validation
            if (string.IsNullOrWhiteSpace(KeyDesn))
            {
                KeyDesn = "";
            }
            //Images Validation
            if (string.IsNullOrWhiteSpace(Images))
            {
                Images = "";
            }
            
            //ImagesPhone Validation
            if (string.IsNullOrWhiteSpace(ImagesPhone))
            {
                ImagesPhone = "";
            }
            //SiteUrlRedirect Link
            if (string.IsNullOrWhiteSpace(SiteUrl))
            {
                SiteUrl = "";
            }
            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|18|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  //  Return New data ID
            }
            else
            {
                var Model = new ArticleCategory.ArticleCategoryModel
                {
                    //Assign values to the data model
                    ParentID = ParentID,// Parent ID 
                    Statues = Statues,// Navigation (0: No, 1: Yes) 
                    BigTitle = BigTitle,// Category Name 
                    KeyTitle = KeyTitle,// Optimized Title 
                    KeyWord = KeyWord,// Keywords 
                    KeyDesn = KeyDesn,// Description 
                    Images = Images,// Images 
                    ImagesPhone = ImagesPhone,// Mobile Image 
                    SiteUrl = SiteUrl,// Redirect Link
                    Sorts = Sorts,// Sort in descending order (largest first) 
                    CreateUserID = AdminModel.AdminID
                };

                // Instantiate the data access layer object, which is responsible for database access
                ArticleCategory.ArticleCategoryDal Dal = new ArticleCategory.ArticleCategoryDal();
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
        // POST: api/ArticleCategory/Update
        //Via POST request Request to Update the data password and return the number of affected records.。
        [HttpPost("Update")]//Define the Update method
        public ActionResult<ApiResponse<int>> Update([FromForm] int BigID,
              [FromForm] int ParentID
            , [FromForm] int Statues
            , [FromForm] string BigTitle
            , [FromForm] string? KeyTitle
            , [FromForm] string? KeyWord
            , [FromForm] string? KeyDesn
            , [FromForm] string? Images
            , [FromForm] string? ImagesPhone
            , [FromForm] string? SiteUrl
            , [FromForm] int Sorts
            )
        {

            // Check if parameters are null
            if (string.IsNullOrWhiteSpace(BigTitle) || ParentID < 0 || Sorts < 0
             || BigID <= 0
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

            //BigTitle Validation
            if (string.IsNullOrWhiteSpace(BigTitle))
            {
                BigTitle = "";
            }
            //KeyTitle Validation
            if (string.IsNullOrWhiteSpace(KeyTitle))
            {
                KeyTitle = "";
            }
            //KeyWord Validation
            if (string.IsNullOrWhiteSpace(KeyWord))
            {
                KeyWord = "";
            }
            //KeyDesn Validation
            if (string.IsNullOrWhiteSpace(KeyDesn))
            {
                KeyDesn = "";
            }
            //Images Validation
            if (string.IsNullOrWhiteSpace(Images))
            {
                Images = "";
            }
            //ImagesPhone Validation
            if (string.IsNullOrWhiteSpace(ImagesPhone))
            {
                ImagesPhone = "";
            }
            //SiteUrlRedirect Link
            if (string.IsNullOrWhiteSpace(SiteUrl))
            {
                SiteUrl = "";
            }
            Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
            //Check login status
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            //Check for permissions
            if (AdminModel.Roles.IndexOf("|19|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  //  Return New data ID
            }
            else
            {
                var Model = new ArticleCategory.ArticleCategoryModel
                {
                    //Assign values to the data model
                    BigID = BigID,// Parent ID 
                    ParentID = ParentID,// Parent ID 
                    Statues = Statues,// Navigation (0: No, 1: Yes) 
                    BigTitle = BigTitle,// Category Name 
                    KeyTitle = KeyTitle,// Optimized Title 
                    KeyWord = KeyWord,// Keywords 
                    KeyDesn = KeyDesn,// Description 
                    Images = Images,// Images 
                    ImagesPhone = ImagesPhone,// Mobile Image 
                    SiteUrl = SiteUrl,// Redirect Link
                    Sorts = Sorts,// Sort in descending order (largest first) 
                    UpdateUserID = AdminModel.AdminID
                };
                // Instantiate the data access layer object, which is responsible for database access
                ArticleCategory.ArticleCategoryDal Dal = new ArticleCategory.ArticleCategoryDal();
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

        // POST: api/ArticleCategory/Delete
        //Perform a DELETE via a POST request based on ID and return the number of deleted records。
        [HttpPost("Delete")]//Define the Delete method
        public ActionResult<ApiResponse<int>> Delete([FromForm] int BigID)
        {
            // Check if parameters are null
            if (
           BigID < 0
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
            if (AdminModel.Roles.IndexOf("|20|") < 0)
            {
                return Ok(new ApiResponse<int> { code = 404, msg = "No permission", count = 0, data = 0 });  //  Return New data ID
            }
            else
            {
                ArticleCategory.ArticleCategoryDal Dal = new ArticleCategory.ArticleCategoryDal();
                int UpdateUserID = AdminModel.AdminID;

                int IsOk = Dal.Delete(BigID, UpdateUserID);

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

        // Post: api/ArticleCategory/Get
        // Via POST request。
        [HttpPost("Get")]  // When the client requests the GET method, the path needs to match api/ArticleCategory/Get
        public ActionResult<ApiResponse<IEnumerable<ArticleCategory.ArticleCategoryModel>>> Get([FromForm] int ParentID)
        {


            // Check if the pagination parameters are valid
            if (ParentID < 0)
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
            ArticleCategory.ArticleCategoryDal Dal = new ArticleCategory.ArticleCategoryDal();


            // Instantiate the data access layer object, which is responsible for database access
            // AdminPower.AdminPowerDal Dal = new AdminPower.AdminPowerDal();

            // Call the Get method to retrieve data from the database
            DataTable Datas = Dal.Get(ParentID);

            // Use the utility method DataTableToList to convert the DataTable into a List<T>, where T is an instance of the AdminModel class
            List<ArticleCategory.ArticleCategoryModel> List = Tools.DataTableToList.DatatableToList<ArticleCategory.ArticleCategoryModel>(Datas);

            // Return paginated data using a standardized API response format, including status code, message, total record count, and dat
            return Ok(new ApiResponse<IEnumerable<ArticleCategory.ArticleCategoryModel>>
            {
                code = 0,  // Status code 0 indicates success
                msg = "Success",  //  Return message "Success"
                count = List.Count,  //  Return the count of records on the current page
                data = List  //  Return the paginated data collection
            });
        }
        // Post: api/ArticleCategory/Get
        // Via POST request。
        [HttpPost("GetAll")]  // When the client requests the GET method, the path needs to match api/ArticleCategory/Get
        public ActionResult<ApiResponse<IEnumerable<ArticleCategory.ArticleCategoryModel>>> GetAll()
        {


            // Instantiate the data access layer object, which is responsible for database access
            ArticleCategory.ArticleCategoryDal Dal = new ArticleCategory.ArticleCategoryDal();

            // Call the Get method to retrieve data from the database
            DataTable Datas = Dal.GetAll();

            // Use the utility method DataTableToList to convert the DataTable into a List<T>, where T is an instance of the AdminModel class
            List<ArticleCategory.ArticleCategoryModel> List = Tools.DataTableToList.DatatableToList<ArticleCategory.ArticleCategoryModel>(Datas);

            // Return paginated data using a standardized API response format, including status code, message, total record count, and dat
            return Ok(new ApiResponse<IEnumerable<ArticleCategory.ArticleCategoryModel>>
            {
                code = 0,  // Status code 0 indicates success
                msg = "Success",  //  Return message "Success"
                count = List.Count,  //  Return the count of records on the current page
                data = List  //  Return the paginated data collection
            });
        }

        // Post: api/ArticleCategory/Select
        // Via POST request。
        [HttpPost("Select")]  // When the client requests the GET method, the path needs to match api/ArticleCategory/Select
        public ActionResult<ApiResponse<IEnumerable<ArticleCategory.ArticleCategoryModel>>> Select([FromForm] int ParentID, [FromForm] int BigID, [FromForm] int? Top)
        {
            // Check if the pagination parameters are valid
            if (ParentID < 0|| BigID < 0)
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
            ArticleCategory.ArticleCategoryDal Dal = new ArticleCategory.ArticleCategoryDal();

            // Call the Get method to retrieve data from the database
            DataTable Datas = Dal.GetParentAll(ParentID);

            // Use the utility method DataTableToList to convert the DataTable into a List<T>, where T is an instance of the AdminModel class
            List<ArticleCategory.SelectList> List = Dal.GetJson(Datas, BigID, ParentID, Top??0);

            // Return paginated data using a standardized API response format, including status code, message, total record count, and dat
            return Ok(new ApiResponse<IEnumerable<ArticleCategory.SelectList>>
            {
                code = 0,  // Status code 0 indicates success
                msg = "Success",  //  Return message "Success"
                count = List.Count,  //  Return the count of records on the current page
                data = List  //  Return the paginated data collection
            });
        }
    }
}