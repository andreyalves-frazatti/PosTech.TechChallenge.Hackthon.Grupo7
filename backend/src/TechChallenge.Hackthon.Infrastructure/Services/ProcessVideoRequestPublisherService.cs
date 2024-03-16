using MassTransit;
using Microsoft.Extensions.Logging;
using TechChallenge.Hackthon.Application.Contracts;
using TechChallenge.Hackthon.Application.Services;
using TechChallenge.Hackthon.Domain.Entities;

namespace TechChallenge.Hackthon.Infrastructure.Services;

public class ProcessVideoRequestPublisherService : IProcessVideoRequestPublisherService
{
    private const string Exchange = "exchange:process-video";

    private readonly IBus _bus;
    private readonly ILogger<ProcessVideoRequestPublisherService> _logger;

    public ProcessVideoRequestPublisherService(IBus bus, ILogger<ProcessVideoRequestPublisherService> logger)
    {
        _bus = bus;
        _logger = logger;
    }

    public async Task PublishAsync(ProcessVideoRequest request, CancellationToken cancellationToken)
    {
        var endpoint = await _bus.GetSendEndpoint(new Uri(Exchange));

        ProcessVideoContract contract = new(request.Id);

        await endpoint.Send(contract, cancellationToken);

        _logger.LogInformation("Process ID: {ProcessId} published", request.Id);
    }
}
