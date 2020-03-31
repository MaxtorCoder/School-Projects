using System;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("You have 2 options to convert:\n  (1) Roman -> Number\n  (2) Number -> Roman\n");
                Console.Write("Please specify what you want to convert: ");

                var input = int.Parse(Console.ReadLine());
                if (input == 1) ConvertToNumber();
                else if (input == 2) ConvertToRoman();
            }
        }

        static void ConvertToRoman()
        {
            Console.Clear();
            Console.Write("Please input a number to convert to roman: ");

            var input = int.Parse(Console.ReadLine());
            if (input > 4999)
                throw new Exception("The input is too high! Please input a number under 4999");
            else if (input < 1)
                throw new Exception("The input is too low! Please input a number higher than 0");

            var roman = new Roman();
            Console.WriteLine($"Output: {roman.NumberToRoman(input)}");
            Console.ReadKey();
        }
        
        static void ConvertToNumber()
        {
            Console.Clear();
            Console.Write("Please input a roman numeral to convert to an integer: ");

            var input = Console.ReadLine().ToUpper();
            var roman = new Roman();

            var output = roman.RomanToNumber(input);
            if (output > 4999)
                throw new Exception("The input is too high! Please input a number under 4999");
            else if (output < 1)
                throw new Exception("The input is too low! Please input a number higher than 0");

            Console.WriteLine($"Output: {output}");
            Console.ReadKey();
        }
    }
}
