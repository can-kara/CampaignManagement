using CampaignManagement.Domain.AggregateModels.ProductModels;
using CampaignManagement.Domain.SeedWork;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManagement.Domain.AggregateModels.CampaignModels
{
    public class Campaign : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; private set; }
        public int Duraction { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }

        public Campaign(string name, Guid productId, int duraction, int priceManipulationLimit, int targetSalesCount)
        {
            if(productId==Guid.Empty) throw new ArgumentNullException(nameof(productId));

            Name = name;
            ProductId = productId;
            Duraction = duraction;
            PriceManipulationLimit = priceManipulationLimit;
            TargetSalesCount = targetSalesCount;
        }
    }
}
