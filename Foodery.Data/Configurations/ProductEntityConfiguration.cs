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
                Description = "Freshly picked cucumbers from a home garden.",
                CategoryId = 1,
                Price = 2.39M,
                ImageUrl = "https://www.freepik.com/free-photo/green-cucumber_7399053.htm#query=cucumbers&position=0&from_view=search&track=sph"
            };
            products.Add(product);

            product = new Product()
            {
                Description = "Tender beef raw stake.",
                CategoryId = 2,
                Price = 16.29M,
                ImageUrl = "https://img.freepik.com/free-photo/raw-steak-white-paper_144627-10267.jpg?w=900&t=st=1691508215~exp=1691508815~hmac=b94fedbcc0b3a2318864761384985b3f7b7ea07415f9934276fe8a4f755a5c69"
            };
            products.Add(product);

            product = new Product()
            {
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
