using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Microservice.Entity.ViewModels;
using Product.Microservice.ServiceSupervisor;
using System.Globalization;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductServiceController : ControllerBase
    {
        private readonly IProductServiceSupervisor _supervisor;
        public ProductServiceController(IProductServiceSupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsVM>> getProductById(int id)
        {

            var result = await _supervisor.GetProductByIdAsync(id);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }


        [HttpGet("getProducts")]
        public async Task<ActionResult<ProductDetailsVM>> getProducts()
        {

            var result = await _supervisor.GetProductsAsync();
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
