using System;

namespace CampaignManagement.Domain.AggregateModels.CampaignModels.ResponseModel
{
    public class GetCampaignResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duraction { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}
