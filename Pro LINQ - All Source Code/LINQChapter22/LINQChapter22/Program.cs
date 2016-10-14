using System;
using System.Collections.Generic;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;


namespace LINQChapter22 {
    class Program {
        static void Main(string[] args) {
            //  Uncomment the functions you want to call.

            //Listing22_1();
            //Listing22_2();

        }

        static void Listing22_1() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
                  "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
                  "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
                  "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
                  "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
                  "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
                  "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            string president = presidents.AsParallel()
                .Where(p => p.StartsWith("Lin")).First();

            Console.WriteLine(president);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing22_2() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            // create the sequential number range
            IEnumerable<int> numbers1 = Enumerable.Range(0, Int32.MaxValue);

            // start the stop watch
            Stopwatch sw = Stopwatch.StartNew();
            
            // perform the LINQ query
            int sum1 = (from n in numbers1
                         where n % 2 == 0
                         select n).Count();

            // write out the seqential result
            Console.WriteLine("Seqential result: {0}", sum1);
            // write out how long the sequential execution took
            Console.WriteLine("Sequential time: {0} ms", sw.ElapsedMilliseconds);

            // create the parallel number range
            IEnumerable<int> numbers2 = ParallelEnumerable.Range(0, Int32.MaxValue);
            // Restart the stopwatch
            sw.Restart();

            // perform the Parallel LINQ query
            int sum2 = (from n in numbers2.AsParallel()
                       where n % 2 == 0
                       select n).Count();

            // write the parallel result
            Console.WriteLine("Parallel result: {0}", sum2);
            // write out how long the parallel execution took
            Console.WriteLine("Parallel time: {0} ms", sw.ElapsedMilliseconds);

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }



    }

    
}
