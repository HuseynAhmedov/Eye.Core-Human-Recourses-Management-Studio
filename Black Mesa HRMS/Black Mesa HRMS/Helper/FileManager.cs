using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Hepler
{
    public static class FileManager
    {
        public static string Save(string rootPath , string folder , IFormFile formImage)
        {
            string fileName = formImage.FileName;
            if (fileName.Length >= 64)
            {
               fileName = fileName.Substring(fileName.Length - 64, 64);
            }
            fileName = Guid.NewGuid().ToString() + fileName;
            string path = Path.Combine(rootPath, folder, fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                formImage.CopyTo(stream);
            }

            return fileName;
        }

        public static bool Delete(string rootPath, string fileName,string imageName)
        {
            string path = Path.Combine(rootPath, fileName , imageName);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;
        }
    }
}
