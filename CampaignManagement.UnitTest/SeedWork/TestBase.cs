using CampaignManagement.Application.Campaign;
using CampaignManagement.Application.Order;
using CampaignManagement.Application.Product;
using CampaignManagement.Application.ProductCampaign;
using CampaignManagement.Domain.SeedWork;
using CampaignManagement.Domain.SeedWork.Repository;
using CampaignManagement.Infrastructure.AddDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CampaignManagement.UnitTest
{
    public abstract class TestBase
    {
        public static T GetService<T>()
        {
            var services = new ServiceCollection();
            services.AddDbContext<CampaignManagementDbContext>(options =>
                options.UseSqlServer("Server=localhost;Database=CampaignManagement;Trusted_Connection=True;"));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICampaignService, CampaignService>();
            services.AddTransient<IProductCampaignService, ProductCampaignService>();

            return services.BuildServiceProvider().GetService<T>();
        }
      
    }
}