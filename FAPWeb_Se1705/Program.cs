using FAPWeb_Se1705.Models;
using Microsoft.EntityFrameworkCore;

namespace FAPWeb_Se1705
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureService(builder);

            var app = builder.Build();

            app.UseStaticFiles();
            app.MapRazorPages();
            app.Run();
        }

        private static void ConfigureService(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<FAPPRJContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyConstr")));
            builder.Services.AddRazorPages();

        }
    }
}