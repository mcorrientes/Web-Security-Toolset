using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using usertools.WebServerFinder;


namespace ToolSet.WebserverFinderCode
{
    public partial class UserControlWebserverFinder : UserControl
    {
        private WebServerFinder serverFinder;
        private int LastResultIndex;
        private ImageList smallImages = new ImageList();

        public UserControlWebserverFinder()
        {
            InitializeComponent();
            serverFinder = new WebServerFinder();
            LastResultIndex = 0;
            smallImages.Images.Add(Properties.Resources.Apachebmp);
            smallImages.Images.Add(Properties.Resources.Windowsbmp);
            smallImages.Images.Add(Properties.Resources.Lockbmp);
            smallImages.Images.Add(Properties.Resources.Zahnradbmp);
            listViewServers.SmallImageList = smallImages;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!serverFinder.Finished)
            {
                serverFinder.Stop();
                buttonSearch.Enabled = false;
            }
            else
            {
                List<Target> Targets = new List<Target>();
                List<IPAddress> IPAddresses = GetIPAddressFromGUI();
                List<int> Ports = GetPortsFromGUI();

                if (IPAddresses.Count == 0 || Ports.Count == 0)
                    return;

                foreach (IPAddress IPAddress in IPAddresses)
                {
                    foreach (int Port in Ports)
                    {
                        Target targetHTTP = new Target();
                        targetHTTP.Port = Port;
                        targetHTTP.Address = IPAddress.ToString();
                        Targets.Add(targetHTTP);

                        Target targetHTTPs = new Target();
                        targetHTTPs.Port = Port;
                        targetHTTPs.Address = IPAddress.ToString();
                        Targets.Add(targetHTTPs);
                    }
                }

                LastResultIndex = 0;
                buttonSearch.Text = "Stop";
                listViewServers.Items.Clear();
                progressBarTargetFinder.Value = 0;

                Thread thread = new Thread(new ParameterizedThreadStart(serverFinder.Start));
                thread.Start((object)Targets);
            }
        }

        private bool ValidIP(string Address)
        {
            IPAddress temp = new IPAddress(2414188L);
            return IPAddress.TryParse(Address, out temp);
        }

        private List<int> GetPortsFromGUI()
        {
            List<int> Ports = new List<int>();
            string[] strPorts = textBoxPorts.Text.Split(',');
            for (int i = 0; i < strPorts.Length; i++)
            {
                int Port = 0;
                if (!Int32.TryParse(strPorts[i].Trim(' '), out Port))
                    continue;

                if (Port > 0 && Port <= 65535)
                    Ports.Add(Port);
            }

            return Ports;
        }

        private List<IPAddress> GetIPAddressFromGUI()
        {

            List<IPAddress> IPAddresses = new List<IPAddress>();
            string[] Splitted = textBoxIPAddress.Text.Split('-');
            if (Splitted.Length == 2)
            {
                int Count = 1;
                if (!Int32.TryParse(Splitted[1].Trim(' '), out Count))
                    return IPAddresses;

                string[] SplittedIP = Splitted[0].Trim(' ').Split('.');
                int Start = 0;
                if (!Int32.TryParse(SplittedIP[3], out Start))
                    return IPAddresses;

                if (Start > Count)
                    return IPAddresses;

                if (Start > 255 || Count > 255)
                    return IPAddresses;

                for (; Start <= Count; Start++)
                {
                    string Address = SplittedIP[0] + "." + SplittedIP[1] + "." + SplittedIP[2] + "." + Start;
                    if (ValidIP(Address))
                        IPAddresses.Add(IPAddress.Parse(Address));
                }
            }
            else
            {
                if (!ValidIP(textBoxIPAddress.Text))
                    return IPAddresses;

                IPAddresses.Add(IPAddress.Parse(textBoxIPAddress.Text));
            }

            return IPAddresses;
        }

        private void FillServerListView()
        {
            for (; LastResultIndex < serverFinder.Results.Count; LastResultIndex++)
            {
                if (!serverFinder.Results[LastResultIndex].Success)
                    continue;

                ListViewItem Item = new ListViewItem();

                Item.Tag = (object)LastResultIndex;
                if (serverFinder.Results[LastResultIndex].StatusCode == HttpStatusCode.Unauthorized)
                    Item.ImageIndex = 2;
                else if (serverFinder.Results[LastResultIndex].Banner.ToLower().Contains("apache"))
                    Item.ImageIndex = 0;
                else if (serverFinder.Results[LastResultIndex].Banner.ToLower().Contains("microsoft"))
                    Item.ImageIndex = 1;
                else Item.ImageIndex = 3;
                Item.Text = serverFinder.Results[LastResultIndex].Url;
                Item.SubItems.Add(serverFinder.Results[LastResultIndex].Hostname);
                Item.SubItems.Add(serverFinder.Results[LastResultIndex].WebServer);
                Item.SubItems.Add(serverFinder.Results[LastResultIndex].Banner);
                listViewServers.Items.Add(Item);
            }

            int Results = serverFinder.Results.Count;
            int TotalCount = Results + serverFinder.TargetsLeft();
            if (Results > 0 && TotalCount > 0)
            {
                int Progress = Convert.ToInt32(Math.Round((float)Results / (float)TotalCount * 100, 0));
                progressBarTargetFinder.Value = Progress;
            }
        }

        private void listViewServers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.ItemIndex > serverFinder.Results.Count && e.ItemIndex < 0)
                return;

            FillResponseInfos((int)e.Item.Tag);
        }

        private void FillResponseInfos(int Index)
        {
            webBrowserSource.Navigate("about:blank");
            richTextBoxSource.Text = "";
            listViewResponseHeaders.Items.Clear();

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
            if (serverFinder.Finished)
            {
                buttonSearch.Text = "Search";
                buttonSearch.Enabled = true;
            }
            FillServerListView();
        }

        private void buttonCreateReport_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Report (*.pdf)|*.pdf|All (*.*)|*.*";
            DialogResult result = saveFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                Speichern(saveFile.FileName);
            }
        }

        private void Speichern(string filename)
        {
            try
            {
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
                document.AddTitle("Webserver Finder Report");
                document.AddCreationDate();
                document.Open();
                document.Add(new Paragraph("Webserver Finder: Server list", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, iTextSharp.text.Font.UNDERLINE)));
                document.Add(new Paragraph(" "));

                foreach (ListViewItem item in listViewServers.Items)
                {
                    document.Add(new Paragraph("Hostname:       " + item.SubItems[1].Text + item.SubItems[1].Text));
                    document.Add(new Paragraph("Used Webserver: " + item.SubItems[2].Text));
                    document.Add(new Paragraph("Server Ip:      " + item.SubItems[0].Text));
                    document.Add(new Paragraph(" "));
                }
                document.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("The file is in use. Please close all applications accessing this file and try again.", "Access not possible", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Speichern" + ex);
            }
        }

    }

}
