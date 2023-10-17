using AutoMapper;
using Foodery.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Web.ViewModels.Receipt
{
    public class ReceiptProfileViewModel : IMapFrom<Foodery.Data.Models.Receipt>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal Total { get; set; }

        public int Products { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Foodery.Data.Models.Receipt, ReceiptProfileViewModel>()
                .ForMember(destination => destination.Total, opt =>
                opt.MapFrom(origin => origin.Orders.Sum(order => order.Product.Price * order.Quantity)))
                .ForMember(destination => destination.Products, opt =>
                opt.MapFrom(origin => origin.Orders.Sum(order => order.Quantity)));
        }
    }
}
