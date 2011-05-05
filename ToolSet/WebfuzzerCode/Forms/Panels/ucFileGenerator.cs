using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using usertools.WebFuzzer.Components.Generators;
using System.IO;

namespace usertools.WebFuzzer.Forms.Panels
{
    public partial class ucFileGenerator : UserControl
    {
        
        public ucFileGenerator()
        {
            InitializeComponent();
        }

        private void File_Generator_Load(object sender, EventArgs e)
        {
            comboBoxEncoding.SelectedIndex = 0;
        }

        private void buttonSearchFile_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFileName.Text = openFileDialog1.FileName;
            }
        }

        public FileGenerator GetGenerator()
        {
            FileGenerator fileGenerator = new FileGenerator();
            fileGenerator.Name = textBoxName.Text;
            fileGenerator.Encoding = GeneratorEncoding.GetEncoding(comboBoxEncoding.SelectedIndex);
            fileGenerator.FilePath = textBoxFileName.Text;

            return fileGenerator;
        }

        public void LoadGenerator(FileGenerator Generator)
        {
            textBoxName.Text = Generator.Name;
            comboBoxEncoding.SelectedIndex = GeneratorEncoding.ReturnEncodingIndex(Generator.Encoding);
            textBoxFileName.Text = Generator.FilePath;
        }

        public bool FieldsValid()
        {
            if (textBoxName.Text == string.Empty)
            {
                MessageBox.Show("Please type in the name of the Generator","Generator: wrong input");
                return false;
            }
            else if (!File.Exists(@textBoxFileName.Text))
            {
                MessageBox.Show("The file does not exist at the given path", "Generator: wrong input");
                return false;
            }
            else return true;
        }
    }
}
