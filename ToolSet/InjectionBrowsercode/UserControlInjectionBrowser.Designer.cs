namespace ToolSet.InjectionBrowsercode
{
    partial class UserControlInjectionBrowser
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "URL",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Modified URL",
            ""}, -1);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowserForw = new System.Windows.Forms.Button();
            this.textBoxModifier = new System.Windows.Forms.TextBox();
            this.textBoxBrowserURL = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewResult = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.tabControlResult = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.listViewResultInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBoxOriginalPOST = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.richTextBoxModifiedPOST = new System.Windows.Forms.RichTextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.richTextBoxSourceCode = new System.Windows.Forms.RichTextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.webBrowserResult = new System.Windows.Forms.WebBrowser();
            this.buttonBrowserBack = new System.Windows.Forms.Button();
            this.buttonBrowserGo = new System.Windows.Forms.Button();
            this.attackBrowser = new csExWB.cEXWB();
            this.cEXWB1 = new csExWB.cEXWB();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlResult.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 600);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Browser";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.buttonBrowserForw);
            this.splitContainer2.Panel1.Controls.Add(this.buttonBrowserBack);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxModifier);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxBrowserURL);
            this.splitContainer2.Panel1.Controls.Add(this.buttonBrowserGo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.attackBrowser);
            this.splitContainer2.Panel2.Controls.Add(this.cEXWB1);
            this.splitContainer2.Size = new System.Drawing.Size(786, 568);
            this.splitContainer2.SplitterDistance = 33;
            this.splitContainer2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(531, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Modifier:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL:";
            // 
            // buttonBrowserForw
            // 
            this.buttonBrowserForw.Enabled = false;
            this.buttonBrowserForw.Image = global::ToolSet.Properties.Resources.go;
            this.buttonBrowserForw.Location = new System.Drawing.Point(50, 7);
            this.buttonBrowserForw.Name = "buttonBrowserForw";
            this.buttonBrowserForw.Size = new System.Drawing.Size(39, 23);
            this.buttonBrowserForw.TabIndex = 2;
            this.buttonBrowserForw.UseVisualStyleBackColor = true;
            this.buttonBrowserForw.Click += new System.EventHandler(this.buttonBrowserForw_Click);
            // 
            // textBoxModifier
            // 
            this.textBoxModifier.Location = new System.Drawing.Point(581, 11);
            this.textBoxModifier.Name = "textBoxModifier";
            this.textBoxModifier.Size = new System.Drawing.Size(121, 20);
            this.textBoxModifier.TabIndex = 1;
            this.textBoxModifier.Text = "\'\">;--!TEST_PATTERN";
            // 
            // textBoxBrowserURL
            // 
            this.textBoxBrowserURL.Location = new System.Drawing.Point(140, 9);
            this.textBoxBrowserURL.Name = "textBoxBrowserURL";
            this.textBoxBrowserURL.Size = new System.Drawing.Size(349, 20);
            this.textBoxBrowserURL.TabIndex = 1;
            this.textBoxBrowserURL.Text = "http://";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Result";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewResult);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlResult);
            this.splitContainer1.Size = new System.Drawing.Size(786, 568);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 0;
            // 
            // listViewResult
            // 
            this.listViewResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResult.FullRowSelect = true;
            this.listViewResult.GridLines = true;
            this.listViewResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewResult.HideSelection = false;
            this.listViewResult.Location = new System.Drawing.Point(0, 0);
            this.listViewResult.MultiSelect = false;
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size(786, 261);
            this.listViewResult.TabIndex = 0;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            this.listViewResult.View = System.Windows.Forms.View.Details;
            this.listViewResult.SelectedIndexChanged += new System.EventHandler(this.listViewResult_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "URL";
            this.columnHeader3.Width = 301;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "POST";
            this.columnHeader4.Width = 344;
            // 
            // tabControlResult
            // 
            this.tabControlResult.Controls.Add(this.tabPage7);
            this.tabControlResult.Controls.Add(this.tabPage3);
            this.tabControlResult.Controls.Add(this.tabPage4);
            this.tabControlResult.Controls.Add(this.tabPage5);
            this.tabControlResult.Controls.Add(this.tabPage6);
            this.tabControlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlResult.Location = new System.Drawing.Point(0, 0);
            this.tabControlResult.Name = "tabControlResult";
            this.tabControlResult.SelectedIndex = 0;
            this.tabControlResult.Size = new System.Drawing.Size(786, 303);
            this.tabControlResult.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.listViewResultInfo);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(778, 277);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "Result Info";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // listViewResultInfo
            // 
            this.listViewResultInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewResultInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResultInfo.FullRowSelect = true;
            this.listViewResultInfo.HideSelection = false;
            this.listViewResultInfo.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listViewResultInfo.Location = new System.Drawing.Point(3, 3);
            this.listViewResultInfo.MultiSelect = false;
            this.listViewResultInfo.Name = "listViewResultInfo";
            this.listViewResultInfo.Size = new System.Drawing.Size(772, 271);
            this.listViewResultInfo.TabIndex = 0;
            this.listViewResultInfo.UseCompatibleStateImageBehavior = false;
            this.listViewResultInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 309;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBoxOriginalPOST);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(778, 277);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Original POST";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBoxOriginalPOST
            // 
            this.richTextBoxOriginalPOST.DetectUrls = false;
            this.richTextBoxOriginalPOST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOriginalPOST.HideSelection = false;
            this.richTextBoxOriginalPOST.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxOriginalPOST.Name = "richTextBoxOriginalPOST";
            this.richTextBoxOriginalPOST.Size = new System.Drawing.Size(772, 271);
            this.richTextBoxOriginalPOST.TabIndex = 1;
            this.richTextBoxOriginalPOST.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.richTextBoxModifiedPOST);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(778, 277);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Modified POST";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // richTextBoxModifiedPOST
            // 
            this.richTextBoxModifiedPOST.DetectUrls = false;
            this.richTextBoxModifiedPOST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxModifiedPOST.HideSelection = false;
            this.richTextBoxModifiedPOST.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxModifiedPOST.Name = "richTextBoxModifiedPOST";
            this.richTextBoxModifiedPOST.Size = new System.Drawing.Size(772, 271);
            this.richTextBoxModifiedPOST.TabIndex = 1;
            this.richTextBoxModifiedPOST.Text = "";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.richTextBoxSourceCode);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(778, 277);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Source Code";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // richTextBoxSourceCode
            // 
            this.richTextBoxSourceCode.DetectUrls = false;
            this.richTextBoxSourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxSourceCode.HideSelection = false;
            this.richTextBoxSourceCode.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxSourceCode.Name = "richTextBoxSourceCode";
            this.richTextBoxSourceCode.Size = new System.Drawing.Size(772, 271);
            this.richTextBoxSourceCode.TabIndex = 0;
            this.richTextBoxSourceCode.Text = "";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.webBrowserResult);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(778, 277);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Browser";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // webBrowserResult
            // 
            this.webBrowserResult.AllowWebBrowserDrop = false;
            this.webBrowserResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserResult.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserResult.Location = new System.Drawing.Point(3, 3);
            this.webBrowserResult.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserResult.Name = "webBrowserResult";
            this.webBrowserResult.ScriptErrorsSuppressed = true;
            this.webBrowserResult.Size = new System.Drawing.Size(772, 271);
            this.webBrowserResult.TabIndex = 0;
            this.webBrowserResult.WebBrowserShortcutsEnabled = false;
            // 
            // buttonBrowserBack
            // 
            this.buttonBrowserBack.Enabled = false;
            this.buttonBrowserBack.Image = global::ToolSet.Properties.Resources.back;
            this.buttonBrowserBack.Location = new System.Drawing.Point(5, 7);
            this.buttonBrowserBack.Name = "buttonBrowserBack";
            this.buttonBrowserBack.Size = new System.Drawing.Size(39, 23);
            this.buttonBrowserBack.TabIndex = 2;
            this.buttonBrowserBack.UseVisualStyleBackColor = true;
            this.buttonBrowserBack.Click += new System.EventHandler(this.buttonBrowserBack_Click);
            // 
            // buttonBrowserGo
            // 
            this.buttonBrowserGo.Image = global::ToolSet.Properties.Resources.control;
            this.buttonBrowserGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBrowserGo.Location = new System.Drawing.Point(708, 8);
            this.buttonBrowserGo.Name = "buttonBrowserGo";
            this.buttonBrowserGo.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowserGo.TabIndex = 0;
            this.buttonBrowserGo.Text = "Go";
            this.buttonBrowserGo.UseVisualStyleBackColor = true;
            this.buttonBrowserGo.Click += new System.EventHandler(this.buttonBrowserGo_Click);
            // 
            // attackBrowser
            // 
            this.attackBrowser.Border3DEnabled = false;
            this.attackBrowser.DocumentSource = "<HTML><HEAD></HEAD>\r\n<BODY></BODY></HTML>";
            this.attackBrowser.DocumentTitle = "";
            this.attackBrowser.DownloadActiveX = true;
            this.attackBrowser.DownloadFrames = true;
            this.attackBrowser.DownloadImages = true;
            this.attackBrowser.DownloadJava = true;
            this.attackBrowser.DownloadScripts = true;
            this.attackBrowser.DownloadSounds = true;
            this.attackBrowser.DownloadVideo = true;
            this.attackBrowser.FileDownloadDirectory = "C:\\Users\\Administrator.ELANIZE.000\\Documents\\";
            this.attackBrowser.Location = new System.Drawing.Point(0, 0);
            this.attackBrowser.LocationUrl = "about:blank";
            this.attackBrowser.Name = "attackBrowser";
            this.attackBrowser.ObjectForScripting = null;
            this.attackBrowser.OffLine = false;
            this.attackBrowser.RegisterAsBrowser = true;
            this.attackBrowser.RegisterAsDropTarget = false;
            this.attackBrowser.RegisterForInternalDragDrop = true;
            this.attackBrowser.ScrollBarsEnabled = false;
            this.attackBrowser.SendSourceOnDocumentCompleteWBEx = false;
            this.attackBrowser.Silent = true;
            this.attackBrowser.Size = new System.Drawing.Size(590, 201);
            this.attackBrowser.TabIndex = 1;
            this.attackBrowser.Text = "cEXWB2";
            this.attackBrowser.TextSize = IfacesEnumsStructsClasses.TextSizeWB.Medium;
            this.attackBrowser.UseInternalDownloadManager = true;
            this.attackBrowser.Visible = false;
            this.attackBrowser.WBDOCDOWNLOADCTLFLAG = 112;
            this.attackBrowser.WBDOCHOSTUIDBLCLK = IfacesEnumsStructsClasses.DOCHOSTUIDBLCLK.DEFAULT;
            this.attackBrowser.WBDOCHOSTUIFLAG = 262156;
            // 
            // cEXWB1
            // 
            this.cEXWB1.Border3DEnabled = false;
            this.cEXWB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cEXWB1.DocumentSource = "<HTML><HEAD></HEAD>\r\n<BODY></BODY></HTML>";
            this.cEXWB1.DocumentTitle = "";
            this.cEXWB1.DownloadActiveX = true;
            this.cEXWB1.DownloadFrames = true;
            this.cEXWB1.DownloadImages = true;
            this.cEXWB1.DownloadJava = true;
            this.cEXWB1.DownloadScripts = true;
            this.cEXWB1.DownloadSounds = true;
            this.cEXWB1.DownloadVideo = true;
            this.cEXWB1.FileDownloadDirectory = "C:\\Users\\Administrator.ELANIZE.000\\Documents\\";
            this.cEXWB1.Location = new System.Drawing.Point(0, 0);
            this.cEXWB1.LocationUrl = "about:blank";
            this.cEXWB1.Name = "cEXWB1";
            this.cEXWB1.ObjectForScripting = null;
            this.cEXWB1.OffLine = false;
            this.cEXWB1.RegisterAsBrowser = false;
            this.cEXWB1.RegisterAsDropTarget = false;
            this.cEXWB1.RegisterForInternalDragDrop = true;
            this.cEXWB1.ScrollBarsEnabled = true;
            this.cEXWB1.SendSourceOnDocumentCompleteWBEx = false;
            this.cEXWB1.Silent = true;
            this.cEXWB1.Size = new System.Drawing.Size(786, 531);
            this.cEXWB1.TabIndex = 0;
            this.cEXWB1.Text = "cEXWB1";
            this.cEXWB1.TextSize = IfacesEnumsStructsClasses.TextSizeWB.Medium;
            this.cEXWB1.UseInternalDownloadManager = true;
            this.cEXWB1.WBDOCDOWNLOADCTLFLAG = 112;
            this.cEXWB1.WBDOCHOSTUIDBLCLK = IfacesEnumsStructsClasses.DOCHOSTUIDBLCLK.DEFAULT;
            this.cEXWB1.WBDOCHOSTUIFLAG = 262276;
            this.cEXWB1.DownloadRequestSynch += new csExWB.SynchDownloadRequestEventHandler(this.cEXWB1_DownloadRequestSynch);
            this.cEXWB1.NavigateComplete2 += new csExWB.NavigateComplete2EventHandler(this.cEXWB1_NavigateComplete2);
            this.cEXWB1.DownloadRequestAsynch += new csExWB.AsynchDownloadRequestEventHandler(this.cEXWB1_DownloadRequestAsynch);
            // 
            // UserControlInjectionBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "UserControlInjectionBrowser";
            this.Size = new System.Drawing.Size(800, 600);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControlResult.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowserForw;
        private System.Windows.Forms.Button buttonBrowserBack;
        private System.Windows.Forms.TextBox textBoxModifier;
        private System.Windows.Forms.TextBox textBoxBrowserURL;
        private System.Windows.Forms.Button buttonBrowserGo;
        private csExWB.cEXWB attackBrowser;
        private csExWB.cEXWB cEXWB1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabControl tabControlResult;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.ListView listViewResultInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBoxOriginalPOST;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox richTextBoxModifiedPOST;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox richTextBoxSourceCode;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.WebBrowser webBrowserResult;
    }
}
