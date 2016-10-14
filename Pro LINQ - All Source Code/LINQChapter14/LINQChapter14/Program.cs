using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;

using nwind;


namespace LINQChapter14
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing14_1();
      //Listing14_2();
      //Listing14_3();
      //Listing14_4();
      //Listing14_5();
      //Listing14_6();
      //Listing14_7();
      //Listing14_8();
      //Listing14_9();
      //Listing14_10();
      //Listing14_11();
      //Listing14_12();
      //Listing14_13();
      //Listing14_14();
      //Listing14_15();
      //Listing14_16();
      //Listing14_17();
      //Listing14_18();
      //Listing14_19();
      //Listing14_20();
      //Listing14_21();  //  Please read the warning above the method before running this example.
      //Listing14_22();
      //Listing14_23();
      //Listing14_24();
      //Listing14_25();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind");
      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  1.  Create the DataContext.
      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      //  2.  Instantiate an entity object.
      Customer cust =
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
        };

      //  3.  Add the entity object to the Customers table.
      db.Customers.InsertOnSubmit(cust);

      //  4.  Call the SubmitChanges method.
      db.SubmitChanges();

      //  Query the record.
      Customer customer = db.Customers.Where(c => c.CustomerID == "LAWN").First();
      Console.WriteLine("{0} - {1}", customer.CompanyName, customer.ContactName);

      //  This part of the code merely resets the database so the example can be
      //  run more than once.
      Console.WriteLine("Deleting the added customer LAWN.");
      db.Customers.DeleteOnSubmit(cust);
      db.SubmitChanges();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Customer cust = (from c in db.Customers
                       where c.CustomerID == "LONEP"
                       select c).Single<Customer>();

      //  Used to query record back out.
      DateTime now = DateTime.Now;

      Order order = new Order
      {
        CustomerID = cust.CustomerID,
        EmployeeID = 4,
        OrderDate = now,
        RequiredDate = DateTime.Now.AddDays(7),
        ShipVia = 3,
        Freight = new Decimal(24.66),
        ShipName = cust.CompanyName,
        ShipAddress = cust.Address,
        ShipCity = cust.City,
        ShipRegion = cust.Region,
        ShipPostalCode = cust.PostalCode,
        ShipCountry = cust.Country
      };

      cust.Orders.Add(order);

      db.SubmitChanges();

      IEnumerable<Order> orders =
        db.Orders.Where(o => o.CustomerID == "LONEP" && o.OrderDate.Value == now);

      foreach (Order o in orders)
      {
        Console.WriteLine("{0} {1}", o.OrderDate, o.ShipName);
      }

      //  This part of the code merely resets the database so the example can be
      //  run more than once.
      db.Orders.DeleteOnSubmit(order);
      db.SubmitChanges();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Customer cust =
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
          Fax = "(800) MOW-LAWO",
          Orders = {
            new Order {
              CustomerID = "LAWN",
              EmployeeID = 4,
              OrderDate = DateTime.Now,
              RequiredDate = DateTime.Now.AddDays(7),
              ShipVia = 3,
              Freight = new Decimal(24.66),
              ShipName = "Lawn Wranglers",
              ShipAddress = "1017 Maple Leaf Way",
              ShipCity = "Ft. Worth",
              ShipRegion = "TX",
              ShipPostalCode = "76104",
              ShipCountry = "USA"
            }
          }
        };

      db.Customers.InsertOnSubmit(cust);
      db.SubmitChanges();

      Customer customer = db.Customers.Where(c => c.CustomerID == "LAWN").First();
      Console.WriteLine("{0} - {1}", customer.CompanyName, customer.ContactName);
      foreach (Order order in customer.Orders)
      {
        Console.WriteLine("{0} - {1}", order.CustomerID, order.OrderDate);
      }

      //  This part of the code merely resets the database so the example can be
      //  run more than once.
      db.Orders.DeleteOnSubmit(cust.Orders.First());
      db.Customers.DeleteOnSubmit(cust);
      db.SubmitChanges();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Customer cust = (from c in db.Customers
                       where c.CustomerID == "LONEP"
                       select c).Single<Customer>();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Customer cust = (from c in db.Customers
                       where c.CustomerID == "LONEP"
                       select c).Single<Customer>();

      Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IQueryable<Customer> custs = from c in db.Customers
                                   where c.City == "London"
                                   select c;

      foreach (Customer cust in custs)
      {
        Console.WriteLine("Customer: {0}", cust.CompanyName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_7()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IQueryable<Customer> custs = from c in db.Customers
                                   where c.Country == "UK" &&
                                     c.City == "London"
                                   orderby c.CustomerID
                                   select c;

      foreach (Customer cust in custs)
      {
        Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
        foreach (Order order in cust.Orders)
        {
          Console.WriteLine("    {0} {1}", order.OrderID, order.OrderDate);
        }
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_8()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IQueryable<Customer> custs = from c in db.Customers
                                   where c.Country == "UK" &&
                                     c.City == "London"
                                   orderby c.CustomerID
                                   select c;

      //  Turn on the logging.
      db.Log = Console.Out;

      foreach (Customer cust in custs)
      {
        Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
        foreach (Order order in cust.Orders)
        {
          Console.WriteLine("    {0} {1}", order.OrderID, order.OrderDate);
        }
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_9()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      DataLoadOptions dlo = new DataLoadOptions();
      dlo.LoadWith<Customer>(c => c.Orders);
      db.LoadOptions = dlo;

      IQueryable<Customer> custs = (from c in db.Customers
                                    where c.Country == "UK" &&
                                      c.City == "London"
                                    orderby c.CustomerID
                                    select c);
      //  Turn on the logging.
      db.Log = Console.Out;

      foreach (Customer cust in custs)
      {
        Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_10()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      DataLoadOptions dlo = new DataLoadOptions();
      dlo.LoadWith<Customer>(c => c.Orders);
      dlo.LoadWith<Customer>(c => c.CustomerCustomerDemos);
      db.LoadOptions = dlo;

      IQueryable<Customer> custs = (from c in db.Customers
                                    where c.Country == "UK" &&
                                      c.City == "London"
                                    orderby c.CustomerID
                                    select c);
      //  Turn on the logging.
      db.Log = Console.Out;

      foreach (Customer cust in custs)
      {
        Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_11()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      DataLoadOptions dlo = new DataLoadOptions();
      dlo.LoadWith<Customer>(c => c.Orders);
      dlo.LoadWith<Order>(o => o.OrderDetails);
      db.LoadOptions = dlo;

      IQueryable<Customer> custs = (from c in db.Customers
                                    where c.Country == "UK" &&
                                      c.City == "London"
                                    orderby c.CustomerID
                                    select c);
      //  Turn on the logging.
      db.Log = Console.Out;

      foreach (Customer cust in custs)
      {
        Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_12()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      DataLoadOptions dlo = new DataLoadOptions();
      dlo.AssociateWith<Customer>(c => from o in c.Orders 
                                       where o.OrderID < 10700 
                                       orderby o.OrderDate descending 
                                       select o);
      db.LoadOptions = dlo;

      IQueryable<Customer> custs = from c in db.Customers
                                   where c.Country == "UK" &&
                                     c.City == "London"
                                   orderby c.CustomerID
                                   select c;

      foreach (Customer cust in custs)
      {
        Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
        foreach (Order order in cust.Orders)
        {
          Console.WriteLine("    {0} {1}", order.OrderID, order.OrderDate);
        }
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_13()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      var entities = from s in db.Suppliers
                     join c in db.Customers on s.City equals c.City
                     select new
                     {
                       SupplierName = s.CompanyName,
                       CustomerName = c.CompanyName,
                       City = c.City
                     };

      foreach (var e in entities)
      {
        Console.WriteLine("{0}: {1} - {2}", e.City, e.SupplierName, e.CustomerName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_14()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      db.Log = Console.Out;

      var entities =
        from s in db.Suppliers
        join c in db.Customers on s.City equals c.City into temp
        from t in temp.DefaultIfEmpty()
        select new
        {
          SupplierName = s.CompanyName,
          CustomerName = t.CompanyName,
          City = s.City
        };

      foreach (var e in entities)
      {
        Console.WriteLine("{0}: {1} - {2}", e.City, e.SupplierName, e.CustomerName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_15()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      var entities = from s in db.Suppliers
                     join c in db.Customers on s.City equals c.City into temp
                     from t in temp.DefaultIfEmpty()
                     select new { s, t };

      foreach (var e in entities)
      {
        Console.WriteLine("{0}: {1} - {2}", e.s.City,
          e.s.CompanyName,
          e.t != null ? e.t.CompanyName : "");
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_16()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      //  Turn on the logging.
      db.Log = Console.Out;

      //  Pretend the values below are not hardcoded, but instead, obtained by accessing 
      //  a dropdown list's selected value.
      string dropdownListCityValue = "Cowes";
      string dropdownListCountryValue = "UK";

      IQueryable<Customer> custs = (from c in db.Customers
                                    select c);

      if (!dropdownListCityValue.Equals("[ALL]"))
      {
        custs = from c in custs
                where c.City == dropdownListCityValue
                select c;
      }

      if (!dropdownListCountryValue.Equals("[ALL]"))
      {
        custs = from c in custs
                where c.Country == dropdownListCountryValue
                select c;
      }

      foreach (Customer cust in custs)
      {
        Console.WriteLine("{0} - {1} - {2}", cust.CompanyName, cust.City, cust.Country);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_17()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      //  Turn on the logging.
      db.Log = Console.Out;

      //  Pretend the values below are not hardcoded, but instead, obtained by accessing 
      //  a dropdown list's selected value.
      string dropdownListCityValue = "[ALL]";
      string dropdownListCountryValue = "UK";

      IQueryable<Customer> custs = (from c in db.Customers
                                    select c);

      if (!dropdownListCityValue.Equals("[ALL]"))
      {
        custs = from c in custs
                where c.City == dropdownListCityValue
                select c;
      }

      if (!dropdownListCountryValue.Equals("[ALL]"))
      {
        custs = from c in custs
                where c.Country == dropdownListCountryValue
                select c;
      }

      foreach (Customer cust in custs)
      {
        Console.WriteLine("{0} - {1} - {2}", cust.CompanyName, cust.City, cust.Country);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_18()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      db.Log = Console.Out;

      string[] cities = { "London", "Madrid" };

      IQueryable<Customer> custs = db.Customers.Where(c => cities.Contains(c.City));

      foreach (Customer cust in custs)
      {
        Console.WriteLine("{0} - {1}", cust.CustomerID, cust.City);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_19()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Order order = (from o in db.Orders
                     where o.EmployeeID == 5
                     orderby o.OrderDate descending
                     select o).First<Order>();

      //  Save off the current employee so I can reset it at the end.
      Employee origEmployee = order.Employee;

      Console.WriteLine("Before changing the employee.");
      Console.WriteLine("OrderID = {0} : OrderDate = {1} : EmployeeID = {2}",
        order.OrderID, order.OrderDate, order.Employee.EmployeeID);

      Employee emp = (from e in db.Employees
                      where e.EmployeeID == 9
                      select e).Single<Employee>();

      //  Now I will assign the new employee to the order.
      order.Employee = emp;

      db.SubmitChanges();

      Order order2 = (from o in emp.Orders
                      where o.OrderID == order.OrderID
                      select o).First<Order>();

      Console.WriteLine("{0}After changing the employee.", System.Environment.NewLine);
      Console.WriteLine("OrderID = {0} : OrderDate = {1} : EmployeeID = {2}",
        order2.OrderID, order2.OrderDate, order2.Employee.EmployeeID);

      //  Now I need to reverse the changes so the example can be run multiple times.
      order.Employee = origEmployee;
      db.SubmitChanges();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_20()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Order order = (from o in db.Orders
                     where o.EmployeeID == 5
                     orderby o.OrderDate descending
                     select o).First<Order>();

      //  Save off the current employee so I can reset it at the end.
      Employee origEmployee = order.Employee;

      Console.WriteLine("Before changing the employee.");
      Console.WriteLine("OrderID = {0} : OrderDate = {1} : EmployeeID = {2}",
        order.OrderID, order.OrderDate, order.Employee.EmployeeID);

      Employee emp = (from e in db.Employees
                      where e.EmployeeID == 9
                      select e).Single<Employee>();

      //  Remove the order from the original employee's Orders.
      origEmployee.Orders.Remove(order);

      //  Now add it to the new employee's orders.
      emp.Orders.Add(order);

      db.SubmitChanges();

      Console.WriteLine("{0}After changing the employee.", System.Environment.NewLine);
      Console.WriteLine("OrderID = {0} : OrderDate = {1} : EmployeeID = {2}",
        order.OrderID, order.OrderDate, order.Employee.EmployeeID);

      //  Now I need to reverse the changes so the example can be run multiple times.
      order.Employee = origEmployee;
      db.SubmitChanges();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    /*
     * Warning	Unlike all the other examples in this chapter, this example will not restore
     * the database at the end.  This is because one of the tables involved contains an 
     * identity column, and it is not a simple matter to programmatically restore the data 
     * to its identical state prior to the example executing.  Therefore, before running this
     * example, make sure you have a backup of your database that you can restore from.  If 
     * you downloaded the zipped extended version of the Northwind database, after running 
     * this example you could just detach the Northwind database, re-extract the database 
     * files, and re-attach the database.
     */
    static void Listing14_21()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      //  Retrieve a customer to delete.
      Customer customer = (from c in db.Customers
                           where c.CompanyName == "Alfreds Futterkiste"
                           select c).Single<Customer>();

      db.OrderDetails.DeleteAllOnSubmit(
        customer.Orders.SelectMany(o => o.OrderDetails));
      db.Orders.DeleteAllOnSubmit(customer.Orders);
      db.Customers.DeleteOnSubmit(customer);

      db.SubmitChanges();

      Customer customer2 = (from c in db.Customers
                            where c.CompanyName == "Alfreds Futterkiste"
                            select c).SingleOrDefault<Customer>();

      Console.WriteLine("Customer {0} found.", customer2 != null ? "is" : "is not");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_22()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      //  Retrieve an order to unrelate.
      Order order = (from o in db.Orders
                     where o.OrderID == 11043
                     select o).Single<Order>();

      //  Save off the original customer so I can set it back.
      Customer c = order.Customer;

      Console.WriteLine("Orders before deleting the relationship:");
      foreach (Order ord in c.Orders)
      {
        Console.WriteLine("OrderID = {0}", ord.OrderID);
      }

      //  Remove the relationship to the customer.
      order.Customer = null;
      db.SubmitChanges();

      Console.WriteLine("{0}Orders after deleting the relationship:",
        System.Environment.NewLine);
      foreach (Order ord in c.Orders)
      {
        Console.WriteLine("OrderID = {0}", ord.OrderID);
      }

      //  Restore the database back to its original state.
      order.Customer = c;
      db.SubmitChanges();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_23()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      Shipper ship = (from s in db.Shippers
                      where s.ShipperID == 1
                      select s).Single<Shipper>();

      ship.CompanyName = "Jiffy Shipping";

      Shipper newShip =
        new Shipper
        {
          ShipperID = 4,
          CompanyName = "Vickey Rattz Shipping",
          Phone = "(800) SHIP-NOW"
        };

      db.Shippers.InsertOnSubmit(newShip);

      Shipper deletedShip = (from s in db.Shippers
                             where s.ShipperID == 3
                             select s).Single<Shipper>();

      db.Shippers.DeleteOnSubmit(deletedShip);

      db.SubmitChanges();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_24()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IQueryable<Customer> custs = from c in db.Customers
                                   where c.CustomerID.TrimEnd('K') == "LAZY"
                                   select c;

      foreach (Customer c in custs)
      {
        Console.WriteLine("{0}", c.CompanyName);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing14_25()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      IQueryable<Customer> custs = from c in db.Customers
                                   where c.CustomerID == "LAZY".TrimEnd('K')
                                   select c;

      foreach (Customer c in custs)
      {
        Console.WriteLine("{0}", c.CompanyName);
      }

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
