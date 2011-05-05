namespace PortScanner
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_IP1 = new System.Windows.Forms.TextBox();
            this.txt_Start = new System.Windows.Forms.TextBox();
            this.txt_End = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lv_Port = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btn_Scan = new System.Windows.Forms.Button();
            this.prg_Scannning = new System.Windows.Forms.ProgressBar();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txt_IP2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_IP3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_IP4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_IPrange = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.raBuChoose = new System.Windows.Forms.RadioButton();
            this.timer_Listview = new System.Windows.Forms.Timer(this.components);
            this.buttonCreateReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "IP to scan:";
            // 
            // txt_IP1
            // 
            this.txt_IP1.Location = new System.Drawing.Point(76, 22);
            this.txt_IP1.MaxLength = 3;
            this.txt_IP1.Name = "txt_IP1";
            this.txt_IP1.Size = new System.Drawing.Size(28, 20);
            this.txt_IP1.TabIndex = 1;
            // 
            // txt_Start
            // 
            this.txt_Start.Location = new System.Drawing.Point(134, 57);
            this.txt_Start.MaxLength = 5;
            this.txt_Start.Name = "txt_Start";
            this.txt_Start.Size = new System.Drawing.Size(55, 20);
            this.txt_Start.TabIndex = 8;
            // 
            // txt_End
            // 
            this.txt_End.Location = new System.Drawing.Point(234, 57);
            this.txt_End.MaxLength = 5;
            this.txt_End.Name = "txt_End";
            this.txt_End.Size = new System.Drawing.Size(55, 20);
            this.txt_End.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "to";
            // 
            // lv_Port
            // 
            this.lv_Port.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader3});
            this.lv_Port.Location = new System.Drawing.Point(4, 177);
            this.lv_Port.Name = "lv_Port";
            this.lv_Port.Size = new System.Drawing.Size(404, 212);
            this.lv_Port.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv_Port.TabIndex = 11;
            this.lv_Port.TabStop = false;
            this.lv_Port.UseCompatibleStateImageBehavior = false;
            this.lv_Port.View = System.Windows.Forms.View.Details;
            this.lv_Port.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_Port_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Port";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Service";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Protocol";
            this.columnHeader5.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 70;
            // 
            // btn_Scan
            // 
            this.btn_Scan.Location = new System.Drawing.Point(242, 147);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.Size = new System.Drawing.Size(73, 23);
            this.btn_Scan.TabIndex = 10;
            this.btn_Scan.Text = "Start Scan";
            this.btn_Scan.UseVisualStyleBackColor = true;
            this.btn_Scan.Click += new System.EventHandler(this.btn_Scan_Click);
            // 
            // prg_Scannning
            // 
            this.prg_Scannning.Location = new System.Drawing.Point(4, 395);
            this.prg_Scannning.Name = "prg_Scannning";
            this.prg_Scannning.Size = new System.Drawing.Size(285, 23);
            this.prg_Scannning.TabIndex = 9;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Enabled = false;
            this.btn_Cancel.Location = new System.Drawing.Point(335, 147);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(73, 24);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.Text = "Stop";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txt_IP2
            // 
            this.txt_IP2.Location = new System.Drawing.Point(118, 22);
            this.txt_IP2.MaxLength = 3;
            this.txt_IP2.Name = "txt_IP2";
            this.txt_IP2.Size = new System.Drawing.Size(28, 20);
            this.txt_IP2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = ".";
            // 
            // txt_IP3
            // 
            this.txt_IP3.Location = new System.Drawing.Point(161, 22);
            this.txt_IP3.MaxLength = 3;
            this.txt_IP3.Name = "txt_IP3";
            this.txt_IP3.Size = new System.Drawing.Size(28, 20);
            this.txt_IP3.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = ".";
            // 
            // txt_IP4
            // 
            this.txt_IP4.Location = new System.Drawing.Point(205, 22);
            this.txt_IP4.MaxLength = 3;
            this.txt_IP4.Name = "txt_IP4";
            this.txt_IP4.Size = new System.Drawing.Size(28, 20);
            this.txt_IP4.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "to";
            // 
            // txt_IPrange
            // 
            this.txt_IPrange.Location = new System.Drawing.Point(261, 22);
            this.txt_IPrange.MaxLength = 3;
            this.txt_IPrange.Name = "txt_IPrange";
            this.txt_IPrange.Size = new System.Drawing.Size(28, 20);
            this.txt_IPrange.TabIndex = 5;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 60);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(99, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Scan ports from";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 90);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(131, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "Search for webservers";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // raBuChoose
            // 
            this.raBuChoose.AutoSize = true;
            this.raBuChoose.Location = new System.Drawing.Point(15, 120);
            this.raBuChoose.Name = "raBuChoose";
            this.raBuChoose.Size = new System.Drawing.Size(136, 17);
            this.raBuChoose.TabIndex = 21;
            this.raBuChoose.TabStop = true;
            this.raBuChoose.Text = "Choose from service list";
            this.raBuChoose.UseVisualStyleBackColor = true;
            this.raBuChoose.CheckedChanged += new System.EventHandler(this.raBuChoose_CheckedChanged);
            // 
            // timer_Listview
            // 
            this.timer_Listview.Enabled = true;
            this.timer_Listview.Interval = 500;
            this.timer_Listview.Tick += new System.EventHandler(this.timer_Listview_Tick);
            // 
            // buttonCreateReport
            // 
            this.buttonCreateReport.Location = new System.Drawing.Point(316, 395);
            this.buttonCreateReport.Name = "buttonCreateReport";
            this.buttonCreateReport.Size = new System.Drawing.Size(92, 23);
            this.buttonCreateReport.TabIndex = 22;
            this.buttonCreateReport.Text = "Create Report";
            this.buttonCreateReport.UseVisualStyleBackColor = true;
            this.buttonCreateReport.Click += new System.EventHandler(this.buttonCreateReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 425);
            this.Controls.Add(this.buttonCreateReport);
            this.Controls.Add(this.raBuChoose);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.txt_IPrange);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_IP4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_IP3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_IP2);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.prg_Scannning);
            this.Controls.Add(this.btn_Scan);
            this.Controls.Add(this.lv_Port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_End);
            this.Controls.Add(this.txt_Start);
            this.Controls.Add(this.txt_IP1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "PortScanner";
            this.Move += new System.EventHandler(this.Form1_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_IP1;
        private System.Windows.Forms.TextBox txt_Start;
        private System.Windows.Forms.TextBox txt_End;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lv_Port;
        private System.Windows.Forms.Button btn_Scan;
        private System.Windows.Forms.ProgressBar prg_Scannning;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txt_IP2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_IP3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_IP4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_IPrange;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.RadioButton raBuChoose;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Timer timer_Listview;
        private System.Windows.Forms.Button buttonCreateReport;
    }
}

