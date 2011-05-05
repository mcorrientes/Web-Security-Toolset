namespace usertools.WebFuzzer.Forms.Panels
{
    partial class ucCharacterGenerator
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
            this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
            this.numericUpDownIncrement = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStopCharacter = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStartCharacter = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIncrement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartCharacter)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxEncoding);
            this.panel1.Controls.Add(this.numericUpDownIncrement);
            this.panel1.Controls.Add(this.numericUpDownStopCharacter);
            this.panel1.Controls.Add(this.numericUpDownStartCharacter);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 268);
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
            this.comboBoxEncoding.Location = new System.Drawing.Point(5, 197);
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            this.comboBoxEncoding.Size = new System.Drawing.Size(275, 21);
            this.comboBoxEncoding.TabIndex = 37;
            // 
            // numericUpDownIncrement
            // 
            this.numericUpDownIncrement.Location = new System.Drawing.Point(5, 153);
            this.numericUpDownIncrement.Maximum = new decimal(new int[] {
            10000,
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
            this.numericUpDownIncrement.TabIndex = 36;
            this.numericUpDownIncrement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownStopCharacter
            // 
            this.numericUpDownStopCharacter.Location = new System.Drawing.Point(5, 108);
            this.numericUpDownStopCharacter.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownStopCharacter.Name = "numericUpDownStopCharacter";
            this.numericUpDownStopCharacter.Size = new System.Drawing.Size(275, 20);
            this.numericUpDownStopCharacter.TabIndex = 35;
            // 
            // numericUpDownStartCharacter
            // 
            this.numericUpDownStartCharacter.Location = new System.Drawing.Point(5, 63);
            this.numericUpDownStartCharacter.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownStartCharacter.Name = "numericUpDownStartCharacter";
            this.numericUpDownStartCharacter.Size = new System.Drawing.Size(275, 20);
            this.numericUpDownStartCharacter.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Encoding:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Increment:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Stop character (ASCII value):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Start character (ASCII value):";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(5, 18);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(275, 20);
            this.textBoxName.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Name:";
            // 
            // ucCharacterGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucCharacterGenerator";
            this.Size = new System.Drawing.Size(290, 274);
            this.Load += new System.EventHandler(this.ucCharacterGenerator_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIncrement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartCharacter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox comboBoxEncoding;
        public System.Windows.Forms.NumericUpDown numericUpDownIncrement;
        public System.Windows.Forms.NumericUpDown numericUpDownStopCharacter;
        public System.Windows.Forms.NumericUpDown numericUpDownStartCharacter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;

    }
}
