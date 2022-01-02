using CampaignManagement.Domain.AggregateModels.OrderModels.RequestModel;
using System;

namespace CampaignManagement.Domain.AggregateModels.OrderModels.ReslponseModel
{
    public class OrderCreateResponseModel : OrderCreateRequestModel
    {
        public Guid Id { get; set; }
    }
}
