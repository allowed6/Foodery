using Foodery.Data.Models;
using Foodery.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Services.Models
{
    public class CategoryServiceModel : IMapFrom<Category>
    {
        public CategoryServiceModel()
        {
            this.Products = new List<ProductServiceModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<ProductServiceModel> Products { get; set; }
    }
}
