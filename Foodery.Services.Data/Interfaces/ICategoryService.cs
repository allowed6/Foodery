using Foodery.Web.ViewModels.Category;

namespace Foodery.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task AddAsync(CategoryAddViewModel viewModel);
    }
}
