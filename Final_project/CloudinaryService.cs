using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_project
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService()
        {
            Account account = new Account(
                "dhoodxgrr",   // Thay thế bằng cloud_name từ Cloudinary
                "558645983595656",      // Thay thế bằng api_key từ Cloudinary
                "Xu09zifFMvO9YbhGd-3vTpZXAxs"    // Thay thế bằng api_secret từ Cloudinary
            );

            _cloudinary = new Cloudinary(account);
        }


        // Phương thức upload hình ảnh
        public string UploadImage(HttpPostedFileBase file)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.InputStream)
            };

            var uploadResult = _cloudinary.Upload(uploadParams);
            return uploadResult.SecureUrl.ToString(); // Trả về URL của ảnh đã upload
        }
    }
}