using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PortScanner;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ToolSet.PortScannerCode
{
    public partial class UserControlPortScanner : UserControl
    {
        private ListViewColumnSorter lvwColumnSorter;
        private PortScanner.PortScanner portScanner;
        
        private int LastFinishedIndex;

        public UserControlPortScanner()
        {
            InitializeComponent();
            portScanner = new PortScanner.PortScanner();
            LastFinishedIndex = 0;
            //Textfile muss zuerst geladen werden
            ReadText();
            timer_Listview.Start();
            comboBoxScanMode.SelectedItem = comboBoxScanMode.Items[0];
            comboBoxScanAttitude.SelectedItem = comboBoxScanAttitude.Items[0];
        }

            #region Variables 
            private List<Services> services;
            private List<int> portRange;
            private string Service;
            private string Protocol;
            private int port;
            private bool buttonOnStop = false;
            private bool userpressedStop = false;
            #endregion 

            public void ReadText()
            {
                services = new List<Services>();
                string[] file = File.ReadAllLines(Application.StartupPath + @"\PortScannerCode\services.dat");

                foreach (string test in file)
                {
                    Regex mySplit = new Regex("/");
                    string text = test;
                    string[] stücke;
                    stücke = text.Split(new char[] { '\t' });
                    string service = stücke[0];
                    if (service != "unknown")
                    {
                        string[] portundprot = mySplit.Split(stücke[1]);
                        string portnumber = portundprot[0];
                        string protocol = portundprot[1];
                        ListViewItem item = new ListViewItem();
                        item.Checked = true;
                        item.Text = service;
                        item.SubItems.Add(portnumber);
                        item.SubItems.Add(protocol);
                        lv_Services.Items.Add(item);
                        services.Add(new Services { Port = portnumber, Protocol = protocol, Service = service });
                    }
                }
            }

            public string ReturnService (int port)
            { 
                Service = string.Empty;
                foreach (Services item in services)
                {
                    if (item.Port == Convert.ToString(port))
                    {
                        Service = item.Service;
                        return Service;
                    }
                }
                return Service;
            }

            public void lookForPort(int port)
            {
                Protocol = string.Empty;
                Service = string.Empty;
                foreach (Services item in services)
                {
                    if (item.Port == Convert.ToString(port))
                    {
                        Service = item.Service;
                        Protocol += item.Protocol + "  ";
                    }
                }
            }
            
            public List<int> PortArray()
            {
                portRange = new List<int>();
                foreach (ListViewItem item in lv_Services.Items)
                {
                    if (item.Checked == true)
                    {
                        port = Convert.ToInt32(item.SubItems[1].Text);
                        portRange.Add(port);
                    }
                }
                return portRange;
            }
        

        #region Properties
        private List<PortInformation> info = new List<PortInformation>();
        // private string address;
        # endregion

        private void radioButtonPortRange_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPortRange.Checked)
            {
                txt_End.Enabled = true;
                txt_Start.Enabled = true;
                comboBoxScanMode.Enabled = true;
            }
            else
            {
                txt_End.Enabled = false;
                txt_Start.Enabled = false;
                comboBoxScanMode.Enabled = false;
            }
        }

        private void raBuChoose_CheckedChanged(object sender, EventArgs e)
        {
            if (raBuChoose.Checked == false)
            {
                panelServicelist.Visible = false;
            }
            else
            {
                panelServicelist.Visible = true;
            }
        }

        private void timer_Listview_Tick(object sender, EventArgs e)
        {
            listViewFüllen();

            if (portScanner.ScanningActive && userpressedStop)
            {
                btn_Scan.Text = "Please wait";
                btn_Scan.Image = Properties.Resources.status_away;
                btn_Scan.ImageAlign = ContentAlignment.MiddleLeft;
            }
            if (portScanner.ScanningActive)
            {
                btn_Scan.Text = "Stop";
                btn_Scan.Image = Properties.Resources.control_stop;
                buttonOnStop = true;
                 // btn_Scan.Image = Properties.Resources
                 // btn_Scan.ImageAlign = ContentAlignment.MiddleCenter;
            }
            else 
            {
                btn_Scan.Text = "Start";
                btn_Scan.Image = Properties.Resources.control;
                buttonOnStop = false;
                   // btn_Scan.Image = Properties.Resources
                  // btn_Scan.ImageAlign = ContentAlignment.MiddleCenter;
            }
            //btn_Scan.Enabled = !portScanner.ScanningActive;
            //btn_Cancel.Enabled = portScanner.ScanningActive;
        }

        private void lv_Port_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvwColumnSorter = new ListViewColumnSorter();

            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            lv_Port.Sort();
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
                document.AddTitle("Portscanner Report");
                document.AddCreationDate();
                document.Open();
                document.Add(new Paragraph("Portscanner: IP/Port list", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, iTextSharp.text.Font.UNDERLINE)));
                document.Add(new Paragraph(" "));

                foreach (ListViewItem item in lv_Port.Items)
                {
                    document.Add(new Paragraph("IP:        " + item.SubItems[0].Text + item.SubItems[1].Text));
                    document.Add(new Paragraph("Port:     " + item.SubItems[1].Text));
                    document.Add(new Paragraph("Status:  " + item.SubItems[4].Text));
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

        private bool ipRichtig(string IP)
        {
            //schaut ob die IP eine richtige IP-Addresse ist
            return Regex.IsMatch(IP, @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$\b");
        }

        private bool portZahl(string a)
        {
            //schaut ob port auch ne Zahl ist
            return Regex.IsMatch(a, @"^[0-9]+$");
        }

        private void btn_Scan_Click(object sender, EventArgs e)
        {

            if (buttonOnStop)
            {
                portScanner.Stop();
                userpressedStop = true;
                return;
            }

            userpressedStop = false;
            List<Service> ScanList = new List<Service>();
            bool allesStimmt = false;
            int start;
            int end;
            string iP;
            string iPEnd;
            int difPort;
            int difIP;
            string IP1 = string.Empty;
            string IP2 = string.Empty;
            string IP3 = string.Empty;
            string IP4 = string.Empty;
            string IPRange = string.Empty;
            string toSplit = string.Empty;
            ScanList.Clear();
            lv_Port.Items.Clear();
            info.Clear();
            int waitForNextThread = 0;
            int requestTimeout = Convert.ToInt32(numericUpDownRequestTimeout.Value);
            if (comboBoxScanAttitude.SelectedItem == comboBoxScanAttitude.Items[1])
                waitForNextThread = Convert.ToInt32(numericUpDownTimebetweenRequests.Value);

            if (radioButton_IPrange.Checked)
            {
                toSplit = maskedTextBoxIP.Text;
                IPRange = txt_IPrange.Text;
            }
            else
            {
                toSplit = DNSServer();
                IPRange = string.Empty;
            }

            if (toSplit == string.Empty)
                return;

            string[] splitme = toSplit.Split(new Char[]{'.'});
            foreach (string split in splitme)
            {
                if (split == string.Empty)
                {
                    MessageBox.Show("Parts of the IP were left empty", "Input failure",MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            if (splitme.Length > 3)
            {
                IP1 = splitme[0].Replace(" ","");
                IP2 = splitme[1].Replace(" ","");
                IP3 = splitme[2].Replace(" ","");
                IP4 = splitme[3].Replace(" ","");
            }
            else { MessageBox.Show("Parts of the IP were left empty", "Input failure",MessageBoxButtons.OK, MessageBoxIcon.Hand);
            return;
            }
            

            if (IPRange == string.Empty)
                IPRange = splitme[3];
            try
            {   //bisschen verschachtelt alles was nicht zutrifft wirft ne Messagebox mit nem Fehler zurück
                if (Convert.ToInt32(IP4) <= Convert.ToInt32(IPRange))
                {
                    iP = IP1 + "." + IP2 + "." + IP3 + "." + IP4;
                    iPEnd = IP1 + "." + IP2 + "." + IP3 + "." + IPRange;


                    if (ipRichtig(iP) && ipRichtig(iPEnd))
                    {
                        allesStimmt = true;

                        if (radioButtonPortRange.Checked == true)
                        {
                            if(txt_Start.Text == string.Empty)
                            {
                                MessageBox.Show("You did choose a port range but the start port field is emtpy", "Input failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                            if (txt_End.Text == string.Empty)
                            {
                                txt_End.Text = txt_Start.Text;
                            }

                            if (portZahl(txt_End.Text) && portZahl(txt_Start.Text))
                            {

                                start = Convert.ToInt32(txt_Start.Text);
                                end = Convert.ToInt32(txt_End.Text);

                                if (start <= end)
                                {
                                    allesStimmt = true;

                                    ScanList.Clear();
                                    for (int i = start; i <= end; i++)
                                    {
                                        for (int iIP = Convert.ToInt32(IP4); iIP <= Convert.ToInt32(IPRange); iIP++)
                                        {
                                            Service service = new Service();
                                            service.ServiceName = ReturnService(i);
                                            service.Port = i;
                                            service.IP = IP1 + "." + IP2 + "." + IP3 + "." + iIP.ToString();
                                            ScanList.Add(service);
                                        }

                                    }
                                    if (start < 0 || end < 0)
                                    {
                                        allesStimmt = false;
                                        MessageBox.Show("The ports have to be positive", "Input failure",MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("The start port has to be lower than the end port", "Input failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    allesStimmt = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("You have to enter numbers for the ports", "Input failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                allesStimmt = false;
                            }
                        }

                        if (radioButtonWebserverSelected.Checked == true)
                        {
                            ScanList.Clear();
                            for (int iIP = Convert.ToInt32(IP4); iIP <= Convert.ToInt32(IPRange); iIP++)
                            {
                                Service serviceHttp = new Service();
                                serviceHttp.ServiceName = ReturnService(80);
                                serviceHttp.Port = 80;
                                serviceHttp.IP = IP1 + "." + IP2 + "." + IP3 + "." + iIP.ToString(); ;
                                ScanList.Add(serviceHttp);
                            }
                            for (int iIP = Convert.ToInt32(IP4); iIP <= Convert.ToInt32(IPRange); iIP++)
                            {
                                Service serviceHttps = new Service();
                                serviceHttps.ServiceName = ReturnService(443);
                                serviceHttps.Port = 443;
                                serviceHttps.IP = IP1 + "." + IP2 + "." + IP3 + "." + iIP.ToString(); ;
                                ScanList.Add(serviceHttps);
                            }
                        }
                        if (raBuChoose.Checked == true)
                        {
                            ScanList.Clear();
                            foreach (int zahl in PortArray())
                            {
                                for (int iIP = Convert.ToInt32(IP4); iIP <= Convert.ToInt32(IPRange); iIP++)
                                {
                                    Service serviceHttps = new Service();
                                    serviceHttps.ServiceName = ReturnService(zahl);
                                    serviceHttps.Port = zahl;
                                    serviceHttps.IP = IP1 + "." + IP2 + "." + IP3 + "." + iIP.ToString();
                                    ScanList.Add(serviceHttps);
                                }
                            }
                        }
                        difPort = ScanList.Count / (Convert.ToInt32(IPRange) - Convert.ToInt32(IP4) + 1);
                        difIP = Convert.ToInt32(IPRange) - Convert.ToInt32(IP4) + 1;
                        prg_Scannning.Value = 0;
                        //das Maximum ist die Anzahl der IP´s mal die Anzahl der zu überprüfenden Ports
                        prg_Scannning.Maximum = difIP * difPort;
                        prg_Scannning.Step = 1;

                        if (allesStimmt == true)
                        {
                            LastFinishedIndex = 0;
                            portScanner.RequestTimeout = requestTimeout;
                            portScanner.Waitfornextthread = waitForNextThread;
                            portScanner.StartScan(ScanList);
                            btn_Scan.Text = "Stop";
                            buttonOnStop = true;
                            btn_Scan.Image = Properties.Resources.control_stop;
                            btn_Scan.ImageAlign = ContentAlignment.MiddleLeft;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No valid IP", "Input failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        allesStimmt = false;
                    }
                }
                else
                {
                    MessageBox.Show("The start Ip has to be lower than the end IP", "Input failure", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    allesStimmt = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter numbers for the IP", "Input failure");
                allesStimmt = false;
            }
        }

        private void listViewFüllen()
        {
            //hier greift nur der Timer drauf zu, blockiert die Liste und schreibt in die Listview
            if (portScanner.FinishedServices.Count > LastFinishedIndex)
            {
                for (; LastFinishedIndex < portScanner.FinishedServices.Count; LastFinishedIndex++)
                {
                    Service service = portScanner.FinishedServices[LastFinishedIndex].TestedService;

                    ListViewItem Item = new ListViewItem();
                    Item.Text = service.IP;
                    Item.SubItems.Add(service.Port.ToString());
                    Item.SubItems.Add(service.ServiceName);
                    Item.SubItems.Add(service.Protocol.ToString());
                    if (portScanner.FinishedServices[LastFinishedIndex].Succeeded)
                        Item.SubItems.Add("Open");
                    else
                        Item.SubItems.Add("Closed");
                    lv_Port.Items.Add(Item);
                    prg_Scannning.PerformStep();
                }
            }
        }

        private string DNSServer()
        {
            string firstAddress = string.Empty;
            try
            {
                string HostName = textBoxAddress.Text;
                if (HostName.StartsWith("http://"))
                {
                   HostName =  HostName.Replace("http://", "");
                }
                if (HostName.StartsWith("https://"))
                {
                    HostName = HostName.Replace("https://","");
                }
                if (HostName.StartsWith("www."))
                {
                    HostName = HostName.Replace("www.", "");
                }
                IPHostEntry NameToIpAddress;
                NameToIpAddress = Dns.GetHostEntry(HostName);
                if (NameToIpAddress.AddressList.Length <1)
                {
                     MessageBox.Show("Could not get the matching IP-address", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return firstAddress;
                }
                firstAddress = NameToIpAddress.AddressList[0].ToString();
                return firstAddress;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim resolven" + ex);
                MessageBox.Show("Could not get the matching IP-address", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return firstAddress;
            }
        }

        private void comboBoxScanMode_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (comboBoxScanMode.SelectedItem == comboBoxScanMode.Items[1])
            {
                txt_Start.Text = "0";
                txt_End.Text = "1023";
                txt_Start.ReadOnly = true;
                txt_End.ReadOnly = true;
            }
            else if (comboBoxScanMode.SelectedItem == comboBoxScanMode.Items[2])
            {
                txt_Start.Text = "1024";
                txt_End.Text = "49151";
                txt_Start.ReadOnly = true;
                txt_End.ReadOnly = true;
            }
            else if (comboBoxScanMode.SelectedItem == comboBoxScanMode.Items[3])
            {
                txt_Start.Text = "49152";
                txt_End.Text = "65535";
                txt_Start.ReadOnly = true;
                txt_End.ReadOnly = true;
            }
            else if (comboBoxScanMode.SelectedItem == comboBoxScanMode.Items[4])
            {
                txt_Start.Text = "0";
                txt_End.Text = "65535";
                txt_Start.ReadOnly = true;
                txt_End.ReadOnly = true;
            }
            else
            {
                txt_Start.ReadOnly = false;
                txt_End.ReadOnly = false;
            }
        }

        private void comboBoxScanAttitude_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxScanAttitude.SelectedItem == comboBoxScanAttitude.Items[0])
            {
                labelmsunvisible.Visible = false;
                numericUpDownTimebetweenRequests.Visible = false;
            }
            else
            {
                labelmsunvisible.Visible = true;
                numericUpDownTimebetweenRequests.Visible = true;
            }
        }

        private void radioButtonHostAddress_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAddress.Enabled = radioButtonHostAddress.Checked;
            maskedTextBoxIP.Enabled = !radioButtonHostAddress.Checked;
            txt_IPrange.Enabled = !radioButtonHostAddress.Checked;
        }

    }
}
