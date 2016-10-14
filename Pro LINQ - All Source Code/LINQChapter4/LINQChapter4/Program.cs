using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;

using nwind;


namespace LINQChapter4
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing4_1();
      //Listing4_2();
      //Listing4_3();
      //Listing4_4();
      //Listing4_5();
      //Listing4_6();
      //Listing4_7();
      //Listing4_8();
      //Listing4_9();
      //Listing4_10();
      //Listing4_11();
      //Listing4_12();
      //Listing4_13();
      //Listing4_14();
      //Listing4_15();
      //Listing4_16();
      //Listing4_17();
      //Listing4_18();
      //Listing4_19();
      //Listing4_20();
      //Listing4_21();
      //Listing4_22();
      //Listing4_23();
      //Listing4_24();
      //Listing4_25();
      //Listing4_26();
      //Listing4_27();
      //Listing4_28();
      //Listing4_29();
      //Listing4_30();
      //Listing4_31();
      //Listing4_32();
      //Listing4_33();
      //Listing4_34();
      //Listing4_35();
      //Listing4_36();
      //Listing4_37();
      //Listing4_38();
      //Listing4_39();
      //Listing4_40();
      //Listing4_41();
      //Listing4_42();
      //Listing4_43();
      //Listing4_44();
      //Listing4_45();
      //Listing4_46();
      //Listing4_47();
      //Listing4_48();
      //Listing4_49();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};


      IEnumerable<string> sequence = presidents.Where(p => p.StartsWith("J"));

      foreach (string s in sequence)
        Console.WriteLine("{0}", s);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};


      IEnumerable<string> sequence = presidents.Where((p, i) => (i & 1) == 1);

      foreach (string s in sequence)
        Console.WriteLine("{0}", s);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<int> nameLengths = presidents.Select(p => p.Length);

      foreach (int item in nameLengths)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      var nameObjs = presidents.Select(p => new { p, p.Length });

      foreach (var item in nameObjs)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      var nameObjs = presidents.Select(p => new { LastName = p, Length = p.Length });

      foreach (var item in nameObjs)
        Console.WriteLine("{0} is {1} characters long.", item.LastName, item.Length);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      var nameObjs = presidents.Select((p, i) => new { Index = i, LastName = p });

      foreach (var item in nameObjs)
        Console.WriteLine("{0}.  {1}", item.Index + 1, item.LastName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_7()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<char> chars = presidents.SelectMany(p => p.ToArray());

      foreach (char ch in chars)
        Console.WriteLine(ch);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_8()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Employee[] employees = Employee.GetEmployeesArray();
      EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

      var employeeOptions = employees
        .SelectMany(e => empOptions
                           .Where(eo => eo.id == e.id)
                           .Select(eo => new
                           {
                             id = eo.id,
                             optionsCount = eo.optionsCount
                           }));

      foreach (var item in employeeOptions)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_9()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<char> chars = presidents
        .SelectMany((p, i) => i < 5 ? p.ToArray() : new char[] { });

      foreach (char ch in chars)
        Console.WriteLine(ch);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_10()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents.Take(5);

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_11()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<char> chars = presidents.Take(5).SelectMany(s => s.ToArray());

      foreach (char ch in chars)
        Console.WriteLine(ch);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_12()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents.TakeWhile(s => s.Length < 10);

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_13()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents
        .TakeWhile((s, i) => s.Length < 10 && i < 5);

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_14()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents.Skip(1);

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_15()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents.SkipWhile(s => s.StartsWith("A"));

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_16()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents
        .SkipWhile((s, i) => s.Length > 4 && i < 10);

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_17()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents.Take(5).Concat(presidents.Skip(5));

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_18()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = new[] {
                                    presidents.Take(5),
                                    presidents.Skip(5)
                                  }
                                  .SelectMany(s => s);

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_19()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents.OrderBy(s => s.Length);

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_20()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      //  We are going to instantiate my comparer ahead of time so we can keep a
      //  reference so we can call the GetVowelConsonantCount() method later
      //  for display purposes.
      MyVowelToConsonantRatioComparer myComp = new MyVowelToConsonantRatioComparer();

      IEnumerable<string> namesByVToCRatio = presidents
        .OrderBy((s => s), myComp);

      foreach (string item in namesByVToCRatio)
      {
        int vCount = 0;
        int cCount = 0;

        myComp.GetVowelConsonantCount(item, ref vCount, ref cCount);
        double dRatio = (double)vCount / (double)cCount;

        Console.WriteLine(item + " - " + dRatio + " - " + vCount + ":" + cCount);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_21()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents.OrderByDescending(s => s);

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_22()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      //  I am going to instantiate my comparer ahead of time so I can keep a
      //  reference so I can call the GetVowelConsonantCount() method later
      //  for display purposes.
      MyVowelToConsonantRatioComparer myComp = new MyVowelToConsonantRatioComparer();

      IEnumerable<string> namesByVToCRatio = presidents
        .OrderByDescending((s => s), myComp);

      foreach (string item in namesByVToCRatio)
      {
        int vCount = 0;
        int cCount = 0;

        myComp.GetVowelConsonantCount(item, ref vCount, ref cCount);
        double dRatio = (double)vCount / (double)cCount;

        Console.WriteLine(item + " - " + dRatio + " - " + vCount + ":" + cCount);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_23()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents.OrderBy(s => s.Length).ThenBy(s => s);

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_24()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      //  I am going to instantiate my comparer ahead of time so I can keep a
      //  reference so I can call the GetVowelConsonantCount() method later
      //  for display purposes.
      MyVowelToConsonantRatioComparer myComp = new MyVowelToConsonantRatioComparer();

      IEnumerable<string> namesByVToCRatio = presidents
        .OrderBy(n => n.Length)
        .ThenBy((s => s), myComp);

      foreach (string item in namesByVToCRatio)
      {
        int vCount = 0;
        int cCount = 0;

        myComp.GetVowelConsonantCount(item, ref vCount, ref cCount);
        double dRatio = (double)vCount / (double)cCount;

        Console.WriteLine(item + " - " + dRatio + " - " + vCount + ":" + cCount);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_25()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items =
        presidents.OrderBy(s => s.Length).ThenByDescending(s => s);

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_26()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      //  I am going to instantiate my comparer ahead of time so I can keep a
      //  reference so I can call the GetVowelConsonantCount() method later
      //  for display purposes.
      MyVowelToConsonantRatioComparer myComp = new MyVowelToConsonantRatioComparer();

      IEnumerable<string> namesByVToCRatio = presidents
        .OrderBy(n => n.Length)
        .ThenByDescending((s => s), myComp);

      foreach (string item in namesByVToCRatio)
      {
        int vCount = 0;
        int cCount = 0;

        myComp.GetVowelConsonantCount(item, ref vCount, ref cCount);
        double dRatio = (double)vCount / (double)cCount;

        Console.WriteLine(item + " - " + dRatio + " - " + vCount + ":" + cCount);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_27()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> items = presidents.Reverse();

      foreach (string item in items)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_28()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Employee[] employees = Employee.GetEmployeesArray();
      EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

      //  Remember, the first argument of the prototype is the outer sequence, which will 
      //  be the sequence we call join on.  In this case, the employees array is the outer
      //  sequence.
      var employeeOptions = employees
        .Join(
          empOptions,	    //  inner sequence
          e => e.id, 		  //  outerKeySelector
          o => o.id, 		  //  innerKeySelector
          (e, o) => new   //  resultSelector
          {
            id = e.id,
            name = string.Format("{0} {1}", e.firstName, e.lastName),
            options = o.optionsCount
          });

      foreach (var item in employeeOptions)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_29()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Employee[] employees = Employee.GetEmployeesArray();
      EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

      var employeeOptions = employees
        .GroupJoin(
          empOptions,
          e => e.id,
          o => o.id,
          (e, os) => new
          {
            id = e.id,
            name = string.Format("{0} {1}", e.firstName, e.lastName),
            options = os.Sum(o => o.optionsCount)
          });

      foreach (var item in employeeOptions)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_30()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();
      IEnumerable<IGrouping<int, EmployeeOptionEntry>> outerSequence =
        empOptions.GroupBy(o => o.id);

      //  First enumerate through the outer sequence of IGroupings.
      foreach (IGrouping<int, EmployeeOptionEntry> keyGroupSequence in outerSequence)
      {
        Console.WriteLine("Option records for employee: " + keyGroupSequence.Key);

        //  Now enumerate through the grouping's sequence of EmployeeOptionEntry elements.
        foreach (EmployeeOptionEntry element in keyGroupSequence)
          Console.WriteLine("id={0} : optionsCount={1} : dateAwarded={2:d}",
            element.id, element.optionsCount, element.dateAwarded);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_31()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Instead of instantiating the comparer on the fly, I am going
      //  to keep a reference to is because I will use its isFounder()
      //  method on the group's key for header display purposes.
      MyFounderNumberComparer comp = new MyFounderNumberComparer();

      EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();
      IEnumerable<IGrouping<int, EmployeeOptionEntry>> opts = empOptions
        .GroupBy(o => o.id, comp);

      //  First enumerate through the sequence of IGroupings.
      foreach (IGrouping<int, EmployeeOptionEntry> keyGroup in opts)
      {
        Console.WriteLine("Option records for: " +
          (comp.isFounder(keyGroup.Key) ? "founder" : "non-founder"));

        //  Now enumerate through the grouping's sequence of EmployeeOptionEntry elements.
        foreach (EmployeeOptionEntry element in keyGroup)
          Console.WriteLine("id={0} : optionsCount={1} : dateAwarded={2:d}",
            element.id, element.optionsCount, element.dateAwarded);
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_32()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();
      IEnumerable<IGrouping<int, DateTime>> opts = empOptions
        .GroupBy(o => o.id, e => e.dateAwarded);

      //  First enumerate through the sequence of IGroupings.
      foreach (IGrouping<int, DateTime> keyGroup in opts)
      {
        Console.WriteLine("Option records for employee: " + keyGroup.Key);

        //  Now enumerate through the grouping's sequence of DateTime elements.
        foreach (DateTime date in keyGroup)
          Console.WriteLine(date.ToShortDateString());
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_33()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Instead of instantiating the comparer on the fly, I am going
      //  to keep a reference to is because I will use its isFounder()
      //  method on the group's key for header display purposes.
      MyFounderNumberComparer comp = new MyFounderNumberComparer();
      EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();
      IEnumerable<IGrouping<int, DateTime>> opts = empOptions
        .GroupBy(o => o.id, o => o.dateAwarded, comp);

      //  First enumerate through the sequence of IGroupings.
      foreach (IGrouping<int, DateTime> keyGroup in opts)
      {
        Console.WriteLine("Option records for: " +
          (comp.isFounder(keyGroup.Key) ? "founder" : "non-founder"));

        //  Now enumerate through the grouping's sequence of EmployeeOptionEntry elements.
        foreach (DateTime date in keyGroup)
          Console.WriteLine(date.ToShortDateString());
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_34()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      //  Display the count of the presidents array.
      Console.WriteLine("presidents count:  " + presidents.Count());

      //  Concatenate presidents with itself.  Now each element should 
      //  be in the sequence twice.
      IEnumerable<string> presidentsWithDupes = presidents.Concat(presidents);
      //  Display the count of the concatenated sequence.
      Console.WriteLine("presidentsWithDupes count:  " + presidentsWithDupes.Count());

      //  Eliminate the duplicates and display the count.
      IEnumerable<string> presidentsDistinct = presidentsWithDupes.Distinct();
      Console.WriteLine("presidentsDistinct count:  " + presidentsDistinct.Count());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_35()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> first = presidents.Take(5);
      IEnumerable<string> second = presidents.Skip(4);
      //  Since I only skipped 4 elements, the fifth element 
      //  should be in both sequences.

      IEnumerable<string> concat = first.Concat<string>(second);
      IEnumerable<string> union = first.Union<string>(second);

      Console.WriteLine("The count of the presidents array is: " + presidents.Count());
      Console.WriteLine("The count of the first sequence is: " + first.Count());
      Console.WriteLine("The count of the second sequence is: " + second.Count());
      Console.WriteLine("The count of the concat sequence is: " + concat.Count());
      Console.WriteLine("The count of the union sequence is: " + union.Count());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_36()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      IEnumerable<string> first = presidents.Take(5);
      IEnumerable<string> second = presidents.Skip(4);
      //  Since I only skipped 4 elements, the fifth element 
      //  should be in both sequences.

      IEnumerable<string> intersect = first.Intersect(second);

      Console.WriteLine("The count of the presidents array is: " + presidents.Count());
      Console.WriteLine("The count of the first sequence is: " + first.Count());
      Console.WriteLine("The count of the second sequence is: " + second.Count());
      Console.WriteLine("The count of the intersect sequence is: " + intersect.Count());

      //  Just for kicks, I will display the intersection sequence,
      //  which should be just the fifth element.
      foreach (string name in intersect)
        Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_37()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      //  First generate a processed sequence.
      IEnumerable<string> processed = presidents.Take(4);

      IEnumerable<string> exceptions = presidents.Except(processed);
      foreach (string name in exceptions)
        Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_38()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      ArrayList employees = Employee.GetEmployeesArrayList();
      Console.WriteLine("The data type of employees is " + employees.GetType());

      var seq = employees.Cast<Employee>();
      Console.WriteLine("The data type of seq is " + seq.GetType());

      var emps = seq.OrderBy(e => e.lastName);
      foreach (Employee emp in emps)
        Console.WriteLine("{0} {1}", emp.firstName, emp.lastName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_39()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      ArrayList al = new ArrayList();
      al.Add(new Employee { id = 1, firstName = "Joe", lastName = "Rattz" });
      al.Add(new Employee { id = 2, firstName = "William", lastName = "Gates" });
      al.Add(new EmployeeOptionEntry { id = 1, optionsCount = 0 });
      al.Add(new EmployeeOptionEntry { id = 2, optionsCount = 99999999999 });
      al.Add(new Employee { id = 3, firstName = "Anders", lastName = "Hejlsberg" });
      al.Add(new EmployeeOptionEntry { id = 3, optionsCount = 848475745 });

      //  First I will demonstrate the Cast Operator's weakness.
      var items = al.Cast<Employee>();

      Console.WriteLine("Attempting to use the Cast operator ...");
      //  Notice that I am starting the try after the actuall call to the OfType operator.
      //  I can get away with that because the operator is deferred.
      try
      {
        foreach (Employee item in items)
          Console.WriteLine("{0} {1} {2}", item.id, item.firstName, item.lastName);
      }
      catch (Exception ex)
      {
        Console.WriteLine("{0}{1}", ex.Message, System.Environment.NewLine);
      }

      //  Now let's try using OfType.
      Console.WriteLine("Attempting to use the OfType operator ...");
      var items2 = al.OfType<Employee>();
      //  I am so confident, I am not even wrapping in a try/catch.
      foreach (Employee item in items2)
        Console.WriteLine("{0} {1} {2}", item.id, item.firstName, item.lastName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_40()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      var custs =
        (from c in db.Customers
         where c.City == "Rio de Janeiro"
         select c)
        .Reverse();

      foreach (var cust in custs)
        Console.WriteLine("{0}", cust.CompanyName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_41()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Northwind db = new Northwind(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;");

      var custs =
        (from c in db.Customers
         where c.City == "Rio de Janeiro"
         select c)
        .AsEnumerable()
        .Reverse();

      foreach (var cust in custs)
        Console.WriteLine("{0}", cust.CompanyName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_42()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string jones = presidents.Where(n => n.Equals("Jones")).First();
      if (jones != null)
        Console.WriteLine("Jones was found");
      else
        Console.WriteLine("Jones was not found");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_43()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string jones = presidents.Where(n => n.Equals("Jones")).DefaultIfEmpty().First();
      if (jones != null)
        Console.WriteLine("Jones was found.");
      else
        Console.WriteLine("Jones was not found.");
    }

    static void Listing4_44()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name =
        presidents.Where(n => n.Equals("Jones")).DefaultIfEmpty("Missing").First();
      Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_45()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      ArrayList employeesAL = Employee.GetEmployeesArrayList();
      //  Add a new employee so one employee will have no EmployeeOptionEntry records.
      employeesAL.Add(new Employee
      {
        id = 102,
        firstName = "Michael",
        lastName = "Bolton"
      });
      Employee[] employees = employeesAL.Cast<Employee>().ToArray();
      EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

      var employeeOptions = employees
        .GroupJoin(
          empOptions,
          e => e.id,
          o => o.id,
          (e, os) => os
            .Select(o => new
            {
              id = e.id,
              name = string.Format("{0} {1}", e.firstName, e.lastName),
              options = o != null ? o.optionsCount : 0
            }))
        .SelectMany(r => r);

      foreach (var item in employeeOptions)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_46()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      ArrayList employeesAL = Employee.GetEmployeesArrayList();
      //  Add a new employee so one employee will have no EmployeeOptionEntry records.
      employeesAL.Add(new Employee
      {
        id = 102,
        firstName = "Michael",
        lastName = "Bolton"
      });
      Employee[] employees = employeesAL.Cast<Employee>().ToArray();
      EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

      var employeeOptions = employees
        .GroupJoin(
          empOptions,
          e => e.id,
          o => o.id,
          (e, os) => os
            .DefaultIfEmpty()
            .Select(o => new
            {
              id = e.id,
              name = string.Format("{0} {1}", e.firstName, e.lastName),
              options = o != null ? o.optionsCount : 0
            }))
        .SelectMany(r => r);

      foreach (var item in employeeOptions)
        Console.WriteLine(item);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_47()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      IEnumerable<int> ints = Enumerable.Range(1, 10);
      foreach (int i in ints)
        Console.WriteLine(i);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_48()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      IEnumerable<int> ints = Enumerable.Repeat(2, 10);
      foreach (int i in ints)
        Console.WriteLine(i);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing4_49()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      IEnumerable<string> strings = Enumerable.Empty<string>();
      foreach (string s in strings)
        Console.WriteLine(s);
      Console.WriteLine(strings.Count());

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }
  }

  //  This class will be used by several examples.
  public class Employee
  {
    public int id;
    public string firstName;
    public string lastName;

    public static ArrayList GetEmployeesArrayList()
    {
      ArrayList al = new ArrayList();

      al.Add(new Employee { id = 1, firstName = "Joe", lastName = "Rattz" });
      al.Add(new Employee { id = 2, firstName = "William", lastName = "Gates" });
      al.Add(new Employee { id = 3, firstName = "Anders", lastName = "Hejlsberg" });
      al.Add(new Employee { id = 4, firstName = "David", lastName = "Lightman" });
      al.Add(new Employee { id = 101, firstName = "Kevin", lastName = "Flynn" });
      return (al);
    }

    public static Employee[] GetEmployeesArray()
    {
      return ((Employee[])GetEmployeesArrayList().ToArray(typeof(Employee)));
    }
  }

  //  This class will be used by several examples.
  public class EmployeeOptionEntry
  {
    public int id;
    public long optionsCount;
    public DateTime dateAwarded;

    public static EmployeeOptionEntry[] GetEmployeeOptionEntries()
    {
      EmployeeOptionEntry[] empOptions = new EmployeeOptionEntry[] {
        new EmployeeOptionEntry { 
          id = 1, 
          optionsCount = 2, 
          dateAwarded = DateTime.Parse("1999/12/31") },
        new EmployeeOptionEntry { 
          id = 2, 
          optionsCount = 10000, 
          dateAwarded = DateTime.Parse("1992/06/30")  },
        new EmployeeOptionEntry { 
          id = 2, 
          optionsCount = 10000, 
          dateAwarded = DateTime.Parse("1994/01/01")  },
        new EmployeeOptionEntry { 
          id = 3, 
          optionsCount = 5000, 
          dateAwarded = DateTime.Parse("1997/09/30") },
        new EmployeeOptionEntry { 
          id = 2, 
          optionsCount = 10000, 
          dateAwarded = DateTime.Parse("2003/04/01")  },
        new EmployeeOptionEntry { 
          id = 3, 
          optionsCount = 7500, 
          dateAwarded = DateTime.Parse("1998/09/30") },
        new EmployeeOptionEntry { 
          id = 3, 
          optionsCount = 7500, 
          dateAwarded = DateTime.Parse("1998/09/30") },
        new EmployeeOptionEntry { 
          id = 4, 
          optionsCount = 1500, 
          dateAwarded = DateTime.Parse("1997/12/31") },
        new EmployeeOptionEntry { 
          id = 101, 
          optionsCount = 2, 
          dateAwarded = DateTime.Parse("1998/12/31") }
      };

      return (empOptions);
    }
  }

  //  This class is used by Listing4_20. 
  public class MyVowelToConsonantRatioComparer : IComparer<string>
  {
    public int Compare(string s1, string s2)
    {
      int vCount1 = 0;
      int cCount1 = 0;
      int vCount2 = 0;
      int cCount2 = 0;

      GetVowelConsonantCount(s1, ref vCount1, ref cCount1);
      GetVowelConsonantCount(s2, ref vCount2, ref cCount2);

      double dRatio1 = (double)vCount1 / (double)cCount1;
      double dRatio2 = (double)vCount2 / (double)cCount2;

      if (dRatio1 < dRatio2)
        return (-1);
      else if (dRatio1 > dRatio2)
        return (1);
      else
        return (0);
    }

    //  This method is public so my code using this comparer can get the values 
    //  if it wants.
    public void GetVowelConsonantCount(string s,
                                       ref int vowelCount,
                                       ref int consonantCount)
    {
      //  DISCLAIMER:  This code is for demonstation purposes only.
      //  This code treats the letter 'y' or 'Y' as a vowel always,
      //  which linguistically speaking, is probably invalid.

      string vowels = "AEIOUY";

      //  Initialize the counts.
      vowelCount = 0;
      consonantCount = 0;

      //  Convert to upper case so we are case insensitive.
      string sUpper = s.ToUpper();

      foreach (char ch in sUpper)
      {
        if (vowels.IndexOf(ch) < 0)
          consonantCount++;
        else
          vowelCount++;
      }

      return;
    }
  }

  //  This class is used by Listing4_31 and Listing4_33. 
  public class MyFounderNumberComparer : IEqualityComparer<int>
  {
    public bool Equals(int x, int y)
    {
      return (isFounder(x) == isFounder(y));
    }

    public int GetHashCode(int i)
    {
      int f = 1;
      int nf = 100;
      return (isFounder(i) ? f.GetHashCode() : nf.GetHashCode());
    }

    public bool isFounder(int id)
    {
      return (id < 100);
    }
  }
}
