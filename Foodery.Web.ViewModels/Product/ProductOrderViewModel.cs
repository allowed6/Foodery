using Foodery.Services.Mapping;

namespace Foodery.Web.ViewModels.Product
{
    public class ProductOrderViewModel
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
