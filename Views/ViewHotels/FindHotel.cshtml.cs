using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace lounga.Views.ViewHotels
{
    public class FindHotel : PageModel
    {
        private readonly ILogger<FindHotel> _logger;

        public FindHotel(ILogger<FindHotel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}