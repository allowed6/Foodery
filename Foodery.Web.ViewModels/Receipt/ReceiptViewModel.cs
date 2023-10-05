

using Foodery.Web.ViewModels.Order;
using Foodery.Web.ViewModels.User;

namespace Foodery.Web.ViewModels.Receipt
{
    public class ReceiptViewModel
    {
        public ReceiptViewModel()
        {
            this.Orders = new List<OrderViewModel>();
        }

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string RecipientId { get; set; } = null!;

        public ApplicationUserViewModel Recipient { get; set; } = null!;

        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
