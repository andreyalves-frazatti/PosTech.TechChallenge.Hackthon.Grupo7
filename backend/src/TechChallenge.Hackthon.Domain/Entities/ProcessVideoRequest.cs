namespace TechChallenge.Hackthon.Domain.Entities;

public class ProcessVideoRequest
{
    public Guid Id { get; set; }

    public required string BlobUrlVideo { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ProcessStatus Status { get; set; }

    public string? BlobUrlZipImages { get; set; }
}
