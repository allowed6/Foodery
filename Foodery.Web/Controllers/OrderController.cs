using Foodery.Services.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Foodery.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var orders = await this.orderService.GetAll()
                .Where(order => order.Status.Name == "Active")
                .ToListAsync();

            return View(orders);
        }

        [HttpPost]
        public IActionResult CartConfirm()
        {
            return View();
        }
    }
}
