using CampaignManagement.Domain.AggregateModels.ProductModels.RequestModel;
using CampaignManagement.Domain.AggregateModels.ProductModels.ResponseModel;
using CampaignManagement.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignManagement.Application.Product
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Domain.AggregateModels.ProductModels.Product> _productRepository;
        private readonly IRepository<Domain.AggregateModels.ProductCampaignModels.ProductCampaign> _productCampaignRepository;
        private readonly IRepository<Domain.AggregateModels.CampaignModels.Campaign> _campaignRepository;

        public ProductService(IRepository<Domain.AggregateModels.ProductModels.Product> productRepository,
            IRepository<Domain.AggregateModels.ProductCampaignModels.ProductCampaign> productCampaignRepository,
            IRepository<Domain.AggregateModels.CampaignModels.Campaign> campaignRepository)
        {
            _productRepository = productRepository;
            _productCampaignRepository = productCampaignRepository;
            _campaignRepository = campaignRepository;
        }

        public async Task<ProductCreateResponseModel> Create(ProductCreateRequestModel model)
        {
            if (!(await CheckProductCode(model.Code)))
            {
                var product = new Domain.AggregateModels.ProductModels.Product(model.Code, model.Price, model.Stock);
                await _productRepository.Create(product);

                await _productRepository.SaveChangesAsync();

                return new ProductCreateResponseModel
                {
                    Id = product.Id,
                    Code = product.Code,
                    Price = product.Price,
                    Stock = product.Stock
                };
            }
            else
            {
                throw new System.Exception("Product code is must be unic");
            }
        }

        public async Task<GetProductInfoResponseModel> GetProductInfo(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new System.Exception("Product code can not be empty");

            var campaingId = await _campaignRepository.GetAll().Where(x => x.ProdutCode == code).Select(x => x.Id).FirstOrDefaultAsync();
            var product = await _productRepository.GetAll().Where(p => p.Code == code).FirstOrDefaultAsync();

            if (product == null) throw new System.Exception("Not found product by this code");

            var productCampaign = await _productCampaignRepository.GetAll().Where(x => x.ProductId == product.Id).OrderByDescending(x => x.CreateDate).FirstOrDefaultAsync();
            if (productCampaign != null)
            {
                return new GetProductInfoResponseModel
                {
                    Id = productCampaign.ProductId,
                    Code = code,
                    Price = productCampaign.DiscountAfterPrice,
                    Stock = product.Stock
                };
            }
            else
            {
                return new GetProductInfoResponseModel
                {
                    Id = product.Id,
                    Code = product.Code,
                    Price = product.Price,
                    Stock = product.Stock
                };
            }
        }

        private async Task<bool> CheckProductCode(string code)
        {
            return await _productRepository.GetAll().AnyAsync(x => x.Code.ToLower().Equals(code.ToLower()));
        }
    }
}
