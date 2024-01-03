using System.Text.Json.Serialization;

namespace WebAppTest.Models
{
    public class NasuniFiler
    {
        public string Alias { get; set; }

        [JsonPropertyName("Cache Size")]
        public string CacheSize { get; set; }

        [JsonPropertyName("Connected Volumes")]
        public string ConnectedVolumes { get; set; }

        [JsonPropertyName("Filer name")]
        public string FilerName { get; set; }

        [JsonPropertyName("Ip address")]
        public string IpAddress { get; set; }

        public string Path { get; set; }

        public string Platform { get; set; }

        public string Shares { get; set; }

        public string Version { get; set; }
    }
}
