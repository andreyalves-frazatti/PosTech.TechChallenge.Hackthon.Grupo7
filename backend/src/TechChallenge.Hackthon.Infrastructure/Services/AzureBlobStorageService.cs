using Azure.Storage.Blobs;
using TechChallenge.Hackthon.Application.Services;

namespace TechChallenge.Hackthon.Infrastructure.Services
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly string _blobStorageConnectionString;
        private readonly string _uploadContainerName;
        private readonly string _downloadContainerName;

        public AzureBlobStorageService(string blobStorageConnectionString)
        {
            _blobStorageConnectionString = blobStorageConnectionString;
            _uploadContainerName = "uploads";
            _downloadContainerName = "downloads";
        }

        public async Task<Uri> UploadAsync(string filename, Stream stream, CancellationToken cancellationToken)
        {
            var blobServiceClient = new BlobServiceClient(_blobStorageConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_uploadContainerName);

            var blobClient = containerClient.GetBlobClient(filename);
            await blobClient.UploadAsync(stream, cancellationToken);
            return blobClient.Uri;
        }

        public async Task DownloadAsync(string filename, string folder, CancellationToken cancellationToken)
        {
            var blobServiceClient = new BlobServiceClient(_blobStorageConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_downloadContainerName);

            var blobClient = containerClient.GetBlobClient(filename);
            await blobClient.DownloadToAsync(folder, cancellationToken);
        }
    }
}
