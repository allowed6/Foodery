namespace Foodery.Services.Data
{
    using Foodery.Data;
    using Foodery.Services.Data.Interfaces;
    using Foodery.Web.ViewModels.Product;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly FooderyDbContext dbContext;

        public ProductService(FooderyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<ProductAllViewModel>> GetAllAsync()
        {
            ICollection<ProductAllViewModel> allProducts = await this.dbContext.Products
                .Select(p => new ProductAllViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                }).ToListAsync();

            return allProducts;
        }
    }
}
