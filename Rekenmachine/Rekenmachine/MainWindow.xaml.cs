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
        private bool hasResult = false;
        private bool isTrainer = false;

        private int Score = 0;
        private int answer = 0;

        private Random R1, R2, Operator;

        public MainWindow()
        {
            InitializeComponent();

            R1 = new Random();
            R2 = new Random();
            Operator = new Random();

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
        }

        private void BtnRekenTrainer_Click(object sender, RoutedEventArgs e)
        {
            if (isTrainer)
            {
                BtnRekenTrainer.Content = "Reken Trainer";
                isTrainer = false;

                RekenMachine.Visibility = Visibility.Visible;
                Trainer.Visibility = Visibility.Hidden;
            }
            else
            {
                LblScore.Content = 0;

                BtnRekenTrainer.Content = "Rekenmachine";
                isTrainer = true;

                RekenMachine.Visibility = Visibility.Hidden;
                Trainer.Visibility = Visibility.Visible;

                Generate();
            }
        }

        private void Generate()
        {
            var sum1 = R1.Next(0, 100).ToString();
            var sum2 = R2.Next(0, 100).ToString();

            LblSum1.Content = sum1;
            LblSum2.Content = sum2;

            var _operator = Operator.Next(0, 2);
            switch (_operator)
            {
                case 0:
                    LblOperator.Content = "+";
                    break;
                case 1:
                    LblOperator.Content = "-";
                    break;
                case 2:
                    LblOperator.Content = "*";
                    break;
                default:
                    break;
            }

            var sumString = $"{sum1}{LblOperator.Content}{sum2}";
            answer = int.Parse(new DataTable().Compute(sumString, null).ToString());
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TxtBoxAnswer.Text, out int inputAnswer))
            {
                if (inputAnswer == answer)
                {
                    UpdateScore();

                    LblFeedback.Content = "Correct!";
                    TxtBoxAnswer.Text = "";

                    Generate();
                }
                else
                    LblFeedback.Content = "Wrong!";
            }
        }

        private void UpdateScore()
        {
            Score++;
            LblScore.Content = Score;
        }
    }
}
