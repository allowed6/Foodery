using Foodery.Services.Data.Interfaces;
using Foodery.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace Foodery.Web.Areas.Administration.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException("Invalid parameters");
            }

            await this.categoryService.AddAsync(viewModel);

            return Redirect("/");
        }
    }
}
