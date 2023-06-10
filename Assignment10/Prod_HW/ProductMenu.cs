using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HW
{
    
    public class AddProd : Menu
    {
        public AddProd(Menu PreviousPage)
        {
            this.PreviousPage = PreviousPage;
            PageName = "Add Product";
        }
        public override void Display()
        {
            Operation ops = new Operation();
            ops.AddProduct("Smasung", "Galaxy", 25000);
            ops.AddProduct("Smasung", "A-Series", 35000);
            Console.WriteLine("2 Products Added");
        }
    }
    public class DelProd : Menu
    {
        public DelProd(Menu PreviousPage)
        {
            this.PreviousPage = PreviousPage;
            PageName = "Delete Product";
        }
        public override void Display()
        {
            Operation ops = new Operation();
            ops.DelProduct();
        }
    }
    public class UpdateProd : Menu
    {
        public UpdateProd(Menu PreviousPage)
        {
            this.PreviousPage = PreviousPage;
            PageName = "Update Product";
        }
        public override void Display()
        {
            Operation ops = new Operation();
            ops.EditProduct();
        }
    }
    public class ViewAllProd : Menu
    {
        public ViewAllProd(Menu PreviousPage)
        {
            this.PreviousPage = PreviousPage;
            PageName = "View All Products";
        }
        public override void Display()
        {
            Operation ops = new Operation();
            ops.DisplayProduct();
        }
    }
    public class ShowHistory : Menu
    {
        public ShowHistory(Menu PreviousPage)
        {
            this.PreviousPage = PreviousPage;
            PageName = "Show History";
        }
        public override void Display()
        {
            Operation ops = new Operation();
            ops.ShowHistory();
        }
    }
}
