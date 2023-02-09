using System;
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
            var app = builder.Build();

            //Statiska filer
            app.UseStaticFiles();

            app.UseRouting();

            //Skapar routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller: Home}/{action=Index}{id?}"
                );

            app.Run();
        }
    }
}