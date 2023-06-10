using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool check = false;
            string plate="";

            while (!check)
            {
                Console.WriteLine("Enter your vehicle plate number:");
                plate = Console.ReadLine().Trim().ToUpper();

                check = validate(plate);
                if (check) { 
                    Console.WriteLine(plate);
                }
                else
                {
                    Console.WriteLine("Enter a correct number plate.");
                }
            }
            Console.ReadLine();
        }
        static Boolean validate(string check)
        {
            char[] chars = { ' ', '-' };
            string[] seperateVals = check.Split(chars);
            int[] num = new int[seperateVals.Length];
            bool[] isParsable = new bool[seperateVals.Length];

            for (int i = 0; i < num.Length; i++)
            {
                isParsable[i] = Int32.TryParse(seperateVals[i], out num[i]);
            }

            string[] stateCodes = { "MH","KA","DL","AP" };
            if (stateCodes.Contains(seperateVals[0]))
            {
                if (isParsable[1] && isParsable[3] && !isParsable[2] && num[3]<10000 && num[3] > 0 && (seperateVals[2].Length==2))
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
    }
}
