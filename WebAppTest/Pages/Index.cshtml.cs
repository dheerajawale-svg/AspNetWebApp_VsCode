using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTest.Models;

namespace WebAppTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<AamSite> AamSites { get; set; }

        public void OnGet()
        {
            DataService.Instance.FetchData(_webHostEnvironment.WebRootPath);
            var aamSites = DataService.Instance.AamSites;

            for (int i = 0; i < 20; i++)
            {
                aamSites.Add(new AamSite() { Name = $"Dummy Site {i+1}" });
            }

            if (string.IsNullOrEmpty(SearchString))
            {
                AamSites = aamSites;
            }
            else
            {
                AamSites = new List<AamSite>(aamSites.Where(s => s.Name.Contains(SearchString)));
            }
        }
    }
}
