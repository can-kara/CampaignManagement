using System.Threading.Tasks;

namespace CampaignManagement.Application.ProductCampaign
{
    public interface IProductCampaignService
    {
        Task<bool> IncreaseTime(int number);
    }
}
