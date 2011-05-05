using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace usertools.WebServerFinder
{
    class ServerInfo
    {
        public string Banner;
        public string Server;
    }

    class FingerPrinter
    {
        private List<ServerInfo> servers;
        internal List<ServerInfo> Servers
        {
            get { return servers; }
            set { servers = value; }
        }

        public void ReadText()
        {   
            servers = new List<ServerInfo>();
            string[] file = File.ReadAllLines(Application.StartupPath + @"\WebserverFinder\signatures.dat");
            for (int i = 0; i < file.Length+1; i+=3)
            {
                servers.Add(new ServerInfo {Banner = file[i], Server = file[i + 1]});
            }
        }

        public string GetWebServer(string banner)
        {
            foreach (ServerInfo server in servers)
            {
                if (banner.ToLower().Contains(server.Banner.ToLower()))
                    return server.Server;
            }
            return "unknown";
        }
    }
}
