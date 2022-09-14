using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Data;
using lounga.Dto.File;
using lounga.Model;

namespace lounga.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dataContext;
        public FileService(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
            
        }
        public Task<ServiceResponse<GetPhotoDto>> UploadImage()
        {
            var response = new ServiceResponse<GetPhotoDto>();
            
            throw new NotImplementedException();
        }
    }
}