using CampaignManagement.Domain.AggregateModels.CampaignModels.RequestModel;
using System;
using System.Collections.Generic;

namespace CampaignManagement.Domain.AggregateModels.CampaignModels.ResponseModel
{
    public class CampaignCreateResponseModel : CampaignCreateRequestModel
    {
        public Guid Id { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
