using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.ProcessVideo;

public record ProcessVideoUseCaseRequest : IRequest<ProcessVideoUseCaseResponse>
{
}
