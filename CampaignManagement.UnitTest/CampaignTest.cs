using CampaignManagement.Application.Campaign;
using CampaignManagement.Application.ProductCampaign;
using CampaignManagement.Domain.AggregateModels.CampaignModels.RequestModel;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CampaignManagement.UnitTest
{
    [TestFixture]
    public class CampaignTest : TestBase
    {
        public ICampaignService _campaignService;
        public IProductCampaignService _productCampaignService;

        [Test]
        public async Task Create_Campaign()
        {
            var campaign = new CampaignCreateRequestModel
            {
                Name = "C1",
                ProductCode = "P1",
                Duraction = 5,
                PriceManipulationLimit = 20,
                TargetSalesCount = 100
            };

            _campaignService = GetService<ICampaignService>();
            var response = await _campaignService.Create(campaign);

            Assert.IsNotNull(response);
            Assert.AreNotEqual(response.Id, Guid.Empty);
        }

        [Test]
        public async Task Get_Campaign_Info()
        {
            _campaignService = GetService<ICampaignService>();
            var response = await _campaignService.GetCampaignInfo("C1");

            Assert.IsNotNull(response);
            Assert.AreNotEqual(response.Id, Guid.Empty);
        }

        [Test]
        public async Task Increase_Time()
        {
            int number = 1;
            _productCampaignService = GetService<IProductCampaignService>();
            var response = await _productCampaignService.IncreaseTime(number);

            Assert.IsTrue(response);
        }
    }
}