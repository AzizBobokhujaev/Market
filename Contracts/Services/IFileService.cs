using System.Threading.Tasks;
using Entities.Enums;
using Microsoft.AspNetCore.Http;

namespace Contracts.Services
{
    public interface IFileService
    {
        Task<string> AddFileAsync(IFormFile file, FileTypes fileType, string folderName);

        void DeleteFile(string folderName);
    }
}