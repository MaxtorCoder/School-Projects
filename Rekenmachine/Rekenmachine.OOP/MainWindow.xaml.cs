using Rekenmachine.OOP.Classes;
using System.Diagnostics;
using System.Windows;
using System;
using System.Threading;

namespace Rekenmachine.OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalcTrainer calc;
        private bool isTrainer = false;
        private CancellationTokenSource dotIndicatorTokenSource;

        public MainWindow()
        {
            InitializeComponent();
            calc = new CalcTrainer(this);

            Btn0.Click += (o, e)        => calc.AddDigit("0");
            Btn1.Click += (o, e)        => calc.AddDigit("1");
            Btn2.Click += (o, e)        => calc.AddDigit("2");
            Btn3.Click += (o, e)        => calc.AddDigit("3");
            Btn4.Click += (o, e)        => calc.AddDigit("4");
            Btn5.Click += (o, e)        => calc.AddDigit("5");
            Btn6.Click += (o, e)        => calc.AddDigit("6");
            Btn7.Click += (o, e)        => calc.AddDigit("7");
            Btn8.Click += (o, e)        => calc.AddDigit("8");
            Btn9.Click += (o, e)        => calc.AddDigit("9");
            BtnComma.Click += (o, e)    => calc.AddDigit(".");
            BtnC.Click += (o, e)        => calc.Clear();

            BtnPlus.Click += (o, e)             => calc.SetOperator("+");
            BtnMin.Click += (o, e)              => calc.SetOperator("-");
            BtnDivide.Click += (o, e)           => calc.SetOperator("/");
            BtnMultiplication.Click += (o, e)   => calc.SetOperator("x");
            BtnResult.Click += (o, e)           => calc.Result();
        }

        private void BtnRekenTrainer_Click(object sender, RoutedEventArgs e)
        {
            if (isTrainer)
            {
                BtnRekenTrainer.Content = "Reken Trainer";
                isTrainer = false;

                RekenMachine.Visibility = Visibility.Visible;
                Trainer.Visibility = Visibility.Hidden;

                calc.Timer.Stop();
                calc.Timer.Reset();
                Timer.Content = string.Empty;
            }
            else
            {
                LblScore.Content = 0;

                BtnRekenTrainer.Content = "Rekenmachine";
                isTrainer = true;

                RekenMachine.Visibility = Visibility.Hidden;
                Trainer.Visibility = Visibility.Visible;

                dotIndicatorTokenSource = new CancellationTokenSource();
                calc.Generate();

                // Start the timer.
                calc.Timer = new Stopwatch();
                calc.Timer.Start();

                Timer.Content = calc.Timer.Elapsed;
                new Thread(() =>
                {
                    while (true)
                    {
                        if (dotIndicatorTokenSource.IsCancellationRequested)
                            break;

                        Dispatcher.Invoke(() =>
                        {
                            Timer.Content = calc.Timer.Elapsed;
                        });
                        Thread.Sleep(1000);
                    }
                }).Start();
            }
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TxtBoxAnswer.Text, out int inputAnswer))
            {
                if (inputAnswer == calc.Answer)
                {
                    calc.UpdateScore();

                    LblFeedback.Content = "Correct!";
                    TxtBoxAnswer.Text = "";

                    calc.Generate();
                }
                else
                    LblFeedback.Content = "Wrong!";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dotIndicatorTokenSource != null)
                dotIndicatorTokenSource.Cancel();
        }
    }
}
