using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals
{
    public class Roman
    {
        public static Dictionary<int, string> RomanNumerals = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 500,  "D" },
            { 100,  "C" },
            { 50,   "L" },
            { 10,   "X" },
            { 5,    "V" },
            { 1,    "I" },
        };
        public static Dictionary<int, string> RomanNumeralRules = new Dictionary<int, string>
        {
            { 900,  "CM" },
            { 400,  "CD" },
            { 90,   "XC" },
            { 40,   "XL" },
            { 9,    "IX" },
            { 4,    "IV" },
        };

        public string NumberToRoman(int input)
        {
            var returnString = string.Empty;
            while (input > 0)
            {
                foreach (var romanNumeral in RomanNumerals)
                {
                    if (RomanNumeralRules.ContainsKey(input))
                    {
                        returnString += RomanNumeralRules[input];
                        input -= input;
                        break;
                    }
                    else if (input >= romanNumeral.Key)
                    {
                        input -= romanNumeral.Key;
                        returnString += romanNumeral.Value;
                        break;
                    }
                }
            }

            return returnString;
        }

        public int RomanToNumber(string input)
        {
            var result = 0;

            foreach (var character in input)
            {
                var index = input.IndexOf(character);

                if ((index + 1) >= input.Length)
                    break;

                var romanString = $"{character}{input[index + 1]}";
                var romanNumeral = 0;

                if (RomanNumeralRules.ContainsValue(romanString))
                    romanNumeral = RomanNumeralRules.FirstOrDefault(x => x.Value == romanString).Key;
                else
                    romanNumeral = RomanNumerals.FirstOrDefault(x => x.Value == character.ToString()).Key;

                result += romanNumeral;
            }

            return result;
        }
    }
}
