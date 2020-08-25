using System;
using System.Threading.Tasks;

namespace ParallelDemo
{
    /// <summary>
    /// https://www.cnblogs.com/zhan520g/p/11083142.html
    /// </summary>
    public class eventEX
    {
          EventHandler<AggregateExceptionArgs> AggregateExceptionCatched;

        public class AggregateExceptionArgs : EventArgs
        {
            public AggregateException AggregateException { get; set; }

        }
        public void Mainc( )
        {
             AggregateExceptionCatched +=
                //EventHandler<AggregateExceptionArgs>
                (Program_AggregateExceptionCatched);
            Task t = new Task(() =>
            {
                try
                {
                    throw new InvalidOperationException("任务并行编码中产生的未知异常");
                }
                catch (Exception err)
                {
                    AggregateExceptionArgs errArgs = new AggregateExceptionArgs()
                    {
                        AggregateException = new AggregateException(err)
                    };
                    AggregateExceptionCatched(null, errArgs);
                }
            });

            t.Start();
            Console.WriteLine("主线程马上结束");
            Console.ReadKey();
        }

        //private static EventHandler<T> EventHandler<T>(Action<object, T> program_AggregateExceptionCatched)
        //{
        //    throw new NotImplementedException();
        //}

        static void Program_AggregateExceptionCatched(object sender, AggregateExceptionArgs e)
        {
            foreach (var item in e.AggregateException.InnerExceptions)
            {
                Console.WriteLine("异常类型:{0}{1}来自:{2}{3}异常内容:{4}", item.GetType(), Environment.NewLine, item.Source, Environment.NewLine, item.Message);
            }
        }

    }
}
