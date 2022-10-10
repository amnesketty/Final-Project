using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace lounga.Views.ViewUsers
{
    public class GetUserTransaction : PageModel
    {
        private readonly ILogger<GetUserTransaction> _logger;

        public GetUserTransaction(ILogger<GetUserTransaction> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}