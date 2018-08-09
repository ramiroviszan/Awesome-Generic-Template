using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AGT.WebApi.Models
{
    public class Image
    {
        public static string[] ImageMimetypes = { "image/gif", "image/jpeg", "image/pjpeg", "image/x-png", "image/png", "image/svg+xml" };
        public static string[] ImageExt = { ".gif", ".jpeg", ".jpg", ".png", ".svg", ".blob" };
        public static string Folder = "uploads";

        public IFormFile File { get; }
        public string InternalServerPath { get; }
        public string RemoteLink { get; }

        public Image(IFormFile formFile, string webRootPath)
        {
            var mimeType = formFile.ContentType;
            var fileRoute = Path.Combine(webRootPath, Folder);
            var extension = Path.GetExtension(formFile.FileName);
            var name = Guid.NewGuid().ToString().Substring(0, 12) + extension;

            File = formFile;
            InternalServerPath = Path.Combine(fileRoute, name);
            RemoteLink = "/" + Folder + "/" + name;

            if (Array.IndexOf(ImageMimetypes, mimeType) == -1 && (Array.IndexOf(ImageExt, extension) == -1))
            {
                throw new ArgumentException("Image format not supported");
            }
        }
    }
}
