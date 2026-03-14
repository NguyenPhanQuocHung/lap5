using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
namespace lap5.Consuming
{
    public abstract class BaseConsumer<T>
    {
        private readonly IModel _channel;
        private readonly string _queueName;

        protected BaseConsumer(IModel channel, string queueName)
        {
            _channel = channel;
            _queueName = queueName;
        }

        public void StartConsuming()
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var data = JsonSerializer.Deserialize<T>(message);

                if (data != null)
                {
                    await HandleMessage(data);
                }

                _channel.BasicAck(args.DeliveryTag, false);
            };

            _channel.BasicConsume(
                queue: _queueName,
                autoAck: false,
                consumer: consumer
            );
        }

        protected abstract Task HandleMessage(T message);
    }
}