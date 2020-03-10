using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rekenmachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> calculations = new List<string>(capacity: 10);
        private string calcOperator = string.Empty;

        private int digitIndex = 0;
        private int operatorIndex = 0;
        private bool hasResult = false;

        public MainWindow()
        {
            InitializeComponent();

            Btn0.Click += (o, e) => AddDigit("0");
            Btn1.Click += (o, e) => AddDigit("1");
            Btn2.Click += (o, e) => AddDigit("2");
            Btn3.Click += (o, e) => AddDigit("3");
            Btn4.Click += (o, e) => AddDigit("4");
            Btn5.Click += (o, e) => AddDigit("5");
            Btn6.Click += (o, e) => AddDigit("6");
            Btn7.Click += (o, e) => AddDigit("7");
            Btn8.Click += (o, e) => AddDigit("8");
            Btn9.Click += (o, e) => AddDigit("9");
            BtnC.Click += (o, e) => Clear();

            BtnPlus.Click += (o, e)             => SetOperator("+");
            BtnMin.Click += (o, e)              => SetOperator("-");
            BtnDivide.Click += (o, e)           => SetOperator("/");
            BtnMultiplication.Click += (o, e)   => SetOperator("x");
            BtnResult.Click += (o, e)           => Result();

            // Hackfix for null reference crash
            for (var i = 0; i < 10; i++)
                calculations.Add(string.Empty);
        }

        private void AddDigit(string num)
        {
            if (hasResult)
                Clear();

            ResultBox.Text += num;
            calculations[digitIndex] += num;
        }

        private void SetOperator(string operator_)
        {
            ResultBox.Text = "";
            TotalBox.Text += $"{calculations[digitIndex]} {operator_}";

            calcOperator = operator_;

            if (operator_ == "x")
                calcOperator = "*";

            digitIndex++;
        }

        private void Result()
        {
            TotalBox.Text += $" {calculations[digitIndex]}";

            var result = string.Empty;
            for (var i = 0; i <= digitIndex; i++)
            {
                if (calculations[i] == string.Empty)
                    calculations[i] = "0";

                result += $"{calculations[i]} ";

                if (i != digitIndex)
                    result += $"{calcOperator} ";
            }

            ResultBox.Text = new DataTable().Compute(result, null).ToString();
            hasResult = true;
        }

        private void Clear()
        {
            hasResult = false;
            ResultBox.Text = "";
            TotalBox.Text = "";

            // Reset values
            for (var i = 0; i < 10; i++)
                calculations[i] = string.Empty;

            digitIndex = 0;
            operatorIndex = 0;
        }
    }
}
