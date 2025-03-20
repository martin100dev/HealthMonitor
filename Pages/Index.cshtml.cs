using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HealthMonitor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private const decimal BMRMale = 88.362m;
        private const decimal BMRFemale = 447.593m;

        [BindProperty]
        public decimal Weight { get; set; }

        [BindProperty]
        public decimal Height { get; set; }

        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public string Gender { get; set; }

        public string Message { get; set; } = string.Empty;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            decimal result = default;
            // Perform any processing here (e.g., save to database, calculations, etc.)
            Message = $"Received: Weight={Weight}, Height={Height}, Age={Age}, Gender={Gender}";

            if (Gender == "male")
            {
                result = BMRMale + (Weight * 13.397m) + (4.799m * Height) - 5.677m * Age;
            }
            else result = BMRFemale + (Weight * 9.247m) + (3.098m * Height) - (4.330m * Age);

            // Optionally, return to the same page with updated values
            return Content(result.ToString());
        }
    }
}