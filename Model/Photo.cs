using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lounga.Model
{
    public class Photo
    {
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public Hotel? Hotel {get; set; }
    }
}