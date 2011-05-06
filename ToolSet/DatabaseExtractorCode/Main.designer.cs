namespace ToolSet.DatabaseExtractorCode
{
    partial class Main
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
            this.txt_Success = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_URL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.raBu_Choose = new System.Windows.Forms.RadioButton();
            this.tc_1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_Preview = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lv_Parameterized = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonCustomCookies = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_EncodeWhiteSpaces = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_EncodeCharacter = new System.Windows.Forms.CheckBox();
            this.txt_Parameter = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_Min = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_Max = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Post = new System.Windows.Forms.TextBox();
            this.raBu_Direct = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_CustomQueryOutput = new System.Windows.Forms.TextBox();
            this.txt_CustomQuery = new System.Windows.Forms.TextBox();
            this.btn_ExecuteCustom = new System.Windows.Forms.Button();
            this.lv_Status = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btn_ReadRows = new System.Windows.Forms.Button();
            this.btn_ReadColumns = new System.Windows.Forms.Button();
            this.btn_ReadTables = new System.Windows.Forms.Button();
            this.btn_GetDatabase = new System.Windows.Forms.Button();
            this.lv_Database = new System.Windows.Forms.ListView();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.tv_Database = new System.Windows.Forms.TreeView();
            this.timerUpdateGUI = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tc_1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Max)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Success
            // 
            this.txt_Success.Location = new System.Drawing.Point(188, 17);
            this.txt_Success.Name = "txt_Success";
            this.txt_Success.Size = new System.Drawing.Size(284, 20);
            this.txt_Success.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Please declare a success phrase:";
            // 
            // txt_URL
            // 
            this.txt_URL.Location = new System.Drawing.Point(188, 13);
            this.txt_URL.Name = "txt_URL";
            this.txt_URL.Size = new System.Drawing.Size(284, 20);
            this.txt_URL.TabIndex = 0;
            this.txt_URL.TextChanged += new System.EventHandler(this.txt_URL_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Please specify the URL:";
            // 
            // raBu_Choose
            // 
            this.raBu_Choose.AutoSize = true;
            this.raBu_Choose.Location = new System.Drawing.Point(15, 66);
            this.raBu_Choose.Name = "raBu_Choose";
            this.raBu_Choose.Size = new System.Drawing.Size(152, 17);
            this.raBu_Choose.TabIndex = 2;
            this.raBu_Choose.Text = "Use a parameter from post:";
            this.raBu_Choose.UseVisualStyleBackColor = true;
            this.raBu_Choose.CheckedChanged += new System.EventHandler(this.raBu_Choose_CheckedChanged);
            // 
            // tc_1
            // 
            this.tc_1.Controls.Add(this.tabPage1);
            this.tc_1.Controls.Add(this.tabPage2);
            this.tc_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_1.Location = new System.Drawing.Point(0, 0);
            this.tc_1.Name = "tc_1";
            this.tc_1.SelectedIndex = 0;
            this.tc_1.Size = new System.Drawing.Size(790, 507);
            this.tc_1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel6);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.btn_Start);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txt_Preview);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Location = new System.Drawing.Point(11, 433);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(490, 40);
            this.panel6.TabIndex = 24;
            // 
            // txt_Preview
            // 
            this.txt_Preview.Location = new System.Drawing.Point(83, 10);
            this.txt_Preview.Name = "txt_Preview";
            this.txt_Preview.Size = new System.Drawing.Size(400, 20);
            this.txt_Preview.TabIndex = 23;
            this.txt_Preview.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Preview:";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lv_Parameterized);
            this.panel5.Location = new System.Drawing.Point(511, 11);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(265, 409);
            this.panel5.TabIndex = 21;
            // 
            // lv_Parameterized
            // 
            this.lv_Parameterized.CheckBoxes = true;
            this.lv_Parameterized.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.lv_Parameterized.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Parameterized.Location = new System.Drawing.Point(0, 0);
            this.lv_Parameterized.Name = "lv_Parameterized";
            this.lv_Parameterized.Size = new System.Drawing.Size(263, 407);
            this.lv_Parameterized.TabIndex = 0;
            this.lv_Parameterized.TabStop = false;
            this.lv_Parameterized.UseCompatibleStateImageBehavior = false;
            this.lv_Parameterized.View = System.Windows.Forms.View.Details;
            this.lv_Parameterized.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_Parameterized_ItemChecked);
            this.lv_Parameterized.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lv_Parameterized_ItemCheck);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Parameters";
            this.columnHeader2.Width = 135;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Possible Injection";
            this.columnHeader3.Width = 123;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.buttonCustomCookies);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.cb_EncodeWhiteSpaces);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.cb_EncodeCharacter);
            this.panel4.Controls.Add(this.txt_Parameter);
            this.panel4.Location = new System.Drawing.Point(11, 125);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(490, 114);
            this.panel4.TabIndex = 1;
            // 
            // buttonCustomCookies
            // 
            this.buttonCustomCookies.Location = new System.Drawing.Point(367, 84);
            this.buttonCustomCookies.Name = "buttonCustomCookies";
            this.buttonCustomCookies.Size = new System.Drawing.Size(100, 23);
            this.buttonCustomCookies.TabIndex = 18;
            this.buttonCustomCookies.Text = "Custom Cookies";
            this.buttonCustomCookies.UseVisualStyleBackColor = true;
            this.buttonCustomCookies.Click += new System.EventHandler(this.buttonCustomCookies_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Optional settings:";
            // 
            // cb_EncodeWhiteSpaces
            // 
            this.cb_EncodeWhiteSpaces.AutoSize = true;
            this.cb_EncodeWhiteSpaces.Location = new System.Drawing.Point(12, 84);
            this.cb_EncodeWhiteSpaces.Name = "cb_EncodeWhiteSpaces";
            this.cb_EncodeWhiteSpaces.Size = new System.Drawing.Size(97, 17);
            this.cb_EncodeWhiteSpaces.TabIndex = 6;
            this.cb_EncodeWhiteSpaces.Text = "Encode Space";
            this.cb_EncodeWhiteSpaces.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Parameter default value:";
            // 
            // cb_EncodeCharacter
            // 
            this.cb_EncodeCharacter.AutoSize = true;
            this.cb_EncodeCharacter.Location = new System.Drawing.Point(12, 61);
            this.cb_EncodeCharacter.Name = "cb_EncodeCharacter";
            this.cb_EncodeCharacter.Size = new System.Drawing.Size(120, 17);
            this.cb_EncodeCharacter.TabIndex = 5;
            this.cb_EncodeCharacter.Text = "Encode Characters ";
            this.cb_EncodeCharacter.UseVisualStyleBackColor = true;
            // 
            // txt_Parameter
            // 
            this.txt_Parameter.Location = new System.Drawing.Point(188, 32);
            this.txt_Parameter.Name = "txt_Parameter";
            this.txt_Parameter.Size = new System.Drawing.Size(284, 20);
            this.txt_Parameter.TabIndex = 4;
            this.txt_Parameter.TextChanged += new System.EventHandler(this.txt_Parameter_TextChanged);
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btn_Start.Location = new System.Drawing.Point(558, 439);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(185, 25);
            this.btn_Start.TabIndex = 10;
            this.btn_Start.Text = "Begin Injection";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.nud_Min);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.nud_Max);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(11, 320);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(490, 99);
            this.panel3.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Declare how many columns you want to identify:";
            // 
            // nud_Min
            // 
            this.nud_Min.Location = new System.Drawing.Point(142, 50);
            this.nud_Min.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nud_Min.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Min.Name = "nud_Min";
            this.nud_Min.ReadOnly = true;
            this.nud_Min.Size = new System.Drawing.Size(50, 20);
            this.nud_Min.TabIndex = 8;
            this.nud_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Min.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mininum columns:";
            // 
            // nud_Max
            // 
            this.nud_Max.Location = new System.Drawing.Point(392, 50);
            this.nud_Max.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nud_Max.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Max.Name = "nud_Max";
            this.nud_Max.ReadOnly = true;
            this.nud_Max.Size = new System.Drawing.Size(50, 20);
            this.nud_Max.TabIndex = 9;
            this.nud_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_Max.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Maximum columns:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_Success);
            this.panel2.Location = new System.Drawing.Point(11, 251);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 56);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_URL);
            this.panel1.Controls.Add(this.txt_Post);
            this.panel1.Controls.Add(this.raBu_Direct);
            this.panel1.Controls.Add(this.raBu_Choose);
            this.panel1.Location = new System.Drawing.Point(11, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 102);
            this.panel1.TabIndex = 0;
            // 
            // txt_Post
            // 
            this.txt_Post.Enabled = false;
            this.txt_Post.Location = new System.Drawing.Point(188, 63);
            this.txt_Post.Name = "txt_Post";
            this.txt_Post.Size = new System.Drawing.Size(284, 20);
            this.txt_Post.TabIndex = 3;
            this.txt_Post.TextChanged += new System.EventHandler(this.txt_Post_TextChanged);
            // 
            // raBu_Direct
            // 
            this.raBu_Direct.AutoSize = true;
            this.raBu_Direct.Checked = true;
            this.raBu_Direct.Location = new System.Drawing.Point(15, 40);
            this.raBu_Direct.Name = "raBu_Direct";
            this.raBu_Direct.Size = new System.Drawing.Size(87, 17);
            this.raBu_Direct.TabIndex = 1;
            this.raBu_Direct.TabStop = true;
            this.raBu_Direct.Text = "Inject in URL";
            this.raBu_Direct.UseVisualStyleBackColor = true;
            this.raBu_Direct.CheckedChanged += new System.EventHandler(this.raBu_Direct_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_Save);
            this.tabPage2.Controls.Add(this.txt_CustomQueryOutput);
            this.tabPage2.Controls.Add(this.txt_CustomQuery);
            this.tabPage2.Controls.Add(this.btn_ExecuteCustom);
            this.tabPage2.Controls.Add(this.lv_Status);
            this.tabPage2.Controls.Add(this.btn_ReadRows);
            this.tabPage2.Controls.Add(this.btn_ReadColumns);
            this.tabPage2.Controls.Add(this.btn_ReadTables);
            this.tabPage2.Controls.Add(this.btn_GetDatabase);
            this.tabPage2.Controls.Add(this.lv_Database);
            this.tabPage2.Controls.Add(this.btn_Stop);
            this.tabPage2.Controls.Add(this.tv_Database);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(782, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(668, 312);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(106, 23);
            this.btn_Save.TabIndex = 28;
            this.btn_Save.Text = "Save current list";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_CustomQueryOutput
            // 
            this.txt_CustomQueryOutput.Location = new System.Drawing.Point(435, 315);
            this.txt_CustomQueryOutput.Name = "txt_CustomQueryOutput";
            this.txt_CustomQueryOutput.ReadOnly = true;
            this.txt_CustomQueryOutput.Size = new System.Drawing.Size(168, 20);
            this.txt_CustomQueryOutput.TabIndex = 27;
            this.txt_CustomQueryOutput.Visible = false;
            // 
            // txt_CustomQuery
            // 
            this.txt_CustomQuery.Location = new System.Drawing.Point(10, 315);
            this.txt_CustomQuery.Name = "txt_CustomQuery";
            this.txt_CustomQuery.Size = new System.Drawing.Size(269, 20);
            this.txt_CustomQuery.TabIndex = 25;
            // 
            // btn_ExecuteCustom
            // 
            this.btn_ExecuteCustom.Enabled = false;
            this.btn_ExecuteCustom.Location = new System.Drawing.Point(293, 313);
            this.btn_ExecuteCustom.Name = "btn_ExecuteCustom";
            this.btn_ExecuteCustom.Size = new System.Drawing.Size(125, 23);
            this.btn_ExecuteCustom.TabIndex = 26;
            this.btn_ExecuteCustom.Text = "Execute Custom Query";
            this.btn_ExecuteCustom.UseVisualStyleBackColor = true;
            this.btn_ExecuteCustom.Click += new System.EventHandler(this.btn_ExecuteCustom_Click);
            // 
            // lv_Status
            // 
            this.lv_Status.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv_Status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lv_Status.Location = new System.Drawing.Point(3, 354);
            this.lv_Status.Name = "lv_Status";
            this.lv_Status.Size = new System.Drawing.Size(776, 124);
            this.lv_Status.TabIndex = 9;
            this.lv_Status.TabStop = false;
            this.lv_Status.UseCompatibleStateImageBehavior = false;
            this.lv_Status.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Current actions";
            this.columnHeader1.Width = 751;
            // 
            // btn_ReadRows
            // 
            this.btn_ReadRows.Enabled = false;
            this.btn_ReadRows.Location = new System.Drawing.Point(194, 145);
            this.btn_ReadRows.Name = "btn_ReadRows";
            this.btn_ReadRows.Size = new System.Drawing.Size(85, 23);
            this.btn_ReadRows.TabIndex = 23;
            this.btn_ReadRows.Text = "Read Rows";
            this.btn_ReadRows.UseVisualStyleBackColor = true;
            this.btn_ReadRows.Click += new System.EventHandler(this.btn_ReadRows_Click);
            // 
            // btn_ReadColumns
            // 
            this.btn_ReadColumns.Enabled = false;
            this.btn_ReadColumns.Location = new System.Drawing.Point(194, 110);
            this.btn_ReadColumns.Name = "btn_ReadColumns";
            this.btn_ReadColumns.Size = new System.Drawing.Size(85, 23);
            this.btn_ReadColumns.TabIndex = 22;
            this.btn_ReadColumns.Text = "Read Columns";
            this.btn_ReadColumns.UseVisualStyleBackColor = true;
            this.btn_ReadColumns.Click += new System.EventHandler(this.btn_ReadColumns_Click);
            // 
            // btn_ReadTables
            // 
            this.btn_ReadTables.Enabled = false;
            this.btn_ReadTables.Location = new System.Drawing.Point(194, 75);
            this.btn_ReadTables.Name = "btn_ReadTables";
            this.btn_ReadTables.Size = new System.Drawing.Size(85, 23);
            this.btn_ReadTables.TabIndex = 21;
            this.btn_ReadTables.Text = "Read Tables";
            this.btn_ReadTables.UseVisualStyleBackColor = true;
            this.btn_ReadTables.Click += new System.EventHandler(this.btn_ReadTables_Click);
            // 
            // btn_GetDatabase
            // 
            this.btn_GetDatabase.Enabled = false;
            this.btn_GetDatabase.Location = new System.Drawing.Point(194, 12);
            this.btn_GetDatabase.Name = "btn_GetDatabase";
            this.btn_GetDatabase.Size = new System.Drawing.Size(85, 23);
            this.btn_GetDatabase.TabIndex = 20;
            this.btn_GetDatabase.Text = "Get Database";
            this.btn_GetDatabase.UseVisualStyleBackColor = true;
            this.btn_GetDatabase.Click += new System.EventHandler(this.btn_GetDatabase_Click);
            // 
            // lv_Database
            // 
            this.lv_Database.Location = new System.Drawing.Point(293, 10);
            this.lv_Database.Name = "lv_Database";
            this.lv_Database.Size = new System.Drawing.Size(484, 290);
            this.lv_Database.TabIndex = 4;
            this.lv_Database.TabStop = false;
            this.lv_Database.UseCompatibleStateImageBehavior = false;
            this.lv_Database.View = System.Windows.Forms.View.Details;
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Location = new System.Drawing.Point(190, 277);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(89, 23);
            this.btn_Stop.TabIndex = 24;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // tv_Database
            // 
            this.tv_Database.HideSelection = false;
            this.tv_Database.Location = new System.Drawing.Point(10, 10);
            this.tv_Database.Name = "tv_Database";
            this.tv_Database.Size = new System.Drawing.Size(169, 290);
            this.tv_Database.TabIndex = 1;
            this.tv_Database.TabStop = false;
            this.tv_Database.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Database_AfterSelect);
            // 
            // timerUpdateGUI
            // 
            this.timerUpdateGUI.Enabled = true;
            this.timerUpdateGUI.Interval = 1000;
            this.timerUpdateGUI.Tick += new System.EventHandler(this.timerUpdateGUI_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 507);
            this.Controls.Add(this.tc_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main";
            this.Text = "Database Extractor";
            this.tc_1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Max)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Success;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton raBu_Choose;
        public System.Windows.Forms.TextBox txt_URL;
        private System.Windows.Forms.TabControl tc_1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown nud_Min;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nud_Max;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox txt_Post;
        private System.Windows.Forms.RadioButton raBu_Direct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cb_EncodeWhiteSpaces;
        private System.Windows.Forms.CheckBox cb_EncodeCharacter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Parameter;
        private System.Windows.Forms.Timer timerUpdateGUI;
        private System.Windows.Forms.TreeView tv_Database;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.ListView lv_Database;
        private System.Windows.Forms.Button btn_GetDatabase;
        private System.Windows.Forms.Button btn_ReadTables;
        private System.Windows.Forms.Button btn_ReadColumns;
        private System.Windows.Forms.Button btn_ReadRows;
        private System.Windows.Forms.ListView lv_Status;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView lv_Parameterized;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txt_Preview;
        private System.Windows.Forms.TextBox txt_CustomQuery;
        private System.Windows.Forms.Button btn_ExecuteCustom;
        private System.Windows.Forms.TextBox txt_CustomQueryOutput;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button buttonCustomCookies;
    }
}

