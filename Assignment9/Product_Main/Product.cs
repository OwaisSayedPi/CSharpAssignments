using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Main
{
    internal class Product
    {
        private string _brand;
        public string Model { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime MfgDate { get; set; }
        public List<Category> Categories { get; set; }
        public List<Specification> Specifications { get; set; }
        public Popularity popularity { get; set; }
        private DateTime _expDate;
        public string Brand
        {
            get { return _brand; }
            set
            {
                if (value.Contains("Samsung"))
                {
                    _brand = value;
                }
            }
        }
        public string GetCategories
        {
            get { 
                string categoryName = "";
                foreach (Category item in Categories)
                {
                    if (item == Categories.Last())
                    {
                        categoryName += item.Name + ",";
                    }
                    else
                    {
                        categoryName += item.Name + ",";
                    }
                }
                return categoryName;
            }
        }
        public string GetSpecifications
        {
            get
            {
                string Specs = "";
                foreach (Specification item in Specifications)
                {
                    if (item == Specifications.Last())
                    {
                        Specs += item;
                    }
                    else
                    {
                        Specs += item + ",";
                    }
                }
                return Specs;
            }
        }     
        public DateTime ExpDate
        {
            get { return _expDate; }
            set { _expDate = MfgDate.AddYears(5); }
        }

        public override string ToString()
        {
            return Brand + "\n" + Model + "\n" + Price;
        }
    }
}
