using CampaignManagement.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace CampaignManagement.Domain.AggregateModels.CampaignModels.RequestModel
{
    public class CampaignCreateRequestModel : ValueObject
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duraction { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
