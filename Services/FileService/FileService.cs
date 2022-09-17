using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using lounga.Data;
using lounga.Dto.File;
using lounga.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace lounga.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly CloudStorageSettings _cloudStorageSettings;
        public FileService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper, IOptions<CloudStorageSettings> cloudStorageSettings)
        {
            _cloudStorageSettings = cloudStorageSettings.Value;
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;            
        }
        public async Task<ServiceResponse<GetPhotoDto>> UploadImage()
        {
            var response = new ServiceResponse<GetPhotoDto>();
            try
            {
                Account account = new Account(
                    _cloudStorageSettings.cloud,
                    _cloudStorageSettings.apiKey,
                    _cloudStorageSettings.apiSecret
                );
                Cloudinary cloudinary = new Cloudinary(account);
                cloudinary.Api.Secure = true;
            
                int.TryParse(_httpContextAccessor.HttpContext.Request.Form["HotelId"], out int hotelId);
                Hotel hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == hotelId);

                var uploadFile = _httpContextAccessor.HttpContext.Request.Form.Files["Image"];
                var file = new FileInfo(_httpContextAccessor.HttpContext.Request.Form.Files["Image"].FileName);
                string filename = file.ToString().Substring(0, file.ToString().Length - file.Extension.ToString().Length);

                using (var filestream = uploadFile.OpenReadStream())
                {
                    var uploadUpload = new ImageUploadParams
                    {
                        File = new FileDescription(uploadFile.FileName, filestream),
                        PublicId = $"{DateTime.Now.ToString("yyyy-MM-ddThh-mm-ss")}_{filename}"
                    };
                    var uploadResult = await cloudinary.UploadAsync(uploadUpload);
                    GetPhotoDto getPhotoDto = new GetPhotoDto
                    {
                        Image = uploadResult.Url.ToString(),
                        HotelId = hotelId
                    };
                    Photo photo = _mapper.Map<Photo>(getPhotoDto);
                    photo.Hotel = hotel;
                    _context.Photos.Add(photo);
                    await _context.SaveChangesAsync();

                    response.Data = getPhotoDto;
                    response.Message = "File uploaded successfully!";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}