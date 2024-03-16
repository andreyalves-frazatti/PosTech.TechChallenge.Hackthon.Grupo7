using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.UploadVideo;

public class UploadVideoUseCase : IRequestHandler<UploadVideoUseCaseRequest, UploadVideoUseCaseResponse>
{
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

        return new UploadVideoUseCaseResponse();
    }
}
