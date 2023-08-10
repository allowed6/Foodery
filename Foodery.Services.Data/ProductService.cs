namespace Foodery.Services.Data
{
    using Foodery.Data;
    using Foodery.Services.Data.Interfaces;
    using Foodery.Web.ViewModels.Product;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly FooderyDbContext dbContext;

        public ProductService(FooderyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public Task<ICollection<ProductAllViewModel>> GetAllAsync()
        //{
        //}
    }
}
