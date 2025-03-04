using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using SunuerManageEn.Data;
using Tools;

namespace SunuerManage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Register ApplicationDbContext and configure it to use SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add services to the container.
            builder.Services.AddRazorPages();
            // Get the root directory of the current application
            var environment = builder.Environment;
            var appRootPath = environment.ContentRootPath; // Get the root directory of the application
            var keysPath = Path.Combine(appRootPath, "keys");
            if (!Directory.Exists(keysPath))
            {
                Directory.CreateDirectory(keysPath);  //Create the folder (if it does not exist)
            }
            //  Set the key storage path to the "keys" folder under the application root directory
            builder.Services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(appRootPath, "keys")))  // Dynamically configure the key storage path
                .SetApplicationName("SunuerApp");  // Optional: Set the application name to isolate the keys

            // Set IConfiguration to ConfigurationHelper
            ConfigurationHelper.SetConfiguration(builder.Configuration);

            // Add services, including IHttpContextAccessor
            builder.Services.AddHttpContextAccessor();
            //This global configuration will ensure that all JSON serialization behavior retains the original case of C# property names
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            // Register API controllers
            builder.Services.AddControllers();  // Add support for API controllers
            builder.Services.AddDistributedMemoryCache(); // Add distributed memory cache service
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5); // Set the session expiration time
                options.Cookie.HttpOnly = true; // Allow cookies to be accessed only via HTTP, preventing client-side scripts from accessing them
                options.Cookie.IsEssential = true; // Ensure cookies are required under privacy policy
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            // Map API controllers
            app.MapControllers();  // Map API controller routes

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
