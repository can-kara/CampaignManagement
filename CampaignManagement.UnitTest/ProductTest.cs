using CampaignManagement.Application.Product;
using CampaignManagement.Domain.AggregateModels.ProductModels.RequestModel;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampaignManagement.UnitTest
{
    [TestFixture]
    public class ProductTest : TestBase
    {
        public IProductService _productService;

        [Test]
        public async Task Create_Product()
        {
            var product = new ProductCreateRequestModel
            {
                Code = "P1",
                Price = 100,
                Stock = 1000
            };
            _productService = GetService<IProductService>();
            var response = await _productService.Create(product);

            Assert.IsNotNull(response);
            Assert.AreNotEqual(response.Id, Guid.Empty);
        }

        [Test]
        public async Task Get_Product_Info()
        {
            _productService = GetService<IProductService>();
            var response = await _productService.GetProductInfo("P1");
            Assert.IsNotNull(response);
        }
    }
}