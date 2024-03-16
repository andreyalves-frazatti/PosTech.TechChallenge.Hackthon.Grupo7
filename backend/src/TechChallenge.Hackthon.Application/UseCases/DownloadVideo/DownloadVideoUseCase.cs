using MediatR;
using TechChallenge.Hackthon.Application.Gateways;
using TechChallenge.Hackthon.Application.Services;
using TechChallenge.Hackthon.Domain.Entities;

namespace TechChallenge.Hackthon.Application.UseCases.DownloadVideo;

public class DownloadVideoUseCase : IRequestHandler<DownloadVideoUseCaseRequest, DownloadVideoUseCaseResponse>
{
    private readonly IProcessVideoRequestGateway _processVideoRequestGateway;
    private readonly IAzureBlobStorageService _azureBlobStorageService;

    public DownloadVideoUseCase(
        IProcessVideoRequestGateway processVideoRequestGateway,
        IAzureBlobStorageService azureBlobStorageService)
    {
        _processVideoRequestGateway = processVideoRequestGateway;
        _azureBlobStorageService = azureBlobStorageService;
    }

    public async Task<DownloadVideoUseCaseResponse> Handle(DownloadVideoUseCaseRequest request, CancellationToken cancellationToken)
    {
        /** TODO
        * 1. Validação básica dos dados informados;
        * 2. Recebe um Id de processamento
        * 3. Apenas itens já processados com a propriedade do Blob preenchida
        * 4. Retorn os dados da Url
        * */

        if (request.UploadId == Guid.Empty)
        {
            throw new Exception();
        }

        var processVideoRequest = await _processVideoRequestGateway.GetByIdAsync(request.UploadId, cancellationToken);

        if (processVideoRequest.Status != ProcessStatus.Completed)
        {
        }

        await _azureBlobStorageService.DownloadAsync(processVideoRequest.Name, request.FolderName, cancellationToken);

        return new DownloadVideoUseCaseResponse();
    }
}
