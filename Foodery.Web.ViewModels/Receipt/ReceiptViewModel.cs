using Foodery.Web.ViewModels.Order;
using Foodery.Web.ViewModels.User;
using Foodery.Services.Models;

namespace Foodery.Web.ViewModels.Receipt
{
    public class ReceiptViewModel
    {
        public ReceiptViewModel()
        {
            Orders = new List<OrderViewModel>();
        }

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid RecipientId { get; set; }

        public ApplicationUserViewModel Recipient { get; set; } = null!;

        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
