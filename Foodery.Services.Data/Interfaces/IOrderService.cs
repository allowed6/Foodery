using Foodery.Web.ViewModels.Order;

namespace Foodery.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(OrderCreateViewModel viewModel);
    }
}
