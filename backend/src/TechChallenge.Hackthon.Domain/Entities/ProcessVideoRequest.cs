namespace TechChallenge.Hackthon.Domain.Entities;

public class ProcessVideoRequest
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? BlobUrlVideo { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ProcessStatus Status { get; set; }

    public string Extension { get; set; } = "mp4";

    public string? BlobUrlZipImages { get; set; }

    public string FileName => $"{Id}_{Name}.{Extension}";

    public static class Factory
    {
        public static ProcessVideoRequest New(string name)
        {
            var createTime = DateTime.Now;

            return new()
            {
                Id = Guid.NewGuid(),
                Name = name,
                CreatedAt = createTime,
                UpdatedAt = createTime,
                Status = ProcessStatus.Waiting
            };
        }
    }
}
