namespace Foodery.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        public Order()
        {
            this.Id = new Guid();
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public Guid ProductId { get; set; }


        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;

        public int Quantity { get; set; }

        public string IssuerId { get; set; } = null!;

        public virtual ApplicationUser Issuer { get; set; } = null!;

        public int StatusId { get; set; }


        [ForeignKey(nameof(StatusId))]
        public virtual OrderStatus Status { get; set; } = null!;

    }
}
