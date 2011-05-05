namespace usertools.WebFuzzer.Forms
{
    partial class frmMatchSettings
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
            this.textBoxRegexMatch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSavePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxSaveMatches = new System.Windows.Forms.CheckBox();
            this.buttonSavePath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 123);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(256, 123);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxRegexMatch
            // 
            this.textBoxRegexMatch.Location = new System.Drawing.Point(12, 25);
            this.textBoxRegexMatch.Name = "textBoxRegexMatch";
            this.textBoxRegexMatch.Size = new System.Drawing.Size(319, 20);
            this.textBoxRegexMatch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Regular Expression Match For HTML";
            // 
            // textBoxSavePath
            // 
            this.textBoxSavePath.Location = new System.Drawing.Point(12, 64);
            this.textBoxSavePath.Name = "textBoxSavePath";
            this.textBoxSavePath.Size = new System.Drawing.Size(238, 20);
            this.textBoxSavePath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Save Path";
            // 
            // checkBoxSaveMatches
            // 
            this.checkBoxSaveMatches.AutoSize = true;
            this.checkBoxSaveMatches.Location = new System.Drawing.Point(12, 90);
            this.checkBoxSaveMatches.Name = "checkBoxSaveMatches";
            this.checkBoxSaveMatches.Size = new System.Drawing.Size(122, 17);
            this.checkBoxSaveMatches.TabIndex = 3;
            this.checkBoxSaveMatches.Text = "Save matches to file";
            this.checkBoxSaveMatches.UseVisualStyleBackColor = true;
            // 
            // buttonSavePath
            // 
            this.buttonSavePath.Location = new System.Drawing.Point(256, 62);
            this.buttonSavePath.Name = "buttonSavePath";
            this.buttonSavePath.Size = new System.Drawing.Size(75, 23);
            this.buttonSavePath.TabIndex = 4;
            this.buttonSavePath.Text = "Save Path";
            this.buttonSavePath.UseVisualStyleBackColor = true;
            this.buttonSavePath.Click += new System.EventHandler(this.buttonSavePath_Click);
            // 
            // frmMatchSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 158);
            this.Controls.Add(this.buttonSavePath);
            this.Controls.Add(this.checkBoxSaveMatches);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSavePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRegexMatch);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMatchSettings";
            this.Text = "Match Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSavePath;
        public System.Windows.Forms.TextBox textBoxRegexMatch;
        public System.Windows.Forms.TextBox textBoxSavePath;
        public System.Windows.Forms.CheckBox checkBoxSaveMatches;
    }
}