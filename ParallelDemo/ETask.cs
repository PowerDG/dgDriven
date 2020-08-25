using System;
using System.Threading.Tasks;

namespace ParallelDemo
{
    public static class ETask
    {
        //public ETask()
        //{
        //}



        public static void try1()
        {
            Task t = new Task(() =>
            {
                throw new Exception("任务并行编码中产生的未知异常");
            });

            t.Start();
            //try
            //{
            //    //若有Result,可求Result
            //    t.Wait();
            //}
            //catch (AggregateException e)
            //{
            //    foreach (var item in e.InnerExceptions)
            //    {
            //        Console.WriteLine("异常类型:{0}{1}来自: {2}{3}异常内容:{4}", item.GetType(),
            //        Environment.NewLine,
            //        item.Source, Environment.NewLine, item.Message);
            //    }
            //}

            Console.WriteLine("Enddd");
            Task tEnd = t.ContinueWith(
                (task) =>
                {
                    foreach (Exception item in task.Exception.InnerExceptions)
                    {
                        Console.WriteLine("异常类型:{0}{1}来自: {2}{3}异常内容:{4}",
                           item.GetType(), Environment.NewLine, item.Source, Environment.NewLine, item.Message);
                    }
                },
                TaskContinuationOptions.OnlyOnFaulted);
            Console.WriteLine("主线程马上结束");
            Console.ReadKey();
        }
    }
}
