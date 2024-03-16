using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.ProcessVideo;

public class ProcessVideoUseCase : IRequestHandler<ProcessVideoUseCaseRequest, ProcessVideoUseCaseResponse>
{
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

        return new ProcessVideoUseCaseResponse();
    }
}
