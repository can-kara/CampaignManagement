using CampaignManagement.Domain.AggregateModels.CampaignModels;
using CampaignManagement.Domain.AggregateModels.ProductModels;
using CampaignManagement.Domain.SeedWork;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampaignManagement.Domain.AggregateModels.ProductCampaignModels
{
    public class ProductCampaign : BaseEntity, IAggregateRoot
    {
        public Guid ProductId { get; private set; }

        [ForeignKey("ProductId")]
        public Product Product { get; private set; }
        public Guid CampaignId { get; set; }
        [ForeignKey("CampaignId")]
        public Campaign Campaign { get; private set; }
        public decimal Price { get; private set; }
        public decimal DiscountAfterPrice { get; private set; }
        public DateTime CreateDate { get; private set; }

        public ProductCampaign(Guid productId, Guid campaignId, decimal price, decimal discountAfterPrice)
        {
            ProductId = productId;
            CampaignId = campaignId;
            Price = price;
            DiscountAfterPrice = discountAfterPrice;
            CreateDate = DateTime.Now;
        }
    }
}
