using CampaignManagement.Domain.AggregateModels.ProductModels.RequestModel;
using CampaignManagement.Domain.AggregateModels.ProductModels.ResponseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignManagement.Application.Product
{
    public interface IProductService
    {
        Task<ProductCreateResponseModel> Create(ProductCreateRequestModel model);
        Task<GetProductInfoResponseModel> GetProductInfo(string code);
    }
}
