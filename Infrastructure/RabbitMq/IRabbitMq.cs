namespace Infrastructure.RabbitMq
{
    public interface IRabbitMq
    {
        void SendMessage(string exchange, string key, string message);

    }
}
