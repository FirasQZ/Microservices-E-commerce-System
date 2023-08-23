using MassTransit.Transports;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Orders.Microservice.Configrations;
using Orders.Microservice.DataContext;
using Orders.Microservice.Entity.Models;
using RabbitMQ.Client;
using System.Text;

namespace Orders.Microservice.OrderRepository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ContextDatabase _dbContext;
        public OrderRepo(ContextDatabase dbContext)
        {
            _dbContext = dbContext;
        }



        /// <summary>
        /// this function add new order
        /// Make by Firas Quzaih 23-8-223
        /// </summary>
        /// <returns></returns>
        public async Task<Order> addOrderAsync(Order order)
        {
            var result = _dbContext.ORDER_ENTITYE.Add(order);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        /// <summary>
        /// this function return all order
        /// Make by Firas Quzaih 23-8-223
        /// </summary>
        /// <returns></returns>
        public Task<List<Order>> getOrders()
        {
            var result = _dbContext.ORDER_ENTITYE.ToListAsync();
            return result;
        }
        /// <summary>
        /// notify the product when add new order to reduce quantity using Rabbitmq
        /// Make by Firas Quzaih 23-8-223
        /// </summary>
        /// <returns></returns>
        public bool SendNotification(Order order)
        {

            var RabbitMQServer="";
            var RabbitMQUserName="";
            var RabbutMQPassword="";
        
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
            {
                 RabbitMQServer = StaticConfigurationManager.AppSetting["RabbitMQ:RabbitURL"];
                 RabbitMQUserName = StaticConfigurationManager.AppSetting["RabbitMQ:Username"];
                 RabbutMQPassword = StaticConfigurationManager.AppSetting["RabbitMQ:Password"];
            }
            else
            {
                 RabbitMQServer = StaticConfigurationManager.AppSetting["RabbitMQ:RabbitURL"];
                 RabbitMQUserName = StaticConfigurationManager.AppSetting["RabbitMQ:Username"];
                 RabbutMQPassword = StaticConfigurationManager.AppSetting["RabbitMQ:Password"];
            }
            try
            {
                var factory = new ConnectionFactory()
                { HostName = RabbitMQServer, UserName = RabbitMQUserName, Password = RabbutMQPassword };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    //Direct Exchange Details like name and type of exchange
                    channel.ExchangeDeclare(StaticConfigurationManager.AppSetting["RabbitMqSettings:ExchangeName"], StaticConfigurationManager.AppSetting["RabbitMqSettings:ExchhangeType"]);
                    //Declare Queue with Name and a few property related to Queue like durabality of msg, auto delete and many more
                    channel.QueueDeclare(queue: StaticConfigurationManager.AppSetting["RabbitMqSettings:QueueName"],
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
                    //Bind Queue with Exhange and routing details
                    channel.QueueBind(queue: StaticConfigurationManager.AppSetting["RabbitMqSettings:QueueName"], exchange: StaticConfigurationManager.AppSetting["RabbitMqSettings:ExchangeName"], routingKey: StaticConfigurationManager.AppSetting["RabbitMqSettings:RouteKey"]);
                    //Seriliaze object using Newtonsoft library
                    string productDetail = JsonConvert.SerializeObject(order);
                    var body = Encoding.UTF8.GetBytes(productDetail);
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    //publish msg
                    channel.BasicPublish(exchange: StaticConfigurationManager.AppSetting["RabbitMqSettings:ExchangeName"],
                                         routingKey: StaticConfigurationManager.AppSetting["RabbitMqSettings:RouteKey"],
                                         basicProperties: properties,
                                         body: body);
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

    }
}
