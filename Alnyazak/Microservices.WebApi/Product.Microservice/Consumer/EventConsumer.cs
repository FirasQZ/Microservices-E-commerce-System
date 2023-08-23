using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace Product.Microservice.Consumer
{
    public class EventConsumer
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;

        public EventConsumer(IConfiguration config)
        {
            var factory = new ConnectionFactory
            {
                HostName = config["RabbitMQ:RabbitURL"],
                UserName = config["RabbitMQ:Username"],
                Password = config["RabbitMQ:Password"]
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _queueName = config["RabbitMQ:QueueName"];
        }

        public void StartListening(Action<string> eventHandler)
        {
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                eventHandler(message);
            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
        }
        public void StopListening()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
