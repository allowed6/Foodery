namespace Foodery.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Products = new List<Product>();
        }

        public virtual ICollection<Product> Products { get; set; }
    }
}
