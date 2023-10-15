using Foodery.Data.Models;
using Foodery.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Services.Models
{
    public class ProductServiceModel : IMapFrom<Product>
    {
        public ProductServiceModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int CategoryId { get; set; }

        public virtual CategoryServiceModel Category { get; set; } = null!;
    }
}
