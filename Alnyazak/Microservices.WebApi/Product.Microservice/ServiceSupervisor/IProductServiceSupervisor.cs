using Product.Microservice.Entity.ViewModels;
using Product.Microservice.Models;

namespace Product.Microservice.ServiceSupervisor
{
    public interface IProductServiceSupervisor
    {
        public Task<ProductDetailsVM> GetProductByIdAsync(int productId);
        public Task<List<ProductDetailsVM>> GetProductsAsync();


    }
}
