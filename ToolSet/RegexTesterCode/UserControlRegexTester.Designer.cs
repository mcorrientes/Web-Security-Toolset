namespace ToolSet.RegexTesterCode
{
    partial class UserControlRegexTester
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
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.listViewGroups = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxReplace = new System.Windows.Forms.TextBox();
            this.buttonReplace = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxText = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelRegexTester = new System.Windows.Forms.Panel();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelRegexTester.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Group";
            this.columnHeader1.Width = 135;
            // 
            // listViewGroups
            // 
            this.listViewGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGroups.FullRowSelect = true;
            this.listViewGroups.GridLines = true;
            this.listViewGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewGroups.HideSelection = false;
            this.listViewGroups.Location = new System.Drawing.Point(3, 16);
            this.listViewGroups.MultiSelect = false;
            this.listViewGroups.Name = "listViewGroups";
            this.listViewGroups.Size = new System.Drawing.Size(359, 575);
            this.listViewGroups.TabIndex = 0;
            this.listViewGroups.UseCompatibleStateImageBehavior = false;
            this.listViewGroups.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 197;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxSearch);
            this.groupBox4.Controls.Add(this.buttonSearch);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(365, 42);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Regular Expression";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(6, 16);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(272, 20);
            this.textBoxSearch.TabIndex = 2;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Image = global::ToolSet.Properties.Resources.control;
            this.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearch.Location = new System.Drawing.Point(284, 13);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxReplace);
            this.groupBox3.Controls.Add(this.buttonReplace);
            this.groupBox3.Location = new System.Drawing.Point(3, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(365, 42);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Replace Match With";
            // 
            // textBoxReplace
            // 
            this.textBoxReplace.Location = new System.Drawing.Point(6, 16);
            this.textBoxReplace.Name = "textBoxReplace";
            this.textBoxReplace.Size = new System.Drawing.Size(252, 20);
            this.textBoxReplace.TabIndex = 2;
            // 
            // buttonReplace
            // 
            this.buttonReplace.Enabled = false;
            this.buttonReplace.Image = global::ToolSet.Properties.Resources.document__pencil;
            this.buttonReplace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReplace.Location = new System.Drawing.Point(264, 13);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(95, 23);
            this.buttonReplace.TabIndex = 3;
            this.buttonReplace.Text = "Replace";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewGroups);
            this.groupBox2.Location = new System.Drawing.Point(384, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 594);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Groups";
            // 
            // richTextBoxText
            // 
            this.richTextBoxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxText.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxText.Name = "richTextBoxText";
            this.richTextBoxText.Size = new System.Drawing.Size(359, 485);
            this.richTextBoxText.TabIndex = 4;
            this.richTextBoxText.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBoxText);
            this.groupBox1.Location = new System.Drawing.Point(3, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 504);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text";
            // 
            // panelRegexTester
            // 
            this.panelRegexTester.Controls.Add(this.groupBox4);
            this.panelRegexTester.Controls.Add(this.groupBox1);
            this.panelRegexTester.Controls.Add(this.groupBox3);
            this.panelRegexTester.Controls.Add(this.groupBox2);
            this.panelRegexTester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegexTester.Location = new System.Drawing.Point(0, 0);
            this.panelRegexTester.Name = "panelRegexTester";
            this.panelRegexTester.Size = new System.Drawing.Size(800, 600);
            this.panelRegexTester.TabIndex = 17;
            // 
            // UserControlRegexTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRegexTester);
            this.Name = "UserControlRegexTester";
            this.Size = new System.Drawing.Size(800, 600);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelRegexTester.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listViewGroups;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxReplace;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBoxText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelRegexTester;
    }
}
