namespace TechChallenge.Hackthon.Application.UseCases.UploadVideo;

public record UploadVideoUseCaseResponse
{
    public Guid Id { get; set; }

    public UploadVideoUseCaseResponse(Guid id)
    {
        Id = id;
    }
}
