using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.GetUploadViewStatus;

public record GetUploadViewStatusUseCaseRequest : IRequest<GetUploadViewStatusUseCaseResponse>;
