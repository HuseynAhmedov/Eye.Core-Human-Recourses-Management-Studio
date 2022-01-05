using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Helper
{
    public class FileManager
    {

        public static string Upload(string rootPath , string filePath , IFormFile formFile)
        {
            string fileName = Guid.NewGuid().ToString() + formFile.FileName;
            string mainPath = Path.Combine(rootPath,filePath, fileName);
            using(FileStream stream = new FileStream(mainPath,FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            return filePath + "/" + fileName;
        }

        public static bool Delete(string rootPath , string filePath)
        {
            string mainPath = Path.Combine(rootPath, filePath);
            if (File.Exists(mainPath))
            {
                File.Delete(mainPath);
                return true;
            }
            return false;
        }
    }
}
