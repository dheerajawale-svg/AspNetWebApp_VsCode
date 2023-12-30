using System.Text.Json.Serialization;

namespace WebAppTest.Models
{
    public class DataDomain
    {
        [JsonPropertyName("Data Domain hostname")]
        public string DataDomainHostname { get; set; }

        [JsonPropertyName("Ip address")]
        public string IpAddress { get; set; }

        public string Version { get; set; }

        public string Model { get; set; }

        [JsonPropertyName("Avamar Replication")]
        public string AvamarReplication { get; set; }

        [JsonPropertyName("Total Capacity")]
        public string TotalCapacity { get; set; }
    }

}
