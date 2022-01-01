using CampaignManagement.Domain.AggregateModels.OrderModels.RequestModel;
using CampaignManagement.Domain.AggregateModels.OrderModels.ReslponseModel;
using CampaignManagement.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
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
            if (!string.IsNullOrEmpty(model.ProductCode))
            {
                var productId = await _productRepository.GetAll().Where(x => x.Code.ToLower().Equals(model.ProductCode.ToLower())).Select(x => x.Id).FirstOrDefaultAsync();
                var order = new Domain.AggregateModels.OrderModels.Order(productId, model.Quantity);
                await _orderRepository.Create(order);
                return new OrderCreateResponseModel { Id = order.Id, Quantity = model.Quantity, ProductCode = model.ProductCode };
            }

            return null;
        }
    }
}
