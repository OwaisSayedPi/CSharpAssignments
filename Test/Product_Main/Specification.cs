using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Main
{
    internal class Specification
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Name + ":" + Value;
        }
    }
}
