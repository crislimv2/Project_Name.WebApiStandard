using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Name.Commons.Services
{
    public interface IStorageService
    {
        Task<string> GetPresignedUrlReadAsync(string fileName);

        Task<string> GetPresignedUrlWriteAsync(string fileName);

        Task UploadFileAsync(string fileName, Stream data);

        Task DeleteFileAsync(string fileName);

        Task MoveFileAsync(string sourcePath, string destPath);
    }
}
