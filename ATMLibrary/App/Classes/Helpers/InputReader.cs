using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMLibrary.App.Classes
{
    static class InputReader
    {
        public static string ReadInputString() => Console.ReadLine() ?? string.Empty;
        public static int ReadInputInt()
        {
            int input = 0;
            int.TryParse(Console.ReadLine(), out input);
            return input;
        }
        public static decimal ReadInputDecimal()
        {
            decimal input = 0m;
            bool success = decimal.TryParse(Console.ReadLine(), out input);
            if (success == true)
            {
                return input;
            }
            else
            {
                return decimal.MinValue;
            }
        }
    }
}