using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OC_P5.Data.Seed;
using OC_P5.Models;

namespace OC_P5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarTrim> CarTrims { get; set; }
        public DbSet<CarModelCarTrim> CarModelCarTrims { get; set; }
        public DbSet<CarMedia> CarMedias { get; set; }
        public DbSet<TypeOfMedia> TypeOfMedias { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<YearOfProduction> YearOfProductions { get; set; }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Creation des clés primaires composites
            modelBuilder.Entity<CarMedia>()
               .HasKey(t => new { t.CarId, t.MediaId });

            modelBuilder.Entity<CarModelCarTrim>()
                .HasKey(t => new { t.CarModelId, t.CarTrimId });

            modelBuilder.Entity<CarModelCarTrim>()
                .HasOne(cct => cct.CarTrim)
                .WithMany(ct => ct.CarModelCarTrims)
                .HasForeignKey(cct => cct.CarTrimId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CarModel>()
                .HasOne(cm => cm.CarBrand)
                .WithMany(cb => cb.CarModels)
                .HasForeignKey(cm => cm.CarBrandId);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.CarModel)
                .WithMany(cm => cm.Cars)
                .HasForeignKey(c => c.CarModelId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            //YearOfProductionSeed.Seed(modelBuilder);
            //TypeOfMediaSeed.Seed(modelBuilder);
            //CarBrandSeed.Seed(modelBuilder);
            //CarModelSeed.Seed(modelBuilder);
            //CarTrimSeed.Seed(modelBuilder);
            //CarCarTrimSeed.Seed(modelBuilder);
            //CarSeed.Seed(modelBuilder);

        }
    }
}
