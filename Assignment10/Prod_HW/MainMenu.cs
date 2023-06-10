using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HW
{
    public class Menu
    {
        public List<Menu> menu { get; set; }
        public static List<Product> Products = new List<Product>();
        public Menu PreviousPage { get; set; }
        public string PageName { get; set; }
        public virtual void Display()
        {
            Console.Clear();
            int i;
            for (i = 0; i < menu.Count; i++)
            {
                Console.WriteLine(i + " -- " + menu[i].PageName);
            }
            int choice = ReturnChoice(Console.ReadLine());

            if (choice < menu.Count())
            {
                menu[choice].Display();
            }


            Console.WriteLine("Do you want to continue: Y or N");
            char.TryParse(Console.ReadLine(), out char c);

            switch (c)
            {
                case 'y':
                case 'Y':
                    Display();
                    break;
                default:
                    break;
            }
        }
        public static double DoubleFromConsole(string placeholder)
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
        public virtual int ReturnChoice(string test)
        {
            if (string.IsNullOrEmpty(test) || string.IsNullOrWhiteSpace(test))
            {
                Console.WriteLine("Enter a correct value.");
                Display();
                return 0;
            }
            else
            {
                int.TryParse(test, out int choice);
                return choice;
            }
        }
    }
}
