using AutoMapper;
using Product.Microservice.Entity.ViewModels;
using Product.Microservice.ServiceRepository;
using System.Globalization;
using System.IO.Pipelines;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Product.Microservice.ServiceSupervisor
{
    public class ProductServiceSupervisor : IProductServiceSupervisor
    {
        private readonly IProductServicesRepo _productServicesRepo;
        private readonly IMapper _mapper;

        public ProductServiceSupervisor(IMapper mapper,IProductServicesRepo productServicesRepo)
        {
            _productServicesRepo = productServicesRepo;
            _mapper = mapper;

        }
        public async Task<ProductDetailsVM> GetProductByIdAsync(int productId)
        {
                var product = await _productServicesRepo.GetProductByIdAsync(productId);
                return _mapper.Map<ProductDetailsVM>(product) ?? null;
        }

        public async Task<List<ProductDetailsVM>> GetProductsAsync()
        {
            var product = await _productServicesRepo.GetProductsAsync();
            var data = _mapper.Map<List<ProductDetailsVM>>(product);
            return data;
        }
    }
}
