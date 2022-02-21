using System;
using System.IO;
using System.Threading.Tasks;
using Contracts.Services;
using Entities.Enums;
using Microsoft.AspNetCore.Http;

namespace Service
{
    public class FileService:IFileService
    {
        public async Task<string> AddFileAsync(IFormFile file, FileTypes fileType, string folderName)
        {
            var path = Path.GetFullPath($"wwwroot/{folderName}/{fileType}");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var filePath = $"/{DateTime.Now.Ticks}_{file.FileName}";
            await using var fs = new FileStream(path + filePath, FileMode.Create);
            await file.CopyToAsync(fs);
            return $"/{folderName}/{fileType}{filePath}";
        }

        

        public void DeleteFile(string folderName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + folderName);
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}