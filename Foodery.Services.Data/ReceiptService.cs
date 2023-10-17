using Foodery.Data;
using Foodery.Data.Models;
using Foodery.Services.Data.Interfaces;
using Foodery.Services.Mapping;
using Foodery.Services.Models;
using Foodery.Web.ViewModels.Receipt;

namespace Foodery.Services.Data
{
    public class ReceiptService : IReceiptService
    {
        public readonly FooderyDbContext dbContext;

        private readonly IOrderService orderService;

        public ReceiptService(FooderyDbContext dbContext, IOrderService orderService)
        {
            this.dbContext = dbContext;
            this.orderService = orderService;
        }

        public async Task CreateReceiptAsync(Guid recipientId)
        {

            Receipt receipt = new Receipt
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                RecipientId = recipientId
            };

            await this.orderService.SetOrdersToReceipt(receipt);

            foreach (var order in receipt.Orders)
            {
                await this.orderService.CompleteOrder(order.Id);
            }

            await this.dbContext.Receipts.AddAsync(receipt);
            await this.dbContext.SaveChangesAsync();
        }

        public IQueryable<ReceiptDetailsViewModel> GetAll()
        {
            return this.dbContext.Receipts
                .To<ReceiptDetailsViewModel>();
        }

        public IQueryable<ReceiptProfileViewModel> GetAllByRecipientId(Guid recipientId)
        {
            return this.dbContext.Receipts.Where(r => r.RecipientId == recipientId).To<ReceiptProfileViewModel>();
        }


    }
}
