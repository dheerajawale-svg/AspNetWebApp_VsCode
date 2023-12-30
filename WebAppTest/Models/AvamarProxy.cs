namespace WebAppTest.Models
{
    public class AvamarProxy
    {
        public string Hostname { get; set; }

        public string IP { get; set; }

        public string Version { get; set; }
    }

    public class ServerList
    {
        public string Description { get; set; }

        public List<string> Servers { get; set; }

        public ServerList()
        {
            Description = "Dell support portal:- https://www.dell.com/support/home \r\nSupport Expiration date - 30 DEC 2024\r\n";
        }
    }

}
