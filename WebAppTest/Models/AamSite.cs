namespace WebAppTest.Models
{
    public class AamSite
    {
        public string Name { get; set; }

        public string DiagramPath { get; set; }

        public List<NasuniFiler> NasuniFilers { get; set; }

        public List<AvamarDetails> AvamarDetails { get; set; }

        public List<AvamarReplication> AvamarReplication { get; set; }

        public List<AvamarProxy> AvamarProxy { get; set; }

        public ServerList AvamarServers { get; set; }

        public List<string> Servers { get; set; }

        public List<DataDomain> DataDomain { get; set; }
    }
}
