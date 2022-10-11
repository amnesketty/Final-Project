using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace lounga.Views.ViewHotels
{
    public class DetailHotel : PageModel
    {
        private readonly ILogger<DetailHotel> _logger;

        public DetailHotel(ILogger<DetailHotel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}