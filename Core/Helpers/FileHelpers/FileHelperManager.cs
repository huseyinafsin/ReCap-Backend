using System;
using System.IO;
using Core.Utilities.Helpers.GuidHelpers;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelperManager 
    {
        private static readonly string RootDirectory = Environment.CurrentDirectory + "\\wwwroot";

        public static IDataResult<string> Upload(IFormFile file, string rootPath)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(rootPath))
                {                          
                                           
                    Directory.CreateDirectory(rootPath);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid();
                string filePath = rootPath+"/" + guid + extension;

                try
                {
                    using (FileStream fileStream = File.Create( filePath))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        return new SuccessDataResult<string>(filePath, "This method returns path of the file of created");
                    }
                }
                catch (Exception e)
                {
                }


            }
            return new ErrorDataResult<string>();


        }

        public static Results.IResult Delete(string filePath)
        {
            var path = $"{RootDirectory}\\{filePath.Replace("/", "\\")}";

            if (File.Exists(path))
            {
                File.Delete(path);
                return new SuccessResult();
            }

            return new ErrorResult();
        }

        public static IDataResult<string> Update(IFormFile file, string filePath, string rootPath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            return Upload(file, rootPath);
        }
    }
}
