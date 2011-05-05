namespace usertools.WebFuzzer.Forms.Panels
{
    partial class ucFileGenerator
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
            this.buttonSearchFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxEncoding);
            this.panel1.Controls.Add(this.buttonSearchFile);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxFileName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 274);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxEncoding
            // 
            this.comboBoxEncoding.FormattingEnabled = true;
            this.comboBoxEncoding.Items.AddRange(new object[] {
            "None",
            "URL (normal)",
            "URL (Hex)",
            "Base64",
            "MD5"});
            this.comboBoxEncoding.Location = new System.Drawing.Point(7, 109);
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            this.comboBoxEncoding.Size = new System.Drawing.Size(275, 21);
            this.comboBoxEncoding.TabIndex = 28;
            // 
            // buttonSearchFile
            // 
            this.buttonSearchFile.Image = global::ToolSet.Properties.Resources.binocular;
            this.buttonSearchFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchFile.Location = new System.Drawing.Point(163, 62);
            this.buttonSearchFile.Name = "buttonSearchFile";
            this.buttonSearchFile.Size = new System.Drawing.Size(117, 23);
            this.buttonSearchFile.TabIndex = 27;
            this.buttonSearchFile.Text = "Search File...";
            this.buttonSearchFile.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Encoding:";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(7, 64);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(150, 20);
            this.textBoxFileName.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "File name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(7, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(275, 20);
            this.textBoxName.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Name:";
            // 
            // ucFileGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucFileGenerator";
            this.Size = new System.Drawing.Size(290, 274);
            this.Load += new System.EventHandler(this.File_Generator_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox comboBoxEncoding;
        public System.Windows.Forms.Button buttonSearchFile;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
    }
}
