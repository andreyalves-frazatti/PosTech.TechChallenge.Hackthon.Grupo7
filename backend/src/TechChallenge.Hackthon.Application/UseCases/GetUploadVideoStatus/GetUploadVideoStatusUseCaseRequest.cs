using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.GetUploadVideoStatus;

public record GetUploadVideoStatusUseCaseRequest : IRequest<GetUploadVideoStatusUseCaseResponse>
{
    public Guid UploadId { get; set; }
}
