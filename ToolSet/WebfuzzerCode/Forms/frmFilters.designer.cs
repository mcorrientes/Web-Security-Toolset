namespace usertools.WebFuzzer.Forms
{
    partial class frmFilters
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.listViewFilters = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.buttonDeleteFilter = new System.Windows.Forms.Button();
            this.comboBoxConditionType = new System.Windows.Forms.ComboBox();
            this.comboBoxFilterType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRegex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFilterName = new System.Windows.Forms.TextBox();
            this.buttonAddFilter = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxConditionType);
            this.splitContainer1.Panel2.Controls.Add(this.comboBoxFilterType);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxRegex);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxFilterName);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAddFilter);
            this.splitContainer1.Size = new System.Drawing.Size(794, 220);
            this.splitContainer1.SplitterDistance = 547;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.listViewFilters);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.buttonDeleteFilter);
            this.splitContainer3.Size = new System.Drawing.Size(547, 220);
            this.splitContainer3.SplitterDistance = 183;
            this.splitContainer3.TabIndex = 1;
            // 
            // listViewFilters
            // 
            this.listViewFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFilters.FullRowSelect = true;
            this.listViewFilters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewFilters.Location = new System.Drawing.Point(0, 0);
            this.listViewFilters.MultiSelect = false;
            this.listViewFilters.Name = "listViewFilters";
            this.listViewFilters.Size = new System.Drawing.Size(547, 183);
            this.listViewFilters.TabIndex = 0;
            this.listViewFilters.UseCompatibleStateImageBehavior = false;
            this.listViewFilters.View = System.Windows.Forms.View.Details;
            this.listViewFilters.SelectedIndexChanged += new System.EventHandler(this.listViewFilters_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 142;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Filter Type";
            this.columnHeader2.Width = 81;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Condition Type";
            this.columnHeader3.Width = 128;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Condition Regular Expression";
            this.columnHeader4.Width = 188;
            // 
            // buttonDeleteFilter
            // 
            this.buttonDeleteFilter.Enabled = false;
            this.buttonDeleteFilter.Location = new System.Drawing.Point(469, 3);
            this.buttonDeleteFilter.Name = "buttonDeleteFilter";
            this.buttonDeleteFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteFilter.TabIndex = 0;
            this.buttonDeleteFilter.Text = "Delete Filter";
            this.buttonDeleteFilter.UseVisualStyleBackColor = true;
            this.buttonDeleteFilter.Click += new System.EventHandler(this.buttonDeleteFilter_Click);
            // 
            // comboBoxConditionType
            // 
            this.comboBoxConditionType.FormattingEnabled = true;
            this.comboBoxConditionType.Items.AddRange(new object[] {
            "Response Status Code",
            "Response HTML",
            "Response Headers"});
            this.comboBoxConditionType.Location = new System.Drawing.Point(2, 103);
            this.comboBoxConditionType.Name = "comboBoxConditionType";
            this.comboBoxConditionType.Size = new System.Drawing.Size(237, 21);
            this.comboBoxConditionType.TabIndex = 3;
            // 
            // comboBoxFilterType
            // 
            this.comboBoxFilterType.FormattingEnabled = true;
            this.comboBoxFilterType.Items.AddRange(new object[] {
            "Exclude",
            "Include"});
            this.comboBoxFilterType.Location = new System.Drawing.Point(3, 64);
            this.comboBoxFilterType.Name = "comboBoxFilterType";
            this.comboBoxFilterType.Size = new System.Drawing.Size(237, 21);
            this.comboBoxFilterType.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Condition Regular Expression";
            // 
            // textBoxRegex
            // 
            this.textBoxRegex.Location = new System.Drawing.Point(2, 142);
            this.textBoxRegex.Name = "textBoxRegex";
            this.textBoxRegex.Size = new System.Drawing.Size(238, 20);
            this.textBoxRegex.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Condition Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filter Name";
            // 
            // textBoxFilterName
            // 
            this.textBoxFilterName.Location = new System.Drawing.Point(2, 25);
            this.textBoxFilterName.Name = "textBoxFilterName";
            this.textBoxFilterName.Size = new System.Drawing.Size(238, 20);
            this.textBoxFilterName.TabIndex = 1;
            // 
            // buttonAddFilter
            // 
            this.buttonAddFilter.Location = new System.Drawing.Point(3, 190);
            this.buttonAddFilter.Name = "buttonAddFilter";
            this.buttonAddFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFilter.TabIndex = 0;
            this.buttonAddFilter.Text = "Add Filter";
            this.buttonAddFilter.UseVisualStyleBackColor = true;
            this.buttonAddFilter.Click += new System.EventHandler(this.buttonAddFilter_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonCancel);
            this.splitContainer2.Panel2.Controls.Add(this.buttonOk);
            this.splitContainer2.Size = new System.Drawing.Size(794, 256);
            this.splitContainer2.SplitterDistance = 220;
            this.splitContainer2.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(707, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(12, 6);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // frmFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 256);
            this.Controls.Add(this.splitContainer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFilters";
            this.Text = "Filters";
            this.Load += new System.EventHandler(this.frmFilters_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView listViewFilters;
        private System.Windows.Forms.Button buttonDeleteFilter;
        private System.Windows.Forms.Button buttonAddFilter;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxRegex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFilterName;
        private System.Windows.Forms.ComboBox comboBoxConditionType;
        private System.Windows.Forms.ComboBox comboBoxFilterType;
    }
}