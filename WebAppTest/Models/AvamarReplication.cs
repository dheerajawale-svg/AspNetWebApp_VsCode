using System.Text.Json.Serialization;

namespace WebAppTest.Models
{
    public class AvamarReplication
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        [JsonPropertyName("OEM Version")]
        public string OEMVersion { get; set; }
    }
}
