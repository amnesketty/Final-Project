using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Dto.User;

namespace lounga.Dto.Web
{
    public class WebProfileDto
    {
        public UserProfileDto? userProfileDto {get; set;}
        public UserTransactionDto? userTransactionDto {get; set;}
    }
}