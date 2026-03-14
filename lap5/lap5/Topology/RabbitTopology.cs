using RabbitMQ.Client;

namespace lap5.Topology
{
    public static class RabbitTopology
    {
        public static void Configure(IModel channel)
        {
            channel.ExchangeDeclare(
                exchange: "ecommerce.topic",
                type: ExchangeType.Topic,
                durable: true
            );

            channel.QueueDeclare(
                queue: "order.queue",
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            channel.QueueBind(
                queue: "order.queue",
                exchange: "ecommerce.topic",
                routingKey: "order.placed"
            );
        }
    }
}