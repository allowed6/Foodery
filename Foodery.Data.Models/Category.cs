namespace Foodery.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Category;

    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}