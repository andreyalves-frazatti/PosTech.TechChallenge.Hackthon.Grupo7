namespace TechChallenge.Hackthon.Application.Services
{
    public interface IAzureBlobStorageService
    {
        Task<Uri> UploadAsync(string filename, Stream stream, CancellationToken cancellationToken);

        Task DownloadAsync(string filename, string folder, CancellationToken cancellationToken);
    }
}
