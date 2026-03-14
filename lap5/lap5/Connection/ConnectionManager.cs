using RabbitMQ.Client;

namespace lap5.Connection
{
   
        public class ConnectionManager
        {
            private readonly ConnectionFactory _factory;

            private IConnection? _connection;

            public ConnectionManager(string host, string user, string pass, string vhost)
            {
                _factory = new ConnectionFactory
                {
                    HostName = host,
                    UserName = user,
                    Password = pass,
                    VirtualHost = vhost,
                    DispatchConsumersAsync = true
                };
            }

            public IConnection GetConnection()
            {
                if (_connection == null || !_connection.IsOpen)
                {
                    _connection = _factory.CreateConnection();
                }

                return _connection;
            }
        }
    }