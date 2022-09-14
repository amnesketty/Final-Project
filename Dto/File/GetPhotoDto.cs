using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Dto.File
{
    public class GetPhotoDto
    {
        public string Image { get; set; } = string.Empty;
        public int HotelId {get; set; }
    }
}