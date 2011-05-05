using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace PortScanner
{
    public partial class MainForm : Form
    {
        private frmServiceList readText = new frmServiceList();
        private ListViewColumnSorter lvwColumnSorter;
        private PortScanner portScanner;
        private int LastFinishedIndex;

        public MainForm()
        {
            InitializeComponent();
            portScanner = new PortScanner();
            LastFinishedIndex = 0;
            //Textfile muss zuerst geladen werden
            readText.ReadText();
            timer_Listview.Start();
        }

        #region Properties
        private List<PortInformation> info = new List<PortInformation>();
        // private string address;
        # endregion

        private void formularVerschieben()
        {
            //dadurch klebt das zweite Formular am Hauptformular
            readText.Location = new Point(Location.X + Width, Location.Y);
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            formularVerschieben();
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
            List<Service> ScanList = new List<Service>();
            bool allesStimmt = false;
            int start;
            int end;
            string iP;
            string iPEnd;
            int difPort;
            int difIP;

            ScanList.Clear();
            lv_Port.Items.Clear();
            info.Clear();


            if (txt_IPrange.Text == string.Empty)
                txt_IPrange.Text = txt_IP4.Text;
            try
            {   //bisschen verschachtelt alles was nicht zutrifft wirft ne Messagebox mit nem Fehler zurück
                if (Convert.ToInt32(txt_IP4.Text) <= Convert.ToInt32(txt_IPrange.Text))
                {
                    iP = txt_IP1.Text + "." + txt_IP2.Text + "." + txt_IP3.Text + "." + txt_IP4.Text;
                    iPEnd = txt_IP1.Text + "." + txt_IP2.Text + "." + txt_IP3.Text + "." + txt_IPrange.Text;


                    if (ipRichtig(iP) && ipRichtig(iPEnd))
                    {
                        allesStimmt = true;

                        if (radioButton1.Checked == true)
                        {
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
                                        for (int iIP = Convert.ToInt32(txt_IP4.Text); iIP <= Convert.ToInt32(txt_IPrange.Text); iIP++)
                                        {
                                            Service service = new Service();
                                            service.ServiceName = readText.ReturnService(i);
                                            service.Port = i;
                                            service.IP = txt_IP1.Text + "." + txt_IP2.Text + "." + txt_IP3.Text + "." + iIP.ToString();
                                            ScanList.Add(service);
                                        }

                                    }
                                    if (start < 0 || end < 0)
                                    {
                                        allesStimmt = false;
                                        MessageBox.Show("The ports have to be positive", "Input failure");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("The start port has to be lower than the end port", "Input failure");
                                    allesStimmt = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("You have to enter numbers for the ports", "Input failure");
                                allesStimmt = false;
                            }
                        }

                        if (radioButton2.Checked == true)
                        {
                            ScanList.Clear();
                            for (int iIP = Convert.ToInt32(txt_IP4.Text); iIP <= Convert.ToInt32(txt_IPrange.Text); iIP++)
                            {
                                Service serviceHttp = new Service();
                                serviceHttp.ServiceName = readText.ReturnService(80);
                                serviceHttp.Port = 80;
                                serviceHttp.IP = txt_IP1.Text + "." + txt_IP2.Text + "." + txt_IP3.Text + "." + iIP.ToString(); ;
                                ScanList.Add(serviceHttp);
                            }
                            for (int iIP = Convert.ToInt32(txt_IP4.Text); iIP <= Convert.ToInt32(txt_IPrange.Text); iIP++)
                            {
                                Service serviceHttps = new Service();
                                serviceHttps.ServiceName = readText.ReturnService(443);
                                serviceHttps.Port = 443;
                                serviceHttps.IP = txt_IP1.Text + "." + txt_IP2.Text + "." + txt_IP3.Text + "." + iIP.ToString(); ;
                                ScanList.Add(serviceHttps);
                            }
                        }
                        if (raBuChoose.Checked == true)
                        {
                            ScanList.Clear();
                            foreach (int zahl in readText.PortArray())
                            {
                                for (int iIP = Convert.ToInt32(txt_IP4.Text); iIP <= Convert.ToInt32(txt_IPrange.Text); iIP++)
                                {
                                    Service serviceHttps = new Service();
                                    serviceHttps.ServiceName = readText.ReturnService(zahl);
                                    serviceHttps.Port = zahl;
                                    serviceHttps.IP = txt_IP1.Text + "." + txt_IP2.Text + "." + txt_IP3.Text + "." + iIP.ToString();
                                    ScanList.Add(serviceHttps);
                                }
                            }
                        }
                        difPort = ScanList.Count / (Convert.ToInt32(txt_IPrange.Text) - Convert.ToInt32(txt_IP4.Text) + 1);
                        difIP = Convert.ToInt32(txt_IPrange.Text) - Convert.ToInt32(txt_IP4.Text) + 1;
                        prg_Scannning.Value = 0;
                        //das Maximum ist die Anzahl der IP´s mal die Anzahl der zu überprüfenden Ports
                        prg_Scannning.Maximum = difIP * difPort;
                        prg_Scannning.Step = 1;

                        if (allesStimmt == true)
                        {
                            btn_Scan.Enabled = false;
                            btn_Cancel.Enabled = true;
                            LastFinishedIndex = 0;
                            portScanner.StartScan(ScanList);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No valid IP", "Input failure");
                        allesStimmt = false;
                    }
                }
                else
                {
                    MessageBox.Show("The start Ip has to be lower than the end IP", "Input failure");
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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            portScanner.Stop();
            btn_Cancel.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false)
            {
                txt_End.Enabled = false;
                txt_Start.Enabled = false;
            }
            else
            {
                txt_End.Enabled = true;
                txt_Start.Enabled = true;
            }
        }

        private void raBuChoose_CheckedChanged(object sender, EventArgs e)
        {
            if (raBuChoose.Checked == false)
            {
                readText.Hide();
            }
            else
            {
                readText.Show(this);
                formularVerschieben();
            }
        }

        private void timer_Listview_Tick(object sender, EventArgs e)
        {   //der Timer aktualisiert jede Sekunde die Listview
            listViewFüllen();

            btn_Scan.Enabled = !portScanner.ScanningActive;
            btn_Cancel.Enabled = portScanner.ScanningActive;
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
    }
}
