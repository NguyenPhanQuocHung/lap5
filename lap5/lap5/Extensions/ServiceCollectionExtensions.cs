using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using lap5.Connection;

namespace lap5.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMq(
            this IServiceCollection services,
            string host,
            string user,
            string pass,
            string vhost)
        {
            var manager = new ConnectionManager(host, user, pass, vhost);

            var connection = manager.GetConnection();

            var channel = connection.CreateModel();

            services.AddSingleton(manager);
            services.AddSingleton(connection);
            services.AddSingleton(channel);

            return services;
        }
    }
}