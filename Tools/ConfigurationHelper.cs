namespace Tools
{
    public class ConfigurationHelper
    {
        /// <summary>
        /// Project:Sunuer Manage
        /// Description:Get the value of a field in appsettings.json
        /// Author：HaiDong
        /// Site:https://www.sunuer.com
        /// Version: 1.0
        /// License：Apache License 2.0
        /// </summary>
        private static IConfiguration _configuration;

        // Set during initialization IConfiguration
        public static void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Use a static method to retrieve configuration items
        public static string GetConfigValue(string key)
        {

            // Use the GetValue method; if the corresponding key is not found, return an empty string
            return _configuration.GetValue<string>(key) ?? string.Empty;
        }
    }
}
