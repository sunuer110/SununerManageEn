namespace ApiResponse
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Define the ApiResponse class to standardize the API response format.
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class ApiResponse<T>
    {
        public string? html { get; set; }  // html：Additional parameters returned
        public int code { get; set; }  // code：Represents the status code of the API operation, where 0 indicates success and other values indicate failure.
        public string msg { get; set; }  // msg：A description of the result, indicating success or failure.
        public int count { get; set; }  // count：The quantity of data or the number of records affected. In query operations, 'count' refers to the total number of data items returned. In insert, delete, and update operations, 'count' refers to the number of rows affected (e.g., 1 record deleted, 2 records updated, etc.).
        public T data { get; set; }  // data：The generic type T represents the actual data returned. T can be of any type, such as a single object (e.g., a single user), a collection (e.g., a list of users), or a simple data type (e.g., int).

    }
}
