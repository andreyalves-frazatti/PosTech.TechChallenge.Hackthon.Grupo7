using MediatR;
using Microsoft.Extensions.Logging;
using TechChallenge.Hackthon.Application.Gateways;

namespace TechChallenge.Hackthon.Application.UseCases.GetUploadVideoStatus;

public class FindUploadVideoStatusUseCase
    (
        ILogger<FindUploadVideoStatusUseCase> logger,
        IProcessVideoRequestGateway processVideoRequestGateway
    )
    : IRequestHandler<FindUploadVideoStatusUseCaseRequest, FindUploadVideoStatusUseCaseResponse>
{
    private readonly ILogger<FindUploadVideoStatusUseCase> _logger = logger;
    private readonly IProcessVideoRequestGateway _processVideoRequestGateway = processVideoRequestGateway;

    public async Task<FindUploadVideoStatusUseCaseResponse> Handle(FindUploadVideoStatusUseCaseRequest request, CancellationToken cancellationToken)
    {
        var processVideoRequest = await _processVideoRequestGateway.GetByIdAsync(request.ProcessVideoRequestId, cancellationToken);

        if (processVideoRequest is null)
        {
            _logger.LogWarning("Request ID: {ProcessVideoRequestId} not found.", request.ProcessVideoRequestId);
            return new FindUploadVideoStatusUseCaseResponse();
        }

        return new FindUploadVideoStatusUseCaseResponse(processVideoRequest);
    }
}
