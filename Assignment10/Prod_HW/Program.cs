using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HW
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Home home = new Home(null);
            home.Display();

            Console.ReadLine();
        }
    }
}
