using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;
using System.Xml.Linq;

using nwind;


namespace LINQChapter18
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing18_1();
      //Listing18_2();
      //Listing18_3();
      //Listing18_4();
      //Listing18_5();
      //Listing18_6();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.
      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing18_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IQueryable<CategorySalesFor1997> seq = from c in db.CategorySalesFor1997s
                                             where c.CategorySales > (decimal)100000.00
                                             orderby c.CategorySales descending
                                             select c;

      foreach (CategorySalesFor1997 c in seq)
      {
        Console.WriteLine("{0} : {1:C}", c.CategoryName, c.CategorySales);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing18_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      db.CategorySalesFor1997s.InsertOnSubmit(
        new CategorySalesFor1997 
          { CategoryName = "Legumes", CategorySales = (decimal) 79043.92 });

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing18_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      TestDB db = new TestDB(@"Data Source=.\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=SSPI;");
      db.CreateDatabase();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing18_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      TestDB db = new TestDB(@"Data Source=.\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=SSPI;");

      db.Shapes.InsertOnSubmit(new Square { Width = 4 });
      db.Shapes.InsertOnSubmit(new Rectangle { Width = 3, Length = 6 });
      db.Shapes.InsertOnSubmit(new Rectangle { Width = 11, Length = 5 });
      db.Shapes.InsertOnSubmit(new Square { Width = 6 });
      db.Shapes.InsertOnSubmit(new Rectangle { Width = 4, Length = 7 });
      db.Shapes.InsertOnSubmit(new Square { Width = 9 });

      db.SubmitChanges();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing18_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      TestDB db = new TestDB(@"Data Source=.\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=SSPI;");

      // First I get all squares which will include rectangles.
      IQueryable<Shape> squares = from s in db.Shapes
                                  where s is Square
                                  select s;

      Console.WriteLine("The following squares exist.");
      foreach (Shape s in squares)
      {
        Console.WriteLine("{0} : {1}", s.Id, s.ToString());
      }

      //  Now I'll get just the rectangles.
      IQueryable<Shape> rectangles = from r in db.Shapes
                                     where r is Rectangle
                                     select r;

      Console.WriteLine("{0}The following rectangles exist.", System.Environment.NewLine);
      foreach (Shape r in rectangles)
      {
        Console.WriteLine("{0} : {1}", r.Id, r.ToString());
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing18_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");
      TestDB testDb = new TestDB(@"Data Source=.\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=SSPI;");

      Customer cust = db.Customers.Where(c => c.CustomerID == "LONEP").SingleOrDefault();
      cust.ContactName = "Barbara Penczek";

      Rectangle rect = (Rectangle)testDb.Shapes.Where(s => s.Id == 3).SingleOrDefault();
      rect.Width = 15;

      try
      {
        using (System.Transactions.TransactionScope scope =
          new System.Transactions.TransactionScope())
        {
          db.SubmitChanges();
          testDb.SubmitChanges();
          throw (new Exception("Just to rollback the transaction."));
          //  A warning will result because the next line cannot be reached.
          scope.Complete();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, cust);
      Console.WriteLine("Contact Name = {0}", cust.ContactName);

      testDb.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, rect);
      Console.WriteLine("Rectangle Width = {0}", rect.Width);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }
  }
}
