using Foodery.Web.ViewModels.Product;
using Foodery.Web.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Web.ViewModels.Order
{
    public class OrderCreateViewModel
    {
        public DateTime IssuedOn { get; set; }

        public Guid ProductId { get; set; }

        public virtual ProductViewModel Product { get; set; } = null!;

        public int Quantity { get; set; }

        public string IssuerId { get; set; } = null!;

        public virtual ApplicationUserViewModel Issuer { get; set; } = null!;

        public int StatusId { get; set; }


        public virtual OrderStatusViewModel Status { get; set; } = null!;
    }
}
