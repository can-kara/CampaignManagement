using System;

namespace CampaignManagement.Domain.AggregateModels.ProductModels.ResponseModel
{
    public class GetProductInfoResponseModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
