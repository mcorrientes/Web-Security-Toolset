using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using ToolSet.CustomRequestCode.Components;
using usertools.CustomRequest;

namespace ToolSet.CustomRequestCode
{
    public partial class UserControlCustomRequest : UserControl
    {
        
        private CookieCollection cookieCollection;
        private NetworkCredential netCred;
        
        public UserControlCustomRequest()
        {
            InitializeComponent();
            toolStripComboBoxMethod.SelectedIndex = 0;
            toolStripComboBoxProtocol.SelectedIndex = 0;
            FillComboboxRequestHeaders();
            cookieCollection = new CookieCollection();
            netCred = new NetworkCredential();
        }

        List<string> headers;

        private string username = string.Empty;
        private string password = string.Empty;

        private void FillComboboxRequestHeaders()
        {
            RequestHeaders[] headers = (RequestHeaders[])Enum.GetValues(typeof(RequestHeaders));
            foreach (RequestHeaders header in headers)
            {
                comboBoxRequestHeaders.Items.Add(header.ToString());
            }
            comboBoxRequestHeaders.SelectedIndex = 0;
        }

        private void buttonAddToList_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Text = comboBoxRequestHeaders.Text;
            item.SubItems.Add(textBoxHeaderValue.Text);
            listViewRequestHeaders.Items.Add(item);
        }

        private void toolStripButtonSendRequest_Click(object sender, EventArgs e)
        {
            if (FieldsValid())
            {
                bool mediatype = false;
                string URL = string.Empty;
                string Post = string.Empty;
                headers = new List<string>();
                listViewResponseHeaders.Items.Clear();
                richTextBoxSource.Text = "";
                webBrowserSource.Navigate("about:blank");

                URL = toolStripTextBoxURL.Text;


                if (toolStripComboBoxMethod.SelectedIndex == 1)
                    Post = richTextBoxPOST.Text;

                if (listViewRequestHeaders.Items.Count > 0)
                    foreach (ListViewItem item in listViewRequestHeaders.Items)
                    {
                        if (item.SubItems.Count > 1)
                            headers.Add(item.Text + ":" + item.SubItems[1].Text);
                    }

                if (toolStripComboBoxProtocol.SelectedIndex == 0)
                    mediatype = true;
                else mediatype = false;

                CreateWebrequest webrequest = new CreateWebrequest();
                webrequest.netCredentials = netCred;
                webrequest.CustomCookieCollection = cookieCollection;

                string HTML = webrequest.StringGetWebPage(URL, Post, headers, mediatype);
                richTextBoxSource.Text = HTML;
                webBrowserSource.DocumentText = HTML;
                if (webrequest.Response != null)
                {
                    for (int i = 0; i < webrequest.Response.Headers.Count; i++)
                    {
                        ListViewItem Item = new ListViewItem();
                        Item.Text = webrequest.Response.Headers.Keys[i];

                        string Value = string.Empty;
                        string[] HeaderValues = webrequest.Response.Headers.GetValues(i);
                        for (int iHv = 0; iHv < HeaderValues.Length; iHv++)
                        {
                            Value += HeaderValues[iHv] + " ";
                        }
                        Item.SubItems.Add(Value);

                        listViewResponseHeaders.Items.Add(Item);
                    }
                }
            }
        }


        private bool FieldsValid()
        {
            if (toolStripComboBoxMethod.SelectedIndex == 1 && richTextBoxPOST.Text == string.Empty)
            {
                MessageBox.Show("You selected Method Post, but you did not define a post");
                return false;
            }
            else if (!toolStripTextBoxURL.Text.StartsWith("htt"))
            {
                MessageBox.Show("Please write the URL with http:// or https://");
                return false;
            }

            return true;
        }

        private void listViewRequestHeaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool Enable = listViewRequestHeaders.SelectedIndices.Count > 0;
            buttonDeleteHeader.Enabled = Enable;
        }

        private void buttonDeleteHeader_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewRequestHeaders.SelectedItems)
            {
                item.Remove();
            }
        }

        private void toolStripButtonCookies_Click(object sender, EventArgs e)
        {
            frmCustomCookies frmCookie = new frmCustomCookies();
            if (frmCookie.ShowDialog() == DialogResult.OK)
                this.cookieCollection = frmCookie.CookieCol;
        }

        private void toolStripButtonAuthType_Click(object sender, EventArgs e)
        {
            frmAuthentication frmAuth = new frmAuthentication();
            if (frmAuth.ShowDialog() == DialogResult.OK)
            {
                this.netCred.UserName = frmAuth.textBoxUsername.Text;
                this.netCred.Password = frmAuth.textBoxPassword.Text;
                if (!(frmAuth.textBoxDomain.Text == string.Empty))
                    this.netCred.Domain = frmAuth.textBoxDomain.Text;
            }
        }



    }
}
