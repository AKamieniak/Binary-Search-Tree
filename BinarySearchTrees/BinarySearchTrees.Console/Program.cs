using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using BinarySearchTrees.Library;
using static System.IO.Path;

namespace BinarySearchTrees.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new DSWBalancedBinarySearchTree<int>();

            //for (var i = 0; i < 4; i++)
            //{
            //    bst.Insert(i);
            //}
            ////System.Console.WriteLine($"Before remove: {bst.GetJson()}");

            //var o = bst.Remove(1);

            //System.Console.WriteLine($"After remove: {bst.GetJson()}");

            TimingTest<int>(1000);
            System.Console.WriteLine("done");
            System.Console.Read();
        }

        public static void TimingTest<T>(int amount) where T : IComparable
        {
            var path = GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\\TimingTest.csv";
            var csv = new StringBuilder();
            csv.AppendLine("generic_list;bst_insert;balanced_insert;balanced_search;remove_balanced;");

            for (var i = 20; i < amount; i++)
            {
                var bstBalanced = new DSWBalancedBinarySearchTree<T>();
                var bst = new BinarySearchTree<T>();
                var genericList = new T[i];
                var watch = Stopwatch.StartNew();

                for (var j = 0; j < i; j++)
                {
                    genericList[j] = (T) Convert.ChangeType(j, typeof(T));                 
                }

                watch.Stop();
                var listTime = watch.Elapsed.TotalMilliseconds;
                watch = Stopwatch.StartNew();

                for (var j = 0; j < i; j++)
                {
                    bst.Insert((T) Convert.ChangeType(j, typeof(T)));
                }

                watch.Stop();
                var bstTime = watch.Elapsed.TotalMilliseconds;
                watch = Stopwatch.StartNew();

                for (var j = 0; j < i; j++)
                {
                    bstBalanced.Insert((T) Convert.ChangeType(j, typeof(T)));
                }

                watch.Stop();
                var balancedTime = watch.Elapsed.TotalMilliseconds;

                watch = Stopwatch.StartNew();
                bstBalanced.Search((T)Convert.ChangeType(0, typeof(T)));
                var search = watch.Elapsed.TotalMilliseconds;

                watch = Stopwatch.StartNew();
                bstBalanced.Remove((T)Convert.ChangeType(0, typeof(T)));
                var remove = watch.Elapsed.TotalMilliseconds;

                var newLine = $"{listTime};{bstTime};{balancedTime},{search},{remove}";
                csv.AppendLine(newLine);
            }

            File.WriteAllText(path, csv.ToString());
        }
    }
}
