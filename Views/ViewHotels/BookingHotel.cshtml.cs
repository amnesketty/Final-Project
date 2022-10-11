using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace lounga.Views.ViewHotels
{
    public class BookingHotel : PageModel
    {
        private readonly ILogger<BookingHotel> _logger;

        public BookingHotel(ILogger<BookingHotel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}