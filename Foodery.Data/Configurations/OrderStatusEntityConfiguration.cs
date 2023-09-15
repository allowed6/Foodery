using Foodery.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodery.Data.Configurations
{
    public class OrderStatusEntityConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasData(this.GenerateOrderStatuses());
        }

        private OrderStatus[] GenerateOrderStatuses()
        {
            ICollection<OrderStatus> orderStatuses = new HashSet<OrderStatus>();

            OrderStatus orderStatus;

            orderStatus = new OrderStatus
            {
                Id = 1,
                Name = "Active",
            };
            orderStatuses.Add(orderStatus);

            orderStatus = new OrderStatus
            {
                Id = 2,
                Name = "Completed",
            };
            orderStatuses.Add(orderStatus);

            return orderStatuses.ToArray();
        }
    }
}
