namespace ToolSet.Global
{
   partial class ProxySettings
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
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.chkUseProxy = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.txtProxyHost = new System.Windows.Forms.MaskedTextBox();
         this.txtProxyUser = new System.Windows.Forms.MaskedTextBox();
         this.txtProxyPass = new System.Windows.Forms.MaskedTextBox();
         this.txtProxyPort = new System.Windows.Forms.MaskedTextBox();
         this.btnCancel = new System.Windows.Forms.Button();
         this.btnOk = new System.Windows.Forms.Button();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.ColumnCount = 3;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
         this.tableLayoutPanel1.Controls.Add(this.chkUseProxy, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
         this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
         this.tableLayoutPanel1.Controls.Add(this.txtProxyHost, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.txtProxyUser, 1, 2);
         this.tableLayoutPanel1.Controls.Add(this.txtProxyPass, 1, 3);
         this.tableLayoutPanel1.Controls.Add(this.txtProxyPort, 2, 1);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 5;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(343, 91);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // chkUseProxy
         // 
         this.chkUseProxy.AutoSize = true;
         this.tableLayoutPanel1.SetColumnSpan(this.chkUseProxy, 2);
         this.chkUseProxy.Dock = System.Windows.Forms.DockStyle.Fill;
         this.chkUseProxy.Location = new System.Drawing.Point(3, 3);
         this.chkUseProxy.Name = "chkUseProxy";
         this.chkUseProxy.Size = new System.Drawing.Size(257, 16);
         this.chkUseProxy.TabIndex = 0;
         this.chkUseProxy.Text = "Use Proxy Server";
         this.chkUseProxy.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label1.Location = new System.Drawing.Point(3, 22);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(58, 22);
         this.label1.TabIndex = 1;
         this.label1.Text = "Host/Port:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label2.Location = new System.Drawing.Point(3, 44);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(58, 22);
         this.label2.TabIndex = 2;
         this.label2.Text = "Username:";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label3.Location = new System.Drawing.Point(3, 66);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(58, 22);
         this.label3.TabIndex = 3;
         this.label3.Text = "Password:";
         this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // txtProxyHost
         // 
         this.txtProxyHost.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtProxyHost.Location = new System.Drawing.Point(66, 24);
         this.txtProxyHost.Margin = new System.Windows.Forms.Padding(2);
         this.txtProxyHost.Name = "txtProxyHost";
         this.txtProxyHost.Size = new System.Drawing.Size(195, 20);
         this.txtProxyHost.TabIndex = 4;
         // 
         // txtProxyUser
         // 
         this.txtProxyUser.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtProxyUser.Location = new System.Drawing.Point(66, 46);
         this.txtProxyUser.Margin = new System.Windows.Forms.Padding(2);
         this.txtProxyUser.Name = "txtProxyUser";
         this.txtProxyUser.Size = new System.Drawing.Size(195, 20);
         this.txtProxyUser.TabIndex = 5;
         // 
         // txtProxyPass
         // 
         this.txtProxyPass.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtProxyPass.Location = new System.Drawing.Point(66, 68);
         this.txtProxyPass.Margin = new System.Windows.Forms.Padding(2);
         this.txtProxyPass.Name = "txtProxyPass";
         this.txtProxyPass.Size = new System.Drawing.Size(195, 20);
         this.txtProxyPass.TabIndex = 6;
         // 
         // txtProxyPort
         // 
         this.txtProxyPort.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtProxyPort.Location = new System.Drawing.Point(265, 24);
         this.txtProxyPort.Margin = new System.Windows.Forms.Padding(2);
         this.txtProxyPort.Name = "txtProxyPort";
         this.txtProxyPort.Size = new System.Drawing.Size(76, 20);
         this.txtProxyPort.TabIndex = 7;
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(280, 114);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnOk
         // 
         this.btnOk.Location = new System.Drawing.Point(199, 114);
         this.btnOk.Name = "btnOk";
         this.btnOk.Size = new System.Drawing.Size(75, 23);
         this.btnOk.TabIndex = 2;
         this.btnOk.Text = "OK";
         this.btnOk.UseVisualStyleBackColor = true;
         this.btnOk.Click += new System.EventHandler(this.btnOkClick);
         // 
         // ProxySettings
         // 
         this.AcceptButton = this.btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(367, 149);
         this.Controls.Add(this.btnOk);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.tableLayoutPanel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ProxySettings";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Proxy settings";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.CheckBox chkUseProxy;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.MaskedTextBox txtProxyHost;
      private System.Windows.Forms.MaskedTextBox txtProxyUser;
      private System.Windows.Forms.MaskedTextBox txtProxyPass;
      private System.Windows.Forms.MaskedTextBox txtProxyPort;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Button btnOk;
   }
}