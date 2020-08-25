using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var re = new FetchPingAnOrderInfoRequest()
            { MerchantId = "11", RefId = "112" };
            re.ToJson();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
