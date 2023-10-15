namespace Foodery.Services.Data
{
    using Foodery.Data;
    using Foodery.Data.Models;
    using Foodery.Services.Data.Interfaces;
    using Foodery.Services.Mapping;
    using Foodery.Services.Models;
    using Foodery.Web.ViewModels.Category;
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

        public async Task EditProductAsync(string id, ProductEditViewModel viewModel)
        {
            Product? product = await this.dbContext.Products
                .FirstOrDefaultAsync(p => p.Id.ToString() == id);

            if (product != null)
            {
                product.Name = viewModel.Name;
                product.Price = viewModel.Price;
                product.Description = viewModel.Description;
                product.ImageUrl = viewModel.ImageUrl;
                product.CategoryId = viewModel.CategoryId;
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ProductDetailsViewModel?> GetProductForDetailsById(string id)
        {
            ICollection<CategoryAllViewModel> allCategories = await this.dbContext.Categories
                .Select(c => new CategoryAllViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            ProductDetailsViewModel? product = await dbContext.Products
                .Where(p => p.Id.ToString() == id)
                .Select(p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    Categories = allCategories
                })
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<ProductEditViewModel?> GetProductForEditById(string id)
        {
            ICollection<CategoryAllViewModel> allCategories = await this.dbContext.Categories
                .Select(c => new CategoryAllViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            ProductEditViewModel? product = await dbContext.Products
                .Where(p => p.Id.ToString() == id)
                .Select(p => new ProductEditViewModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    Categories = allCategories
                })
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<ProductAddViewModel> GetNewProductAsync() 
        {
            ICollection<CategoryAllViewModel> allCategories = await this.dbContext.Categories
                .Select(c => new CategoryAllViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            ProductAddViewModel currentProduct = new ProductAddViewModel
            {
                Categories = allCategories
            };

            return currentProduct;
        }

        public async Task AddAsync(ProductAddViewModel viewModel)
        {
            Product productToAdd = new Product 
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                Price = viewModel.Price,
                ImageUrl = viewModel.ImageUrl,
                Description = viewModel.Description,
                CategoryId = viewModel.CategoryId
            };

            this.dbContext.Products.Add(productToAdd);
            await this.dbContext.SaveChangesAsync();
        }

        public IQueryable<ProductAllViewModel> GetAllAsync()
        {
            IQueryable<ProductAllViewModel> allProducts = this.dbContext.Products
                .To<ProductAllViewModel>();

            return allProducts;
        }
    }
}
