namespace usertools.WebFuzzer.Forms.Panels
{
    partial class ucRandomStringGenerator
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownStringLength = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNumberOfStrings = new System.Windows.Forms.NumericUpDown();
            this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
            this.checkBoxAllowRepetitions = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCharacterSet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStringLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfStrings)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDownStringLength);
            this.panel1.Controls.Add(this.numericUpDownNumberOfStrings);
            this.panel1.Controls.Add(this.comboBoxEncoding);
            this.panel1.Controls.Add(this.checkBoxAllowRepetitions);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxCharacterSet);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 274);
            this.panel1.TabIndex = 0;
            // 
            // numericUpDownStringLength
            // 
            this.numericUpDownStringLength.Location = new System.Drawing.Point(7, 64);
            this.numericUpDownStringLength.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownStringLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownStringLength.Name = "numericUpDownStringLength";
            this.numericUpDownStringLength.Size = new System.Drawing.Size(275, 20);
            this.numericUpDownStringLength.TabIndex = 33;
            this.numericUpDownStringLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownNumberOfStrings
            // 
            this.numericUpDownNumberOfStrings.Location = new System.Drawing.Point(7, 199);
            this.numericUpDownNumberOfStrings.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownNumberOfStrings.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberOfStrings.Name = "numericUpDownNumberOfStrings";
            this.numericUpDownNumberOfStrings.Size = new System.Drawing.Size(275, 20);
            this.numericUpDownNumberOfStrings.TabIndex = 32;
            this.numericUpDownNumberOfStrings.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.comboBoxEncoding.Location = new System.Drawing.Point(7, 244);
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            this.comboBoxEncoding.Size = new System.Drawing.Size(275, 21);
            this.comboBoxEncoding.TabIndex = 31;
            // 
            // checkBoxAllowRepetitions
            // 
            this.checkBoxAllowRepetitions.AutoSize = true;
            this.checkBoxAllowRepetitions.Location = new System.Drawing.Point(10, 159);
            this.checkBoxAllowRepetitions.Name = "checkBoxAllowRepetitions";
            this.checkBoxAllowRepetitions.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAllowRepetitions.TabIndex = 30;
            this.checkBoxAllowRepetitions.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Encoding:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Number of strings:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Allow repetitions:";
            // 
            // textBoxCharacterSet
            // 
            this.textBoxCharacterSet.Location = new System.Drawing.Point(7, 109);
            this.textBoxCharacterSet.Name = "textBoxCharacterSet";
            this.textBoxCharacterSet.Size = new System.Drawing.Size(275, 20);
            this.textBoxCharacterSet.TabIndex = 29;
            this.textBoxCharacterSet.Text = "abcABC0123";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Character set:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "String length:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(7, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(275, 20);
            this.textBoxName.TabIndex = 28;
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
            // ucRandomStringGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucRandomStringGenerator";
            this.Size = new System.Drawing.Size(290, 274);
            this.Load += new System.EventHandler(this.ucRandomStringGenerator_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStringLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfStrings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.NumericUpDown numericUpDownStringLength;
        public System.Windows.Forms.NumericUpDown numericUpDownNumberOfStrings;
        public System.Windows.Forms.ComboBox comboBoxEncoding;
        public System.Windows.Forms.CheckBox checkBoxAllowRepetitions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxCharacterSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;

    }
}
