using System;
using System.Collections.Generic;

namespace InvoiceGenerator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int counter = 10983;
            Console.WriteLine(GenerateInvoice(counter+1));
            
            /*string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string day = DateTime.Now.DayOfWeek.ToString().Substring(0, 2).ToUpper();
            if (month.Length == 1)
            {
                month = '0' + month;
            }
            Console.WriteLine(month);
            Console.WriteLine(day);*/
            /*Console.WriteLine(day);
            Console.WriteLine(month);
            Console.WriteLine(year);
            Console.WriteLine(ToRomanNumeral(Convert.ToInt32(year.Substring(2))));
            Console.WriteLine(ToRomanNumeral(19));*/
        }

        static string GenerateInvoice(int counter)
        {
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string yearRoman = ToRomanNumeral(Convert.ToInt32(year.Substring(2)));
            string day = ToRomanNumeral(Convert.ToInt32(DateTime.Now.Day.ToString()));
            
            string dayWeek = DateTime.Now.DayOfWeek.ToString().Substring(0, 2).ToUpper();
            if (month.Length == 1)
            {
                /*month = '0' + month;*/
                month = month.PadLeft(2, '0');
            }
            string yearMonth = year + month;

            return $"INV/{yearMonth}/{dayWeek}/{day}/{yearRoman}/{counter}";
        }

        static List<string> romanNumerals = new List<string>() { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        static List<int> numerals = new List<int>() { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        static string ToRomanNumeral(int number)
        {
            var romanNumeral = string.Empty;
            while (number > 0)
            {
                var index = numerals.FindIndex(x => x <= number);
                number -= numerals[index];
                romanNumeral += romanNumerals[index];
            }
            return romanNumeral;
        }
    }
}
