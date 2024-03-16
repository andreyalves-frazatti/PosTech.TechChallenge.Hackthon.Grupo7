using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.UploadVideo;

public record UploadVideoUseCaseRequest : IRequest<UploadVideoUseCaseResponse>
{
    public Guid UploadId { get; set; }
}
