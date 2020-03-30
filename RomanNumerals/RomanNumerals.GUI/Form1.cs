using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            RomanInput.Text = RomanInput.Text.ToUpper();
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

    public class Roman
    {
        public string NumberToRoman(int input)
        {
            if (input >= 1000) return "M" + NumberToRoman(input - 1000);
            if (input >= 900) return "CM" + NumberToRoman(input - 900);
            if (input >= 500) return "D" + NumberToRoman(input - 500);
            if (input >= 400) return "CD" + NumberToRoman(input - 400);
            if (input >= 100) return "C" + NumberToRoman(input - 100);
            if (input >= 90) return "XC" + NumberToRoman(input - 90);
            if (input >= 50) return "L" + NumberToRoman(input - 50);
            if (input >= 40) return "XL" + NumberToRoman(input - 40);
            if (input >= 10) return "X" + NumberToRoman(input - 10);
            if (input >= 9) return "IX" + NumberToRoman(input - 9);
            if (input >= 5) return "V" + NumberToRoman(input - 5);
            if (input >= 4) return "IV" + NumberToRoman(input - 4);
            if (input >= 1) return "I" + NumberToRoman(input - 1);
            if (input == 0) return string.Empty;
            throw new ArgumentException("Please input a number in between 1 - 4999");
        }

        public int RomanToNumber(string input)
        {
            var result = 0;

            // Convert any hidden cases to the correct roman numerals.
            input = input.Replace("CM", "DCCCC");
            input = input.Replace("CD", "CCCC");
            input = input.Replace("XC", "LXXXX");
            input = input.Replace("XL", "XXXX");
            input = input.Replace("IX", "VIIII");
            input = input.Replace("IV", "IIII");

            foreach (var character in input)
            {
                if (character == 'I') result += 1;
                if (character == 'V') result += 5;
                if (character == 'X') result += 10;
                if (character == 'L') result += 50;
                if (character == 'C') result += 100;
                if (character == 'D') result += 500;
                if (character == 'M') result += 1000;
            }

            return result;
        }
    }
}
