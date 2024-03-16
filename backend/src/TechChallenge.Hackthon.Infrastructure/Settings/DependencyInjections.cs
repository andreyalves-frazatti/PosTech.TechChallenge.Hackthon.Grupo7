using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Hackthon.Infrastructure.Consumers;

namespace TechChallenge.Hackthon.Infrastructure.Settings;

public static class DependencyInjections
{
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
