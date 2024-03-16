using TechChallenge.Hackthon.Application.UseCases.UploadVideo;

namespace TechChallenge.Hackthon.API.Models;

public record PostUploadVideoModel
{
    public required IFormFile UploadedVideo { get; init; }

    public UploadVideoUseCaseRequest ToUseCaseRequest()
    {
        return new UploadVideoUseCaseRequest
        {
            Name = UploadedVideo.FileName,
            Stream = UploadedVideo.OpenReadStream()
        };
    }
}
