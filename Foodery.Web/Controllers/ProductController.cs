namespace Foodery.Web.Controllers
{
    using Foodery.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> All()
        {
            var products = await this.productService.GetAllAsync();

            return this.View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var product = await this.productService.GetProductForDetailsById(id);

            return this.View(product);
        }
    }
}
