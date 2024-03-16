using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.UploadVideo;

public record UploadVideoUseCaseRequest : IRequest<UploadVideoUseCaseResponse>
{
    public Guid UploadId { get; set; }

    public string Name { get; set; }

    public string Extension { get; set; }

    public Stream Stream { get; set; }

    public string FileName => $"{UploadId}_{Name}.{Extension}";
}
