using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConnection>(options =>
    {
        var connection = new ConnectionFactory()
        {
            HostName = "localhost"
        };
        return connection.CreateConnection();
    });

builder.Services.AddHostedService<EventBusConsumer.EventBusConsumer>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
