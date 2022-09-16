using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.File
{
    public class MailRequest
    {
        public string? ToEmail {get; set;}
        public string? Subject {get; set;}
        public int toid {get; set;}
        public string? Body {get; set;}
        public string? UserName {get; set;}
    }
}