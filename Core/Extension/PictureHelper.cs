using Microsoft.AspNetCore.Http;

namespace Core.Extension
{
    public static class PictureHelper
    {
        public static string UploadImage(this IFormFile formfile, string webRootPath)
        {
            var path = "/Images/" + Guid.NewGuid().ToString() + formfile.FileName;

            using (FileStream fileStream = new FileStream(webRootPath + path, FileMode.Create))
            {
                formfile.CopyTo(fileStream);
            }

            return path;
        }
    }
}
