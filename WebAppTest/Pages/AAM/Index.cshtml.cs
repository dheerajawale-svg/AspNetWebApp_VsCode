using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebAppTest.Models;

namespace WebAppTest.Pages.AAM
{
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndexModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public AamSite AamSite { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SiteName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public void OnGet()
        {
            DataService.Instance.FetchData(_webHostEnvironment.WebRootPath);
            var aamSites = DataService.Instance.AamSites;

            var currentSite = aamSites.FirstOrDefault(s => s.Name == SiteName);

            if (!currentSite.Name.Contains("Dummy"))
            {
                AamSite = currentSite;
            }
        }

        private static T ParseData<T>(string rootPath, string fileName)
        {
            var fullPath = Path.Combine(rootPath, fileName);
            var jsonData = System.IO.File.ReadAllText(fullPath);

            var filers = JsonSerializer.Deserialize<T>(jsonData, new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                WriteIndented = true
            });

            return filers;
        }

        private void Misc()
        {
            //var avamardetails = ParseData<List<AvamarDetails>>(rootPath, "data\\avamardetails.json");
            //var avamarreplication = ParseData<List<AvamarReplication>>(rootPath, "data\\avamarreplication.json");
            //var avamarproxy = ParseData<List<AvamarProxy>>(rootPath, "data\\avamarproxy.json");
            //var serverlist = ParseData<List<string>>(rootPath, "data\\serverlist.json");
            //var datadomain = ParseData<List<DataDomain>>(rootPath, "data\\datadomain.json");

            //AamSite site = new AamSite
            //{
            //    NasuniFilers = filers,
            //    AvamarDetails = avamardetails,
            //    AvamarReplication = avamarreplication,
            //    AvamarProxy = avamarproxy,
            //    Servers = serverlist,
            //    DataDomain = datadomain
            //};

            //var json = JsonSerializer.Serialize(site);
            //Console.WriteLine(json);


        }
    }
}
