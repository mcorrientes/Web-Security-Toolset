using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using usertools.SubdomainScanner;

namespace ToolSet.SudomainScannerCode
{
    public partial class UserControlSubdomainScanner : UserControl
    {
        private WebServerFinder serverFinder;
        private DnsValidator dnsValidator;
        private int LastResultIndex;
        private List<string> SubdomainsBig;
        private List<string> SubdomainsMed;
        private List<string> SubdomainsTiny;
        private bool AwaitingFinish;
        private bool DnsFinished;
        ImageList smallImages = new ImageList();

        public UserControlSubdomainScanner()
        {
            InitializeComponent();
            serverFinder = new WebServerFinder();
            dnsValidator = new DnsValidator();
            LastResultIndex = 0;
            comboBoxDnsServer.SelectedIndex = 0;
            comboBoxSearch.SelectedIndex = 0;
            SubdomainsBig = new List<string>();
            SubdomainsMed = new List<string>();
            SubdomainsTiny = new List<string>();
            LoadSubdomains();
            AwaitingFinish = false;
            DnsFinished = false;
            smallImages.Images.Add(Properties.Resources.Windowsbmp);
            smallImages.Images.Add(Properties.Resources.Apachebmp);
            smallImages.Images.Add(Properties.Resources.Lockbmp);
            smallImages.Images.Add(Properties.Resources.Zahnradbmp);
            listViewServers.SmallImageList = smallImages;
        }

        private void LoadSubdomains()
        {
            string SubdomainFileBig = Application.StartupPath + @"\SudomainScannerCode\big.dat";
            string SubdomainFileMed = Application.StartupPath + @"\SudomainScannerCode\med.dat";
            string SubdomainFileTiny = Application.StartupPath + @"\SudomainScannerCode\tiny.dat";
            if (!File.Exists(SubdomainFileBig) || !File.Exists(SubdomainFileMed) || !File.Exists(SubdomainFileTiny))
            {
                MessageBox.Show("Default passwords and usernames text do not exist.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SubdomainsBig = new List<string>(File.ReadAllLines(SubdomainFileBig));
            SubdomainsMed = new List<string>(File.ReadAllLines(SubdomainFileMed));
            SubdomainsTiny = new List<string>(File.ReadAllLines(SubdomainFileTiny));
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (AwaitingFinish)
            {
                serverFinder.Stop();
                dnsValidator.Stop();
                DnsFinished = true;
                buttonSearch.Enabled = false;
            }
            else
            {
                listViewServers.Items.Clear();
                progressBarTargetFinder.Value = 0;
                progressBarDnsChecks.Value = 0;
                GetValidDomains();

                if (dnsValidator.DNSServer == string.Empty)
                    MessageBox.Show("remote dns server not found", "search stopped");
                else
                {
                    buttonSearch.Text = "Stop";
                    Application.DoEvents();
                    DnsFinished = false;
                    AwaitingFinish = true;
                }
            }
        }

        private bool ValidIP(string Address)
        {
            IPAddress temp = new IPAddress(2414188L);
            return IPAddress.TryParse(Address, out temp);
        }

        private void GetValidDomains()
        {
            List<string> Subdomains = null;
            if (comboBoxSearch.SelectedIndex == 0)
                Subdomains = SubdomainsBig;
            else if (comboBoxSearch.SelectedIndex == 1)
                Subdomains = SubdomainsMed;
            else
                Subdomains = SubdomainsTiny;

            string Domain = textBoxDomain.Text;
            string DNSDomain = textBoxDomain.Text;
            if (Domain.IndexOf("://") != -1)
                Domain = Domain.Remove(0, Domain.IndexOf("://") + 3);
            if (Domain.IndexOf("www.") != -1)
                Domain = Domain.Remove(0, Domain.IndexOf("www.") + 4);
            if (DNSDomain.IndexOf("://") != -1)
                DNSDomain = DNSDomain.Remove(0, DNSDomain.IndexOf("://") + 3);

            List<string> Domains = new List<string>();
            for (int i = 0; i < Subdomains.Count; i++)
            {
                Domains.Add(Subdomains[i] + "." + textBoxDomain.Text);
            }

            if (comboBoxDnsServer.SelectedIndex == 1)
                dnsValidator.DNSServer = textBoxCustomDNS.Text;
            else
                dnsValidator.DNSServer = dnsValidator.GetDnsServer(DNSDomain);

            if (dnsValidator.DNSServer != string.Empty)
            {
                progressBarDnsChecks.Maximum = Domains.Count;
                dnsValidator.ValidDomainsAsync(Domains);
            }
        }

        private void FillServerListView()
        {
            for (; LastResultIndex < serverFinder.Results.Count; LastResultIndex++)
            {
                if (!serverFinder.Results[LastResultIndex].Success)
                    continue;

                ListViewItem Item = new ListViewItem();
                Item.Tag = (object)LastResultIndex;
                if (serverFinder.Results[LastResultIndex].Banner.ToLower().Contains("apache"))
                    Item.ImageIndex = 1;
                else if (serverFinder.Results[LastResultIndex].Banner.ToLower().Contains("windows"))
                    Item.ImageIndex = 0;
                else
                    Item.ImageIndex = 3;
                if (serverFinder.Results[LastResultIndex].Protocol == HttpProtocol.HTTP)
                    Item.Text = "HTTP";
                else if (serverFinder.Results[LastResultIndex].Protocol == HttpProtocol.HTTPs)
                    Item.Text = "HTTPs";
                Item.SubItems.Add(serverFinder.Results[LastResultIndex].Url);
                Item.SubItems.Add(serverFinder.Results[LastResultIndex].Hostname);
                Item.SubItems.Add(serverFinder.Results[LastResultIndex].WebServer);
                Item.SubItems.Add(serverFinder.Results[LastResultIndex].Banner);
                listViewServers.Items.Add(Item);
            }

            if (dnsValidator.RequestsDone <= progressBarDnsChecks.Maximum)
                progressBarDnsChecks.Value = dnsValidator.RequestsDone;
            if (serverFinder.Results.Count <= progressBarTargetFinder.Maximum)
                progressBarTargetFinder.Value = serverFinder.Results.Count;
        }

        private void listViewServers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.ItemIndex > serverFinder.Results.Count && e.ItemIndex < 0)
                return;

            FillResponseInfos((int)e.Item.Tag);
        }

        private void FillResponseInfos(int Index)
        {
            listViewResponseHeaders.Items.Clear();
            richTextBoxSource.Text = "";
            webBrowserSource.Navigate("about:blank");

            listViewResponseHeadersHTTPs.Items.Clear();
            richTextBoxSourceHTTPs.Text = "";
            webBrowserSourceHTTPs.Navigate("about:blank");

            TargetResult Result = serverFinder.Results[Index];
            richTextBoxSource.Text = Result.Html;
            webBrowserSource.Navigate(Result.Url);

            for (int i = 0; i < Result.ResponseHeaders.Count; i++)
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = Result.ResponseHeaders.Keys[i];

                string Value = string.Empty;
                string[] HeaderValues = Result.ResponseHeaders.GetValues(i);
                for (int iHv = 0; iHv < HeaderValues.Length; iHv++)
                {
                    Value += HeaderValues[iHv] + " ";
                }
                Item.SubItems.Add(Value);
                listViewResponseHeaders.Items.Add(Item);
            }
        }

        private void timerGUI_Tick(object sender, EventArgs e)
        {
            FillServerListView();
            if (AwaitingFinish)
            {
                if (DnsFinished)
                {
                    if (serverFinder.Finished && dnsValidator.Finished)
                    {
                        AwaitingFinish = false;
                        buttonSearch.Text = "Search";
                        buttonSearch.Enabled = true;

                        if (dnsValidator.FoundDomains.Count > SubdomainsTiny.Count)
                            MessageBox.Show("Dns server does not return name errors, searching stopped", "Searching stopped", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            MessageBox.Show("Searching Finished", "Searching Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (dnsValidator.RequestsLeft() == 0)
                {
                    DnsFinished = true;

                    if (dnsValidator.FoundDomains.Count != 0 && dnsValidator.FoundDomains.Count <= SubdomainsTiny.Count)
                    {
                        LastResultIndex = 0;
                        progressBarTargetFinder.Maximum = dnsValidator.FoundDomains.Count * 2;

                        List<Target> Targets = new List<Target>();
                        foreach (string Domain in dnsValidator.FoundDomains)
                        {
                            Target targetHTTP = new Target();
                            targetHTTP.Port = 80;
                            targetHTTP.Address = Domain;
                            Targets.Add(targetHTTP);

                            Target targetHTTPs = new Target();
                            targetHTTPs.Port = 443;
                            targetHTTPs.Address = Domain;
                            targetHTTPs.Protocol = HttpProtocol.HTTPs;
                            Targets.Add(targetHTTPs);
                        }

                        Thread thread = new Thread(new ParameterizedThreadStart(serverFinder.Start));
                        thread.Start((object)Targets);
                    }
                }
            }
        }

        private void comboBoxDnsServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxCustomDNS.ReadOnly = !(comboBoxDnsServer.SelectedIndex == 1);
        }
    }
}
