using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace lounga.Views.ViewFlights
{
    public class FindFlight : PageModel
    {
        private readonly ILogger<FindFlight> _logger;

        public FindFlight(ILogger<FindFlight> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}