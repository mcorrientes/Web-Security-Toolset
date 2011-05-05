using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ScanServerManager.Components;
using System.Net;

namespace ToolSet.HTTPSnifferCode
{
    public partial class UserControlHTTPSniffer : UserControl
    {

        private ProxyManager proxyManager;
        private bool Listening;
        private int LastProxyOutputIndex;
        private List<ProxyRequest> Requests;

        public UserControlHTTPSniffer()
        {
            InitializeComponent();

            proxyManager = new ProxyManager();
            Listening = false;
            LastProxyOutputIndex = 0;
            Requests = new List<ProxyRequest>();
        }

        private void buttonListen_Click(object sender, EventArgs e)
        {
            if (Listening)
            {
                buttonListen.Enabled = false;
                proxyManager.Stop();
            }
            else
            {
                Listening = true;
                buttonListen.Text = "Stop Listening";
                LastProxyOutputIndex = 0;

                int Port = Convert.ToInt32(numericUpDownSnifferPort.Value);
                proxyManager = new ProxyManager();
                proxyManager.StartProxy(Port);
            }
        }

        private void timerGUI_Tick(object sender, EventArgs e)
        {
            if (Listening)
            {
                UpdateGUI();
                if (!proxyManager.ProxyActive)
                {
                    Listening = false;
                    buttonListen.Text = "Listen";
                    buttonListen.Enabled = true;
                }
            }
        }

        private void UpdateGUI()
        {
            for (; LastProxyOutputIndex < proxyManager.Output.Requests.Count; LastProxyOutputIndex++)
            {
                ProxyRequest proxyRequest = proxyManager.Output.Requests[LastProxyOutputIndex];
                Requests.Add(proxyRequest);

                ListViewItem Item = new ListViewItem();
                Item.Text = proxyRequest.RequestTime.ToLongTimeString();
                Item.SubItems.Add(proxyRequest.URL);
                Item.SubItems.Add(proxyRequest.POST);
                listViewSnifferOutput.Items.Add(Item);
            }
        }

        private void listViewSnifferOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSnifferOutput.SelectedIndices.Count == 0)
                return;

            int Index = listViewSnifferOutput.SelectedIndices[0];
            ProxyRequest proxyRequest = Requests[Index];
            listViewInfo.Items[0].SubItems[1].Text = proxyRequest.URL;
            listViewInfo.Items[1].SubItems[1].Text = proxyRequest.RequestTime.ToLongTimeString();
            richTextBoxPOST.Text = proxyRequest.POST;
            richTextBoxRequestHeaders.Text = proxyRequest.RequestHeaders;
            richTextBoxResponseHeaders.Text = proxyRequest.ResponseHeaders;
            richTextBoxSource.Text = proxyRequest.Data;
            webBrowserSource.DocumentText = proxyRequest.Data;
        }

        private string HeadersToString(WebHeaderCollection Headers)
        {
            string Output = string.Empty;
            for (int i = 0; i < Headers.Count; i++)
            {
                Output += Headers.GetKey(i) + ": " + Headers[i] + "\r\n";
            }

            return Output;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            proxyManager.Stop();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.label1,"The proxy port you defined in your browser settings.");
        }
        

    }
}
