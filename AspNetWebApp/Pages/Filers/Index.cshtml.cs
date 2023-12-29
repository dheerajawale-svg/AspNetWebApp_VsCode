using AspNetWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AspNetWebApp.Pages.Filers
{
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndexModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IList<Filer> Filers { get; set; }


        [BindProperty(SupportsGet = true)]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? SearchString { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        public void OnGet()
        {
            var rootPath = _webHostEnvironment.WebRootPath; //get the root path
            var fullPath = Path.Combine(rootPath, "data\\filers.json"); //combine the root path with that of our json file inside mydata directory
            var jsonData = System.IO.File.ReadAllText(fullPath); //read all the content inside the file

            var filers = JsonSerializer.Deserialize<List<Filer>>(jsonData, new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                WriteIndented = true
            });

            if (string.IsNullOrEmpty(SearchString))
            {
                Filers = filers;
            }
            else
            {
                Filers = new List<Filer>(filers.Where(s => s.FilerName.Contains(SearchString)));
            }
        }
    }
}
