using Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Utilities
{
    public class FileUploadHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\Files\\";

        public static string Upload(IFormFile file)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists != null)
            {
                throw new BusinessException(fileExists);
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid != null)
            {
                throw new BusinessException(typeValid);
            }

            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return (_folderName + randomName + type).Replace("\\", "/");
        }

        public static string Update(IFormFile file, string imagePath)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists != null)
            {
                throw new BusinessException(fileExists);
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid != null)
            {
                throw new BusinessException(typeValid);
            }

            DeleteOldImageFile((_currentDirectory + imagePath).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return (_folderName + randomName + type).Replace("\\", "/");
        }

        public static void Delete(string path)
        {
            DeleteOldImageFile((_currentDirectory + path).Replace("/", "\\"));
        }

        private static string CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return null;
            }
            return "Dosya mevcut değil.";
        }

        private static string CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg" && type != ".doc" && type != ".xls" && type != ".xlsx" && type != ".pdf")
            {
                return "Yanlış dosya türü.";
            }
            return null;
        }

        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }

        }
    }
}
