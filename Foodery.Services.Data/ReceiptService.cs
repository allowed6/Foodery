using Foodery.Data;
using Foodery.Data.Models;
using Foodery.Services.Data.Interfaces;
using Foodery.Services.Mapping;
using Foodery.Web.ViewModels.Receipt;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task CreateReceiptAsync(string recipientId)
        {
            Receipt receipt = new Receipt
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.UtcNow,
                RecipientId = recipientId,
                Orders = await this.dbContext.Orders.Where(order => order.IssuerId.ToString() == recipientId &&
                order.Status.Name == "Active").ToListAsync()
            };

            await this.dbContext.Receipts.AddAsync(receipt);
            await this.dbContext.SaveChangesAsync();
        }

        public IQueryable<ReceiptViewModel> GetAll()
        {
            return this.dbContext.Receipts.To<ReceiptViewModel>();
        }

        public IQueryable<ReceiptViewModel> GetAllByRecipientId(string recipientId)
        {
            throw new NotImplementedException();
        }
    }
}
