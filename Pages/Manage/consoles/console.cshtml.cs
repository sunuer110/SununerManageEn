using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SunuerManageEn.Pages.Manage.consoles
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Backend Main Area Default Page - Template 1
    /// Author£ºHaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License£ºApache License 2.0
    /// </summary>
    public class consoleModel : PageModel
    {
        public string url = "https://www.sunuer.com/Ad/";
        public string DataList="";//Time String
        public string TotalList = "";
        public List<NumberModel> List = new List<NumberModel>();
        //Pass HTTP injection for GetIP
        private readonly IHttpContextAccessor _httpContextAccessor;
        public consoleModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Admin.AdminLoginModel AdminModel = new Admin.AdminLoginModel();
        public async Task OnGetAsync()
        {
            AdminModel = Admin.AdminDal.GetAdminCheckLogin(_httpContextAccessor);
            GetModel();
            TotalListMethod();
            getNotdates();
            ViewData["Title"] = "Sunuer Managae";
            ViewData["KeyWords"] = "Sunuer Managae";
            ViewData["Description"] = "Sunuer Managae";
            using HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                url = "";
            }
        }
        //Count the number of articles under each Category.
        public void GetModel()
        {
            ArticleCategory.ArticleCategoryDal Dal = new ArticleCategory.ArticleCategoryDal();
            DataTable Datas = Dal.GetNumber(1);
            // Use the utility method DataTableToList to convert the DataTable into a List<T>, where T is an instance of the AdminModel class
            List = Tools.DataTableToList.DatatableToList<NumberModel>(Datas);
        }
        public class NumberModel()
        {
            public int BigID { get; set; } = 0; // Article Category
            public int Number { get; set; } = 0; // Article Count
            public string BigTitle { get; set; } = ""; // Category Name
        }
        //Get daily count
        public void TotalListMethod()
        {


            DateTime STime = DateTime.Now.AddDays(-29);//Start Time
            //Set to 00:00
            STime = DateTime.Parse(STime.ToString("yyyy-MM-dd 00:00:00"));
            DateTime ETime = DateTime.Now;//End Time
            int isok = 0;
            DateTime now = DateTime.Now;

            List<string> stringList = new List<string>();
            Articles.ArticlesDal Dal = new Articles.ArticlesDal();
            DataTable Count = Dal.GetCount30(STime, ETime);
            if (Count.Rows.Count > 0)
            {
                for (int i = 0; i < 30; i++)
                {
                    isok = 0;
                    foreach (DataRow col2 in Count.Rows)           //Tables[0].Rows retrieves all rows from the specified table (0 can be replaced with the table name)
                    {
                        if (DateTime.Parse(col2["Datas"].ToString()).ToString("yyyy-MM-dd") == now.AddDays(-29 + i).ToString("yyyy-MM-dd"))
                        {
                            stringList.Add(col2["Number"].ToString());
                            isok = 1;
                        }

                    }
                    if (isok == 0)
                    {

                        stringList.Add("0");
                    }
                }
            }
            else
            {
                for (int i = 0; i < 30; i++)
                {
                    stringList.Add("0");
                }
            }

            TotalList= JsonConvert.SerializeObject(stringList);

        }
        /// <summary>
        /// No method set to limit time
        /// </summary>
        /// <returns></returns>
        private void getNotdates()
        {
            List<string> stringList = new List<string>();
            DateTime now = DateTime.Now.AddDays(-29);
            stringList.Add(now.ToString("yyyy-MM-dd"));
            for (int i = 1; i < 30; i++)
            {
                stringList.Add(now.AddDays(i).ToString("yyyy-MM-dd"));
            }

            DataList= JsonConvert.SerializeObject(stringList);

        }
    }
}
