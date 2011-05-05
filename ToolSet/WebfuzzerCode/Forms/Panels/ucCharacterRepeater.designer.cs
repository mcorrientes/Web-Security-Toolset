namespace usertools.WebFuzzer.Forms.Panels
{
    partial class ucCharacterRepeater
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
            this.numericUpDownInitialCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFinalCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownIncrement = new System.Windows.Forms.NumericUpDown();
            this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCharacterString = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFinalCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIncrement)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDownInitialCount);
            this.panel1.Controls.Add(this.numericUpDownFinalCount);
            this.panel1.Controls.Add(this.numericUpDownIncrement);
            this.panel1.Controls.Add(this.comboBoxEncoding);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxCharacterString);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 274);
            this.panel1.TabIndex = 0;
            // 
            // numericUpDownInitialCount
            // 
            this.numericUpDownInitialCount.Location = new System.Drawing.Point(7, 108);
            this.numericUpDownInitialCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownInitialCount.Name = "numericUpDownInitialCount";
            this.numericUpDownInitialCount.Size = new System.Drawing.Size(275, 20);
            this.numericUpDownInitialCount.TabIndex = 33;
            this.numericUpDownInitialCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownFinalCount
            // 
            this.numericUpDownFinalCount.Location = new System.Drawing.Point(7, 153);
            this.numericUpDownFinalCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownFinalCount.Name = "numericUpDownFinalCount";
            this.numericUpDownFinalCount.Size = new System.Drawing.Size(275, 20);
            this.numericUpDownFinalCount.TabIndex = 32;
            this.numericUpDownFinalCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownIncrement
            // 
            this.numericUpDownIncrement.Location = new System.Drawing.Point(7, 198);
            this.numericUpDownIncrement.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownIncrement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownIncrement.Name = "numericUpDownIncrement";
            this.numericUpDownIncrement.Size = new System.Drawing.Size(275, 20);
            this.numericUpDownIncrement.TabIndex = 31;
            this.numericUpDownIncrement.Value = new decimal(new int[] {
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
            this.comboBoxEncoding.Location = new System.Drawing.Point(7, 243);
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            this.comboBoxEncoding.Size = new System.Drawing.Size(275, 21);
            this.comboBoxEncoding.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Encoding:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Increment:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Final count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Initial count:";
            // 
            // textBoxCharacterString
            // 
            this.textBoxCharacterString.Location = new System.Drawing.Point(7, 63);
            this.textBoxCharacterString.Name = "textBoxCharacterString";
            this.textBoxCharacterString.Size = new System.Drawing.Size(275, 20);
            this.textBoxCharacterString.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Character/string:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(7, 18);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(275, 20);
            this.textBoxName.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Name:";
            // 
            // ucCharacterRepeater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucCharacterRepeater";
            this.Size = new System.Drawing.Size(290, 274);
            this.Load += new System.EventHandler(this.ucCharacter_Repeater_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFinalCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIncrement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.NumericUpDown numericUpDownInitialCount;
        public System.Windows.Forms.NumericUpDown numericUpDownFinalCount;
        public System.Windows.Forms.NumericUpDown numericUpDownIncrement;
        public System.Windows.Forms.ComboBox comboBoxEncoding;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxCharacterString;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;

    }
}
