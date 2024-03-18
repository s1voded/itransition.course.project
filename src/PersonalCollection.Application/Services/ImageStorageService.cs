using Dropbox.Api.Files;
using Dropbox.Api;
using Microsoft.Extensions.Options;
using PersonalCollection.Application.Models.Config;

namespace PersonalCollection.Application.Services
{
    public class ImageStorageService
    {
        private readonly IOptions<DropboxConfig> _dropboxConfig;

        public ImageStorageService(IOptions<DropboxConfig> dropboxConfig)
        {
            _dropboxConfig = dropboxConfig;
        }

        public async Task Upload(string fileName, Stream stream)
        {
            var path = $"/{_dropboxConfig.Value.Folder}/{fileName}";

            using var dbx = new DropboxClient(_dropboxConfig.Value.Token);
            var updated = await dbx.Files.UploadAsync(path, WriteMode.Overwrite.Instance, body: stream);
        }

        public async Task<byte[]> Download(string fileName)
        {
            var path = $"/{_dropboxConfig.Value.Folder}/{fileName}";

            using var dbx = new DropboxClient(_dropboxConfig.Value.Token);
            using var response = await dbx.Files.DownloadAsync(path);
            return await response.GetContentAsByteArrayAsync();
        }

        public async Task Delete(string fileName)
        {
            var path = $"/{_dropboxConfig.Value.Folder}/{fileName}";
            using var dbx = new DropboxClient(_dropboxConfig.Value.Token);
            var result = await dbx.Files.DeleteV2Async(path);
        }
    }
}
