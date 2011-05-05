using System;
using System.Collections.Generic;
using System.Text;
using DnsDig;
using System.Net;
using System.Threading;
using System.Net.NetworkInformation;

namespace usertools.SubdomainScanner
{
    class DnsValidator
    {
        private Queue<string> Work;
        private ManualResetEvent FinishedValidation;

        private bool userStopped;
        public bool UserStopped
        {
            get { return userStopped; }
        }

        private int requestsDone;
        public int RequestsDone
        {
            get { return requestsDone; }
            set { requestsDone = value; }
        }

        private List<string> foundDomains;
        public List<string> FoundDomains
        {
            get { return foundDomains; }
        }

        private bool finished;
        public bool Finished
        {
            get { return finished; }
            set { finished = value; }
        }

        private string dNSServer;
        public string DNSServer
        {
            get { return dNSServer; }
            set { dNSServer = value; }
        }


        public DnsValidator()
        {
            Work = new Queue<string>();
            FinishedValidation = new ManualResetEvent(false);
            userStopped = false;
            requestsDone = 0;
            foundDomains = new List<string>();
            dNSServer = string.Empty;
            finished = false;
        }

        public int RequestsLeft()
        {
            lock (Work)
            {
                return Work.Count;
            }
        }

        public bool ValidDomain(string domain)
        {
            return ValidateDomain(domain);
        }

        public void ValidDomainsAsync(List<string> domains)
        {
            StartThreads(domains);
        }

        public List<string> ValidDomains(List<string> domains)
        {
            StartThreads(domains);

            WaitHandle[] finish = new WaitHandle[] { FinishedValidation };
            WaitHandle.WaitAny(finish);

            return foundDomains;
        }

        private void StartThreads(List<string> domains)
        {
            finished = false;
            userStopped = false;
            foundDomains.Clear();
            requestsDone = 0;
            Work.Clear();

            for (int i = 0; i < domains.Count; i++)
                Work.Enqueue(domains[i]);

            StartThreads(50);
        }

        public void Stop()
        {
            userStopped = true;
        }

        private void StartThreads(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                Thread thread = new Thread(new ThreadStart(ThreadFunction));
                thread.Start();
            }
        }

        private void ThreadFunction()
        {
            // Initialization Wait, waiting WaitHandle to be set
            Thread.Sleep(100);

            while (true)
            {
                string domain = GetDomain();
                if (domain != null && !userStopped)
                {
                    if (ValidateDomain(domain))
                        foundDomains.Add(domain);

                    IncrementRequestCount();
                }
                else
                {
                    Thread.Sleep(4000);
                    FinishedValidation.Set();
                    finished = true;
                    break;
                }
            }
        }

        private string GetDomain()
        {
            lock (Work)
            {
                if (Work.Count > 0)
                    return Work.Dequeue();
            }

            return null;
        }

        private void IncrementRequestCount()
        {
            lock (Work)
            {
                requestsDone++;
            }
        }

        public string GetDnsServer(string domain)
        {
            string Dns = string.Empty;
            try
            {
                IPAddress DefaultDns = GetDefaultDns();
                if (DefaultDns == null)
                    return string.Empty;

                Dig dig = new Dig();
                dig.resolver.TransportType = Heijden.DNS.TransportType.Tcp;
                Heijden.DNS.Response Response = dig.resolver.Query(domain, Heijden.DNS.QType.NS, Heijden.DNS.QClass.IN);

                if (Response != null)
                {
                    if (Response.header.RCODE == Heijden.DNS.RCode.NoError)
                    {
                        if (Response.Answers.Count > 0)
                            Dns = Response.Answers[0].RECORD.ToString().TrimEnd('.');
                        if (Response.Authorities.Count > 0)
                        {
                            //Dns = Response.Authorities[0].RECORD.ToString().Substring(0, Response.Authorities[0].RECORD.ToString().LastIndexOf('.'));
                            Dns = Response.Authorities[0].RECORD.ToString().Substring(0, Response.Authorities[0].RECORD.ToString().IndexOf(' ')).TrimEnd('.');
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("DNSServer konnte nicht gefunden werden.(DNSValidator/GetDNSServer)");
            }

            return Dns;
        }

        private bool ValidateDomain(string domain)
        {
            try
            {
                //IPAddress dnsServer = null;
                //IPAddress[] dnsAddresses = Dns.GetHostAddresses(dNSServer);
                //if (dnsAddresses.Length > 0)
                //    dnsServer = dnsAddresses[0];


                Dig dig = new Dig();
                dig.resolver.DnsServer = dNSServer;
                dig.resolver.TimeOut = 500;
                dig.resolver.TransportType = Heijden.DNS.TransportType.Tcp;
                Heijden.DNS.Response Response = dig.resolver.Query(domain, Heijden.DNS.QType.A, Heijden.DNS.QClass.IN);

                if (Response != null)
                    if (Response.header.RCODE == Heijden.DNS.RCode.NoError && Response.RecordsA.Length > 0)
                        return true;

            }
            catch (Exception)
            {
                Console.WriteLine("DNSServer konnte nicht bestätigt werden (DnsValidator/ValidateDomain) k");
            }

            return false;
        }
        private IPAddress GetDefaultDns()
        {
            //The following requires using System.Net.NetworkInformation
            NetworkInterface[] arrNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface objNetworkInterface in arrNetworkInterfaces)
            {
                if ((objNetworkInterface.OperationalStatus == OperationalStatus.Up)
                && (objNetworkInterface.Speed > 0)
                && (objNetworkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                && (objNetworkInterface.NetworkInterfaceType != NetworkInterfaceType.Tunnel))
                {
                    foreach (IPAddress objDNSAddress in objNetworkInterface.GetIPProperties().DnsAddresses)
                    {
                        return objDNSAddress;
                    }
                }
            }

            return null;
        }
    }
}
