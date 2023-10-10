using Foodery.Data.Models;
using Foodery.Web.ViewModels.Order;

namespace Foodery.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(OrderCreateViewModel viewModel);

        IQueryable<OrderViewModel> GetAll();

        Task SetOrdersToReceipt(Receipt receipt);

        Task CompleteOrder(Guid orderId);
    }
}
