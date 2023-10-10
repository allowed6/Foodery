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
        private readonly IReceiptService receiptService;

        public OrderController(IOrderService orderService, IReceiptService receiptService)
        {
            this.orderService = orderService;
            this.receiptService = receiptService;
        }
        public string UserId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return userId;
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
        public async Task<IActionResult> CartConfirm()
        {
            Guid userId = new Guid(UserId());

            await this.receiptService.CreateReceiptAsync(userId);

            return this.Redirect("/");
        }
    }
}
