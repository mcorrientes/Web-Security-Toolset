namespace ToolSet.WebserverFinderCode
{
    partial class UserControlWebserverFinder
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
            this.listViewServers = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.listViewResponseHeaders = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBoxSource = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.webBrowserSource = new System.Windows.Forms.WebBrowser();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.progressBarTargetFinder = new System.Windows.Forms.ProgressBar();
            this.buttonCreateReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPorts = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.timerGUI = new System.Windows.Forms.Timer(this.components);
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewServers
            // 
            this.listViewServers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewServers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.listViewServers.Size = new System.Drawing.Size(800, 232);
            this.listViewServers.TabIndex = 0;
            this.listViewServers.UseCompatibleStateImageBehavior = false;
            this.listViewServers.View = System.Windows.Forms.View.Details;
            this.listViewServers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewServers_ItemSelectionChanged);
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
            this.listViewResponseHeaders.Size = new System.Drawing.Size(786, 225);
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewResponseHeaders);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 231);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Response Headers";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.tabControl1.Size = new System.Drawing.Size(800, 257);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBoxSource);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 231);
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
            this.richTextBoxSource.Size = new System.Drawing.Size(786, 225);
            this.richTextBoxSource.TabIndex = 0;
            this.richTextBoxSource.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.webBrowserSource);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 231);
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
            this.webBrowserSource.Size = new System.Drawing.Size(786, 225);
            this.webBrowserSource.TabIndex = 0;
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
            this.splitContainer3.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.progressBarTargetFinder);
            this.splitContainer3.Panel2MinSize = 10;
            this.splitContainer3.Size = new System.Drawing.Size(800, 276);
            this.splitContainer3.SplitterDistance = 257;
            this.splitContainer3.TabIndex = 1;
            // 
            // progressBarTargetFinder
            // 
            this.progressBarTargetFinder.Location = new System.Drawing.Point(604, 2);
            this.progressBarTargetFinder.Name = "progressBarTargetFinder";
            this.progressBarTargetFinder.Size = new System.Drawing.Size(176, 10);
            this.progressBarTargetFinder.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarTargetFinder.TabIndex = 0;
            // 
            // buttonCreateReport
            // 
            this.buttonCreateReport.Image = global::ToolSet.Properties.Resources.document_pdf;
            this.buttonCreateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCreateReport.Location = new System.Drawing.Point(677, 1);
            this.buttonCreateReport.Name = "buttonCreateReport";
            this.buttonCreateReport.Size = new System.Drawing.Size(115, 23);
            this.buttonCreateReport.TabIndex = 0;
            this.buttonCreateReport.Text = "Create Report";
            this.buttonCreateReport.UseVisualStyleBackColor = true;
            this.buttonCreateReport.Click += new System.EventHandler(this.buttonCreateReport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(601, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ports";
            // 
            // textBoxPorts
            // 
            this.textBoxPorts.Location = new System.Drawing.Point(604, 25);
            this.textBoxPorts.Name = "textBoxPorts";
            this.textBoxPorts.Size = new System.Drawing.Size(100, 20);
            this.textBoxPorts.TabIndex = 2;
            this.textBoxPorts.Text = "80, 443";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Range";
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
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxPorts);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxIPAddress);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 600);
            this.splitContainer1.SplitterDistance = 55;
            this.splitContainer1.TabIndex = 1;
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(12, 25);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(586, 20);
            this.textBoxIPAddress.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Image = global::ToolSet.Properties.Resources.control;
            this.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearch.Location = new System.Drawing.Point(710, 23);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(800, 541);
            this.splitContainer2.SplitterDistance = 261;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.listViewServers);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.buttonCreateReport);
            this.splitContainer4.Size = new System.Drawing.Size(800, 261);
            this.splitContainer4.SplitterDistance = 232;
            this.splitContainer4.TabIndex = 1;
            // 
            // timerGUI
            // 
            this.timerGUI.Enabled = true;
            this.timerGUI.Interval = 1000;
            this.timerGUI.Tick += new System.EventHandler(this.timerGUI_Tick);
            // 
            // UserControlWebserverFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControlWebserverFinder";
            this.Size = new System.Drawing.Size(800, 600);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewServers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listViewResponseHeaders;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBoxSource;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.WebBrowser webBrowserSource;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ProgressBar progressBarTargetFinder;
        private System.Windows.Forms.Button buttonCreateReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Timer timerGUI;
    }
}
