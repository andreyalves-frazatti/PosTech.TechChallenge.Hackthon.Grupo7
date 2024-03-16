using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using TechChallenge.Hackthon.Application.Contracts;
using TechChallenge.Hackthon.Application.UseCases.ProcessVideo;

namespace TechChallenge.Hackthon.Infrastructure.Consumers;

public class ProcessVideoConsumer(ILogger<ProcessVideoConsumer> logger, IMediator mediator) : IConsumer<ProcessVideoContract>
{
    private readonly ILogger<ProcessVideoConsumer> _logger = logger;
    private readonly IMediator _mediator = mediator;

    public async Task Consume(ConsumeContext<ProcessVideoContract> context)
    {
        try
        {
            _logger.LogInformation("[{Class}] Consumed message: {@Message}", nameof(ProcessVideoConsumer), context.Message);

            ProcessVideoUseCaseRequest request = new(context.Message.ProcessVideoRequestId);
            await _mediator.Send(request);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "[{Class}] Fail to process message: {@Message}", nameof(ProcessVideoConsumer), context.Message);
        }
    }
}
