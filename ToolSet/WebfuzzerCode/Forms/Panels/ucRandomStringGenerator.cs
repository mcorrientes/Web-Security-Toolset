using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using usertools.WebFuzzer.Components.Generators;

namespace usertools.WebFuzzer.Forms.Panels
{
    public partial class ucRandomStringGenerator : UserControl
    {
        public ucRandomStringGenerator()
        {
            InitializeComponent();
        }

        private void ucRandomStringGenerator_Load(object sender, EventArgs e)
        {
            comboBoxEncoding.SelectedIndex = 0;
        }

        public RandomStringGenerator GetGenerator()
        {
            RandomStringGenerator randomGenerator = new RandomStringGenerator();
            randomGenerator.Name = textBoxName.Text;
            randomGenerator.Encoding = GeneratorEncoding.GetEncoding(comboBoxEncoding.SelectedIndex);
            randomGenerator.CharacterSet = textBoxCharacterSet.Text;
            randomGenerator.StringLength = Convert.ToInt32(numericUpDownStringLength.Value);
            randomGenerator.MaximumStrings = Convert.ToInt32(numericUpDownNumberOfStrings.Value);
            randomGenerator.AllowRepetitions = checkBoxAllowRepetitions.Checked;

            return randomGenerator;
        }

        public void LoadGenerator(RandomStringGenerator Generator)
        {
            textBoxName.Text = Generator.Name;
            comboBoxEncoding.SelectedIndex = GeneratorEncoding.ReturnEncodingIndex(Generator.Encoding);
            numericUpDownNumberOfStrings.Value = Convert.ToInt32(Generator.MaximumStrings);
            numericUpDownStringLength.Value = Convert.ToDecimal(Generator.StringLength);
            checkBoxAllowRepetitions.Checked = Generator.AllowRepetitions;
            textBoxCharacterSet.Text = Generator.CharacterSet;
        }

        public bool FieldsValid()
        {
            if (textBoxName.Text == string.Empty)
            {
                MessageBox.Show("Please type in the name of the Generator", "Generator: wrong input");
                return false;
            }
            else if (textBoxCharacterSet.Text == string.Empty)
            {
                MessageBox.Show("Please define a character set", "Generator: wrong input");
                return false;
            }
            else if (checkBoxAllowRepetitions.Checked == false && (Convert.ToInt32(numericUpDownStringLength.Value) > textBoxCharacterSet.Text.Length))
            {
                    MessageBox.Show("The quantity of the character set has to be higher then the string length if you do not allow repetitions", "Generator: wrong input");
                    return false;
            }
            else return true;
        }
    }
}
