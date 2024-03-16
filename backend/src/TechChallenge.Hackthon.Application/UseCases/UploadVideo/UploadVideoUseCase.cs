using MediatR;
using TechChallenge.Hackthon.Application.Services;
using TechChallenge.Hackthon.Domain.Entities;

namespace TechChallenge.Hackthon.Application.UseCases.UploadVideo;

public class UploadVideoUseCase : IRequestHandler<UploadVideoUseCaseRequest, UploadVideoUseCaseResponse>
{
    private readonly IAzureBlobStorageService _azureBlobStorageService;

    public UploadVideoUseCase(IAzureBlobStorageService azureBlobStorageService)
    {
        _azureBlobStorageService = azureBlobStorageService;
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

        if (request.UploadId == Guid.Empty)
        {
            throw new Exception();
        }

        var uri = await _azureBlobStorageService.UploadAsync(
            request.FileName,
            request.Stream,
            cancellationToken);

        var processVideoRequest = ProcessVideoRequest.Factory.New(
            request.Name,
            uri.ToString());



        return new UploadVideoUseCaseResponse();
    }
}
