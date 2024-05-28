using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Demo.PL.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile (IFormFile file , string FolderName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);
            string FileName = $"{file.FileName}";
            string FilePath = Path.Combine(FolderPath, FileName);
            using var fs = new FileStream(FilePath,FileMode.CreateNew);
            file.CopyTo(fs);
            return FileName;
        }

        public static void DeleteFile(string FileName , string FolderName)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName, FileName );

            if(File.Exists(FilePath) )
            {
                File.Delete(FilePath);
            }

        }
    }
}
