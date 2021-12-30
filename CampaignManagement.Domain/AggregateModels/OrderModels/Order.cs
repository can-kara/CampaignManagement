using CampaignManagement.Domain.SeedWork;
using System;

namespace CampaignManagement.Domain.AggregateModels.OrderModels
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public Order(Guid productId, int quantity)
        {
            if (productId == Guid.Empty) { throw new ArgumentNullException(nameof(productId)); }
            if (quantity == 0) { throw new ArgumentNullException(nameof(quantity)); }

            ProductId = productId;
            Quantity = quantity;
        }
    }
}
