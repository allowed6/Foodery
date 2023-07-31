namespace Foodery.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Product;

    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public double Price { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
