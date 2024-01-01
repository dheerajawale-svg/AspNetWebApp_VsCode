using System.Text.Json.Serialization;
using System.Text.Json;
using WebAppTest.Models;

namespace WebAppTest
{
    public sealed class DataService
    {
        private static readonly Lazy<DataService> lazy =
            new Lazy<DataService>(() => new DataService());

        public static DataService Instance { get { return lazy.Value; } }

        private DataService()
        {
            AamSites = new List<AamSite>();
        }

        public List<AamSite> AamSites { get; private set; }

        public void FetchData(string rootPath)
        {
            if(AamSites != null && AamSites.Count > 0)
            {
                return;
            }

            string path = Path.Combine(rootPath, "data");
            var allSitesJsonData = Directory.GetFiles(path);

            foreach (var site in allSitesJsonData)
            {
                var aamSite = ParseData<AamSite>(site);

                AamSites.Add(aamSite);

                var json = JsonSerializer.Serialize(aamSite);
                Console.WriteLine(json);
            }
        }

        private static T ParseData<T>(string fullPath)
        {
            //var fullPath = Path.Combine(rootPath, fileName);
            var jsonData = System.IO.File.ReadAllText(fullPath);

            var dataModel = JsonSerializer.Deserialize<T>(jsonData, new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                WriteIndented = true
            });

            return dataModel;
        }
    }
}
