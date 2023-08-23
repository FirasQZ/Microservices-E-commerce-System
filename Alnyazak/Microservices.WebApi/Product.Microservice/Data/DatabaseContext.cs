using Microsoft.EntityFrameworkCore;
using Product.Microservice.Models;
using System.Configuration;

namespace Product.Microservice.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
       : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<ProductDetails> PRODUCT_DETAILS_ENTITY { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<ProductDetails>().HasData(
            new ProductDetails
            {
                id = 1,
                ProductName = "Product 1",
                ProductPrice="100",
                ProductQuantity =10,
                createdAt = DateTime.Now.ToString(),
                updatedAt = DateTime.Now.ToString(),
                createdBy = "User_1",
                updatedBy = "User_1",
            },
            new ProductDetails
            {
                id = 2,
                ProductName = "Product 2",
                ProductPrice = "200",
                ProductQuantity = 20,
                createdAt = DateTime.Now.ToString(),
                updatedAt = DateTime.Now.ToString(),
                createdBy = "User_1",
                updatedBy = "User_1",
            },
            new ProductDetails
            {
                id = 3,
                ProductName = "Product 3",
                ProductPrice = "300",
                ProductQuantity = 30,
                createdAt = DateTime.Now.ToString(),
                updatedAt = DateTime.Now.ToString(),
                createdBy = "User_1",
                updatedBy = "User_1",
            });

        }
    }
}
