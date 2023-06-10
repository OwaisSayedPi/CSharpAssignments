using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name + "\n" + Age;
        }
    }
    public class DBO
    {
        public DateTime DOB { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public override string ToString()
        {
            return FName + "\n" + LName + "\n" + DOB;
        }

    }
    class EqualisingPersonAndDBO
    {
        public static List<Person> Person = new List<Person>();
        public static List<DBO> DBO= new List<DBO>();
    }
    class Operation:EqualisingPersonAndDBO
    {
        public void AddProduct(string fname, string lname, DateTime dob)
        {
            DBO dbo = new DBO
            {
                DOB = dob,
                FName = fname,
                LName = lname
            };

            EqualisingPersonAndDBO.DBO.Add(dbo);
        }
        public void GetPerson()
        {
            EqualisingPersonAndDBO.Person = EqualisingPersonAndDBO.DBO.Select(x => new Person { Age = DateTime.Now.Year - x.DOB.Year, Name = x.FName + x.LName }).ToList();
        }
        public void DisplayLists()
        {
            Console.WriteLine("Enter:\n1 for DBO List\n2 for Person List");
            int.TryParse(Console.ReadLine(), out int choice);
            if (choice == 1)
            {
                for (int i = 0; i < EqualisingPersonAndDBO.DBO.Count; i++)
                {
                    Console.WriteLine(EqualisingPersonAndDBO.DBO[i]);
                }
            }
            else if (choice == 2)
            {
                for (int i = 0; i < EqualisingPersonAndDBO.Person.Count; i++)
                {
                    Console.WriteLine(EqualisingPersonAndDBO.Person[i]);
                }
            }
        }
        public void ShowMenu()
        {
            Console.WriteLine("Show Persons with :");
            Console.WriteLine("1 -- Age>18");
            Console.WriteLine("2 -- First Name starting with S");
            Console.WriteLine("3 -- Birth Date from year 1993");
            Console.WriteLine("4 -- Birth Date between 2000-2005");

            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    foreach (var item in EqualisingPersonAndDBO.Person.Select(x => x).Where(x => x.Age>18).ToList())
                    {
                        Console.WriteLine(item);
                    }                    
                    break;
                case 2:
                    foreach (var item in EqualisingPersonAndDBO.Person.Select(x => x).Where(x => x.Name.StartsWith("S")).ToList())
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 3:
                    foreach (var item in EqualisingPersonAndDBO.Person.Select(x => x).Where(x => x.Age == DateTime.Now.Year - 1993).ToList())
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 4:
                    foreach (var item in EqualisingPersonAndDBO.Person.Select(x => x).Where(x => x.Age < DateTime.Now.Year - 2000 && x.Age > DateTime.Now.Year - 2005).ToList())
                    {
                        Console.WriteLine(item);
                    }
                    break;                
                default:
                    break;
            }
            Console.Clear();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            GetReader getReader = new GetReader();
            Operation operation = new Operation();

            string fname = GetReader.StringFromConsole("Enter First Name");
            string lname = GetReader.StringFromConsole("Enter Last Name");
            DateTime dob = GetReader.DateFromConsole("Enter your DOB");

            operation.AddProduct(fname, lname, dob);

            operation.GetPerson();

            operation.DisplayLists();

            operation.ShowMenu();


            Product product1 = new Product();
            Product product2 = new Product();

            Console.WriteLine("Number of Product objects initialised: "+Product.UID);
            Console.ReadLine();
        }
    }
}
