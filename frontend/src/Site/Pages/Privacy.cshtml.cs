using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Site.ExternalService;
using Site.Pages.Model;

namespace Site.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public List<Processamentos> ProcessamentosList;
        private readonly IServiceConverce _service;
        public PrivacyModel(ILogger<PrivacyModel> logger, IServiceConverce service)
        {
            _logger = logger;
            _service = service;
        }

        public void OnGet()
        {
        }
    }
}