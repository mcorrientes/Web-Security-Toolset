using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace usertools.AuthenticationTester.Forms
{
    public partial class frmAuthenticationForm : Form
    {
        private AuthenticationForm authForm;
        public AuthenticationForm AuthForm
        {
            get { return authForm; }
        }

        private List<AuthenticationForm> authForms;
        public List<AuthenticationForm> AuthForms
        {
            get { return authForms; }
        }

        public frmAuthenticationForm(string URL)
        {
            InitializeComponent();
            authForm = new AuthenticationForm();
            authForms = new List<AuthenticationForm>();
            textBoxURL.Text = URL;
        }

        public void LoadAuthForms(List<AuthenticationForm> AuthenticationForms)
        {
            authForms = AuthenticationForms;
            FillGUIForms(authForms);
        }

        public void LoadOnlineForms()
        {
            authForms = LoadForms(textBoxURL.Text);
            FillGUIForms(authForms);
        }

        private List<AuthenticationForm> LoadForms(string URL)
        {
            List<AuthenticationForm> Forms = new List<AuthenticationForm>();

            CreateWebrequest webRequest = new CreateWebrequest();
            string HTML = webRequest.StringGetWebPage(URL, string.Empty);
            if (HTML != string.Empty)
            {
                int LastFormIndexEnd = 0;
                while (true)
                {
                    string NewHTML = HTML.Substring(LastFormIndexEnd);

                    int FormIndex = NewHTML.ToLower().IndexOf("<form");
                    int FormIndexEnd = NewHTML.ToLower().IndexOf("</form>") + 7;
                    int FormLength = FormIndexEnd - FormIndex;

                    if (FormIndex == -1 || FormIndex >= FormIndexEnd)
                        break;

                    string HTMLForm = NewHTML.Substring(FormIndex, FormLength);

                    string action = RegexText(" action\\=\\\"([^\"]*)\\\"", HTMLForm);
                    string method = RegexText(" method\\=\\\"([^\"]*)\\\"", HTMLForm);

                    AuthenticationForm authForm = new AuthenticationForm();
                    authForm.Action = GetURL(textBoxURL.Text, action);
                    if (method.ToLower() == "get")
                        authForm.Method = AuthenticationForm.Methods.GET;
                    else
                        authForm.Method = AuthenticationForm.Methods.POST;

                    authForm.InputFields = LoadInputFields(HTMLForm);
                    if (!authForm.Action.ToLower().Contains("javascript:"))
                        Forms.Add(authForm);

                    LastFormIndexEnd += FormIndexEnd;
                }
            }

            return Forms;
        }

        private List<InputField> LoadInputFields(string HTMLForm)
        {
            List<InputField> InputFields = new List<InputField>();
            int LastFormIndexEnd = 0;
            while (true)
            {
                string NewHTML = HTMLForm.Substring(LastFormIndexEnd);

                int InputIndex = NewHTML.ToLower().IndexOf("<input");
                int Count = -1;
                if (InputIndex > -1)
                    NewHTML = HTMLForm.Substring(LastFormIndexEnd + InputIndex);

                if (NewHTML.Contains("/>") || NewHTML.ToLower().Contains("</input>"))
                {
                    Count = NewHTML.ToLower().IndexOf("</input>") + 7;
                    if (Count == 6 || (InputIndex < Count && NewHTML.Substring(InputIndex, Count).ToLower().Contains("<input>")))
                        Count = NewHTML.ToLower().IndexOf("/>") + 2;
                }
                if (Count == -1)
                    Count = NewHTML.ToLower().IndexOf(">") + 1;

                if (InputIndex == -1 || Count < 7)
                    break;

                string HTMLInput = NewHTML.Substring(0, Count);

                string type = RegexText(" type\\=\\\"([^\"]*)\\\"", HTMLInput);
                if (type == string.Empty)
                    type = RegexText(" type\\=([^ >]*)", HTMLInput);

                string name = RegexText(" name\\=\\\"([^\"]*)\\\"", HTMLInput);
                if (name == string.Empty)
                    name = RegexText(" name\\=([^ >]*)", HTMLInput);

                string value = RegexText(" value\\=\\\"([^\"]*)\\\"", HTMLInput);
                if (value == string.Empty)
                    value = RegexText(" value\\=([^ >]*)", HTMLInput);

                InputField inputField = new InputField();
                inputField.Name = name;
                inputField.Type = type;
                inputField.Value = value;
                InputFields.Add(inputField);

                LastFormIndexEnd += InputIndex + Count;
            }
            return InputFields;
        }

        private void FillGUIForms(List<AuthenticationForm> Forms)
        {
            listViewForms.Items.Clear();
            for (int i = 0; i < Forms.Count; i++)
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = Forms[i].Action;

                string Method = "POST";
                if (Forms[i].Method == AuthenticationForm.Methods.GET)
                    Method = "GET";

                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Method });
                listViewForms.Items.Add(Item);
            }
        }

        private void listViewInputFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool Enable = listViewInputFields.SelectedIndices.Count > 0;
            if (Enable)
            {
                int SelectedInputField = listViewInputFields.SelectedIndices[0];
                bool EnableUsername = true;
                bool EnablePassword = true;
                bool EnableClear = false;

                for (int i = 0; i < authForms[listViewForms.SelectedIndices[0]].InputFields.Count; i++)
                {
                    InputField inputField = authForms[listViewForms.SelectedIndices[0]].InputFields[i];

                    if (inputField.InputType == InputField.InputTypes.Username)
                        EnableUsername = false;
                    if (inputField.InputType == InputField.InputTypes.Password)
                        EnablePassword = false;


                    if ((inputField.InputType == InputField.InputTypes.Password && i == SelectedInputField) ||
                        (inputField.InputType == InputField.InputTypes.Username && i == SelectedInputField))
                        EnableClear = true;
                }

                buttonSetPassword.Enabled = EnablePassword;
                buttonSetUsername.Enabled = EnableUsername;
                buttonClear.Enabled = EnableClear;
            }
            else
            {
                buttonSetPassword.Enabled = Enable;
                buttonSetUsername.Enabled = Enable;
                buttonClear.Enabled = Enable;
            }
        }

        private void listViewForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSetPassword.Enabled = false;
            buttonSetUsername.Enabled = false;
            buttonClear.Enabled = false;

            if (listViewForms.SelectedIndices.Count > 0)
            {
                listViewInputFields.Enabled = true;
                FillGUIInputFields(authForms[listViewForms.SelectedIndices[0]]);
            }
            else
                listViewInputFields.Enabled = false;
        }

        private void FillGUIInputFields(AuthenticationForm Form)
        {
            listViewInputFields.Items.Clear();
            for (int i = 0; i < Form.InputFields.Count; i++)
            {
                ListViewItem Item = new ListViewItem();
                string MarkedAs = string.Empty;
                if (Form.InputFields[i].InputType == InputField.InputTypes.Password)
                    MarkedAs = "Password";
                else if (Form.InputFields[i].InputType == InputField.InputTypes.Username)
                    MarkedAs = "Username";

                Item.Text = MarkedAs;
                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Form.InputFields[i].Name });
                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Form.InputFields[i].Type });
                Item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Form.InputFields[i].Value });

                listViewInputFields.Items.Add(Item);
            }
        }

        private void buttonSetUsername_Click(object sender, EventArgs e)
        {
            if (listViewForms.SelectedIndices.Count > 0)
            {
                int FormIndex = listViewForms.SelectedIndices[0];

                if (listViewInputFields.SelectedIndices.Count > 0)
                {
                    buttonClear.Enabled = true;
                    buttonSetUsername.Enabled = false;
                    int InputIndex = listViewInputFields.SelectedIndices[0];
                    authForms[FormIndex].InputFields[InputIndex].InputType = InputField.InputTypes.Username;
                    listViewInputFields.Items[InputIndex].Text = "Username";
                }
            }
        }

        private void buttonSetPassword_Click(object sender, EventArgs e)
        {
            if (listViewForms.SelectedIndices.Count > 0)
            {
                int FormIndex = listViewForms.SelectedIndices[0];

                if (listViewInputFields.SelectedIndices.Count > 0)
                {
                    buttonClear.Enabled = true;
                    buttonSetPassword.Enabled = false;
                    int InputIndex = listViewInputFields.SelectedIndices[0];
                    authForms[FormIndex].InputFields[InputIndex].InputType = InputField.InputTypes.Password;
                    listViewInputFields.Items[InputIndex].Text = "Password";
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (listViewForms.SelectedIndices.Count > 0)
            {
                int FormIndex = listViewForms.SelectedIndices[0];

                if (listViewInputFields.SelectedIndices.Count > 0)
                {
                    buttonClear.Enabled = false;
                    int InputIndex = listViewInputFields.SelectedIndices[0];
                    if (authForms[FormIndex].InputFields[InputIndex].InputType == InputField.InputTypes.Username)
                        buttonSetUsername.Enabled = true;
                    else if (authForms[FormIndex].InputFields[InputIndex].InputType == InputField.InputTypes.Password)
                        buttonSetPassword.Enabled = true;
                    authForms[FormIndex].InputFields[InputIndex].InputType = InputField.InputTypes.None;
                    listViewInputFields.Items[InputIndex].Text = "";
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (listViewForms.SelectedIndices.Count > 0)
                authForm = authForms[listViewForms.SelectedIndices[0]];
        }

        private string GetURL(string OriginalURL, string Link)
        {
            if (Link == string.Empty)
                return OriginalURL;

            if (Link.Contains("://"))
            {
                return Link;
            }
            else if (Link.StartsWith("#"))
            {
                return OriginalURL;
            }
            else if (Link.StartsWith("/"))
            {
                int StartIndex = OriginalURL.IndexOf('/', OriginalURL.IndexOf("://") + 3) + 1;
                if (StartIndex != 0)
                    return OriginalURL.Substring(0, StartIndex - 1) + Link;
                else
                    return OriginalURL + "/" + Link;
            }
            else if (Link.StartsWith("../"))
            {
                string tempLink = Link;
                int AboveFolder = 0;
                while (tempLink.StartsWith("../"))
                {
                    tempLink.Remove(3);
                    AboveFolder++;
                }

                int LastFolderIndex = Link.Length;
                for (int i = 0; i < AboveFolder; i++)
                    LastFolderIndex = Link.LastIndexOf('/', LastFolderIndex);

                string NewLink = Link.Substring(0, LastFolderIndex + 1);
                NewLink += tempLink;

                return NewLink;
            }
            else
            {
                int StartIndex = OriginalURL.LastIndexOf('/', OriginalURL.IndexOf("://") + 3) + 1;
                if (StartIndex != 0)
                    return OriginalURL.Substring(0, StartIndex) + Link;
                else
                    return OriginalURL + "/" + Link;
            }
        }

        private string RegexText(string Search, string Text)
        {
            string MatchText = "";

            try
            {
                Regex regex = new Regex(Search, RegexOptions.IgnoreCase);
                Match match = regex.Match(Text);
                if (match.Success)
                    if (match.Groups.Count > 0)
                        MatchText = match.Groups[1].Value;
            }
            catch (Exception)
            {
            }
            return MatchText;
        }
    }
}
