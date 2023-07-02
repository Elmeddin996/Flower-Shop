using Flowers.Core.Entities;
using Flowers.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Flowers.Data
{
    public class FlowerDbContext : IdentityDbContext
    {
        public FlowerDbContext(DbContextOptions<FlowerDbContext> options) : base(options)
        {
        }

        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<FlowerImage> FlowerImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategorieConfig).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flower>()
           .HasMany(flower => flower.FlowerImages)
           .WithOne(image => image.Flower)
           .HasForeignKey(image => image.FlowerId);

            modelBuilder.Entity<Flower>()
           .HasOne(flower => flower.Categorie)
           .WithMany(categorie => categorie.Flower)
           .HasForeignKey(flower => flower.CategorieId);
        }
    }
}
