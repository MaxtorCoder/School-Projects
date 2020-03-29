using System;
using System.Collections.Generic;
using System.Data;

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

            var input = Console.ReadLine();
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

    public class Roman
    {
        public string NumberToRoman(int input)
        {
            if (input >= 1000) return "M"  + NumberToRoman(input - 1000);
            if (input >= 900)  return "CM" + NumberToRoman(input - 900);
            if (input >= 500)  return "D"  + NumberToRoman(input - 500);
            if (input >= 400)  return "CD" + NumberToRoman(input - 400);
            if (input >= 100)  return "C"  + NumberToRoman(input - 100);
            if (input >= 90)   return "XC" + NumberToRoman(input - 90);
            if (input >= 50)   return "L"  + NumberToRoman(input - 50);
            if (input >= 40)   return "XL" + NumberToRoman(input - 40);
            if (input >= 10)   return "X"  + NumberToRoman(input - 10);
            if (input >= 9)    return "IX" + NumberToRoman(input - 9);
            if (input >= 5)    return "V"  + NumberToRoman(input - 5);
            if (input >= 4)    return "IV" + NumberToRoman(input - 4);
            if (input >= 1)    return "I"  + NumberToRoman(input - 1);
            if (input == 0)    return string.Empty;
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
