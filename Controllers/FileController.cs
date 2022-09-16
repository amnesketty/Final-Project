using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.File;
using lounga.Model;
using lounga.Services.FileService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lounga.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        [AllowAnonymous]
        [HttpPost("UploadImage")]
        public async Task<ActionResult<ServiceResponse<string>>> UploadImage()
        {
            return Ok(await _fileService.UploadImage());
        }
    }
}