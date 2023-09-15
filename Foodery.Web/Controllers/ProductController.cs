namespace Foodery.Web.Controllers
{
    using Foodery.Services.Data.Interfaces;
    using Foodery.Web.ViewModels.Order;
    using Foodery.Web.ViewModels.Product;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;

        public ProductController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
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

        [HttpPost]
        public async Task<IActionResult> Order(ProductOrderViewModel productOrderViewModel)
        {
            OrderCreateViewModel orderViewModel = new OrderCreateViewModel
            {
                Quantity = productOrderViewModel.Quantity,
                ProductId = productOrderViewModel.ProductId
            };

            orderViewModel.IssuerId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

             await this.orderService.CreateAsync(orderViewModel);

            return this.Redirect("/");
        }
    }
}
