using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_HW
{
    public class Operation:Menu
    {
        public void EditProduct()
        {
            Product Product = new Product();

            Console.WriteLine("Enter UID to Edit.");
            if (int.TryParse(Console.ReadLine(), out int checkUID) && checkUID <= Menu.Products.Count-1)
            {
                //foreach (int itemUID in Menu.Products.Select(x => x.UID).Where(x => x == checkUID))
                
                for (int i = 0; i < Menu.Products.Count; i++)
                {
                    if (checkUID == Menu.Products[i].UID)
                    {
                        Menu.Products[i].UID = -1;
                        Menu.Products[i].RecordEndDate = DateTime.Now;
                        AddProduct(checkUID);
                        break;
                    }
                }
            }            
        }
        public void DelProduct()
        {
            Product Product = new Product();

            Console.WriteLine("Enter UID to Delete.");
            if (int.TryParse(Console.ReadLine(), out int checkUID) && checkUID <= Menu.Products.Count-1)
            {
                //foreach (int itemUID in Menu.Products.Select(x => x.UID).Where(x => x == checkUID))
                
                for (int i = 0; i < Menu.Products.Count; i++)
                {
                    if (checkUID == Menu.Products[i].UID)
                    {
                        Menu.Products[i].UID = -2;
                        Menu.Products[i].RecordEndDate = DateTime.Now;
                        break;
                    }
                }
            }            
        }
        public void AddProduct(int OldUID)
        {
            Product Product = new Product();
            Product.BrandName = GetReader.StringFromConsole("Enter Brand name:");
            Product.ModelName = GetReader.StringFromConsole("Enter Model name:");
            Product.Price = GetReader.IntFromConsole("Enter price:");
            Product.UID = OldUID;
            Product.RecordStartDate = DateTime.Now;

            Console.WriteLine("Confirm Product Edit: Y or N");
            if (Console.ReadLine() == "Y" || Console.ReadLine() == "y")
            {
                Menu.Products.Add(Product);
                Console.WriteLine("1 Product Updated.");
            }
            else if (Console.ReadLine() == "N" || Console.ReadLine() == "n")
            {
                Console.WriteLine("No Product Added.");
            }
        }
        public void AddProduct()
        {
            Product Product = new Product();
            Product.BrandName = GetReader.StringFromConsole("Enter Brand name:");
            Product.ModelName = GetReader.StringFromConsole("Enter Model name:");
            Product.Price = GetReader.IntFromConsole("Enter price:");
            Product.UID = Menu.Products.Count+1;
            Product.RecordStartDate = DateTime.Now;

            Console.WriteLine("Do you want to add this Product: Y or N");
            if (Console.ReadLine() == "Y" || Console.ReadLine() == "y")
            {
                Menu.Products.Add(Product);
                Console.WriteLine("1 Product Added.");
            }
            else if (Console.ReadLine()=="N"||Console.ReadLine()=="n")
            {
                Console.WriteLine("No Product Added.");
            }
        }
        public void AddProduct(string brand, string model, int price)
        {
            Product Product = new Product();
            Product.BrandName = brand;
            Product.ModelName = model;
            Product.Price = price;
            Product.UID = Menu.Products.Count + 1;
            Product.RecordStartDate = DateTime.Now;

            Menu.Products.Add(Product);
        }
        
        public void DisplayProduct(){
            foreach (Product item in Menu.Products.Select(x => x).Where(x => x.UID > 0).OrderBy(x => x.UID).ToList<Product>())
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        public void ShowHistory(){
            foreach (Product item in Menu.Products.Select(x => x).OrderBy(x => x.BrandName).ToList<Product>())
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
    }
}
