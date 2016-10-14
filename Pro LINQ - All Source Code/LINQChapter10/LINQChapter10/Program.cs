using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;
using System.Text;

namespace LINQChapter10
{
  //  A common class used by most examples.
  class Student
  {
    public int Id;
    public string Name;
  }

  //  A class used by Listing10_9.
  class StudentClass
  {
    public int Id;
    public string Class;
  }

  class Program
  {
    static void Main(string[] args)
    {
      //  Uncomment the functions you want to call.
      //YourTest();

      //Listing10_1();
      //Listing10_2();
      //Listing10_3();
      //Listing10_4();
      //Listing10_5();
      //Listing10_6();
      //Listing10_7();
      //Listing10_8();
      //Listing10_9();
      //Listing10_10();
      //Listing10_11();
      //Listing10_12();
      //Listing10_13();
      //Listing10_14();
      //Listing10_15();
      //Listing10_16();
      //Listing10_17();
      //Listing10_18();
      //Listing10_19();
    }

    static void YourTest()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      //  Do whatever you want in here.

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_1()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 6, Name = "Ulyses Hutchens" },
        new Student { Id = 19, Name = "Bob Tanko" },
        new Student { Id = 45, Name = "Erin Doutensal" },
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 12, Name = "Bob Mapplethorpe" },
        new Student { Id = 17, Name = "Anthony Adams" },
        new Student { Id = 32, Name = "Dignan Stephens" }
      };

      DataTable dt = GetDataTable(students);

      Console.WriteLine("{0}Before calling Distinct(){0}",
        System.Environment.NewLine);

      OutputDataTableHeader(dt, 15);

      foreach (DataRow dataRow in dt.Rows)
      {
        Console.WriteLine("{0,-15}{1,-15}",
          dataRow.Field<int>(0),
          dataRow.Field<string>(1));
      }

      IEnumerable<DataRow> distinct =
        dt.AsEnumerable().Distinct(DataRowComparer.Default);

      Console.WriteLine("{0}After calling Distinct(){0}",
        System.Environment.NewLine);

      OutputDataTableHeader(dt, 15);

      foreach (DataRow dataRow in distinct)
      {
        Console.WriteLine("{0,-15}{1,-15}",
          dataRow.Field<int>(0),
          dataRow.Field<string>(1));
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_2()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 6, Name = "Ulyses Hutchens" },
        new Student { Id = 19, Name = "Bob Tanko" },
        new Student { Id = 45, Name = "Erin Doutensal" },
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 12, Name = "Bob Mapplethorpe" },
        new Student { Id = 17, Name = "Anthony Adams" },
        new Student { Id = 32, Name = "Dignan Stephens" }
      };

      DataTable dt = GetDataTable(students);

      Console.WriteLine("{0}Before calling Distinct(){0}",
        System.Environment.NewLine);

      OutputDataTableHeader(dt, 15);

      foreach (DataRow dataRow in dt.Rows)
      {
        Console.WriteLine("{0,-15}{1,-15}",
          dataRow.Field<int>(0),
          dataRow.Field<string>(1));
      }

      IEnumerable<DataRow> distinct = dt.AsEnumerable().Distinct();

      Console.WriteLine("{0}After calling Distinct(){0}",
        System.Environment.NewLine);

      OutputDataTableHeader(dt, 15);

      foreach (DataRow dataRow in distinct)
      {
        Console.WriteLine("{0,-15}{1,-15}",
          dataRow.Field<int>(0),
          dataRow.Field<string>(1));
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_3()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      Student[] students2 = { 
        new Student { Id = 5, Name = "Abe Henry" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 29, Name = "Future Man" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      DataTable dt1 = GetDataTable(students);
      IEnumerable<DataRow> seq1 = dt1.AsEnumerable();
      DataTable dt2 = GetDataTable(students2);
      IEnumerable<DataRow> seq2 = dt2.AsEnumerable();

      IEnumerable<DataRow> except =
        seq1.Except(seq2, System.Data.DataRowComparer.Default);

      Console.WriteLine("{0}Results of Except() with comparer{0}",
        System.Environment.NewLine);

      OutputDataTableHeader(dt1, 15);

      foreach (DataRow dataRow in except)
      {
        Console.WriteLine("{0,-15}{1,-15}",
          dataRow.Field<int>(0),
          dataRow.Field<string>(1));
      }

      except = seq1.Except(seq2);

      Console.WriteLine("{0}Results of Except() without comparer{0}",
        System.Environment.NewLine);

      OutputDataTableHeader(dt1, 15);

      foreach (DataRow dataRow in except)
      {
        Console.WriteLine("{0,-15}{1,-15}",
          dataRow.Field<int>(0),
          dataRow.Field<string>(1));
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_4()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      Student[] students2 = { 
        new Student { Id = 5, Name = "Abe Henry" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 29, Name = "Future Man" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      DataTable dt1 = GetDataTable(students);
      IEnumerable<DataRow> seq1 = dt1.AsEnumerable();
      DataTable dt2 = GetDataTable(students2);
      IEnumerable<DataRow> seq2 = dt2.AsEnumerable();

      IEnumerable<DataRow> intersect =
        seq1.Intersect(seq2, System.Data.DataRowComparer.Default);

      Console.WriteLine("{0}Results of Intersect() with comparer{0}",
        System.Environment.NewLine);

      OutputDataTableHeader(dt1, 15);

      foreach (DataRow dataRow in intersect)
      {
        Console.WriteLine("{0,-15}{1,-15}",
          dataRow.Field<int>(0),
          dataRow.Field<string>(1));
      }

      intersect = seq1.Intersect(seq2);

      Console.WriteLine("{0}Results of Intersect() without comparer{0}",
        System.Environment.NewLine);

      OutputDataTableHeader(dt1, 15);

      foreach (DataRow dataRow in intersect)
      {
        Console.WriteLine("{0,-15}{1,-15}",
          dataRow.Field<int>(0),
          dataRow.Field<string>(1));
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_5()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      Student[] students2 = { 
        new Student { Id = 5, Name = "Abe Henry" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 29, Name = "Future Man" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      DataTable dt1 = GetDataTable(students);
      IEnumerable<DataRow> seq1 = dt1.AsEnumerable();
      DataTable dt2 = GetDataTable(students2);
      IEnumerable<DataRow> seq2 = dt2.AsEnumerable();

      IEnumerable<DataRow> union =
        seq1.Union(seq2, System.Data.DataRowComparer.Default);

      Console.WriteLine("{0}Results of Union() with comparer{0}",
        System.Environment.NewLine);

      OutputDataTableHeader(dt1, 15);

      foreach (DataRow dataRow in union)
      {
        Console.WriteLine("{0,-15}{1,-15}",
          dataRow.Field<int>(0),
          dataRow.Field<string>(1));
      }

      union = seq1.Union(seq2);

      Console.WriteLine("{0}Results of Union() without comparer{0}",
        System.Environment.NewLine);

      OutputDataTableHeader(dt1, 15);

      foreach (DataRow dataRow in union)
      {
        Console.WriteLine("{0,-15}{1,-15}",
          dataRow.Field<int>(0),
          dataRow.Field<string>(1));
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_6()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      DataTable dt1 = GetDataTable(students);
      IEnumerable<DataRow> seq1 = dt1.AsEnumerable();
      DataTable dt2 = GetDataTable(students);
      IEnumerable<DataRow> seq2 = dt2.AsEnumerable();

      bool equal = seq1.SequenceEqual(seq2, System.Data.DataRowComparer.Default);
      Console.WriteLine("SequenceEqual() with comparer : {0}", equal);

      equal = seq1.SequenceEqual(seq2);
      Console.WriteLine("SequenceEqual() without comparer : {0}", equal);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_7()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Console.WriteLine("(3 == 3) is {0}.", (3 == 3));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_8()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Console.WriteLine("((Object)3 == (Object)3) is {0}.", ((Object)3 == (Object)3));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_9()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      StudentClass[] classDesignations = { 
        new StudentClass { Id = 1, Class = "Sophmore" },
        new StudentClass { Id = 7, Class = "Freshman" },
        new StudentClass { Id = 13, Class = "Graduate" },
        new StudentClass { Id = 72, Class = "Senior" }
      };

      DataTable dt1 = GetDataTable(students);
      IEnumerable<DataRow> seq1 = dt1.AsEnumerable();
      DataTable dt2 = GetDataTable2(classDesignations);
      IEnumerable<DataRow> seq2 = dt2.AsEnumerable();

      string anthonysClass = (from s in seq1
                              where s.Field<string>("Name") == "Anthony Adams"
                              from c in seq2
                              where c["Id"] == s["Id"]
                              select (string)c["Class"]).
                             SingleOrDefault<string>();

      Console.WriteLine("Anthony's Class is: {0}",
        anthonysClass != null ? anthonysClass : "null");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_10()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      StudentClass[] classDesignations = { 
        new StudentClass { Id = 1, Class = "Sophmore" },
        new StudentClass { Id = 7, Class = "Freshman" },
        new StudentClass { Id = 13, Class = "Graduate" },
        new StudentClass { Id = 72, Class = "Senior" }
      };

      DataTable dt1 = GetDataTable(students);
      IEnumerable<DataRow> seq1 = dt1.AsEnumerable();
      DataTable dt2 = GetDataTable2(classDesignations);
      IEnumerable<DataRow> seq2 = dt2.AsEnumerable();

      string anthonysClass = (from s in seq1
                              where s.Field<string>("Name") == "Anthony Adams"
                              from c in seq2
                              where (int)c["Id"] == (int)s["Id"]
                              select (string)c["Class"]).
                             SingleOrDefault<string>();

      Console.WriteLine("Anthony's Class is: {0}",
        anthonysClass != null ? anthonysClass : "null");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_11()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      StudentClass[] classDesignations = { 
        new StudentClass { Id = 1, Class = "Sophmore" },
        new StudentClass { Id = 7, Class = "Freshman" },
        new StudentClass { Id = 13, Class = "Graduate" },
        new StudentClass { Id = 72, Class = "Senior" }
      };

      DataTable dt1 = GetDataTable(students);
      IEnumerable<DataRow> seq1 = dt1.AsEnumerable();
      DataTable dt2 = GetDataTable2(classDesignations);
      IEnumerable<DataRow> seq2 = dt2.AsEnumerable();

      string anthonysClass = (from s in seq1
                              where s.Field<string>("Name") == "Anthony Adams"
                              from c in seq2
                              where c.Field<int>("Id") == s.Field<int>("Id")
                              select (string)c["Class"]).
                             SingleOrDefault<string>();

      Console.WriteLine("Anthony's Class is: {0}",
        anthonysClass != null ? anthonysClass : "null");

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_12()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      DataTable dt1 = GetDataTable(students);
      IEnumerable<DataRow> seq1 = dt1.AsEnumerable();

      int id;

      //  Using prototype 1.
      id = (from s in seq1
            where s.Field<string>("Name") == "Anthony Adams"
            select s.Field<int>(dt1.Columns[0], DataRowVersion.Current)).
           Single<int>();
      Console.WriteLine("Anthony's Id retrieved with prototype 1 is: {0}", id);

      //  Using prototype 2.
      id = (from s in seq1
            where s.Field<string>("Name") == "Anthony Adams"
            select s.Field<int>("Id", DataRowVersion.Current)).
           Single<int>();
      Console.WriteLine("Anthony's Id retrieved with prototype 2 is: {0}", id);

      //  Using prototype 3.
      id = (from s in seq1
            where s.Field<string>("Name") == "Anthony Adams"
            select s.Field<int>(0, DataRowVersion.Current)).
           Single<int>();
      Console.WriteLine("Anthony's Id retrieved with prototype 3 is: {0}", id);

      //  Using prototype 4.
      id = (from s in seq1
            where s.Field<string>("Name") == "Anthony Adams"
            select s.Field<int>(dt1.Columns[0])).
           Single<int>();
      Console.WriteLine("Anthony's Id retrieved with prototype 4 is: {0}", id);

      //  Using prototype 5.
      id = (from s in seq1
            where s.Field<string>("Name") == "Anthony Adams"
            select s.Field<int>("Id")).
           Single<int>();
      Console.WriteLine("Anthony's Id retrieved with prototype 5 is: {0}", id);

      //  Using prototype 6.
      id = (from s in seq1
            where s.Field<string>("Name") == "Anthony Adams"
            select s.Field<int>(0)).
           Single<int>();
      Console.WriteLine("Anthony's Id retrieved with prototype 6 is: {0}", id);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_13()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      DataTable dt1 = GetDataTable(students);
      IEnumerable<DataRow> seq1 = dt1.AsEnumerable();

      DataRow row = (from s in seq1
                     where s.Field<string>("Name") == "Anthony Adams"
                     select s).Single<DataRow>();

      row.AcceptChanges();
      row.SetField("Name", "George Oscar Bluth");

      Console.WriteLine("Original value = {0} : Current value = {1}",
        row.Field<string>("Name", DataRowVersion.Original),
        row.Field<string>("Name", DataRowVersion.Current));

      row.AcceptChanges();
      Console.WriteLine("Original value = {0} : Current value = {1}",
        row.Field<string>("Name", DataRowVersion.Original),
        row.Field<string>("Name", DataRowVersion.Current));

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_14()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = null },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      DataTable dt1 = GetDataTable(students);
      IEnumerable<DataRow> seq1 = dt1.AsEnumerable();

      string name = seq1.Where(student => student.Field<int>("Id") == 7)
        .Select(student => (string)student["Name"])
        .Single();

      Console.WriteLine("Student's name is '{0}'", name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_15()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = null },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      DataTable dt1 = GetDataTable(students);
      IEnumerable<DataRow> seq1 = dt1.AsEnumerable();

      string name = seq1.Where(student => student.Field<int>("Id") == 7)
        .Select(student => student.Field<string>("Name"))
        .Single();

      Console.WriteLine("Student's name is '{0}'", name);

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_16()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      DataTable dt1 = GetDataTable(students);
      IEnumerable<DataRow> seq1 = dt1.AsEnumerable();

      Console.WriteLine("{0}Results before calling any prototype:",
        System.Environment.NewLine);

      foreach (DataRow dataRow in seq1)
      {
        Console.WriteLine("Student Id = {0} is {1}", dataRow.Field<int>("Id"),
          dataRow.Field<string>("Name"));
      }

      //  Using prototype 1.
      (from s in seq1
       where s.Field<string>("Name") == "Anthony Adams"
       select s).Single<DataRow>().SetField(dt1.Columns[1], "George Oscar Bluth");

      Console.WriteLine("{0}Results after calling prototype 1:",
        System.Environment.NewLine);

      foreach (DataRow dataRow in seq1)
      {
        Console.WriteLine("Student Id = {0} is {1}", dataRow.Field<int>("Id"),
          dataRow.Field<string>("Name"));
      }

      //  Using prototype 2.
      (from s in seq1
       where s.Field<string>("Name") == "George Oscar Bluth"
       select s).Single<DataRow>().SetField("Name", "Michael Bluth");

      Console.WriteLine("{0}Results after calling prototype 2:",
          System.Environment.NewLine);

      foreach (DataRow dataRow in seq1)
      {
        Console.WriteLine("Student Id = {0} is {1}", dataRow.Field<int>("Id"),
          dataRow.Field<string>("Name"));
      }

      //  Using prototype 3.
      (from s in seq1
       where s.Field<string>("Name") == "Michael Bluth"
       select s).Single<DataRow>().SetField("Name", "Tony Wonder");

      Console.WriteLine("{0}Results after calling prototype 3:",
        System.Environment.NewLine);

      foreach (DataRow dataRow in seq1)
      {
        Console.WriteLine("Student Id = {0} is {1}", dataRow.Field<int>("Id"),
          dataRow.Field<string>("Name"));
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_17()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      DataTable dt1 = GetDataTable(students);

      Console.WriteLine("Original DataTable:");
      foreach (DataRow dataRow in dt1.AsEnumerable())
      {
        Console.WriteLine("Student Id = {0} is {1}", dataRow.Field<int>("Id"),
          dataRow.Field<string>("Name"));
      }

      (from s in dt1.AsEnumerable()
       where s.Field<string>("Name") == "Anthony Adams"
       select s).Single<DataRow>().SetField("Name", "George Oscar Bluth");

      DataTable newTable = dt1.AsEnumerable().CopyToDataTable();

      Console.WriteLine("{0}New DataTable:", System.Environment.NewLine);
      foreach (DataRow dataRow in newTable.AsEnumerable())
      {
        Console.WriteLine("Student Id = {0} is {1}", dataRow.Field<int>("Id"),
          dataRow.Field<string>("Name"));
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_18()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      DataTable dt1 = GetDataTable(students);
      DataTable newTable = dt1.AsEnumerable().CopyToDataTable();

      Console.WriteLine("Before upserting DataTable:");
      foreach (DataRow dataRow in newTable.AsEnumerable())
      {
        Console.WriteLine("Student Id = {0} : original {1} : current {2}",
          dataRow.Field<int>("Id"),
          dataRow.Field<string>("Name", DataRowVersion.Original),
          dataRow.Field<string>("Name", DataRowVersion.Current));
      }

      (from s in dt1.AsEnumerable()
       where s.Field<string>("Name") == "Anthony Adams"
       select s).Single<DataRow>().SetField("Name", "George Oscar Bluth");

      dt1.AsEnumerable().CopyToDataTable(newTable, LoadOption.Upsert);

      Console.WriteLine("{0}After upserting DataTable:", System.Environment.NewLine);
      foreach (DataRow dataRow in newTable.AsEnumerable())
      {
        Console.WriteLine("Student Id = {0} : original {1} : current {2}",
          dataRow.Field<int>("Id"),
          dataRow.HasVersion(DataRowVersion.Original) ? 
            dataRow.Field<string>("Name", DataRowVersion.Original) : "-does not exist-",
          dataRow.Field<string>("Name", DataRowVersion.Current));
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    static void Listing10_19()
    {
      Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

      Student[] students = { 
        new Student { Id = 1, Name = "Joe Rattz" },
        new Student { Id = 7, Name = "Anthony Adams" },
        new Student { Id = 13, Name = "Stacy Sinclair" },
        new Student { Id = 72, Name = "Dignan Stephens" }
      };

      DataTable dt1 = GetDataTable(students);
      DataTable newTable = dt1.AsEnumerable().CopyToDataTable();
      newTable.PrimaryKey = new DataColumn[] { newTable.Columns[0] };

      Console.WriteLine("Before upserting DataTable:");
      foreach (DataRow dataRow in newTable.AsEnumerable())
      {
        Console.WriteLine("Student Id = {0} : original {1} : current {2}",
          dataRow.Field<int>("Id"),
          dataRow.Field<string>("Name", DataRowVersion.Original),
          dataRow.Field<string>("Name", DataRowVersion.Current));
      }

      (from s in dt1.AsEnumerable()
       where s.Field<string>("Name") == "Anthony Adams"
       select s).Single<DataRow>().SetField("Name", "George Oscar Bluth");

      dt1.AsEnumerable().CopyToDataTable(newTable, LoadOption.Upsert);

      Console.WriteLine("{0}After upserting DataTable:", System.Environment.NewLine);
      foreach (DataRow dataRow in newTable.AsEnumerable())
      {
        Console.WriteLine("Student Id = {0} : original {1} : current {2}",
          dataRow.Field<int>("Id"),
          dataRow.HasVersion(DataRowVersion.Original) ?
            dataRow.Field<string>("Name", DataRowVersion.Original) : "-does not exist-",
          dataRow.Field<string>("Name", DataRowVersion.Current));
      }

      Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
    }

    //  A common method used by most examples.
    static DataTable GetDataTable(Student[] students)
    {
      DataTable table = new DataTable();

      table.Columns.Add("Id", typeof(Int32));
      table.Columns.Add("Name", typeof(string));

      foreach (Student student in students)
      {
        table.Rows.Add(student.Id, student.Name);
      }

      return (table);
    }

    //  A method used by Listing10_9.
    static DataTable GetDataTable2(StudentClass[] studentClasses)
    {
      DataTable table = new DataTable();

      table.Columns.Add("Id", typeof(Int32));
      table.Columns.Add("Class", typeof(string));

      foreach (StudentClass studentClass in studentClasses)
      {
        table.Rows.Add(studentClass.Id, studentClass.Class);
      }

      return (table);
    }

    //  A common method used by most examples.
    static void OutputDataTableHeader(DataTable dt, int columnWidth)
    {
      string format = string.Format("{0}0,-{1}{2}", "{", columnWidth, "}");

      //  Display the column headings.
      foreach (DataColumn column in dt.Columns)
      {
        Console.Write(format, column.ColumnName);
      }
      Console.WriteLine();
      foreach (DataColumn column in dt.Columns)
      {
        for (int i = 0; i < columnWidth; i++)
        {
          Console.Write("=");
        }
      }
      Console.WriteLine();
    }
  }
}
