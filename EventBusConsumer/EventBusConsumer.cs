using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EventBusConsumer
{
    public class EventBusConsumer : IHostedService
    {
        private readonly IConnection _connection;
        private readonly ILogger<EventBusConsumer> _logger;
        public EventBusConsumer(IConnection connection, ILogger<EventBusConsumer> logger)
        {
            _connection = connection;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var model = _connection.CreateModel();
            var consumer = new EventingBasicConsumer(model);

            consumer.Received += (s, e) =>
            {
                _logger.LogInformation(Encoding.UTF8.GetString(e.Body.ToArray()));
                model.BasicAck(e.DeliveryTag, false);
            };
            model.BasicConsume("TestQueue", false, consumer);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _connection.Close();
        }


    }
}
