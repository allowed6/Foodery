namespace Foodery.Web.Controllers
{
    using Foodery.Services.Data.Interfaces;
    using Foodery.Services.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using Foodery.Web.ViewModels.Receipt;
    using Humanizer.DateTimeHumanizeStrategy;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Foodery.Services.Mapping;

    public class ReceiptController : Controller
    {
        private readonly IReceiptService receiptService;
        private readonly IMapper mapper;

        public ReceiptController(IReceiptService receiptService, IMapper mapper)
        {
            this.receiptService = receiptService;
            this.mapper = mapper;
        }

        public string GetUserId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return userId;
        }

        public string GetUserName()
        {
            var userName = this.User?.Identity?.Name;

            return userName;
        }

        public async Task<IActionResult> Profile()
        {
            string userId = GetUserId();

            Guid userIdAsGuid = new Guid(userId);

            List<ReceiptProfileViewModel> receipts = await
                this.receiptService.GetAllByRecipientId(userIdAsGuid)
                .ToListAsync();

            return this.View(receipts);
        }

        [Authorize]
        public async Task<IActionResult> Details(Guid id)
        {
            ReceiptDetailsViewModel receipt = await this.receiptService.GetAll()
                .SingleOrDefaultAsync(receipt => receipt.Id == id);

            if (receipt.Recipient != GetUserName())
            {
                throw new Exception("Invalid receipt!");
            }


            return this.View(receipt);
        }
    }
}
