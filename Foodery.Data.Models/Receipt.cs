namespace Foodery.Data.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.Orders = new List<Order>();
        }

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid RecipientId { get; set; }

        public ApplicationUser Recipient { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
