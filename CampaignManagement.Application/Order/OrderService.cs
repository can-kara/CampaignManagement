using CampaignManagement.Domain.AggregateModels.OrderModels.RequestModel;
using CampaignManagement.Domain.AggregateModels.OrderModels.ReslponseModel;
using CampaignManagement.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignManagement.Application.Order
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Domain.AggregateModels.OrderModels.Order> _orderRepository;
        private readonly IRepository<Domain.AggregateModels.ProductModels.Product> _productRepository;

        public OrderService(IRepository<Domain.AggregateModels.OrderModels.Order> orderRepository,
            IRepository<Domain.AggregateModels.ProductModels.Product> productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderCreateResponseModel> Create(OrderCreateRequestModel model)
        {
            if (string.IsNullOrEmpty(model.ProductCode)) throw new ArgumentNullException(nameof(model.ProductCode));

            Guid productId = await GetProductIdByCode(model.ProductCode);

            if (productId == Guid.Empty) throw new Exception("No records found by product code");

            var order = new Domain.AggregateModels.OrderModels.Order(productId, model.ProductCode, model.Quantity);
            await _orderRepository.Create(order);
            await _orderRepository.SaveChangesAsync();

            return new OrderCreateResponseModel { Id = order.Id, Quantity = model.Quantity, ProductCode = model.ProductCode };
        }

        private async Task<Guid> GetProductIdByCode(string productCode)
        {
            return await _productRepository.GetAll().Where(x => x.Code.ToLower().Equals(productCode.ToLower())).Select(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
