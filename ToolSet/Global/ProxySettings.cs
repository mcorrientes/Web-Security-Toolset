using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ToolSet.Global
{
   public partial class ProxySettings : Form
   {
      public ProxySettings()
      {
         InitializeComponent();
      }

      protected override void OnLoad(EventArgs e)
      {
         base.OnLoad(e);

         chkUseProxy.Checked = Settings.UseProxy;

         if (Settings.Proxy != null)
         {
            txtProxyHost.Text = Settings.Proxy.Address.Host;
            txtProxyPort.Text = Settings.Proxy.Address.Port.ToString();
            txtProxyUser.Text = Settings.Proxy.Credentials.GetCredential(Settings.Proxy.Address,"").UserName;
         }
      }

      private void btnOkClick(object sender, EventArgs e)
      {
         var proxy = new WebProxy(this.txtProxyHost.Text, Int32.Parse(this.txtProxyPort.Text));

         if (txtProxyUser.Text.Length > 0)
            proxy.Credentials = new NetworkCredential(txtProxyUser.Text, txtProxyPass.Text);

         Settings.Proxy = proxy;
         Settings.UseProxy = chkUseProxy.Checked;
         DialogResult = System.Windows.Forms.DialogResult.OK;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         DialogResult = System.Windows.Forms.DialogResult.Cancel;
      }
   }
}
