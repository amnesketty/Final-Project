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
        
        //[AllowAnonymous]
        [HttpPost("UploadImage")]
        public async Task<ActionResult<ServiceResponse<string>>> UploadImage()
        {
            return Ok(await _fileService.UploadImage());
        }

        [HttpPost("MailNotification")]
        public async Task SendEmailAsync(MailRequest mailRequest)
            {
                // var random = new Random();
                // var newOTP = random.Next(100000,999999);
                // mailRequest.Body = newOTP.ToString();
                // result.Otp = newOTP;
                // await db.SaveChangesAsync();
                // await mail.SendEmailAsync(mailRequest);
                // await wa.SendWaAsync(mailRequest);
                // return Results.Ok("OTP has been sent");
            }

    }
}