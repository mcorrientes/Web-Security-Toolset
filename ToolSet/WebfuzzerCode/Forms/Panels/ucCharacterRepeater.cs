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
    public partial class ucCharacterRepeater : UserControl
    {
        public ucCharacterRepeater()
        {
            InitializeComponent();
        }

        private void ucCharacter_Repeater_Load(object sender, EventArgs e)
        {
            comboBoxEncoding.SelectedIndex = 0;
        }

        public CharacterRepeater GetGenerator()
        {
            CharacterRepeater characterRepeaterGenerator = new CharacterRepeater();
            characterRepeaterGenerator.Name = textBoxName.Text;
            characterRepeaterGenerator.Encoding = GeneratorEncoding.GetEncoding(comboBoxEncoding.SelectedIndex);
            characterRepeaterGenerator.Increment = Convert.ToInt32(numericUpDownIncrement.Value);
            characterRepeaterGenerator.InitialCount = Convert.ToInt32(numericUpDownInitialCount.Value);
            characterRepeaterGenerator.FinalCount = Convert.ToInt32(numericUpDownFinalCount.Value);
            characterRepeaterGenerator.Character = textBoxCharacterString.Text;

            return characterRepeaterGenerator;
        }

        public void LoadGenerator(CharacterRepeater Generator)
        {
            textBoxName.Text = Generator.Name;
            comboBoxEncoding.SelectedIndex = GeneratorEncoding.ReturnEncodingIndex(Generator.Encoding);
            numericUpDownIncrement.Value = Convert.ToDecimal(Generator.Increment);
            numericUpDownInitialCount.Value = Convert.ToDecimal(Generator.InitialCount);
            numericUpDownFinalCount.Value = Convert.ToDecimal(Generator.FinalCount);
            textBoxCharacterString.Text = Generator.Character;
        }

        public bool FieldsValid()
        {
            if (textBoxName.Text == string.Empty)
            {
                MessageBox.Show("Please type in the name of the Generator", "Generator: wrong input");
                return false;
            }
            else if (numericUpDownInitialCount.Value >= numericUpDownFinalCount.Value)
            {
                MessageBox.Show("Intial count has to be lower than final count", "Generator: wrong input");
                return false;
            }
            else if (textBoxCharacterString.Text == string.Empty)
            {
                MessageBox.Show("Please define a character or string", "Generator: wrong input");
                return false;
            }
            else return true;
        }
    }
}
