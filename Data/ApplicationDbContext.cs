using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OC_P5.Models;

namespace OC_P5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarTrim> CarTrims { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarMedia>()
               .HasKey(t => new { t.CarId, t.MediaId });

            modelBuilder.Entity<CarCarTrim>()
                .HasKey(t => new { t.CarId, t.CarTrimId });

            modelBuilder.Entity<CarCarTrim>()
                .HasOne(cct => cct.CarTrim)
                .WithMany(ct => ct.CarCarTrims)
                .HasForeignKey(cct => cct.CarTrimId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<CarModel>()
                .HasOne(cm => cm.CarBrand)
                .WithMany(cb => cb.CarModels)
                .HasForeignKey(cm => cm.CarBrandId);

        }
    }
}
