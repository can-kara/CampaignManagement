using CampaignManagement.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignManagement.Domain.AggregateModels.ProductModels.RequestModel
{
    public class ProductCreateRequestModel : ValueObject
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
