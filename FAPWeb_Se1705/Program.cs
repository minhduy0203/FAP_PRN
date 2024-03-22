using FAPWeb_Se1705.Logics;
using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Repository;
using FAPWeb_Se1705.Service;
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
            builder.Services.AddTransient<TimeTableLogic>();
            builder.Services.AddTransient<ISessionService, SessionService>();
            builder.Services.AddTransient<ISessionRepostiory, SessionRepository>();
            builder.Services.AddTransient<IRoomRepository, RoomRepository>();
            builder.Services.AddTransient<IRoomService, RoomService>();
            builder.Services.AddTransient<ICourseRepository, CourseRepository>();
            builder.Services.AddTransient<ICourseService, CourseService>();
            builder.Services.AddTransient<IGroupRepository, GroupRepository>();
            builder.Services.AddTransient<IGroupService, GroupService>();
            builder.Services.AddTransient<IInstructorRepository, InstructorRepository>();
            builder.Services.AddTransient<IInstructorService, InstructorService>();
            builder.Services.AddRazorPages();

        }
    }
}