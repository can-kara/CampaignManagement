using CampaignManagement.Application.Order;
using CampaignManagement.Domain.AggregateModels.OrderModels.RequestModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CampaignManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController (IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("create_order")]
        public async Task<ActionResult> Create([FromBody] OrderCreateRequestModel model)
        {
            try
            {
                var response =await _orderService.Create(model);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);                
            }
        }
    }
}
