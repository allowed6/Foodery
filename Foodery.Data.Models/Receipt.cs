namespace Foodery.Data.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.ReceiptOrders = new List<Receipt>();
        }

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid RecipientId { get; set; }

        public virtual ApplicationUser Recipient { get; set; } = null!;

        public virtual ICollection<Receipt> ReceiptOrders { get; set; }
    }
}
