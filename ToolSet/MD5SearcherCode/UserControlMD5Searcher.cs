using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using usertools.MD5Cracker;

namespace ToolSet.MD5SearcherCode
{
    public partial class UserControlMD5Searcher : UserControl
    {
        public UserControlMD5Searcher()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            MD5Cracker Cracker = new MD5Cracker();
            Cracker.Crack(textBoxMD5Crack.Text);
            if (Cracker.CrackedHash)
                MessageBox.Show("Hash Found:\r\n" + Cracker.HashValue, "Found Hash", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Hash Not Found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
