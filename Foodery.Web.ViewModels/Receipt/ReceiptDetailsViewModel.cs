using AutoMapper;
using Foodery.Data.Models;
using Foodery.Services.Mapping;
using Foodery.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Web.ViewModels.Receipt
{
    public class ReceiptDetailsViewModel : IMapFrom<Foodery.Data.Models.Receipt>, IHaveCustomMappings
    {
        public ReceiptDetailsViewModel()
        {
            Orders = new List<ReceiptDetailsOrderViewModel>();
        }

        public Guid Id { get; set; }

        public string Recipient { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedOn { get; set; }

        public virtual List<ReceiptDetailsOrderViewModel> Orders { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Foodery.Data.Models.Receipt, ReceiptDetailsViewModel>()
                .ForMember(destination => destination.Recipient, opt =>
                opt.MapFrom(origin => origin.Recipient.UserName));
        }
    }
}
