using Foodery.Web.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<ProductAllViewModel>> GetAllAsync();

        Task AddAsync(ProductAddViewModel viewModel);

        Task<ProductAddViewModel> GetNewProductAsync();

        Task<ProductEditViewModel?> GetProductForEditById(string id);

        Task EditProductAsync(string id, ProductEditViewModel viewModel);

        Task<ProductDetailsViewModel?> GetProductForDetailsById(string id);
    }
}
