using System;
using System.Diagnostics;
using System.Linq;

namespace LINQChapter13
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing13_1();
      //Listing13_2();
      //Listing13_3();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing13_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      nwind.Northwind db =
        new nwind.Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      db.Log = Console.Out;

      var custs = from c in db.Customers
                  where c.Region == "WA"
                  select new { Id = c.CustomerID, Name = c.ContactName };

      foreach (var cust in custs)
      {
        Console.WriteLine("{0} - {1}", cust.Id, cust.Name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing13_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      NorthwindDataContext db = new NorthwindDataContext();

      IQueryable<Customer> custs = from c in db.Customers
                                   where c.City == "London"
                                   select c;

      foreach (Customer c in custs)
      {
        Console.WriteLine("{0} has {1} orders.", c.CompanyName, c.Orders.Count);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing13_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      NorthwindDataContext db = new NorthwindDataContext();

      db.Log = Console.Out;

      Customer cust =
        new Customer
        {
          CustomerID = "EWICH",
          CompanyName = "Every 'Wich Way",
          ContactName = "Vickey Rattz",
          ContactTitle = "Owner",
          Address = "105 Chip Morrow Dr.",
          City = "Alligator Point",
          Region = "FL",
          PostalCode = "32346",
          Country = "USA",
          Phone = "(800) EAT-WICH",
          Fax = "(800) FAX-WICH"
        };

      db.Customers.InsertOnSubmit(cust);

      db.SubmitChanges();

      Customer customer = db.Customers.Where(c => c.CustomerID == "EWICH").First();
      Console.WriteLine("{0} - {1}", customer.CompanyName, customer.ContactName);

      //  Restore the database.
      db.Customers.DeleteOnSubmit(cust);
      db.SubmitChanges();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }
  }
}
