using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Main
{
    internal class Program
    {
        List<Product> products = new List<Product>();
        Product Product = new Product();
        static void Main(string[] args)
        {
            Operation ops = new Operation();

            List<Specification> specs = new List<Specification>();
            Specification specification = new Specification();
            specification.Name = "Ram";
            specification.Value = "8GB";
            specs.Add(specification);

            Category category = new Category();
            List<Category> categories = new List<Category>();
            category.Name = "Health";
            categories.Add(category);

            ops.AddProduct("Samsung","Galaxy",25000,59,DateTime.Today,categories,specs,Popularity.High);

            ops.AddProduct("Samsung", "A-Series", 35000, 99, DateTime.Today, categories, specs, Popularity.Low);

            while (true)
            {
                int choice = Menu();

                switch (choice)
                {
                    case 1:
                        ops.AddProduct();
                        break;
                    case 2:
                        ops.DisplayProduct();
                        break;
                    case 3:
                        Console.WriteLine("Enter 0 for High");
                        Console.WriteLine("Enter 1 for Medium");
                        Console.WriteLine("Enter 2 for Low");
                        Popularity.TryParse(Console.ReadLine(), out Popularity value);
                        ops.SearchProduct(value);
                        break;
                    case 4:
                        Console.WriteLine("Enter Price of the product to search:");
                        int.TryParse(Console.ReadLine(), out int num);
                        ops.SearchProduct(num);
                        break;
                    case 5:
                        Console.WriteLine("Enter Brand to search:");
                        ops.SearchProduct(Console.ReadLine());
                        break;
                    case 6:
                        Console.WriteLine("Enter Stock Quantity of the product to search:");
                        int.TryParse(Console.ReadLine(), out int stock);
                        ops.SearchProduct(stock);
                        break;
                    case 7:
                        ops.ExportToExcel();
                        break;
                    case 8:
                        ops.ImportFromExcel(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\Product.xlsx","Product");
                        break;
                    case 9:                        
                        //ops.ImportFromExcel();
                        break;


                    default:
                        break;
                }
                Console.Clear();
            }            
        }
        static int Menu()
        {
            Console.WriteLine("1. Add Product.");
            Console.WriteLine("2. View Product.");
            Console.WriteLine("3. Search By Popularity.");
            Console.WriteLine("4. Search By Price.");
            Console.WriteLine("5. Search By Brand.");
            Console.WriteLine("6. Search By Stock Quantity.");
            Console.WriteLine("7. Export to Excel.");
            Console.WriteLine("8. Import to Excel.");
            Console.WriteLine("9. Show Products Expiring This Month.");
            int.TryParse(Console.ReadLine(), out int choice);
            return choice;
        }

        
        
        public List<Product> ValueFromUser()
        {
            List<Product> products = new List<Product>();
            Product product = new Product();

            return products;
        }
    }
}
