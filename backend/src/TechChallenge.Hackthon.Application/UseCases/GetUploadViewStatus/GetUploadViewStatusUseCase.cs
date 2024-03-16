using MediatR;
using Microsoft.Extensions.Logging;
using TechChallenge.Hackthon.Application.Gateways;

namespace TechChallenge.Hackthon.Application.UseCases.GetUploadViewStatus;

public class GetUploadViewStatusUseCase
    (
        ILogger<GetUploadViewStatusUseCase> logger,
        IProcessVideoRequestGateway processVideoRequestGateway
    )
    : IRequestHandler<GetUploadViewStatusUseCaseRequest, GetUploadViewStatusUseCaseResponse>
{
    private readonly ILogger<GetUploadViewStatusUseCase> _logger = logger;
    private readonly IProcessVideoRequestGateway _processVideoRequestGateway = processVideoRequestGateway;

    public async Task<GetUploadViewStatusUseCaseResponse> Handle(GetUploadViewStatusUseCaseRequest request, CancellationToken cancellationToken)
    {
        var allRequests = await _processVideoRequestGateway.GetAllAsync(cancellationToken);
        return new GetUploadViewStatusUseCaseResponse(allRequests);
    }
}
