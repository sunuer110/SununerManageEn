using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using System.IO;

namespace SunuerManageEn.Controllers
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Image CAPTCHA
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CaptchaController : ControllerBase
    {
        [HttpGet("Generate")]
        public IActionResult Generate()
        {
            string captchaText = GenerateCaptchaText();

            using (var bitmap = new SKBitmap(100, 40))
            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.White);

                // Set text style
                var paint = new SKPaint
                {
                    Color = SKColors.Black,
                    TextSize = 20,
                    IsAntialias = true,
                    Typeface = SKTypeface.Default
                };

                // Draw captcha text
                canvas.DrawText(captchaText, 10, 30, paint);

                // Add interference lines
                var random = new Random();
                for (int i = 0; i < 5; i++)
                {
                    var linePaint = new SKPaint
                    {
                        Color = SKColors.Gray,
                        StrokeWidth = 1
                    };
                    float startX = random.Next(0, 100);
                    float startY = random.Next(0, 40);
                    float endX = random.Next(0, 100);
                    float endY = random.Next(0, 40);
                    canvas.DrawLine(startX, startY, endX, endY, linePaint);
                }

                // Add random colored noise
                for (int i = 0; i < 100; i++)
                {
                    var dotPaint = new SKPaint
                    {
                        IsAntialias = true
                    };

                    // Randomly generate color
                    dotPaint.Color = new SKColor(
                        (byte)random.Next(0, 256), // Red component
                        (byte)random.Next(0, 256), // Green component
                        (byte)random.Next(0, 256)  // Blue component
                    );

                    float x = random.Next(0, 100);
                    float y = random.Next(0, 40);
                    canvas.DrawPoint(x, y, dotPaint);
                }

                using (var memoryStream = new MemoryStream())
                {
                    bitmap.Encode(memoryStream, SKEncodedImageFormat.Png, 100);

                    // Save the captcha to the cookie
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddMinutes(5), // Set expiration time
                        HttpOnly = true, // Prevent access from client-side scripts
                      //  Secure = true, // Transmit only over HTTPS connections
                        SameSite = SameSiteMode.Strict // Prevent CSRF attacks
                    };
                    HttpContext.Response.Cookies.Append("CaptchaCode", Tools.CBC.HtmlEncodeEncrypt(captchaText), cookieOptions);

                    return File(memoryStream.ToArray(), "image/png");
                }
            }
        }

        private string GenerateCaptchaText()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var captcha = new char[5];
            for (int i = 0; i < 5; i++)
            {
                captcha[i] = chars[random.Next(chars.Length)];
            }
            return new string(captcha);
        }
    }
}
