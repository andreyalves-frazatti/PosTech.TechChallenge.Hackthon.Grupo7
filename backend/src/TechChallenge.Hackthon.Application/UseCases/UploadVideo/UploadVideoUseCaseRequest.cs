using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.UploadVideo;

public record UploadVideoUseCaseRequest : IRequest<UploadVideoUseCaseResponse>
{
    public Guid UploadId { get; set; }

    public required string Name { get; set; }

    public required string Extension { get; set; }
 
    public required Stream Stream { get; init; }

    public string FileName => $"{UploadId}_{Name}.{Extension}";
}
