using CampaignManagement.Domain.AggregateModels.CampaignModels.RequestModel;
using CampaignManagement.Domain.AggregateModels.CampaignModels.ResponseModel;
using System.Threading.Tasks;

namespace CampaignManagement.Application.Campaign
{
    public interface ICampaignService
    {
        Task<CampaignCreateResponseModel> Create(CampaignCreateRequestModel model);
        Task<GetCampaignResponseModel> GetCampaignInfo(string campaignName);
    }
}
