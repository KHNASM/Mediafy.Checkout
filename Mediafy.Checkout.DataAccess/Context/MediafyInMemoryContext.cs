using Mediafy.Checkout.Domain.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace Mediafy.Checkout.DataAccess.Context
{
    public class MediafyInMemoryContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Offer> Offers { get; set; }

        public MediafyInMemoryContext(DbContextOptions opt)  : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().HasData(SampleData.GetSampleProductData());
            modelBuilder.Entity<Offer>().ToTable("Offers");
            modelBuilder.Entity<Offer>().HasData(SampleData.GetOfferData());
        }
    }
}
