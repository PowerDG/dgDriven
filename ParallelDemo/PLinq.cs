using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelDemo
{
    public static class PLinq
    {
        //public PLinq()
        //{
        //}
        public static void Invokest()
        {
            Parallel.Invoke(() =>
            {
                Console.WriteLine("任务1……");
            },
            () =>
            {
                Console.WriteLine("任务2……");
            },
            () =>
            {
                Console.WriteLine("任务3……");
            });
            Console.ReadKey();
        }

        public static void pTest()
        {
            List<int> intList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var query = from p in intList select p;
            Console.WriteLine("以下是LINQ顺序输出:");
            foreach (int item in query)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("以下是PLINQ并行输出:");
            var queryParallel = from p in intList.AsParallel() select p;
            foreach (int item in queryParallel)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("111:");
            queryParallel.ForAll((item) => { Console.WriteLine(item.ToString()); });


            Console.WriteLine("222:");

              queryParallel = from p in intList.AsParallel().AsOrdered()
                                select p;
            queryParallel.ForAll((item) =>
            {
                Console.WriteLine(item.ToString());
            });
            Console.WriteLine("333:");

              queryParallel = from p in intList.AsParallel().AsOrdered()
                                select p;
            foreach (int item in queryParallel)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("take:");

            foreach (int item in queryParallel.Take(5))
            {
                Console.WriteLine(item.ToString());
            }
        }


        public static void forT()
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            Parallel.For(0, nums.Length, (i) =>
            {
                Console.WriteLine("针对数组索引{0}对应的那个元素{1}的一些工作代码……", i, nums[i]);
            });
            Console.ReadKey();
        }
        public static void ForEachT()
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            Parallel.For(0, nums.Length, (i) =>
            {
                Console.WriteLine("针对数组索引{0}对应的那个元素{1}的一些工作代码……", i, nums[i]);
            });
            Console.ReadKey();
        }

        public static void ParallelStr()
        {
            string[] stringArr = new string[] { "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh" };
            string result = string.Empty;
            Parallel.For<string>(0, stringArr.Length, () => "-", (i, loopState, subResult) =>
            {
                return subResult += stringArr[i];
            },
            (threadEndString) =>
            {
                result += threadEndString;
                Console.WriteLine("Inner:" + threadEndString);
            });

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}