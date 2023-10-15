namespace Foodery.Services.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUserServiceModel : IdentityUser<Guid>
    {
        public ApplicationUserServiceModel()
        {
            this.Id = Guid.NewGuid();
            this.Orders = new List<OrderServiceModel>();
        }

        public virtual ICollection<OrderServiceModel> Orders { get; set; }
    }
}
