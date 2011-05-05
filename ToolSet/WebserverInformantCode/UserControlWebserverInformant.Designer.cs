namespace ToolSet.WebserverInformantCode
{
    partial class UserControlWebserverInformant
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
            this.btn_Start = new System.Windows.Forms.Button();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Domain = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Image = global::ToolSet.Properties.Resources.control;
            this.btn_Start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Start.Location = new System.Drawing.Point(278, 30);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(142, 23);
            this.btn_Start.TabIndex = 7;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // txt_Output
            // 
            this.txt_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Output.Location = new System.Drawing.Point(0, 0);
            this.txt_Output.Multiline = true;
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.ReadOnly = true;
            this.txt_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Output.Size = new System.Drawing.Size(800, 530);
            this.txt_Output.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Enter host or domain name:";
            // 
            // txt_Domain
            // 
            this.txt_Domain.Location = new System.Drawing.Point(16, 30);
            this.txt_Domain.Name = "txt_Domain";
            this.txt_Domain.Size = new System.Drawing.Size(256, 20);
            this.txt_Domain.TabIndex = 6;
            this.txt_Domain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Domain_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 600);
            this.panel1.TabIndex = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Domain);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Start);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_Output);
            this.splitContainer1.Size = new System.Drawing.Size(800, 600);
            this.splitContainer1.SplitterDistance = 66;
            this.splitContainer1.TabIndex = 10;
            // 
            // UserControlWebserverInformant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserControlWebserverInformant";
            this.Size = new System.Drawing.Size(800, 600);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox txt_Output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Domain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
