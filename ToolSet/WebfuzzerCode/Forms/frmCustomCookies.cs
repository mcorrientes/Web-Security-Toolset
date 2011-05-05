using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace WebFuzzer
{
    public partial class frmCustomCookies : Form
    {
        public CookieCollection CookieCol;

        public frmCustomCookies()
        {
            InitializeComponent();
            CookieCol = new CookieCollection();
        }

        private void buttonAddCookie_Click(object sender, EventArgs e)
        {
            CookieCol.Add(new Cookie(textBoxCookieName.Text, textBoxCookieValue.Text));
            ListViewItem Item = new ListViewItem(textBoxCookieName.Text);
            Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = textBoxCookieValue.Text });
            listViewCookies.Items.Add(Item);
        }

        private void buttonClearCookies_Click(object sender, EventArgs e)
        {
            CookieCol = new CookieCollection();
            listViewCookies.Items.Clear();
        }
    }
}
