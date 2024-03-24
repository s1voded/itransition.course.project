namespace PersonalCollection.Application.Interfaces.Services
{
    public interface IImageStorageService
    {
        public Task UploadAsync(string fileName, Stream stream);
        public Task<string?> DownloadAsync(string fileName);
        public Task DeleteAsync(string fileName);

    }
}
