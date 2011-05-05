namespace ToolSet.PortScannerCode
{
    partial class UserControlPortScanner
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
            this.components = new System.ComponentModel.Container();
            this.timer_Listview = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.labelmsunvisible = new System.Windows.Forms.Label();
            this.numericUpDownTimebetweenRequests = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRequestTimeout = new System.Windows.Forms.NumericUpDown();
            this.comboBoxScanAttitude = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lv_Port = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.prg_Scannning = new System.Windows.Forms.ProgressBar();
            this.buttonCreateReport = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonHostAddress = new System.Windows.Forms.RadioButton();
            this.radioButton_IPrange = new System.Windows.Forms.RadioButton();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBoxIP = new System.Windows.Forms.MaskedTextBox();
            this.txt_IPrange = new System.Windows.Forms.TextBox();
            this.btn_Scan = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxScanMode = new System.Windows.Forms.ComboBox();
            this.radioButtonPortRange = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_End = new System.Windows.Forms.TextBox();
            this.txt_Start = new System.Windows.Forms.TextBox();
            this.raBuChoose = new System.Windows.Forms.RadioButton();
            this.radioButtonWebserverSelected = new System.Windows.Forms.RadioButton();
            this.panelServicelist = new System.Windows.Forms.Panel();
            this.lv_Services = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimebetweenRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRequestTimeout)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelServicelist.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_Listview
            // 
            this.timer_Listview.Enabled = true;
            this.timer_Listview.Interval = 500;
            this.timer_Listview.Tick += new System.EventHandler(this.timer_Listview_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panelServicelist);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 600);
            this.panel1.TabIndex = 44;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.labelmsunvisible);
            this.groupBox5.Controls.Add(this.numericUpDownTimebetweenRequests);
            this.groupBox5.Controls.Add(this.numericUpDownRequestTimeout);
            this.groupBox5.Controls.Add(this.comboBoxScanAttitude);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(3, 200);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(470, 79);
            this.groupBox5.TabIndex = 70;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Optional";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(339, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "ms";
            // 
            // labelmsunvisible
            // 
            this.labelmsunvisible.AutoSize = true;
            this.labelmsunvisible.Location = new System.Drawing.Point(439, 21);
            this.labelmsunvisible.Name = "labelmsunvisible";
            this.labelmsunvisible.Size = new System.Drawing.Size(20, 13);
            this.labelmsunvisible.TabIndex = 4;
            this.labelmsunvisible.Text = "ms";
            this.labelmsunvisible.Visible = false;
            // 
            // numericUpDownTimebetweenRequests
            // 
            this.numericUpDownTimebetweenRequests.Location = new System.Drawing.Point(342, 19);
            this.numericUpDownTimebetweenRequests.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numericUpDownTimebetweenRequests.Name = "numericUpDownTimebetweenRequests";
            this.numericUpDownTimebetweenRequests.Size = new System.Drawing.Size(91, 20);
            this.numericUpDownTimebetweenRequests.TabIndex = 3;
            this.numericUpDownTimebetweenRequests.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownTimebetweenRequests.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTimebetweenRequests.Visible = false;
            // 
            // numericUpDownRequestTimeout
            // 
            this.numericUpDownRequestTimeout.Location = new System.Drawing.Point(161, 46);
            this.numericUpDownRequestTimeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownRequestTimeout.Name = "numericUpDownRequestTimeout";
            this.numericUpDownRequestTimeout.Size = new System.Drawing.Size(171, 20);
            this.numericUpDownRequestTimeout.TabIndex = 2;
            this.numericUpDownRequestTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownRequestTimeout.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // comboBoxScanAttitude
            // 
            this.comboBoxScanAttitude.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScanAttitude.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxScanAttitude.FormattingEnabled = true;
            this.comboBoxScanAttitude.Items.AddRange(new object[] {
            "Aggressive(multiple Threads)",
            "Silent         (one request each)"});
            this.comboBoxScanAttitude.Location = new System.Drawing.Point(161, 19);
            this.comboBoxScanAttitude.Name = "comboBoxScanAttitude";
            this.comboBoxScanAttitude.Size = new System.Drawing.Size(171, 21);
            this.comboBoxScanAttitude.TabIndex = 1;
            this.comboBoxScanAttitude.SelectedIndexChanged += new System.EventHandler(this.comboBoxScanAttitude_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Request Timeout:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scan Attitude:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Location = new System.Drawing.Point(3, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 301);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(464, 282);
            this.panel3.TabIndex = 67;
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
            this.splitContainer1.Panel1.Controls.Add(this.lv_Port);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.prg_Scannning);
            this.splitContainer1.Panel2.Controls.Add(this.buttonCreateReport);
            this.splitContainer1.Size = new System.Drawing.Size(464, 282);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 65;
            // 
            // lv_Port
            // 
            this.lv_Port.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader3});
            this.lv_Port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Port.Location = new System.Drawing.Point(0, 0);
            this.lv_Port.Name = "lv_Port";
            this.lv_Port.Size = new System.Drawing.Size(464, 239);
            this.lv_Port.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv_Port.TabIndex = 55;
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
            // prg_Scannning
            // 
            this.prg_Scannning.Location = new System.Drawing.Point(5, 8);
            this.prg_Scannning.Name = "prg_Scannning";
            this.prg_Scannning.Size = new System.Drawing.Size(324, 23);
            this.prg_Scannning.TabIndex = 52;
            // 
            // buttonCreateReport
            // 
            this.buttonCreateReport.Image = global::ToolSet.Properties.Resources.document_pdf;
            this.buttonCreateReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCreateReport.Location = new System.Drawing.Point(339, 8);
            this.buttonCreateReport.Name = "buttonCreateReport";
            this.buttonCreateReport.Size = new System.Drawing.Size(122, 23);
            this.buttonCreateReport.TabIndex = 64;
            this.buttonCreateReport.Text = "Create Report";
            this.buttonCreateReport.UseVisualStyleBackColor = true;
            this.buttonCreateReport.Click += new System.EventHandler(this.buttonCreateReport_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonHostAddress);
            this.groupBox4.Controls.Add(this.radioButton_IPrange);
            this.groupBox4.Controls.Add(this.textBoxAddress);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.maskedTextBoxIP);
            this.groupBox4.Controls.Add(this.txt_IPrange);
            this.groupBox4.Controls.Add(this.btn_Scan);
            this.groupBox4.Location = new System.Drawing.Point(3, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(470, 79);
            this.groupBox4.TabIndex = 66;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Destination";
            // 
            // radioButtonHostAddress
            // 
            this.radioButtonHostAddress.AutoSize = true;
            this.radioButtonHostAddress.Location = new System.Drawing.Point(29, 47);
            this.radioButtonHostAddress.Name = "radioButtonHostAddress";
            this.radioButtonHostAddress.Size = new System.Drawing.Size(88, 17);
            this.radioButtonHostAddress.TabIndex = 67;
            this.radioButtonHostAddress.Text = "Host Address";
            this.radioButtonHostAddress.UseVisualStyleBackColor = true;
            this.radioButtonHostAddress.CheckedChanged += new System.EventHandler(this.radioButtonHostAddress_CheckedChanged);
            // 
            // radioButton_IPrange
            // 
            this.radioButton_IPrange.AutoSize = true;
            this.radioButton_IPrange.Checked = true;
            this.radioButton_IPrange.Location = new System.Drawing.Point(29, 21);
            this.radioButton_IPrange.Name = "radioButton_IPrange";
            this.radioButton_IPrange.Size = new System.Drawing.Size(104, 17);
            this.radioButton_IPrange.TabIndex = 66;
            this.radioButton_IPrange.TabStop = true;
            this.radioButton_IPrange.Text = "Define IP-Range";
            this.radioButton_IPrange.UseVisualStyleBackColor = true;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Enabled = false;
            this.textBoxAddress.Location = new System.Drawing.Point(158, 46);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(171, 20);
            this.textBoxAddress.TabIndex = 65;
            this.textBoxAddress.Text = "http://scanmyports.com";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "-";
            // 
            // maskedTextBoxIP
            // 
            this.maskedTextBoxIP.Location = new System.Drawing.Point(158, 20);
            this.maskedTextBoxIP.Mask = "000/000/000/000";
            this.maskedTextBoxIP.Name = "maskedTextBoxIP";
            this.maskedTextBoxIP.Size = new System.Drawing.Size(89, 20);
            this.maskedTextBoxIP.TabIndex = 64;
            this.maskedTextBoxIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_IPrange
            // 
            this.txt_IPrange.Location = new System.Drawing.Point(290, 20);
            this.txt_IPrange.MaxLength = 3;
            this.txt_IPrange.Name = "txt_IPrange";
            this.txt_IPrange.Size = new System.Drawing.Size(39, 20);
            this.txt_IPrange.TabIndex = 48;
            this.txt_IPrange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_Scan
            // 
            this.btn_Scan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Scan.Image = global::ToolSet.Properties.Resources.control;
            this.btn_Scan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Scan.Location = new System.Drawing.Point(339, 44);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.Size = new System.Drawing.Size(114, 23);
            this.btn_Scan.TabIndex = 54;
            this.btn_Scan.Text = "Start Scan";
            this.btn_Scan.UseVisualStyleBackColor = true;
            this.btn_Scan.Click += new System.EventHandler(this.btn_Scan_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxScanMode);
            this.groupBox3.Controls.Add(this.radioButtonPortRange);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txt_End);
            this.groupBox3.Controls.Add(this.txt_Start);
            this.groupBox3.Controls.Add(this.raBuChoose);
            this.groupBox3.Controls.Add(this.radioButtonWebserverSelected);
            this.groupBox3.Location = new System.Drawing.Point(3, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(470, 97);
            this.groupBox3.TabIndex = 65;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Port Targets";
            // 
            // comboBoxScanMode
            // 
            this.comboBoxScanMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScanMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxScanMode.FormattingEnabled = true;
            this.comboBoxScanMode.Items.AddRange(new object[] {
            "Custom",
            "Well-known ports",
            "Registered ports",
            "Dynamic/private ports",
            "All ports"});
            this.comboBoxScanMode.Location = new System.Drawing.Point(158, 21);
            this.comboBoxScanMode.Name = "comboBoxScanMode";
            this.comboBoxScanMode.Size = new System.Drawing.Size(126, 21);
            this.comboBoxScanMode.TabIndex = 64;
            this.comboBoxScanMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxScanMode_SelectedIndexChanged);
            // 
            // radioButtonPortRange
            // 
            this.radioButtonPortRange.AutoSize = true;
            this.radioButtonPortRange.Checked = true;
            this.radioButtonPortRange.Location = new System.Drawing.Point(29, 22);
            this.radioButtonPortRange.Name = "radioButtonPortRange";
            this.radioButtonPortRange.Size = new System.Drawing.Size(119, 17);
            this.radioButtonPortRange.TabIndex = 49;
            this.radioButtonPortRange.TabStop = true;
            this.radioButtonPortRange.Text = "Port scanning mode";
            this.radioButtonPortRange.UseVisualStyleBackColor = true;
            this.radioButtonPortRange.CheckedChanged += new System.EventHandler(this.radioButtonPortRange_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "-";
            // 
            // txt_End
            // 
            this.txt_End.Location = new System.Drawing.Point(392, 21);
            this.txt_End.MaxLength = 5;
            this.txt_End.Name = "txt_End";
            this.txt_End.Size = new System.Drawing.Size(60, 20);
            this.txt_End.TabIndex = 53;
            this.txt_End.Text = "80";
            this.txt_End.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_Start
            // 
            this.txt_Start.Location = new System.Drawing.Point(304, 21);
            this.txt_Start.MaxLength = 5;
            this.txt_Start.Name = "txt_Start";
            this.txt_Start.Size = new System.Drawing.Size(60, 20);
            this.txt_Start.TabIndex = 51;
            this.txt_Start.Text = "0";
            this.txt_Start.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // raBuChoose
            // 
            this.raBuChoose.AutoSize = true;
            this.raBuChoose.Location = new System.Drawing.Point(29, 68);
            this.raBuChoose.Name = "raBuChoose";
            this.raBuChoose.Size = new System.Drawing.Size(142, 17);
            this.raBuChoose.TabIndex = 63;
            this.raBuChoose.TabStop = true;
            this.raBuChoose.Text = "Choose from Service List";
            this.raBuChoose.UseVisualStyleBackColor = true;
            this.raBuChoose.CheckedChanged += new System.EventHandler(this.raBuChoose_CheckedChanged);
            // 
            // radioButtonWebserverSelected
            // 
            this.radioButtonWebserverSelected.AutoSize = true;
            this.radioButtonWebserverSelected.Location = new System.Drawing.Point(29, 45);
            this.radioButtonWebserverSelected.Name = "radioButtonWebserverSelected";
            this.radioButtonWebserverSelected.Size = new System.Drawing.Size(139, 17);
            this.radioButtonWebserverSelected.TabIndex = 50;
            this.radioButtonWebserverSelected.Text = "Search for Web Servers";
            this.radioButtonWebserverSelected.UseVisualStyleBackColor = true;
            // 
            // panelServicelist
            // 
            this.panelServicelist.Controls.Add(this.lv_Services);
            this.panelServicelist.Location = new System.Drawing.Point(479, 3);
            this.panelServicelist.Name = "panelServicelist";
            this.panelServicelist.Size = new System.Drawing.Size(307, 583);
            this.panelServicelist.TabIndex = 68;
            this.panelServicelist.Visible = false;
            // 
            // lv_Services
            // 
            this.lv_Services.CheckBoxes = true;
            this.lv_Services.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lv_Services.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Services.Location = new System.Drawing.Point(0, 0);
            this.lv_Services.Name = "lv_Services";
            this.lv_Services.Size = new System.Drawing.Size(307, 583);
            this.lv_Services.TabIndex = 1;
            this.lv_Services.UseCompatibleStateImageBehavior = false;
            this.lv_Services.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Service";
            this.columnHeader6.Width = 128;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Port ";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Protocol";
            this.columnHeader8.Width = 72;
            // 
            // UserControlPortScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserControlPortScanner";
            this.Size = new System.Drawing.Size(800, 600);
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimebetweenRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRequestTimeout)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelServicelist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_Listview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCreateReport;
        private System.Windows.Forms.RadioButton raBuChoose;
        private System.Windows.Forms.RadioButton radioButtonWebserverSelected;
        private System.Windows.Forms.RadioButton radioButtonPortRange;
        private System.Windows.Forms.TextBox txt_IPrange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar prg_Scannning;
        private System.Windows.Forms.ListView lv_Port;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_End;
        private System.Windows.Forms.TextBox txt_Start;
        private System.Windows.Forms.Button btn_Scan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelServicelist;
        private System.Windows.Forms.ListView lv_Services;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxIP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton_IPrange;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.RadioButton radioButtonHostAddress;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBoxScanAttitude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownRequestTimeout;
        private System.Windows.Forms.ComboBox comboBoxScanMode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelmsunvisible;
        private System.Windows.Forms.NumericUpDown numericUpDownTimebetweenRequests;
    }
}
