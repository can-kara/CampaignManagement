using CampaignManagement.Application.Product;
using CampaignManagement.Domain.AggregateModels.ProductModels.RequestModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CampaignManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("create_product")]
        public async Task<ActionResult> Create([FromBody] ProductCreateRequestModel model)
        {
            try
            {
                var response = await _productService.Create(model);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("get_product_info")]
        public async Task<ActionResult> GetProductInfo([FromBody] string productCode)
        {
            try
            {
                var response = await _productService.GetProductInfo(productCode);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
