using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;

using nwind;


namespace LINQChapter17
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing17_1();
      //Listing17_2();
      //Listing17_3();
      //Listing17_4();
      //Listing17_5();
      //Listing17_6();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.
      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing17_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      db.Log = Console.Out;

      Customer cust = db.Customers.Where(c => c.CustomerID == "LONEP").SingleOrDefault();
      string name = cust.ContactName; // to restore later.

      cust.ContactName = "Neo Anderson";

      db.SubmitChanges();

      //  Restore database.
      cust.ContactName = name;
      db.SubmitChanges();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing17_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Customer cust = db.Customers.Where(c => c.CustomerID == "LAZYK").SingleOrDefault();

      ExecuteStatementInDb(String.Format(
        @"update Customers
          set ContactName = 'Samuel Arthur Sanders' 
          where CustomerID = 'LAZYK'"));

      cust.ContactTitle = "President";
      try
      {
        db.SubmitChanges(ConflictMode.ContinueOnConflict);
      }
      catch (ChangeConflictException)
      {
        db.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
        try
        {
          db.SubmitChanges(ConflictMode.ContinueOnConflict);
          cust = db.Customers.Where(c => c.CustomerID == "LAZYK").SingleOrDefault();
          Console.WriteLine("ContactName = {0} : ContactTitle = {1}", 
            cust.ContactName, cust.ContactTitle);
        }
        catch (ChangeConflictException)
        {
          Console.WriteLine("Conflict again, aborting.");
        }
      }

      //  Reset the database.
      ExecuteStatementInDb(String.Format(
        @"update Customers 
          set ContactName = 'John Steel', ContactTitle = 'Marketing Manager' 
          where CustomerID = 'LAZYK'"));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing17_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Customer cust = db.Customers.Where(c => c.CustomerID == "LAZYK").SingleOrDefault();

      ExecuteStatementInDb(String.Format(
        @"update Customers
          set ContactName = 'Samuel Arthur Sanders' 
          where CustomerID = 'LAZYK'"));

      cust.ContactTitle = "President";
      try
      {
        db.SubmitChanges(ConflictMode.ContinueOnConflict);
      }
      catch (ChangeConflictException)
      {
        foreach (ObjectChangeConflict conflict in db.ChangeConflicts)
        {
          Console.WriteLine("Conflict occurred in customer {0}.",
            ((Customer)conflict.Object).CustomerID);
          Console.WriteLine("Calling Resolve ...");
          conflict.Resolve(RefreshMode.KeepChanges);
          Console.WriteLine("Conflict resolved.{0}", System.Environment.NewLine);
        }

        try
        {
          db.SubmitChanges(ConflictMode.ContinueOnConflict);
          cust = db.Customers.Where(c => c.CustomerID == "LAZYK").SingleOrDefault();
          Console.WriteLine("ContactName = {0} : ContactTitle = {1}",
            cust.ContactName, cust.ContactTitle);
        }
        catch (ChangeConflictException)
        {
          Console.WriteLine("Conflict again, aborting.");
        }
      }

      //  Reset the database.
      ExecuteStatementInDb(String.Format(
        @"update Customers 
          set ContactName = 'John Steel', ContactTitle = 'Marketing Manager' 
          where CustomerID = 'LAZYK'"));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing17_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Customer cust = db.Customers.Where(c => c.CustomerID == "LAZYK").SingleOrDefault();

      ExecuteStatementInDb(String.Format(
        @"update Customers
          set ContactName = 'Samuel Arthur Sanders', 
            ContactTitle = 'CEO' 
          where CustomerID = 'LAZYK'"));

      cust.ContactName = "Viola Sanders";
      cust.ContactTitle = "President";
      try
      {
        db.SubmitChanges(ConflictMode.ContinueOnConflict);
      }
      catch (ChangeConflictException)
      {
        foreach (ObjectChangeConflict conflict in db.ChangeConflicts)
        {
          Console.WriteLine("Conflict occurred in customer {0}.",
            ((Customer)conflict.Object).CustomerID);
          foreach (MemberChangeConflict memberConflict in conflict.MemberConflicts)
          {
            Console.WriteLine("Calling Resolve for {0} ...", 
              memberConflict.Member.Name);
            if (memberConflict.Member.Name.Equals("ContactName"))
            {
              memberConflict.Resolve(RefreshMode.OverwriteCurrentValues);
            }
            else
            {
              memberConflict.Resolve(RefreshMode.KeepChanges);
            }
            
            Console.WriteLine("Conflict resolved.{0}", System.Environment.NewLine);
          }
        }

        try
        {
          db.SubmitChanges(ConflictMode.ContinueOnConflict);
          cust = db.Customers.Where(c => c.CustomerID == "LAZYK").SingleOrDefault();
          Console.WriteLine("ContactName = {0} : ContactTitle = {1}",
            cust.ContactName, cust.ContactTitle);
        }
        catch (ChangeConflictException)
        {
          Console.WriteLine("Conflict again, aborting.");
        }
      }

      //  Reset the database.
      ExecuteStatementInDb(String.Format(
        @"update Customers 
          set ContactName = 'John Steel', ContactTitle = 'Marketing Manager' 
          where CustomerID = 'LAZYK'"));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing17_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      using (System.Transactions.TransactionScope transaction =
        new System.Transactions.TransactionScope())
      {
        Customer cust = 
          db.Customers.Where(c => c.CustomerID == "LAZYK").SingleOrDefault();

        try
        {
          Console.WriteLine("Let's try to update LAZYK's ContactName with ADO.NET.");
          Console.WriteLine("  Please be patient, we have to wait for timeout ...");
          using (System.Transactions.TransactionScope t2 =
            new System.Transactions.TransactionScope(
              System.Transactions.TransactionScopeOption.RequiresNew))
          {
            ExecuteStatementInDb(String.Format(
              @"update Customers 
                set ContactName = 'Samuel Arthur Sanders' 
                where CustomerID = 'LAZYK'"));

            t2.Complete();
          }

          Console.WriteLine("LAZYK's ContactName updated.{0}", 
            System.Environment.NewLine);
        }
        catch (Exception ex)
        {
          Console.WriteLine(
            "Exception occurred trying to update LAZYK with ADO.NET:{0}  {1}{0}",
            System.Environment.NewLine, ex.Message);
        }

        cust.ContactName = "Viola Sanders";
        db.SubmitChanges();

        cust = db.Customers.Where(c => c.CustomerID == "LAZYK").SingleOrDefault();
        Console.WriteLine("Customer Contact Name: {0}", cust.ContactName);

        transaction.Complete();
      }

      //  Reset the database.
      ExecuteStatementInDb(String.Format(
        @"update Customers 
          set ContactName = 'John Steel',
            ContactTitle = 'Marketing Manager' 
          where CustomerID = 'LAZYK'"));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing17_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      //  Create an entity object.
      Console.WriteLine("Constructing an empty Customer object.");
      Customer cust = new Customer();

      //  First, all fields establishing identity must get set.
      Console.WriteLine("Setting the primary keys.");
      cust.CustomerID = "LAZYK";

      //  Next, every field that will change must be set.
      Console.WriteLine("Setting the fields I will change.");
      cust.ContactName = "John Steel";

      //  Last, all fields participating in update check must be set.  
      //  Unfortunately, for the Customer entity class, that is all of them.
      Console.WriteLine("Setting all fields participating in update check.");
      cust.CompanyName = "Lazy K Kountry Store";
      cust.ContactTitle = "Marketing Manager";
      cust.Address = "12 Orchestra Terrace";
      cust.City = "Walla Walla";
      cust.Region = "WA";
      cust.PostalCode = "99362";
      cust.Country = "USA";
      cust.Phone = "(509) 555-7969";
      cust.Fax = "(509) 555-6221";

      //  Now let's attach to the Customers Table<T>;
      Console.WriteLine("Attaching to the Customers Table<Customer>.");
      db.Customers.Attach(cust);

      //  At this point we can make our changes and call SubmitChanges().
      Console.WriteLine("Making my changes and calling SubmitChanges().");
      cust.ContactName = "Vickey Rattz";
      db.SubmitChanges();

      cust = db.Customers.Where(c => c.CustomerID == "LAZYK").SingleOrDefault();
      Console.WriteLine("ContactName in database = {0}", cust.ContactName);

      Console.WriteLine("Restoring changes and calling SubmitChanges().");
      cust.ContactName = "John Steel";
      db.SubmitChanges();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static private void ExecuteStatementInDb(string cmd)
    {
      string connection =
        @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";

      System.Data.SqlClient.SqlConnection sqlConn =
        new System.Data.SqlClient.SqlConnection(connection);

      System.Data.SqlClient.SqlCommand sqlComm =
        new System.Data.SqlClient.SqlCommand(cmd);

      sqlComm.Connection = sqlConn;
      try
      {
        sqlConn.Open();
        Console.WriteLine("Executing SQL statement against database with ADO.NET ...");
        sqlComm.ExecuteNonQuery();
        Console.WriteLine("Database updated.");
      }
      finally
      {
        //  Close the connection.
        sqlComm.Connection.Close();
      }
    }
  }
}
