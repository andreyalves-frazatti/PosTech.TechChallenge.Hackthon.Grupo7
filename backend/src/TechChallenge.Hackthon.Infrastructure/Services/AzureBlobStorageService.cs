using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using TechChallenge.Hackthon.Application.Services;

namespace TechChallenge.Hackthon.Infrastructure.Services
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly string _blobStorageConnectionString;
        private readonly string _uploadContainerName;

        public AzureBlobStorageService(string blobStorageConnectionString)
        {
            _blobStorageConnectionString = blobStorageConnectionString;
            _uploadContainerName = "uploads";
        }

        public async Task<Uri> UploadAsync(string filename, Stream stream, CancellationToken cancellationToken)
        {
            var blobServiceClient = new BlobServiceClient(_blobStorageConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_uploadContainerName);

            var blobClient = containerClient.GetBlobClient(filename);
            await blobClient.UploadAsync(stream, cancellationToken);
            return blobClient.Uri;
        }

        public async Task<Uri> DownloadAsync(string filename, string folder, CancellationToken cancellationToken)
        {
            var blobServiceClient = new BlobServiceClient(_blobStorageConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_uploadContainerName);

            var blobClient = containerClient.GetBlobClient(filename);
            var filePath = Path.Combine(folder, filename);
            await blobClient.DownloadToAsync(filePath, cancellationToken);

            return new Uri(filePath);
        }

        public async Task<Stream> DownloadStream(string filename, CancellationToken cancellationToken)
        {
            var blobServiceClient = new BlobServiceClient(_blobStorageConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_uploadContainerName);

            var blobClient = containerClient.GetBlobClient(filename);
            var stream = await blobClient.DownloadStreamingAsync(new BlobDownloadOptions(), cancellationToken);

            return stream.Value.Content;
        }
    }
}
