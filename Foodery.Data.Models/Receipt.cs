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

        public string RecipientId { get; set; } = null!;

        public ApplicationUser Recipient { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
