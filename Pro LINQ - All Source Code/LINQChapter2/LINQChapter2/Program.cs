using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;

using Netsplore.Utilities;

namespace LINQChapter2
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing2_1();
      //Listing2_2();
      //Listing2_3();
      //Listing2_4();
      //Listing2_5();
      //Listing2_6();
      //Listing2_7();
      //Listing2_8();
      //Listing2_9();
      //Listing2_10();
      //Listing2_11();
      //Listing2_12();
      //Listing2_13();
      //Listing2_14();
      //Listing2_15();
      //Listing2_16();
      //Listing2_17();
      //Listing2_18();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

      int[] oddNums = Common.FilterArrayOfInts(nums, Application.IsOdd);

      foreach (int i in oddNums)
        Console.WriteLine(i);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

      int[] oddNums =
        Common.FilterArrayOfInts(nums, delegate(int i) { return ((i & 1) == 1); });

      foreach (int i in oddNums)
        Console.WriteLine(i);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

      int[] oddNums = Common.FilterArrayOfInts(nums, i => ((i & 1) == 1));

      foreach (int i in oddNums)
        Console.WriteLine(i);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  The line below is commented out so the code will compile for other examples.
      //var name;

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      var name = "Joe";    //  So far so good.
      //  The line below is commented out so the code will compile for other examples.
      //name = 1;            //  Uh oh.
      Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      var unnamedTypeVar = new { firstArg = 1, secondArg = "Joe" };
      Console.WriteLine(unnamedTypeVar.firstArg + ". " + unnamedTypeVar.secondArg);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_7()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Address address = new Address();
      address.address = "105 Elm Street";
      address.city = "Atlanta";
      address.state = "GA";
      address.postalCode = "30339";

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_8()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Address address = new Address
      {
        address = "105 Elm Street",
        city = "Atlanta",
        state = "GA",
        postalCode = "30339"
      };

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_9()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      List<string> presidents = new List<string> { "Adams", "Arthur", "Buchanan" };
      foreach (string president in presidents)
      {
        Console.WriteLine(president);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_10()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      var address = new
      {
        address = "105 Elm Street",
        city = "Atlanta",
        state = "GA",
        postalCode = "30339"
      };

      Console.WriteLine("address = {0} : city = {1} : state = {2} : zip = {3}",
        address.address, address.city, address.state, address.postalCode);

      Console.WriteLine("{0}", address.GetType().ToString());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_11()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string name = "Joe";
      Console.WriteLine(name.ToUpper());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_12()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  The line below is commented out so the code will compile for other examples.
      //string.ToUpper();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_13()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  The four lines below are commented out so the code will compile for other examples.
      //string firstName = "Joe";
      //string lastName = "Rattz";
      //string name = firstName.Format("{0} {1}", firstName, lastName);
      //Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_14()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string firstName = "Joe";
      string lastName = "Rattz";
      string name = string.Format("{0} {1}", firstName, lastName);
      Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_15()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      double pi = "3.1415926535".ToDouble();
      Console.WriteLine(pi);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_16()
    {
      // Make sure the class declaration for MyWidget in this module is commented out before
      // running this example the first time for when demonstrating what happens when partial
      // methods are not implemented.  Uncomment the MyWidget delcaration to see how this
      // example behaves when partial methods are implemented.
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      MyWidget myWidget = new MyWidget();

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_17()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] names = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> sequence = names
        .Where(n => n.Length < 6)
        .Select(n => n);

      foreach (string name in sequence)
      {
        Console.WriteLine("{0}", name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing2_18()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] names = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> sequence = from n in names
                                     where n.Length < 6
                                     select n;

      foreach (string name in sequence)
      {
        Console.WriteLine("{0}", name);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }
  }

  //  The following code is used in Listing2_1.
  public class Application
  {
    public static bool IsOdd(int i)
    {
      return ((i & 1) == 1);
    }
  }

  //  The following code is used in Listing2_1.
  public class Common
  {
    public delegate bool IntFilter(int i);

    public static int[] FilterArrayOfInts(int[] ints, IntFilter filter)
    {
      ArrayList aList = new ArrayList();
      foreach (int i in ints)
      {
        if (filter(i))
        {
          aList.Add(i);
        }
      }
      return ((int[])aList.ToArray(typeof(int)));
    }
  }

  //  The following code is used in Listing2_7, Listing2_8, and Listing2_9.
  public class Address
  {
    public string address;
    public string city;
    public string state;
    public string postalCode;
  }

  //  The following code is for Listing 2_16.
  //  It should be commented out to see how partial methods behave when they have not
  //  been implemented.  It should NOT be commented out to see how they behave when
  //  they are implemented.
  /*
  public partial class MyWidget
  {
    partial void MyWidgetStart(int count)
    {
      Console.WriteLine("In MyWidgetStart(count is {0})", count);
    }

    partial void MyWidgetEnd(int count)
    {
      Console.WriteLine("In MyWidgetEnd(count is {0})", count);
    }
  }
  */
}
