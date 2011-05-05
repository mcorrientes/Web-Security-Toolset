using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace usertools.WebFuzzer.Forms
{
    public partial class frmMatchSettings : Form
    {
        public frmMatchSettings()
        {
            InitializeComponent();
        }

        private void buttonSavePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBoxSavePath.Text = openFileDialog.FileName;
        }
    }
}
