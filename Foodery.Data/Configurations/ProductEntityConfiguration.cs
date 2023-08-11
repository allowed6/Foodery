namespace Foodery.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateProducts());
        }

        private Product[] GenerateProducts()
        {
            ICollection<Product> products = new HashSet<Product>();

            Product product;

            product = new Product()
            {
                Name = "Cucumber",
                Description = "Freshly picked cucumbers from a home garden.",
                CategoryId = 1,
                Price = 2.39M,
                ImageUrl = "https://img.freepik.com/free-photo/green-cucumber_144627-21625.jpg?w=1060&t=st=1691777180~exp=1691777780~hmac=69e89a3b2e1153169d0963bf34f111254a986af1488ef705d28019f8d50b585c"
            };
            products.Add(product);

            product = new Product()
            {
                Name = "Beef stake",
                Description = "Tender beef raw stake.",
                CategoryId = 2,
                Price = 16.29M,
                ImageUrl = "https://img.freepik.com/free-photo/raw-steak-white-paper_144627-10267.jpg?w=900&t=st=1691508215~exp=1691508815~hmac=b94fedbcc0b3a2318864761384985b3f7b7ea07415f9934276fe8a4f755a5c69"
            };
            products.Add(product);

            product = new Product()
            {
                Name = "Blue cheese",
                Description = "Delicious french blue cheese.",
                CategoryId = 3,
                Price = 34.99M,
                ImageUrl = "https://img.freepik.com/free-photo/delicious-piece-blue-cheese_144627-43343.jpg?w=740&t=st=1691508345~exp=1691508945~hmac=e0362a0145d63688f350affe6295f39dd2aa68fb2c1f7d09e2aa92dec4ab8f3f"
            };
            products.Add(product);

            return products.ToArray();
        }
    }
}
