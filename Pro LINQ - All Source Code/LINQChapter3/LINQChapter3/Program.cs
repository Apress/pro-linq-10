using System;
using System.Collections.Generic;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;

namespace LINQChapter3
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing3_1();
      //Listing3_2();
      //Listing3_3();
      //Listing3_4();
      //Listing3_5();
      //Listing3_6();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing3_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string president = presidents.Where(p => p.StartsWith("Lin")).First();

      Console.WriteLine(president);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing3_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents.Where(p => p.StartsWith("A"));

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing3_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents.Where(s => Char.IsLower(s[4]));

      Console.WriteLine("After the query.");

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing3_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Create an array of ints.
      int[] intArray = new int[] { 1, 2, 3 };

      IEnumerable<int> ints = intArray.Select(i => i);

      //  Display the results.
      foreach (int i in ints)
        Console.WriteLine(i);

      // Change an element in the source data.
      intArray[0] = 5;

      Console.WriteLine("---------");

      //  Display the results again.
      foreach (int i in ints)
        Console.WriteLine(i);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing3_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Create an array of ints.
      int[] intArray = new int[] { 1, 2, 3 };

      List<int> ints = intArray.Select(i => i).ToList();

      //  Display the results.
      foreach (int i in ints)
        Console.WriteLine(i);

      // Change an element in the source data.
      intArray[0] = 5;

      Console.WriteLine("---------");

      //  Display the results again.
      foreach (int i in ints)
        Console.WriteLine(i);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing3_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Create an array of ints.
      int[] ints = new int[] { 1, 2, 3, 4, 5, 6 };

      //  Declare our delegate.
      Func<int, bool> GreaterThanTwo = i => i > 2;

      //  Perform the query ... not really.  Don't forget about deferred queries!!!
      IEnumerable<int> intsGreaterThanTwo = ints.Where(GreaterThanTwo);

      //  Display the results.
      foreach (int i in intsGreaterThanTwo)
        Console.WriteLine(i);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }
  }
}
