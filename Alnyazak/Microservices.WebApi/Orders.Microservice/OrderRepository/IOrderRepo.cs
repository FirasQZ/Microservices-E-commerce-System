using Orders.Microservice.Entity.Models;

namespace Orders.Microservice.OrderRepository
{
    public interface IOrderRepo
    {
        public Task<Order> addOrderAsync(Order order);
        public Task<List<Order>> getOrders();
        public bool SendNotification(Order order);
    }
}
