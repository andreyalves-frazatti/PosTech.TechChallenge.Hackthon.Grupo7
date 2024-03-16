using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.GetUploadVideoStatus;

public record FindUploadVideoStatusUseCaseRequest(Guid ProcessVideoRequestId) : IRequest<FindUploadVideoStatusUseCaseResponse>;