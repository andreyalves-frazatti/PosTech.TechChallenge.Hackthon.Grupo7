using MediatR;
using TechChallenge.Hackthon.Application.Gateways;
using TechChallenge.Hackthon.Application.Services;
using TechChallenge.Hackthon.Domain.Entities;

namespace TechChallenge.Hackthon.Application.UseCases.UploadVideo;

public class UploadVideoUseCase : IRequestHandler<UploadVideoUseCaseRequest, UploadVideoUseCaseResponse>
{
    private readonly IAzureBlobStorageService _azureBlobStorageService;
    private readonly IProcessVideoRequestGateway _processVideoRequestGateway;
    private readonly IProcessVideoRequestPublisherService _processVideoRequestPublisherService;

    public UploadVideoUseCase(
        IAzureBlobStorageService azureBlobStorageService,
        IProcessVideoRequestGateway processVideoRequestGateway,
        IProcessVideoRequestPublisherService processVideoRequestPublisherService)
    {
        _azureBlobStorageService = azureBlobStorageService;
        _processVideoRequestGateway = processVideoRequestGateway;
        _processVideoRequestPublisherService = processVideoRequestPublisherService;
    }

    public async Task<UploadVideoUseCaseResponse> Handle(UploadVideoUseCaseRequest request, CancellationToken cancellationToken)
    {
        var uri = await _azureBlobStorageService.UploadAsync(
            request.FileName,
            request.Stream,
            cancellationToken);

        var processVideoRequest = ProcessVideoRequest.Factory.New(
            request.Name,
            uri.ToString());

        await _processVideoRequestGateway
            .AddAsync(processVideoRequest, cancellationToken);

        await _processVideoRequestPublisherService
            .PublishAsync(processVideoRequest, cancellationToken);

        return new UploadVideoUseCaseResponse(processVideoRequest.Id);
    }
}
