using System;
using System.Collections.Generic;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;


namespace LINQChapter23 {
    class Program {
        static void Main(string[] args) {
            //  Uncomment the functions you want to call.

            //Listing23_1();
            //Listing23_2();
            //Listing23_3();
            //Listing23_4();
            //Listing23_5();
            //Listing23_6();
            //Listing23_7();
            //Listing23_8();
            //Listing23_9();
            //Listing23_10();
            //Listing23_11();
            //Listing23_12();


        }

        static void Listing23_1() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            // sequential LINQ query
            IEnumerable<string> results = from p in presidents
                                          where p.Contains('o')
                                          select p;

            foreach (string president in results) {
                Console.WriteLine("Sequential result: {0}", president);
            }

            // Parallel LINQ query
            results = from p in presidents.AsParallel()
                      where p.Contains('o')
                      select p;

            foreach (string president in results) {
                Console.WriteLine("Parallel result: {0}", president);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing23_2() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            IEnumerable<string> results = from p in presidents.AsParallel()
                                          where p.StartsWith("M")
                                          select p;

            foreach (string president in results) {
                Console.WriteLine("Query expression result: {0}", president);
            }

            results = presidents.AsParallel()
                .Where(p => p.StartsWith("M"))
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Extension method result: {0}", president);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing23_3() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            int count = presidents.AsParallel()
                .Where(p => p.Contains("o"))
                .Select(p => p)
                .Count();

            Console.WriteLine("Result count: {0}", count);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }


        static void Listing23_4() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            // Parallel LINQ query
            IEnumerable<string> results = from p in presidents.AsParallel().AsOrdered()
                                          where p.Contains('o')
                                          select p;

            foreach (string president in results) {
                Console.WriteLine("Parallel result: {0}", president);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing23_5() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            // Parallel LINQ query
            IEnumerable<string> results = presidents
                .AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .Where(p => p.Contains('o'))
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Parallel result: {0}", president);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing23_6() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            // Parallel LINQ query
            IEnumerable<string> results = presidents
                .AsParallel()
                .WithDegreeOfParallelism(2)
                .Where(p => p.Contains('o'))
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Parallel result: {0}", president);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing23_7() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            // Parallel LINQ query
            IEnumerable<string> results = presidents
                .Select(p => {
                    if (p == "Arthur")
                        throw new Exception(String.Format("Problem with President {0}", p));
                    return p;
                });


            try {
                foreach (string president in results) {
                    Console.WriteLine("Result: {0}", president);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing23_8() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            // Parallel LINQ query
            IEnumerable<string> results = presidents
                .AsParallel()
                .Select(p => {
                    if (p == "Arthur" || p == "Harding")
                        throw new Exception(String.Format("Problem with President {0}", p));
                    return p;
                });

            try {
                foreach (string president in results) {
                    Console.WriteLine("Result: {0}", president);
                }
            } catch (AggregateException agex) {
                agex.Handle(ex => {
                    Console.WriteLine(ex.Message);
                    return true;
                });
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing23_9() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            // Parallel LINQ query
            presidents.AsParallel()
                .Where(p => p.Contains('o'))
                .ForAll(p => Console.WriteLine("Name: {0}", p));
                    
            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing23_10() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            int count = 0;

            // Parallel LINQ query
            presidents.AsParallel()
                .ForAll(p => {
                    if (p.Contains('o')) {
                        System.Threading.Interlocked.Increment(ref count);
                    }
                });

            Console.WriteLine("Matches: {0}", count);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing23_11() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            IEnumerable<int> evens = ((ParallelQuery<int>) ParallelEnumerable.Range(0, 50000))
                .Where(i => i % 2 == 0)
                .Select(i => i);

            Console.WriteLine("Count: {0}", evens.Count());

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing23_12() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            int sum = ParallelEnumerable.Repeat(1, 50000)
                .Select(i => i)
                .Sum();

            Console.WriteLine("Sum: {0}", sum);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }
    }
}
