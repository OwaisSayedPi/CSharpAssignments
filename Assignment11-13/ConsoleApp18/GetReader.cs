using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    public class GetReader
    {
        public static int IntFromConsole(string placeholder)
        {
            bool success = false;

            while (!success)
            {
                Console.WriteLine(placeholder);
                if (Int32.TryParse(Console.ReadLine(), out int num))
                {
                    success = true;
                    return num;
                }
                else
                {
                    Console.WriteLine("Please enter correct value.");
                    continue;
                }
            }
            return -1;
        }
        public static string StringFromConsole (string placeholder)
        {
            bool success = false;

            while (!success)
            {
                Console.WriteLine(placeholder);
                string value = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(value))
                {
                    success = true;
                    return value;
                }
                else
                {
                    Console.WriteLine("Please enter correct value.");
                    continue;
                }
            }
            return null;
        }

        internal static DateTime DateFromConsole(string placeholder)
        {
            bool success = false;

            while (!success)
            {
                Console.WriteLine(placeholder);
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    success = true;
                    return date;
                }
                else
                {
                    Console.WriteLine("Please enter correct value.");
                    continue;
                }
            }
            return DateTime.Now;
        }
    }
}
