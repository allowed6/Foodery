using Foodery.Data;
using Foodery.Data.Models;
using Foodery.Services.Data.Interfaces;
using Foodery.Web.ViewModels.Order;
using Foodery.Web.ViewModels.Product;
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

        public IQueryable<OrderViewModel> GetAll()
        {
            var allOrders = this.dbContext.Orders
                .Select(o => new OrderViewModel 
                {
                    IssuedOn = o.IssuedOn,
                    Quantity = o.Quantity,
                    Product = new ProductViewModel 
                    {
                        Id = o.ProductId,
                        Name = o.Product.Name,
                        CategoryId = o.Product.CategoryId,
                        Description = o.Product.Description,
                        ImageUrl = o.Product.ImageUrl,
                        Price = o.Product.Price
                    },
                    IssuerId = o.IssuerId.ToString(),
                    ProductId = o.ProductId.ToString(),
                    Status = new OrderStatusViewModel
                    {
                        Name = o.Status.Name
                    },
                    StatusId = o.StatusId
                });

            return allOrders;
        }
    }
}
