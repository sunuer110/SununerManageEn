using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SunuerManageEn.Controllers
{

    /// <summary>
    /// Project:Sunuer Manage
    /// Description:Upload file API
    /// Author：HaiDong
    /// Site:https://www.sunuer.com
    /// Version: 1.0
    /// License：Apache License 2.0
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    { 
        // Use dependency injection to get IHttpContextAccessor – Retrieve the actual IP address
        private readonly IHttpContextAccessor _httpContextAccessor;
        //Inject the Getappsettings.json string
        private readonly IConfiguration _configuration;

        public FilesController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(IFormFile file,[FromQuery] string? name)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded or file is empty.");
            }
            //About Validation
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "";
            }
            // Restrict file types
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".pdf", ".docx", ".xlsx" };
            string fileExtension = Path.GetExtension(file.FileName).ToLower();
            string[] allowedMimeTypes = { "image/jpeg", "image/png", "image/gif", "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };

            string FileType = "";
            FileType = fileExtension;
            // Check file extension and MIME type
            if (!allowedExtensions.Contains(fileExtension) || !allowedMimeTypes.Contains(file.ContentType))
            {
                return Ok(new
                {
                    Code = "401",
                    Messge = "Upload failed, format error!",//Invalid file type,
                    FileUrl = ""
                });
            }
            // Ensure the upload file path does not contain ".." to prevent path traversal
            if (file.FileName.Contains(".."))
            {
                return Ok(new
                {
                    Code = "402",
                    Messge = "Upload failed, format error!",//Invalid file name
                    FileUrl = ""
                });
            }
            // Validate file's Magic Number
            if (!IsValidFile(file))
            {

                return Ok(new
                {
                    Code = "403",
                    Messge = "Upload failed, format error!",//Invalid file content.
                    FileUrl = ""
                });
            }

            // File size limit(5MB)
            const long maxFileSize = 5 * 1024 * 1024; // 5MB
            if (file.Length > maxFileSize)
            {
                return Ok(new
                {
                    Code = "404",
                    Messge = "Upload failed, format error!",//File size exceeds the 5MB limit.
                    FileUrl = ""
                });
            }

            // Save file
            try
            {
                if (name != "")
                {
                    string baseFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploadfile");


                    string uniqueFileName = $"{name}{fileExtension}";
                    string filePath = Path.Combine(baseFolder, uniqueFileName);
                    Console.WriteLine(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    string fileUrl = $"/Uploadfile/{uniqueFileName}";
                    string FileName = uniqueFileName;
                    return Ok(new
                    {
                        Code = "0",
                        Messge = "Upload success",

                        FileType = FileType,
                        FileUrl = fileUrl,
                        FileName = FileName
                    });
                }
                else
                {
                    string baseFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploadfile");
                    string yearMonthFolder = Path.Combine(baseFolder, DateTime.Now.ToString("yyyy/MM").Replace("/", Path.DirectorySeparatorChar.ToString()));
                    if (!Directory.Exists(yearMonthFolder))
                    {
                        Directory.CreateDirectory(yearMonthFolder);
                    }

                    string uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                    string filePath = Path.Combine(yearMonthFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    string fileUrl = $"/Uploadfile/{DateTime.Now:yyyy}/{DateTime.Now:MM}/{uniqueFileName}";
                    string FileName = file.FileName;
                    return Ok(new
                    {
                        Code = "0",
                        Messge = "Upload success",

                        FileType = FileType,
                        FileUrl = fileUrl,
                        FileName = FileName
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Code = "500",
                    Messge = "Upload failed",//An error occurred while uploading the file.
                    FileUrl = ""
                });
              
            }
        }
        [HttpPost("Uploads")]
        public async Task<IActionResult> Uploads(IFormFile[] files)
        {
            if (files == null || files.Length == 0)
            {
                return BadRequest(new
                {
                    Code = "405",
                    Messge = "Upload failed",
                    FileUrls = new List<string>()
                });
            }

            // Restrict file types
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".pdf", ".docx", ".xlsx"};
            string[] allowedMimeTypes = { "image/jpeg", "image/png", "image/gif", "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
            List<string> fileUrls = new List<string>(); // Used to store all uploaded file URLs

            foreach (var file in files)
            {
                string fileExtension = Path.GetExtension(file.FileName).ToLower();
                string FileType = "";
                FileType = file.ContentType;
                // Check file extension and MIME type
                if (!allowedExtensions.Contains(fileExtension) || !allowedMimeTypes.Contains(file.ContentType))
                {
                    return Ok(new
                    {
                        Code = "401",
                        Messge = "Upload failed, format error!", // Invalid file type
                        FileUrls = fileUrls
                    });
                }

                // Ensure the upload file path does not contain ".." to prevent path traversal
                if (file.FileName.Contains(".."))
                {
                    return Ok(new
                    {
                        Code = "402",
                        Messge = "Upload failed，Filename error", // Invalid file name
                        FileUrls = fileUrls
                    });
                }

                // Validate file's Magic Number
                if (!IsValidFile(file))
                {
                    return Ok(new
                    {
                        Code = "403",
                        Messge = "Upload failed，File content format error", // Invalid file content
                        FileUrls = fileUrls
                    });
                }

                // File size limit(5MB)
                const long maxFileSize = 5 * 1024 * 1024; // 5MB
                if (file.Length > maxFileSize)
                {
                    return Ok(new
                    {
                        Code = "404",
                        Messge = "Upload failed，File exceeds size limit", // File size exceeds the 5MB limit.
                        FileUrls = fileUrls
                    });
                }

                // Save file
                try
                {
                    string baseFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploadfile");
                    string yearMonthFolder = Path.Combine(baseFolder, DateTime.Now.ToString("yyyy/MM").Replace("/", Path.DirectorySeparatorChar.ToString()));

                    // Create the folder if it does not exist
                    if (!Directory.Exists(yearMonthFolder))
                    {
                        Directory.CreateDirectory(yearMonthFolder);
                    }

                    string uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                    string filePath = Path.Combine(yearMonthFolder, uniqueFileName);

                    // Save file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Public URL of the file
                    string fileUrl = $"{Request.Scheme}://{Request.Host}/Uploadfile/{DateTime.Now:yyyy}/{DateTime.Now:MM}/{uniqueFileName}";
                    fileUrls.Add(fileUrl); // Add to the file URL list
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Message = "Error occurred during file upload", Error = ex.Message });
                }
            }

            //  Return all uploaded file URLs
            return Ok(new
            {
                Code = "200",
                Messge = "File upload success",
                FileUrls = fileUrls
            });
        }


        //File type security check
        public bool IsValidFile(IFormFile file)
        {
            try
            {
                byte[] buffer = new byte[4];  // Read the first 4 bytes（Magic Number）
                using (var stream = file.OpenReadStream())
                {
                    // Read the first 4 bytes of the file
                    stream.Read(buffer, 0, buffer.Length);
                }

                string hex = BitConverter.ToString(buffer).Replace("-", string.Empty);
                Console.WriteLine(hex);
                // Validate the file type Magic Number
                if (hex.StartsWith("FFD8FF")) return true; // JPEG
                if (hex.StartsWith("89504E47")) return true; // PNG
                if (hex.StartsWith("47494638")) return true; // GIF
                if (hex.StartsWith("25504446") && file.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)) return true; // PDF
                if (file.FileName.EndsWith(".docx", StringComparison.OrdinalIgnoreCase) || file.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    // DOCX and XLSX files are in ZIP format; check if the file starts with "PK"
                    byte[] zipBuffer = new byte[2];
                    using (var stream = file.OpenReadStream())
                    {
                        stream.Read(zipBuffer, 0, zipBuffer.Length);
                    }
                    string zipHex = BitConverter.ToString(zipBuffer).Replace("-", string.Empty);
                    if (zipHex.StartsWith("504B")) return true; // ZIP (DOCX, XLSX)
                }

                return false; // Does not match a known format
            }
            catch (Exception)
            {
                return false; // If reading fails, the file is invalid
            }
        }


    }
}
