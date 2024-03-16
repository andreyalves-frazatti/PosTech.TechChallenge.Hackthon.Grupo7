namespace TechChallenge.Hackthon.Domain.Entities;

public class ProcessVideoRequest
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string BlobUrlVideo { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ProcessStatus Status { get; set; }

    public string? BlobUrlZipImages { get; set; }

    public static class Factory
    {
        public static ProcessVideoRequest New(string name, string blobUrlVideo)
        {
            var createTime = DateTime.Now;

            return new()
            {
                Id = Guid.NewGuid(),
                Name = name,
                BlobUrlVideo = blobUrlVideo,
                CreatedAt = createTime,
                UpdatedAt = createTime,
                Status = ProcessStatus.Waiting
            };
        }
    }
}
