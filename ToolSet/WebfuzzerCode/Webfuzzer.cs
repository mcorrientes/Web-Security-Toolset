using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using ToolSet.DatabaseExtractorCode;
using usertools.WebFuzzer;
using usertools.WebFuzzer.Forms;
using usertools.WebFuzzer.Forms.Panels;
using usertools.WebFuzzer.Components.Generators;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp;

namespace ToolSet.Webfuzzer
{
    public partial class UCWebfuzzer : UserControl
    {

        private usertools.WebFuzzer.WebFuzzer webFuzzer;
        private CookieCollection CookieCol;
        private bool AwaitingFinish;
        private bool UseMatchSettings;
        private string MatchRegex;
        private string MatchFile;
        private List<IGenerator> Generators;
        private List<FuzzerFilter> Filters;
        private int LastFilteredIndex;

        public UCWebfuzzer()
        {
            InitializeComponent();
            webFuzzer = new usertools.WebFuzzer.WebFuzzer();
            CookieCol = new CookieCollection();
            AwaitingFinish = false;
            UseMatchSettings = false;
            MatchRegex = string.Empty;
            MatchFile = string.Empty;
            Generators = new List<IGenerator>();
            Filters = new List<FuzzerFilter>();
            LastFilteredIndex = 0;
            comboBoxConditionType.SelectedIndex = 0;
            comboBoxFilterType.SelectedIndex = 0;
            //LoadDefaultFilters();
            textBoxSavePath.Text = Application.StartupPath + "\\match.txt";
            deserializeGenerators();
            deserializeFilters();
        }

        private void buttonStartFuzzer_Click(object sender, EventArgs e)
        {
            webFuzzer.RequestsMade = 0;
            webFuzzer.RequestAnzahl = 0;
            if (AwaitingFinish)
            {
                buttonStartFuzzer.Enabled = false;
                webFuzzer.Stop();
            }
            else
            {
                if (!VerifyStart())
                    return;

                AwaitingFinish = true;
                buttonStartFuzzer.Text = "Stop Fuzzing";
                LastFilteredIndex = 0;
                listViewResult.Items.Clear();

                MatchRegex = textBoxRegexMatch.Text;
                MatchFile = textBoxSavePath.Text;
                UseMatchSettings = checkBoxSaveMatches.Checked;

                webFuzzer.URL = textBoxURL.Text;
                if (checkBoxUsePOST.Checked)
                    webFuzzer.POST = richTextBoxPOST.Text;
                webFuzzer.CustomCookieCollection = CookieCol;
                webFuzzer.UseMatchFile = UseMatchSettings;
                webFuzzer.RegularMatch = MatchRegex;
                webFuzzer.MatchFile = MatchFile;
                webFuzzer.Generators = Generators;
                webFuzzer.FuzzerFilters = Filters;
                webFuzzer.Start();
                tabControl1.SelectedTab = tabPage2;
                tabControl1.Focus();
            }
        }


        private bool VerifyStart()
        {
            if (!textBoxURL.Text.ToLower().StartsWith("http://") && !textBoxURL.Text.ToLower().StartsWith("https://"))
            {
                MessageBox.Show("Url has to start with http:// or https://", "Start Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Generators.Count == 0)
            {
                MessageBox.Show("You need at least one generator", "Start Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void buttonCustomCookies_Click(object sender, EventArgs e)
        {
            frmCustomCookies dialog = new frmCustomCookies();
            if (dialog.ShowDialog() == DialogResult.OK)
                this.CookieCol = dialog.CookieCol;
        }

        private void timerWebfuzzer_Tick(object sender, EventArgs e)
        {
            if (AwaitingFinish)
            {
                if (webFuzzer.Finished)
                {

                    AwaitingFinish = false;
                    buttonStartFuzzer.Text = "Start Fuzzing";
                    buttonStartFuzzer.Enabled = true;
                }

                progressBarFuzzing.Maximum = webFuzzer.RequestAnzahl;
                progressBarFuzzing.Value = webFuzzer.RequestsMade;
                UpdateGUI();
            }
        }

        private void UpdateGUI()
        {
            for (; LastFilteredIndex < webFuzzer.FilteredRequests.Count; LastFilteredIndex++)
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = (LastFilteredIndex + 1).ToString();
                Item.SubItems.Add(webFuzzer.FilteredRequests[LastFilteredIndex].URL);
                listViewResult.Items.Add(Item);
            }
        }

        private void listViewResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewResult.SelectedIndices.Count > 0)
            {
                int Index = listViewResult.SelectedIndices[0];

                richTextBoxRequestHeaders.Text = webFuzzer.FilteredRequests[Index].RequestHeaders;
                richTextBoxResponseHeaders.Text = webFuzzer.FilteredRequests[Index].ResponseHeaders;
                richTextBoxSourceCode.Text = webFuzzer.FilteredRequests[Index].HTML;
                webBrowserResult.DocumentText = webFuzzer.FilteredRequests[Index].HTML;
            }
            else
            {
                richTextBoxRequestHeaders.Text = "";
                richTextBoxResponseHeaders.Text = "";
                richTextBoxSourceCode.Text = "";
                webBrowserResult.Navigate("about:blank");
            }
        }

        private void buttonGenerators_Click(object sender, EventArgs e)
        {
            contextMenuStripGenerators.Show(MousePosition.X, MousePosition.Y);
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            contextMenuStripInsert.Show(MousePosition.X, MousePosition.Y);
        }

        #region AddGenerator

        private void AddGenerator(Control control)
        {
            buttonSaveGenerator.Enabled = true;
            splitContainer4.Panel2.Controls.Clear();
            splitContainer4.Panel2.Controls.Add(control);
        }

        private void addNumberGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddGenerator(new ucNumberGenerator());
        }

        private void addCharacterGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddGenerator(new ucCharacterGenerator());
        }

        private void addFileGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddGenerator(new ucFileGenerator());
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddGenerator(new ucStringGenerator());
        }

        private void addRandomStringGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddGenerator(new ucRandomStringGenerator());
        }

        private void addCharacterRepeaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddGenerator(new ucCharacterRepeater());
        }
        #endregion

        private void listViewGenerators_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool enable = (listViewGenerators.SelectedIndices.Count > 0);
            buttonChangeGenerator.Enabled = enable;
            buttonDeleteGenerator.Enabled = enable;
            buttonInsert.Enabled = enable;
            if (enable)
            {
                LoadGeneratorGUI(Generators[listViewGenerators.SelectedIndices[0]]);
            }
        }

        private void buttonSaveGenerator_Click(object sender, EventArgs e)
        {
            if (splitContainer4.Panel2.Controls.Count == 0)
                return;

            AddGeneratorFromPanel(-1);
            SaveGenerators();
        }

        private void LoadGeneratorGUI(IGenerator Generator)
        {
            if (Generator.GetType() == typeof(CharacterGenerator))
            {
                ucCharacterGenerator ucGenerator = new ucCharacterGenerator();
                ucGenerator.LoadGenerator((CharacterGenerator)Generator);
                AddGenerator(ucGenerator);
            }
            else if (Generator.GetType() == typeof(CharacterRepeater))
            {
                ucCharacterRepeater ucGenerator = new ucCharacterRepeater();
                ucGenerator.LoadGenerator((CharacterRepeater)Generator);
                AddGenerator(ucGenerator);
            }
            else if (Generator.GetType() == typeof(FileGenerator))
            {
                ucFileGenerator ucGenerator = new ucFileGenerator();
                ucGenerator.LoadGenerator((FileGenerator)Generator);
                AddGenerator(ucGenerator);
            }
            else if (Generator.GetType() == typeof(NumberGenerator))
            {
                ucNumberGenerator ucGenerator = new ucNumberGenerator();
                ucGenerator.LoadGenerator((NumberGenerator)Generator);
                AddGenerator(ucGenerator);
            }
            else if (Generator.GetType() == typeof(RandomStringGenerator))
            {
                ucRandomStringGenerator ucGenerator = new ucRandomStringGenerator();
                ucGenerator.LoadGenerator((RandomStringGenerator)Generator);
                AddGenerator(ucGenerator);
            }
            else if (Generator.GetType() == typeof(StringGenerator))
            {
                ucStringGenerator ucGenerator = new ucStringGenerator();
                ucGenerator.LoadGenerator((StringGenerator)Generator);
                AddGenerator(ucGenerator);
            }
        }

        private void buttonDeleteGenerator_Click(object sender, EventArgs e)
        {
            if (listViewGenerators.SelectedIndices.Count == 0)
                return;

            int GeneratorIndex = listViewGenerators.SelectedIndices[0];
            Generators.RemoveAt(GeneratorIndex);
            listViewGenerators.Items.RemoveAt(GeneratorIndex);

            buttonDeleteGenerator.Enabled = false;
            buttonChangeGenerator.Enabled = false;
            buttonInsert.Enabled = false;
            splitContainer4.Panel2.Controls.Clear();
            SaveGenerators();
        }

        private void buttonChangeGenerator_Click(object sender, EventArgs e)
        {
            if (listViewGenerators.SelectedIndices.Count == 0)
                return;
            if (splitContainer4.Panel2.Controls.Count == 0)
                return;

            int GeneratorIndex = listViewGenerators.SelectedIndices[0];
            Generators.RemoveAt(GeneratorIndex);
            listViewGenerators.Items.RemoveAt(GeneratorIndex);
            AddGeneratorFromPanel(GeneratorIndex);
            SaveGenerators();
        }

        private void AddGeneratorFromPanel(int GeneratorIndex)
        {
            Type panelType = splitContainer4.Panel2.Controls[0].GetType();
            Control panelControl = splitContainer4.Panel2.Controls[0];

            ListViewItem Item = new ListViewItem();
            if (panelType == typeof(ucCharacterGenerator))
            {
                ucCharacterGenerator ucGenerator = (ucCharacterGenerator)panelControl;
                if (!ucGenerator.FieldsValid())
                    return;

                CharacterGenerator characterGenerator = ucGenerator.GetGenerator();
                foreach (ListViewItem item in listViewGenerators.Items)
                {
                    if (characterGenerator.Name == item.Text)
                    {
                        MessageBox.Show("This generator name already exists. Please choose another.", "Name taken", MessageBoxButtons.OK);
                        return;
                    }
                }

                if (GeneratorIndex == -1)
                    Generators.Add((IGenerator)characterGenerator);
                else
                    Generators.Insert(GeneratorIndex, (IGenerator)characterGenerator);
                Item.Text = characterGenerator.Name;
                Item.SubItems.Add("Character Generator");
                Item.SubItems.Add(
                    "Inc: " + characterGenerator.Increment.ToString() +
                    ", Start: " + characterGenerator.StartCharacter.ToString() +
                    ", Stop: " + characterGenerator.StopCharacter.ToString() +
                    ", Enc: " + characterGenerator.Encoding.ToString()
                    );
            }
            else if (panelType == typeof(ucCharacterRepeater))
            {
                ucCharacterRepeater ucGenerator = (ucCharacterRepeater)panelControl;
                if (!ucGenerator.FieldsValid())
                    return;

                CharacterRepeater characterRepeater = ucGenerator.GetGenerator();
                foreach (ListViewItem item in listViewGenerators.Items)
                {
                    if (characterRepeater.Name == item.Text)
                    {
                        MessageBox.Show("This generator name already exists. Please choose another.", "Name taken", MessageBoxButtons.OK);
                        return;
                    }
                }

                if (GeneratorIndex == -1)
                    Generators.Add((IGenerator)characterRepeater);
                else
                    Generators.Insert(GeneratorIndex, (IGenerator)characterRepeater);
                Item.Text = characterRepeater.Name;
                Item.SubItems.Add("Character Repeater Generator");
                Item.SubItems.Add(
                    "Inc: " + characterRepeater.Increment.ToString() +
                    ", Init: " + characterRepeater.InitialCount.ToString() +
                    ", Final: " + characterRepeater.FinalCount.ToString() +
                    ", Enc: " + characterRepeater.Encoding.ToString()
                    );
            }
            else if (panelType == typeof(ucFileGenerator))
            {
                ucFileGenerator ucGenerator = (ucFileGenerator)panelControl;
                if (!ucGenerator.FieldsValid())
                    return;

                FileGenerator fileGenerator = ucGenerator.GetGenerator();
                foreach (ListViewItem item in listViewGenerators.Items)
                {
                    if (fileGenerator.Name == item.Text)
                    {
                        MessageBox.Show("This generator name already exists. Please choose another.", "Name taken", MessageBoxButtons.OK);
                        return;
                    }
                }

                if (GeneratorIndex == -1)
                    Generators.Add((IGenerator)fileGenerator);
                else
                    Generators.Insert(GeneratorIndex, (IGenerator)fileGenerator);
                Item.Text = fileGenerator.Name;
                Item.SubItems.Add("File Generator");
                Item.SubItems.Add(
                    "File: " + fileGenerator.FilePath.ToString() +
                    ", Enc: " + fileGenerator.Encoding.ToString()
                    );
            }
            else if (panelType == typeof(ucNumberGenerator))
            {
                ucNumberGenerator ucGenerator = (ucNumberGenerator)panelControl;
                if (!ucGenerator.FieldsValid())
                    return;

                NumberGenerator numberGenerator = ucGenerator.GetGenerator();
                foreach (ListViewItem item in listViewGenerators.Items)
                {
                    if (numberGenerator.Name == item.Text)
                    {
                        MessageBox.Show("This generator name already exists. Please choose another.", "Name taken", MessageBoxButtons.OK);
                        return;
                    }
                }

                if (GeneratorIndex == -1)
                    Generators.Add((IGenerator)numberGenerator);
                else
                    Generators.Insert(GeneratorIndex, (IGenerator)numberGenerator);
                Item.Text = numberGenerator.Name;
                Item.SubItems.Add("Number Generator");
                Item.SubItems.Add(
                    "Inc: " + numberGenerator.Increment.ToString() +
                    ", Start: " + numberGenerator.StartNumber.ToString() +
                    ", Stop: " + numberGenerator.StopNumber.ToString() +
                    ", Enc: " + numberGenerator.Encoding.ToString()
                    );
            }
            else if (panelType == typeof(ucRandomStringGenerator))
            {
                ucRandomStringGenerator ucGenerator = (ucRandomStringGenerator)panelControl;
                if (!ucGenerator.FieldsValid())
                    return;

                RandomStringGenerator randomStringGenerator = ucGenerator.GetGenerator();
                foreach (ListViewItem item in listViewGenerators.Items)
                {
                    if (randomStringGenerator.Name == item.Text)
                    {
                        MessageBox.Show("This generator name already exists. Please choose another.", "Name taken", MessageBoxButtons.OK);
                        return;
                    }
                }

                if (GeneratorIndex == -1)
                    Generators.Add((IGenerator)randomStringGenerator);
                else
                    Generators.Insert(GeneratorIndex, (IGenerator)randomStringGenerator);
                Item.Text = randomStringGenerator.Name;
                Item.SubItems.Add("Random String Generator");
                Item.SubItems.Add(
                    "Rep: " + randomStringGenerator.AllowRepetitions.ToString() +
                    ", Chars: " + randomStringGenerator.CharacterSet +
                    ", MaxStrings: " + randomStringGenerator.MaximumStrings.ToString() +
                    ", StrLength: " + randomStringGenerator.StringLength.ToString() +
                    ", Enc: " + randomStringGenerator.Encoding.ToString()
                    );
            }
            else if (panelType == typeof(ucStringGenerator))
            {
                ucStringGenerator ucGenerator = (ucStringGenerator)panelControl;
                if (!ucGenerator.FieldsValid())
                    return;

                StringGenerator stringGenerator = ucGenerator.GetGenerator();
                foreach (ListViewItem item in listViewGenerators.Items)
                {
                    if (stringGenerator.Name == item.Text)
                    {
                        MessageBox.Show("This generator name already exists. Please choose another.", "Name taken", MessageBoxButtons.OK);
                        return;
                    }
                }

                if (GeneratorIndex == -1)
                    Generators.Add((IGenerator)stringGenerator);
                else
                    Generators.Insert(GeneratorIndex, (IGenerator)stringGenerator);
                Item.Text = stringGenerator.Name;
                Item.SubItems.Add("String Generator");
                Item.SubItems.Add(
                    "Rep: " + stringGenerator.AllowRepetitions.ToString() +
                    ", Chars: " + stringGenerator.CharacterSet +
                    ", StrLength: " + stringGenerator.StringLength.ToString() +
                    ", Enc: " + stringGenerator.Encoding.ToString()
                    );
            }

            if (GeneratorIndex == -1)
                listViewGenerators.Items.Add(Item);
            else
                listViewGenerators.Items.Insert(GeneratorIndex, Item);
        }

        private void insertIntoURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewGenerators.SelectedIndices.Count == 0)
                return;

            int GeneratorIndex = listViewGenerators.SelectedIndices[0];
            textBoxURL.Text += "{" + Generators[GeneratorIndex].Name + "}";
        }

        private void insertIntoPOSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewGenerators.SelectedIndices.Count == 0)
                return;

            int GeneratorIndex = listViewGenerators.SelectedIndices[0];
            richTextBoxPOST.Text += "{" + Generators[GeneratorIndex].Name + "}";
        }

        private void buttonAddFilter_Click(object sender, EventArgs e)
        {
             FuzzerFilter Filter = new FuzzerFilter();

            foreach (ListViewItem item in listViewFilters.Items)
            {
                if (item.Text == textBoxFilterName.Text)
                {
                    MessageBox.Show("This filter name already exists. Please choose another", "Name taken",MessageBoxButtons.OK);
                    return;
                }
            }

            Filter.Name = textBoxFilterName.Text;
            Filter.ConditionValue = textBoxRegex.Text;
            if (comboBoxFilterType.SelectedIndex == 0)
                Filter.FilterType = FuzzerFilter.FilterTypes.Exclude;
            else
                Filter.FilterType = FuzzerFilter.FilterTypes.Include;

            if (comboBoxConditionType.SelectedIndex == 0)
                Filter.ConditionType = FuzzerFilter.ConditionTypes.ResponseStatusCode;
            else if (comboBoxConditionType.SelectedIndex == 1)
                Filter.ConditionType = FuzzerFilter.ConditionTypes.ResponseHTML;
            else if (comboBoxConditionType.SelectedIndex == 2)
                Filter.ConditionType = FuzzerFilter.ConditionTypes.ResponseHeaders;
            Filters.Add(Filter);

            AddFilterToGui(Filter);
            SaveFilters();
        }

        private void AddFilterToGui(FuzzerFilter Filter)
        {
            ListViewItem Item = new ListViewItem();
            Item.Text = Filter.Name;
            Item.SubItems.Add(Filter.FilterType.ToString());
            Item.SubItems.Add(Filter.ConditionType.ToString());
            Item.SubItems.Add(Filter.ConditionValue);
            listViewFilters.Items.Add(Item);
        }

        private void buttonDeleteFilter_Click(object sender, EventArgs e)
        {
            if (listViewFilters.SelectedIndices.Count == 0)
                return;

            int FilterIndex = listViewFilters.SelectedIndices[0];
            listViewFilters.Items.RemoveAt(FilterIndex);
            Filters.RemoveAt(FilterIndex);
            SaveFilters();
        }

        private void listViewFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool Enable = listViewFilters.SelectedIndices.Count > 0;
            buttonDeleteFilter.Enabled = Enable;
        }

        private void buttonSavePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBoxSavePath.Text = openFileDialog.FileName;
        }

        private void SaveGenerators()
        {
            if (Generators.Count > 0)
            {
                try
                {
                    using (Stream newStream = File.Open(Application.StartupPath + "\\Generators.dat", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(newStream, Generators);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fehler beim Speichern" + ex);
                }
            }
        }

        private void SaveFilters()
        {
            if (Filters.Count > 0)
            {
                try
                {
                    using (Stream newStream = File.Open(Application.StartupPath + "\\Filters.dat", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(newStream, Filters);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fehler beim Speichern" + ex);
                }
            }
        }

        private void deserializeGenerators()
        {
            if (File.Exists(Application.StartupPath + "\\Generators.dat"))
            {
                ListViewItem Item;
                try
                {
                    using (Stream deStream = File.Open(Application.StartupPath + "\\Generators.dat", FileMode.Open))
                    {

                        BinaryFormatter bin = new BinaryFormatter();
                        Generators = (List<IGenerator>)bin.Deserialize(deStream);
                        foreach (IGenerator generator in Generators)
                        {
                            Item = new ListViewItem();

                            if (generator.GetType() == typeof(CharacterGenerator))
                            {
                                CharacterGenerator characterGenerator = (CharacterGenerator)generator;
                                Item.Text = characterGenerator.Name;
                                Item.SubItems.Add("Character Generator");
                                Item.SubItems.Add(
                                    "Inc: " + characterGenerator.Increment.ToString() +
                                    ", Start: " + characterGenerator.StartCharacter.ToString() +
                                    ", Stop: " + characterGenerator.StopCharacter.ToString() +
                                    ", Enc: " + characterGenerator.Encoding.ToString()
                                    );
                            }
                            else if (generator.GetType() == typeof(CharacterRepeater))
                            {
                                CharacterRepeater characterRepeater = (CharacterRepeater)generator;
                                Item.Text = characterRepeater.Name;
                                Item.SubItems.Add("Character Repeater Generator");
                                Item.SubItems.Add(
                                    "Inc: " + characterRepeater.Increment.ToString() +
                                    ", Init: " + characterRepeater.InitialCount.ToString() +
                                    ", Final: " + characterRepeater.FinalCount.ToString() +
                                    ", Enc: " + characterRepeater.Encoding.ToString()
                                    );
                            }
                            else if (generator.GetType() == typeof(FileGenerator))
                            {
                                FileGenerator fileGenerator = (FileGenerator)generator;
                                Item.Text = fileGenerator.Name;
                                Item.SubItems.Add("File Generator");
                                Item.SubItems.Add(
                                    "File: " + fileGenerator.FilePath.ToString() +
                                    ", Enc: " + fileGenerator.Encoding.ToString()
                                    );

                            }
                            else if (generator.GetType() == typeof(NumberGenerator))
                            {
                                NumberGenerator numberGenerator = (NumberGenerator)generator;
                                Item.Text = numberGenerator.Name;
                                Item.SubItems.Add("Number Generator");
                                Item.SubItems.Add(
                                    "Inc: " + numberGenerator.Increment.ToString() +
                                    ", Start: " + numberGenerator.StartNumber.ToString() +
                                    ", Stop: " + numberGenerator.StopNumber.ToString() +
                                    ", Enc: " + numberGenerator.Encoding.ToString()
                                    );

                            }
                            else if (generator.GetType() == typeof(RandomStringGenerator))
                            {
                                RandomStringGenerator randomStringGenerator = (RandomStringGenerator)generator;
                                Item.Text = randomStringGenerator.Name;
                                Item.SubItems.Add("Random String Generator");
                                Item.SubItems.Add(
                                    "Rep: " + randomStringGenerator.AllowRepetitions.ToString() +
                                    ", Chars: " + randomStringGenerator.CharacterSet +
                                    ", MaxStrings: " + randomStringGenerator.MaximumStrings.ToString() +
                                    ", StrLength: " + randomStringGenerator.StringLength.ToString() +
                                    ", Enc: " + randomStringGenerator.Encoding.ToString()
                                    );

                            }
                            else if (generator.GetType() == typeof(StringGenerator))
                            {
                                StringGenerator stringGenerator = (StringGenerator)generator;
                                Item.Text = stringGenerator.Name;
                                Item.SubItems.Add("String Generator");
                                Item.SubItems.Add(
                                    "Rep: " + stringGenerator.AllowRepetitions.ToString() +
                                    ", Chars: " + stringGenerator.CharacterSet +
                                    ", StrLength: " + stringGenerator.StringLength.ToString() +
                                    ", Enc: " + stringGenerator.Encoding.ToString()
                                    );
                            }
                            listViewGenerators.Items.Add(Item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fehler beim Laden der File" + ex);
                }
            }
        }

        private void deserializeFilters()
        {
            if (File.Exists(Application.StartupPath + "\\Filters.dat"))
            {
                try
                {

                    using (Stream deStream = File.Open(Application.StartupPath + "\\Filters.dat", FileMode.Open))
                    {

                        BinaryFormatter bin = new BinaryFormatter();
                        Filters = (List<FuzzerFilter>)bin.Deserialize(deStream);
                    }
                    foreach (FuzzerFilter filter in Filters)
                    {
                        AddFilterToGui(filter);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fehler beim Filter deserialisieren " + ex);
                }
            }

        }

        private void buttonSaveList_Click(object sender, EventArgs e)
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
                document.AddTitle("Webfuzzer Report");
                document.AddCreationDate();
                document.Open();
                document.Add(new Paragraph("WebFuzzer Found URLs", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, iTextSharp.text.Font.UNDERLINE)));
                document.Add(new Paragraph(" "));
                foreach (ListViewItem item in listViewResult.Items)
                {
                    document.Add(new Paragraph(item.SubItems[1].Text));
                    if (richTextBoxPOST.Text != string.Empty)
                    {
                        document.Add(new Paragraph("POST data: " + richTextBoxPOST.Text));
                    }
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

        private void checkBoxUsePOST_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
