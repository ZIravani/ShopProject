using Contracts.ProductCategory;
using EFcore;
using EFcore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagementApplication;
using ShopManagmentDomain.ProductCategory;

namespace Configuration
{
    public class BootStrapper
    {
        public static void Configure(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<IProductCategoryApplication, ProductCatApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionstring));

        }
    }
}