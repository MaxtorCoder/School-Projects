using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Rekenmachine.OOP.Classes
{
    public class Calculator
    {
        private MainWindow mainWindow;

        private List<string> calculations = new List<string>(capacity: 10);
        private string calcOperator = string.Empty;
        private int digitIndex = 0;

        private bool hasResult = false;

        public Calculator(MainWindow window)
        {
            mainWindow = window;

            // Hackfix for null reference crash
            for (var i = 0; i < 10; i++)
                calculations.Add(string.Empty);
        }

        public void AddDigit(string num) 
        {
            if (hasResult)
                Clear();

            mainWindow.ResultBox.Text += num;
            calculations[digitIndex] += num;
        }

        public void SetOperator(string _operator)
        {
            mainWindow.ResultBox.Text = "";
            mainWindow.TotalBox.Text += $"{calculations[digitIndex]} {_operator}";

            calcOperator = _operator;

            if (_operator == "x")
                calcOperator = "*";

            digitIndex++;
        }

        public void Clear()
        {
            hasResult = false;
            mainWindow.ResultBox.Text = "";
            mainWindow.TotalBox.Text = "";

            // Reset values
            for (var i = 0; i < 10; i++)
                calculations[i] = string.Empty;

            digitIndex = 0;
        }

        public void Result()
        {
            mainWindow.TotalBox.Text += $" {calculations[digitIndex]}";

            var result = string.Empty;
            for (var i = 0; i <= digitIndex; i++)
            {
                if (calculations[i] == string.Empty)
                    calculations[i] = "0";

                result += $"{calculations[i]} ";

                if (i != digitIndex)
                    result += $"{calcOperator} ";
            }

            mainWindow.ResultBox.Text = new DataTable().Compute(result, null).ToString();
            hasResult = true;
        }
    }
}
