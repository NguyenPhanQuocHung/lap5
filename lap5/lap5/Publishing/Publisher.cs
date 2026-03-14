using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace lap5.Publishing
{
    public class Publisher
    {
        private readonly IModel _channel;

        public Publisher(IModel channel)
        {
            _channel = channel;

            // Tạo Exchange nếu chưa có
            _channel.ExchangeDeclare(
                exchange: "ecommerce.topic",
                type: ExchangeType.Topic,
                durable: true
            );

            // Tạo Queue nếu chưa có
            _channel.QueueDeclare(
                queue: "order.queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            // Bind Queue với Exchange
            _channel.QueueBind(
                queue: "order.queue",
                exchange: "ecommerce.topic",
                routingKey: "order.created"
            );
        }

        public void Publish<T>(string exchange, string routingKey, T message)
        {
            var json = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(json);

            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            _channel.BasicPublish(
                exchange: exchange,
                routingKey: routingKey,
                basicProperties: properties,
                body: body
            );
        }
    }
}