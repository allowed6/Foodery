namespace Foodery.Data
{
    using Foodery.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class FooderyDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public FooderyDbContext(DbContextOptions<FooderyDbContext> options)
            : base(options)
        {
        }


        //might need to delete migrations later!!!!!!!!!!!!!!!!!!
    }
}