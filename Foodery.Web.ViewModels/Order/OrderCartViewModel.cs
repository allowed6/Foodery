using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Web.ViewModels.Order
{
    public class OrderCartViewModel
    {
        public string Id { get; set; }

        public string ProductPicture { get; set; }

        public string ProductName { get; set; }

        public string Quantity { get; set; }
    }
}
