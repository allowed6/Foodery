using Foodery.Data.Models;
using Foodery.Services.Models;
using Foodery.Web.ViewModels.Receipt;

namespace Foodery.Services.Data.Interfaces
{
    public interface IReceiptService
    {
        Task CreateReceiptAsync(Guid recipientId);

        IQueryable<ReceiptDetailsViewModel> GetAll();

        IQueryable<ReceiptProfileViewModel> GetAllByRecipientId(Guid recipientId);


    }
}
