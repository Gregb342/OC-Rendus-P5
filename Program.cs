using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using OC_P5.Areas.Identity.CustomData;
using OC_P5.Data;
using OC_P5.Data.Repositories;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Services;
using OC_P5.Services.Interfaces;
using Serilog;

namespace OC_P5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("ExpressVoituresDB") ?? throw new InvalidOperationException("Connection string 'ExpressVoituresDB' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<AdminUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
            builder.Services.AddScoped<ICarBrandRepository, CarBrandRepository>();
            builder.Services.AddScoped<ICarTrimRepository, CarTrimRepository>();
            builder.Services.AddScoped<IMediaRepository, MediaRepository>();
            builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            builder.Services.AddScoped<IRepairRepository, RepairRepository>();
            builder.Services.AddScoped<ISaleRepository, SaleRepository>();
            builder.Services.AddScoped<ICarMediaRepository, CarMediaRepository>();
            builder.Services.AddScoped<IYearOfProductionRepository, YearOfProductionRepository>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<ICarBrandService, CarBrandService>();
            builder.Services.AddScoped<ICarModelService, CarModelService>();
            builder.Services.AddScoped<ICarTrimService, CarTrimService>();
            builder.Services.AddScoped<IPurchaseService, PurchaseService>();
            builder.Services.AddScoped<IRepairService, RepairService>();
            builder.Services.AddScoped<ISaleService, SaleService>();
            builder.Services.AddScoped<IMediaService, MediaService>();
            builder.Services.AddScoped<IYearOfProductionService, YearOfProductionService>();

            Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.File("Logs/myapp-.txt", rollingInterval: RollingInterval.Day)
                        .CreateLogger();

            // Remplacer le système de log par défaut par Serilog
            builder.Host.UseSerilog();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin" };

                foreach (var role in roles)
                {
                    if (!roleManager.RoleExistsAsync(role).Result)
                    {
                        roleManager.CreateAsync(new IdentityRole(role)).Wait();
                    }
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AdminUser>>();

                string email = "admin@express-voitures.com";
                string password = "Admin@123";

                var user = new AdminUser();
                user.UserName = email;
                user.Email = email;
                user.EmailConfirmed = true;

                userManager.CreateAsync(user, password).Wait();
                userManager.AddToRoleAsync(user, "Admin").Wait();
            }

            var cultureInfo = new CultureInfo("fr-FR");
            cultureInfo.NumberFormat = NumberFormatInfo.InvariantInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            var supportedCultures = new[] { cultureInfo };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(cultureInfo),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Cars}/{action=Index}/{id?}");
            app.MapRazorPages();


            app.Run();
        }

    }
}