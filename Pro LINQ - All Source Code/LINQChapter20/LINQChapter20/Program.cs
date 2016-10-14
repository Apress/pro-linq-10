using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;

namespace LINQChapter20 {
    class Program {
        static void Main(string[] args) {
            //  Uncomment the functions you want to call.
            //YourTest();

            //Listing20_1();
            //Listing20_2();
            //Listing20_3();
            //Listing20_4();
            //Listing20_5();
            //Listing20_6();
            //Listing20_7();
            //Listing20_8();
            //Listing20_9();
            //Listing20_10();
            //Listing20_11();
            //Listing20_12();
            //Listing20_13();
            //Listing20_14();
            //Listing20_15();
            //Listing20_16();
            //Listing20_17();
            //Listing20_18();
            //Listing20_19();
            //Listing20_20();
            //Listing20_21();
            //Listing20_22();
            //Listing20_23();
            //Listing20_24();
            //Listing20_25();
            //Listing20_26();
            //Listing20_27();
            //Listing20_28();
            //Listing20_29();
        }

        static void YourTest() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }



        static void Listing20_1() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // step 1. Create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // Step 2. Create a new customer object
            Customer cust = new Customer() {
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

            // Step 3. Add to the ObjectSet<Customer>
            context.Customers.AddObject(cust);

            // Step 4. Save the changes
            context.SaveChanges();

            //  Query the record.
            Customer customer = context.Customers.Where(c => c.CustomerID == "LAWN").First();
            Console.WriteLine("{0} - {1}", customer.CompanyName, customer.ContactName);

            //  Reset the database so the example can be run more than once.
            Console.WriteLine("Deleting the added customer LAWN.");
            context.DeleteObject(customer);
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_2() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
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

            // add the new customer to the Customers ObjectSet
            context.Customers.AddObject(cust);

            // save the changes
            context.SaveChanges();

            //  Query the record.
            Customer customer = context.Customers.Where(c => c.CustomerID == "LAWN").First();
            Console.WriteLine("{0} - {1}", customer.CompanyName, customer.ContactName);

            //  Reset the database so the example can be run more than once.
            Console.WriteLine("Deleting the added customer LAWN.");
            context.DeleteObject(customer);
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_3() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            Customer cust = new Customer {
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

            // add the new Customer 
            context.Customers.AddObject(cust);

            // save the changes
            context.SaveChanges();

            // query to make sure the record is there
            Customer customer = context.Customers.Where(c => c.CustomerID == "LAWN").First();
            Console.WriteLine("{0} - {1}", customer.CompanyName, customer.ContactName);
            foreach (Order order in customer.Orders) {
                Console.WriteLine("{0} - {1}", order.CustomerID, order.OrderDate);
            }

            //  This part of the code resets the database 
            context.DeleteObject(cust);
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_4() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // create the new customer
            Customer cust = new Customer {
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

            // create the new order
            Order ord = new Order {
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
            };

            // attach the order to the customer
            cust.Orders.Add(ord);

            // add the new Customer 
            context.Customers.AddObject(cust);

            // save the changes
            context.SaveChanges();

            // query to make sure the record is there
            Customer customer = context.Customers.Where(c => c.CustomerID == "LAWN").First();
            Console.WriteLine("{0} - {1}", customer.CompanyName, customer.ContactName);
            foreach (Order order in customer.Orders) {
                Console.WriteLine("{0} - {1}", order.CustomerID, order.OrderDate);
            }

            //  This part of the code resets the database 
            context.DeleteObject(cust);
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_5() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // create the new customer
            Customer cust = new Customer {
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

            // create the new order
            Order ord = new Order {
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
            };

            // attach the customer to the order
            ord.Customer = cust;

            // add the new Order to the context
            context.Orders.AddObject(ord);

            // save the changes
            context.SaveChanges();

            // query to make sure the record is there
            Customer customer = context.Customers.Where(c => c.CustomerID == "LAWN").First();
            Console.WriteLine("{0} - {1}", customer.CompanyName, customer.ContactName);
            Console.WriteLine("Customer has {0} orders", customer.Orders.Count());

            //  This part of the code resets the database 
            context.DeleteObject(ord);
            context.DeleteObject(cust);
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_6() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            IQueryable<Customer> custs = from c in context.Customers
                                         where c.City == "London"
                                         select c;

            foreach (Customer cust in custs) {
                Console.WriteLine("Customer: {0}", cust.CompanyName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_7() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // query for London-based customers
            IQueryable<Customer> londonCustomers = from customer in context.Customers
                                                   where customer.City == "LONDON"
                                                   select customer;
            // print out the names of the london customers
            foreach (Customer cust in londonCustomers) {
                Console.WriteLine("London customer: {0}", cust.CompanyName);
            }

            // query for Paris-based customers
            IQueryable<Customer> parisCustomers = from customer in context.Customers
                                                  where customer.City == "PARIS"
                                                  select customer;
            // print out the names of the Paris customers
            foreach (Customer cust in parisCustomers) {
                Console.WriteLine("Paris customer: {0}", cust.CompanyName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }


        static void Listing20_8() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // define the compiled query
            Func<NorthwindEntities, string, IQueryable<Customer>> compiledQuery
                = CompiledQuery.Compile<NorthwindEntities, string, IQueryable<Customer>>(
                    (ctx, city) =>
                        from customer in ctx.Customers
                        where customer.City == city
                        select customer);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // define the cities we are interested in
            string[] cities = new string[] { "London", "Paris" };

            // call the compiled query for each city
            foreach (string city in cities) {
                IQueryable<Customer> custs = compiledQuery(context, city);
                foreach (Customer cust in custs) {
                    Console.WriteLine("{0} customer: {1}", city, cust.CompanyName);
                }
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_9() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // query for London-based customers
            IQueryable<Customer> londonCustomers = from customer in context.Customers
                                                   where customer.City == "LONDON"
                                                   select customer;

            // ensure that the database connection is open
            if (context.Connection.State != ConnectionState.Open) {
                context.Connection.Open();
            }

            // display the sql statement
            string sqlStatement = (londonCustomers as ObjectQuery).ToTraceString();
            Console.WriteLine(sqlStatement);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_10() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            IQueryable<Customer> custs = from c in context.Customers
                                         where c.Country == "UK" &&
                                           c.City == "London"
                                         orderby c.CustomerID
                                         select c;

            foreach (Customer cust in custs) {
                Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
                Order firstOrder = cust.Orders.First();
                Console.WriteLine("    {0}", firstOrder.OrderID);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }


        static void Listing20_11() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            IQueryable<Customer> custs = from c in context.Customers
                                         .Include("Orders")
                                         where c.Country == "UK" &&
                                           c.City == "London"
                                         orderby c.CustomerID
                                         select c;

            foreach (Customer cust in custs) {
                Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
                Order firstOrder = cust.Orders.First();
                Console.WriteLine("    {0}", firstOrder.OrderID);
            }


            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_12() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            IQueryable<Order> orders = context.Orders
                .Include("Shipper")
                .Include("Customer")
                .Where(c => c.ShipCountry == "France")
                .Select(c => c);

            foreach (Order ord in orders) {
                Console.WriteLine("OrderID: {0}, Shipper: {1}, Contact: {2}",
                    ord.OrderID,
                    ord.Shipper.CompanyName,
                    ord.Customer.ContactName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_13() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // disable lazy loading
            context.ContextOptions.LazyLoadingEnabled = false;

            IQueryable<Customer> custs = context.Customers
                .Where(c => c.Country == "UK" && c.City == "London")
                .OrderBy(c => c.CustomerID)
                .Select(c => c);

            // explicitly load the orders for each customer
            foreach (Customer cust in custs) {
                if (cust.CompanyName != "North/South") {
                    cust.Orders.Load();
                }
            }

            foreach (Customer cust in custs) {
                Console.WriteLine("{0} - {1}", cust.CompanyName, cust.ContactName);
                // check to see that the order data is loaded for this customer
                if (cust.Orders.IsLoaded) {
                    Order firstOrder = cust.Orders.First();
                    Console.WriteLine("    {0}", firstOrder.OrderID);
                } else {
                    Console.WriteLine("   No order data loaded");
                }
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_14() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            IQueryable<Customer_and_Suppliers_by_City> res
                = context.Customer_and_Suppliers_by_Cities
                .Where(c => c.City == "LONDON")
                .Select(c => c);

            foreach (Customer_and_Suppliers_by_City r in res) {
                Console.WriteLine("{0}, {1}", r.CompanyName, r.ContactName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_15() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            IEnumerable<Customers_By_City_Result> custs = context.Customers_By_City("London");

            foreach (Customers_By_City_Result cust in custs) {
                Console.WriteLine("{0}, {1}", cust.CompanyName, cust.ContactName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_16() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            var entities = from s in context.Suppliers
                           join c in context.Customers on s.City equals c.City
                           select new {
                               SupplierName = s.CompanyName,
                               CustomerName = c.CompanyName,
                               City = c.City
                           };

            foreach (var e in entities) {
                Console.WriteLine("{0}: {1} - {2}", e.City, e.SupplierName, e.CustomerName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_17() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            var entities =
              from s in context.Suppliers
              join c in context.Customers on s.City equals c.City into temp
              from t in temp.DefaultIfEmpty()
              select new {
                  SupplierName = s.CompanyName,
                  CustomerName = t.CompanyName,
                  City = s.City
              };

            foreach (var e in entities) {
                Console.WriteLine("{0}: {1} - {2}", e.City, e.SupplierName, e.CustomerName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_18() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            //  Retrieve customer LAZYK.
            Customer cust = (from c in context.Customers
                             where c.CustomerID == "LAZYK"
                             select c).Single<Customer>();

            //  Update the contact name.
            cust.ContactName = "Ned Plimpton";

            // save the changes
            context.SaveChanges();

            // restore the database
            cust.ContactName = "John Steel";
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_19() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            Order order = (from o in context.Orders
                           where o.EmployeeID == 5
                           orderby o.OrderDate descending
                           select o).First<Order>();

            //  Save off the current employee so we can reset it at the end.
            Employee origEmployee = order.Employee;

            Console.WriteLine("Before changing the employee.");
            Console.WriteLine("OrderID = {0} : OrderDate = {1} : EmployeeID = {2}",
              order.OrderID, order.OrderDate, order.Employee.EmployeeID);

            Employee emp = (from e in context.Employees
                            where e.EmployeeID == 9
                            select e).Single<Employee>();

            //  Now we will assign the new employee to the order.
            order.Employee = emp;

            context.SaveChanges();

            Order order2 = (from o in emp.Orders
                            where o.OrderID == order.OrderID
                            select o).First<Order>();

            Console.WriteLine("{0}After changing the employee.", System.Environment.NewLine);
            Console.WriteLine("OrderID = {0} : OrderDate = {1} : EmployeeID = {2}",
              order2.OrderID, order2.OrderDate, order2.Employee.EmployeeID);

            //  Now we need to reverse the changes so the example can be run multiple times.
            order.Employee = origEmployee;
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_20() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // get the order details for order 10248
            IQueryable<Order_Detail> ods = from o in context.Order_Details
                                           where o.OrderID == 10248
                                           select o;

            // print out the query results
            Console.WriteLine("Before deletion");
            foreach (Order_Detail od in ods) {
                Console.WriteLine("Order detail {0}, {1}, {2}",
                    od.ProductID, od.UnitPrice, od.Quantity);
            }

            // delete the first order detail
            context.DeleteObject(ods.First());

            // save the changes
            context.SaveChanges();

            // print out the query results
            Console.WriteLine("After deletion");
            foreach (Order_Detail od in ods) {
                Console.WriteLine("Order detail {0}, {1}, {2}",
                    od.ProductID, od.UnitPrice, od.Quantity);
            }             

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_21() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // get the order details for order 10248
            IQueryable<Order_Detail> ods = from o in context.Order_Details
                                           where o.OrderID == 10248
                                           select o;

            // print out the query results
            Console.WriteLine("Before deletion");
            foreach (Order_Detail od in ods) {
                Console.WriteLine("Order detail {0}, {1}, {2}",
                    od.ProductID, od.UnitPrice, od.Quantity);
            }

            // delete the first order detail
            context.Order_Details.DeleteObject(ods.First());

            // save the changes
            context.SaveChanges();

            // print out the query results
            Console.WriteLine("After deletion");
            foreach (Order_Detail od in ods) {
                Console.WriteLine("Order detail {0}, {1}, {2}",
                    od.ProductID, od.UnitPrice, od.Quantity);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_22() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // query for the first order for LAZYK
            Order firstOrder = context.Orders
                .Where(o => o.CustomerID == "LAZYK")
                .Select(o => o)
                .First();

            // delete the order
            context.DeleteObject(firstOrder);

            // save the changes
            context.SaveChanges();
                              
            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_23() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // query for the first order for LAZYK
            Order firstOrder = context.Orders
                .Where(o => o.OrderID == 10248)
                .Select(o => o)
                .First();

            // delete the Order_Detail objects for the order 
            foreach (Order_Detail od in firstOrder.Order_Details.ToArray()) {
                Console.WriteLine("Deleting order detail {0}, {1}, {2}, {3}",
                    od.OrderID, od.ProductID, od.UnitPrice, od.Quantity);
                context.DeleteObject(od);
            }

            // delete the order
            context.DeleteObject(firstOrder);

            // save the changes
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_24() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // query for the order
            Order firstOrder = context.Orders
                .Where(o => o.OrderID == 10248)
                .Select(o => o)
                .First();

            // delete the order
            context.DeleteObject(firstOrder);

            // save the changes
            context.SaveChanges();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_25() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            Customer cust = context.Customers
                .Where(c => c.CustomerID == "LAZYK")
                .Select(c => c)
                .First();

            Console.WriteLine("Initial value {0}", cust.ContactName);

            // change the record outside of the entity framework
            ExecuteStatementInDb(String.Format(
                    @"update Customers 
                    set ContactName = 'Samuel Arthur Sanders' 
                    where CustomerID = 'LAZYK'"));

            // get the database value outside of the Entity Framework
            string dbValue = GetStringFromDb(String.Format(
                @"select ContactName from Customers
                where CustomerID = 'LAZYK'"));

            Console.WriteLine("Database value: {0}", dbValue);

            // modify the customer 
            cust.ContactName = "John Doe";

            // save the changes
            context.SaveChanges();

            Console.WriteLine("Final value: {0}", cust.ContactName);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_26() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            Customer cust = context.Customers
                .Where(c => c.CustomerID == "LAZYK")
                .Select(c => c)
                .First();

            Console.WriteLine("Initial value {0}", cust.ContactName);

            // change the record outside of the entity framework
            ExecuteStatementInDb(String.Format(
                    @"update Customers 
                    set ContactName = 'Samuel Arthur Sanders' 
                    where CustomerID = 'LAZYK'"));

            // modify the customer 
            cust.ContactName = "John Doe";

            // save the changes
            try {
                context.SaveChanges();
            } catch (OptimisticConcurrencyException) {
                Console.WriteLine("Detected concurrency conflict - giving up");
            } finally {
                string dbValue = GetStringFromDb(String.Format(
                    @"select ContactName from Customers
                where CustomerID = 'LAZYK'"));
                Console.WriteLine("Database value: {0}", dbValue);
                Console.WriteLine("Cached value: {0}", cust.ContactName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }


        static void Listing20_27() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            Customer cust = context.Customers
                .Where(c => c.CustomerID == "LAZYK")
                .Select(c => c)
                .First();

            Console.WriteLine("Initial value {0}", cust.ContactName);

            // change the record outside of the entity framework
            ExecuteStatementInDb(String.Format(
                    @"update Customers 
                    set ContactName = 'Samuel Arthur Sanders' 
                    where CustomerID = 'LAZYK'"));

            // modify the customer 
            cust.ContactName = "John Doe";

            // save the changes
            try {
                context.SaveChanges();
            } catch (OptimisticConcurrencyException) {
                Console.WriteLine("Detected concurrency conflict - refreshing data");
                context.Refresh(RefreshMode.StoreWins, cust);
            } finally {
                string dbValue = GetStringFromDb(String.Format(
                    @"select ContactName from Customers
                where CustomerID = 'LAZYK'"));
                Console.WriteLine("Database value: {0}", dbValue);
                Console.WriteLine("Cached value: {0}", cust.ContactName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_28() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            Customer cust = context.Customers
                .Where(c => c.CustomerID == "LAZYK")
                .Select(c => c)
                .First();

            Console.WriteLine("Initial value {0}", cust.ContactName);

            // change the record outside of the entity framework
            ExecuteStatementInDb(String.Format(
                    @"update Customers 
                    set ContactName = 'Samuel Arthur Sanders' 
                    where CustomerID = 'LAZYK'"));

            // modify the customer 
            cust.ContactName = "John Doe";

            // save the changes
            try {
                context.SaveChanges();
            } catch (OptimisticConcurrencyException) {
                Console.WriteLine("Detected concurrency conflict - refreshing data");
                context.Refresh(RefreshMode.ClientWins, cust);
                context.SaveChanges();
            } finally {
                string dbValue = GetStringFromDb(String.Format(
                    @"select ContactName from Customers
                where CustomerID = 'LAZYK'"));
                Console.WriteLine("Database value: {0}", dbValue);
                Console.WriteLine("Cached value: {0}", cust.ContactName);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing20_29() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            Customer cust = context.Customers
                .Where(c => c.CustomerID == "LAZYK")
                .Select(c => c)
                .First();

            Console.WriteLine("Initial value {0}", cust.ContactName);

            // change the record outside of the entity framework
            ExecuteStatementInDb(String.Format(
                    @"update Customers 
                    set ContactName = 'Samuel Arthur Sanders' 
                    where CustomerID = 'LAZYK'"));

            // modify the customer 
            cust.ContactName = "John Doe";

            int maxAttempts = 5;
            bool recordsUpdated = false;

            for (int i = 0; i < maxAttempts && !recordsUpdated; i++) {
                Console.WriteLine("Performing write attempt {0}", i);
                // save the changes
                try {
                    context.SaveChanges();
                    recordsUpdated = true;
                } catch (OptimisticConcurrencyException) {
                    Console.WriteLine("Detected concurrency conflict - refreshing data");
                    context.Refresh(RefreshMode.ClientWins, cust);
                }
            }

            string dbValue = GetStringFromDb(String.Format(
                @"select ContactName from Customers
                where CustomerID = 'LAZYK'"));
            Console.WriteLine("Database value: {0}", dbValue);
            Console.WriteLine("Cached value: {0}", cust.ContactName);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

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
    }
}
