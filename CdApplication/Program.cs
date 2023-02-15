using System;
using CdApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace CdApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //MVC
            builder.Services.AddControllersWithViews();

            //DbContext
            builder.Services.AddDbContext<CdContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultDbConnection"))
            );

            var app = builder.Build();

            //Statiska filer
            app.UseStaticFiles();

            //Routing
            app.UseRouting();

            //Skapar routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();
        }
    }
}