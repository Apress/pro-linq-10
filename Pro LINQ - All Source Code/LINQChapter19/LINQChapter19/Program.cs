using System;
using System.Data;
using System.Data.Objects;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;

namespace LINQChapter19 {
    class Program {
        static void Main(string[] args) {
            //  Uncomment the functions you want to call.
            //YourTest();

            //Listing19_1();
            
        }

        static void YourTest() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            NorthwindEntities context = new NorthwindEntities();

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing19_1() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the ObjectContext
            NorthwindEntities context = new NorthwindEntities();

            // retrieve customer LAZY K
            Customer cust = (from c in context.Customers
                             where c.CustomerID == "LAZYK"
                             select c).Single<Customer>();

            // Update the contact name
            cust.ContactName = "Ned Plimpton";

            // save the changes 
            try {
                context.SaveChanges();
            } catch (OptimisticConcurrencyException) {
                context.Refresh(RefreshMode.ClientWins, 
                    context.Customers);
                context.SaveChanges();
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

       

     
    }
}
