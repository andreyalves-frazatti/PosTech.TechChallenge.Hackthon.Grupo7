using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TechChallenge.Hackthon.Application.Gateways;
using TechChallenge.Hackthon.Application.Services;
using TechChallenge.Hackthon.Infrastructure.Consumers;
using TechChallenge.Hackthon.Infrastructure.Gateways;
using TechChallenge.Hackthon.Infrastructure.Services;

namespace TechChallenge.Hackthon.Infrastructure.Settings;

public static class DependencyInjections
{
    public static void AddGateways(this IServiceCollection services)
    {
        services.AddScoped<IProcessVideoRequestGateway, ProcessVideoRequestGateway>();
        services.AddScoped<IExtractImagesService, ExtractImagesService>();
    }

    public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDb");

        services.AddScoped<IMongoClient>(_ => new MongoClient(connectionString));
    }

    public static void AddConsumers(this IServiceCollection services, RabbitMqOptions rabbitMqOptions)
    {
        services.AddMassTransit(c =>
        {
            c.AddConsumer<ProcessVideoConsumer>();

            c.UsingRabbitMq((context, configure) =>
            {
                configure.Host(host: rabbitMqOptions.Host, virtualHost: rabbitMqOptions.VirtualHost, configure: o =>
                {
                    o.Username(rabbitMqOptions.Username);
                    o.Password(rabbitMqOptions.Password);
                });

                configure.ReceiveEndpoint(rabbitMqOptions.QueueName, e => { e.Consumer<ProcessVideoConsumer>(context); });
            });
        });
    }
}
