using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RabbitMq
{
    public class RabbitMq : IRabbitMq
    {

        private IConnection _connection;

        public RabbitMq(IConnection connection)
        {
            _connection = connection;
        }

        public void SendMessage(string exchange, string key, string message)
        {
            var model = _connection.CreateModel();
            model.BasicPublish(exchange, key, body: Encoding.UTF8.GetBytes(message));
            
        }
    }
}
