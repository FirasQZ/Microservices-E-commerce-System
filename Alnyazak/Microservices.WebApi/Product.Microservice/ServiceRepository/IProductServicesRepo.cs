using Product.Microservice.Models;

namespace Product.Microservice.ServiceRepository
{
    public interface IProductServicesRepo
    {
        public Task<ProductDetails> GetProductByIdAsync(int productId);
        public Task<List<ProductDetails>> GetProductsAsync();
    }
}
