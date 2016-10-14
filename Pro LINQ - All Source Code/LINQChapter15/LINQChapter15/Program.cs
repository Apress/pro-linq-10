using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;

using nwind;

namespace LINQChapter15
{
  //  This class will be used by Listing15_3.
  class CustomerContact
  {
    public string Name;
    public string Phone;

    public CustomerContact(string name, string phone)
    {
      Name = name;
      Phone = phone;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing15_1();
      //Listing15_2();
      //Listing15_3();
      //Listing15_4();
      //Listing15_5();
      //Listing15_6();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.
      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing15_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      var cusorders = from o in db.Orders
                      where o.Customer.CustomerID == "CONSH"
                      orderby o.ShippedDate descending
                      select new { Customer = o.Customer, Order = o };

      //  Grab the first order.
      Order firstOrder = cusorders.First().Order;

      //  Now, let's save off the first order's shipcountry so I can reset it later.
      string shipCountry = firstOrder.ShipCountry;
      Console.WriteLine("Order is originally shipping to {0}", shipCountry);

      //  Now, I'll change the order's ship country from UK to USA.
      firstOrder.ShipCountry = "USA";
      db.SubmitChanges();

      //  Query to see that the country was indeed changed.
      string country = (from o in db.Orders
                        where o.Customer.CustomerID == "CONSH"
                        orderby o.ShippedDate descending
                        select o.ShipCountry).FirstOrDefault<string>();

      Console.WriteLine("Order is now shipping to {0}", country);

      //  Reset the order in the database so example can be re-run.
      firstOrder.ShipCountry = shipCountry;
      db.SubmitChanges();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing15_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      db.Log = Console.Out;

      var contacts = from c in db.Customers
                     where c.City == "Buenos Aires"
                     select new { Name = c.ContactName, Phone = c.Phone } into co
                     orderby co.Name
                     select co;

      foreach (var contact in contacts)
      {
        Console.WriteLine("{0} - {1}", contact.Name, contact.Phone);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing15_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      db.Log = Console.Out;

      var contacts = from c in db.Customers
                     where c.City == "Buenos Aires"
                     select new CustomerContact(c.ContactName, c.Phone) into co
                     orderby co.Name
                     select co;

      foreach (var contact in contacts)
      {
        Console.WriteLine("{0} - {1}", contact.Name, contact.Phone);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing15_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      db.Log = Console.Out;

      var contacts = from c in db.Customers
                     where c.City == "Buenos Aires"
                     select new CustomerContact(c.ContactName, c.Phone);

      foreach (var contact in contacts)
      {
        Console.WriteLine("{0} - {1}", contact.Name, contact.Phone);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing15_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      db.Log = Console.Out;

      var contacts = db.Customers.Where(c => c.City == "Buenos Aires").
                     Select(c => new CustomerContact(c.ContactName, c.Phone)).
                     OrderBy(c => c.Name);

      foreach (var contact in contacts)
      {
        Console.WriteLine("{0} - {1}", contact.Name, contact.Phone);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing15_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Contact contact = db.Contacts.Where(c => c.ContactID == 11).SingleOrDefault();
      Console.WriteLine("CompanyName = {0}", contact.CompanyName);

      contact.CompanyName = "Joe's House of Booze";
      Console.WriteLine("CompanyName = {0}", contact.CompanyName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }
  }
}

namespace nwind
{
  //  This class will be used by Listing15_6.
  public partial class Contact
  {
    partial void OnLoaded()
    {
      Console.WriteLine("OnLoaded() called.");
    }

    partial void OnCreated()
    {
      Console.WriteLine("OnCreated() called.");
    }

    partial void OnCompanyNameChanging(string value)
    {
      Console.WriteLine("OnCompanyNameChanging() called.");
    }

    partial void OnCompanyNameChanged()
    {
      Console.WriteLine("OnCompanyNameChanged() called.");
    }
  }
}