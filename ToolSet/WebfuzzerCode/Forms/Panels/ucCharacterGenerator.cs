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
    public partial class ucCharacterGenerator : UserControl
    {
        public ucCharacterGenerator()
        {
            InitializeComponent();
        }

        private void ucCharacterGenerator_Load(object sender, EventArgs e)
        {
            comboBoxEncoding.SelectedIndex = 0;
        }

        public CharacterGenerator GetGenerator()
        {
            CharacterGenerator characterGenerator = new CharacterGenerator(); 
            characterGenerator.Name = textBoxName.Text;
            characterGenerator.Encoding = GeneratorEncoding.GetEncoding(comboBoxEncoding.SelectedIndex);
            characterGenerator.Increment = Convert.ToInt32(numericUpDownIncrement.Value);
            characterGenerator.StartCharacter = Convert.ToInt32(numericUpDownStartCharacter.Value);
            characterGenerator.StopCharacter = Convert.ToInt32(numericUpDownStopCharacter.Value);

            return characterGenerator;
        }

        public void LoadGenerator(CharacterGenerator Generator)
        {
            textBoxName.Text = Generator.Name;
            comboBoxEncoding.SelectedIndex = GeneratorEncoding.ReturnEncodingIndex(Generator.Encoding);
            numericUpDownIncrement.Value = Convert.ToDecimal(Generator.Increment);
            numericUpDownStartCharacter.Value = Convert.ToDecimal(Generator.StartCharacter);
            numericUpDownStopCharacter.Value = Convert.ToDecimal(Generator.StopCharacter);
        }

        public bool FieldsValid()
        {
            if (textBoxName.Text == string.Empty)
            {
                MessageBox.Show("Please type in the name of the Generator", "Generator: wrong input");
                return false;
            }
            else if (numericUpDownStartCharacter.Value >= numericUpDownStopCharacter.Value)
            {
                MessageBox.Show("The start character has to be lower than the stop character", "Generator: wrong input");
                return false;
            }
            else return true;
        }
    }
}
