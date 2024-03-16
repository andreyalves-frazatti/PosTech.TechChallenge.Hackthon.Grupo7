using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.ProcessVideo;

public record ProcessVideoUseCaseRequest(Guid ProcessVideoRequestId)
    : IRequest<ProcessVideoUseCaseResponse>;
