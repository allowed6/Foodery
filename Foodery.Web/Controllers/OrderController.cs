using Foodery.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Foodery.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var orders = await this.orderService.GetAll()
                .Where(order => order.Status.Name == "Active" && 
                order.IssuerId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
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
