using MediatR;

namespace TechChallenge.Hackthon.Application.UseCases.UploadVideo;

public record UploadVideoUseCaseRequest : IRequest<UploadVideoUseCaseResponse>
{
    public required string Name { get; set; }
    public required Stream Stream { get; set; }
}
