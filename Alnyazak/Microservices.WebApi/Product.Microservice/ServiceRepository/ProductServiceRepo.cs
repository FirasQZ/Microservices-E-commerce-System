using Microsoft.EntityFrameworkCore;
using Product.Microservice.Data;
using Product.Microservice.Models;

namespace Product.Microservice.ServiceRepository
{
    public class ProductServiceRepo : IProductServicesRepo
    {
        private readonly DatabaseContext _dbContext;
        public ProductServiceRepo(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductDetails> GetProductByIdAsync(int productId)
        {
            return await _dbContext.PRODUCT_DETAILS_ENTITY.Where(x => x.id == productId).FirstOrDefaultAsync();
        }

        public async Task<List<ProductDetails>> GetProductsAsync()
        {
            return await _dbContext.PRODUCT_DETAILS_ENTITY.ToListAsync();
        }
    }
}
