using HomeHero.Data;
using HomeHero.Models;
using HomeHero.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace HomeHero
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<HomeHeroContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

            //Create a service for login 
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(50);
            });
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.AccessDeniedPath = "/Manage/AccessError";
                });
            builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

            builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting = false)
                .AddSessionStateTempDataProvider();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ADMINISTRADORES", policy => policy.RequireRole("ADMIN"));
            });
            //Add services to send mails
            builder.Services.AddSingleton<IHHeroEmail>(new HHeroEmail(builder.Configuration["GmailSettings:Email"],builder.Configuration["GmailSettings:Password"]));
            
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbContext = services.GetRequiredService<HomeHeroContext>();
                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.EnsureCreated();
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while deleting the data: " + ex.Message);
                }

            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}