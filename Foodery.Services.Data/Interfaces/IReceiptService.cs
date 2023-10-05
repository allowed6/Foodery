using Foodery.Web.ViewModels.Receipt;

namespace Foodery.Services.Data.Interfaces
{
    public interface IReceiptService
    {
        Task CreateReceiptAsync(string recipientId);

        IQueryable<ReceiptViewModel> GetAll();

        IQueryable<ReceiptViewModel> GetAllByRecipientId(string recipientId);
    }
}
