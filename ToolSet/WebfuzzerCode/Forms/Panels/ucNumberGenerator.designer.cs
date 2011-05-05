namespace usertools.WebFuzzer.Forms.Panels
{
    partial class ucNumberGenerator
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
            this.numericUpDownStartNumber = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStopNumber = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownIncrement = new System.Windows.Forms.NumericUpDown();
            this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIncrement)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDownStartNumber);
            this.panel1.Controls.Add(this.numericUpDownStopNumber);
            this.panel1.Controls.Add(this.numericUpDownIncrement);
            this.panel1.Controls.Add(this.comboBoxEncoding);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
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
            // numericUpDownStartNumber
            // 
            this.numericUpDownStartNumber.Location = new System.Drawing.Point(8, 64);
            this.numericUpDownStartNumber.Name = "numericUpDownStartNumber";
            this.numericUpDownStartNumber.Size = new System.Drawing.Size(275, 20);
            this.numericUpDownStartNumber.TabIndex = 35;
            // 
            // numericUpDownStopNumber
            // 
            this.numericUpDownStopNumber.Location = new System.Drawing.Point(8, 110);
            this.numericUpDownStopNumber.Name = "numericUpDownStopNumber";
            this.numericUpDownStopNumber.Size = new System.Drawing.Size(275, 20);
            this.numericUpDownStopNumber.TabIndex = 34;
            // 
            // numericUpDownIncrement
            // 
            this.numericUpDownIncrement.Location = new System.Drawing.Point(8, 154);
            this.numericUpDownIncrement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownIncrement.Name = "numericUpDownIncrement";
            this.numericUpDownIncrement.Size = new System.Drawing.Size(275, 20);
            this.numericUpDownIncrement.TabIndex = 33;
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
            this.comboBoxEncoding.Location = new System.Drawing.Point(8, 199);
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            this.comboBoxEncoding.Size = new System.Drawing.Size(275, 21);
            this.comboBoxEncoding.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Encoding:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Increment:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Stop number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Start number:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(8, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(275, 20);
            this.textBoxName.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Name:";
            // 
            // ucNumberGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucNumberGenerator";
            this.Size = new System.Drawing.Size(290, 274);
            this.Load += new System.EventHandler(this.ucNumberGenerator_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIncrement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.NumericUpDown numericUpDownStartNumber;
        public System.Windows.Forms.NumericUpDown numericUpDownStopNumber;
        public System.Windows.Forms.NumericUpDown numericUpDownIncrement;
        public System.Windows.Forms.ComboBox comboBoxEncoding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;


    }
}
