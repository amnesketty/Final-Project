using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.File;
using lounga.Model;

namespace lounga.Services.FileService
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}