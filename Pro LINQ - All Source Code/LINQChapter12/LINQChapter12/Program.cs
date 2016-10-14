using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;

using nwind;

namespace LINQChapter12
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      Listing12_1();
    }
    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing12_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Create a DataContext.
      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      //  Retrieve customer LAZYK.
      Customer cust = (from c in db.Customers
                       where c.CustomerID == "LAZYK"
                       select c).Single<Customer>();

      //  Update the contact name.
      cust.ContactName = "Ned Plimpton";

      try
      {
        //  Save the changes.
        db.SubmitChanges();
      }
      //  Detect concurrency conflicts.
      catch (ChangeConflictException)
      {
        //  Resolve conflicts.
        db.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }
  }
}
