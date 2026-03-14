namespace lap5.Options
{
    public class RabbitMqOptions
    {
        public string HostName { get; set; } = "localhost";

        public int Port { get; set; } = 5672;

        public string UserName { get; set; } = "guest";

        public string Password { get; set; } = "guest";

        public string VirtualHost { get; set; } = "/";

        public string ExchangeName { get; set; } = "ecommerce.topic";

        public string OrderQueue { get; set; } = "order.queue";
    }
}
