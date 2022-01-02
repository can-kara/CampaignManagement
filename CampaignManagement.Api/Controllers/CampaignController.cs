using CampaignManagement.Application.Campaign;
using CampaignManagement.Domain.AggregateModels.CampaignModels.RequestModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CampaignManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpPost]
        [Route("create_campaign")]
        public async Task<ActionResult> Create([FromBody] CampaignCreateRequestModel model)
        {
            try
            {
                var response = await _campaignService.Create(model);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("get_campaign_info")]
        public async Task<ActionResult> GetCampaignInfo([FromBody] string campaignName)
        {
            try
            {
                var response = await _campaignService.GetCampaignInfo(campaignName);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
