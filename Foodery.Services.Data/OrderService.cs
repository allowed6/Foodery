using Foodery.Data;
using Foodery.Data.Models;
using Foodery.Services.Data.Interfaces;
using Foodery.Web.ViewModels.Order;
using Microsoft.EntityFrameworkCore;

namespace Foodery.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly FooderyDbContext dbContext;

        public OrderService(FooderyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(OrderCreateViewModel viewModel)
        {
            Order orderToCreate = new Order();

            //Id = Guid.NewGuid(),
            //    IssuedOn = DateTime.UtcNow,
            //    Status = await this.dbContext.OrderStatuses
            //    .SingleOrDefaultAsync(os => os.Name == "Active")

            orderToCreate.Id = Guid.NewGuid();
            orderToCreate.Status = await this.dbContext.OrderStatuses
                .SingleOrDefaultAsync(os => os.Name == "Active");
            orderToCreate.ProductId = viewModel.ProductId;
            orderToCreate.IssuedOn = DateTime.UtcNow;
            orderToCreate.IssuerId = viewModel.IssuerId;
            orderToCreate.Quantity = viewModel.Quantity;

            await this.dbContext.Orders.AddAsync(orderToCreate);
            await this.dbContext.SaveChangesAsync();

        }
    }
}
