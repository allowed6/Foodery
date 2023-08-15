using Foodery.Web.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Web.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public int CategoryId { get; set; }


        public ICollection<CategoryAllViewModel> Categories = new List<CategoryAllViewModel>();
    }
}
