using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Rekenmachine.OOP.Classes
{
    public class CalcTrainer : Calculator
    {
        private MainWindow mainWindow;
        private int Score = 0;
        private Random R1, R2, Operator;

        public int Answer = 0;
        public Stopwatch Timer;

        public CalcTrainer(MainWindow window) : base(window)
        {
            mainWindow = window;

            R1          = new Random();
            R2          = new Random();
            Operator    = new Random();
        }

        public void UpdateScore()
        {
            Score++;
            mainWindow.LblScore.Content = Score;
        }

        public void Generate()
        {
            var sum1 = R1.Next(0, 100).ToString();
            var sum2 = R2.Next(0, 100).ToString();

            mainWindow.LblSum1.Content = sum1;
            mainWindow.LblSum2.Content = sum2;

            var _operator = Operator.Next(0, 2);
            switch (_operator)
            {
                case 0:
                    mainWindow.LblOperator.Content = "+";
                    break;
                case 1:
                    mainWindow.LblOperator.Content = "-";
                    break;
                case 2:
                    mainWindow.LblOperator.Content = "*";
                    break;
                default:
                    break;
            }

            var sumString = $"{sum1}{mainWindow.LblOperator.Content}{sum2}";
            Answer = int.Parse(new DataTable().Compute(sumString, null).ToString());
        }
    }
}
