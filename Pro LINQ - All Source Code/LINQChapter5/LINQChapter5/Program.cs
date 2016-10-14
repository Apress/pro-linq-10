using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;

namespace LINQChapter5
{
  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing5_1();
      //Listing5_2();
      //Listing5_3();
      //Listing5_4();
      //Listing5_5();
      //Listing5_6();
      //Listing5_7();
      //Listing5_8();
      //Listing5_9();
      //Listing5_10();
      //Listing5_11();
      //Listing5_12();
      //Listing5_13();
      //Listing5_14();
      //Listing5_15();
      //Listing5_16();
      //Listing5_17();
      //Listing5_18();
      //Listing5_19();
      //Listing5_20();
      //Listing5_21();
      //Listing5_22();
      //Listing5_23();
      //Listing5_24();
      //Listing5_25();
      //Listing5_26();
      //Listing5_27();
      //Listing5_28();
      //Listing5_29();
      //Listing5_30();
      //Listing5_31();
      //Listing5_32();
      //Listing5_33();
      //Listing5_34();
      //Listing5_35();
      //Listing5_36();
      //Listing5_37();
      //Listing5_38();
      //Listing5_39();
      //Listing5_40();
      //Listing5_41();
      //Listing5_42();
      //Listing5_43();
      //Listing5_44();
      //Listing5_45();
      //Listing5_46();
      //Listing5_47();
      //Listing5_48();
      //Listing5_49();
      //Listing5_50();
      //Listing5_51();
      //Listing5_52();
      //Listing5_53();
      //Listing5_54();
      //Listing5_55();
      //Listing5_56();
      //Listing5_57();
      //Listing5_58();
      //Listing5_59();
      //Listing5_60();
      //Listing5_61();
      //Listing5_62();
      //Listing5_63();
      //Listing5_64();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string[] names = presidents.OfType<string>().ToArray();

      foreach (string name in names)
        Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      List<string> names = presidents.ToList();

      foreach (string name in names)
        Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  My dictionary is going to be of type Dictionary<int, Employee> because 
      //  I am going to use the Employee.id field as the key, which is of type int,
      //  and I am going to store the entire Employee object as the element.
      Dictionary<int, Employee> eDictionary =
        Employee.GetEmployeesArray().ToDictionary(k => k.id);

      Employee e = eDictionary[2];
      Console.WriteLine("Employee whose id == 2 is {0} {1}", e.firstName, e.lastName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  My dictionary is going to be of type Dictionary<string, Employee2> because
      //  I am going to use the Employee2.id field as the key, which is of type string,
      //  and I am going to store the entire Employee2 object as the element.
      Dictionary<string, Employee2> eDictionary = Employee2.GetEmployeesArray()
        .ToDictionary(k => k.id, new MyStringifiedNumberComparer());

      Employee2 e = eDictionary["2"];
      Console.WriteLine("Employee whose id == \"2\" : {0} {1}",
        e.firstName, e.lastName);

      e = eDictionary["000002"];
      Console.WriteLine("Employee whose id == \"000002\" : {0} {1}",
        e.firstName, e.lastName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  My dictionary is going to be of type Dictionary<int, string> because
      //  I am going to use the Employee.id field as the key, which is of type int,
      //  and I am going to store a concatenation of the firstName and lastName as 
      //  the element.
      Dictionary<int, string> eDictionary = Employee.GetEmployeesArray()
        .ToDictionary(k => k.id,
                      i => string.Format("{0} {1}",   //  elementSelector
                        i.firstName, i.lastName));

      string name = eDictionary[2];
      Console.WriteLine("Employee whose id == 2 is {0}", name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  My dictionary is going to be of type Dictionary<string, string> because
      //  I am going to use the Employee.id field as the key, which is of type string,
      //  and I am going to store firstName and lastName concatenated as the value.
      Dictionary<string, string> eDictionary = Employee2.GetEmployeesArray()
        .ToDictionary(k => k.id,                           //  keySelector
                      i => string.Format("{0} {1}",        //  elementSelector 
                        i.firstName, i.lastName),
                      new MyStringifiedNumberComparer());  //  comparer

      string name = eDictionary["2"];
      Console.WriteLine("Employee whose id == \"2\" : {0}", name);

      name = eDictionary["000002"];
      Console.WriteLine("Employee whose id == \"000002\" : {0}", name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_7()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  My Lookup is going to be of type ILookup<int, Actor> because I am 
      //  going to use the Actor.birthYear field as the key, which is of type int,
      //  and I am going to store the entire Actor object as the stored value.
      ILookup<int, Actor> lookup = Actor.GetActors().ToLookup(k => k.birthYear);

      //  Let's see if I can find the 'one' born in 1964.
      IEnumerable<Actor> actors = lookup[1964];
      foreach (var actor in actors)
        Console.WriteLine("{0} {1}", actor.firstName, actor.lastName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_8()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  My Lookup is going to be of type ILookup<string, Actor2> because I am 
      //  going to use the Actor2.birthYear field as the key, which is of type string,
      //  and I am going to store the entire Actor2 object as the stored value.
      ILookup<string, Actor2> lookup = Actor2.GetActors()
        .ToLookup(k => k.birthYear, new MyStringifiedNumberComparer());

      //  Let's see if I can find the 'one' born in 1964.
      IEnumerable<Actor2> actors = lookup["0001964"];
      foreach (var actor in actors)
        Console.WriteLine("{0} {1}", actor.firstName, actor.lastName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_9()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  My Lookup is going to be of type ILookup<int, string> because I am
      //  going to use the Actor.birthYear field as the key, which is of type int,
      //  and I am going to store the firstName and lastName concatenated
      //  together as the stored value.
      ILookup<int, string> lookup = Actor.GetActors()
        .ToLookup(k => k.birthYear,
                  a => string.Format("{0} {1}", a.firstName, a.lastName));

      //  Let's see if I can find the 'one' born in 1964.
      IEnumerable<string> actors = lookup[1964];
      foreach (var actor in actors)
        Console.WriteLine("{0}", actor);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_10()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  My Lookup is going to be of type ILookup<string, string> because I am 
      //  going to use the Actor2.birthYear field as the key, which is of type string,
      //  and I am going to store the firstName and lastName concatenated together,
      //  which is a string, as the stored value.
      ILookup<string, string> lookup = Actor2.GetActors()
        .ToLookup(k => k.birthYear,
                  a => string.Format("{0} {1}", a.firstName, a.lastName),
                  new MyStringifiedNumberComparer());

      //  Let's see if I can find the 'one' born in 1964.
      IEnumerable<string> actors = lookup["0001964"];
      foreach (var actor in actors)
        Console.WriteLine("{0}", actor);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_11()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      bool eq = presidents.SequenceEqual(presidents);
      Console.WriteLine(eq);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_12()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      bool eq = presidents.SequenceEqual(presidents.Take(presidents.Count()));
      Console.WriteLine(eq);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_13()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      bool eq = presidents.SequenceEqual(presidents.Take(presidents.Count() - 1));
      Console.WriteLine(eq);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_14()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      bool eq = presidents.SequenceEqual(presidents.Take(5).Concat(presidents.Skip(5)));
      Console.WriteLine(eq);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_15()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] stringifiedNums1 = { 
        "001", "49", "017", "0080", "00027", "2" };

      string[] stringifiedNums2 = { 
        "1", "0049", "17", "080", "27", "02" };

      bool eq = stringifiedNums1.SequenceEqual(stringifiedNums2,
                                               new MyStringifiedNumberComparer());

      Console.WriteLine(eq);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_16()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name = presidents.First();
      Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_17()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name = presidents.First(p => p.StartsWith("H"));
      Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_18()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name = presidents.Take(0).FirstOrDefault();
      Console.WriteLine(name == null ? "NULL" : name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_19()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name = presidents.FirstOrDefault();
      Console.WriteLine(name == null ? "NULL" : name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_20()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name = presidents.FirstOrDefault(p => p.StartsWith("B"));
      Console.WriteLine(name == null ? "NULL" : name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_21()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name = presidents.FirstOrDefault(p => p.StartsWith("Z"));
      Console.WriteLine(name == null ? "NULL" : name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_22()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name = presidents.Last();
      Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_23()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name = presidents.Last(p => p.StartsWith("H"));
      Console.WriteLine(name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_24()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name = presidents.Take(0).LastOrDefault();
      Console.WriteLine(name == null ? "NULL" : name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_25()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name = presidents.LastOrDefault();
      Console.WriteLine(name == null ? "NULL" : name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_26()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name = presidents.LastOrDefault(p => p.StartsWith("B"));
      Console.WriteLine(name == null ? "NULL" : name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_27()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string name = presidents.LastOrDefault(p => p.StartsWith("Z"));
      Console.WriteLine(name == null ? "NULL" : name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_28()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  For the Single call to not throw an exception, I must have a sequence with 
      //  a single element.  I will use the Where operator to insure this.
      Employee emp = Employee.GetEmployeesArray()
        .Where(e => e.id == 3).Single();

      Console.WriteLine("{0} {1}", emp.firstName, emp.lastName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_29()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  For the Single call to not throw an exception, I must have a sequence with 
      //  a single element.  I will use the Where operator to insure this.
      Employee emp = Employee.GetEmployeesArray()
          .Single(e => e.id == 3);

      Console.WriteLine("{0} {1}", emp.firstName, emp.lastName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_30()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Employee emp = Employee.GetEmployeesArray()
        .Where(e => e.id == 5).SingleOrDefault();

      Console.WriteLine(emp == null ? "NULL" :
        string.Format("{0} {1}", emp.firstName, emp.lastName));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_31()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Employee emp = Employee.GetEmployeesArray()
        .Where(e => e.id == 4).SingleOrDefault();

      Console.WriteLine(emp == null ? "NULL" :
        string.Format("{0} {1}", emp.firstName, emp.lastName));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_32()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Employee emp = Employee.GetEmployeesArray()
        .SingleOrDefault(e => e.id == 4);

      Console.WriteLine(emp == null ? "NULL" :
        string.Format("{0} {1}", emp.firstName, emp.lastName));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_33()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Employee emp = Employee.GetEmployeesArray()
        .SingleOrDefault(e => e.id == 5);

      Console.WriteLine(emp == null ? "NULL" :
        string.Format("{0} {1}", emp.firstName, emp.lastName));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_34()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Employee emp = Employee.GetEmployeesArray()
        .ElementAt(3);

      Console.WriteLine("{0} {1}", emp.firstName, emp.lastName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_35()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Employee emp = Employee.GetEmployeesArray()
        .ElementAtOrDefault(3);

      Console.WriteLine(emp == null ? "NULL" :
        string.Format("{0} {1}", emp.firstName, emp.lastName));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_36()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Employee emp = Employee.GetEmployeesArray()
        .ElementAtOrDefault(5);

      Console.WriteLine(emp == null ? "NULL" :
        string.Format("{0} {1}", emp.firstName, emp.lastName));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_37()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      bool any = Enumerable.Empty<string>().Any();
      Console.WriteLine(any);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_38()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      bool any = presidents.Any();
      Console.WriteLine(any);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_39()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      bool any = presidents.Any(s => s.StartsWith("Z"));
      Console.WriteLine(any);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_40()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      bool any = presidents.Any(s => s.StartsWith("A"));
      Console.WriteLine(any);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_41()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      bool all = presidents.All(s => s.Length > 5);
      Console.WriteLine(all);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_42()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      bool all = presidents.All(s => s.Length > 3);
      Console.WriteLine(all);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_43()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      bool contains = presidents.Contains("Rattz");
      Console.WriteLine(contains);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_44()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      bool contains = presidents.Contains("Hayes");
      Console.WriteLine(contains);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_45()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] stringifiedNums = { 
        "001", "49", "017", "0080", "00027", "2" };

      bool contains = stringifiedNums.Contains("0000002",
                                               new MyStringifiedNumberComparer());

      Console.WriteLine(contains);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_46()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] stringifiedNums = { 
        "001", "49", "017", "0080", "00027", "2" };

      bool contains = stringifiedNums.Contains("000271",
                                               new MyStringifiedNumberComparer());

      Console.WriteLine(contains);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_47()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      int count = presidents.Count();
      Console.WriteLine(count);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_48()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      int count = presidents.Count(s => s.StartsWith("J"));
      Console.WriteLine(count);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_49()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      long count = Enumerable.Range(0, int.MaxValue).
        Concat(Enumerable.Range(0, int.MaxValue)).LongCount();

      Console.WriteLine(count);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_50()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      long count = Enumerable.Range(0, int.MaxValue).
        Concat(Enumerable.Range(0, int.MaxValue)).LongCount(n => n > 1 && n < 4);

      Console.WriteLine(count);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_51()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  First I'll generate a sequence of integers.
      IEnumerable<int> ints = Enumerable.Range(1, 10);

      //  I'll show you the sequence of integers.
      foreach (int i in ints)
        Console.WriteLine(i);

      Console.WriteLine("--");

      //  Now, I'll sum them.
      int sum = ints.Sum();
      Console.WriteLine(sum);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_52()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      IEnumerable<EmployeeOptionEntry> options =
        EmployeeOptionEntry.GetEmployeeOptionEntries();

      long optionsSum = options.Sum(o => o.optionsCount);
      Console.WriteLine("The sum of the employee options is: {0}", optionsSum);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_53()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      int[] myInts = new int[] { 974, 2, 7, 1374, 27, 54 };
      int minInt = myInts.Min();
      Console.WriteLine(minInt);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_54()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string minName = presidents.Min();
      Console.WriteLine(minName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_55()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      int oldestActorAge = Actor.GetActors().Min(a => a.birthYear);
      Console.WriteLine(oldestActorAge);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_56()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string firstAlphabetically = Actor.GetActors().Min(a => a.lastName);
      Console.WriteLine(firstAlphabetically);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_57()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      int[] myInts = new int[] { 974, 2, 7, 1374, 27, 54 };
      int maxInt = myInts.Max();
      Console.WriteLine(maxInt);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_58()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string[] presidents = { 
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
        "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt", 
        "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

      string maxName = presidents.Max();
      Console.WriteLine(maxName);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_59()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      int youngestActorAge = Actor.GetActors().Max(a => a.birthYear);
      Console.WriteLine(youngestActorAge);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_60()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      string lastAlphabetically = Actor.GetActors().Max(a => a.lastName);
      Console.WriteLine(lastAlphabetically);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_61()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  First build a sequence of integers.
      IEnumerable<int> intSequence = Enumerable.Range(1, 10);
      Console.WriteLine("Here is my sequnece of integers:");
      foreach (int i in intSequence)
        Console.WriteLine(i);

      //  Now I'll get the average.
      double average = intSequence.Average();
      Console.WriteLine("Here is the average:  {0}", average);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_62()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  First, I'll get the sequence of EmployeeOptionEntry objects.
      IEnumerable<EmployeeOptionEntry> options =
        EmployeeOptionEntry.GetEmployeeOptionEntries();

      Console.WriteLine("Here are the employee ids and their options:");
      foreach (EmployeeOptionEntry eo in options)
        Console.WriteLine("Employee id:  {0},  Options:  {1}", eo.id, eo.optionsCount);

      //  Now I'll get the average of the options.
      double optionAverage = options.Average(o => o.optionsCount);
      Console.WriteLine("The average of the employee options is: {0}", optionAverage);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_63()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  First I need an array of integers from 1 to N where
      //  N is the number I want the factorial for.  In this case,
      //  N will be 5.
      int N = 5;
      IEnumerable<int> intSequence = Enumerable.Range(1, N);

      //  I will just ouput the sequence so all can see it.
      foreach (int item in intSequence)
        Console.WriteLine(item);

      //  Now calculate the factorial and display it.
      //  av == aggregated value, e == element
      int agg = intSequence.Aggregate((av, e) => av * e);
      Console.WriteLine("{0}! = {1}", N, agg);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing5_64()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Create a sequence of ints from 1 to 10.
      IEnumerable<int> intSequence = Enumerable.Range(1, 10);

      //  I'll just ouput the sequence so all can see it.
      foreach (int item in intSequence)
        Console.WriteLine(item);
      Console.WriteLine("--");

      //  Now calculate the sum and display it.
      int sum = intSequence.Aggregate(0, (s, i) => s + i);
      Console.WriteLine(sum);

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

  //  This class will be used by several examples.
  public class MyStringifiedNumberComparer : IEqualityComparer<string>
  {
    public bool Equals(string x, string y)
    {
      return (Int32.Parse(x) == Int32.Parse(y));
    }

    public int GetHashCode(string obj)
    {
      return Int32.Parse(obj).ToString().GetHashCode();
    }
  }

  //  This class will be used by several examples.
  public class Actor
  {
    public int birthYear;
    public string firstName;
    public string lastName;

    public static Actor[] GetActors()
    {
      Actor[] actors = new Actor[] {
        new Actor { birthYear = 1964, firstName = "Keanu", lastName = "Reeves" },
        new Actor { birthYear = 1968, firstName = "Owen", lastName = "Wilson" },
        new Actor { birthYear = 1960, firstName = "James", lastName = "Spader" },
        new Actor { birthYear = 1964, firstName = "Sandra", lastName = "Bullock" },
      };

      return (actors);
    }
  }

  //  This class will be used by Listing5_4 and Listing5_6.
  public class Employee2
  {
    public string id;
    public string firstName;
    public string lastName;

    public static ArrayList GetEmployeesArrayList()
    {
      ArrayList al = new ArrayList();

      al.Add(new Employee2 { id = "1", firstName = "Joe", lastName = "Rattz" });
      al.Add(new Employee2 { id = "2", firstName = "William", lastName = "Gates" });
      al.Add(new Employee2
      {
        id = "3",
        firstName = "Anders",
        lastName = "Hejlsberg"
      });
      al.Add(new Employee2 { id = "4", firstName = "David", lastName = "Lightman" });
      al.Add(new Employee2 { id = "101", firstName = "Kevin", lastName = "Flynn" });
      return (al);
    }

    public static Employee2[] GetEmployeesArray()
    {
      return ((Employee2[])GetEmployeesArrayList().ToArray(typeof(Employee2)));
    }
  }

  //  This class will be used by Listing5_8 and Listing5_10.
  public class Actor2
  {
    public string birthYear;
    public string firstName;
    public string lastName;

    public static Actor2[] GetActors()
    {
      Actor2[] actors = new Actor2[] {
        new Actor2 { birthYear = "1964", firstName = "Keanu", lastName = "Reeves" },
        new Actor2 { birthYear = "1968", firstName = "Owen", lastName = "Wilson" },
        new Actor2 { birthYear = "1960", firstName = "James", lastName = "Spader" },
        //  The worlds first Y10K compliant date!
        new Actor2 { birthYear = "01964", firstName = "Sandra", 
          lastName = "Bullock" },  
      };

      return (actors);
    }
  }
}
