namespace Foodery.Web
{
    using Foodery.Data;
    using Foodery.Data.Models;
    using Foodery.Services.Data;
    using Foodery.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Foodery.Web.Infrastructure.Extensions;
    using Microsoft.IdentityModel.Protocols.OpenIdConnect;

    using static Common.GlobalApplicationConstants;
    using System.Security.Cryptography.X509Certificates;
    using Foodery.Web.Infrastructure.ModelBinders;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
    using Foodery.Web.ViewModels.Home;
    using System.Reflection;
    using Foodery.Services.Models;
    using Foodery.Web.ViewModels.Receipt;
    using AutoMapper;
    using Foodery.Services.Mapping;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            builder.Services.AddDbContext<FooderyDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddRazorPages();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
            {
                options.SignIn.RequireConfirmedAccount = 
                    builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase = 
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase = 
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric = 
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength = 
                    builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<FooderyDbContext>();

            builder.Services.AddApplicationServices(typeof(IProductService));
            builder.Services.AddApplicationServices(typeof(ICategoryService));
            builder.Services.AddApplicationServices(typeof(IOrderService));
            builder.Services.AddApplicationServices(typeof(IReceiptService));
            builder.Services.AddAutoMapper(typeof(IMapper));

            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                });

            WebApplication app = builder.Build();

            app.SeedAdministrator();

            AutoMapperConfig.RegisterMappings(
                typeof(ErrorViewModel).GetTypeInfo().Assembly,
                typeof(ReceiptDetailsViewModel).GetType().Assembly,
                typeof(ReceiptServiceModel).GetType().Assembly);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();


            app.Run();
        }
    }
}