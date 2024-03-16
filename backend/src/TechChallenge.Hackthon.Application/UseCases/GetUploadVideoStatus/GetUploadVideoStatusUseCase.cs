using MediatR;
using Microsoft.Extensions.Logging;
using TechChallenge.Hackthon.Application.Gateways;

namespace TechChallenge.Hackthon.Application.UseCases.GetUploadVideoStatus;

public class GetUploadVideoStatusUseCase : IRequestHandler<GetUploadVideoStatusUseCaseRequest, GetUploadVideoStatusUseCaseResponse>
{
    private readonly ILogger<GetUploadVideoStatusUseCase> _logger;
    private readonly IProcessVideoRequestGateway _processVideoRequestGateway;

    public GetUploadVideoStatusUseCase(ILogger<GetUploadVideoStatusUseCase> logger, IProcessVideoRequestGateway processVideoRequestGateway)
    {
        _logger = logger;
        _processVideoRequestGateway = processVideoRequestGateway;
    }

    public async Task<GetUploadVideoStatusUseCaseResponse> Handle(GetUploadVideoStatusUseCaseRequest request, CancellationToken cancellationToken)
    {
        if (request.ProcessVideoRequestIds is null || !request.ProcessVideoRequestIds.Any())
        {
            var allRequests = await _processVideoRequestGateway
                .GetAllAsync(cancellationToken);

            return new GetUploadVideoStatusUseCaseResponse(allRequests);
        }

        var requestItemsTasks = request
            .ProcessVideoRequestIds
            .Select(async id => await _processVideoRequestGateway.GetByIdAsync(id, cancellationToken));

        var requests = await Task.WhenAll(requestItemsTasks);

        return new GetUploadVideoStatusUseCaseResponse(requests.ToList());
    }
}
