using System.Text.Json.Serialization;

namespace WebAppTest.Models
{
    public class AvamarDetails
    {
        public string Hostname { get; set; }

        public string IP { get; set; }

        [JsonPropertyName("OEM Version")]
        public string OEMVersion { get; set; }
    }
}
