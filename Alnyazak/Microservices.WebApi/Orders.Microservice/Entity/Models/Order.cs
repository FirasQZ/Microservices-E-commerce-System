namespace Orders.Microservice.Entity.Models
{
    public class Order:BaseEntity
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int Paid { get; set; }
        public string CustomerName { set; get; }
    }
}
