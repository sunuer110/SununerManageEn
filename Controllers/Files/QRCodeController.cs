using Microsoft.AspNetCore.Mvc;
using QRCoder;
using SkiaSharp;
using System.IO;

namespace SunuerManageEn.Controllers.Files
{
    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Generate QR code using QRCoder and SkiaSharp
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        [HttpGet("GenerateQRCode")]
        public IActionResult GenerateQRCode(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return BadRequest("Text cannot be empty.");
            }

            try
            {
                // Use QRCoder to generate QR code data
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);

                // Use SkiaSharp to render the QR code
                using (SKBitmap bitmap = GenerateQRCodeBitmap(qrCodeData))
                using (SKImage image = SKImage.FromBitmap(bitmap))
                using (SKData data = image.Encode(SKEncodedImageFormat.Png, 100))
                {
                    return File(data.ToArray(), "image/png");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error generating QR Code.", Details = ex.Message });
            }
        }

        private SKBitmap GenerateQRCodeBitmap(QRCodeData qrCodeData)
        {
            int moduleSize = 10; // Module size
            int pixelsPerModule = moduleSize; // Pixel size of each module
            int qrSize = qrCodeData.ModuleMatrix.Count * pixelsPerModule; // Total QR code size

            // Create canvas
            SKBitmap bitmap = new SKBitmap(qrSize, qrSize);
            using (SKCanvas canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.White);

                // Draw QR code
                for (int y = 0; y < qrCodeData.ModuleMatrix.Count; y++)
                {
                    for (int x = 0; x < qrCodeData.ModuleMatrix.Count; x++)
                    {
                        if (qrCodeData.ModuleMatrix[y][x])
                        {
                            canvas.DrawRect(
                                new SKRect(x * pixelsPerModule, y * pixelsPerModule,
                                           (x + 1) * pixelsPerModule, (y + 1) * pixelsPerModule),
                                new SKPaint { Color = SKColors.Black });
                        }
                    }
                }
            }

            return bitmap;
        }
    }
}