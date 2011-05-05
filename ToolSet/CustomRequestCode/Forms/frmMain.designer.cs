namespace usertools.CustomRequest
{
    partial class frmMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStripRequest = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxProtocol = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxMethod = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxURL = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCookies = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAuthType = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSendRequest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBoxRequestHeaders = new System.Windows.Forms.ComboBox();
            this.buttonAddToList = new System.Windows.Forms.Button();
            this.textBoxHeaderValue = new System.Windows.Forms.TextBox();
            this.listViewRequestHeaders = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.buttonDeleteHeader = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBoxPOST = new System.Windows.Forms.RichTextBox();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listViewResponseHeaders = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.richTextBoxSource = new System.Windows.Forms.RichTextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.webBrowserSource = new System.Windows.Forms.WebBrowser();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStripRequest.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(912, 313);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(904, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Request";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.toolStripRequest);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(898, 281);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 2;
            // 
            // toolStripRequest
            // 
            this.toolStripRequest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripComboBoxProtocol,
            this.toolStripSeparator7,
            this.toolStripLabel1,
            this.toolStripComboBoxMethod,
            this.toolStripSeparator8,
            this.toolStripLabel3,
            this.toolStripTextBoxURL,
            this.toolStripSeparator3,
            this.toolStripButtonCookies,
            this.toolStripSeparator9,
            this.toolStripButtonAuthType,
            this.toolStripSeparator5,
            this.toolStripButtonSendRequest,
            this.toolStripSeparator6});
            this.toolStripRequest.Location = new System.Drawing.Point(0, 0);
            this.toolStripRequest.Name = "toolStripRequest";
            this.toolStripRequest.Size = new System.Drawing.Size(898, 25);
            this.toolStripRequest.TabIndex = 0;
            this.toolStripRequest.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel2.Text = "Protocol";
            // 
            // toolStripComboBoxProtocol
            // 
            this.toolStripComboBoxProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxProtocol.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBoxProtocol.Items.AddRange(new object[] {
            "HTTP /1.0",
            "HTTP /1.1"});
            this.toolStripComboBoxProtocol.Name = "toolStripComboBoxProtocol";
            this.toolStripComboBoxProtocol.Size = new System.Drawing.Size(80, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel1.Text = "Method";
            // 
            // toolStripComboBoxMethod
            // 
            this.toolStripComboBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxMethod.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBoxMethod.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.toolStripComboBoxMethod.Name = "toolStripComboBoxMethod";
            this.toolStripComboBoxMethod.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel3.Text = "URL:";
            // 
            // toolStripTextBoxURL
            // 
            this.toolStripTextBoxURL.Name = "toolStripTextBoxURL";
            this.toolStripTextBoxURL.Size = new System.Drawing.Size(410, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonCookies
            // 
            this.toolStripButtonCookies.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCookies.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButtonCookies.Name = "toolStripButtonCookies";
            this.toolStripButtonCookies.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCookies.Text = "Define Cokies";
            this.toolStripButtonCookies.Click += new System.EventHandler(this.toolStripButtonCookies_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonAuthType
            // 
            this.toolStripButtonAuthType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAuthType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAuthType.Name = "toolStripButtonAuthType";
            this.toolStripButtonAuthType.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAuthType.Text = "Define Authentication";
            this.toolStripButtonAuthType.Click += new System.EventHandler(this.toolStripButtonAuthType_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSendRequest
            // 
            this.toolStripButtonSendRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSendRequest.Name = "toolStripButtonSendRequest";
            this.toolStripButtonSendRequest.Size = new System.Drawing.Size(94, 22);
            this.toolStripButtonSendRequest.Text = "Send Request";
            this.toolStripButtonSendRequest.Click += new System.EventHandler(this.toolStripButtonSendRequest_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer4.Size = new System.Drawing.Size(898, 252);
            this.splitContainer4.SplitterDistance = 546;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 252);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request Headers";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxRequestHeaders);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddToList);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxHeaderValue);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewRequestHeaders);
            this.splitContainer1.Panel2.Controls.Add(this.buttonDeleteHeader);
            this.splitContainer1.Size = new System.Drawing.Size(540, 233);
            this.splitContainer1.SplitterDistance = 33;
            this.splitContainer1.TabIndex = 1;
            // 
            // comboBoxRequestHeaders
            // 
            this.comboBoxRequestHeaders.FormattingEnabled = true;
            this.comboBoxRequestHeaders.Location = new System.Drawing.Point(3, 5);
            this.comboBoxRequestHeaders.Name = "comboBoxRequestHeaders";
            this.comboBoxRequestHeaders.Size = new System.Drawing.Size(169, 21);
            this.comboBoxRequestHeaders.TabIndex = 3;
            // 
            // buttonAddToList
            // 
            this.buttonAddToList.Location = new System.Drawing.Point(450, 3);
            this.buttonAddToList.Name = "buttonAddToList";
            this.buttonAddToList.Size = new System.Drawing.Size(87, 23);
            this.buttonAddToList.TabIndex = 2;
            this.buttonAddToList.Text = "Add to List";
            this.buttonAddToList.UseVisualStyleBackColor = true;
            this.buttonAddToList.Click += new System.EventHandler(this.buttonAddToList_Click);
            // 
            // textBoxHeaderValue
            // 
            this.textBoxHeaderValue.Location = new System.Drawing.Point(178, 5);
            this.textBoxHeaderValue.Name = "textBoxHeaderValue";
            this.textBoxHeaderValue.Size = new System.Drawing.Size(266, 20);
            this.textBoxHeaderValue.TabIndex = 1;
            // 
            // listViewRequestHeaders
            // 
            this.listViewRequestHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewRequestHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRequestHeaders.FullRowSelect = true;
            this.listViewRequestHeaders.GridLines = true;
            this.listViewRequestHeaders.Location = new System.Drawing.Point(0, 0);
            this.listViewRequestHeaders.Name = "listViewRequestHeaders";
            this.listViewRequestHeaders.Size = new System.Drawing.Size(540, 173);
            this.listViewRequestHeaders.TabIndex = 0;
            this.listViewRequestHeaders.UseCompatibleStateImageBehavior = false;
            this.listViewRequestHeaders.View = System.Windows.Forms.View.Details;
            this.listViewRequestHeaders.SelectedIndexChanged += new System.EventHandler(this.listViewRequestHeaders_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Header Name";
            this.columnHeader1.Width = 174;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Header Value";
            this.columnHeader2.Width = 333;
            // 
            // buttonDeleteHeader
            // 
            this.buttonDeleteHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonDeleteHeader.Enabled = false;
            this.buttonDeleteHeader.Location = new System.Drawing.Point(0, 173);
            this.buttonDeleteHeader.Name = "buttonDeleteHeader";
            this.buttonDeleteHeader.Size = new System.Drawing.Size(540, 23);
            this.buttonDeleteHeader.TabIndex = 1;
            this.buttonDeleteHeader.Text = "Delete Headers";
            this.buttonDeleteHeader.UseVisualStyleBackColor = true;
            this.buttonDeleteHeader.Click += new System.EventHandler(this.buttonDeleteHeader_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBoxPOST);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 252);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "POST";
            // 
            // richTextBoxPOST
            // 
            this.richTextBoxPOST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxPOST.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxPOST.Name = "richTextBoxPOST";
            this.richTextBoxPOST.Size = new System.Drawing.Size(342, 233);
            this.richTextBoxPOST.TabIndex = 0;
            this.richTextBoxPOST.Text = "";
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage5);
            this.tabControl4.Controls.Add(this.tabPage6);
            this.tabControl4.Controls.Add(this.tabPage7);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(0, 0);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(912, 256);
            this.tabControl4.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listViewResponseHeaders);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(904, 230);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Response Headers";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listViewResponseHeaders
            // 
            this.listViewResponseHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewResponseHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResponseHeaders.Location = new System.Drawing.Point(3, 3);
            this.listViewResponseHeaders.Name = "listViewResponseHeaders";
            this.listViewResponseHeaders.Size = new System.Drawing.Size(898, 224);
            this.listViewResponseHeaders.TabIndex = 0;
            this.listViewResponseHeaders.UseCompatibleStateImageBehavior = false;
            this.listViewResponseHeaders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Header Name";
            this.columnHeader3.Width = 229;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Header Value";
            this.columnHeader4.Width = 458;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.richTextBoxSource);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(904, 230);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Source Code";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // richTextBoxSource
            // 
            this.richTextBoxSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSource.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxSource.Name = "richTextBoxSource";
            this.richTextBoxSource.Size = new System.Drawing.Size(898, 224);
            this.richTextBoxSource.TabIndex = 0;
            this.richTextBoxSource.Text = "";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.webBrowserSource);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(904, 230);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Browser";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // webBrowserSource
            // 
            this.webBrowserSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserSource.Location = new System.Drawing.Point(0, 0);
            this.webBrowserSource.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserSource.Name = "webBrowserSource";
            this.webBrowserSource.Size = new System.Drawing.Size(904, 230);
            this.webBrowserSource.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer3.Panel2.Controls.Add(this.tabControl4);
            this.splitContainer3.Size = new System.Drawing.Size(912, 573);
            this.splitContainer3.SplitterDistance = 313;
            this.splitContainer3.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 573);
            this.Controls.Add(this.splitContainer3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Custom Request";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.toolStripRequest.ResumeLayout(false);
            this.toolStripRequest.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStripRequest;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxMethod;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxProtocol;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButtonCookies;
        private System.Windows.Forms.ToolStripButton toolStripButtonAuthType;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxURL;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.ListView listViewResponseHeaders;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.RichTextBox richTextBoxSource;
        private System.Windows.Forms.WebBrowser webBrowserSource;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBoxRequestHeaders;
        private System.Windows.Forms.Button buttonAddToList;
        private System.Windows.Forms.TextBox textBoxHeaderValue;
        private System.Windows.Forms.ListView listViewRequestHeaders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripButton toolStripButtonSendRequest;
        private System.Windows.Forms.Button buttonDeleteHeader;
        private System.Windows.Forms.RichTextBox richTextBoxPOST;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}

