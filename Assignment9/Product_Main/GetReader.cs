using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    public class GetReader
    {
        public static int GetInt(string placeholder)
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
        public static DateTime GetDate(string placeholder)
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
