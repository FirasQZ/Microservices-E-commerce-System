using Orders.Microservice.Entity.Models;

namespace Orders.Microservice.OrderSupervisor
{
    public interface IOrderSupervisor
    {
        public Task<List<Order>> getOrders();
        public Task<Order> addOrder(Order order);
        public bool SendNotification(Order order);
    }
}
