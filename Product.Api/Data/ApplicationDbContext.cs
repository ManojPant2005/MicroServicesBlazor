using Microsoft.EntityFrameworkCore;
using ProductApi.Data.Models;

namespace ProductApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Products> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            for (int i = 1; i <= 4; i++)
            {
                modelBuilder.Entity<Products>().HasData(new Products
                {
                    Id = i,
                    Name = $"Product Name {i}",
                    Description = $"Description for Product {i}",
                    Price = i * 10,
                    ImageUrl = "",
                    CategoryName = $"Category {(i % 2) + 1}"
                });
            }
        }
    }
}
