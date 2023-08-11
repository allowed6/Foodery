using Foodery.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Foodery.Web.Areas.Administration.Controllers
{
    public class ProductController : AdminController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
    }
}
