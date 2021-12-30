using System.Threading.Tasks;

namespace CampaignManagement.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
