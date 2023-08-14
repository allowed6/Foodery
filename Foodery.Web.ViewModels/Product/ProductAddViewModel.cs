using Foodery.Web.ViewModels.Category;

namespace Foodery.Web.ViewModels.Product
{
    public class ProductAddViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int CategoryId { get; set; }

        public string CategoryType { get; set; } = null!;


        public ICollection<CategoryAllViewModel> Categories = new List<CategoryAllViewModel>();
    }
}
