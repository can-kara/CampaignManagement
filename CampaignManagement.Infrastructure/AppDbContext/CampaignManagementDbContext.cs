using CampaignManagement.Domain.AggregateModels.CampaignModels;
using CampaignManagement.Domain.AggregateModels.OrderModels;
using CampaignManagement.Domain.AggregateModels.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace AppDbContext.Domain.SeedWork.CampaignManagementDbContext
{
    public class CampaignManagementDbContext : DbContext
    {
        public CampaignManagementDbContext(DbContextOptions<CampaignManagementDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
    }
}