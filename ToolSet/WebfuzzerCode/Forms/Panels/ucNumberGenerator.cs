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
    public partial class ucNumberGenerator : UserControl
    {
        public ucNumberGenerator()
        {
            InitializeComponent();
        }

        private void ucNumberGenerator_Load(object sender, EventArgs e)
        {
            comboBoxEncoding.SelectedIndex = 0;
        }

        public NumberGenerator GetGenerator()
        {
            NumberGenerator numberGenerator = new NumberGenerator();
            numberGenerator.Name = textBoxName.Text;
            numberGenerator.Encoding = GeneratorEncoding.GetEncoding(comboBoxEncoding.SelectedIndex);
            numberGenerator.Increment = Convert.ToInt32(numericUpDownIncrement.Value);
            numberGenerator.StartNumber = Convert.ToInt32(numericUpDownStartNumber.Value);
            numberGenerator.StopNumber = Convert.ToInt32(numericUpDownStopNumber.Value);

            return numberGenerator;
        }

        public void LoadGenerator(NumberGenerator Generator)
        {
            textBoxName.Text = Generator.Name;
            comboBoxEncoding.SelectedIndex = GeneratorEncoding.ReturnEncodingIndex(Generator.Encoding);
            numericUpDownIncrement.Value = Convert.ToDecimal(Generator.Increment);
            numericUpDownStartNumber.Value = Convert.ToDecimal(Generator.StartNumber);
            numericUpDownStopNumber.Value = Convert.ToDecimal(Generator.StopNumber);
        }

        public bool FieldsValid()
        {
            if (textBoxName.Text == string.Empty)
            {
                MessageBox.Show("Please type in the name of the Generator", "Generator: wrong input");
                return false;
            }
            else if (numericUpDownStartNumber.Value >= numericUpDownStopNumber.Value)
            {
                MessageBox.Show("The start number has to be lower than the stop number", "Generator: wrong input");
                return false;
            }
            else return true;
        }
    }
}
