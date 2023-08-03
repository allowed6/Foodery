using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Data.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string ProductId { get; set; } = null!;


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
