using CampaignManagement.Application.Order;
using CampaignManagement.Domain.AggregateModels.OrderModels.RequestModel;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CampaignManagement.UnitTest
{
    [TestFixture]
    public class OrderTest : TestBase
    {
        public IOrderService _orderService;

        [Test]
        public async Task OrderCreate()
        {
            var order = new OrderCreateRequestModel("P1", 3);
            _orderService = GetService<IOrderService>();
            var response = await _orderService.Create(order);

            Assert.AreNotEqual(response.Id, Guid.Empty);
        }
    }
}