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
        /** TODO
         * 1. Validação básica dos dados informados;
         * 2. Gerar o ID
         * 3. Fazer Upload para o Azure Blob
         * 4. Salvar o dados no Mongo
         * 5. Publica no Rabbit Mq
         * 6. Retornar o ID gerado para consulta 
         * */

        //var uri = await _azureBlobStorageService.UploadAsync(
        //    request.FileName,
        //    request.Stream,
        //    cancellationToken);

        var uri = "";

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
