namespace ToolSet
{
    partial class ToolSetManager
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
           this.components = new System.ComponentModel.Container();
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolSetManager));
           this.splitContainer1 = new System.Windows.Forms.SplitContainer();
           this.treeViewControl = new System.Windows.Forms.TreeView();
           this.tabControlToolset = new System.Windows.Forms.TabControl();
           this.tabPageAuthentication = new System.Windows.Forms.TabPage();
           this.tabPageCustomRequest = new System.Windows.Forms.TabPage();
           this.tabPageDatabaseExtractor = new System.Windows.Forms.TabPage();
           this.tabPageEncoder = new System.Windows.Forms.TabPage();
           this.tabPageHTTPsniffer = new System.Windows.Forms.TabPage();
           this.tabPageInjectionBrowser = new System.Windows.Forms.TabPage();
           this.tabPageMD5Searcher = new System.Windows.Forms.TabPage();
           this.tabPagePortscanner = new System.Windows.Forms.TabPage();
           this.tabPageRegexTester = new System.Windows.Forms.TabPage();
           this.tabPageSubdomainScanner = new System.Windows.Forms.TabPage();
           this.tabPageWebfuzzer = new System.Windows.Forms.TabPage();
           this.tabPageWebserverFinder = new System.Windows.Forms.TabPage();
           this.tabPageWebserverInformationCatcher = new System.Windows.Forms.TabPage();
           this.toolStrip1 = new System.Windows.Forms.ToolStrip();
           this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonAuthTester = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonCustomRequest = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonDatabaseExtractor = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonInjectionBrowser = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonSubdomainScanner = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonWebFuzzer = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonWebserverFinder = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonWebserverInformationCatcher = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonHttpSniffer = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonPortscanner = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripButtonEncoder = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonMD5Searcher = new System.Windows.Forms.ToolStripButton();
           this.toolStripButtonRegexTester = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
           this.menuStrip1 = new System.Windows.Forms.MenuStrip();
           this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.databaseExtractorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.encoderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.hTTPSnifferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.injectionBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.mD5SearcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.portscannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.regexTesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.subdomainScannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.webfuzzerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.webserverFinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.webserverInformationCatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.timerCounter = new System.Windows.Forms.Timer(this.components);
           this.buttonCloseTabpage = new System.Windows.Forms.Button();
           this.btnProxySettings = new System.Windows.Forms.ToolStripButton();
           this.splitContainer1.Panel1.SuspendLayout();
           this.splitContainer1.Panel2.SuspendLayout();
           this.splitContainer1.SuspendLayout();
           this.tabControlToolset.SuspendLayout();
           this.toolStrip1.SuspendLayout();
           this.SuspendLayout();
           // 
           // splitContainer1
           // 
           this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.splitContainer1.Location = new System.Drawing.Point(0, 49);
           this.splitContainer1.Name = "splitContainer1";
           // 
           // splitContainer1.Panel1
           // 
           this.splitContainer1.Panel1.Controls.Add(this.treeViewControl);
           // 
           // splitContainer1.Panel2
           // 
           this.splitContainer1.Panel2.Controls.Add(this.tabControlToolset);
           this.splitContainer1.Size = new System.Drawing.Size(1092, 724);
           this.splitContainer1.SplitterDistance = 209;
           this.splitContainer1.TabIndex = 0;
           // 
           // treeViewControl
           // 
           this.treeViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
           this.treeViewControl.Location = new System.Drawing.Point(0, 0);
           this.treeViewControl.Name = "treeViewControl";
           this.treeViewControl.Size = new System.Drawing.Size(209, 724);
           this.treeViewControl.TabIndex = 0;
           this.treeViewControl.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewControl_NodeMouseClick);
           // 
           // tabControlToolset
           // 
           this.tabControlToolset.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
           this.tabControlToolset.Controls.Add(this.tabPageAuthentication);
           this.tabControlToolset.Controls.Add(this.tabPageCustomRequest);
           this.tabControlToolset.Controls.Add(this.tabPageDatabaseExtractor);
           this.tabControlToolset.Controls.Add(this.tabPageEncoder);
           this.tabControlToolset.Controls.Add(this.tabPageHTTPsniffer);
           this.tabControlToolset.Controls.Add(this.tabPageInjectionBrowser);
           this.tabControlToolset.Controls.Add(this.tabPageMD5Searcher);
           this.tabControlToolset.Controls.Add(this.tabPagePortscanner);
           this.tabControlToolset.Controls.Add(this.tabPageRegexTester);
           this.tabControlToolset.Controls.Add(this.tabPageSubdomainScanner);
           this.tabControlToolset.Controls.Add(this.tabPageWebfuzzer);
           this.tabControlToolset.Controls.Add(this.tabPageWebserverFinder);
           this.tabControlToolset.Controls.Add(this.tabPageWebserverInformationCatcher);
           this.tabControlToolset.Dock = System.Windows.Forms.DockStyle.Fill;
           this.tabControlToolset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
           this.tabControlToolset.Location = new System.Drawing.Point(0, 0);
           this.tabControlToolset.Multiline = true;
           this.tabControlToolset.Name = "tabControlToolset";
           this.tabControlToolset.SelectedIndex = 0;
           this.tabControlToolset.Size = new System.Drawing.Size(879, 724);
           this.tabControlToolset.TabIndex = 0;
           // 
           // tabPageAuthentication
           // 
           this.tabPageAuthentication.Location = new System.Drawing.Point(4, 49);
           this.tabPageAuthentication.Name = "tabPageAuthentication";
           this.tabPageAuthentication.Padding = new System.Windows.Forms.Padding(3);
           this.tabPageAuthentication.Size = new System.Drawing.Size(871, 671);
           this.tabPageAuthentication.TabIndex = 0;
           this.tabPageAuthentication.Text = "Authentication Tester";
           this.tabPageAuthentication.UseVisualStyleBackColor = true;
           // 
           // tabPageCustomRequest
           // 
           this.tabPageCustomRequest.Location = new System.Drawing.Point(4, 49);
           this.tabPageCustomRequest.Name = "tabPageCustomRequest";
           this.tabPageCustomRequest.Padding = new System.Windows.Forms.Padding(3);
           this.tabPageCustomRequest.Size = new System.Drawing.Size(871, 671);
           this.tabPageCustomRequest.TabIndex = 1;
           this.tabPageCustomRequest.Text = "Custom Request";
           this.tabPageCustomRequest.UseVisualStyleBackColor = true;
           // 
           // tabPageDatabaseExtractor
           // 
           this.tabPageDatabaseExtractor.Location = new System.Drawing.Point(4, 49);
           this.tabPageDatabaseExtractor.Name = "tabPageDatabaseExtractor";
           this.tabPageDatabaseExtractor.Size = new System.Drawing.Size(871, 671);
           this.tabPageDatabaseExtractor.TabIndex = 2;
           this.tabPageDatabaseExtractor.Text = "Database Extractor";
           this.tabPageDatabaseExtractor.UseVisualStyleBackColor = true;
           // 
           // tabPageEncoder
           // 
           this.tabPageEncoder.Location = new System.Drawing.Point(4, 49);
           this.tabPageEncoder.Name = "tabPageEncoder";
           this.tabPageEncoder.Size = new System.Drawing.Size(871, 671);
           this.tabPageEncoder.TabIndex = 3;
           this.tabPageEncoder.Text = "Encoder";
           this.tabPageEncoder.UseVisualStyleBackColor = true;
           // 
           // tabPageHTTPsniffer
           // 
           this.tabPageHTTPsniffer.Location = new System.Drawing.Point(4, 49);
           this.tabPageHTTPsniffer.Name = "tabPageHTTPsniffer";
           this.tabPageHTTPsniffer.Size = new System.Drawing.Size(871, 671);
           this.tabPageHTTPsniffer.TabIndex = 4;
           this.tabPageHTTPsniffer.Text = "HTTP Snifffer";
           this.tabPageHTTPsniffer.UseVisualStyleBackColor = true;
           // 
           // tabPageInjectionBrowser
           // 
           this.tabPageInjectionBrowser.Location = new System.Drawing.Point(4, 49);
           this.tabPageInjectionBrowser.Name = "tabPageInjectionBrowser";
           this.tabPageInjectionBrowser.Size = new System.Drawing.Size(871, 671);
           this.tabPageInjectionBrowser.TabIndex = 5;
           this.tabPageInjectionBrowser.Text = "Injection Browser";
           this.tabPageInjectionBrowser.UseVisualStyleBackColor = true;
           // 
           // tabPageMD5Searcher
           // 
           this.tabPageMD5Searcher.Location = new System.Drawing.Point(4, 49);
           this.tabPageMD5Searcher.Name = "tabPageMD5Searcher";
           this.tabPageMD5Searcher.Size = new System.Drawing.Size(871, 671);
           this.tabPageMD5Searcher.TabIndex = 6;
           this.tabPageMD5Searcher.Text = "MD5 Searcher";
           this.tabPageMD5Searcher.UseVisualStyleBackColor = true;
           // 
           // tabPagePortscanner
           // 
           this.tabPagePortscanner.Location = new System.Drawing.Point(4, 49);
           this.tabPagePortscanner.Name = "tabPagePortscanner";
           this.tabPagePortscanner.Size = new System.Drawing.Size(871, 671);
           this.tabPagePortscanner.TabIndex = 7;
           this.tabPagePortscanner.Text = "Portscanner";
           this.tabPagePortscanner.UseVisualStyleBackColor = true;
           // 
           // tabPageRegexTester
           // 
           this.tabPageRegexTester.Location = new System.Drawing.Point(4, 49);
           this.tabPageRegexTester.Name = "tabPageRegexTester";
           this.tabPageRegexTester.Size = new System.Drawing.Size(871, 671);
           this.tabPageRegexTester.TabIndex = 8;
           this.tabPageRegexTester.Text = "Regex Tester";
           this.tabPageRegexTester.UseVisualStyleBackColor = true;
           // 
           // tabPageSubdomainScanner
           // 
           this.tabPageSubdomainScanner.Location = new System.Drawing.Point(4, 49);
           this.tabPageSubdomainScanner.Name = "tabPageSubdomainScanner";
           this.tabPageSubdomainScanner.Size = new System.Drawing.Size(871, 671);
           this.tabPageSubdomainScanner.TabIndex = 9;
           this.tabPageSubdomainScanner.Text = "Subdomain Scanner";
           this.tabPageSubdomainScanner.UseVisualStyleBackColor = true;
           // 
           // tabPageWebfuzzer
           // 
           this.tabPageWebfuzzer.Location = new System.Drawing.Point(4, 49);
           this.tabPageWebfuzzer.Name = "tabPageWebfuzzer";
           this.tabPageWebfuzzer.Padding = new System.Windows.Forms.Padding(8);
           this.tabPageWebfuzzer.Size = new System.Drawing.Size(871, 671);
           this.tabPageWebfuzzer.TabIndex = 10;
           this.tabPageWebfuzzer.Text = "Webfuzzer";
           this.tabPageWebfuzzer.UseVisualStyleBackColor = true;
           // 
           // tabPageWebserverFinder
           // 
           this.tabPageWebserverFinder.Location = new System.Drawing.Point(4, 49);
           this.tabPageWebserverFinder.Name = "tabPageWebserverFinder";
           this.tabPageWebserverFinder.Size = new System.Drawing.Size(871, 671);
           this.tabPageWebserverFinder.TabIndex = 11;
           this.tabPageWebserverFinder.Text = "Webserver Finder";
           this.tabPageWebserverFinder.UseVisualStyleBackColor = true;
           // 
           // tabPageWebserverInformationCatcher
           // 
           this.tabPageWebserverInformationCatcher.Location = new System.Drawing.Point(4, 49);
           this.tabPageWebserverInformationCatcher.Name = "tabPageWebserverInformationCatcher";
           this.tabPageWebserverInformationCatcher.Size = new System.Drawing.Size(871, 671);
           this.tabPageWebserverInformationCatcher.TabIndex = 12;
           this.tabPageWebserverInformationCatcher.Text = "Webserver Information Catcher";
           this.tabPageWebserverInformationCatcher.UseVisualStyleBackColor = true;
           // 
           // toolStrip1
           // 
           this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
           this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
           this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProxySettings});
           this.toolStrip1.Location = new System.Drawing.Point(0, 24);
           this.toolStrip1.Name = "toolStrip1";
           this.toolStrip1.Size = new System.Drawing.Size(1092, 25);
           this.toolStrip1.TabIndex = 1;
           this.toolStrip1.Text = "toolStrip1";
           // 
           // toolStripSeparator6
           // 
           this.toolStripSeparator6.Name = "toolStripSeparator6";
           this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
           // 
           // toolStripButtonAuthTester
           // 
           this.toolStripButtonAuthTester.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonAuthTester.Image = global::ToolSet.Properties.Resources.key;
           this.toolStripButtonAuthTester.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonAuthTester.Name = "toolStripButtonAuthTester";
           this.toolStripButtonAuthTester.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonAuthTester.Text = "toolStripButton1";
           this.toolStripButtonAuthTester.Click += new System.EventHandler(this.toolStripButtonAuthTester_Click);
           // 
           // toolStripButtonCustomRequest
           // 
           this.toolStripButtonCustomRequest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonCustomRequest.Image = global::ToolSet.Properties.Resources.edit_code;
           this.toolStripButtonCustomRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonCustomRequest.Name = "toolStripButtonCustomRequest";
           this.toolStripButtonCustomRequest.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonCustomRequest.Text = "toolStripButton2";
           this.toolStripButtonCustomRequest.Click += new System.EventHandler(this.toolStripButtonCustomRequest_Click);
           // 
           // toolStripButtonDatabaseExtractor
           // 
           this.toolStripButtonDatabaseExtractor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonDatabaseExtractor.Image = global::ToolSet.Properties.Resources.database_export;
           this.toolStripButtonDatabaseExtractor.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonDatabaseExtractor.Name = "toolStripButtonDatabaseExtractor";
           this.toolStripButtonDatabaseExtractor.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonDatabaseExtractor.Text = "toolStripButton3";
           this.toolStripButtonDatabaseExtractor.Click += new System.EventHandler(this.toolStripButtonDatabaseExtractor_Click);
           // 
           // toolStripButtonInjectionBrowser
           // 
           this.toolStripButtonInjectionBrowser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonInjectionBrowser.Image = global::ToolSet.Properties.Resources.globe_medium;
           this.toolStripButtonInjectionBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonInjectionBrowser.Name = "toolStripButtonInjectionBrowser";
           this.toolStripButtonInjectionBrowser.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonInjectionBrowser.Text = "toolStripButton4";
           this.toolStripButtonInjectionBrowser.Click += new System.EventHandler(this.toolStripButtonInjectionBrowser_Click);
           // 
           // toolStripButtonSubdomainScanner
           // 
           this.toolStripButtonSubdomainScanner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonSubdomainScanner.Image = global::ToolSet.Properties.Resources.server;
           this.toolStripButtonSubdomainScanner.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonSubdomainScanner.Name = "toolStripButtonSubdomainScanner";
           this.toolStripButtonSubdomainScanner.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonSubdomainScanner.Text = "toolStripButton5";
           this.toolStripButtonSubdomainScanner.Click += new System.EventHandler(this.toolStripButtonSubdomainScanner_Click);
           // 
           // toolStripButtonWebFuzzer
           // 
           this.toolStripButtonWebFuzzer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonWebFuzzer.Image = global::ToolSet.Properties.Resources.server_cast;
           this.toolStripButtonWebFuzzer.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonWebFuzzer.Name = "toolStripButtonWebFuzzer";
           this.toolStripButtonWebFuzzer.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonWebFuzzer.Text = "toolStripButton6";
           this.toolStripButtonWebFuzzer.Click += new System.EventHandler(this.toolStripButtonWebFuzzer_Click);
           // 
           // toolStripButtonWebserverFinder
           // 
           this.toolStripButtonWebserverFinder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonWebserverFinder.Image = global::ToolSet.Properties.Resources.servers_network;
           this.toolStripButtonWebserverFinder.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonWebserverFinder.Name = "toolStripButtonWebserverFinder";
           this.toolStripButtonWebserverFinder.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonWebserverFinder.Text = "toolStripButton7";
           this.toolStripButtonWebserverFinder.Click += new System.EventHandler(this.toolStripButtonWebserverFinder_Click);
           // 
           // toolStripButtonWebserverInformationCatcher
           // 
           this.toolStripButtonWebserverInformationCatcher.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonWebserverInformationCatcher.Image = global::ToolSet.Properties.Resources.document_horizontal_text;
           this.toolStripButtonWebserverInformationCatcher.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonWebserverInformationCatcher.Name = "toolStripButtonWebserverInformationCatcher";
           this.toolStripButtonWebserverInformationCatcher.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonWebserverInformationCatcher.Text = "toolStripButton8";
           this.toolStripButtonWebserverInformationCatcher.Click += new System.EventHandler(this.toolStripButtonWebserverInformationCatcher_Click);
           // 
           // toolStripSeparator7
           // 
           this.toolStripSeparator7.Name = "toolStripSeparator7";
           this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
           // 
           // toolStripButtonHttpSniffer
           // 
           this.toolStripButtonHttpSniffer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonHttpSniffer.Image = global::ToolSet.Properties.Resources.eye_red;
           this.toolStripButtonHttpSniffer.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonHttpSniffer.Name = "toolStripButtonHttpSniffer";
           this.toolStripButtonHttpSniffer.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonHttpSniffer.Text = "toolStripButton10";
           this.toolStripButtonHttpSniffer.Click += new System.EventHandler(this.toolStripButtonHttpSniffer_Click);
           // 
           // toolStripButtonPortscanner
           // 
           this.toolStripButtonPortscanner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonPortscanner.Image = global::ToolSet.Properties.Resources.network_hub;
           this.toolStripButtonPortscanner.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonPortscanner.Name = "toolStripButtonPortscanner";
           this.toolStripButtonPortscanner.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonPortscanner.Text = "toolStripButton9";
           this.toolStripButtonPortscanner.Click += new System.EventHandler(this.toolStripButtonPortscanner_Click);
           // 
           // toolStripSeparator8
           // 
           this.toolStripSeparator8.Name = "toolStripSeparator8";
           this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
           // 
           // toolStripButtonEncoder
           // 
           this.toolStripButtonEncoder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonEncoder.Image = global::ToolSet.Properties.Resources.barcode;
           this.toolStripButtonEncoder.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonEncoder.Name = "toolStripButtonEncoder";
           this.toolStripButtonEncoder.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonEncoder.Text = "toolStripButton11";
           this.toolStripButtonEncoder.Click += new System.EventHandler(this.toolStripButtonEncoder_Click);
           // 
           // toolStripButtonMD5Searcher
           // 
           this.toolStripButtonMD5Searcher.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonMD5Searcher.Image = global::ToolSet.Properties.Resources.magnifier_medium;
           this.toolStripButtonMD5Searcher.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonMD5Searcher.Name = "toolStripButtonMD5Searcher";
           this.toolStripButtonMD5Searcher.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonMD5Searcher.Text = "toolStripButton12";
           this.toolStripButtonMD5Searcher.Click += new System.EventHandler(this.toolStripButtonMD5Searcher_Click);
           // 
           // toolStripButtonRegexTester
           // 
           this.toolStripButtonRegexTester.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButtonRegexTester.Image = global::ToolSet.Properties.Resources.block;
           this.toolStripButtonRegexTester.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButtonRegexTester.Name = "toolStripButtonRegexTester";
           this.toolStripButtonRegexTester.Size = new System.Drawing.Size(23, 22);
           this.toolStripButtonRegexTester.Text = "toolStripButton13";
           this.toolStripButtonRegexTester.Click += new System.EventHandler(this.toolStripButtonRegexTester_Click);
           // 
           // toolStripSeparator9
           // 
           this.toolStripSeparator9.Name = "toolStripSeparator9";
           this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
           // 
           // menuStrip1
           // 
           this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
           this.menuStrip1.Location = new System.Drawing.Point(0, 0);
           this.menuStrip1.Name = "menuStrip1";
           this.menuStrip1.Size = new System.Drawing.Size(1092, 24);
           this.menuStrip1.TabIndex = 2;
           this.menuStrip1.Text = "menuStrip1";
           // 
           // fileToolStripMenuItem
           // 
           this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
           this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
           this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
           this.fileToolStripMenuItem.Text = "&File";
           // 
           // exitToolStripMenuItem
           // 
           this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
           this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
           this.exitToolStripMenuItem.Text = "E&xit";
           this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
           // 
           // toolsToolStripMenuItem
           // 
           this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.databaseExtractorToolStripMenuItem,
            this.encoderToolStripMenuItem,
            this.hTTPSnifferToolStripMenuItem,
            this.injectionBrowserToolStripMenuItem,
            this.mD5SearcherToolStripMenuItem,
            this.portscannerToolStripMenuItem,
            this.regexTesterToolStripMenuItem,
            this.subdomainScannerToolStripMenuItem,
            this.webfuzzerToolStripMenuItem,
            this.webserverFinderToolStripMenuItem,
            this.webserverInformationCatcherToolStripMenuItem});
           this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
           this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
           this.toolsToolStripMenuItem.Text = "&Tools";
           // 
           // customizeToolStripMenuItem
           // 
           this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
           this.customizeToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.customizeToolStripMenuItem.Text = "Authentication Tester";
           this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
           // 
           // optionsToolStripMenuItem
           // 
           this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
           this.optionsToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.optionsToolStripMenuItem.Text = "Custom Request";
           this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
           // 
           // databaseExtractorToolStripMenuItem
           // 
           this.databaseExtractorToolStripMenuItem.Name = "databaseExtractorToolStripMenuItem";
           this.databaseExtractorToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.databaseExtractorToolStripMenuItem.Text = "Database Extractor";
           this.databaseExtractorToolStripMenuItem.Click += new System.EventHandler(this.databaseExtractorToolStripMenuItem_Click);
           // 
           // encoderToolStripMenuItem
           // 
           this.encoderToolStripMenuItem.Name = "encoderToolStripMenuItem";
           this.encoderToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.encoderToolStripMenuItem.Text = "Encoder";
           this.encoderToolStripMenuItem.Click += new System.EventHandler(this.encoderToolStripMenuItem_Click);
           // 
           // hTTPSnifferToolStripMenuItem
           // 
           this.hTTPSnifferToolStripMenuItem.Name = "hTTPSnifferToolStripMenuItem";
           this.hTTPSnifferToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.hTTPSnifferToolStripMenuItem.Text = "HTTP Sniffer";
           this.hTTPSnifferToolStripMenuItem.Click += new System.EventHandler(this.hTTPSnifferToolStripMenuItem_Click);
           // 
           // injectionBrowserToolStripMenuItem
           // 
           this.injectionBrowserToolStripMenuItem.Name = "injectionBrowserToolStripMenuItem";
           this.injectionBrowserToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.injectionBrowserToolStripMenuItem.Text = "Injection Browser";
           this.injectionBrowserToolStripMenuItem.Click += new System.EventHandler(this.injectionBrowserToolStripMenuItem_Click);
           // 
           // mD5SearcherToolStripMenuItem
           // 
           this.mD5SearcherToolStripMenuItem.Name = "mD5SearcherToolStripMenuItem";
           this.mD5SearcherToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.mD5SearcherToolStripMenuItem.Text = "MD5 Searcher";
           this.mD5SearcherToolStripMenuItem.Click += new System.EventHandler(this.mD5SearcherToolStripMenuItem_Click);
           // 
           // portscannerToolStripMenuItem
           // 
           this.portscannerToolStripMenuItem.Name = "portscannerToolStripMenuItem";
           this.portscannerToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.portscannerToolStripMenuItem.Text = "Portscanner";
           this.portscannerToolStripMenuItem.Click += new System.EventHandler(this.portscannerToolStripMenuItem_Click);
           // 
           // regexTesterToolStripMenuItem
           // 
           this.regexTesterToolStripMenuItem.Name = "regexTesterToolStripMenuItem";
           this.regexTesterToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.regexTesterToolStripMenuItem.Text = "Regex Tester";
           this.regexTesterToolStripMenuItem.Click += new System.EventHandler(this.regexTesterToolStripMenuItem_Click);
           // 
           // subdomainScannerToolStripMenuItem
           // 
           this.subdomainScannerToolStripMenuItem.Name = "subdomainScannerToolStripMenuItem";
           this.subdomainScannerToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.subdomainScannerToolStripMenuItem.Text = "Subdomain Scanner";
           this.subdomainScannerToolStripMenuItem.Click += new System.EventHandler(this.subdomainScannerToolStripMenuItem_Click);
           // 
           // webfuzzerToolStripMenuItem
           // 
           this.webfuzzerToolStripMenuItem.Name = "webfuzzerToolStripMenuItem";
           this.webfuzzerToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.webfuzzerToolStripMenuItem.Text = "Webfuzzer";
           this.webfuzzerToolStripMenuItem.Click += new System.EventHandler(this.webfuzzerToolStripMenuItem_Click);
           // 
           // webserverFinderToolStripMenuItem
           // 
           this.webserverFinderToolStripMenuItem.Name = "webserverFinderToolStripMenuItem";
           this.webserverFinderToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.webserverFinderToolStripMenuItem.Text = "Webserver Finder";
           this.webserverFinderToolStripMenuItem.Click += new System.EventHandler(this.webserverFinderToolStripMenuItem_Click);
           // 
           // webserverInformationCatcherToolStripMenuItem
           // 
           this.webserverInformationCatcherToolStripMenuItem.Name = "webserverInformationCatcherToolStripMenuItem";
           this.webserverInformationCatcherToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
           this.webserverInformationCatcherToolStripMenuItem.Text = "Webserver Information Catcher";
           this.webserverInformationCatcherToolStripMenuItem.Click += new System.EventHandler(this.webserverInformationCatcherToolStripMenuItem_Click);
           // 
           // helpToolStripMenuItem
           // 
           this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
           this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
           this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
           this.helpToolStripMenuItem.Text = "&Help";
           this.helpToolStripMenuItem.Visible = false;
           // 
           // aboutToolStripMenuItem
           // 
           this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
           this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
           this.aboutToolStripMenuItem.Text = "&About...";
           this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
           // 
           // buttonCloseTabpage
           // 
           this.buttonCloseTabpage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
           this.buttonCloseTabpage.FlatAppearance.BorderSize = 0;
           this.buttonCloseTabpage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.buttonCloseTabpage.Image = global::ToolSet.Properties.Resources.cross;
           this.buttonCloseTabpage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
           this.buttonCloseTabpage.Location = new System.Drawing.Point(1025, 48);
           this.buttonCloseTabpage.Name = "buttonCloseTabpage";
           this.buttonCloseTabpage.Size = new System.Drawing.Size(75, 23);
           this.buttonCloseTabpage.TabIndex = 3;
           this.buttonCloseTabpage.Text = "Close";
           this.buttonCloseTabpage.UseVisualStyleBackColor = true;
           this.buttonCloseTabpage.Click += new System.EventHandler(this.buttonCloseTabpage_Click);
           // 
           // btnProxySettings
           // 
           this.btnProxySettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
           this.btnProxySettings.Image = ((System.Drawing.Image)(resources.GetObject("btnProxySettings.Image")));
           this.btnProxySettings.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.btnProxySettings.Name = "btnProxySettings";
           this.btnProxySettings.Size = new System.Drawing.Size(84, 22);
           this.btnProxySettings.Text = "Proxy settings";
           this.btnProxySettings.Click += new System.EventHandler(this.btnProxySettingsClick);
           // 
           // ToolSetManager
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(1092, 773);
           this.Controls.Add(this.buttonCloseTabpage);
           this.Controls.Add(this.splitContainer1);
           this.Controls.Add(this.toolStrip1);
           this.Controls.Add(this.menuStrip1);
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MinimumSize = new System.Drawing.Size(1100, 770);
           this.Name = "ToolSetManager";
           this.Text = "Web Security ToolSet 2.00";
           this.Resize += new System.EventHandler(this.ToolSetManager_Resize);
           this.splitContainer1.Panel1.ResumeLayout(false);
           this.splitContainer1.Panel2.ResumeLayout(false);
           this.splitContainer1.ResumeLayout(false);
           this.tabControlToolset.ResumeLayout(false);
           this.toolStrip1.ResumeLayout(false);
           this.toolStrip1.PerformLayout();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControlToolset;
        private System.Windows.Forms.TabPage tabPageAuthentication;
        private System.Windows.Forms.TabPage tabPageCustomRequest;
        private System.Windows.Forms.TabPage tabPageDatabaseExtractor;
        private System.Windows.Forms.TabPage tabPageEncoder;
        private System.Windows.Forms.TabPage tabPageHTTPsniffer;
        private System.Windows.Forms.TabPage tabPageInjectionBrowser;
        private System.Windows.Forms.TabPage tabPageMD5Searcher;
        private System.Windows.Forms.TabPage tabPagePortscanner;
        private System.Windows.Forms.TabPage tabPageRegexTester;
        private System.Windows.Forms.TabPage tabPageSubdomainScanner;
        private System.Windows.Forms.TabPage tabPageWebfuzzer;
        private System.Windows.Forms.TabPage tabPageWebserverFinder;
        private System.Windows.Forms.TabPage tabPageWebserverInformationCatcher;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer timerCounter;
        private System.Windows.Forms.Button buttonCloseTabpage;
        private System.Windows.Forms.ToolStripButton toolStripButtonAuthTester;
        private System.Windows.Forms.ToolStripButton toolStripButtonCustomRequest;
        private System.Windows.Forms.ToolStripButton toolStripButtonDatabaseExtractor;
        private System.Windows.Forms.ToolStripButton toolStripButtonInjectionBrowser;
        private System.Windows.Forms.ToolStripButton toolStripButtonSubdomainScanner;
        private System.Windows.Forms.ToolStripButton toolStripButtonWebFuzzer;
        private System.Windows.Forms.ToolStripButton toolStripButtonWebserverFinder;
        private System.Windows.Forms.ToolStripButton toolStripButtonWebserverInformationCatcher;
        private System.Windows.Forms.ToolStripButton toolStripButtonPortscanner;
        private System.Windows.Forms.ToolStripButton toolStripButtonHttpSniffer;
        private System.Windows.Forms.ToolStripButton toolStripButtonEncoder;
        private System.Windows.Forms.ToolStripButton toolStripButtonMD5Searcher;
        private System.Windows.Forms.ToolStripButton toolStripButtonRegexTester;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem databaseExtractorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encoderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hTTPSnifferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem injectionBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mD5SearcherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portscannerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regexTesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subdomainScannerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webfuzzerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webserverFinderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webserverInformationCatcherToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnProxySettings;

    }
}

