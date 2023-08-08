namespace Foodery.Data
{
    using Foodery.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class FooderyDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public FooderyDbContext(DbContextOptions<FooderyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderStatus> OrderStatuses { get; set; } = null!;

        public DbSet<Receipt> Receipts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(FooderyDbContext)) ?? 
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(14, 2);

            base.OnModelCreating(builder);
        }
    }
}