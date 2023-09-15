using Foodery.Web.ViewModels.Order;
using Microsoft.AspNetCore.Identity;

namespace Foodery.Web.ViewModels.User
{
    public class ApplicationUserViewModel : IdentityUser<Guid>
    {

        public ApplicationUserViewModel()
        {
            this.Id = Guid.NewGuid();
            this.Orders = new List<OrderViewModel>();
        }

        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
