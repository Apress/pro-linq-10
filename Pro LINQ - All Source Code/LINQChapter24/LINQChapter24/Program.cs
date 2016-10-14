using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;  //  For the StackTrace.
using System.Linq;


namespace LINQChapter24 {
    class Program {
        static void Main(string[] args) {
            
            //  Uncomment the functions you want to call.
            //Listing24_1();
            //Listing24_2();
            //Listing24_3();
            //Listing24_4();
            //Listing24_5();
            //Listing24_6();
            //Listing24_7();
            //Listing24_8();
            //Listing24_9();
            //Listing24_10();
            //Listing24_11();
            //Listing24_12();
            //Listing24_13();
            //Listing24_14();
            //Listing24_15();
            //Listing24_16();
        }

        static void Listing24_1() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            ParallelQuery<string> pq = presidents.AsParallel();

            IEnumerable<string> results = from p in pq
                      where p.Contains('o')
                      select p;

            foreach (string president in results) {
                Console.WriteLine("Match: {0}", president);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }


        static void Listing24_2() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            ArrayList list = new ArrayList() { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson"};

            IEnumerable<string> results = list
                .AsParallel()
                .Cast<string>()
                .Where(p => p.Contains('o'))
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Match: {0}", president);
            }    

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_3() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            ArrayList list = new ArrayList();
            
            list.Add("Adams");
            list.Add(23);
            list.Add("Arthur");
            list.Add(DateTime.Now);
            list.Add("Buchanan");
            list.Add(new string[] { "apple", "orange" });
            
            IEnumerable<string> results = list
                .AsParallel()
                .OfType<string>()
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Match: {0}", president);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_4() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            ParallelQuery<int> pq = ParallelEnumerable.Range(0, 10);

            foreach (int i in pq) {
                Console.WriteLine("Value {0}", i);
            }

            IEnumerable<int> results = from i in pq
                                       where i % 2 == 0
                                       select i;

            foreach (int i in results) {
                Console.WriteLine("Match: {0}", i);
            }
                
            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_5() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            ParallelQuery<int> pq = ParallelEnumerable.Repeat(2, 10);

            foreach (int i in pq) {
                Console.WriteLine("Value {0}", i);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_6() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

           string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            IEnumerable<string> results = presidents
                .AsParallel()
                .AsOrdered()
                .Where(p => p.Contains('o'))
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Match: {0}", president);
            }    

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_7() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            ArrayList list = new ArrayList() { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson"};

            IEnumerable<string> results = list
                .AsParallel()
                .AsOrdered()
                .Cast<string>()
                .Where(p => p.Contains('o'))
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Match: {0}", president);
            } 

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_8() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            IEnumerable<string> results = presidents
                .AsParallel()
                .AsOrdered()
                .Where(p => p.Contains('o'))
                .Take(5)
                .AsUnordered()
                .Where(p => p.Contains('e'))
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Match: {0}", president);
            }    

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_9() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            IEnumerable<string> results = presidents
                .AsParallel()
                .AsOrdered()
                .Where(p => p.Contains('o'))
                .Take(5)
                .AsSequential()
                .Where(p => p.Contains('e'))
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Match: {0}", president);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_10() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            IEnumerable<string> results = presidents
                .AsParallel()
                .AsOrdered()
                .Where(p => p.Contains('o'))
                .Take(5)
                .AsEnumerable()
                .Where(p => p.Contains('e'))
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Match: {0}", president);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_11() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            IEnumerable<string> results = presidents
                .AsParallel()
                .WithDegreeOfParallelism(2)
                .Where(p => p.Contains('o'))
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Match: {0}", president);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_12() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            string[] presidents = { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
              "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley", 
              "Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
              "Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            IEnumerable<string> results = presidents
                .AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .Where(p => p.Contains('o'))
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Match: {0}", president);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_13() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            IEnumerable<int> results = ParallelEnumerable.Range(0, 10)
                .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                .Select(i => {
                    System.Threading.Thread.Sleep(1000);
                    return i;
                });

            Stopwatch sw = Stopwatch.StartNew();

            foreach (int i in results) {
                Console.WriteLine("Value: {0}, Time: {1}", i, sw.ElapsedMilliseconds);
            }
           
            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_14() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            IEnumerable<int> results = ParallelEnumerable.Range(0, 10)
                .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                .Select(i => {
                    System.Threading.Thread.Sleep(1000);
                    return i;
                });

            Stopwatch sw = Stopwatch.StartNew();

            foreach (int i in results) {
                Console.WriteLine("Value: {0}, Time: {1}", i, sw.ElapsedMilliseconds);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_15() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            ArrayList list = new ArrayList() { 
              "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland", 
              "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford", "Garfield",
              "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson"};

            IEnumerable<string> results = list
                .AsParallel()
                .Cast<string>()
                .Where(p => p.Contains('o'))
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Match: {0}", president);
            } 

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }

        static void Listing24_16() {
            Console.WriteLine("{0} : Begin", new StackTrace(0, true).GetFrame(0).GetMethod().Name);

            ArrayList list = new ArrayList();

            list.Add("Adams");
            list.Add(23);
            list.Add("Arthur");
            list.Add(DateTime.Now);
            list.Add("Buchanan");
            list.Add(new string[] { "apple", "orange" });

            IEnumerable<string> results = list
                .AsParallel()
                .OfType<string>()
                .Select(p => p);

            foreach (string president in results) {
                Console.WriteLine("Match: {0}", president);
            }

            Console.WriteLine("{0} : End", new StackTrace(0, true).GetFrame(0).GetMethod().Name);
        }
    }
}
