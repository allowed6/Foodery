namespace Foodery.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.Orders = new List<Order>();
        }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
