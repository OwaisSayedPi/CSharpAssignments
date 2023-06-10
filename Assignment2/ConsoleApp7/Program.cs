using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Fname, Lname;


            bool success = false;

            while (!success)
            {
                Console.WriteLine("Enter your first name:");
                Fname = Console.ReadLine().Trim().ToLower();
                Console.WriteLine("Enter your last name:");
                Lname = Console.ReadLine().Trim().ToLower();

                success = validate(Fname);
                success = validate(Lname);

                Fname = NamingConvention(Fname);
                Lname = NamingConvention(Lname);


                displayBox(5, (Fname+" "+Lname));
            }
            Console.ReadLine();
        }
        static bool validate(string toValidate) {
            if (string.IsNullOrEmpty(toValidate) || int.TryParse(toValidate, out int _))
            {
                Console.WriteLine("Please enter correct values");
                return false;
            }
            return true;
        }
        static void displayBox(int limit, string toDisplay)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("_________________________");
            Console.Write("|\t\t\t|");
            Console.WriteLine();
            int temp = toDisplay.Length;
            Console.Write("|\t");

            Console.ForegroundColor = ConsoleColor.White;
            if (temp > limit)
            {
                for (int x = 0; x <= limit; x++)
                {
                    Console.Write(toDisplay[x]);
                }
                Console.Write("...");
            }
            else
            {
                Console.Write(toDisplay);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t|");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("|_______________________|");
        }
        static string NamingConvention(string toChange) {
            char temp;
            temp = toChange[0];
            char.ToUpper(temp);
            string tempString = temp.ToString().ToUpper();

            return string.Join(tempString, toChange.Split(temp));
        }
    }
}
