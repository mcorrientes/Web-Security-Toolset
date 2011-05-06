using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ToolSet.DatabaseExtractorCode;
using ToolSet.Global;
using ToolSet.Webfuzzer;
using ToolSet.CustomRequestCode;
using ToolSet.AuthenticationTesterCode;
using ToolSet.EncoderCode;
using ToolSet.InjectionBrowsercode;
using ToolSet.MD5SearcherCode;
using ToolSet.PortScannerCode;
using ToolSet.RegexTesterCode;
using ToolSet.SudomainScannerCode;
using ToolSet.WebserverFinderCode;
using ToolSet.WebserverInformantCode;
using ToolSet.HTTPSnifferCode;


namespace ToolSet
{
    public partial class ToolSetManager : Form
    {
        private bool m_bLayoutCalled = false;
        private System.Windows.Forms.Timer timer1;
        private DateTime m_dt;
        private List<TabPage> savedTabs;
        private int waitTime = 10;

        private UCWebfuzzer ucWebFuzzer;
        private UserControlAuthenticationTester ucAuthenticationTester;
        private UserControlCustomRequest ucCustomReQuest;
        private UserControlDatabaseExtractor ucDatabaseExtractor;
        private UserControlEncoder ucEncoder;
        private UserControlInjectionBrowser ucInjectionBrowser;
        private UserControlMD5Searcher ucMD5Searcher;
        private UserControlPortScanner ucPortScanner;
        private UserControlRegexTester ucRegexTester;
        private UserControlSubdomainScanner ucSubdomainScanner;
        private UserControlWebserverFinder ucWebserverfinder;
        private UserControlWebserverInformant ucWebServerInformant;
        private UserControlHTTPSniffer ucHTTPSniffer;
        private ImageList treeviewImagelist;

        public ToolSetManager()
        {
            InitializeComponent();
            Application.DoEvents();
            treeviewImagelist = new ImageList();
            AddImages();
            this.treeViewControl.ImageList = treeviewImagelist;
            SplashScreen.SetStatus("Initializing Components...");
            Thread.Sleep(300);
            SplashScreen.SetStatus("Loading AuthenticationTester...");
            ucAuthenticationTester = new UserControlAuthenticationTester();
            tabPageAuthentication.Controls.Add(ucAuthenticationTester);
            ucAuthenticationTester.Dock = DockStyle.Fill;
            Thread.Sleep(100);
            SplashScreen.SetStatus("Loading CustomRequest...");
            ucCustomReQuest = new UserControlCustomRequest ();
            tabPageCustomRequest.Controls.Add(ucCustomReQuest);
            ucCustomReQuest.Dock = DockStyle.Fill;
            Thread.Sleep(100);
            SplashScreen.SetStatus("Loading Database Extractor...");
            ucDatabaseExtractor = new UserControlDatabaseExtractor();
            tabPageDatabaseExtractor.Controls.Add(ucDatabaseExtractor);
            ucDatabaseExtractor.Dock = DockStyle.Fill;
            Thread.Sleep(100);
            SplashScreen.SetStatus("Loading Encoder..."); 
            ucEncoder = new UserControlEncoder();
            tabPageEncoder.Controls.Add(ucEncoder);
            ucEncoder.Dock = DockStyle.Fill;
            Thread.Sleep(100);
            SplashScreen.SetStatus("Loading HTTP Sniffer...");
            ucHTTPSniffer = new UserControlHTTPSniffer();
            tabPageHTTPsniffer.Controls.Add(ucHTTPSniffer);
            ucHTTPSniffer.Dock = DockStyle.Fill;
            SplashScreen.SetStatus("Loading Injection Browser...");
            Thread.Sleep(100);
            ucInjectionBrowser = new UserControlInjectionBrowser();
            tabPageInjectionBrowser.Controls.Add(ucInjectionBrowser);
            ucInjectionBrowser.Dock = DockStyle.Fill;
            Thread.Sleep(100);
            SplashScreen.SetStatus("Loading MD5Searcher...");
            ucMD5Searcher = new UserControlMD5Searcher();
            tabPageMD5Searcher.Controls.Add(ucMD5Searcher);
            ucMD5Searcher.Dock = DockStyle.Fill;
            Thread.Sleep(100);
            SplashScreen.SetStatus("Loading PortScanner...");
            ucPortScanner = new UserControlPortScanner();
            tabPagePortscanner.Controls.Add(ucPortScanner);
            ucPortScanner.Dock = DockStyle.Fill;
            Thread.Sleep(100);
            SplashScreen.SetStatus("Loading RegexTester...");
            ucRegexTester = new UserControlRegexTester();
            tabPageRegexTester.Controls.Add(ucRegexTester);
            ucRegexTester.Dock = DockStyle.Fill;
            Thread.Sleep(100);
            SplashScreen.SetStatus("Loading SubdomainScanner...");
            ucSubdomainScanner = new UserControlSubdomainScanner();
            tabPageSubdomainScanner.Controls.Add(ucSubdomainScanner);
            ucSubdomainScanner.Dock = DockStyle.Fill;
            Thread.Sleep(100);
            SplashScreen.SetStatus("Loading Webfuzzer...");
            ucWebFuzzer = new UCWebfuzzer();
            tabPageWebfuzzer.Controls.Add(ucWebFuzzer);
            ucWebFuzzer.Dock = DockStyle.Fill;
            Thread.Sleep(100);
            SplashScreen.SetStatus("Loading WebserverFinder...");
            ucWebserverfinder = new UserControlWebserverFinder();
            tabPageWebserverFinder.Controls.Add(ucWebserverfinder);
            ucWebserverfinder.Dock = DockStyle.Fill;
            Thread.Sleep(100);
            SplashScreen.SetStatus("Loading WebserverInformant...");
            ucWebServerInformant = new UserControlWebserverInformant();
            tabPageWebserverInformationCatcher.Controls.Add(ucWebServerInformant);
            ucWebserverfinder.Dock = DockStyle.Fill;
            Thread.Sleep(100);
            InitializeTreeview();
            SplashScreen.CloseForm();
            Thread.Sleep(100);
            SaveTabepages();
            //timerWerbung.Start();
        }

        private void AddImages()
        {
            treeviewImagelist.Images.Add("Wrench", Properties.Resources.wrench_screwdriver);
            treeviewImagelist.Images.Add("Key",Properties.Resources.key);
            treeviewImagelist.Images.Add("Block",Properties.Resources.block);
            treeviewImagelist.Images.Add("Edit-Code",Properties.Resources.edit_code);
            treeviewImagelist.Images.Add("Database_Export",Properties.Resources.database_export);
            treeviewImagelist.Images.Add("Network_Hub",Properties.Resources.network_hub);
            treeviewImagelist.Images.Add("Eye-Red",Properties.Resources.eye_red);
            treeviewImagelist.Images.Add("Server",Properties.Resources.server);
            treeviewImagelist.Images.Add("Server_Cast",Properties.Resources.server_cast);
            treeviewImagelist.Images.Add("Servers_Network",Properties.Resources.servers_network);
            treeviewImagelist.Images.Add("Barcode",Properties.Resources.barcode);
            treeviewImagelist.Images.Add("Magnifier_medium",Properties.Resources.magnifier_medium);
            treeviewImagelist.Images.Add("Globe_medium",Properties.Resources.globe_medium);
            treeviewImagelist.Images.Add("Document_horizontal",Properties.Resources.document_horizontal_text);

        }

        private void SaveTabepages()
        {
            savedTabs = new List<TabPage>();
            for (int i = 0; i < tabControlToolset.TabPages.Count;)
            {
                savedTabs.Add(tabControlToolset.TabPages[i]);
                tabControlToolset.TabPages.Remove(tabControlToolset.TabPages[i]);
            }
        }

        private void ClearTabs()
        {
            for (int i = 0; i < tabControlToolset.TabPages.Count;)
            {
                tabControlToolset.TabPages.Remove(tabControlToolset.TabPages[i]);
            }
        }


        private void InitializeTreeview()
        {
            treeViewControl.SuspendLayout();
            //TreeNode node;
            //node = treeViewControl.Nodes.Add("Penetration Test Tools");
            //"Web Security ToolSet"
            TreeNode websecurity;
            websecurity = treeViewControl.Nodes.Add("Web Security ToolSet");
            websecurity.Nodes.Add("Webfuzzer", "Webfuzzer", "Server_Cast", "Server_Cast");

            websecurity.Nodes.Add("Database Extractor", "Database Extractor", "Database_Export", "Database_Export");
            websecurity.Nodes.Add("Injection Browser", "Injection Browser", "Globe_medium", "Globe_medium");
            websecurity.Nodes.Add("Authentication Tester", "Authentication Tester", "Key", "Key");
            websecurity.Nodes.Add("Custom Request", "Custom Request", "Edit-Code", "Edit-Code");
            websecurity.Nodes.Add("Subdomain Scanner", "Subdomain Scanner", "Server", "Server");
            websecurity.Nodes.Add("Webserver Finder", "Webserver Finder", "Servers_Network", "Servers_Network");
            websecurity.Nodes.Add("Webserver Information Catcher", "Webserver Information Catcher", "Document_horizontal", "Document_horizontal");

            //"Network Security Toolset"
            TreeNode networksecurity;
            networksecurity = treeViewControl.Nodes.Add("Network Security Toolset");
            networksecurity.Nodes.Add("Portscanner", "Portscanner", "Network_Hub", "Network_Hub");
            networksecurity.Nodes.Add("HTTP Snifffer", "HTTP Snifffer", "Eye-Red", "Eye-Red");
            //"General Tools"
            TreeNode general;
            general = treeViewControl.Nodes.Add("General Tools");
            general.Nodes.Add("Encoder", "Encoder", "Barcode", "Barcode");
            general.Nodes.Add("MD5 Searcher", "MD5 Searcher", "Magnifier_medium", "Magnifier_medium");
            general.Nodes.Add("Regex Tester", "Regex Tester", "Block", "Block");


            treeViewControl.ExpandAll();
            treeViewControl.ResumeLayout();
           
        }


        private void treeViewControl_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode clickedNode = e.Node;
            
            if (clickedNode.Text == "Authentication Tester")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[0]);
                tabControlToolset.SelectedTab = tabPageAuthentication;
                tabControlToolset.Focus();
                
            }
            else if (clickedNode.Text == "Custom Request")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[1]);
                tabControlToolset.SelectedTab = tabPageCustomRequest;
                tabControlToolset.Focus();
                

            }
            else if (clickedNode.Text == "Database Extractor")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[2]);
                tabControlToolset.SelectedTab = tabPageDatabaseExtractor;
                tabControlToolset.Focus();
                
              
            }
            else if (clickedNode.Text == "Encoder")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[3]);
                tabControlToolset.SelectedTab = tabPageEncoder;
                tabControlToolset.Focus();
                

            }
            else if (clickedNode.Text == "HTTP Snifffer")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[4]);
                tabControlToolset.SelectedTab = tabPageHTTPsniffer;
                tabControlToolset.Focus();
             
       
            }
            else if (clickedNode.Text == "Injection Browser")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[5]);
                tabControlToolset.SelectedTab = tabPageInjectionBrowser;
                tabControlToolset.Focus();
              
          
            }
            else if (clickedNode.Text == "MD5 Searcher")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[6]);
                tabControlToolset.SelectedTab = tabPageMD5Searcher;
                tabControlToolset.Focus();
             
            }
            else if (clickedNode.Text == "Portscanner")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[7]);
                tabControlToolset.SelectedTab = tabPagePortscanner;
                tabControlToolset.Focus();

            }
            else if (clickedNode.Text == "Regex Tester")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[8]);
                tabControlToolset.SelectedTab = tabPageRegexTester;
                tabControlToolset.Focus();
                             
            }
            else if (clickedNode.Text == "Subdomain Scanner")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[9]);
                tabControlToolset.SelectedTab = tabPageSubdomainScanner;
                tabControlToolset.Focus();

            }
            else if (clickedNode.Text == "Webfuzzer")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[10]);
                tabControlToolset.SelectedTab = tabPageWebfuzzer;
                tabControlToolset.Focus();
          
            }
            else if (clickedNode.Text == "Webserver Finder")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[11]);
                tabControlToolset.SelectedTab = tabPageWebserverFinder;
                tabControlToolset.Focus();
              
            }
            else if (clickedNode.Text == "Webserver Information Catcher")
            {
                ClearTabs();
                tabControlToolset.TabPages.Add(savedTabs[12]);
                tabControlToolset.SelectedTab = tabPageWebserverInformationCatcher;
                tabControlToolset.Focus();
            }
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabelSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void buttonCloseTabpage_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlToolset.TabPages.Remove(tabControlToolset.SelectedTab);
            }
            catch (Exception)
            { 

            }

        }

        private void ToolSetManager_Resize(object sender, EventArgs e)
        {
            buttonCloseTabpage.Location = new Point(this.Width - 90, 55);
        }

        private void toolStripButtonAuthTester_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[0]);
            tabControlToolset.SelectedTab = tabPageAuthentication;
            tabControlToolset.Focus();

        }

        private void toolStripButtonCustomRequest_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[1]);
            tabControlToolset.SelectedTab = tabPageCustomRequest;
            tabControlToolset.Focus();
        }

        private void toolStripButtonDatabaseExtractor_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[2]);
            tabControlToolset.SelectedTab = tabPageDatabaseExtractor;
            tabControlToolset.Focus();
        }

        private void toolStripButtonInjectionBrowser_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[5]);
            tabControlToolset.SelectedTab = tabPageInjectionBrowser;
            tabControlToolset.Focus();
        }

        private void toolStripButtonSubdomainScanner_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[9]);
            tabControlToolset.SelectedTab = tabPageSubdomainScanner;
            tabControlToolset.Focus();
        }

        private void toolStripButtonWebFuzzer_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[10]);
            tabControlToolset.SelectedTab = tabPageWebfuzzer;
            tabControlToolset.Focus();
          
        }

        private void toolStripButtonWebserverFinder_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[11]);
            tabControlToolset.SelectedTab = tabPageWebserverFinder;
            tabControlToolset.Focus();
        }

        private void toolStripButtonWebserverInformationCatcher_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[12]);
            tabControlToolset.SelectedTab = tabPageWebserverInformationCatcher;
            tabControlToolset.Focus();
        }

        private void toolStripButtonHttpSniffer_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[4]);
            tabControlToolset.SelectedTab = tabPageHTTPsniffer;
            tabControlToolset.Focus();
        }

        private void toolStripButtonPortscanner_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[7]);
            tabControlToolset.SelectedTab = tabPagePortscanner;
            tabControlToolset.Focus();
        }

        private void toolStripButtonEncoder_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[3]);
            tabControlToolset.SelectedTab = tabPageEncoder;
            tabControlToolset.Focus();
                
        }

        private void toolStripButtonMD5Searcher_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[6]);
            tabControlToolset.SelectedTab = tabPageMD5Searcher;
            tabControlToolset.Focus();
        }

        private void toolStripButtonRegexTester_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[8]);
            tabControlToolset.SelectedTab = tabPageRegexTester;
            tabControlToolset.Focus();
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[0]);
            tabControlToolset.SelectedTab = tabPageAuthentication;
            tabControlToolset.Focus();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[1]);
            tabControlToolset.SelectedTab = tabPageCustomRequest;
            tabControlToolset.Focus();
        }

        private void databaseExtractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[2]);
            tabControlToolset.SelectedTab = tabPageDatabaseExtractor;
            tabControlToolset.Focus();
        }

        private void encoderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[3]);
            tabControlToolset.SelectedTab = tabPageEncoder;
            tabControlToolset.Focus();
                
        }

        private void hTTPSnifferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[4]);
            tabControlToolset.SelectedTab = tabPageHTTPsniffer;
            tabControlToolset.Focus();
        }

        private void injectionBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[5]);
            tabControlToolset.SelectedTab = tabPageInjectionBrowser;
            tabControlToolset.Focus();
        }

        private void mD5SearcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[6]);
            tabControlToolset.SelectedTab = tabPageMD5Searcher;
            tabControlToolset.Focus();
        }

        private void portscannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[7]);
            tabControlToolset.SelectedTab = tabPagePortscanner;
            tabControlToolset.Focus();
        }

        private void regexTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[8]);
            tabControlToolset.SelectedTab = tabPageRegexTester;
            tabControlToolset.Focus();
        }

        private void subdomainScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[9]);
            tabControlToolset.SelectedTab = tabPageSubdomainScanner;
            tabControlToolset.Focus();
        }

        private void webfuzzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[10]);
            tabControlToolset.SelectedTab = tabPageWebfuzzer;
            tabControlToolset.Focus();
          
        }

        private void webserverFinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[11]);
            tabControlToolset.SelectedTab = tabPageWebserverFinder;
            tabControlToolset.Focus();
        }

        private void webserverInformationCatcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTabs();
            tabControlToolset.TabPages.Add(savedTabs[12]);
            tabControlToolset.SelectedTab = tabPageWebserverInformationCatcher;
            tabControlToolset.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnProxySettingsClick(object sender, EventArgs e)
        {
           var frm = new ProxySettings();
           frm.ShowDialog(this);
        }
    }
}
