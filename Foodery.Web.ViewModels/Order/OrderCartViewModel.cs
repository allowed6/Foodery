using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Web.ViewModels.Order
{

    // this class is not used anywhere!!!!!!!!!
    public class OrderCartViewModel
    {
        public string Id { get; set; } = null!;

        public string ProductPicture { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}
