using Foodery.Services.Data.Interfaces;
using Foodery.Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace Foodery.Web.Areas.Administration.Controllers
{
    public class ProductController : AdminController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var product = await this.productService.GetNewProductAsync();

            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductAddViewModel viewModel)
        {
            await this.productService.AddAsync(viewModel);

            return RedirectToAction("All", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var product = await this.productService.GetProductForEditById(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ProductEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException("Invalid parameters!");
            }

            await this.productService.EditProductAsync(id, viewModel);

            return RedirectToAction("All", "Product");
        }
    }
}
