using Azure.Storage.Blobs;

namespace PersonalCollection.Application.Services
{
    public class ImageStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public ImageStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task UploadAsync(string fileName, Stream stream)
        {
            try
            {
                var blobClient = GetBlobClient(fileName);
                await blobClient.UploadAsync(stream, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task<byte[]> DownloadAsync(string fileName)
        {
            var blobClient = GetBlobClient(fileName);
            var downloadResult = await blobClient.DownloadContentAsync();
            var blobContents = downloadResult.Value.Content.ToArray();
            return blobContents;
        }

        public async Task DeleteAsync(string fileName)
        {
            var blobClient = GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        private BlobClient GetBlobClient(string fileName) 
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("images");
            var blobClient = containerClient.GetBlobClient(fileName);
            return blobClient;
        }
    }
}
