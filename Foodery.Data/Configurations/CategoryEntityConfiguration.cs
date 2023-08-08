namespace Foodery.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Vegetables"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Meat"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Dairy"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
