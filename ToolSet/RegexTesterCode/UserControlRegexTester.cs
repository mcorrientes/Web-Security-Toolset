using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ToolSet.RegexTesterCode
{
    public partial class UserControlRegexTester : UserControl
    {
        public UserControlRegexTester()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (richTextBoxText.Text.Length == 0)
            {
                MessageBox.Show("Please enter some text", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxSearch.Text.Length == 0)
            {
                MessageBox.Show("Please enter a regular expression", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            listViewGroups.Items.Clear();
            richTextBoxText.SelectAll();
            richTextBoxText.SelectionColor = Color.Black;
            richTextBoxText.SelectionFont = this.Font;

            try
            {
                Regex regex = new Regex(textBoxSearch.Text, RegexOptions.Singleline);
                MatchCollection matches = regex.Matches(richTextBoxText.Text);
                if (matches.Count > 0)
                {
                    buttonReplace.Enabled = true;
                    for (int iMatch = 0; iMatch < matches.Count; iMatch++)
                    {
                        Match match = matches[iMatch];
                        for (int i = 0; i < match.Groups.Count; i++)
                        {
                            ListViewItem Item = new ListViewItem();
                            Item.Text = "Match " + (iMatch + 1).ToString() + ", Group " + (i + 1);
                            Item.SubItems.Add(match.Groups[i].Value);
                            listViewGroups.Items.Add(Item);

                            richTextBoxText.Select(match.Groups[i].Index, match.Groups[i].Length);
                            richTextBoxText.SelectionColor = Color.Red;
                            richTextBoxText.SelectionFont = new Font(this.Font, FontStyle.Bold);
                        }
                    }
                }
                else
                    buttonReplace.Enabled = false;
            }
            catch (Exception)
            {
            }
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            if (textBoxReplace.Text.Length == 0)
            {
                MessageBox.Show("Please enter a replacement before", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            listViewGroups.Items.Clear();

            try
            {
                Regex regex = new Regex(textBoxSearch.Text);
                string Replaced = regex.Replace(richTextBoxText.Text, textBoxReplace.Text);
                ListViewItem Item = new ListViewItem();
                Item.Text = "Replaced";
                Item.SubItems.Add(Replaced);
                listViewGroups.Items.Add(Item);
            }
            catch (Exception)
            {
            }
        }
    }
}
