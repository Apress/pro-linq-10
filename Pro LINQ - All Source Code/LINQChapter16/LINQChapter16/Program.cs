using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;

using nwind;

namespace LINQChapter16
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing16_1();
      //Listing16_2();
      //Listing16_3();
      //Listing16_4();
      //Listing16_5();
      //Listing16_6();
      //Listing16_7();
      //Listing16_8();
      //Listing16_9();
      //Listing16_10();
      //Listing16_11();
      //Listing16_12();
      //Listing16_13();
      //Listing16_14();
      //Listing16_15();
      //Listing16_16();
      //Listing16_17();
      //Listing16_18();
      //Listing16_19();
      //Listing16_20();
      //Listing16_21();
      //Listing16_22();
      //Listing16_23();
      //Listing16_24();
      //Listing16_25();
      //Listing16_26();
      //Listing16_27();
      //Listing16_28();
      //Listing16_29();
      //Listing16_30();
      //Listing16_31();
      //Listing16_32();
      //Listing16_33();
      //Listing16_34();
      //Listing16_35();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.
      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IQueryable<Customer> query = from cust in db.Customers
                                   where cust.Country == "USA"
                                   select cust;

      foreach (Customer c in query)
      {
        Console.WriteLine("{0}", c.CompanyName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      DataContext dc =
        new DataContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IQueryable<Customer> query = from cust in dc.GetTable<Customer>()
                                   where cust.Country == "USA"
                                   select cust;

      foreach (Customer c in query)
      {
        Console.WriteLine("{0}", c.CompanyName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      //  Let's get a cutomer to modify that will be outside our query of region == 'WA'.
      Customer cust = (from c in db.Customers
                       where c.CustomerID == "LONEP"
                       select c).Single<Customer>();

      Console.WriteLine("Customer {0} has region = {1}.{2}",
        cust.CustomerID, cust.Region, System.Environment.NewLine);

      //  Ok, LONEP's region is OR.

      //  Now, let's get a sequence of customers from 'WA', which will not include LONEP
      //  since his region is OR.
      IEnumerable<Customer> custs = (from c in db.Customers
                                     where c.Region == "WA"
                                     select c);

      Console.WriteLine("Customers from WA before ADO.NET change - start ...");
      foreach (Customer c in custs)
      {
        //  Display each entity object's Region.
        Console.WriteLine("Customer {0}'s region is {1}.", c.CustomerID, c.Region);
      }
      Console.WriteLine("Customers from WA before ADO.NET change - end.{0}",
        System.Environment.NewLine);

      //  Now we will change LONEP's region to WA, which would have included it
      //  in that previous query's results.

      //  Change the customers' region through ADO.NET.
      Console.WriteLine("Updating LONEP's region to WA in ADO.NET...");
      ExecuteStatementInDb(
        "update Customers set Region = 'WA' where CustomerID = 'LONEP'");
      Console.WriteLine("LONEP's region updated.{0}", System.Environment.NewLine);

      Console.WriteLine("So LONEP's region is WA in database, but ...");
      Console.WriteLine("Customer {0} has region = {1} in entity object.{2}",
        cust.CustomerID, cust.Region, System.Environment.NewLine);

      //  Now, LONEP's region is WA in database, but still OR in entity object.

      //  Now, let's perform the query again.
      //  Display the customers entity object's region again.
      Console.WriteLine("Query entity objects after ADO.NET change - start ...");
      foreach (Customer c in custs)
      {
        //  Display each entity object's Region.
        Console.WriteLine("Customer {0}'s region is {1}.", c.CustomerID, c.Region);
      }
      Console.WriteLine("Query entity objects after ADO.NET change - end.{0}",
        System.Environment.NewLine);

      //  We need to reset the changed values so that the code can be run
      //  more than once.
      Console.WriteLine("{0}Resetting data to original values.",
        System.Environment.NewLine);
      ExecuteStatementInDb(
        "update Customers set Region = 'OR' where CustomerID = 'LONEP'");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Console.WriteLine("First we will add customer LAWN.");
      db.Customers.InsertOnSubmit(
        new Customer
        {
          CustomerID = "LAWN",
          CompanyName = "Lawn Wranglers",
          ContactName = "Mr. Abe Henry",
          ContactTitle = "Owner",
          Address = "1017 Maple Leaf Way",
          City = "Ft. Worth",
          Region = "TX",
          PostalCode = "76104",
          Country = "USA",
          Phone = "(800) MOW-LAWN",
          Fax = "(800) MOW-LAWO"
        });

      Console.WriteLine("Next we will query for customer LAWN.");
      Customer cust = (from c in db.Customers
                       where c.CustomerID == "LAWN"
                       select c).SingleOrDefault<Customer>();
      Console.WriteLine("Customer LAWN {0}.{1}",
        cust == null ? "does not exist" : "exists",
        System.Environment.NewLine);

      Console.WriteLine("Now we will delete customer LONEP");
      cust = (from c in db.Customers
              where c.CustomerID == "LONEP"
              select c).SingleOrDefault<Customer>();
      db.Customers.DeleteOnSubmit(cust);

      Console.WriteLine("Next we will query for customer LONEP.");
      cust = (from c in db.Customers
              where c.CustomerID == "LONEP"
              select c).SingleOrDefault<Customer>();
      Console.WriteLine("Customer LONEP {0}.{1}",
        cust == null ? "does not exist" : "exists",
        System.Environment.NewLine);

      //  No need to reset database since SubmitChanges() was not called.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      DataContext dc = new DataContext(@"C:\Northwind.mdf");

      IQueryable<Customer> query = from cust in dc.GetTable<Customer>()
                                   where cust.Country == "USA"
                                   select cust;

      foreach (Customer c in query)
      {
        Console.WriteLine("{0}", c.CompanyName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"C:\Northwind.mdf");

      IQueryable<Customer> query = from cust in db.Customers
                                   where cust.Country == "USA"
                                   select cust;

      foreach (Customer c in query)
      {
        Console.WriteLine("{0}", c.CompanyName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_7()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IQueryable<Customer> query = from cust in db.Customers
                                   where cust.Country == "USA"
                                   select cust;

      foreach (Customer c in query)
      {
        Console.WriteLine("{0}", c.CompanyName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_8()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      System.Data.SqlClient.SqlConnection sqlConn =
        new System.Data.SqlClient.SqlConnection(
        @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      string cmd = @"insert into Customers values ('LAWN', 'Lawn Wranglers', 
        'Mr. Abe Henry', 'Owner', '1017 Maple Leaf Way', 'Ft. Worth', 'TX', 
        '76104', 'USA', '(800) MOW-LAWN', '(800) MOW-LAWO')";

      System.Data.SqlClient.SqlCommand sqlComm = 
        new System.Data.SqlClient.SqlCommand(cmd);

      sqlComm.Connection = sqlConn;
      try
      {
        sqlConn.Open();
        //  Insert the record.
        sqlComm.ExecuteNonQuery();

        Northwind db = new Northwind(sqlConn);

        IQueryable<Customer> query = from cust in db.Customers
                                     where cust.Country == "USA"
                                     select cust;

        Console.WriteLine("Customers after insertion, but before deletion.");
        foreach (Customer c in query)
        {
          Console.WriteLine("{0}", c.CompanyName);
        }

        sqlComm.CommandText = "delete from Customers where CustomerID = 'LAWN'";
        //  Delete the record.
        sqlComm.ExecuteNonQuery();

        Console.WriteLine("{0}{0}Customers after deletion.", System.Environment.NewLine);
        foreach (Customer c in query)
        {
          Console.WriteLine("{0}", c.CompanyName);
        }
      }
      finally
      {
        //  Close the connection.
        sqlComm.Connection.Close();
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_9()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string mapPath = "abbreviatednorthwindmap.xml";
      XmlMappingSource nwindMap = 
        XmlMappingSource.FromXml(System.IO.File.ReadAllText(mapPath));

      DataContext db = new DataContext(
        @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;",
        nwindMap);

      IQueryable<Linqdev.Customer> query =
        from cust in db.GetTable<Linqdev.Customer>()
        where cust.Country == "USA"
        select cust;

      foreach (Linqdev.Customer c in query)
      {
        Console.WriteLine("{0}", c.CompanyName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_10()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      System.Data.SqlClient.SqlConnection sqlConn =
        new System.Data.SqlClient.SqlConnection(
        @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      string cmd = @"insert into Customers values ('LAWN', 'Lawn Wranglers', 
        'Mr. Abe Henry', 'Owner', '1017 Maple Leaf Way', 'Ft. Worth', 'TX', 
        '76104', 'USA', '(800) MOW-LAWN', '(800) MOW-LAWO')";

      System.Data.SqlClient.SqlCommand sqlComm =
        new System.Data.SqlClient.SqlCommand(cmd);

      sqlComm.Connection = sqlConn;
      try
      {
        sqlConn.Open();
        //  Insert the record.
        sqlComm.ExecuteNonQuery();

        string mapPath = "abbreviatednorthwindmap.xml";
        XmlMappingSource nwindMap =
          XmlMappingSource.FromXml(System.IO.File.ReadAllText(mapPath));

        DataContext db = new DataContext(sqlConn, nwindMap);

        IQueryable<Linqdev.Customer> query =
          from cust in db.GetTable<Linqdev.Customer>()
          where cust.Country == "USA"
          select cust;

        Console.WriteLine("Customers after insertion, but before deletion.");
        foreach (Linqdev.Customer c in query)
        {
          Console.WriteLine("{0}", c.CompanyName);
        }

        sqlComm.CommandText = "delete from Customers where CustomerID = 'LAWN'";
        //  Delete the record.
        sqlComm.ExecuteNonQuery();

        Console.WriteLine("{0}{0}Customers after deletion.", System.Environment.NewLine);
        foreach (Linqdev.Customer c in query)
        {
          Console.WriteLine("{0}", c.CompanyName);
        }
      }
      finally
      {
        //  Close the connection.
        sqlComm.Connection.Close();
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_11()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      System.Data.SqlClient.SqlConnection sqlConn =
        new System.Data.SqlClient.SqlConnection(
        @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      try
      {
        sqlConn.Open();

        string sqlQuery = "select ContactTitle from Customers where CustomerID = 'LAZYK'";
        string originalTitle = GetStringFromDb(sqlConn, sqlQuery);
        string title = originalTitle;
        Console.WriteLine("Title from database record: {0}", title);

        Northwind db = new Northwind(sqlConn);

        Customer c = (from cust in db.Customers
                      where cust.CustomerID == "LAZYK"
                      select cust).
                     Single<Customer>();
        Console.WriteLine("Title from entity object : {0}", c.ContactTitle);

        Console.WriteLine(String.Format(
          "{0}Change the title to 'Director of Marketing' in the entity object:",
          System.Environment.NewLine));
        c.ContactTitle = "Director of Marketing";

        title = GetStringFromDb(sqlConn, sqlQuery);
        Console.WriteLine("Title from database record: {0}", title);

        Customer c2 = (from cust in db.Customers
                       where cust.CustomerID == "LAZYK"
                       select cust).
                      Single<Customer>();
        Console.WriteLine("Title from entity object : {0}", c2.ContactTitle);

        db.SubmitChanges();
        Console.WriteLine(String.Format(
          "{0}SubmitChanges() method has been called.",
          System.Environment.NewLine));

        title = GetStringFromDb(sqlConn, sqlQuery);
        Console.WriteLine("Title from database record: {0}", title);

        Console.WriteLine("Restoring ContactTitle back to original value ...");
        c.ContactTitle = "Marketing Manager";
        db.SubmitChanges();
        Console.WriteLine("ContactTitle restored.");
      }
      finally
      {
        sqlConn.Close();
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_12()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Console.WriteLine("Querying for the LAZYK Customer with LINQ.");
      Customer cust1 = (from c in db.Customers
                        where c.CustomerID == "LAZYK"
                        select c).Single<Customer>();

      Console.WriteLine("Querying for the LONEP Customer with LINQ.");
      Customer cust2 = (from c in db.Customers
                        where c.CustomerID == "LONEP"
                        select c).Single<Customer>();

      string cmd = @"update Customers set ContactTitle = 'Director of Marketing' 
                       where CustomerID = 'LAZYK'; 
                     update Customers set ContactTitle = 'Director of Sales' 
                       where CustomerID = 'LONEP'";
      ExecuteStatementInDb(cmd);

      Console.WriteLine("Change ContactTitle in entity objects for LAZYK and LONEP.");
      cust1.ContactTitle = "Vice President of Marketing";
      cust2.ContactTitle = "Vice President of Sales";

      try
      {
        Console.WriteLine("Calling SubmitChanges() ...");
        db.SubmitChanges(ConflictMode.ContinueOnConflict);
        Console.WriteLine("SubmitChanges() called successfully.");
      }
      catch (ChangeConflictException ex)
      {
        Console.WriteLine("Conflict(s) occurred calling SubmitChanges(): {0}",
          ex.Message);

        foreach (ObjectChangeConflict objectConflict in db.ChangeConflicts)
        {
          Console.WriteLine("Conflict for {0} occurred.",
            ((Customer)objectConflict.Object).CustomerID);

          foreach (MemberChangeConflict memberConflict in objectConflict.MemberConflicts)
          {
            Console.WriteLine("  LINQ value = {0}{1}  Database value = {2}",
              memberConflict.CurrentValue,
              System.Environment.NewLine,
              memberConflict.DatabaseValue);
          }
        }
      }

      Console.WriteLine("{0}Resetting data to original values.", System.Environment.NewLine);
      cmd = @"update Customers set ContactTitle = 'Marketing Manager'
                where CustomerID = 'LAZYK'; 
              update Customers set ContactTitle = 'Sales Manager' 
                where CustomerID = 'LONEP'";
      ExecuteStatementInDb(cmd);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_13()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Console.WriteLine("Querying for the LAZYK Customer with LINQ.");
      Customer cust1 = (from c in db.Customers
                        where c.CustomerID == "LAZYK"
                        select c).Single<Customer>();

      Console.WriteLine("Querying for the LONEP Customer with LINQ.");
      Customer cust2 = (from c in db.Customers
                        where c.CustomerID == "LONEP"
                        select c).Single<Customer>();

      string cmd = @"update Customers set ContactTitle = 'Director of Marketing' 
                       where CustomerID = 'LAZYK'; 
                     update Customers set ContactTitle = 'Director of Sales' 
                       where CustomerID = 'LONEP'";
      ExecuteStatementInDb(cmd);

      Console.WriteLine("Change ContactTitle in entity objects for LAZYK and LONEP.");
      cust1.ContactTitle = "Vice President of Marketing";
      cust2.ContactTitle = "Vice President of Sales";

      try
      {
        Console.WriteLine("Calling SubmitChanges() ...");
        db.SubmitChanges(ConflictMode.FailOnFirstConflict);
        Console.WriteLine("SubmitChanges() called successfully.");
      }
      catch (ChangeConflictException ex)
      {
        Console.WriteLine("Conflict(s) occurred calling SubmitChanges(): {0}",
          ex.Message);

        foreach (ObjectChangeConflict objectConflict in db.ChangeConflicts)
        {
          Console.WriteLine("Conflict for {0} occurred.",
            ((Customer)objectConflict.Object).CustomerID);

          foreach (MemberChangeConflict memberConflict in objectConflict.MemberConflicts)
          {
            Console.WriteLine("  LINQ value = {0}{1}  Database value = {2}",
              memberConflict.CurrentValue,
              System.Environment.NewLine,
              memberConflict.DatabaseValue);
          }
        }
      }

      Console.WriteLine("{0}Resetting data to original values.",
        System.Environment.NewLine);
      cmd = @"update Customers set ContactTitle = 'Marketing Manager'
                where CustomerID = 'LAZYK'; 
              update Customers set ContactTitle = 'Sales Manager' 
                where CustomerID = 'LONEP'";
      ExecuteStatementInDb(cmd);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_14()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Console.WriteLine("The Northwind database {0}.",
        db.DatabaseExists() ? "exists" : "does not exist");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_15()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"C:\Northwnd.mdf");
      db.CreateDatabase();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_16()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"C:\Northwnd.mdf");
      db.DeleteDatabase();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_17()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IQueryable<ProductsUnderThisUnitPriceResult> results =
        db.ProductsUnderThisUnitPrice(new Decimal(5.50));

      foreach (ProductsUnderThisUnitPriceResult prod in results)
      {
        Console.WriteLine("{0} - {1:C}", prod.ProductName, prod.UnitPrice);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_18()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IEnumerable<Customer> custs = db.ExecuteQuery<Customer>(
        @"select CustomerID, CompanyName, ContactName, ContactTitle
          from Customers where Region = {0}", "WA");

      foreach (Customer c in custs)
      {
        Console.WriteLine("ID = {0} : Name = {1} : Contact = {2}",
          c.CustomerID, c.CompanyName, c.ContactName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_19()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IEnumerable<Customer> custs = db.ExecuteQuery<Customer>(
        @"select CustomerID, CompanyName, ContactName, ContactTitle
          from Customers where Region = 'WA'");

      foreach (Customer c in custs)
      {
        Console.WriteLine("ID = {0} : Name = {1} : Contact = {2}",
          c.CustomerID, c.CompanyName, c.ContactName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_20()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IEnumerable<Customer> custs = db.ExecuteQuery<Customer>(
        @"select CustomerID, Address + ', ' + City + ', ' + Region as Address
          from Customers where Region = 'WA'");

      foreach (Customer c in custs)
      {
        Console.WriteLine("Id = {0} : Address = {1}",
            c.CustomerID, c.Address);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_21()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      System.Data.SqlClient.SqlConnection sqlConn = 
        new System.Data.SqlClient.SqlConnection(
        @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      string cmd = @"select CustomerID, CompanyName, ContactName, ContactTitle
                     from Customers where Region = 'WA'";

      System.Data.SqlClient.SqlCommand sqlComm = 
        new System.Data.SqlClient.SqlCommand(cmd);

      sqlComm.Connection = sqlConn;
      try
      {
        sqlConn.Open();
        System.Data.SqlClient.SqlDataReader reader = sqlComm.ExecuteReader();

        Northwind db = new Northwind(sqlConn);
        IEnumerable<Customer> custs = db.Translate<Customer>(reader);

        foreach (Customer c in custs)
        {
          Console.WriteLine("ID = {0} : Name = {1} : Contact = {2}",
              c.CustomerID, c.CompanyName, c.ContactName);
        }
      }
      finally
      {
        sqlComm.Connection.Close();
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_22()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Console.WriteLine("Inserting customer ...");
      int rowsAffected = db.ExecuteCommand(
        @"insert into Customers values ({0}, 'Lawn Wranglers', 
          'Mr. Abe Henry', 'Owner', '1017 Maple Leaf Way', 'Ft. Worth', 'TX', 
          '76104', 'USA', '(800) MOW-LAWN', '(800) MOW-LAWO')",
        "LAWN");
      Console.WriteLine("Insert complete.{0}", System.Environment.NewLine);

      Console.WriteLine("There were {0} row(s) affected.  Is customer in database?",
        rowsAffected);

      Customer cust = (from c in db.Customers
                       where c.CustomerID == "LAWN"
                       select c).DefaultIfEmpty<Customer>().Single<Customer>();

      Console.WriteLine("{0}{1}",
        cust != null ? 
          "Yes, customer is in database." : "No, customer is not in database.",
        System.Environment.NewLine);

      Console.WriteLine("Deleting customer ...");
      rowsAffected =
        db.ExecuteCommand(@"delete from Customers where CustomerID = {0}", "LAWN");

      Console.WriteLine("Delete complete.{0}", System.Environment.NewLine);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_23()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");
      int rc = db.CustomersCountByRegion("WA");
      Console.WriteLine("There are {0} customers in WA.", rc);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_24()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");
      decimal? totalSales = 0;
      int rc = db.CustOrderTotal("LAZYK", ref totalSales);
      Console.WriteLine("Customer LAZYK has total sales of {0:C}.", totalSales);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_25()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      ISingleResult<CustomersByCityResult> results = db.CustomersByCity("London");

      foreach (CustomersByCityResult cust in results)
      {
        Console.WriteLine("{0} - {1} - {2} - {3}", cust.CustomerID, cust.CompanyName,
          cust.ContactName, cust.City);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_26()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IMultipleResults results = db.WholeOrPartialCustomersSet(1);

      foreach (WholeOrPartialCustomersSetResult1 cust in
          results.GetResult<WholeOrPartialCustomersSetResult1>())
      {
        Console.WriteLine("{0} - {1} - {2} - {3}", cust.CustomerID, cust.CompanyName,
          cust.ContactName, cust.City);
      }


      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_27()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IMultipleResults results = db.GetCustomerAndOrders("LAZYK");

      GetCustomerAndOrdersResult1 cust = 
        results.GetResult<GetCustomerAndOrdersResult1>().Single();

      Console.WriteLine("{0} orders:", cust.CompanyName);

      foreach (GetCustomerAndOrdersResult2 order in
          results.GetResult<GetCustomerAndOrdersResult2>())
      {
        Console.WriteLine("{0} - {1}", order.OrderID, order.OrderDate);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_28()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IQueryable<Product> products = from p in db.Products
                                     where p.UnitPrice == 
                                       db.MinUnitPriceByCategory(p.CategoryID)
                                     select p;

      foreach (Product p in products)
      {
        Console.WriteLine("{0} - {1:C}", p.ProductName, p.UnitPrice);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_29()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IQueryable<Customer> custs = from c in db.Customers
                                   where c.Region == "WA"
                                   select c;
      
      System.Data.Common.DbCommand dbc = db.GetCommand(custs);

      Console.WriteLine("Query's timeout is: {0}{1}", dbc.CommandTimeout,
        System.Environment.NewLine);

      dbc.CommandTimeout = 1;
      
      Console.WriteLine("Query's SQL is: {0}{1}",
        dbc.CommandText, System.Environment.NewLine);

      Console.WriteLine("Query's timeout is: {0}{1}", dbc.CommandTimeout,
        System.Environment.NewLine);

      foreach (Customer c in custs)
      {
        Console.WriteLine("{0}", c.CompanyName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_30()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Customer cust = (from c in db.Customers
                       where c.CustomerID == "LAZYK"
                       select c).Single<Customer>();
      cust.Region = "Washington";

      db.Customers.InsertOnSubmit(
        new Customer
        {
          CustomerID = "LAWN",
          CompanyName = "Lawn Wranglers",
          ContactName = "Mr. Abe Henry",
          ContactTitle = "Owner",
          Address = "1017 Maple Leaf Way",
          City = "Ft. Worth",
          Region = "TX",
          PostalCode = "76104",
          Country = "USA",
          Phone = "(800) MOW-LAWN",
          Fax = "(800) MOW-LAWO"
        });

      Customer cust2 = (from c in db.Customers
                        where c.CustomerID == "LONEP"
                        select c).Single<Customer>();
      db.Customers.DeleteOnSubmit(cust2);
      cust2 = null;

      ChangeSet changeSet = db.GetChangeSet();

      Console.WriteLine("{0}First, the added entities:", System.Environment.NewLine);
      foreach (Customer c in changeSet.Inserts)
      {
        Console.WriteLine("Customer {0} will be added.", c.CompanyName);
      }

      Console.WriteLine("{0}Second, the modified entities:", System.Environment.NewLine);
      foreach (Customer c in changeSet.Updates)
      {
        Console.WriteLine("Customer {0} will be updated.", c.CompanyName);
      }

      Console.WriteLine("{0}Third, the removed entities:", System.Environment.NewLine);
      foreach (Customer c in changeSet.Deletes)
      {
        Console.WriteLine("Customer {0} will be deleted.", c.CompanyName);
      }
      
      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_31()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      DataContext db =
        new DataContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Customer cust = (from c in db.GetTable<Customer>()
                       where c.CustomerID == "LAZYK"
                       select c).Single<Customer>();

      Console.WriteLine("Customer {0} retrieved.", cust.CompanyName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_32()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      DataContext db =
        new DataContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Customer cust = (from c in ((IQueryable<Customer>)db.GetTable(typeof(Customer)))
                       where c.CustomerID == "LAZYK"
                       select c).Single<Customer>();

      Console.WriteLine("Customer {0} retrieved.", cust.CompanyName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_33()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Customer cust = (from c in db.Customers
                       where c.CustomerID == "GREAL"
                       select c).Single<Customer>();

      Console.WriteLine("Customer's original name is {0}, ContactTitle is {1}.{2}",
        cust.ContactName, cust.ContactTitle, System.Environment.NewLine);

      ExecuteStatementInDb(String.Format(
        @"update Customers set ContactName = 'Brad Radaker' where CustomerID = 'GREAL'"));

      cust.ContactTitle = "Chief Technology Officer";

      Console.WriteLine("Customer's name before refresh is {0}, ContactTitle is {1}.{2}",
        cust.ContactName, cust.ContactTitle, System.Environment.NewLine);

      db.Refresh(RefreshMode.KeepChanges, cust);

      Console.WriteLine("Customer's name after refresh is {0}, ContactTitle is {1}.{2}",
        cust.ContactName, cust.ContactTitle, System.Environment.NewLine);

      //  we need to reset the changed values so that the code can be run
      //  more than once.
      Console.WriteLine("{0}Resetting data to original values.",
        System.Environment.NewLine);
      ExecuteStatementInDb(String.Format(
        @"update Customers set ContactName = 'Howard Snyder' where CustomerID = 'GREAL'"));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_34()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IEnumerable<Customer> custs = (from c in db.Customers
                                     where c.Region == "WA"
                                     select c);

      Console.WriteLine("Entity objects before ADO.NET change and Refresh() call:");
      foreach (Customer c in custs)
      {
        Console.WriteLine("Customer {0}'s region is {1}, country is {2}.",
          c.CustomerID, c.Region, c.Country);
      }

      Console.WriteLine("{0}Updating customers' country to United States in ADO.NET...",
        System.Environment.NewLine);
      ExecuteStatementInDb(String.Format(
        @"update Customers set Country = 'United States' where Region = 'WA'"));
      Console.WriteLine("Customers' country updated.{0}", System.Environment.NewLine);

      Console.WriteLine("Entity objects after ADO.NET change but before Refresh() call:");
      foreach (Customer c in custs)
      {
        Console.WriteLine("Customer {0}'s region is {1}, country is {2}.",
          c.CustomerID, c.Region, c.Country);
      }

      Customer[] custArray = custs.ToArray();
      Console.WriteLine("{0}Refreshing params array of customer entity objects ...",
        System.Environment.NewLine);
      db.Refresh(RefreshMode.KeepChanges, custArray[0], custArray[1], custArray[2]);
      Console.WriteLine("Params array of Customer entity objects refreshed.{0}",
        System.Environment.NewLine);

      Console.WriteLine("Entity objects after ADO.NET change and Refresh() call:");
      foreach (Customer c in custs)
      {
        Console.WriteLine("Customer {0}'s region is {1}, country is {2}.",
          c.CustomerID, c.Region, c.Country);
      }

      //  We need to reset the changed values so that the code can be run
      //  more than once.
      Console.WriteLine("{0}Resetting data to original values.",
        System.Environment.NewLine);
      ExecuteStatementInDb(String.Format(
        @"update Customers set Country = 'USA' where Region = 'WA'"));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing16_35()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IEnumerable<Customer> custs = (from c in db.Customers
                                     where c.Region == "WA"
                                     select c);

      Console.WriteLine("Entity objects before ADO.NET change and Refresh() call:");
      foreach (Customer c in custs)
      {
        Console.WriteLine("Customer {0}'s region is {1}, country is {2}.",
          c.CustomerID, c.Region, c.Country);
      }

      Console.WriteLine("{0}Updating customers' country to United States in ADO.NET...",
        System.Environment.NewLine);
      ExecuteStatementInDb(String.Format(
        @"update Customers set Country = 'United States' where Region = 'WA'"));
      Console.WriteLine("Customers' country updated.{0}", System.Environment.NewLine);

      Console.WriteLine("Entity objects after ADO.NET change but before Refresh() call:");
      foreach (Customer c in custs)
      {
        Console.WriteLine("Customer {0}'s region is {1}, country is {2}.",
          c.CustomerID, c.Region, c.Country);
      }

      Console.WriteLine("{0}Refreshing sequence of customer entity objects ...",
        System.Environment.NewLine);
      db.Refresh(RefreshMode.KeepChanges, custs);
      Console.WriteLine("Sequence of Customer entity objects refreshed.{0}",
        System.Environment.NewLine);

      Console.WriteLine("Entity objects after ADO.NET change and Refresh() call:");
      foreach (Customer c in custs)
      {
        Console.WriteLine("Customer {0}'s region is {1}, country is {2}.",
          c.CustomerID, c.Region, c.Country);
      }

      //  We need to reset the changed values so that the code can be run
      //  more than once.
      Console.WriteLine("{0}Resetting data to original values.",
        System.Environment.NewLine);
      ExecuteStatementInDb(String.Format(
        @"update Customers set Country = 'USA' where Region = 'WA'"));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static private string GetStringFromDb(
      System.Data.SqlClient.SqlConnection sqlConnection, string sqlQuery)
    {
      if (sqlConnection.State != System.Data.ConnectionState.Open)
      {
        sqlConnection.Open();
      }

      System.Data.SqlClient.SqlCommand sqlCommand =
        new System.Data.SqlClient.SqlCommand(sqlQuery, sqlConnection);

      System.Data.SqlClient.SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
      string result = null;

      try
      {
        if (!sqlDataReader.Read())
        {
          throw (new Exception(
            String.Format("Unexpected exception executing query [{0}].", sqlQuery)));
        }
        else
        {
          if (!sqlDataReader.IsDBNull(0))
          {
            result = sqlDataReader.GetString(0);
          }
        }
      }
      finally
      {
        // always call Close when done reading.
        sqlDataReader.Close();
      }

      return (result);
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

//  Used by Listing 16_9 and Listing 16-10.
namespace Linqdev
{
  public partial class Customer
  {
    private string _CustomerID;
    private string _CompanyName;
    private string _ContactName;
    private string _ContactTitle;
    private string _Address;
    private string _City;
    private string _Region;
    private string _PostalCode;
    private string _Country;
    private string _Phone;
    private string _Fax;

    public Customer()
    {
    }

    public string CustomerID
    {
      get
      {
        return this._CustomerID;
      }
      set
      {
        if ((this._CustomerID != value))
        {
          this._CustomerID = value;
        }
      }
    }

    public string CompanyName
    {
      get
      {
        return this._CompanyName;
      }
      set
      {
        if ((this._CompanyName != value))
        {
          this._CompanyName = value;
        }
      }
    }

    public string ContactName
    {
      get
      {
        return this._ContactName;
      }
      set
      {
        if ((this._ContactName != value))
        {
          this._ContactName = value;
        }
      }
    }

    public string ContactTitle
    {
      get
      {
        return this._ContactTitle;
      }
      set
      {
        if ((this._ContactTitle != value))
        {
          this._ContactTitle = value;
        }
      }
    }

    public string Address
    {
      get
      {
        return this._Address;
      }
      set
      {
        if ((this._Address != value))
        {
          this._Address = value;
        }
      }
    }

    public string City
    {
      get
      {
        return this._City;
      }
      set
      {
        if ((this._City != value))
        {
          this._City = value;
        }
      }
    }

    public string Region
    {
      get
      {
        return this._Region;
      }
      set
      {
        if ((this._Region != value))
        {
          this._Region = value;
        }
      }
    }

    public string PostalCode
    {
      get
      {
        return this._PostalCode;
      }
      set
      {
        if ((this._PostalCode != value))
        {
          this._PostalCode = value;
        }
      }
    }

    public string Country
    {
      get
      {
        return this._Country;
      }
      set
      {
        if ((this._Country != value))
        {
          this._Country = value;
        }
      }
    }

    public string Phone
    {
      get
      {
        return this._Phone;
      }
      set
      {
        if ((this._Phone != value))
        {
          this._Phone = value;
        }
      }
    }

    public string Fax
    {
      get
      {
        return this._Fax;
      }
      set
      {
        if ((this._Fax != value))
        {
          this._Fax = value;
        }
      }
    }
  }
}
