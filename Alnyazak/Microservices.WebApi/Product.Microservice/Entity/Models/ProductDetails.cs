using Product.Microservice.Entity;

namespace Product.Microservice.Models
{
    public class ProductDetails :BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
