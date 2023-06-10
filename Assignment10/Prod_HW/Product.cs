using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HW
{
    public class Product
    {
        public int UID { get; set; }
        public string ModelName { get; set; }
        public int Price { get; set; }
        public string BrandName { get; set; }
        public DateTime RecordStartDate { get; set; }
        public Nullable<DateTime> RecordEndDate { get; set; }
        public override string ToString()
        {
            return UID + "\n" + BrandName + "\n" + ModelName + "\n" + Price + "\n" + RecordStartDate;
        }
    }
}
