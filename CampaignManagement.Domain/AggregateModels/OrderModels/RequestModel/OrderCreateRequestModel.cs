using CampaignManagement.Domain.SeedWork;
using System.Collections.Generic;

namespace CampaignManagement.Domain.AggregateModels.OrderModels.RequestModel
{
    public class OrderCreateRequestModel : ValueObject
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }

        public OrderCreateRequestModel() { }

        public OrderCreateRequestModel(string productCode, int quantity)
        {
            ProductCode = productCode;
            Quantity = quantity;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ProductCode;
            yield return Quantity;
        }
    }
}
