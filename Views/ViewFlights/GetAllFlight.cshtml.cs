using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace lounga.Views.Flight
{
    public class GetAllFlight : PageModel
    {
        private readonly ILogger<GetAllFlight> _logger;

        public GetAllFlight(ILogger<GetAllFlight> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}