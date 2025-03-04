using System.Data;
using System.Reflection;

namespace Tools
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Define the DataTableToList class to convert DataTable to List
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public static class DataTableToList
    {
        /// <summary>
        /// Convert DataTable to List<T>
        /// </summary>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="dataTable">Source DataTable</param>
        /// <returns>Converted result List<T></returns>
        public static List<T> DatatableToList<T>(this DataTable dataTable) where T : new()
        {
            // Create a List<T> to store the results
            List<T> list = new List<T>();

            // Retrieve all public properties of the target type
            PropertyInfo[] properties = typeof(T).GetProperties();

            // Iterate through each row in the DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                // Create a new instance of type T
                T item = new T();

                // Iterate through the properties and assign the column data from the DataTable to the corresponding properties of the object
                foreach (PropertyInfo property in properties)
                {
                    // Check if the DataTable contains a column that matches the property name
                    if (dataTable.Columns.Contains(property.Name))
                    {
                        // If the column data is not DBNull, assign the value to the property
                        if (row[property.Name] != DBNull.Value)
                        {
                            property.SetValue(item, Convert.ChangeType(row[property.Name], property.PropertyType), null);
                        }
                    }
                }

                // Add the object to the list
                list.Add(item);
            }

            return list;
        }
    }
}
