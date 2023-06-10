using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;

namespace Product_Main
{
    internal class Operation
    {
        List<Product> products = new List<Product>();
        
        public void AddProduct()
        {
            Product Product = new Product();
            Product.Brand = GetString("Enter Brand name:");
            Product.Model = GetString("Enter Model name:");
            Product.Price = ConsoleToAskInt("Enter price:");
            Product.StockQuantity = ConsoleToAskInt("Enter stock quantity:");
            Product.MfgDate = GetDate("Enter Manufacturing date:");
            Product.Categories = ConsoletoAskCategory("Enter category ");
            Product.Specifications = ConsoletoGetSpecs("Enter specifications in key value pairs, separated by return key.");
            Product.popularity = ConsoleGetPopularity("Enter\n0 for Low Rating\n1 for Midium\n2 for High");

            Console.WriteLine("Do you want to add this Product: Y or N");
            if (Console.ReadLine() == "Y" || Console.ReadLine() == "y")
            {
                products.Add(Product);
                Console.WriteLine("1 Product Added.");
            }
            else if (Console.ReadLine()=="N"||Console.ReadLine()=="n")
            {
                Console.WriteLine("No Product Added.");
            }
        }
        public void AddProduct(string brand, string model, int price, int stockquantity, DateTime mfgdate, List<Category> category, List<Specification> specification, Popularity popularity)
        {
            Product Product = new Product();
            Product.Brand = brand;
            Product.Model = model;
            Product.Price = price;
            Product.StockQuantity = stockquantity;
            Product.MfgDate = mfgdate;
            Product.Categories = category;
            Product.Specifications = specification;
            Product.popularity = popularity;

            products.Add(Product);
        }
        public void SearchProduct(Popularity value)
        {            
            DisplayProduct(value);
        }
        public void SearchProduct(int value)
        {            
            DisplayProduct(value);
        }
        public void SearchProduct(string value)
        {            
            DisplayProduct(value);
        }
        public void SearchProduct(DateTime value)
        {
            DisplayProduct(value);
        }
        public void ImportFromExcel(string excelfilepath, string sheetName)
        {
            Type typeOfObject = typeof(Product);
            using (IXLWorkbook workbook = new XLWorkbook(excelfilepath))
            {
                var worksheet = workbook.Worksheets.Where( x => x.Name == sheetName).First();
                var properties = typeOfObject.GetProperties();

                var LastRow = worksheet.Column(1).LastCellUsed().Address.RowNumber;
                for (int row = 2; row <= LastRow; row++)
                {
                    Product product = new Product();
                    product.Brand = worksheet.Cell(row, 1).Value.ToString();
                    product.Model = worksheet.Cell(row, 2).Value.ToString();
                    product.Price = Convert.ToInt32(worksheet.Cell(row, 3).Value);
                    product.StockQuantity = Convert.ToInt32(worksheet.Cell(row, 4).Value);
                    product.MfgDate = DateTime.Parse(worksheet.Cell(row, 5).Value.ToString());
                    string[] category = worksheet.Cell(row, 6).Value.ToString().Split(',');
                    
                    List<Category> value = new List<Category>();
                    foreach (var item in category)
                    {
                        Category c = new Category();
                        c.Name = item;
                        value.Add(c);
                    }
                    product.Categories = value;

                    string[] specs = worksheet.Cell(row, 7).Value.ToString().Split(',');
                    List<Specification> spec = new List<Specification>();
                    foreach (var item in specs)
                    {
                        Specification c = new Specification();
                        c.Name = item.Split(':')[0];
                        c.Value = item.Split(':')[1];
                        spec.Add(c);
                    }
                    product.Specifications = spec;
                    product.popularity = (Popularity)int.Parse(worksheet.Cell(row, 8).Value.ToString());


                    products.Add(product);
                }
            }
            Console.WriteLine("Exported Data Successfully.");
        }
        public void ExportToExcel()
        {
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filepath = Path.Combine(filepath, "Product.xlsx");

            Export(products, filepath, "Product");
            Console.WriteLine("Exported Data Successfully.");
            Console.ReadLine();
        }

        //Generate The Data table
        public bool Export(List<Product> list, string Filepath, string SheetName)
        {
            bool Exported = false;
            using (IXLWorkbook workbook = new XLWorkbook())
            {
                var ws = workbook.AddWorksheet(SheetName);
                ws.Cell(1, 1).Value = "Brand";
                ws.Cell(1, 2).Value = "Model";
                ws.Cell(1, 3).Value = "Price";
                ws.Cell(1, 4).Value = "StockQuantity";
                ws.Cell(1, 5).Value = "MfgDate";
                ws.Cell(1, 6).Value = "Categories";
                ws.Cell(1, 7).Value = "Specifications";
                ws.Cell(1, 8).Value = "Popularity";

                for (int i = 1; i <= list.Count; i++)
                {
                    Product product = list[i-1];
                    ws.Cell(i + 1, 1).Value = product.Brand;
                    ws.Cell(i + 1, 2).Value = product.Model;
                    ws.Cell(i + 1, 3).Value = product.Price;
                    ws.Cell(i + 1, 4).Value = product.StockQuantity;
                    ws.Cell(i + 1, 5).Value = product.MfgDate;
                    ws.Cell(i + 1, 6).Value = product.GetCategories;
                    ws.Cell(i + 1, 7).Value = product.GetSpecifications;
                    int pop = (int)product.popularity;
                    ws.Cell(i + 1, 8).Value = pop;
                }
                workbook.SaveAs(Filepath);
                Exported = true;
            }
            return Exported;
        }
        public void DisplayProduct(){
            int i;
            for (i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i]);
            }
            Console.ReadLine();
        }
        public void DisplayProduct(Popularity value)
        {
            int i;
            for (i = 0; i < products.Count; i++)
            {
                if (products[i].popularity == value)
                {
                    Console.WriteLine(products[i]);
                }
            }
            Console.ReadLine();
        }
        public void DisplayProduct(int value)
        {
            int i;
            for (i = 0; i < products.Count; i++)
            {
                if (products[i].Price == value || products[i].StockQuantity == value)
                {
                    Console.WriteLine(products[i]);
                }
            }
            Console.ReadLine();
        }
        public void DisplayProduct(string value)
        {
            int i;
            for (i = 0; i < products.Count; i++)
            {
                if (products[i].Brand == value)
                {
                    Console.WriteLine(products[i]);
                }
            }
            Console.ReadLine();
        }
        public void DisplayProduct(DateTime value)
        {
            int i;
            for (i = 0; i < products.Count; i++)
            {
                if (products[i].ExpDate.Year == value.Year)
                {
                    Console.WriteLine(products[i]);
                }
            }
            Console.ReadLine();
        }
        public Popularity ConsoleGetPopularity(string placeholder)
        {
            bool success = false;

            while (!success)
            {
                Console.WriteLine(placeholder);

                if (!Popularity.TryParse(Console.ReadLine().Trim().ToLower(), out Popularity Value))
                {
                    success = false;
                    Console.WriteLine("Please enter correct value.");
                    continue;
                }
                else
                {
                    return Value;
                }
            }
            return 0;
        }
        public string GetString(string placeholder)
        {
            bool success = false;

            while (!success)
            {
                Console.WriteLine(placeholder);
                string value = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrEmpty(value))
                {
                    success = false;
                    Console.WriteLine("Please enter correct value.");
                    continue;
                }
                else
                {
                    char temp = char.ToUpper(value[0]);
                    value = temp.ToString() + value.Remove(0, 1);
                    return value;
                }
            }
            return null;
        }
        public bool GetYesorNo(string placeholder)
        {
            bool success = false;

            while (!success)
            {
                Console.WriteLine(placeholder);
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    if (num == 1)
                    {
                        return true;
                    }
                    else if (num == 2)
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter correct value.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter correct value.");
                    continue;
                }
            }
            return false;
        }
        public int ConsoleToAskInt(string placeholder)
        {
            bool success = false;

            while (!success)
            {
                Console.WriteLine(placeholder);
                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.WriteLine("Please enter correct value.");
                    continue;
                }
                else
                {
                    return num;
                }
            }
            return 0;
        }
        public DateTime GetDate(string placeholder)
        {
            bool success = false;

            while (!success)
            {
                Console.WriteLine(placeholder);
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Please enter correct value.");
                    continue;
                }
            }
            return DateTime.Now;
        }
        List<Specification> ConsoletoGetSpecs(string placeholder)
        {
            bool success = false;
            List<Specification> specs = new List<Specification>();
            Specification sp = new Specification();
            string key, value;

            while (!success)
            {
                Console.WriteLine(placeholder);
                key = Console.ReadLine().Trim().ToLower();
                value = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrEmpty(value) && string.IsNullOrEmpty(key))
                {
                    break;
                }
                else
                {
                    sp.Name = key;
                    sp.Value = value;
                    specs.Add(sp);
                }
            }
            return specs;
        }
        public List<Category> ConsoletoAskCategory(string placeholder)
        {
            bool success = false;
            Category c = new Category();
            List<Category> value = new List<Category>();
            string tempString = "";

            while (!success)
            {
                Console.WriteLine(placeholder);
                tempString = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrEmpty(tempString))
                {
                    break;
                }
                else
                {
                    char temp = char.ToUpper(tempString[0]);
                    tempString = temp.ToString() + tempString.Remove(0, 1);
                    c.Name = tempString;
                    value.Add(c);
                }
            }
            return value;
        }
    }
}
