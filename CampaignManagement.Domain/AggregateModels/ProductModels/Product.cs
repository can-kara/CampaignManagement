using CampaignManagement.Domain.SeedWork;
using System;

namespace CampaignManagement.Domain.AggregateModels.ProductModels
{
    public class Product : BaseEntity, IAggregateRoot
    {
        public string Code { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public Product(string code, decimal price, int stock)
        {
            if (stock == 0) throw new Exception("Stock can not me 0");

            Code = code;
            Price = price;
            Stock = stock;
        }
    }
}
