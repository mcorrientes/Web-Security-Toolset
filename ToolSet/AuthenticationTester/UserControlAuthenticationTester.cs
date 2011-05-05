using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp;
using usertools.AuthenticationTester;
using usertools.AuthenticationTester.Forms;

namespace ToolSet.AuthenticationTesterCode
{
    public partial class UserControlAuthenticationTester : UserControl
    {
        private AuthenticationForm AuthForm;
        private List<AuthenticationForm> AuthenticationForms;
        private AuthenticationTester authTester;
        private bool AwaitingFinish;
        private int LastCombinationIndex;

        public UserControlAuthenticationTester()
        {
            InitializeComponent();
            AuthForm = new AuthenticationForm();
            AuthenticationForms = new List<AuthenticationForm>();
            authTester = new AuthenticationTester();
            LoadTestFiles();
            AwaitingFinish = false;
            LastCombinationIndex = 0;
        }

        private void LoadTestFiles()
        {
            // Apply default user/password paths
            textBoxUsernameFile.Text = Application.StartupPath + @"\AuthenticationTester\usernames.txt";
            textBoxPasswordFile.Text = Application.StartupPath + @"\AuthenticationTester\passwords.txt";
            // Combobox default select
            comboBoxAuthMethod.SelectedIndex = 0;
            comboBoxCondition.SelectedIndex = 0;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (AwaitingFinish)
            {
                authTester.Stop();
                buttonStart.Enabled = false;
            }
            else
            {
                if (!VerifyInputStart())
                    return;

                listViewAuths.Items.Clear();
                buttonSelectFields.Enabled = false;
                textBoxURL.ReadOnly = true;
                buttonStart.Text = "Stop";
                AwaitingFinish = true;
                LastCombinationIndex = 0;

                authTester = new AuthenticationTester();
                authTester.URL = textBoxURL.Text;
                authTester.AuthForm = AuthForm;
                authTester.Usernames = new List<string>(File.ReadAllLines(textBoxUsernameFile.Text));
                authTester.Passwords = new List<string>(File.ReadAllLines(textBoxPasswordFile.Text));
                toolStripProgressBarAuthTester.Maximum = authTester.Usernames.Count * authTester.Passwords.Count;

                authTester.SuccessFilter.Text = textBoxCondition.Text;
                if (comboBoxCondition.SelectedIndex == 0)
                    authTester.SuccessFilter.Condition = Filter.Conditions.StatusCodeIs;
                else if (comboBoxCondition.SelectedIndex == 1)
                    authTester.SuccessFilter.Condition = Filter.Conditions.StatusCodeIsNot;
                else if (comboBoxCondition.SelectedIndex == 2)
                    authTester.SuccessFilter.Condition = Filter.Conditions.HTMLContains;
                else if (comboBoxCondition.SelectedIndex == 3)
                    authTester.SuccessFilter.Condition = Filter.Conditions.HTMLContainsNot;
                else if (comboBoxCondition.SelectedIndex == 4)
                    authTester.SuccessFilter.Condition = Filter.Conditions.RegularExpression;

                if (comboBoxAuthMethod.SelectedIndex == 0)
                    authTester.Authentication = AuthenticationTester.AuthenticationMethods.BasicAuth;
                else
                    authTester.Authentication = AuthenticationTester.AuthenticationMethods.HTMLForm;

                authTester.Start();
            }
        }

        private void comboBoxAuthMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSelectFields.Visible = (comboBoxAuthMethod.SelectedIndex != 0);
        }

        public bool VerifyInputStart()
        {
            if (!textBoxURL.Text.ToLower().StartsWith("http://") && !textBoxURL.Text.ToLower().StartsWith("https://"))
            {
                MessageBox.Show("Url has to start with http:// or https://", "Start Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxCondition.Text.Length == 0)
            {
                MessageBox.Show("No condition value has been set", "Start Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!File.Exists(textBoxUsernameFile.Text))
            {
                MessageBox.Show("Could Not Find Username File", "Start Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!File.Exists(textBoxPasswordFile.Text))
            {
                MessageBox.Show("Could Not Find Password File", "Start Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxCondition.SelectedIndex == 0 || comboBoxCondition.SelectedIndex == 1)
            {
                foreach (Char chr in textBoxCondition.Text)
                {
                    if (!Char.IsDigit(chr))
                    {
                        MessageBox.Show("Your Condition Value Has To Be Numeric", "Start Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            if (comboBoxCondition.SelectedIndex == 4)
            {
                try
                {
                    Regex regex = new Regex(textBoxCondition.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Your Regular Expression Is Not Valid", "Start Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (comboBoxAuthMethod.SelectedIndex == 1)
            {
                bool usernameSet = false;
                bool passwordSet = false;

                if (AuthenticationForms.Count == 0)
                {
                    MessageBox.Show("No Authentication Set For The HTML Form", "Start Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                foreach (InputField inputField in AuthForm.InputFields)
                {
                    if (inputField.InputType == InputField.InputTypes.Username)
                        usernameSet = true;
                    else if (inputField.InputType == InputField.InputTypes.Password)
                        passwordSet = true;
                }

                if (!usernameSet)
                {
                    MessageBox.Show("No username has been set for the authentication form!", "Start Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!passwordSet)
                {
                    MessageBox.Show("No password has been set for the authentication form!", "Start Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        public bool VerifyInputSelectField()
        {
            if (!textBoxURL.Text.ToLower().StartsWith("http://") && !textBoxURL.Text.ToLower().StartsWith("https://"))
            {
                MessageBox.Show("Url has to start with http:// or https://");
                return false;
            }

            return true;
        }

        private void buttonSelectFields_Click(object sender, EventArgs e)
        {
            if (!VerifyInputSelectField())
                return;

            frmAuthenticationForm authDialog = new frmAuthenticationForm(textBoxURL.Text);
            if (AuthenticationForms.Count > 0)
                authDialog.LoadAuthForms(AuthenticationForms);
            else
                authDialog.LoadOnlineForms();

            if (authDialog.ShowDialog() == DialogResult.OK)
            {
                AuthForm = authDialog.AuthForm;
                AuthenticationForms = authDialog.AuthForms;
            }
        }

        private void buttonSelectUsernameFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBoxUsernameFile.Text = openFileDialog.FileName;
        }

        private void buttonSelectPasswordFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBoxPasswordFile.Text = openFileDialog.FileName;
        }

        private void timerGUI_Tick(object sender, EventArgs e)
        {
            if (AwaitingFinish)
            {
                if (authTester.Finished)
                {
                    buttonSelectFields.Enabled = true;
                    textBoxURL.ReadOnly = false;
                    AwaitingFinish = false;
                    buttonStart.Text = "Start";
                    buttonStart.Enabled = true;
                }
                for (; LastCombinationIndex < authTester.ValidCombinations.Count; LastCombinationIndex++)
                {
                    ListViewItem Item = new ListViewItem();
                    Item.Text = authTester.ValidCombinations[LastCombinationIndex].Username;
                    Item.SubItems.Add(authTester.ValidCombinations[LastCombinationIndex].Password);
                    listViewAuths.Items.Add(Item);
                }

                int Value = toolStripProgressBarAuthTester.Maximum - authTester.RequestsLeft();
                if (Value > -1 && Value <= toolStripProgressBarAuthTester.Maximum)
                    toolStripProgressBarAuthTester.Value = Value;
            }
        }

        private void textBoxURL_TextChanged(object sender, EventArgs e)
        {
            AuthenticationForms.Clear();
            AuthForm = new AuthenticationForm();
        }

        private void toolStripButtonSaveList_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Report (*.pdf)|*.pdf|All (*.*)|*.*";
            DialogResult result = saveFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                Speichern(saveFile.FileName);
            }
        }

        private void Speichern(string filename)
        {
            try
            {
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
                document.AddTitle("Authentication Report");
                document.AddCreationDate();
                document.Open();
                document.Add(new Paragraph("Authentication Tester: User/Password List", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, iTextSharp.text.Font.UNDERLINE)));
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph("From: " + textBoxURL.Text));
                document.Add(new Paragraph(" "));
                foreach (ListViewItem item in listViewAuths.Items)
                {
                    document.Add(new Paragraph("Username: " + item.Text));
                    document.Add(new Paragraph("Password: " + item.SubItems[1].Text));
                    document.Add(new Paragraph(" "));
                }
                document.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("The file is in use. Please close all applications accessing this file and try again.", "Access not possible", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Speichern" + ex);
            }
        }
    }
}
