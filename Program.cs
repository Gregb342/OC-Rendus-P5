using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OC_P5.Data;
using OC_P5.Data.Repositories;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Services;
using OC_P5.Services.Interfaces;

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

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
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
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IPurchaseService, PurchaseService>();
            builder.Services.AddScoped<IRepairService, RepairService>();

            var app = builder.Build();

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