namespace ToolSet.HTTPSnifferCode
{
    partial class UserControlHTTPSniffer
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "URL",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "TIME",
            ""}, -1);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonListen = new System.Windows.Forms.Button();
            this.numericUpDownSnifferPort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewSnifferOutput = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listViewInfo = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.richTextBoxPOST = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBoxRequestHeaders = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBoxResponseHeaders = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBoxSource = new System.Windows.Forms.RichTextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.webBrowserSource = new System.Windows.Forms.WebBrowser();
            this.timerGUI = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSnifferPort)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.buttonListen);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDownSnifferPort);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 600);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 1;
            // 
            // buttonListen
            // 
            this.buttonListen.Image = global::ToolSet.Properties.Resources.control;
            this.buttonListen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonListen.Location = new System.Drawing.Point(258, 8);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(94, 23);
            this.buttonListen.TabIndex = 2;
            this.buttonListen.Text = "Listen";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // numericUpDownSnifferPort
            // 
            this.numericUpDownSnifferPort.Location = new System.Drawing.Point(106, 11);
            this.numericUpDownSnifferPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownSnifferPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSnifferPort.Name = "numericUpDownSnifferPort";
            this.numericUpDownSnifferPort.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSnifferPort.TabIndex = 1;
            this.numericUpDownSnifferPort.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listen to Port:";
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewSnifferOutput);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(800, 556);
            this.splitContainer2.SplitterDistance = 321;
            this.splitContainer2.TabIndex = 1;
            // 
            // listViewSnifferOutput
            // 
            this.listViewSnifferOutput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewSnifferOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSnifferOutput.FullRowSelect = true;
            this.listViewSnifferOutput.GridLines = true;
            this.listViewSnifferOutput.HideSelection = false;
            this.listViewSnifferOutput.Location = new System.Drawing.Point(0, 0);
            this.listViewSnifferOutput.MultiSelect = false;
            this.listViewSnifferOutput.Name = "listViewSnifferOutput";
            this.listViewSnifferOutput.Size = new System.Drawing.Size(800, 321);
            this.listViewSnifferOutput.TabIndex = 0;
            this.listViewSnifferOutput.UseCompatibleStateImageBehavior = false;
            this.listViewSnifferOutput.View = System.Windows.Forms.View.Details;
            this.listViewSnifferOutput.SelectedIndexChanged += new System.EventHandler(this.listViewSnifferOutput_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time";
            this.columnHeader1.Width = 83;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "URL";
            this.columnHeader2.Width = 265;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "POST";
            this.columnHeader3.Width = 326;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 231);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listViewInfo);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 205);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Info";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listViewInfo
            // 
            this.listViewInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.listViewInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewInfo.FullRowSelect = true;
            this.listViewInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewInfo.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listViewInfo.Location = new System.Drawing.Point(3, 3);
            this.listViewInfo.Name = "listViewInfo";
            this.listViewInfo.Size = new System.Drawing.Size(786, 199);
            this.listViewInfo.TabIndex = 0;
            this.listViewInfo.UseCompatibleStateImageBehavior = false;
            this.listViewInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 67;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Value";
            this.columnHeader5.Width = 477;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.richTextBoxPOST);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(792, 205);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "POST";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // richTextBoxPOST
            // 
            this.richTextBoxPOST.DetectUrls = false;
            this.richTextBoxPOST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxPOST.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxPOST.Name = "richTextBoxPOST";
            this.richTextBoxPOST.Size = new System.Drawing.Size(786, 199);
            this.richTextBoxPOST.TabIndex = 2;
            this.richTextBoxPOST.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBoxRequestHeaders);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 205);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Request Headers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBoxRequestHeaders
            // 
            this.richTextBoxRequestHeaders.DetectUrls = false;
            this.richTextBoxRequestHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxRequestHeaders.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxRequestHeaders.Name = "richTextBoxRequestHeaders";
            this.richTextBoxRequestHeaders.Size = new System.Drawing.Size(786, 199);
            this.richTextBoxRequestHeaders.TabIndex = 1;
            this.richTextBoxRequestHeaders.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBoxResponseHeaders);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Response Headers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBoxResponseHeaders
            // 
            this.richTextBoxResponseHeaders.DetectUrls = false;
            this.richTextBoxResponseHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxResponseHeaders.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxResponseHeaders.Name = "richTextBoxResponseHeaders";
            this.richTextBoxResponseHeaders.Size = new System.Drawing.Size(786, 199);
            this.richTextBoxResponseHeaders.TabIndex = 1;
            this.richTextBoxResponseHeaders.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBoxSource);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 205);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Source Code";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBoxSource
            // 
            this.richTextBoxSource.DetectUrls = false;
            this.richTextBoxSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSource.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxSource.Name = "richTextBoxSource";
            this.richTextBoxSource.Size = new System.Drawing.Size(786, 199);
            this.richTextBoxSource.TabIndex = 0;
            this.richTextBoxSource.Text = "";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.webBrowserSource);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(792, 205);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Browser";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // webBrowserSource
            // 
            this.webBrowserSource.AllowWebBrowserDrop = false;
            this.webBrowserSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserSource.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserSource.Location = new System.Drawing.Point(3, 3);
            this.webBrowserSource.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserSource.Name = "webBrowserSource";
            this.webBrowserSource.ScriptErrorsSuppressed = true;
            this.webBrowserSource.Size = new System.Drawing.Size(786, 199);
            this.webBrowserSource.TabIndex = 0;
            this.webBrowserSource.WebBrowserShortcutsEnabled = false;
            // 
            // timerGUI
            // 
            this.timerGUI.Enabled = true;
            this.timerGUI.Interval = 1000;
            this.timerGUI.Tick += new System.EventHandler(this.timerGUI_Tick);
            // 
            // UserControlHTTPSniffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControlHTTPSniffer";
            this.Size = new System.Drawing.Size(800, 600);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSnifferPort)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.NumericUpDown numericUpDownSnifferPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewSnifferOutput;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView listViewInfo;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.RichTextBox richTextBoxPOST;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBoxRequestHeaders;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBoxResponseHeaders;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBoxSource;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.WebBrowser webBrowserSource;
        private System.Windows.Forms.Timer timerGUI;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
