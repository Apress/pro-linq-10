using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;
using System.Xml.Linq;

using nwind;

namespace LINQChapter1
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing1_1();
      //Listing1_2();
      //Listing1_3();
      //Listing1_4();
      //Listing1_5();
      //Listing1_6();
      //Listing1_7();
      //Listing1_8();
      //Listing1_9();
      //Listing1_10();
      //Listing1_11();
      //Listing1_12();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing1_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] greetings = { "hello world", "hello LINQ", "hello Apress" };

      var items =
        from s in greetings
        where s.EndsWith("LINQ")
        select s;

      foreach (var item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing1_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      XElement books = XElement.Parse(
          @"<books>
              <book>
                <title>Pro LINQ: Language Integrated Query in C# 2010</title>
                <author>Joe Rattz</author>
              </book>
              <book>
                <title>Pro .NET 4.0 Parallel Programming in C#</title>
                <author>Adam Freeman</author>
              </book>
              <book>
                <title>Pro VB 2010 and the .NET 4.0 Platform</title>
                <author>Andrew Troelsen</author>
              </book>
            </books>");

      var titles =
        from book in books.Elements("book")
        where (string)book.Element("author") == "Joe Rattz"
        select book.Element("title");

      foreach (var title in titles)
        Console.WriteLine(title.Value);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing1_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      var custs =
        from c in db.Customers
        where c.City == "Rio de Janeiro"
        select c;

      foreach (var cust in custs)
        Console.WriteLine("{0}", cust.CompanyName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing1_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] numbers = { "0042", "010", "9", "27" };

      int[] nums = numbers.Select(s => Int32.Parse(s)).ToArray();

      foreach (int num in nums)
        Console.WriteLine(num);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing1_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] numbers = { "0042", "010", "9", "27" };

      int[] nums = numbers.Select(s => Int32.Parse(s)).OrderBy(s => s).ToArray();

      foreach (int num in nums)
        Console.WriteLine(num);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing1_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      ArrayList alEmployees = LINQDev.HR.Employee.GetEmployees();

      LINQDev.Common.Contact[] contacts = alEmployees
        .Cast<LINQDev.HR.Employee>()
        .Select(e => new LINQDev.Common.Contact {
                       Id = e.id,
                       Name = string.Format("{0} {1}", e.firstName, e.lastName)
                     })
        .ToArray<LINQDev.Common.Contact>();

      LINQDev.Common.Contact.PublishContacts(contacts);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing1_7()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind");

      var orders = db.Customers
        .Where(c => c.Country == "USA" && c.Region == "WA")
        .SelectMany(c => c.Orders);

      Console.WriteLine(orders.GetType());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing1_8()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IEnumerable<Order> orders = db.Customers
        .Where(c => c.Country == "USA" && c.Region == "WA")
        .SelectMany(c => c.Orders);

      foreach (Order item in orders)
        Console.WriteLine("{0} - {1} - {2}", item.OrderDate, item.OrderID, item.ShipName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing1_9()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I’ll build a legacy collection.
      ArrayList arrayList = new ArrayList();
      //  Sure wish I could use collection initialization here, but that 
      //  doesn't work with legacy collections.
      arrayList.Add("Adams");
      arrayList.Add("Arthur");
      arrayList.Add("Buchanan");

      IEnumerable<string> names = arrayList.Cast<string>().Where(n => n.Length < 7);
      foreach (string name in names)
        Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing1_10()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  I’ll build a legacy collection.
      ArrayList arrayList = new ArrayList();
      //  Sure wish I could use collection initialization here, but that 
      //  doesn't work with legacy collections.
      arrayList.Add("Adams");
      arrayList.Add("Arthur");
      arrayList.Add("Buchanan");

      IEnumerable<string> names = arrayList.OfType<string>().Where(n => n.Length < 7);
      foreach (string name in names)
        Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing1_11()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] strings = { "one", "two", null, "three" };

      Console.WriteLine("Before Where() is called.");
      IEnumerable<string> ieStrings = strings.Where(s => s.Length == 3);
      Console.WriteLine("After Where() is called.");

      foreach (string s in ieStrings)
      {
        Console.WriteLine("Processing " + s);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing1_12()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      db.Log = Console.Out;

      IQueryable<Order> orders = from c in db.Customers
                                 from o in c.Orders
                                 where c.Country == "USA" && c.Region == "WA"
                                 select o;

      foreach (Order item in orders)
        Console.WriteLine("{0} - {1} - {2}", item.OrderDate, item.OrderID, item.ShipName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }
  }
}

//  The following namespaces are used for Listing1_5.
namespace LINQDev.HR
{
  public class Employee
  {
    public int id;
    public string firstName;
    public string lastName;

    public static ArrayList GetEmployees()
    {
      //  Of course the real code would probably be making a database query 
      //  right about here.
      ArrayList al = new ArrayList();

      //  Man, do the C# object initialization features make this a snap.
      al.Add(new Employee { id = 1, firstName = "Joe", lastName = "Rattz" });
      al.Add(new Employee { id = 2, firstName = "William", lastName = "Gates" });
      al.Add(new Employee { id = 3, firstName = "Anders", lastName = "Hejlsberg" });
      return (al);
    }
  }
}

namespace LINQDev.Common
{
  public class Contact
  {
    public int Id;
    public string Name;

    public static void PublishContacts(Contact[] contacts)
    {
      //  This publish method just writes them to the console window.
      foreach (Contact c in contacts)
        Console.WriteLine("Contact Id:  {0}  Contact:  {1}", c.Id, c.Name);
    }
  }
}
