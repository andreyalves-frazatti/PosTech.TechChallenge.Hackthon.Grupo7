using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.DownloadVideo;

public class DownloadVideoUseCase : IRequestHandler<DownloadVideoUseCaseRequest, DownloadVideoUseCaseResponse>
{
    public async Task<DownloadVideoUseCaseResponse> Handle(DownloadVideoUseCaseRequest request, CancellationToken cancellationToken)
    {
        /** TODO
        * 1. Validação básica dos dados informados;
        * 2. Recebe um Id de processamento
        * 3. Apenas itens já processados com a propriedade do Blob preenchida
        * 4. Retorn os dados da Url
        * */

        return new DownloadVideoUseCaseResponse();
    }
}
