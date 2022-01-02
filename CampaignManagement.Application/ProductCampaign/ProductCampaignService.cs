using CampaignManagement.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignManagement.Application.ProductCampaign
{
    public class ProductCampaignService : IProductCampaignService
    {
        private readonly IRepository<Domain.AggregateModels.ProductCampaignModels.ProductCampaign> _productCampaignRepository;
        private readonly IRepository<Domain.AggregateModels.ProductModels.Product> _productRepository;
        private readonly IRepository<Domain.AggregateModels.CampaignModels.Campaign> _campaignRepository;

        public ProductCampaignService(IRepository<Domain.AggregateModels.ProductCampaignModels.ProductCampaign> productCampaignRepository,
            IRepository<Domain.AggregateModels.ProductModels.Product> productRepository,
            IRepository<Domain.AggregateModels.CampaignModels.Campaign> campaignRepository)
        {
            _productCampaignRepository = productCampaignRepository;
            _productRepository = productRepository;
            _campaignRepository = campaignRepository;
        }

        public async Task<bool> IncreaseTime(int number)
        {
            try
            {
                var products = await _productRepository.GetAll().Select(x => new { x.Id, x.Price }).AsNoTracking().ToListAsync();
                var productIdList = products.Select(x => x.Id).ToList();
                var campaigns = await _campaignRepository.GetAll().Where(x => productIdList.Contains(x.ProductId)).Select(x => new
                {
                    x.Id,
                    x.ProductId,
                    x.Duraction,
                    x.PriceManipulationLimit
                }).AsNoTracking().ToListAsync();

                var productCampaigns = await _productCampaignRepository.GetAll().Where(x => productIdList.Contains(x.ProductId))
                                     .OrderByDescending(x => x.CreateDate).Select(x => new { x.ProductId, x.CampaignId, x.DiscountAfterPrice, x.Price }).AsNoTracking().ToListAsync();

                foreach (var item in products)
                {
                    var discount = 0;
                    decimal discountedPrice = 0;
                    var campaign = campaigns.Where(x => x.ProductId == item.Id).FirstOrDefault();
                    if (campaign != null)
                    {
                        var productCampaign = productCampaigns.Where(x => x.ProductId == item.Id && x.CampaignId == campaign.Id).FirstOrDefault();
                        if (productCampaign == null)
                        {
                            discount = campaign.Duraction * number;
                            discountedPrice = item.Price - discount;
                            var entity = new Domain.AggregateModels.ProductCampaignModels.ProductCampaign(item.Id, campaign.Id, item.Price, discountedPrice);
                            await _productCampaignRepository.Create(entity);
                        }
                        else
                        {
                            discount = campaign.Duraction * number;
                            discountedPrice = productCampaign.DiscountAfterPrice - discount;

                            if ((item.Price - campaign.PriceManipulationLimit) <= discountedPrice)
                            {
                                var entity = new Domain.AggregateModels.ProductCampaignModels.ProductCampaign(item.Id, campaign.Id, productCampaign.DiscountAfterPrice, discountedPrice);
                                await _productCampaignRepository.Create(entity);
                            }
                            else
                            {
                                //İndirim son aşamada ise hepsini clear ediyor. 
                                //Aslında burada daha iyi bi çözüm uygulanabilirdi. İlk aklıma gelen bu oldu.
                                //Zaman kalmadığı için bu şekilde bıraktım.
                                var productCampaignList = await _productCampaignRepository.GetAll().Where(x => x.ProductId == item.Id && x.CampaignId == campaign.Id).ToListAsync();
                                foreach (var deleteItem in productCampaignList)
                                {
                                    await _productCampaignRepository.Delete(deleteItem);
                                }
                            }
                        }
                    }
                }

                await _productCampaignRepository.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

              return false;
            }
        }
    }
}
