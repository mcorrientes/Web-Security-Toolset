namespace ToolSet.EncoderCode
{
    partial class UserControlEncoder
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
            this.textEncChars = new System.Windows.Forms.TextBox();
            this.textEncURL = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.splitContainer20 = new System.Windows.Forms.SplitContainer();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.textEncMD5 = new System.Windows.Forms.TextBox();
            this.textEncURLUTF8 = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.textEncAmpHash = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.textEncAmpHex = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.textEncAmp = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.textEncEscape = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.textDecEscape = new System.Windows.Forms.TextBox();
            this.textDecAmp = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.textDecFull = new System.Windows.Forms.TextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.textEncOrig = new System.Windows.Forms.TextBox();
            this.splitContainer19 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer20.Panel1.SuspendLayout();
            this.splitContainer20.Panel2.SuspendLayout();
            this.splitContainer20.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.splitContainer19.Panel1.SuspendLayout();
            this.splitContainer19.Panel2.SuspendLayout();
            this.splitContainer19.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEncChars
            // 
            this.textEncChars.BackColor = System.Drawing.Color.White;
            this.textEncChars.Location = new System.Drawing.Point(149, 42);
            this.textEncChars.Name = "textEncChars";
            this.textEncChars.Size = new System.Drawing.Size(499, 20);
            this.textEncChars.TabIndex = 8;
            this.textEncChars.TextChanged += new System.EventHandler(this.textEncChars_TextChanged);
            // 
            // textEncURL
            // 
            this.textEncURL.BackColor = System.Drawing.Color.White;
            this.textEncURL.Location = new System.Drawing.Point(149, 68);
            this.textEncURL.Name = "textEncURL";
            this.textEncURL.Size = new System.Drawing.Size(499, 20);
            this.textEncURL.TabIndex = 9;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(9, 19);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(30, 13);
            this.label68.TabIndex = 2;
            this.label68.Text = "MD5";
            // 
            // splitContainer20
            // 
            this.splitContainer20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer20.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer20.IsSplitterFixed = true;
            this.splitContainer20.Location = new System.Drawing.Point(0, 0);
            this.splitContainer20.Name = "splitContainer20";
            this.splitContainer20.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer20.Panel1
            // 
            this.splitContainer20.Panel1.Controls.Add(this.groupBox15);
            // 
            // splitContainer20.Panel2
            // 
            this.splitContainer20.Panel2.Controls.Add(this.groupBox16);
            this.splitContainer20.Size = new System.Drawing.Size(800, 328);
            this.splitContainer20.SplitterDistance = 228;
            this.splitContainer20.TabIndex = 0;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.textEncMD5);
            this.groupBox15.Controls.Add(this.textEncChars);
            this.groupBox15.Controls.Add(this.textEncURL);
            this.groupBox15.Controls.Add(this.label68);
            this.groupBox15.Controls.Add(this.textEncURLUTF8);
            this.groupBox15.Controls.Add(this.label79);
            this.groupBox15.Controls.Add(this.textEncAmpHash);
            this.groupBox15.Controls.Add(this.label70);
            this.groupBox15.Controls.Add(this.textEncAmpHex);
            this.groupBox15.Controls.Add(this.label72);
            this.groupBox15.Controls.Add(this.textEncAmp);
            this.groupBox15.Controls.Add(this.label78);
            this.groupBox15.Controls.Add(this.textEncEscape);
            this.groupBox15.Controls.Add(this.label69);
            this.groupBox15.Controls.Add(this.label76);
            this.groupBox15.Controls.Add(this.label75);
            this.groupBox15.Location = new System.Drawing.Point(0, 0);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox15.Size = new System.Drawing.Size(668, 228);
            this.groupBox15.TabIndex = 2;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Encoding";
            // 
            // textEncMD5
            // 
            this.textEncMD5.BackColor = System.Drawing.Color.White;
            this.textEncMD5.Location = new System.Drawing.Point(149, 16);
            this.textEncMD5.Name = "textEncMD5";
            this.textEncMD5.Size = new System.Drawing.Size(499, 20);
            this.textEncMD5.TabIndex = 0;
            // 
            // textEncURLUTF8
            // 
            this.textEncURLUTF8.BackColor = System.Drawing.Color.White;
            this.textEncURLUTF8.Location = new System.Drawing.Point(149, 94);
            this.textEncURLUTF8.Name = "textEncURLUTF8";
            this.textEncURLUTF8.Size = new System.Drawing.Size(499, 20);
            this.textEncURLUTF8.TabIndex = 3;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(9, 175);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(101, 13);
            this.label79.TabIndex = 2;
            this.label79.Text = "Percentage Escape";
            // 
            // textEncAmpHash
            // 
            this.textEncAmpHash.BackColor = System.Drawing.Color.White;
            this.textEncAmpHash.Location = new System.Drawing.Point(149, 120);
            this.textEncAmpHash.Name = "textEncAmpHash";
            this.textEncAmpHash.Size = new System.Drawing.Size(499, 20);
            this.textEncAmpHash.TabIndex = 4;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(9, 201);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(67, 13);
            this.label70.TabIndex = 3;
            this.label70.Text = "Amp Escape";
            // 
            // textEncAmpHex
            // 
            this.textEncAmpHex.BackColor = System.Drawing.Color.White;
            this.textEncAmpHex.Location = new System.Drawing.Point(149, 146);
            this.textEncAmpHex.Name = "textEncAmpHex";
            this.textEncAmpHex.Size = new System.Drawing.Size(499, 20);
            this.textEncAmpHex.TabIndex = 5;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(9, 45);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(74, 13);
            this.label72.TabIndex = 5;
            this.label72.Text = "Encode Chars";
            // 
            // textEncAmp
            // 
            this.textEncAmp.BackColor = System.Drawing.Color.White;
            this.textEncAmp.Location = new System.Drawing.Point(149, 198);
            this.textEncAmp.Name = "textEncAmp";
            this.textEncAmp.Size = new System.Drawing.Size(499, 20);
            this.textEncAmp.TabIndex = 7;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(9, 149);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(116, 13);
            this.label78.TabIndex = 2;
            this.label78.Text = "Encode Amp-hash-heX";
            // 
            // textEncEscape
            // 
            this.textEncEscape.BackColor = System.Drawing.Color.White;
            this.textEncEscape.Location = new System.Drawing.Point(149, 172);
            this.textEncEscape.Name = "textEncEscape";
            this.textEncEscape.Size = new System.Drawing.Size(499, 20);
            this.textEncEscape.TabIndex = 6;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(9, 71);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(102, 13);
            this.label69.TabIndex = 2;
            this.label69.Text = "Encode Percentage";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(9, 123);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(94, 13);
            this.label76.TabIndex = 2;
            this.label76.Text = "Encode Amp-hash";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(9, 97);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(135, 13);
            this.label75.TabIndex = 3;
            this.label75.Text = "Encode UTF-8 Percentage";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.textDecEscape);
            this.groupBox16.Controls.Add(this.textDecAmp);
            this.groupBox16.Controls.Add(this.label80);
            this.groupBox16.Controls.Add(this.textDecFull);
            this.groupBox16.Controls.Add(this.label87);
            this.groupBox16.Controls.Add(this.label81);
            this.groupBox16.Location = new System.Drawing.Point(0, 0);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox16.Size = new System.Drawing.Size(668, 100);
            this.groupBox16.TabIndex = 0;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Decoding";
            // 
            // textDecEscape
            // 
            this.textDecEscape.BackColor = System.Drawing.Color.White;
            this.textDecEscape.Location = new System.Drawing.Point(149, 12);
            this.textDecEscape.Name = "textDecEscape";
            this.textDecEscape.Size = new System.Drawing.Size(499, 20);
            this.textDecEscape.TabIndex = 0;
            // 
            // textDecAmp
            // 
            this.textDecAmp.BackColor = System.Drawing.Color.White;
            this.textDecAmp.Location = new System.Drawing.Point(149, 38);
            this.textDecAmp.Name = "textDecAmp";
            this.textDecAmp.Size = new System.Drawing.Size(499, 20);
            this.textDecAmp.TabIndex = 1;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(9, 19);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(88, 13);
            this.label80.TabIndex = 3;
            this.label80.Text = "Escape decoded";
            // 
            // textDecFull
            // 
            this.textDecFull.BackColor = System.Drawing.Color.White;
            this.textDecFull.Location = new System.Drawing.Point(149, 64);
            this.textDecFull.Name = "textDecFull";
            this.textDecFull.Size = new System.Drawing.Size(499, 20);
            this.textDecFull.TabIndex = 2;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(9, 71);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(133, 13);
            this.label87.TabIndex = 3;
            this.label87.Text = "Escape and Amp decoded";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(9, 45);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(73, 13);
            this.label81.TabIndex = 3;
            this.label81.Text = "Amp decoded";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.textEncOrig);
            this.groupBox14.Location = new System.Drawing.Point(0, 0);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox14.Size = new System.Drawing.Size(668, 51);
            this.groupBox14.TabIndex = 0;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "String";
            // 
            // textEncOrig
            // 
            this.textEncOrig.BackColor = System.Drawing.Color.White;
            this.textEncOrig.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEncOrig.Location = new System.Drawing.Point(6, 19);
            this.textEncOrig.Name = "textEncOrig";
            this.textEncOrig.Size = new System.Drawing.Size(656, 20);
            this.textEncOrig.TabIndex = 0;
            this.textEncOrig.TextChanged += new System.EventHandler(this.textEncOrig_TextChanged);
            // 
            // splitContainer19
            // 
            this.splitContainer19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer19.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer19.IsSplitterFixed = true;
            this.splitContainer19.Location = new System.Drawing.Point(0, 0);
            this.splitContainer19.Name = "splitContainer19";
            this.splitContainer19.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer19.Panel1
            // 
            this.splitContainer19.Panel1.Controls.Add(this.groupBox14);
            // 
            // splitContainer19.Panel2
            // 
            this.splitContainer19.Panel2.Controls.Add(this.splitContainer20);
            this.splitContainer19.Size = new System.Drawing.Size(800, 386);
            this.splitContainer19.SplitterDistance = 54;
            this.splitContainer19.TabIndex = 8;
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer19);
            this.splitContainer1.Size = new System.Drawing.Size(800, 600);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 4;
            // 
            // UserControlEncoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControlEncoder";
            this.Size = new System.Drawing.Size(800, 600);
            this.splitContainer20.Panel1.ResumeLayout(false);
            this.splitContainer20.Panel2.ResumeLayout(false);
            this.splitContainer20.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.splitContainer19.Panel1.ResumeLayout(false);
            this.splitContainer19.Panel2.ResumeLayout(false);
            this.splitContainer19.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textEncChars;
        private System.Windows.Forms.TextBox textEncURL;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.SplitContainer splitContainer20;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.TextBox textEncMD5;
        private System.Windows.Forms.TextBox textEncURLUTF8;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox textEncAmpHash;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox textEncAmpHex;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox textEncAmp;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.TextBox textEncEscape;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.TextBox textDecEscape;
        private System.Windows.Forms.TextBox textDecAmp;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.TextBox textDecFull;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.TextBox textEncOrig;
        private System.Windows.Forms.SplitContainer splitContainer19;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
