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
    public partial class ucStringGenerator : UserControl
    {
        public ucStringGenerator()
        {
            InitializeComponent();
        }

        private void ucStringGenerator_Load(object sender, EventArgs e)
        {
            comboBoxEncoding.SelectedIndex = 0;
        }

        public StringGenerator GetGenerator()
        {
            StringGenerator stringGenerator = new StringGenerator();
            stringGenerator.Name = textBoxName.Text;
            stringGenerator.Encoding = GeneratorEncoding.GetEncoding(comboBoxEncoding.SelectedIndex);
            stringGenerator.StringLength = Convert.ToInt32(numericUpDownStringLength.Value);
            stringGenerator.CharacterSet = textBoxCharacterSet.Text;
            stringGenerator.AllowRepetitions = checkBoxAllowRepetitions.Checked;

            return stringGenerator;
        }

        public void LoadGenerator(StringGenerator Generator)
        {
            textBoxName.Text = Generator.Name;
            comboBoxEncoding.SelectedIndex = GeneratorEncoding.ReturnEncodingIndex(Generator.Encoding);
            textBoxCharacterSet.Text = Generator.CharacterSet;
            numericUpDownStringLength.Value = Convert.ToDecimal(Generator.StringLength);
            checkBoxAllowRepetitions.Checked = Generator.AllowRepetitions;
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
                MessageBox.Show("Please define a chracter set", "Generator: wrong input");
                return false;
            }
            else if (checkBoxAllowRepetitions.Checked == false && (Convert.ToInt32(numericUpDownStringLength.Value) > textBoxCharacterSet.Text.Length))
            {
                    MessageBox.Show("The quantity of the character set has to be higher then the string length if you do not allow repetitions", "Generator: wrong input");
                    return false;
            }
            else if (checkBoxAllowRepetitions.Checked == false && NoRepititionCount() > 10000)
            {
                MessageBox.Show("Please reduce the character set or the string length, in order to be under 10000 requests", "Generator: too much requests");
                return false;
            }
            else if (checkBoxAllowRepetitions.Checked == true && RepititionCount() > 10000)
            {
                MessageBox.Show("Please reduce the character set or the string length, in order to be under 10000 requests", "Generator: too much requests");
                return false;
            }

            else return true;
        }

        private void buttonGeneratePreview_Click(object sender, EventArgs e)
        {
            if (checkBoxAllowRepetitions.Checked)
            {
                 textBoxPreview.Text = NoRepititionCount().ToString();
            }
            else
            {
                textBoxPreview.Text = RepititionCount().ToString();
            }
        }

        private double RepititionCount()
        {
            double count = 1;
            try
            {
                for (double i =(Convert.ToDouble( textBoxCharacterSet.Text.Length + 1)- Convert.ToDouble(numericUpDownStringLength.Value)); i < (Convert.ToDouble(textBoxCharacterSet.Text.Length + 1)); i++)
                {
                    count *= i;
                }
                return count;
            }
            catch (Exception)
            {
                double a = 10001;
                return a;
            }
        }

        private double NoRepititionCount()
        {
            double count = 0;
            try
            {
                count = Math.Pow(Convert.ToDouble(textBoxCharacterSet.Text.Length), Convert.ToDouble(numericUpDownStringLength.Value));
                return count;
            }
            catch (Exception)
            {
                double a = 10001;
                return a;
            }
        }
    }
}
