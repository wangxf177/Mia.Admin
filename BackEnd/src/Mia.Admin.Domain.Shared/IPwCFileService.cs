using System.IO;
using System.Threading.Tasks;

namespace Mia.Admin
{
    public interface IMiaFileService
    {
        Task<string> UploadFileAsync(string fileName, string contentType, Stream fileStream);

        Task<string> UploadFileAsync(string fileName, string contentType, byte[] fileBytes);

        Task<(byte[] fileContents, string contentType, string fileDownloadName)> DocnloadFilesAsync(string fileId);
    }
}
