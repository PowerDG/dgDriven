using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           test();
            //PLinq.pTest();
            //ETask.try1();
            //Console.ReadKey();
            new eventEX().Mainc();
            Console.ReadKey();
        }




        static void test()
        {
            int[] nums = new int[] { 1, 2, 3, 4  };
            int total = 0;
            Parallel.For<int>(0, nums.Length, () =>
            {
                return 0;
            },
            (i, loopState, subtotal) =>
            {
                subtotal += nums[i];
                return subtotal;
            },

            (x) => Interlocked.Add(ref total, x)
           );

            Console.WriteLine("total={0}", total);
            //Console.ReadKey();
        }


    }
}
