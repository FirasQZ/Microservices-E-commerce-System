using MassTransit;
using Product.Microservice.Models;
using Shared.Models.Models;

namespace Product.Microservice.Consumers
{
    public class OrderProductConsumer : IConsumer<OrderProduct>
    {
        public async Task Consume(ConsumeContext<OrderProduct> context)
        {
            await Task.Run(() => { var obj = context.Message; });
        }
    }
}
