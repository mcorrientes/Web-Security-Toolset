namespace ToolSet.SudomainScannerCode
{
    partial class UserControlSubdomainScanner
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richTextBoxSourceHTTPs = new System.Windows.Forms.RichTextBox();
            this.listViewServers = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.webBrowserSourceHTTPs = new System.Windows.Forms.WebBrowser();
            this.listViewResponseHeadersHTTPs = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.progressBarDnsChecks = new System.Windows.Forms.ProgressBar();
            this.progressBarTargetFinder = new System.Windows.Forms.ProgressBar();
            this.timerGUI = new System.Windows.Forms.Timer(this.components);
            this.textBoxCustomDNS = new System.Windows.Forms.TextBox();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.comboBoxDnsServer = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDomain = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listViewResponseHeaders = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBoxSource = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.webBrowserSource = new System.Windows.Forms.WebBrowser();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxSourceHTTPs
            // 
            this.richTextBoxSourceHTTPs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxSourceHTTPs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSourceHTTPs.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxSourceHTTPs.Name = "richTextBoxSourceHTTPs";
            this.richTextBoxSourceHTTPs.Size = new System.Drawing.Size(778, 199);
            this.richTextBoxSourceHTTPs.TabIndex = 0;
            this.richTextBoxSourceHTTPs.Text = "";
            // 
            // listViewServers
            // 
            this.listViewServers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
            this.listViewServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewServers.FullRowSelect = true;
            this.listViewServers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewServers.HideSelection = false;
            this.listViewServers.Location = new System.Drawing.Point(0, 0);
            this.listViewServers.MultiSelect = false;
            this.listViewServers.Name = "listViewServers";
            this.listViewServers.Size = new System.Drawing.Size(800, 261);
            this.listViewServers.TabIndex = 0;
            this.listViewServers.UseCompatibleStateImageBehavior = false;
            this.listViewServers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Protocol";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Server";
            this.columnHeader1.Width = 195;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Hostname";
            this.columnHeader2.Width = 132;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Web Server";
            this.columnHeader4.Width = 136;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Banner";
            this.columnHeader3.Width = 246;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.richTextBoxSourceHTTPs);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(784, 205);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Source Code";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // webBrowserSourceHTTPs
            // 
            this.webBrowserSourceHTTPs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserSourceHTTPs.Location = new System.Drawing.Point(3, 3);
            this.webBrowserSourceHTTPs.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserSourceHTTPs.Name = "webBrowserSourceHTTPs";
            this.webBrowserSourceHTTPs.Size = new System.Drawing.Size(778, 199);
            this.webBrowserSourceHTTPs.TabIndex = 0;
            // 
            // listViewResponseHeadersHTTPs
            // 
            this.listViewResponseHeadersHTTPs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewResponseHeadersHTTPs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9});
            this.listViewResponseHeadersHTTPs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResponseHeadersHTTPs.FullRowSelect = true;
            this.listViewResponseHeadersHTTPs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewResponseHeadersHTTPs.HideSelection = false;
            this.listViewResponseHeadersHTTPs.Location = new System.Drawing.Point(3, 3);
            this.listViewResponseHeadersHTTPs.MultiSelect = false;
            this.listViewResponseHeadersHTTPs.Name = "listViewResponseHeadersHTTPs";
            this.listViewResponseHeadersHTTPs.Size = new System.Drawing.Size(778, 199);
            this.listViewResponseHeadersHTTPs.TabIndex = 0;
            this.listViewResponseHeadersHTTPs.UseCompatibleStateImageBehavior = false;
            this.listViewResponseHeadersHTTPs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Header Name";
            this.columnHeader8.Width = 223;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Header Value";
            this.columnHeader9.Width = 371;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.webBrowserSourceHTTPs);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(784, 205);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "Browser";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // progressBarDnsChecks
            // 
            this.progressBarDnsChecks.Location = new System.Drawing.Point(422, 2);
            this.progressBarDnsChecks.Name = "progressBarDnsChecks";
            this.progressBarDnsChecks.Size = new System.Drawing.Size(176, 10);
            this.progressBarDnsChecks.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarDnsChecks.TabIndex = 0;
            // 
            // progressBarTargetFinder
            // 
            this.progressBarTargetFinder.Location = new System.Drawing.Point(604, 2);
            this.progressBarTargetFinder.Name = "progressBarTargetFinder";
            this.progressBarTargetFinder.Size = new System.Drawing.Size(176, 10);
            this.progressBarTargetFinder.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarTargetFinder.TabIndex = 0;
            // 
            // timerGUI
            // 
            this.timerGUI.Enabled = true;
            this.timerGUI.Interval = 1000;
            this.timerGUI.Tick += new System.EventHandler(this.timerGUI_Tick);
            // 
            // textBoxCustomDNS
            // 
            this.textBoxCustomDNS.Location = new System.Drawing.Point(552, 25);
            this.textBoxCustomDNS.Name = "textBoxCustomDNS";
            this.textBoxCustomDNS.ReadOnly = true;
            this.textBoxCustomDNS.Size = new System.Drawing.Size(152, 20);
            this.textBoxCustomDNS.TabIndex = 5;
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Items.AddRange(new object[] {
            "Complete Search",
            "Partial Search (Medium)",
            "Partial Search (Small)"});
            this.comboBoxSearch.Location = new System.Drawing.Point(245, 25);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(129, 21);
            this.comboBoxSearch.TabIndex = 4;
            // 
            // comboBoxDnsServer
            // 
            this.comboBoxDnsServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDnsServer.FormattingEnabled = true;
            this.comboBoxDnsServer.Items.AddRange(new object[] {
            "Use DNS Server Of Domain",
            "Use Custom DNS Server"});
            this.comboBoxDnsServer.Location = new System.Drawing.Point(380, 25);
            this.comboBoxDnsServer.Name = "comboBoxDnsServer";
            this.comboBoxDnsServer.Size = new System.Drawing.Size(166, 21);
            this.comboBoxDnsServer.TabIndex = 4;
            this.comboBoxDnsServer.SelectedIndexChanged += new System.EventHandler(this.comboBoxDnsServer_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxCustomDNS);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxSearch);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxDnsServer);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxDomain);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 600);
            this.splitContainer1.SplitterDistance = 55;
            this.splitContainer1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Domain";
            // 
            // textBoxDomain
            // 
            this.textBoxDomain.Location = new System.Drawing.Point(12, 25);
            this.textBoxDomain.Name = "textBoxDomain";
            this.textBoxDomain.Size = new System.Drawing.Size(227, 20);
            this.textBoxDomain.TabIndex = 1;
            this.textBoxDomain.Text = "testsite.com";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Image = global::ToolSet.Properties.Resources.control;
            this.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearch.Location = new System.Drawing.Point(710, 23);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(82, 23);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewServers);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(800, 541);
            this.splitContainer2.SplitterDistance = 261;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.progressBarDnsChecks);
            this.splitContainer3.Panel2.Controls.Add(this.progressBarTargetFinder);
            this.splitContainer3.Panel2MinSize = 10;
            this.splitContainer3.Size = new System.Drawing.Size(800, 276);
            this.splitContainer3.SplitterDistance = 257;
            this.splitContainer3.TabIndex = 1;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(800, 257);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tabControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(792, 231);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "HTTP";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 231);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewResponseHeaders);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(784, 205);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Response Headers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listViewResponseHeaders
            // 
            this.listViewResponseHeaders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewResponseHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listViewResponseHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResponseHeaders.FullRowSelect = true;
            this.listViewResponseHeaders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewResponseHeaders.HideSelection = false;
            this.listViewResponseHeaders.Location = new System.Drawing.Point(3, 3);
            this.listViewResponseHeaders.MultiSelect = false;
            this.listViewResponseHeaders.Name = "listViewResponseHeaders";
            this.listViewResponseHeaders.Size = new System.Drawing.Size(778, 199);
            this.listViewResponseHeaders.TabIndex = 0;
            this.listViewResponseHeaders.UseCompatibleStateImageBehavior = false;
            this.listViewResponseHeaders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Header Name";
            this.columnHeader5.Width = 223;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Header Value";
            this.columnHeader6.Width = 371;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBoxSource);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(784, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Source Code";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBoxSource
            // 
            this.richTextBoxSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSource.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxSource.Name = "richTextBoxSource";
            this.richTextBoxSource.Size = new System.Drawing.Size(778, 199);
            this.richTextBoxSource.TabIndex = 0;
            this.richTextBoxSource.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.webBrowserSource);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(784, 205);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Browser";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // webBrowserSource
            // 
            this.webBrowserSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserSource.Location = new System.Drawing.Point(3, 3);
            this.webBrowserSource.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserSource.Name = "webBrowserSource";
            this.webBrowserSource.Size = new System.Drawing.Size(778, 199);
            this.webBrowserSource.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tabControl3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(792, 231);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "HTTPS";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage6);
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(792, 231);
            this.tabControl3.TabIndex = 1;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.listViewResponseHeadersHTTPs);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(784, 205);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Response Headers";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // UserControlSubdomainScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControlSubdomainScanner";
            this.Size = new System.Drawing.Size(800, 600);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxSourceHTTPs;
        private System.Windows.Forms.ListView listViewServers;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.WebBrowser webBrowserSourceHTTPs;
        private System.Windows.Forms.ListView listViewResponseHeadersHTTPs;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.ProgressBar progressBarDnsChecks;
        private System.Windows.Forms.ProgressBar progressBarTargetFinder;
        private System.Windows.Forms.Timer timerGUI;
        private System.Windows.Forms.TextBox textBoxCustomDNS;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.ComboBox comboBoxDnsServer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDomain;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listViewResponseHeaders;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBoxSource;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.WebBrowser webBrowserSource;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage6;
    }
}
