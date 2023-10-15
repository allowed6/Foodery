using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Services.Models
{
    public class OrderServiceModel
    {
        public OrderServiceModel()
        {
            this.Id = new Guid();
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public Guid ProductId { get; set; }


        [ForeignKey(nameof(ProductId))]
        public virtual ProductServiceModel Product { get; set; } = null!;

        public int Quantity { get; set; }

        public Guid IssuerId { get; set; }

        public virtual ApplicationUserServiceModel Issuer { get; set; } = null!;

        public int StatusId { get; set; }


        [ForeignKey(nameof(StatusId))]
        public virtual OrderStatusServiceModel Status { get; set; } = null!;
    }
}
