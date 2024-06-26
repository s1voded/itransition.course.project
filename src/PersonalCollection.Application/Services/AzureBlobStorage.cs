﻿using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using PersonalCollection.Application.Interfaces.Services;
using PersonalCollection.Application.Models.Config;

namespace PersonalCollection.Application.Services
{
    public class AzureBlobStorage: IImageStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IOptions<AzureBlobConfig> _azureBlobConfig;

        public AzureBlobStorage(BlobServiceClient blobServiceClient, IOptions<AzureBlobConfig> azureBlobConfig)
        {
            _blobServiceClient = blobServiceClient;
            _azureBlobConfig = azureBlobConfig;
        }

        public async Task UploadAsync(string fileName, Stream stream)
        {
            var blobClient = GetBlobClient(fileName);
            await blobClient.UploadAsync(stream, true);
        }

        public async Task<string?> DownloadAsync(string fileName)
        {
            var blobClient = GetBlobClient(fileName);
            if (!await blobClient.ExistsAsync()) return null;
            var downloadResult = await blobClient.DownloadContentAsync();
            var blobContents = downloadResult.Value.Content.ToArray();
            return $"data:image;base64,{Convert.ToBase64String(blobContents)}";
        }

        public async Task DeleteAsync(string fileName)
        {
            var blobClient = GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
        }

        private BlobClient GetBlobClient(string fileName) 
        {
            var containerName = _azureBlobConfig.Value.ContainerName;
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            return blobClient;
        }
    }
}
