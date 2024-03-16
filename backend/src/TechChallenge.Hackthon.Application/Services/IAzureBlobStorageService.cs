namespace TechChallenge.Hackthon.Application.Services
{
    public interface IAzureBlobStorageService
    {
        Task<Uri> UploadAsync(string filename, Stream stream, CancellationToken cancellationToken);

        Task<Uri> DownloadAsync(string filename, string folder, CancellationToken cancellationToken);

        Task<Stream> DownloadStream(string filename, CancellationToken cancellationToken);
    }
}
