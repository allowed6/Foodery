using Foodery.Data;
using Foodery.Data.Models;
using Foodery.Services.Data.Interfaces;
using Foodery.Web.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace Foodery.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly FooderyDbContext dbContext;

        public CategoryService(FooderyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryAllViewModel>> GetAllAsync()
        {
            IEnumerable<CategoryAllViewModel> allCategories = await this.dbContext.Categories
                .Select(c => new CategoryAllViewModel 
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            return allCategories;
        }

        public async Task AddAsync(CategoryAddViewModel viewModel)
        {
            Category category = new Category 
            {
                Name = viewModel.Name,
            };

            this.dbContext.Categories.Add(category);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
