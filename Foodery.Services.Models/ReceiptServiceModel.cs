using Foodery.Data.Models;

namespace Foodery.Services.Models
{
    public class ReceiptServiceModel
    {
        public ReceiptServiceModel()
        {
            this.Orders = new List<OrderServiceModel>();
        }

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid RecipientId { get; set; }

        public ApplicationUserServiceModel Recipient { get; set; } = null!;

        public virtual ICollection<OrderServiceModel> Orders { get; set; }
    }
}