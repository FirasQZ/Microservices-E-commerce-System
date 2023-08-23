using MassTransit.Transports;
using Orders.Microservice.Entity.Models;
using Orders.Microservice.OrderRepository;

namespace Orders.Microservice.OrderSupervisor
{
    public class OrderSuperv : IOrderSupervisor
    {
        private readonly IOrderRepo _orderRepo;
        public OrderSuperv(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;

        }

        public async Task<Order> addOrder(Order order)
        {
            return await _orderRepo.addOrderAsync(order);
        }
        public Task<List<Order>> getOrders()
        {
            return _orderRepo.getOrders();
        }
        public bool SendNotification(Order order)
        {
            return _orderRepo.SendNotification(order);
        }

    }
}
