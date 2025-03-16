using ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Tools;
namespace Web.Controllers.SMSs
{


    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Send Verification Code
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SMSController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // POST: api/SMS/SendCode
        //Send Verification Code via POST Request (If a phone number is provided, send an SMS code; if an email is provided, send an email verification code. At least one of the two is required.)
        [HttpPost("SendCode")]
        public async Task<ActionResult<ApiResponse<int>>> SendCode(

        [FromForm] string? phone
        , [FromForm] string? Email
        , [FromForm] int ClassID

        )
        {
            //Check if Parameters Are Empty
            if (

             (string.IsNullOrWhiteSpace(phone) && string.IsNullOrWhiteSpace(Email)) || ClassID < 0

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
            bool isPhone = !string.IsNullOrWhiteSpace(phone);
            var target = !string.IsNullOrWhiteSpace(phone) ? phone : Email;
            if (target is null)
            {
                return BadRequest(new ApiResponse<int>
                {
                    code = 400,
                    msg = "Phone Number and Email Cannot Be Empty at the Same Time",
                    count = 0,
                    data = 0
                });
            }

            string IP = Tools.Tools.GetUserIp(_httpContextAccessor.HttpContext ?? throw new InvalidOperationException("HttpContext is null."));// Call GetUserIp Method and Pass the Current HttpContext
            string chkCode = Tools.Tools.MakephoneSMS(6);
            SMS.SMSDal sm = new SMS.SMSDal();
            int smid = sm.AddSMS(target, ClassID, chkCode, IP);//Add the Verification Code to the Database and Validate If It Meets Sending Requirements
            //Verify the Verification Code by Calling sm.CheckSMS(target, ClassID, chkCode, IP) Function
            if (smid == -3)
            {
                if (isPhone)
                {
                    await SendSMS(chkCode, phone!);//Send SMS
                }
                else
                {
                    await BindEmail(chkCode, Email!);//Send Email
                }
                return Ok(new ApiResponse<int>
                {
                    code = 0,
                    msg = "Send Verification Code Successfully",
                    count = 1,
                    data = 0
                });
            }
            else
            {
                return Ok(new ApiResponse<int>
                {
                    code = 0,
                    msg = "Failed to Retrieve Verification Code",
                    count = 1,
                    data = 0
                });

            }


        }

        private static readonly HttpClient httpClient = new();

        /// <summary>
        // Send Mobile Verification Code - Adjust According to Different SMS Providers
        /// </summary>
        /// <param name="chkCode">Verification Code</param>
        /// <param name="phone">Phone</param>
        /// <returns></returns>
        private async Task SendSMS(string chkCode, string phone)
        {
            string posturl = $"SMS Sending URL";

            var postData = new Dictionary<string, string>
            {
                //{ "code", chkCode },
                //{ "phone", phone }
            };

            using var content = new FormUrlEncodedContent(postData);

            try
            {
                var response = await httpClient.PostAsync(posturl, content);
                response.EnsureSuccessStatusCode(); // Ensure the Request is Successful

                var responseContent = await response.Content.ReadAsStringAsync();
                //  Console.WriteLine(responseContent);
                // Process responseContent Accordingly
            }
            catch (HttpRequestException ex)
            {
                // Log Exception
            }
            catch (Exception ex)
            {
                // Log Exception
            }

        }

        // ************ Send Email-Star ************//
        private async Task BindEmail(string chkCode, string receiveEmail)
        {
            var subject = "Email Verification Title";
            var content = $"Email Verification Content (Includes Verification Code)";

            using var client = new SmtpClient("Eamil smtp", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("Eamil", "Email Sending Password")
            };

            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

            var msg = new MailMessage("Email", receiveEmail, subject, content) { IsBodyHtml = true };

            try
            {
                await client.SendMailAsync(msg);
            }
            catch
            {
                // Log Recording or Error Handling
            }
        }

        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            return true;
        }
        // ************ Send Email-End ************//

    }
}
