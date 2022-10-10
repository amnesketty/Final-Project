using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace lounga.Views.ViewHotels
{
    public class GetHotel : PageModel
    {
        private readonly ILogger<GetHotel> _logger;

        public GetHotel(ILogger<GetHotel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}