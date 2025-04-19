using Microsoft.AspNetCore.WebUtilities;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Tools
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Tools Class，Provides common utility methods
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// Truncate a string, representing excess parts with "..."
        /// </summary>
        /// <param name="msg">Input string</param>
        /// <param name="len">Maximum length</param>
        /// <returns>Truncated string</returns>
        public static string SubStrings(string msg, int len)
        {
            if (msg.Length <= len)
            {
                return msg;  // If the length of the string is less than or equal to the specified length, return it directly.
            }
            return msg.Substring(0, len) + "...";  // Represent the excess part with "...".
        }

        /// <summary>
        /// Hide the middle 4 digits of a phone number
        /// </summary>
        /// <param name="phones">Input phone number</param>
        /// <returns>Phone number with the middle 4 digits hidden</returns>
        public static string SubPhone(string phones)
        {
            if (phones.Length != 11)
            {
                return phones;  // If the length of the phone number is not 11 digits, return the original phone number directly
            }
            return phones.Substring(0, 3) + "****" + phones.Substring(7, 4);
        }

        /// <summary>
        /// Generate the current Unix timestamp (in seconds)
        /// </summary>
        /// <returns>Current Unix timestamp</returns>
        public static long CreatenTimestamp()
        {
            return (DateTime.UtcNow.Ticks - 621355968000000000) / 10000000;
        }

        /// <summary>
        /// Generate a random string of specified length
        /// </summary>
        /// <param name="pwdlen">Length of the string</param>
        /// <returns>Randomly generated string</returns>
        public static string MakePassword(int pwdlen)
        {
            const string pwdchars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            char[] result = new char[pwdlen];
            for (int i = 0; i < pwdlen; i++)
            {
                result[i] = pwdchars[rnd.Next(pwdchars.Length)];
            }
            return new string(result);
        }

        /// <summary>
        /// Generate a random numeric string of specified length
        /// </summary>
        /// <param name="pwdlen">Length of the string</param>
        /// <returns>Randomly generated numeric string</returns>
        public static string MakephoneSMS(int pwdlen)
        {
            const string digits = "0123456789";
            Random rnd = new Random();
            char[] result = new char[pwdlen];
            for (int i = 0; i < pwdlen; i++)
            {
                result[i] = digits[rnd.Next(digits.Length)];
            }
            return new string(result);
        }

        /// <summary>
        /// Calculate the number of days between two dates
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Number of days between the dates</returns>
        public static int DateToDays(string startDate, string endDate)
        {
            DateTime dt1 = DateTime.Parse(startDate);
            DateTime dt2 = DateTime.Parse(endDate);
            TimeSpan ts = dt2 - dt1;  
            return Math.Abs(ts.Days);  // Return the absolute value to avoid negative results
        }

        /// <summary>
        /// Check if the date format is valid
        /// </summary>
        /// <param name="dateStr">Date string</param>
        /// <returns>Whether it is a valid date</returns>
        public static bool IsDate(string dateStr)
        {
            return DateTime.TryParse(dateStr, out _);  // Use TryParse to attempt to parse the date
        }

        /// <summary>
        /// Determine if the string is a positive integer
        /// </summary>
        /// <param name="str">String to be evaluated</param>
        /// <returns>Whether it is a positive integer</returns>
        public static bool IsNonNegativeInteger(string str)
        {
            return Regex.IsMatch(str, @"^[1-9]\d*$");  // Match positive integers
        }

        /// <summary>
        /// Determine if the string is a valid phone number
        /// </summary>
        /// <param name="str">String to be evaluated</param>
        /// <returns>Whether it is a valid phone number</returns>
        public static bool IsPhoneNumber(string str)
        {
            return Regex.IsMatch(str, @"^1[3-9]\d{9}$");  // Phone number regex validation
        }


        /// <summary>
        /// Determine if the string is a valid email address
        /// </summary>
        /// <param name="str">Email string</param>
        /// <returns>Whether it is a valid email address</returns>
        public static bool IsEmail(string str)
        {
            const string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(str, pattern);
        }
        /// <summary>
        /// Get the user's IP address
        /// Prioritize obtaining the external IP address; if unavailable, obtain the internal IP address
        /// </summary>
        /// <param name="httpContext">HttpContext of the current request</param>
        /// <returns>User's IP address</returns>
        public static string GetUserIp(HttpContext httpContext)
        {
            // First attempt to retrieve the external IP from X-Forwarded-For
            if (httpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                var forwardedHeader = httpContext.Request.Headers["X-Forwarded-For"].ToString();
                if (!string.IsNullOrWhiteSpace(forwardedHeader))
                {
                    var ips = forwardedHeader.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var ip in ips)
                    {
                        var trimmedIp = ip.Trim();
                        if (IsValidIpAddress(trimmedIp) && !IsPrivateIp(trimmedIp))
                        {
                            return trimmedIp; 
                        }
                    }
                }
            }

            // If no external IP is available, retrieve the internal IP
            var remoteIpAddress = httpContext.Connection.RemoteIpAddress?.ToString();
            return !string.IsNullOrEmpty(remoteIpAddress) && IsValidIpAddress(remoteIpAddress)
                ? remoteIpAddress
                : "Unknown"; // Return the internal IP or "Unknown"
        }

        /// <summary>
        /// Validate whether it is a valid IP address
        /// </summary>
        /// <param name="ipAddress">IP address to be validated</param>
        /// <returns>Whether it is a valid IP address</returns>
        private static bool IsValidIpAddress(string ipAddress)
        {
            return IPAddress.TryParse(ipAddress, out _);
        }

        /// <summary>
        /// Determine if it is a private IP address (internal IP)
        /// </summary>
        /// <param name="ipAddress">IP address to be validated</param>
        /// <returns>Whether it is an internal IP address</returns>
        private static bool IsPrivateIp(string ipAddress)
        {
            if (IPAddress.TryParse(ipAddress, out var ip))
            {
                var bytes = ip.GetAddressBytes();
                switch (bytes[0])
                {
                    case 10:
                        return true; // 10.0.0.0 - 10.255.255.255
                    case 172:
                        return bytes[1] >= 16 && bytes[1] <= 31; // 172.16.0.0 - 172.31.255.255
                    case 192:
                        return bytes[1] == 168; // 192.168.0.0 - 192.168.255.255
                    default:
                        return false;
                }
            }
            return false;
        }


        /// <summary>
        /// Get the current date in the transaction date format (yyyyMMdd)
        /// </summary>
        public static string GetTransDate()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Generate an order number (16-digit number)
        /// </summary>
        public static string GetOrderId()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }

        /// <summary>
        /// Get the current week number of the year
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>Which week of the year</returns>
        public static int GetWeekNumOfTheYear(DateTime date)
        {
            CultureInfo ci = new CultureInfo("zh-CN");
            Calendar cal = ci.Calendar;
            CalendarWeekRule rule = ci.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDay = ci.DateTimeFormat.FirstDayOfWeek;
            return cal.GetWeekOfYear(date, rule, firstDay);
        }
        /// <summary>
        /// MD5 Encryption
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static String MD5(string password)
        {
            Byte[] clearBytes = new UnicodeEncoding().GetBytes(password);
            Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")!).ComputeHash(clearBytes);

            return BitConverter.ToString(hashedBytes);
        }


        //Dynamically query JSON
        public static string? FindDynamicValue(
       List<Dictionary<string, List<Dictionary<string, string>>>>? languages,
       string targetLanguage,
       string targetKey
   )
        {
            if (languages == null)
            {
                return null;
            }

            // Find target language
            var languageData = languages.FirstOrDefault(lang => lang.ContainsKey(targetLanguage));

            if (languageData != null && languageData.TryGetValue(targetLanguage, out var details))
            {
                // Find the value of the target key
                var entry = details.FirstOrDefault(dict => dict.ContainsKey(targetKey));
                return entry?[targetKey];
            }

            return null; // Target language or target key not found
        }
        /// <summary>
        /// Replace or add the value of URL query parameters
        /// </summary>
        /// <param name="url">Original URL</param>
        /// <param name="paramName">Parameter name to replace or add</param>
        /// <param name="paramValue">New parameter value</param>
        /// <returns>Return the modified URL</returns>
        public static string ReplaceUrlParameter(string url, string paramName, string paramValue)
        {
            // Create a UriBuilder instance to parse and construct a URL
            var uriBuilder = new UriBuilder(url);

            // Parse the query string into a dictionary
            var query = QueryHelpers.ParseQuery(uriBuilder.Query);

            // Convert the parsed query parameters into a Dictionary to support modification
            var queryDictionary = new Dictionary<string, string>(query.ToDictionary(k => k.Key, v => v.Value.ToString()))
            {
                [paramName] = paramValue // Replace or add parameters
            };

            // Concatenate the modified query parameters using &
            uriBuilder.Query = string.Join("&", queryDictionary.Select(kv => $"{kv.Key}={kv.Value}"));

            // Return the new URL
            return uriBuilder.ToString();
        }
        /// <summary>
        // Check if the Device is Mobile
        /// </summary>
        /// <param name="request">HttpRequest request</param>
        /// <returns>true/fasle</returns>
        public static bool IsMobileDevice(HttpRequest request)
        {
            var userAgent = request.Headers["User-Agent"].ToString().ToLower();
            return userAgent.Contains("mobi") || userAgent.Contains("android") || userAgent.Contains("iphone");
        }
    }
}
