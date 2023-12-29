using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebAppTest.Models;

namespace WebAppTest.Pages.Filers
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
        public string? SearchString { get; set; }

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
