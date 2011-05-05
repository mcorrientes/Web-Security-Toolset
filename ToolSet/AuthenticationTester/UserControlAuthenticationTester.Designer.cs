namespace ToolSet.AuthenticationTesterCode
{
    partial class UserControlAuthenticationTester
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxPasswordFile = new System.Windows.Forms.TextBox();
            this.textBoxUsernameFile = new System.Windows.Forms.TextBox();
            this.comboBoxCondition = new System.Windows.Forms.ComboBox();
            this.comboBoxAuthMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCondition = new System.Windows.Forms.TextBox();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.listViewAuths = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripProgressBarAuthTester = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.timerGUI = new System.Windows.Forms.Timer(this.components);
            this.buttonSelectFields = new System.Windows.Forms.Button();
            this.buttonSelectPasswordFile = new System.Windows.Forms.Button();
            this.buttonSelectUsernameFile = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.toolStripButtonSaveList = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonSelectFields);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxPasswordFile);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxUsernameFile);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxCondition);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxAuthMethod);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSelectPasswordFile);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSelectUsernameFile);
            this.splitContainer1.Panel1.Controls.Add(this.buttonStart);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxCondition);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxURL);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewAuths);
            this.splitContainer1.Size = new System.Drawing.Size(800, 575);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 2;
            // 
            // textBoxPasswordFile
            // 
            this.textBoxPasswordFile.Location = new System.Drawing.Point(152, 122);
            this.textBoxPasswordFile.Name = "textBoxPasswordFile";
            this.textBoxPasswordFile.Size = new System.Drawing.Size(375, 20);
            this.textBoxPasswordFile.TabIndex = 13;
            // 
            // textBoxUsernameFile
            // 
            this.textBoxUsernameFile.Location = new System.Drawing.Point(152, 96);
            this.textBoxUsernameFile.Name = "textBoxUsernameFile";
            this.textBoxUsernameFile.Size = new System.Drawing.Size(375, 20);
            this.textBoxUsernameFile.TabIndex = 10;
            // 
            // comboBoxCondition
            // 
            this.comboBoxCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCondition.FormattingEnabled = true;
            this.comboBoxCondition.Items.AddRange(new object[] {
            "HTTP status code is",
            "HTTP status code is not",
            "HTML contains",
            "HTML does not contain",
            "Regular Expression For HTML"});
            this.comboBoxCondition.Location = new System.Drawing.Point(152, 69);
            this.comboBoxCondition.Name = "comboBoxCondition";
            this.comboBoxCondition.Size = new System.Drawing.Size(233, 21);
            this.comboBoxCondition.TabIndex = 7;
            // 
            // comboBoxAuthMethod
            // 
            this.comboBoxAuthMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAuthMethod.FormattingEnabled = true;
            this.comboBoxAuthMethod.Items.AddRange(new object[] {
            "Basic Authentication (HTTP)",
            "HTML form based"});
            this.comboBoxAuthMethod.Location = new System.Drawing.Point(152, 42);
            this.comboBoxAuthMethod.Name = "comboBoxAuthMethod";
            this.comboBoxAuthMethod.Size = new System.Drawing.Size(233, 21);
            this.comboBoxAuthMethod.TabIndex = 4;
            this.comboBoxAuthMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxAuthMethod_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Password file:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Username file:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Login succeeded if:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Authentication method:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Target URL:";
            // 
            // textBoxCondition
            // 
            this.textBoxCondition.Location = new System.Drawing.Point(425, 69);
            this.textBoxCondition.Name = "textBoxCondition";
            this.textBoxCondition.Size = new System.Drawing.Size(216, 20);
            this.textBoxCondition.TabIndex = 8;
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(152, 15);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(489, 20);
            this.textBoxURL.TabIndex = 1;
            this.textBoxURL.Text = "http://www.testsite.com/login/";
            this.textBoxURL.TextChanged += new System.EventHandler(this.textBoxURL_TextChanged);
            // 
            // listViewAuths
            // 
            this.listViewAuths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewAuths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAuths.FullRowSelect = true;
            this.listViewAuths.GridLines = true;
            this.listViewAuths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewAuths.HideSelection = false;
            this.listViewAuths.Location = new System.Drawing.Point(0, 0);
            this.listViewAuths.Name = "listViewAuths";
            this.listViewAuths.Size = new System.Drawing.Size(800, 382);
            this.listViewAuths.TabIndex = 0;
            this.listViewAuths.UseCompatibleStateImageBehavior = false;
            this.listViewAuths.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Valid Username";
            this.columnHeader1.Width = 240;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Valid Password";
            this.columnHeader2.Width = 326;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarAuthTester,
            this.toolStripSeparator2,
            this.toolStripButtonSaveList,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 575);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripProgressBarAuthTester
            // 
            this.toolStripProgressBarAuthTester.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBarAuthTester.Name = "toolStripProgressBarAuthTester";
            this.toolStripProgressBarAuthTester.Size = new System.Drawing.Size(200, 22);
            this.toolStripProgressBarAuthTester.Step = 1;
            this.toolStripProgressBarAuthTester.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // timerGUI
            // 
            this.timerGUI.Enabled = true;
            this.timerGUI.Interval = 1000;
            this.timerGUI.Tick += new System.EventHandler(this.timerGUI_Tick);
            // 
            // buttonSelectFields
            // 
            this.buttonSelectFields.Image = global::ToolSet.Properties.Resources.binocular;
            this.buttonSelectFields.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSelectFields.Location = new System.Drawing.Point(425, 40);
            this.buttonSelectFields.Name = "buttonSelectFields";
            this.buttonSelectFields.Size = new System.Drawing.Size(216, 23);
            this.buttonSelectFields.TabIndex = 5;
            this.buttonSelectFields.Text = "Select User/Password Field";
            this.buttonSelectFields.UseVisualStyleBackColor = true;
            this.buttonSelectFields.Visible = false;
            this.buttonSelectFields.Click += new System.EventHandler(this.buttonSelectFields_Click);
            // 
            // buttonSelectPasswordFile
            // 
            this.buttonSelectPasswordFile.Image = global::ToolSet.Properties.Resources.folder_open_document;
            this.buttonSelectPasswordFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSelectPasswordFile.Location = new System.Drawing.Point(542, 120);
            this.buttonSelectPasswordFile.Name = "buttonSelectPasswordFile";
            this.buttonSelectPasswordFile.Size = new System.Drawing.Size(99, 23);
            this.buttonSelectPasswordFile.TabIndex = 14;
            this.buttonSelectPasswordFile.Text = "Select File";
            this.buttonSelectPasswordFile.UseVisualStyleBackColor = true;
            this.buttonSelectPasswordFile.Click += new System.EventHandler(this.buttonSelectPasswordFile_Click);
            // 
            // buttonSelectUsernameFile
            // 
            this.buttonSelectUsernameFile.Image = global::ToolSet.Properties.Resources.folder_open_document;
            this.buttonSelectUsernameFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSelectUsernameFile.Location = new System.Drawing.Point(542, 94);
            this.buttonSelectUsernameFile.Name = "buttonSelectUsernameFile";
            this.buttonSelectUsernameFile.Size = new System.Drawing.Size(99, 23);
            this.buttonSelectUsernameFile.TabIndex = 11;
            this.buttonSelectUsernameFile.Text = "Select File";
            this.buttonSelectUsernameFile.UseVisualStyleBackColor = true;
            this.buttonSelectUsernameFile.Click += new System.EventHandler(this.buttonSelectUsernameFile_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Image = global::ToolSet.Properties.Resources.control;
            this.buttonStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStart.Location = new System.Drawing.Point(542, 161);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(99, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // toolStripButtonSaveList
            // 
            this.toolStripButtonSaveList.Image = global::ToolSet.Properties.Resources.document_pdf;
            this.toolStripButtonSaveList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveList.Name = "toolStripButtonSaveList";
            this.toolStripButtonSaveList.Size = new System.Drawing.Size(96, 22);
            this.toolStripButtonSaveList.Text = "Create Report";
            this.toolStripButtonSaveList.ToolTipText = "Saves the found usernames and passwords";
            this.toolStripButtonSaveList.Click += new System.EventHandler(this.toolStripButtonSaveList_Click);
            // 
            // UserControlAuthenticationTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UserControlAuthenticationTester";
            this.Size = new System.Drawing.Size(800, 600);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonSelectFields;
        private System.Windows.Forms.TextBox textBoxPasswordFile;
        private System.Windows.Forms.TextBox textBoxUsernameFile;
        private System.Windows.Forms.ComboBox comboBoxCondition;
        private System.Windows.Forms.ComboBox comboBoxAuthMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectPasswordFile;
        private System.Windows.Forms.Button buttonSelectUsernameFile;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxCondition;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.ListView listViewAuths;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarAuthTester;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer timerGUI;
    }
}
