using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using usertools.CustomRequest;
using ToolSet.InjectionBrowsercode.Components;

namespace ToolSet.InjectionBrowsercode
{
    public partial class UserControlInjectionBrowser : UserControl
    {
        private bool attacking;
        private List<AttackedUrl> AttackedUrls;

        public UserControlInjectionBrowser()
        {
            InitializeComponent();
            attacking = true;
            AttackedUrls = new List<AttackedUrl>();
        }

        private void cEXWB1_DownloadRequestSynch(object sender, csExWB.SynchDownloadRequestEventArgs e)
        {
            if (attacking)
            {
                e.ClientHandled = false;
                e.CancelDownload = false;
                if (e.Post != null)
                {
                    string POST = Encoding.UTF8.GetString(e.Post as byte[]);
                    AttackPOST(e.Url, POST);
                }
                else
                    AttackURL(e.Url);
            }
        }

        private void cEXWB1_DownloadRequestAsynch(object sender, csExWB.AsynchDownloadRequestEventArgs e)
        {
            if (attacking)
            {
                e.ClientHandled = false;
                e.CancelDownload = false;
                if (e.Post != null)
                {
                    string POST = Encoding.UTF8.GetString(e.Post as byte[]);
                    AttackPOST(e.Url, POST);
                }
                else
                    AttackURL(e.Url);
            }
        }

        private void buttonBrowserGo_Click(object sender, EventArgs e)
        {
            cEXWB1.Navigate(textBoxBrowserURL.Text);
        }

        private void buttonBrowserForw_Click(object sender, EventArgs e)
        {
            cEXWB1.GoForward();
        }

        private void buttonBrowserBack_Click(object sender, EventArgs e)
        {
            cEXWB1.GoBack();
        }

        private void cEXWB1_NavigateComplete2(object sender, csExWB.NavigateComplete2EventArgs e)
        {
            buttonBrowserBack.Enabled = cEXWB1.CanGoBack;
            buttonBrowserForw.Enabled = cEXWB1.CanGoForward;
            textBoxBrowserURL.Text = e.url;
        }

        private void listViewResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewResult.SelectedIndices.Count == 0)
                return;

            int Index = listViewResult.SelectedIndices[0];
            webBrowserResult.DocumentText = AttackedUrls[Index].HTML;
            richTextBoxSourceCode.Text = AttackedUrls[Index].HTML;
            richTextBoxOriginalPOST.Text = AttackedUrls[Index].OriginalPOST;
            richTextBoxModifiedPOST.Text = AttackedUrls[Index].ModifiedPOST;
            listViewResultInfo.Items[0].SubItems[1].Text = AttackedUrls[Index].OriginalURL;
            listViewResultInfo.Items[1].SubItems[1].Text = AttackedUrls[Index].ModifiedURL;
        }


        private void ClearAttackBrowser()
        {
            //attackBrowser = new csExWB.cEXWB();
            //attackBrowser.Visible = false;
            //attackBrowser.Silent = true;
            //attackBrowser.RegisterAsBrowser = true;
        }

        private void AttackURL(string URL)
        {
            if (!URL.Contains("?"))
                return;

            for (int i = 0; i < AttackedUrls.Count; i++)
            {
                if (AttackedUrls[i].OriginalURL == URL && string.IsNullOrEmpty(AttackedUrls[i].OriginalPOST))
                    return;
            }

            string Query = URL.Substring(URL.IndexOf('?') + 1);
            string BeforeQuery = URL.Substring(0, URL.IndexOf('?') + 1);

            QueryModifier queryModifier = new QueryModifier(Query);
            if (queryModifier.ParameterCount != 0)
            {
                do
                {
                    string NewURL = BeforeQuery + queryModifier.GetModifiedQuery(textBoxModifier.Text);

                    DateTime Start = DateTime.Now;
                    CreateWebrequest Request = new CreateWebrequest();
                    string HTML = Request.StringGetWebPage(NewURL, string.Empty, new List<string>(), false);
                    AttackedUrl attackedURL = new AttackedUrl();
                    attackedURL.HTML = HTML;
                    attackedURL.OriginalURL = URL;
                    attackedURL.ModifiedURL = NewURL;
                    AttackedUrls.Add(attackedURL);
                    ClearAttackBrowser();

                    ListViewItem Item = new ListViewItem();
                    Item.Text = NewURL;
                    Item.SubItems.Add(string.Empty);
                    listViewResult.Items.Add(Item);
                }
                while (queryModifier.NextParameter());
            }
        }

        private void AttackPOST(string URL, string POST)
        {
            if (string.IsNullOrEmpty(POST))
                return;

            for (int i = 0; i < AttackedUrls.Count; i++)
            {
                if (AttackedUrls[i].OriginalURL == URL && AttackedUrls[i].OriginalPOST == POST)
                    return;
            }

            QueryModifier queryModifier = new QueryModifier(POST);
            if (queryModifier.ParameterCount == 0)
                return;

            do
            {
                string NewPOST = queryModifier.GetModifiedQuery(textBoxModifier.Text);

                DateTime Start = DateTime.Now;

                CreateWebrequest Request = new CreateWebrequest();
                string HTML = Request.StringGetWebPage(URL, POST, new List<string>(), false);
                AttackedUrl attackedURL = new AttackedUrl();
                attackedURL.HTML = HTML;
                attackedURL.OriginalPOST = POST;
                attackedURL.OriginalURL = URL;
                attackedURL.ModifiedPOST = NewPOST;
                AttackedUrls.Add(attackedURL);
                ClearAttackBrowser();

                ListViewItem Item = new ListViewItem();
                Item.Text = URL;
                Item.SubItems.Add(NewPOST);
                listViewResult.Items.Add(Item);
            }
            while (queryModifier.NextParameter());
        }
    }
}