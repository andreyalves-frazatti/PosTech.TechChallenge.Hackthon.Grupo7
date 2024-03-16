using MediatR;
using TechChallenge.Hackthon.Application.Gateways;
using TechChallenge.Hackthon.Application.Services;
using TechChallenge.Hackthon.Domain.Entities;

namespace TechChallenge.Hackthon.Application.UseCases.ProcessVideo;

public class ProcessVideoUseCase : IRequestHandler<ProcessVideoUseCaseRequest, ProcessVideoUseCaseResponse>
{
    private readonly IExtractImagesService _extractImagesService;
    private readonly IAzureBlobStorageService _azureBlobStorageService;
    private readonly IProcessVideoRequestGateway _processVideoRequestGateway;

    public ProcessVideoUseCase(
        IExtractImagesService extractImagesService,
        IAzureBlobStorageService azureBlobStorageService,
        IProcessVideoRequestGateway processVideoRequestGateway)
    {
        _extractImagesService = extractImagesService;
        _azureBlobStorageService = azureBlobStorageService;
        _processVideoRequestGateway = processVideoRequestGateway;
    }

    public async Task<ProcessVideoUseCaseResponse> Handle(ProcessVideoUseCaseRequest request, CancellationToken cancellationToken)
    {
        /** TODO
        * 1. Validação básica dos dados informados;
        * 2. Recebe um Id de processamento
        * 3. Aplica regra de processamento
        * 4. Salva o resultado no Blob
        * 5. Atualiza a entidade de dominio com o status e url
        * 6. Fim
        * */

        if (request.ProcessVideoRequestId == Guid.Empty)
        {
            throw new Exception();
        }

        var processVideoRequest = await _processVideoRequestGateway
            .GetByIdAsync(request.ProcessVideoRequestId, cancellationToken);

        var videoStream = await _azureBlobStorageService.DownloadStream(processVideoRequest.Name, cancellationToken);

        var zipImagesStream = _extractImagesService.GetImages(videoStream);

        var zipName = $"{processVideoRequest.Name}_images";

        var zipUrl = await _azureBlobStorageService.UploadAsync(zipName, zipImagesStream, cancellationToken);

        processVideoRequest.Status = ProcessStatus.Completed;
        processVideoRequest.BlobUrlZipImages = zipUrl.ToString();

        await _processVideoRequestGateway.UpdateAsync(processVideoRequest, cancellationToken);

        return new ProcessVideoUseCaseResponse();
    }
}
