using System;
using System.Drawing;
using System.Windows.Forms;

namespace RomanNumerals.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NummerInput_TextChanged(object sender, EventArgs e)
        {
            if (NummerInput.Text == string.Empty || NummerInput.Text == "")
                return;

            if (int.TryParse(NummerInput.Text, out int input))
            {
                if (input > 4999 || input < 1)
                {
                    HelpText.Text = "Please input a new number! \nMust be between 1 - 4999";
                    HelpText.ForeColor = Color.Red;
                }
                else
                {
                    HelpText.Text = "";
                    var roman = new Roman();
                    var output = roman.NumberToRoman(input);
                    OutputRoman.Text = output;
                }
            }
        }

        private void RomanInput_TextChanged(object sender, EventArgs e)
        {
            if (RomanInput.Text == string.Empty || RomanInput.Text == "")
                return;

            var roman = new Roman();
            var output = roman.RomanToNumber(RomanInput.Text);
            if (output > 4999 || output < 1)
            {
                HelpText.Text = "Please input a new number! \nMust be between 1 - 4999";
                HelpText.ForeColor = Color.Red;
            }
            else
            {
                HelpText.Text = "";
                NummerOutput.Text = output.ToString();
            }
        }
    }
}
