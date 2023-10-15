using Foodery.Services.Mapping;
using Foodery.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Web.ViewModels.Receipt
{
    public class ReceiptDetailsOrderViewModel : IMapFrom<Foodery.Data.Models.Order>
    {
        public string ProductName { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}

