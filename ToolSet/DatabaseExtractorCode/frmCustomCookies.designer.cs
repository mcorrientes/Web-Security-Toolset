namespace ToolSet.DatabaseExtractorCode
{
    partial class frmCustomCookies
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonClearCookies = new System.Windows.Forms.Button();
            this.buttonAddCookie = new System.Windows.Forms.Button();
            this.listViewCookies = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.textBoxCookieName = new System.Windows.Forms.TextBox();
            this.textBoxCookieValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Image = global::ToolSet.Properties.Resources.tick;
            this.buttonOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOK.Location = new System.Drawing.Point(12, 238);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::ToolSet.Properties.Resources.cross;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.Location = new System.Drawing.Point(344, 238);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonClearCookies
            // 
            this.buttonClearCookies.Image = global::ToolSet.Properties.Resources.minus_circle;
            this.buttonClearCookies.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClearCookies.Location = new System.Drawing.Point(308, 13);
            this.buttonClearCookies.Name = "buttonClearCookies";
            this.buttonClearCookies.Size = new System.Drawing.Size(111, 23);
            this.buttonClearCookies.TabIndex = 0;
            this.buttonClearCookies.Text = "Clear Cookies";
            this.buttonClearCookies.UseVisualStyleBackColor = true;
            this.buttonClearCookies.Click += new System.EventHandler(this.buttonClearCookies_Click);
            // 
            // buttonAddCookie
            // 
            this.buttonAddCookie.Image = global::ToolSet.Properties.Resources.plus_circle;
            this.buttonAddCookie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddCookie.Location = new System.Drawing.Point(308, 178);
            this.buttonAddCookie.Name = "buttonAddCookie";
            this.buttonAddCookie.Size = new System.Drawing.Size(108, 23);
            this.buttonAddCookie.TabIndex = 0;
            this.buttonAddCookie.Text = "Add Cookie";
            this.buttonAddCookie.UseVisualStyleBackColor = true;
            this.buttonAddCookie.Click += new System.EventHandler(this.buttonAddCookie_Click);
            // 
            // listViewCookies
            // 
            this.listViewCookies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewCookies.FullRowSelect = true;
            this.listViewCookies.GridLines = true;
            this.listViewCookies.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewCookies.Location = new System.Drawing.Point(13, 13);
            this.listViewCookies.MultiSelect = false;
            this.listViewCookies.Name = "listViewCookies";
            this.listViewCookies.Size = new System.Drawing.Size(280, 145);
            this.listViewCookies.TabIndex = 1;
            this.listViewCookies.UseCompatibleStateImageBehavior = false;
            this.listViewCookies.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 122;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 134;
            // 
            // textBoxCookieName
            // 
            this.textBoxCookieName.Location = new System.Drawing.Point(10, 180);
            this.textBoxCookieName.Name = "textBoxCookieName";
            this.textBoxCookieName.Size = new System.Drawing.Size(126, 20);
            this.textBoxCookieName.TabIndex = 2;
            // 
            // textBoxCookieValue
            // 
            this.textBoxCookieValue.Location = new System.Drawing.Point(142, 180);
            this.textBoxCookieValue.Name = "textBoxCookieValue";
            this.textBoxCookieValue.Size = new System.Drawing.Size(151, 20);
            this.textBoxCookieValue.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cookie Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cookie Value";
            // 
            // frmCustomCookies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 273);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCookieValue);
            this.Controls.Add(this.textBoxCookieName);
            this.Controls.Add(this.listViewCookies);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAddCookie);
            this.Controls.Add(this.buttonClearCookies);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomCookies";
            this.Text = "Custom Cookies";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonClearCookies;
        private System.Windows.Forms.Button buttonAddCookie;
        private System.Windows.Forms.ListView listViewCookies;
        private System.Windows.Forms.TextBox textBoxCookieName;
        private System.Windows.Forms.TextBox textBoxCookieValue;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}