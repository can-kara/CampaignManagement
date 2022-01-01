using CampaignManagement.Domain.SeedWork;

namespace CampaignManagement.Application.Campaign
{
    public class CampaignService
    {
        private readonly IRepository<Domain.AggregateModels.CampaignModels.Campaign> _campaignRepository;

        public CampaignService(IRepository<Domain.AggregateModels.CampaignModels.Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
    }
}
