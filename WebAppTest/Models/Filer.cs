namespace WebAppTest.Models
{
    public class Filer
    {
        public string Alias { get; set; }

        //[JsonProperty(PropertyName = "Cache size")]
        public string CacheSize { get; set; }

        //[JsonProperty(PropertyName = "ConnectedVolumes")]
        public string ConnectedVolumes { get; set; }

        //[JsonProperty(PropertyName = "Filer name")]
        public string FilerName { get; set; }

        //[JsonProperty(PropertyName = "Ip address")]
        public string IpAddress { get; set; }

        public string Path { get; set; }

        public string Platform { get; set; }

        public string Shares { get; set; }

        public string Version { get; set; }
    }
}
