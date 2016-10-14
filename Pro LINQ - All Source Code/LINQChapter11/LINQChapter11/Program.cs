using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;

namespace LINQChapter11
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing11_1();
      //Listing11_2();
      //Listing11_3();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing11_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      StudentsDataSet studentsDataSet = new StudentsDataSet();
      studentsDataSet.Students.AddStudentsRow(1, "Joe Rattz");
      studentsDataSet.Students.AddStudentsRow(7, "Anthony Adams");
      studentsDataSet.Students.AddStudentsRow(13, "Stacy Sinclair");
      studentsDataSet.Students.AddStudentsRow(72, "Dignan Stephens");

      string name =
        studentsDataSet.Students.Where(student => student.Id == 7).Single().Name;

      Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing11_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string connectionString =
        @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";

      SqlDataAdapter dataAdapter = new SqlDataAdapter(
        @"SELECT O.EmployeeID, E.FirstName + ' ' + E.LastName as EmployeeName, 
          O.CustomerID, C.CompanyName, O.ShipCountry
          FROM Orders O
          JOIN Employees E on O.EmployeeID = E.EmployeeID
          JOIN Customers C on O.CustomerID = C.CustomerID",
        connectionString);

      DataSet dataSet = new DataSet();
      dataAdapter.Fill(dataSet, "EmpCustShip");

      //  All code prior to this comment is legacy code.

      var ordersQuery = dataSet.Tables["EmpCustShip"].AsEnumerable()
        .Where(r => r.Field<string>("ShipCountry").Equals("Germany"))
        .Distinct(System.Data.DataRowComparer.Default)
        .OrderBy(r => r.Field<string>("EmployeeName"))
        .ThenBy(r => r.Field<string>("CompanyName"));

      foreach (var dataRow in ordersQuery)
      {
        Console.WriteLine("{0,-20} {1,-20}", dataRow.Field<string>("EmployeeName"),
          dataRow.Field<string>("CompanyName"));
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing11_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string connectionString =
        @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";

      SqlDataAdapter dataAdapter = new SqlDataAdapter(
        @"SELECT O.EmployeeID, E.FirstName + ' ' + E.LastName as EmployeeName, 
          O.CustomerID, C.CompanyName, O.ShipCountry
          FROM Orders O
          JOIN Employees E on O.EmployeeID = E.EmployeeID
          JOIN Customers C on O.CustomerID = C.CustomerID",
        connectionString);

      DataSet dataSet = new DataSet();
      dataAdapter.Fill(dataSet, "EmpCustShip");

      //  All code prior to this comment is legacy code.

      var ordersQuery = (from r in dataSet.Tables["EmpCustShip"].AsEnumerable()
                         where r.Field<string>("ShipCountry").Equals("Germany")
                         orderby r.Field<string>("EmployeeName"),
                           r.Field<string>("CompanyName")
                         select r)
                        .Distinct(System.Data.DataRowComparer.Default);

      foreach (var dataRow in ordersQuery)
      {
        Console.WriteLine("{0,-20} {1,-20}", dataRow.Field<string>("EmployeeName"),
          dataRow.Field<string>("CompanyName"));
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }
  }
}
