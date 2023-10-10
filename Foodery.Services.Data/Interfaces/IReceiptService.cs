using Foodery.Data.Models;
using Foodery.Web.ViewModels.Receipt;

namespace Foodery.Services.Data.Interfaces
{
    public interface IReceiptService
    {
        Task CreateReceiptAsync(Guid recipientId);

        IQueryable<ReceiptViewModel> GetAll();

        IQueryable<ReceiptViewModel> GetAllByRecipientId(Guid recipientId);

        
    }
}
