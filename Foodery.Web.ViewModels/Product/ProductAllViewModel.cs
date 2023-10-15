using Foodery.Services.Mapping;

namespace Foodery.Web.ViewModels.Product
{
    public class ProductAllViewModel : IMapFrom<Foodery.Data.Models.Product>
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
