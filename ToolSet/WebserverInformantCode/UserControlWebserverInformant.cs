using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ToolSet.WebserverInformantCode
{
    public partial class UserControlWebserverInformant : UserControl
    {
        public UserControlWebserverInformant()
        {
            InitializeComponent();
        }

        #region Properties
        private string überarbeitet = string.Empty;
        private string endURL = string.Empty;
        #endregion 

        private void btn_Start_Click(object sender, EventArgs e)
        {
            UseNslookUp(txt_Domain.Text);
        }

        private void UseNslookUp(string url)
        {
            btn_Start.Enabled = false;
            //nslookup funktioniert am besten wenn nur domain also ohne www oder http übergeben wird
            //funktioniert zwar anders auch nur die Ausgabe ist nciht so detailiert
            if (url.StartsWith("http://"))
            {
                überarbeitet = url.Replace("http://", "");
            }
            else if (url.StartsWith("https://"))
            {
                überarbeitet = url.Replace("https://", "");
            }
            else überarbeitet = url;

            if (überarbeitet.StartsWith("www."))
            {
                endURL = überarbeitet.Replace("www.", "");
            }
            else endURL = überarbeitet;

            try
            {
                //Zugriff auf des Windows interne Programm nslookup 
                Process lookup = new Process();
                lookup.StartInfo.FileName = "nslookup.exe";
                lookup.StartInfo.CreateNoWindow = true;
                lookup.StartInfo.UseShellExecute = false;
                lookup.StartInfo.RedirectStandardOutput = true;
                lookup.StartInfo.RedirectStandardInput = true;
                lookup.Start();
                lookup.StandardInput.WriteLine("set type=any");
                lookup.StandardInput.WriteLine(endURL);
                lookup.StandardInput.WriteLine("exit");
                lookup.StandardInput.Flush();
                string output = lookup.StandardOutput.ReadToEnd();
                txt_Output.AppendText("\r\n");
                txt_Output.AppendText("-------Server: Lookup-------");
                txt_Output.AppendText("\r\n");
                // die ersten 5 zeilen sind Müll
                Regex Splitter = new Regex("\r\n");
                string[] splitted = Splitter.Split(output);

                for (int i = 5; i < splitted.Length; i++)
                {
                    txt_Output.AppendText(splitted[i] + "\r\n");
                }

                if (lookup.ExitCode == 0)
                    txt_Output.AppendText(lookup.StandardOutput.ReadToEnd());
                txt_Output.AppendText("\r\n");
                txt_Output.AppendText("-------Server: Details-------");
                txt_Output.AppendText("\r\n");
            }
            catch (Exception)
            {
                btn_Start.Enabled = true;
                txt_Output.AppendText("Could not process information");
            }
            TryConnection(txt_Domain.Text);
        }

        // is nich drin
        private void Connect()
        {
            string HostName = txt_Domain.Text;
            Console.WriteLine("Looking up: " + HostName + "\r\n");
            IPHostEntry NameToIpAddress;
            NameToIpAddress = Dns.GetHostEntry(HostName);
            int AddressCount = 0;
            foreach (IPAddress Address in NameToIpAddress.AddressList)
                Console.WriteLine(" IP Address " + (++AddressCount) + ":" + Address.ToString() + "\r\n");
            //TryConnection(HostName);
        }

        private void TryConnection(string domain)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //funktioniert nicht wenn die Eingabe nicht mit http oder https beginnt
                if (!domain.StartsWith("http://") &&
                    !domain.StartsWith("https://"))
                {
                    domain = "http://" + domain;
                }
                //einfach nur die header auslesen
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(domain);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                request.Accept = "text/plain";
                txt_Output.AppendText("\r\n");
                txt_Output.AppendText("Server Information: \r\n");
                txt_Output.AppendText("  Server: " + response.Server + "\r\n");
                txt_Output.AppendText("  Protocol version: " + response.ProtocolVersion + "\r\n");
                txt_Output.AppendText("  Status code: " + response.StatusCode + "\r\n");
                txt_Output.AppendText("  Status description: " + response.StatusDescription + "\r\n");
                txt_Output.AppendText("  Content encoding: " + response.ContentEncoding + "\r\n");
                txt_Output.AppendText("  Content length: " + response.ContentLength + "\r\n");
                txt_Output.AppendText("  Last Modified: " + response.LastModified + "\r\n");
                txt_Output.AppendText("  Length using method: " + response.GetResponseHeader("Content-Length") + "\r\n");

                Regex splitter = new Regex("\r\n");
                string[] splitted = splitter.Split(response.Headers.ToString());
                foreach (string split in splitted)
                {
                    if (split.StartsWith("Server:"))
                    { }
                    else { txt_Output.AppendText("  " + split + "\r\n"); }
                }
            }
            catch (Exception)
            {
                txt_Output.AppendText("\r\n");
                txt_Output.AppendText("Server has not responded");
                Cursor.Current = Cursors.Default;
                btn_Start.Enabled = true;
            }
            Cursor.Current = Cursors.Default;
            btn_Start.Enabled = true;
        }

        private void txt_Domain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                UseNslookUp(txt_Domain.Text);
        }
    }
}
