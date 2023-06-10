using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int limit = GetInt("Enter a limit:");

                int[] Numbers = input(limit);
                displayNumbers(Numbers);

                int choice = 0;
                Console.Write("Choose:\n");
                Console.Write("1. Show Largest Number.\n");
                Console.Write("2. Show Smallest Number.\n");
                Console.Write("3. Calculate Sum.\n");
                Console.Write("4. Calculate Average.\n");
                Console.Write("5. Show Successive Pairs.\n");
                choice = GetInt("Select Your Option");

                Loading(500);
                menu(choice, Numbers);
                Console.ReadLine();
                Console.Clear();
            }
            Console.ReadLine();
        }
        static int[] input(int limit)
        {
            int[] Numbers = new int[limit];
            for (int i = 0; i < Numbers.Length; i++)
            {
                Numbers[i] = GetInt("Enter Number " + (i + 1) + ":");
            }
            return Numbers;
        }
        static void displayNumbers(int[] number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (i%10==1 && i!=11)
                {
                    Console.WriteLine((i) + "st Number:" + number[i]);
                }
                else if (i % 10 == 2)
                {
                    Console.WriteLine((i) + "nd Number:" + number[i]);
                }
                else if (i % 10 == 3)
                {
                    Console.WriteLine((i) + "rd Number:" + number[i]);
                }
                else
                {
                    Console.WriteLine((i) + "th Number:" + number[i]);
                }
            }
        }
        static void menu(int choice, int[] Numbers)
        {
            switch (choice)
            {
                default:
                    Console.Write("Choose Again");
                    break;
                case 1:
                    Console.Write("Largest number is: " + Numbers.Max() + "\n");
                    break;
                case 2:
                    Console.Write("Smallest number is: " + Numbers.Min() + "\n");
                    break;
                case 3:
                    Console.Write("Smallest number is: " + Numbers.Sum() + "\n");
                    break;
                case 4:
                    Console.Write("Smallest number is: " + Numbers.Average() + "\n");
                    break;
                case 5:
                    Console.Write("Successive Pair(s): \n");
                    for (int i = 0; i < Numbers.Length-1; i++)
                    {
                        if ((Numbers[i] + 1) == Numbers[i + 1])
                        {
                            Console.Write(Numbers[i] + " & " + Numbers[i + 1] + "\n");
                        }
                        else
                        {
                            continue;
                        }
                    }
                    break;
            }
        }
        public static void Loading(int time)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("LOADING");
            Thread.Sleep(time);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(".");
            Thread.Sleep(time);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(".");
            Thread.Sleep(time);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(".");
            Thread.Sleep(time);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(".");
            Thread.Sleep(time);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }
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
    }
}
