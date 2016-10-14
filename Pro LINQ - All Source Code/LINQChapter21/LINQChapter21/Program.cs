using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Data.EntityClient;
using System.Data.SqlClient;

namespace LINQChapter21 {
    class Program {
        static void Main(string[] args) {
            //  Uncomment the functions you want to call.
            //YourTest();

            //Listing21_1();
            //Listing21_2();
            //Listing21_3();
            //Listing21_4();
            //Listing21_5();
            //Listing21_6();
            //Listing21_7();
            //Listing21_8();
            //Listing21_9();
            //Listing21_10();
            //Listing21_11();
            //Listing21_12();
            //Listing21_13();
            //Listing21_14();
            //Listing21_15();
            //Listing21_16();
            //Listing21_17();
            //Listing21_18();
            //Listing21_19();
            //Listing21_20();
            //Listing21_21();
            //Listing21_22();
            //Listing21_23();

        }

        static void YourTest() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_1() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            IQueryable<Customer> custs = context.Customers
                .Where(c => c.City == "London")
                .Select(c => c);

            foreach (Customer cust in custs) {
                Console.WriteLine("Customer name: {0}", cust.CompanyName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_2() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string connectionString = "name=NorthwindEntities";

            NorthwindEntities context = new NorthwindEntities(connectionString);

            IQueryable<Customer> custs = context.Customers
                .Where(c => c.City == "London")
                .Select(c => c);

            foreach (Customer cust in custs) {
                Console.WriteLine("Customer name: {0}", cust.CompanyName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_3() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".\sqlexpress";
            scsb.InitialCatalog = "Northwind";
            scsb.IntegratedSecurity = true;
            scsb.MultipleActiveResultSets = true;

            EntityConnectionStringBuilder ecsb = new EntityConnectionStringBuilder();
            ecsb.Provider = "System.Data.SqlClient";
            ecsb.ProviderConnectionString = scsb.ToString();
            ecsb.Metadata = @"res://*/NorthwindEntityModel.csdl|
                    res://*/NorthwindEntityModel.ssdl
                    |res://*/NorthwindEntityModel.msl";

            NorthwindEntities context = new NorthwindEntities(ecsb.ToString());

            IQueryable<Customer> custs = context.Customers
                .Where(c => c.City == "London")
                .Select(c => c);

            foreach (Customer cust in custs) {
                Console.WriteLine("Customer name: {0}", cust.CompanyName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_4() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            bool databaseExists = context.DatabaseExists();

            Console.WriteLine("Database exists: {0}", databaseExists);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_5() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            if (context.DatabaseExists()) {
                context.DeleteDatabase();
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_6() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            if (!context.DatabaseExists()) {
                context.CreateDatabase();
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }


        static void Listing21_7() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            Customer cust = (from c in context.Customers
                             where c.CustomerID == "LAZYK"
                             select c).First();

            cust.ContactName = "John Doe";

            int modificationCount = context.SaveChanges();

            Console.WriteLine("Count: {0}", modificationCount);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_8() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            Customer cust = (from c in context.Customers
                             where c.CustomerID == "LAZYK"
                             select c).First();

            // refresh a single entity object
            context.Refresh(RefreshMode.StoreWins, cust);
            // refresh an entire collection of objects
            context.Refresh(RefreshMode.StoreWins, context.Customers);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }


        static void Listing21_9() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // create a new customer object
            Customer cust = Customer.CreateCustomer("LAWN", "Lawn Wranglers");

            // populate the nullable fields
            cust.ContactName = "Mr. Abe Henry";
            cust.ContactTitle = "Owner";
            cust.Address = "1017 Maple Leaf Way";
            cust.City = "Ft. Worth";
            cust.Region = "TX";
            cust.PostalCode = "76104";
            cust.Country = "USA";
            cust.Phone = "(800) MOW-LAWN";
            cust.Fax = "(800) MOW-LAWO";

            context.AddObject("Customers", cust);

            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_10() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // create a new customer object
            Customer cust = context.CreateObject<Customer>();
                
            // populate all of the fields
            cust.CustomerID = "LAWN";
            cust.CompanyName = "Lawn Wranglers";
            cust.ContactName = "Mr. Abe Henry";
            cust.ContactTitle = "Owner";
            cust.Address = "1017 Maple Leaf Way";
            cust.City = "Ft. Worth";
            cust.Region = "TX";
            cust.PostalCode = "76104";
            cust.Country = "USA";
            cust.Phone = "(800) MOW-LAWN";
            cust.Fax = "(800) MOW-LAWO";

            context.AddObject("Customers", cust);

            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_11() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // get the order details for order 10248
            IQueryable<Order_Detail> ods = (from o in context.Order_Details
                               where o.OrderID == 10248
                               select o);

            foreach (Order_Detail od in ods) {
                context.DeleteObject(od);
            }

            // save the changes
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_12() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // create a new customer object
            Customer cust = new Customer();

            // populate all of the fields
            cust.CustomerID = "LAWN";
            cust.CompanyName = "Lawn Wranglers";
            cust.ContactName = "Mr. Abe Henry";
            cust.ContactTitle = "Owner";
            cust.Address = "1017 Maple Leaf Way";
            cust.City = "Ft. Worth";
            cust.Region = "TX";
            cust.PostalCode = "76104";
            cust.Country = "USA";
            cust.Phone = "(800) MOW-LAWN";
            cust.Fax = "(800) MOW-LAWO";

            context.AddObject("Customers", cust);

            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_13() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // create a new customer object
            Customer cust = Customer.CreateCustomer("LAWN", "Lawn Wranglers");

            // populate the remaining fields
            cust.ContactName = "Mr. Abe Henry";
            cust.ContactTitle = "Owner";
            cust.Address = "1017 Maple Leaf Way";
            cust.City = "Ft. Worth";
            cust.Region = "TX";
            cust.PostalCode = "76104";
            cust.Country = "USA";
            cust.Phone = "(800) MOW-LAWN";
            cust.Fax = "(800) MOW-LAWO";

            context.AddObject("Customers", cust);

            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_14() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // query for a customer record
            Customer cust = (from c in context.Customers
                             where c.CustomerID == "LAZYK"
                             select c).First();

            // access the current data value
            Console.WriteLine("Original City Value: {0}", cust.City);

            // change the value
            cust.City = "Seattle";

            // write the new (but not persisted value)
            Console.WriteLine("New City Value: {0}", cust.City);

            // save the changes
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_15() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // query for the customer record
            Customer cust = (from c in context.Customers
                             where c.CompanyName == "Lazy K Kountry Store"
                             select c).First();

            // query for the orders placed by that company
            IQueryable<Order> orders = from o in context.Orders
                                       where o.CustomerID == cust.CustomerID
                                       select o;

            // print out the orders
            foreach (Order ord in orders) {
                Console.WriteLine("Order ID {0}, Date {1}", ord.OrderID, ord.OrderDate);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_16() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // query for the customer record
            Customer cust = (from c in context.Customers
                             where c.CompanyName == "Lazy K Kountry Store"
                             select c).First();

            EntityCollection<Order> orders = cust.Orders;

            foreach (Order ord in orders) {
                Console.WriteLine("Order ID: {0} Date: {1}", ord.OrderID, ord.OrderDate);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_17() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // query for the order
            Order ord = (from o in context.Orders
                         where o.CustomerID == "LAZYK"
                         select o).First();

            // get the entity reference
            EntityReference<Customer> customerRef = ord.CustomerReference;

            Console.WriteLine("Customer name: {0}", customerRef.Value.CompanyName);

            // get the customer via the convenience property
            Customer cust = ord.Customer;

            Console.WriteLine("Customer name: {0}", cust.CompanyName);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_18() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // disable lazy loading
            context.ContextOptions.LazyLoadingEnabled = false;

            // query for the order
            Order ord = (from o in context.Orders
                         where o.CustomerID == "LAZYK"
                         select o).First();

            // get the entity reference
            EntityReference<Customer> customerRef = ord.CustomerReference;

            // explicitly load the order
            customerRef.Load();

            Console.WriteLine("Customer name: {0}", customerRef.Value.CompanyName);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_19() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // get the LAZYK customer
            Customer cust1 = (from c in context.Customers
                             where c.CustomerID == "LAZYK"
                             select c).First();

            // get the AROUT customer
            Customer cust2 = (from c in context.Customers
                              where c.CustomerID == "AROUT"
                              select c).First();

            // get the first LAZY K order
            Order firstOrder = cust1.Orders.First();

            Console.WriteLine("First LAZYK Customer ID: {0}, Order ID: {1}", firstOrder.CustomerID, firstOrder.OrderID);

            // Add the LAZYK order to the AROUT orders set
            cust2.Orders.Add(firstOrder);

            Console.WriteLine("First LAZYK Customer ID: {0}, Order ID: {1}", firstOrder.CustomerID, firstOrder.OrderID);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_20() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // get the LAZYK customer
            Customer cust = (from c in context.Customers
                              where c.CustomerID == "LAZYK"
                              select c).First();

            // get the first LAZY K order
            Order order = cust.Orders.First();

            Console.WriteLine("Order has CustomerID of {0}", order.CustomerID);

            // remove the order from the collection
            Console.WriteLine("Removing order with ID: {0}", order.OrderID);
            cust.Orders.Remove(order);

            Console.WriteLine("Order has CustomerID of {0}", (order.CustomerID == null? 
                "NULL" : order.CustomerID));

            // save changes
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_21() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // get the LAZYK customer
            Customer cust = (from c in context.Customers
                             where c.CustomerID == "LAZYK"
                             select c).First();

            // clear the Orders collection
            cust.Orders.Clear();

            // save changes
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_22() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // get the LAZYK customer
            Customer cust = (from c in context.Customers
                             where c.CustomerID == "LAZYK"
                             select c).First();

            // get the first order for the customer
            Order ord = cust.Orders.First();

            // use the Contains method
            Console.WriteLine("Orders Contains Order {0}",
                cust.Orders.Contains(ord));

            // remove the orde from the collection
            Console.WriteLine("Removing order");
            cust.Orders.Remove(ord);

            // use the Contains method
            Console.WriteLine("Orders Contains Order {0}",
                cust.Orders.Contains(ord));

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing21_23() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            // get the LAZYK customer
            Customer cust = (from c in context.Customers
                             where c.CustomerID == "LAZYK"
                             select c).First();

            // Count the number of Orders
            Console.WriteLine("Number of Orders: {0}",
                cust.Orders.Count);

            // get the first order for the customer
            Order ord = cust.Orders.First();

            // remove the orde from the collection
            Console.WriteLine("Removing order");
            cust.Orders.Remove(ord);

            // Count the number of Orders
            Console.WriteLine("Number of Orders: {0}",
                cust.Orders.Count);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        # region common methods

        static private string GetStringFromDb(string sqlQuery) {

            string connection =
               @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";

            System.Data.SqlClient.SqlConnection sqlConn =
              new System.Data.SqlClient.SqlConnection(connection);


            if (sqlConn.State != ConnectionState.Open) {
                sqlConn.Open();
            }

            System.Data.SqlClient.SqlCommand sqlCommand =
              new System.Data.SqlClient.SqlCommand(sqlQuery, sqlConn);

            System.Data.SqlClient.SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            string result = null;

            try {
                if (!sqlDataReader.Read()) {
                    throw (new Exception(
                      String.Format("Unexpected exception executing query [{0}].", sqlQuery)));
                } else {
                    if (!sqlDataReader.IsDBNull(0)) {
                        result = sqlDataReader.GetString(0);
                    }
                }
            } finally {
                // always call Close when done reading.
                sqlDataReader.Close();
                sqlConn.Close();
            }

            return (result);
        }

        static private void ExecuteStatementInDb(string cmd) {
            string connection =
              @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";

            System.Data.SqlClient.SqlConnection sqlConn =
              new System.Data.SqlClient.SqlConnection(connection);

            if (sqlConn.State != ConnectionState.Open) {
                sqlConn.Open();
            }

            System.Data.SqlClient.SqlCommand sqlComm =
              new System.Data.SqlClient.SqlCommand(cmd);

            sqlComm.Connection = sqlConn;
            try {
                Console.WriteLine("Executing SQL statement against database with ADO.NET ...");
                sqlComm.ExecuteNonQuery();
                Console.WriteLine("Database updated.");
            } finally {
                //  Close the connection.
                sqlComm.Connection.Close();
            }
        }

        #endregion
    }
}
