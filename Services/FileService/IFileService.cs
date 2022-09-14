using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.File;
using lounga.Model;

namespace lounga.Services.FileService
{
    public interface IFileService
    {
        Task<ServiceResponse<GetPhotoDto>> UploadImage ();
    }
}