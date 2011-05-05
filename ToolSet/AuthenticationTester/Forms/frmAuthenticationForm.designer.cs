namespace usertools.AuthenticationTester.Forms
{
    partial class frmAuthenticationForm
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
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listViewForms = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.buttonSetPassword = new System.Windows.Forms.Button();
            this.buttonSetUsername = new System.Windows.Forms.Button();
            this.listViewInputFields = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonClear = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(78, 6);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.ReadOnly = true;
            this.textBoxURL.Size = new System.Drawing.Size(342, 20);
            this.textBoxURL.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(12, 391);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(371, 391);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // listViewForms
            // 
            this.listViewForms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listViewForms.FullRowSelect = true;
            this.listViewForms.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewForms.HideSelection = false;
            this.listViewForms.Location = new System.Drawing.Point(6, 32);
            this.listViewForms.MultiSelect = false;
            this.listViewForms.Name = "listViewForms";
            this.listViewForms.Size = new System.Drawing.Size(414, 80);
            this.listViewForms.TabIndex = 2;
            this.listViewForms.UseCompatibleStateImageBehavior = false;
            this.listViewForms.View = System.Windows.Forms.View.Details;
            this.listViewForms.SelectedIndexChanged += new System.EventHandler(this.listViewForms_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Action";
            this.columnHeader5.Width = 194;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Method";
            this.columnHeader6.Width = 123;
            // 
            // buttonSetPassword
            // 
            this.buttonSetPassword.Enabled = false;
            this.buttonSetPassword.Location = new System.Drawing.Point(118, 320);
            this.buttonSetPassword.Name = "buttonSetPassword";
            this.buttonSetPassword.Size = new System.Drawing.Size(106, 23);
            this.buttonSetPassword.TabIndex = 1;
            this.buttonSetPassword.Text = "Set Password";
            this.buttonSetPassword.UseVisualStyleBackColor = true;
            this.buttonSetPassword.Click += new System.EventHandler(this.buttonSetPassword_Click);
            // 
            // buttonSetUsername
            // 
            this.buttonSetUsername.Enabled = false;
            this.buttonSetUsername.Location = new System.Drawing.Point(6, 320);
            this.buttonSetUsername.Name = "buttonSetUsername";
            this.buttonSetUsername.Size = new System.Drawing.Size(106, 23);
            this.buttonSetUsername.TabIndex = 1;
            this.buttonSetUsername.Text = "Set Username";
            this.buttonSetUsername.UseVisualStyleBackColor = true;
            this.buttonSetUsername.Click += new System.EventHandler(this.buttonSetUsername_Click);
            // 
            // listViewInputFields
            // 
            this.listViewInputFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewInputFields.Enabled = false;
            this.listViewInputFields.FullRowSelect = true;
            this.listViewInputFields.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewInputFields.HideSelection = false;
            this.listViewInputFields.Location = new System.Drawing.Point(6, 118);
            this.listViewInputFields.MultiSelect = false;
            this.listViewInputFields.Name = "listViewInputFields";
            this.listViewInputFields.Size = new System.Drawing.Size(414, 194);
            this.listViewInputFields.TabIndex = 2;
            this.listViewInputFields.UseCompatibleStateImageBehavior = false;
            this.listViewInputFields.View = System.Windows.Forms.View.Details;
            this.listViewInputFields.SelectedIndexChanged += new System.EventHandler(this.listViewInputFields_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Marked As";
            this.columnHeader4.Width = 69;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 146;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 101;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Value";
            this.columnHeader3.Width = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Target URL:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(434, 375);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.listViewForms);
            this.tabPage1.Controls.Add(this.buttonClear);
            this.tabPage1.Controls.Add(this.buttonSetPassword);
            this.tabPage1.Controls.Add(this.buttonSetUsername);
            this.tabPage1.Controls.Add(this.textBoxURL);
            this.tabPage1.Controls.Add(this.listViewInputFields);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(426, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Form Authentication";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Enabled = false;
            this.buttonClear.Location = new System.Drawing.Point(314, 320);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(106, 23);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // frmAuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 426);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAuthenticationForm";
            this.Text = "Authentication Form";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListView listViewForms;
        private System.Windows.Forms.Button buttonSetPassword;
        private System.Windows.Forms.Button buttonSetUsername;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView listViewInputFields;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonClear;
    }
}