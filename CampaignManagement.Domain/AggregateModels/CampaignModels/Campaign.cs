using CampaignManagement.Domain.AggregateModels.ProductModels;
using CampaignManagement.Domain.SeedWork;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManagement.Domain.AggregateModels.CampaignModels
{
    public class Campaign : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Guid ProductId { get; private set; }

        [ForeignKey("ProductId")]
        private Product Product { get; set; }
        public string ProdutCode { get; private set; }
        public int Duraction { get; private set; }
        public int PriceManipulationLimit { get; private set; }
        public int TargetSalesCount { get; private set; }

        public Campaign(string name, Guid productId, string produtCode, int duraction, int priceManipulationLimit, int targetSalesCount)
        {
            if (productId == Guid.Empty) throw new ArgumentNullException(nameof(productId));

            Name = name;
            ProductId = productId;
            //Product = product;
            ProdutCode = produtCode;
            Duraction = duraction;
            PriceManipulationLimit = priceManipulationLimit;
            TargetSalesCount = targetSalesCount;
        }
    }
}
