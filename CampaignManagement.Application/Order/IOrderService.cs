using CampaignManagement.Domain.AggregateModels.OrderModels.RequestModel;
using CampaignManagement.Domain.AggregateModels.OrderModels.ReslponseModel;
using System.Threading.Tasks;

namespace CampaignManagement.Application.Order
{
    public interface IOrderService
    {
        Task<OrderCreateResponseModel> Create(OrderCreateRequestModel model);
    }
}
