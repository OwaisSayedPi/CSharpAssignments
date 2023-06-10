using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    public class Product
    {
        public static int UID { get; set; }
        public Product()
        {
            UID++;
        }
    }
}
