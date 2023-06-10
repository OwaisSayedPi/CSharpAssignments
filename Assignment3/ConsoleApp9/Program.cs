using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool check = false;

            while (!check)
            {
                Console.WriteLine("Enter your IP");
                string ip = Console.ReadLine();

                check = validate(ip);
            }
            Console.ReadLine();
        }        
        static Boolean validate(string check)
        {
            char[] chars = { '-',':','.' };
            string[] sepIP = check.Split(chars);
            int[] num = new int[sepIP.Length];

            for(int i = 0; i < num.Length; i++)
            {
                bool isParsable = Int32.TryParse(sepIP[i], out num[i]);
            }
            if (num[0]==192 && num[1] == 168)
            {
                Console.WriteLine("Gateway: " + sepIP[2]);
                Console.WriteLine("Your Code: " + sepIP[3]);
                return true;
            }
            else {
                Console.WriteLine("Enter a correct IP Address.");
                return false;
            }
        }
    }
}
