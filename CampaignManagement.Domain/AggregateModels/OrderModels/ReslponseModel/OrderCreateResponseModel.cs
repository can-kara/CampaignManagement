using System;

namespace CampaignManagement.Domain.AggregateModels.OrderModels.ReslponseModel
{
    public class OrderCreateResponseModel
    {
        public Guid Id { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
