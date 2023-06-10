using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Limit");
            int limit = int.Parse(Console.ReadLine());

            for (int i = 0; i <= limit; i++)
            {
                if (i%2!=0)
                {
                    Console.Write(i + "\t");
                }
            }
            Console.WriteLine();
            Console.WriteLine(limit / 2);
            Console.ReadLine();
        }
    }
}
