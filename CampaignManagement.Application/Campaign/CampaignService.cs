using CampaignManagement.Domain.AggregateModels.CampaignModels.RequestModel;
using CampaignManagement.Domain.AggregateModels.CampaignModels.ResponseModel;
using CampaignManagement.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignManagement.Application.Campaign
{
    public class CampaignService : ICampaignService
    {
        private readonly IRepository<Domain.AggregateModels.CampaignModels.Campaign> _campaignRepository;
        private readonly IRepository<Domain.AggregateModels.ProductModels.Product> _productRepository;

        public CampaignService(IRepository<Domain.AggregateModels.CampaignModels.Campaign> campaignRepository,
            IRepository<Domain.AggregateModels.ProductModels.Product> productRepository)
        {
            _campaignRepository = campaignRepository;
            _productRepository = productRepository;
        }


        public async Task<CampaignCreateResponseModel> Create(CampaignCreateRequestModel model)
        {
            if (string.IsNullOrEmpty(model.ProductCode)) throw new ArgumentNullException(nameof(model.ProductCode));
            Guid productId = await GetProductIdByCode(model.ProductCode);

            var campaign = new Domain.AggregateModels.CampaignModels.Campaign(model.Name, productId, model.ProductCode, model.Duraction, model.PriceManipulationLimit, model.TargetSalesCount);
            await _campaignRepository.Create(campaign);
            await _campaignRepository.SaveChangesAsync();
            return new CampaignCreateResponseModel
            {
                Id = campaign.Id,
                ProductCode = model.ProductCode,
                Duraction = model.Duraction,
                Name = model.Name,
                PriceManipulationLimit = model.PriceManipulationLimit,
                TargetSalesCount = model.TargetSalesCount
            };
        }

        public async Task<GetCampaignResponseModel> GetCampaignInfo(string campaignName)
        {
            if (string.IsNullOrEmpty(campaignName)) throw new ArgumentNullException(nameof(campaignName));

            var campaign = await _campaignRepository.GetAll().Where(x => x.Name.Equals(campaignName)).Select(x => new GetCampaignResponseModel
            {
                Name = x.Name,
                Duraction = x.Duraction,
                Id = x.Id,
                PriceManipulationLimit = x.PriceManipulationLimit,
                ProductCode = x.ProdutCode,
                TargetSalesCount = x.TargetSalesCount
            }).FirstOrDefaultAsync();

            return campaign;
        }

        private async Task<Guid> GetProductIdByCode(string code)
        {
            return await _productRepository.GetAll().Where(x => x.Code.ToLower().Equals(code.ToLower())).Select(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
