using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.DownloadVideo;

public record DownloadVideoUseCaseRequest : IRequest<DownloadVideoUseCaseResponse>
{
    public Guid UploadId { get; set; }
}
