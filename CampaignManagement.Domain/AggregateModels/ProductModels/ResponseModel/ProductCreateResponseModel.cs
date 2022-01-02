using CampaignManagement.Domain.AggregateModels.ProductModels.RequestModel;
using System;

namespace CampaignManagement.Domain.AggregateModels.ProductModels.ResponseModel
{
    public class ProductCreateResponseModel : ProductCreateRequestModel
    {
        public Guid Id { get; set; }
    }
}
