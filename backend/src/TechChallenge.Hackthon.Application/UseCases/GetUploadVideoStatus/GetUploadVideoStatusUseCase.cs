using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.GetUploadVideoStatus;

public class GetUploadVideoStatusUseCase : IRequestHandler<GetUploadVideoStatusUseCaseRequest, GetUploadVideoStatusUseCaseResponse>
{
    public async Task<GetUploadVideoStatusUseCaseResponse> Handle(GetUploadVideoStatusUseCaseRequest request, CancellationToken cancellationToken)
    {
        /** TODO
         * 1. Validação básica dos dados informados;
         * 2. Pode receber lista ou nenhum;
         * 3. Acessar o Mongo e devolve a consulta
         * */

        return new GetUploadVideoStatusUseCaseResponse();
    }
}
